using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MailLibrary.Migrations
{
    public partial class SeedSchedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Emails_EmailId",
                schema: "dbo",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Recipients_RecipientId",
                schema: "dbo",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Senders_SenderId",
                schema: "dbo",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Servers_ServerId",
                schema: "dbo",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "ServerId",
                schema: "dbo",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                schema: "dbo",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipientId",
                schema: "dbo",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmailId",
                schema: "dbo",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Schedules",
                columns: new[] { "Id", "DateTime", "EmailId", "RecipientId", "SenderId", "ServerId" },
                values: new object[] { 1, new DateTime(2020, 12, 18, 17, 19, 49, 877, DateTimeKind.Local).AddTicks(7748), 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Schedules",
                columns: new[] { "Id", "DateTime", "EmailId", "RecipientId", "SenderId", "ServerId" },
                values: new object[] { 2, new DateTime(2020, 12, 18, 17, 19, 49, 878, DateTimeKind.Local).AddTicks(5643), 2, 2, 2, 2 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Schedules",
                columns: new[] { "Id", "DateTime", "EmailId", "RecipientId", "SenderId", "ServerId" },
                values: new object[] { 3, new DateTime(2020, 12, 18, 17, 19, 49, 878, DateTimeKind.Local).AddTicks(5658), 3, 3, 3, 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Emails_EmailId",
                schema: "dbo",
                table: "Schedules",
                column: "EmailId",
                principalSchema: "dbo",
                principalTable: "Emails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Recipients_RecipientId",
                schema: "dbo",
                table: "Schedules",
                column: "RecipientId",
                principalSchema: "dbo",
                principalTable: "Recipients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Senders_SenderId",
                schema: "dbo",
                table: "Schedules",
                column: "SenderId",
                principalSchema: "dbo",
                principalTable: "Senders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Servers_ServerId",
                schema: "dbo",
                table: "Schedules",
                column: "ServerId",
                principalSchema: "dbo",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Emails_EmailId",
                schema: "dbo",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Recipients_RecipientId",
                schema: "dbo",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Senders_SenderId",
                schema: "dbo",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Servers_ServerId",
                schema: "dbo",
                table: "Schedules");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "ServerId",
                schema: "dbo",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                schema: "dbo",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RecipientId",
                schema: "dbo",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmailId",
                schema: "dbo",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Emails_EmailId",
                schema: "dbo",
                table: "Schedules",
                column: "EmailId",
                principalSchema: "dbo",
                principalTable: "Emails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Recipients_RecipientId",
                schema: "dbo",
                table: "Schedules",
                column: "RecipientId",
                principalSchema: "dbo",
                principalTable: "Recipients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Senders_SenderId",
                schema: "dbo",
                table: "Schedules",
                column: "SenderId",
                principalSchema: "dbo",
                principalTable: "Senders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Servers_ServerId",
                schema: "dbo",
                table: "Schedules",
                column: "ServerId",
                principalSchema: "dbo",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
