using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MailLibrary.Migrations
{
    public partial class FixSeedingSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 12, 18, 17, 19, 49, 877, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2020, 12, 18, 17, 19, 49, 878, DateTimeKind.Local).AddTicks(5643));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2020, 12, 18, 17, 19, 49, 878, DateTimeKind.Local).AddTicks(5658));
        }
    }
}
