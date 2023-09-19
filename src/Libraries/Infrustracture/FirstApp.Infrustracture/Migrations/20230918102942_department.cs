using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApp.Infrustracture.Migrations
{
    /// <inheritdoc />
    public partial class department : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 9, 18, 16, 29, 41, 477, DateTimeKind.Unspecified).AddTicks(8088), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 9, 18, 16, 29, 41, 477, DateTimeKind.Unspecified).AddTicks(8132), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Created", "CreatedBy", "DepartmentName", "LastModified", "LastModifiedBy", "Stutas" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 9, 18, 16, 29, 41, 478, DateTimeKind.Unspecified).AddTicks(1221), new TimeSpan(0, 6, 0, 0, 0)), "HHH", "IT", null, null, 1 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 9, 18, 16, 29, 41, 481, DateTimeKind.Unspecified).AddTicks(5007), new TimeSpan(0, 6, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 9, 18, 15, 54, 59, 918, DateTimeKind.Unspecified).AddTicks(6466), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 9, 18, 15, 54, 59, 918, DateTimeKind.Unspecified).AddTicks(6516), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 9, 18, 15, 54, 59, 922, DateTimeKind.Unspecified).AddTicks(6949), new TimeSpan(0, 6, 0, 0, 0)));
        }
    }
}
