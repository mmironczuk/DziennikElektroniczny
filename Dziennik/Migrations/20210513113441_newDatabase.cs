using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dziennik.Migrations
{
    public partial class newDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Przedmiot",
                columns: table => new
                {
                    PrzedmiotId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nazwa = table.Column<string>(nullable: true),
                    dziedzina = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przedmiot", x => x.PrzedmiotId);
                });

            migrationBuilder.CreateTable(
                name: "Semestr",
                columns: table => new
                {
                    SemestrId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_rozpoczecia = table.Column<DateTime>(nullable: false),
                    data_zakonczenia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestr", x => x.SemestrId);
                });

            migrationBuilder.CreateTable(
                name: "Konto",
                columns: table => new
                {
                    KontoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    login = table.Column<string>(nullable: true),
                    haslo = table.Column<string>(nullable: true),
                    imie = table.Column<string>(nullable: true),
                    nazwisko = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    pesel = table.Column<string>(nullable: true),
                    adres = table.Column<string>(nullable: true),
                    active = table.Column<int>(nullable: false),
                    typ_uzytkownika = table.Column<int>(nullable: false),
                    KlasaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konto", x => x.KontoId);
                });

            migrationBuilder.CreateTable(
                name: "Klasa",
                columns: table => new
                {
                    KlasaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nazwa = table.Column<string>(nullable: true),
                    KontoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasa", x => x.KlasaId);
                    table.ForeignKey(
                        name: "FK_Klasa_Konto_KontoId",
                        column: x => x.KontoId,
                        principalTable: "Konto",
                        principalColumn: "KontoId");
                });

            migrationBuilder.CreateTable(
                name: "Wiadomosc",
                columns: table => new
                {
                    WiadomoscId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tytul = table.Column<string>(nullable: true),
                    tresc = table.Column<string>(nullable: true),
                    data = table.Column<DateTime>(nullable: false),
                    OdbiorcaId = table.Column<int>(nullable: false),
                    NadawcaId = table.Column<int>(nullable: false),
                    czy_odczytana = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wiadomosc", x => x.WiadomoscId);
                    table.ForeignKey(
                        name: "FK_Wiadomosc_Konto_NadawcaId",
                        column: x => x.NadawcaId,
                        principalTable: "Konto",
                        principalColumn: "KontoId");
                    table.ForeignKey(
                        name: "FK_Wiadomosc_Konto_OdbiorcaId",
                        column: x => x.OdbiorcaId,
                        principalTable: "Konto",
                        principalColumn: "KontoId");
                });

            migrationBuilder.CreateTable(
                name: "Nauczanie",
                columns: table => new
                {
                    NauczanieId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KlasaId = table.Column<int>(nullable: false),
                    KontoId = table.Column<int>(nullable: false),
                    PrzedmiotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nauczanie", x => x.NauczanieId);
                    table.ForeignKey(
                        name: "FK_Nauczanie_Klasa_KlasaId",
                        column: x => x.KlasaId,
                        principalTable: "Klasa",
                        principalColumn: "KlasaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nauczanie_Konto_KontoId",
                        column: x => x.KontoId,
                        principalTable: "Konto",
                        principalColumn: "KontoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nauczanie_Przedmiot_PrzedmiotId",
                        column: x => x.PrzedmiotId,
                        principalTable: "Przedmiot",
                        principalColumn: "PrzedmiotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lekcja",
                columns: table => new
                {
                    LekcjaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NauczanieId = table.Column<int>(nullable: false),
                    data = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekcja", x => x.LekcjaId);
                    table.ForeignKey(
                        name: "FK_Lekcja_Nauczanie_NauczanieId",
                        column: x => x.NauczanieId,
                        principalTable: "Nauczanie",
                        principalColumn: "NauczanieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocena",
                columns: table => new
                {
                    OcenaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(nullable: false),
                    wartosc = table.Column<string>(nullable: true),
                    opis = table.Column<string>(nullable: true),
                    KontoId = table.Column<int>(nullable: false),
                    NauczanieId = table.Column<int>(nullable: true),
                    koncowa = table.Column<int>(nullable: false),
                    SemestrId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocena", x => x.OcenaId);
                    table.ForeignKey(
                        name: "FK_Ocena_Konto_KontoId",
                        column: x => x.KontoId,
                        principalTable: "Konto",
                        principalColumn: "KontoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocena_Nauczanie_NauczanieId",
                        column: x => x.NauczanieId,
                        principalTable: "Nauczanie",
                        principalColumn: "NauczanieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ocena_Semestr_SemestrId",
                        column: x => x.SemestrId,
                        principalTable: "Semestr",
                        principalColumn: "SemestrId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wydarzenie",
                columns: table => new
                {
                    WydarzenieId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NauczanieId = table.Column<int>(nullable: false),
                    nazwa = table.Column<string>(nullable: true),
                    opis = table.Column<string>(nullable: true),
                    data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydarzenie", x => x.WydarzenieId);
                    table.ForeignKey(
                        name: "FK_Wydarzenie_Nauczanie_NauczanieId",
                        column: x => x.NauczanieId,
                        principalTable: "Nauczanie",
                        principalColumn: "NauczanieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obecnosc",
                columns: table => new
                {
                    ObecnoscId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    typ_obecnosci = table.Column<int>(nullable: false),
                    LekcjaId = table.Column<int>(nullable: true),
                    KontoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obecnosc", x => x.ObecnoscId);
                    table.ForeignKey(
                        name: "FK_Obecnosc_Konto_KontoId",
                        column: x => x.KontoId,
                        principalTable: "Konto",
                        principalColumn: "KontoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obecnosc_Lekcja_LekcjaId",
                        column: x => x.LekcjaId,
                        principalTable: "Lekcja",
                        principalColumn: "LekcjaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klasa_KontoId",
                table: "Klasa",
                column: "KontoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Konto_KlasaId",
                table: "Konto",
                column: "KlasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekcja_NauczanieId",
                table: "Lekcja",
                column: "NauczanieId");

            migrationBuilder.CreateIndex(
                name: "IX_Nauczanie_KlasaId",
                table: "Nauczanie",
                column: "KlasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nauczanie_KontoId",
                table: "Nauczanie",
                column: "KontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Nauczanie_PrzedmiotId",
                table: "Nauczanie",
                column: "PrzedmiotId");

            migrationBuilder.CreateIndex(
                name: "IX_Obecnosc_KontoId",
                table: "Obecnosc",
                column: "KontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Obecnosc_LekcjaId",
                table: "Obecnosc",
                column: "LekcjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_KontoId",
                table: "Ocena",
                column: "KontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_NauczanieId",
                table: "Ocena",
                column: "NauczanieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_SemestrId",
                table: "Ocena",
                column: "SemestrId");

            migrationBuilder.CreateIndex(
                name: "IX_Wiadomosc_NadawcaId",
                table: "Wiadomosc",
                column: "NadawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wiadomosc_OdbiorcaId",
                table: "Wiadomosc",
                column: "OdbiorcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wydarzenie_NauczanieId",
                table: "Wydarzenie",
                column: "NauczanieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Konto_Klasa_KlasaId",
                table: "Konto",
                column: "KlasaId",
                principalTable: "Klasa",
                principalColumn: "KlasaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klasa_Konto_KontoId",
                table: "Klasa");

            migrationBuilder.DropTable(
                name: "Obecnosc");

            migrationBuilder.DropTable(
                name: "Ocena");

            migrationBuilder.DropTable(
                name: "Wiadomosc");

            migrationBuilder.DropTable(
                name: "Wydarzenie");

            migrationBuilder.DropTable(
                name: "Lekcja");

            migrationBuilder.DropTable(
                name: "Semestr");

            migrationBuilder.DropTable(
                name: "Nauczanie");

            migrationBuilder.DropTable(
                name: "Przedmiot");

            migrationBuilder.DropTable(
                name: "Konto");

            migrationBuilder.DropTable(
                name: "Klasa");
        }
    }
}
