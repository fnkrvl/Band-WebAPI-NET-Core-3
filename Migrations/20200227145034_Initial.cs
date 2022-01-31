using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BandAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(nullable: false),
                    MainGenre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    BandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[,]
                {
                    { new Guid("15b239b4-369f-49f0-a0b8-531abf22d64e"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Metallica" },
                    { new Guid("78727b66-4fc8-4e00-908f-af747f68bf68"), new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Guns n Roses" },
                    { new Guid("deb0be4c-a2de-4465-8621-0d8dc0e61185"), new DateTime(1965, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "ABBA" },
                    { new Guid("fadf9cf0-573b-4e34-b611-d7e50ee6f595"), new DateTime(1991, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alternative", "Oasis" },
                    { new Guid("af44229e-d4b9-4081-9294-6957798022a6"), new DateTime(1981, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "A-ha" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("1520ee8a-17ef-4ac7-9585-7f090e238cfb"), new Guid("15b239b4-369f-49f0-a0b8-531abf22d64e"), "One of the best heavy metal albums ever.", "Master of Puppets" },
                    { new Guid("9c4c3f62-5f42-4729-b08e-3dcefdc7f04c"), new Guid("78727b66-4fc8-4e00-908f-af747f68bf68"), "Amazing Rock album with raw sound.", "Appetite for Destruction" },
                    { new Guid("d284779e-c930-4011-b190-44b5e359a758"), new Guid("deb0be4c-a2de-4465-8621-0d8dc0e61185"), "Very groovy album.", "Waterloo" },
                    { new Guid("e80e2ef3-4e13-4dd6-a8b3-a6b1ccfa517c"), new Guid("fadf9cf0-573b-4e34-b611-d7e50ee6f595"), "Arguably one of the best albums by Oasis.", "Be Here Now" },
                    { new Guid("0cfda149-e1d3-4b22-9d24-5418d4945597"), new Guid("af44229e-d4b9-4081-9294-6957798022a6"), "Awesome Debut album by A-ha.", "Hunting Hight and Low" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
