using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2528a868-07b4-4d26-b96a-b0cb18e0bd05"), new DateTime(2024, 12, 22, 19, 49, 28, 668, DateTimeKind.Local).AddTicks(3471), "Telefon", 20000m, 12, null },
                    { new Guid("30a8e2ad-eda9-4c4a-b3dd-081624f67d30"), new DateTime(2024, 12, 22, 19, 49, 28, 668, DateTimeKind.Local).AddTicks(3481), "Tablet", 8000m, 7, null },
                    { new Guid("91b9889d-2019-4e5e-9c89-f0010c9b6e93"), new DateTime(2024, 12, 22, 19, 49, 28, 668, DateTimeKind.Local).AddTicks(3156), "Laptop", 50000m, 10, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "PWHash", "PWSalt", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("7423cc82-b04f-4055-829f-7992b2d73218"), new DateTime(2024, 12, 22, 19, 49, 28, 667, DateTimeKind.Local).AddTicks(2226), "Admin", "Admin", new byte[] { 214, 48, 148, 32, 58, 199, 86, 153, 231, 140, 108, 205, 162, 136, 148, 106, 76, 177, 18, 241, 240, 140, 223, 39, 253, 109, 95, 26, 141, 44, 64, 210, 120, 229, 247, 170, 191, 247, 83, 175, 213, 199, 192, 57, 41, 99, 230, 90, 65, 84, 126, 71, 72, 67, 148, 224, 166, 250, 129, 105, 111, 152, 27, 84 }, new byte[] { 221, 57, 155, 174, 151, 49, 132, 182, 146, 194, 31, 184, 217, 172, 103, 161, 226, 144, 72, 216, 232, 138, 27, 152, 120, 255, 135, 253, 75, 39, 23, 172, 25, 71, 129, 212, 174, 228, 210, 13, 117, 27, 133, 112, 8, 202, 209, 153, 46, 107, 123, 221, 123, 151, 67, 3, 43, 60, 42, 5, 227, 224, 179, 203, 7, 12, 39, 118, 31, 210, 127, 89, 43, 119, 183, 17, 206, 164, 59, 248, 165, 137, 0, 237, 116, 59, 166, 34, 112, 175, 156, 160, 43, 115, 127, 71, 234, 95, 35, 131, 4, 223, 41, 41, 133, 35, 53, 25, 158, 199, 201, 254, 239, 16, 163, 241, 244, 150, 250, 212, 41, 146, 121, 122, 140, 6, 140, 104 }, null, "admin" },
                    { new Guid("e6cdc519-0d8c-4c6e-9f01-458fbda440c0"), new DateTime(2024, 12, 22, 19, 49, 28, 668, DateTimeKind.Local).AddTicks(2364), "Test", "Test", new byte[] { 214, 48, 148, 32, 58, 199, 86, 153, 231, 140, 108, 205, 162, 136, 148, 106, 76, 177, 18, 241, 240, 140, 223, 39, 253, 109, 95, 26, 141, 44, 64, 210, 120, 229, 247, 170, 191, 247, 83, 175, 213, 199, 192, 57, 41, 99, 230, 90, 65, 84, 126, 71, 72, 67, 148, 224, 166, 250, 129, 105, 111, 152, 27, 84 }, new byte[] { 221, 57, 155, 174, 151, 49, 132, 182, 146, 194, 31, 184, 217, 172, 103, 161, 226, 144, 72, 216, 232, 138, 27, 152, 120, 255, 135, 253, 75, 39, 23, 172, 25, 71, 129, 212, 174, 228, 210, 13, 117, 27, 133, 112, 8, 202, 209, 153, 46, 107, 123, 221, 123, 151, 67, 3, 43, 60, 42, 5, 227, 224, 179, 203, 7, 12, 39, 118, 31, 210, 127, 89, 43, 119, 183, 17, 206, 164, 59, 248, 165, 137, 0, 237, 116, 59, 166, 34, 112, 175, 156, 160, 43, 115, 127, 71, 234, 95, 35, 131, 4, 223, 41, 41, 133, 35, 53, 25, 158, 199, 201, 254, 239, 16, 163, 241, 244, 150, 250, 212, 41, 146, 121, 122, 140, 6, 140, 104 }, null, "test" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("7423cc82-b04f-4055-829f-7992b2d73218") },
                    { 2, new Guid("e6cdc519-0d8c-4c6e-9f01-458fbda440c0") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2528a868-07b4-4d26-b96a-b0cb18e0bd05"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30a8e2ad-eda9-4c4a-b3dd-081624f67d30"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("91b9889d-2019-4e5e-9c89-f0010c9b6e93"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("7423cc82-b04f-4055-829f-7992b2d73218") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("e6cdc519-0d8c-4c6e-9f01-458fbda440c0") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7423cc82-b04f-4055-829f-7992b2d73218"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e6cdc519-0d8c-4c6e-9f01-458fbda440c0"));
        }
    }
}
