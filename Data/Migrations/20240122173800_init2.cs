using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "68ab30dc-bfe1-4202-be84-5bc9d4d32bbf", "2e32c241-af4f-40a0-9d8a-3c05ae8c884e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68ab30dc-bfe1-4202-be84-5bc9d4d32bbf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e32c241-af4f-40a0-9d8a-3c05ae8c884e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c53cec76-a301-439f-9993-373a38b0ccf9", "c53cec76-a301-439f-9993-373a38b0ccf9", "admin", "ADMIN" },
                    { "e13382bc-6fe3-4e96-a4d0-b02eedf7c136", "e13382bc-6fe3-4e96-a4d0-b02eedf7c136", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c74fabfc-8f7b-4762-bf0a-819cce548322", 0, "52a08a0c-3788-44aa-99cd-6e9d378eb742", "adamo@micros.com", true, false, null, "ADAMO@MICROS.COM", "ADAMO", "AQAAAAIAAYagAAAAEKb1woIgA9IFIkptUn83ZeyMSPFWO4Tl769oV+1yVpHvJA3D/CJcDjFra7J9M200tA==", null, false, "b854369f-0aec-410f-a94d-1433e968114a", false, "adamo" });

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 22, 18, 37, 59, 916, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 22, 18, 37, 59, 916, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c53cec76-a301-439f-9993-373a38b0ccf9", "c74fabfc-8f7b-4762-bf0a-819cce548322" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e13382bc-6fe3-4e96-a4d0-b02eedf7c136");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c53cec76-a301-439f-9993-373a38b0ccf9", "c74fabfc-8f7b-4762-bf0a-819cce548322" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c53cec76-a301-439f-9993-373a38b0ccf9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c74fabfc-8f7b-4762-bf0a-819cce548322");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68ab30dc-bfe1-4202-be84-5bc9d4d32bbf", "68ab30dc-bfe1-4202-be84-5bc9d4d32bbf", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2e32c241-af4f-40a0-9d8a-3c05ae8c884e", 0, "5ae8affa-f3df-415e-bb3a-cf39a8b83be4", "adamo@micros.com", true, false, null, "ADAMO@MICROS.COM", "ADAMO", "AQAAAAIAAYagAAAAEFX/mCgRyRNl+PTzEDvMImuTRfuYGAQTre2qwLeU4i90wStDXwnMXh9imob4dg/+qA==", null, false, "8e35afd6-980f-4cca-a687-c3e1b68a26d5", false, "adamo" });

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 22, 14, 59, 50, 102, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 22, 14, 59, 50, 102, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "68ab30dc-bfe1-4202-be84-5bc9d4d32bbf", "2e32c241-af4f-40a0-9d8a-3c05ae8c884e" });
        }
    }
}
