using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dziennik.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogloszenie_Nauczanie_NauczanieId",
                table: "Ogloszenie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ogloszenie",
                table: "Ogloszenie");

            migrationBuilder.RenameTable(
                name: "Ogloszenie",
                newName: "Wydarzenie");

            migrationBuilder.RenameIndex(
                name: "IX_Ogloszenie_NauczanieId",
                table: "Wydarzenie",
                newName: "IX_Wydarzenie_NauczanieId");

            migrationBuilder.AddColumn<DateTime>(
                name: "data",
                table: "Ocena",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wydarzenie",
                table: "Wydarzenie",
                column: "WydarzenieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wydarzenie_Nauczanie_NauczanieId",
                table: "Wydarzenie",
                column: "NauczanieId",
                principalTable: "Nauczanie",
                principalColumn: "NauczanieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wydarzenie_Nauczanie_NauczanieId",
                table: "Wydarzenie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wydarzenie",
                table: "Wydarzenie");

            migrationBuilder.DropColumn(
                name: "data",
                table: "Ocena");

            migrationBuilder.RenameTable(
                name: "Wydarzenie",
                newName: "Ogloszenie");

            migrationBuilder.RenameIndex(
                name: "IX_Wydarzenie_NauczanieId",
                table: "Ogloszenie",
                newName: "IX_Ogloszenie_NauczanieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ogloszenie",
                table: "Ogloszenie",
                column: "WydarzenieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogloszenie_Nauczanie_NauczanieId",
                table: "Ogloszenie",
                column: "NauczanieId",
                principalTable: "Nauczanie",
                principalColumn: "NauczanieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
