using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "OrgNumber" },
                values: new object[,]
                {
                    { 1, "IKEASWE", "1" },
                    { 2, "IKEANOR", "2" },
                    { 3, "IKEADEN", "3" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CEO" },
                    { 2, "Developer" },
                    { 3, "Manager" },
                    { 4, "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "Id", "CompanyId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "SWESales" },
                    { 2, 2, "NORLegal" },
                    { 3, 2, "NORStore" },
                    { 4, 3, "DENSales" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DivisionId", "FirstName", "LastName", "Salary", "TradeUnion" },
                values: new object[,]
                {
                    { 1, 4, "Brandon", "Rojas", 400000m, false },
                    { 2, 2, "Paula", "Harrison", 550000m, true },
                    { 3, 2, "Kasper", "Fuller", 475000m, true },
                    { 4, 4, "Wiktor", "Prince", 375000m, false }
                });

            migrationBuilder.InsertData(
                table: "EmployeePositions",
                columns: new[] { "EmployeeId", "PositionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeePositions",
                keyColumns: new[] { "EmployeeId", "PositionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeePositions",
                keyColumns: new[] { "EmployeeId", "PositionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeePositions",
                keyColumns: new[] { "EmployeeId", "PositionId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "EmployeePositions",
                keyColumns: new[] { "EmployeeId", "PositionId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "EmployeePositions",
                keyColumns: new[] { "EmployeeId", "PositionId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

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
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
