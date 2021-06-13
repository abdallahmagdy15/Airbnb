using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airbnb.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditExpire",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "CreditCards");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "CreditCards",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BuildingNo",
                table: "CreditCards",
                newName: "usercity");

            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "CreditCards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "CreditCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Value",
                table: "CreditCards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "CreditCards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "CreditCards");

            migrationBuilder.RenameColumn(
                name: "usercity",
                table: "CreditCards",
                newName: "BuildingNo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CreditCards",
                newName: "LastName");

            migrationBuilder.AlterColumn<int>(
                name: "CVV",
                table: "CreditCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreditExpire",
                table: "CreditCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "CreditCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "CreditCards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
