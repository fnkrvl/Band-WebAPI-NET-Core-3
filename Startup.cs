using AutoMapper;
using BandAPI.DbContexts;
using BandAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;

namespace BandAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();

            services.AddControllers(setupAction =>
            {                                                                                           // 406 Not Acceptable
                setupAction.ReturnHttpNotAcceptable = true; // Permite devolver si el formato seleccionado no es soportado | XML or JSON
                setupAction.CacheProfiles.Add("90SecondsCacheProfile", new CacheProfile { Duration = 90});
            }).AddXmlDataContractSerializerFormatters()     // Permite aceptar devolver el resultado en XML 
              .AddNewtonsoftJson(setupAction => 
              {
                  setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); 
              }); 

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IBandAlbumRepository, BandAlbumRepository>();

            services.AddScoped<IPropertyMappingService, PropertyMappingService>();

            services.AddScoped<IPropertyValidationService, PropertyValidationService>();

            services.AddDbContext<BandAlbumContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async c =>
                    {
                        c.Response.StatusCode = 500;
                        await c.Response.WriteAsync("Something went horribly wrong, try again later.");
                    });
                });
            }

            app.UseResponseCaching();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
