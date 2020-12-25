using Microsoft.EntityFrameworkCore.Migrations;

namespace MailLibrary.Migrations
{
    public partial class SeedServers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Servers",
                columns: new[] { "Id", "Host", "Password", "Port", "User" },
                values: new object[] { 1, "smtp.yandex.ru", "", 565, "test" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Servers",
                columns: new[] { "Id", "Host", "Password", "Port", "User" },
                values: new object[] { 2, "smtp.mail.ru", "", 25, "test" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Servers",
                columns: new[] { "Id", "Host", "Password", "Port", "User" },
                values: new object[] { 3, "smtp.gmail.com", "", 467, "test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Servers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Servers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Servers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
