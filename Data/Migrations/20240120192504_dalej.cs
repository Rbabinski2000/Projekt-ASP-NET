using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class dalej : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8c642819-fa43-41a5-95f1-afc38c807a91", "52ac1cfc-dfa3-4b22-84ab-905e6dd31656" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c642819-fa43-41a5-95f1-afc38c807a91");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52ac1cfc-dfa3-4b22-84ab-905e6dd31656");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e485f291-59e4-4b40-b97c-d41d183675c1", "e485f291-59e4-4b40-b97c-d41d183675c1", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bfa0e51b-53ba-4c4f-8eba-76c2f0458c13", 0, "b1178067-071d-48aa-bb70-391f90e47bcd", "adamo@micros.com", true, false, null, "ADAMO@MICROS.COM", "ADAMO", "AQAAAAIAAYagAAAAEHP1JuZoLyJVR2XnGrYbosenCzDP+UTwQNb33T53t2gdOWw53jJ+lx6FpE6Frz/3tA==", null, false, "cbb841e3-5a9a-40b1-9981-74334ab45f0b", false, "adamo" });

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 20, 20, 25, 4, 671, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 20, 20, 25, 4, 671, DateTimeKind.Local).AddTicks(9900));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e485f291-59e4-4b40-b97c-d41d183675c1", "bfa0e51b-53ba-4c4f-8eba-76c2f0458c13" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e485f291-59e4-4b40-b97c-d41d183675c1", "bfa0e51b-53ba-4c4f-8eba-76c2f0458c13" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e485f291-59e4-4b40-b97c-d41d183675c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfa0e51b-53ba-4c4f-8eba-76c2f0458c13");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c642819-fa43-41a5-95f1-afc38c807a91", "8c642819-fa43-41a5-95f1-afc38c807a91", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "52ac1cfc-dfa3-4b22-84ab-905e6dd31656", 0, "2635914b-5c93-494f-a024-002acd82a8a0", "adamo@micros.com", true, false, null, "ADAMO@MICROS.COM", "ADAMO", "AQAAAAIAAYagAAAAEBKHhgFoB21BHHHp619ibEkUEr/Jy+BnSqAV3G1RORPuHmK7gENSPbN2GLb5z/BvDg==", null, false, "1ebbeaa6-c37c-4c2e-bbe5-b5d6f62fc94e", false, "adamo" });

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 20, 18, 32, 41, 538, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 20, 18, 32, 41, 538, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8c642819-fa43-41a5-95f1-afc38c807a91", "52ac1cfc-dfa3-4b22-84ab-905e6dd31656" });
        }
    }
}
