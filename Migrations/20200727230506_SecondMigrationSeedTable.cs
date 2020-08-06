using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkcoreCodeFirstApproach.Migrations
{
    public partial class SecondMigrationSeedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Fullname", "Salary" },
                values: new object[] { 1, 4, "wonkulahp@yahoo.com", "Precious K Wonkulah", 10000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Fullname", "Salary" },
                values: new object[] { 2, 2, "tuseTheProgrammer@outlook.com", "Dad S Wonkulah", 15000m });
        }

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
        }
    }
}
