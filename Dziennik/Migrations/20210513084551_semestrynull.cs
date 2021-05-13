using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dziennik.Migrations
{
    public partial class semestrynull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocena_Semestr_SemestrId",
                table: "Ocena");

            migrationBuilder.AlterColumn<int>(
                name: "SemestrId",
                table: "Ocena",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "Lekcja",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocena_Semestr_SemestrId",
                table: "Ocena",
                column: "SemestrId",
                principalTable: "Semestr",
                principalColumn: "SemestrId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocena_Semestr_SemestrId",
                table: "Ocena");

            migrationBuilder.AlterColumn<int>(
                name: "SemestrId",
                table: "Ocena",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "Lekcja",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocena_Semestr_SemestrId",
                table: "Ocena",
                column: "SemestrId",
                principalTable: "Semestr",
                principalColumn: "SemestrId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
