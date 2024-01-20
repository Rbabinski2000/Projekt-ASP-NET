using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Pesel = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Region = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StartPlace = table.Column<string>(type: "TEXT", nullable: false),
                    EndPlace = table.Column<string>(type: "TEXT", nullable: false),
                    Participants = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    GuideId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_organization_GuideId",
                        column: x => x.GuideId,
                        principalTable: "organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "organization",
                columns: new[] { "Id", "Name", "Pesel", "Surname", "Address_City", "Address_PostalCode", "Address_Region", "Address_Street" },
                values: new object[,]
                {
                    { 1, "Grzegorz", "13424234123", "Drewniak", "Kraków", "31-150", "małopolskie", "Św. Filipa 17" },
                    { 2, "Tomasz", "13424234567", "Drewniak", "Kraków", "31-150", "małopolskie", "Krowoderska 45/6" }
                });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Created", "EndDate", "EndPlace", "GuideId", "Name", "Participants", "StartDate", "StartPlace" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 20, 16, 27, 17, 725, DateTimeKind.Local).AddTicks(4709), new DateTime(2012, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kair", 1, "Niezapomniana Podróż-Kair", "Kamil,Dawid,Michał", new DateTime(2012, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warszawa" },
                    { 2, new DateTime(2024, 1, 20, 16, 27, 17, 725, DateTimeKind.Local).AddTicks(4759), new DateTime(2013, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egipt", 2, "Niezapomniana Podróż-Egipt", "Kamil,Dawid,Gabryś", new DateTime(2013, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kraków" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_GuideId",
                table: "Travels",
                column: "GuideId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "organization");
        }
    }
}
