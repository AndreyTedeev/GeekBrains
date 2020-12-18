using Microsoft.EntityFrameworkCore.Migrations;

namespace MailLibrary.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Emails",
                columns: new[] { "Id", "Message", "Subject" },
                values: new object[,]
                {
                    { 1, "Test... 1", "Test Email #1" },
                    { 2, "Test... 2", "Test Email #2" },
                    { 3, "Test... 3", "Test Email #3" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Recipients",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "john@yandex.ru", "John Lennon" },
                    { 2, "gaga@yandex.ru", "Lady Gaga" },
                    { 3, "kperry@yandex.ru", "Katy Perry" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Senders",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "iviv@yandex.ru", "Ivan Ivanov" },
                    { 2, "pepe@yandex.ru", "Petr Petrov" },
                    { 3, "sidor@yandex.ru", "Sidor Sidorov" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Emails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Emails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Recipients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Recipients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Recipients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Senders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Senders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Senders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
