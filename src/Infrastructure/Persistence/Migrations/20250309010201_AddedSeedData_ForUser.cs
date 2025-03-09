using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData_ForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 9, 4, 2, 1, 339, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 9, 4, 2, 1, 339, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 9, 4, 2, 1, 339, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 9, 4, 2, 1, 339, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 9, 4, 2, 1, 339, DateTimeKind.Local).AddTicks(9157));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "FirstName", "Gender", "IsActive", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Type", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2025, 3, 9, 4, 2, 1, 340, DateTimeKind.Local).AddTicks(3411), null, "admin@admin.com", "Admin", (byte)0, true, "Admin", new byte[] { 125, 8, 131, 92, 88, 157, 255, 245, 142, 200, 177, 0, 27, 9, 250, 99, 58, 204, 252, 150, 85, 225, 202, 151, 138, 135, 241, 138, 58, 160, 159, 231, 39, 123, 193, 21, 7, 179, 114, 139, 51, 239, 144, 172, 157, 156, 156, 30, 111, 45, 14, 115, 186, 192, 97, 89, 31, 225, 169, 8, 188, 129, 63, 146 }, new byte[] { 241, 214, 235, 133, 185, 140, 20, 6, 37, 80, 72, 147, 8, 147, 118, 231, 163, 62, 210, 135, 142, 197, 89, 21, 235, 236, 182, 74, 131, 103, 87, 173, 251, 37, 60, 180, 49, 244, 120, 236, 141, 115, 233, 169, 182, 61, 86, 169, 135, 201, 47, 2, 158, 77, 70, 56, 199, 96, 156, 90, 201, 224, 125, 230, 50, 145, 37, 107, 128, 98, 61, 175, 141, 228, 140, 10, 188, 52, 36, 51, 66, 12, 61, 125, 100, 223, 255, 200, 39, 150, 193, 176, 170, 249, 235, 70, 123, 19, 54, 132, 160, 227, 121, 187, 174, 220, 149, 90, 195, 4, 117, 237, 176, 139, 151, 20, 5, 42, 144, 161, 248, 178, 230, 47, 252, 137, 77, 105 }, "1234567890", (byte)1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 17, 54, 6, 29, DateTimeKind.Local).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 17, 54, 6, 29, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 17, 54, 6, 30, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 17, 54, 6, 30, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 17, 54, 6, 30, DateTimeKind.Local).AddTicks(7706));
        }
    }
}
