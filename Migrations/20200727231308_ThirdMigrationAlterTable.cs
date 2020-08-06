using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkcoreCodeFirstApproach.Migrations
{
    public partial class ThirdMigrationAlterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Fullname" },
                values: new object[] { "john@yahoo.com", "John Brown" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Fullname" },
                values: new object[] { "mary@outlook.com", "Mary Smith" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Fullname" },
                values: new object[] { "wonkulahp@yahoo.com", "Precious K Wonkulah" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Fullname" },
                values: new object[] { "tuseTheProgrammer@outlook.com", "Dad S Wonkulah" });
        }
    }
}
