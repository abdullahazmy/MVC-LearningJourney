using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo1.Migrations
{
    /// <inheritdoc />
    public partial class AddModelSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Building A", "IT" },
                    { 2, "Building B", "HR" },
                    { 3, "Building C", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "ImageUrl", "Name", "Position", "Salary" },
                values: new object[,]
                {
                    { 1, 1, null, "Abdullah", "Software Engineer", 10000m },
                    { 2, 2, null, "Mona", "HR Manager", 8000m },
                    { 3, 1, null, "Ali", "DevOps Engineer", 9000m },
                    { 4, 3, null, "Sara", "Accountant", 9500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
