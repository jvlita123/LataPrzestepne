using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaimsIdentity.Migrations
{
    public partial class MyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Person",
                newName: "ErrorMessage");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Person",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Person",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Person",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "data",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "data",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "ErrorMessage",
                table: "Person",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
