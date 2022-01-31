using BandAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.DbContexts
{
    public class BandAlbumContext : DbContext
    {
               
        public BandAlbumContext(DbContextOptions<BandAlbumContext> options) :
            base(options)
        {
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(
            new Band()
            {
                Id = Guid.Parse("15b239b4-369f-49f0-a0b8-531abf22d64e"),
                Name = "Metallica",
                Founded = new DateTime(1980, 1, 1),
                MainGenre = "Heavy Metal"
            },
            new Band
            {
                Id = Guid.Parse("78727b66-4fc8-4e00-908f-af747f68bf68"),
                Name = "Guns n Roses",
                Founded = new DateTime(1985, 2, 1),
                MainGenre = "Rock"
            },
            new Band
            {
                Id = Guid.Parse("deb0be4c-a2de-4465-8621-0d8dc0e61185"), 
                Name = "ABBA",
                Founded = new DateTime(1965, 7, 1),
                MainGenre = "Disco"
            },
            new Band
            {
                Id = Guid.Parse("fadf9cf0-573b-4e34-b611-d7e50ee6f595"),
                Name = "Oasis",
                Founded = new DateTime(1991, 12, 1),
                MainGenre = "Alternative"
            },
            new Band
            {
                Id = Guid.Parse("af44229e-d4b9-4081-9294-6957798022a6"),
                Name = "A-ha",
                Founded = new DateTime(1981, 6, 1),
                MainGenre = "Pop"
            });


            modelBuilder.Entity<Album>().HasData(
            new Album
            {
                Id = Guid.Parse("1520ee8a-17ef-4ac7-9585-7f090e238cfb"),
                Title = "Master of Puppets",
                Description = "One of the best heavy metal albums ever.",
                BandId = Guid.Parse("15b239b4-369f-49f0-a0b8-531abf22d64e"),
            },
            new Album
            {
                Id = Guid.Parse("9c4c3f62-5f42-4729-b08e-3dcefdc7f04c"),
                Title = "Appetite for Destruction",
                Description = "Amazing Rock album with raw sound.",
                BandId = Guid.Parse("78727b66-4fc8-4e00-908f-af747f68bf68"),
            },
            new Album
            {
                Id = Guid.Parse("d284779e-c930-4011-b190-44b5e359a758"),
                Title = "Waterloo",
                Description = "Very groovy album.",
                BandId = Guid.Parse("deb0be4c-a2de-4465-8621-0d8dc0e61185"),
            },
            new Album
            {
                Id = Guid.Parse("e80e2ef3-4e13-4dd6-a8b3-a6b1ccfa517c"),
                Title = "Be Here Now",
                Description = "Arguably one of the best albums by Oasis.",
                BandId = Guid.Parse("fadf9cf0-573b-4e34-b611-d7e50ee6f595"),
            },
            new Album
            {
                Id = Guid.Parse("0cfda149-e1d3-4b22-9d24-5418d4945597"),
                Title = "Hunting Hight and Low",
                Description = "Awesome Debut album by A-ha.",
                BandId = Guid.Parse("af44229e-d4b9-4081-9294-6957798022a6"),
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
