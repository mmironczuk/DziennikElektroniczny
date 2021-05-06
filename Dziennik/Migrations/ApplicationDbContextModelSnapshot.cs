﻿// <auto-generated />
using System;
using Dziennik.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dziennik.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dziennik.Models.Klasa", b =>
                {
                    b.Property<int>("KlasaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KontoId")
                        .HasColumnType("int");

                    b.Property<string>("nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlasaId");

                    b.HasIndex("KontoId")
                        .IsUnique();

                    b.ToTable("Klasa");
                });

            modelBuilder.Entity("Dziennik.Models.Konto", b =>
                {
                    b.Property<int>("KontoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KlasaId")
                        .HasColumnType("int");

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<string>("adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("haslo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("typ_uzytkownika")
                        .HasColumnType("int");

                    b.HasKey("KontoId");

                    b.HasIndex("KlasaId");

                    b.ToTable("Konto");
                });

            modelBuilder.Entity("Dziennik.Models.Lekcja", b =>
                {
                    b.Property<int>("LekcjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NauczanieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.HasKey("LekcjaId");

                    b.HasIndex("NauczanieId");

                    b.ToTable("Lekcja");
                });

            modelBuilder.Entity("Dziennik.Models.Nauczanie", b =>
                {
                    b.Property<int>("NauczanieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KlasaId")
                        .HasColumnType("int");

                    b.Property<int>("KontoId")
                        .HasColumnType("int");

                    b.Property<int>("PrzedmiotId")
                        .HasColumnType("int");

                    b.HasKey("NauczanieId");

                    b.HasIndex("KlasaId");

                    b.HasIndex("KontoId");

                    b.HasIndex("PrzedmiotId");

                    b.ToTable("Nauczanie");
                });

            modelBuilder.Entity("Dziennik.Models.Obecnosc", b =>
                {
                    b.Property<int>("ObecnoscId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KontoId")
                        .HasColumnType("int");

                    b.Property<int?>("LekcjaId")
                        .HasColumnType("int");

                    b.Property<int>("typ_obecnosci")
                        .HasColumnType("int");

                    b.HasKey("ObecnoscId");

                    b.HasIndex("KontoId");

                    b.HasIndex("LekcjaId");

                    b.ToTable("Obecnosc");
                });

            modelBuilder.Entity("Dziennik.Models.Ocena", b =>
                {
                    b.Property<int>("OcenaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KontoId")
                        .HasColumnType("int");

                    b.Property<int?>("NauczanieId")
                        .HasColumnType("int");

                    b.Property<int>("SemestrId")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int>("koncowa")
                        .HasColumnType("int");

                    b.Property<string>("opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("wartosc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OcenaId");

                    b.HasIndex("KontoId");

                    b.HasIndex("NauczanieId");

                    b.HasIndex("SemestrId");

                    b.ToTable("Ocena");
                });

            modelBuilder.Entity("Dziennik.Models.Przedmiot", b =>
                {
                    b.Property<int>("PrzedmiotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dziedzina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrzedmiotId");

                    b.ToTable("Przedmiot");
                });

            modelBuilder.Entity("Dziennik.Models.Semestr", b =>
                {
                    b.Property<int>("SemestrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("data_rozpoczecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_zakonczenia")
                        .HasColumnType("datetime2");

                    b.HasKey("SemestrId");

                    b.ToTable("Semestr");
                });

            modelBuilder.Entity("Dziennik.Models.Wiadomosc", b =>
                {
                    b.Property<int>("WiadomoscId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NadawcaId")
                        .HasColumnType("int");

                    b.Property<int>("OdbiorcaId")
                        .HasColumnType("int");

                    b.Property<int>("czy_odczytana")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<string>("tresc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tytul")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WiadomoscId");

                    b.HasIndex("NadawcaId");

                    b.HasIndex("OdbiorcaId");

                    b.ToTable("Wiadomosc");
                });

            modelBuilder.Entity("Dziennik.Models.Wydarzenie", b =>
                {
                    b.Property<int>("WydarzenieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NauczanieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<string>("nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WydarzenieId");

                    b.HasIndex("NauczanieId");

                    b.ToTable("Wydarzenie");
                });

            modelBuilder.Entity("Dziennik.Models.Klasa", b =>
                {
                    b.HasOne("Dziennik.Models.Konto", "Wychowawca")
                        .WithOne("Wychowankowie")
                        .HasForeignKey("Dziennik.Models.Klasa", "KontoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Dziennik.Models.Konto", b =>
                {
                    b.HasOne("Dziennik.Models.Klasa", "Klasa")
                        .WithMany("Uczniowie")
                        .HasForeignKey("KlasaId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Dziennik.Models.Lekcja", b =>
                {
                    b.HasOne("Dziennik.Models.Nauczanie", "Nauczanie")
                        .WithMany("Lekcje")
                        .HasForeignKey("NauczanieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dziennik.Models.Nauczanie", b =>
                {
                    b.HasOne("Dziennik.Models.Klasa", "Klasa")
                        .WithMany("Nauczania")
                        .HasForeignKey("KlasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dziennik.Models.Konto", "Konto")
                        .WithMany("Nauczania")
                        .HasForeignKey("KontoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dziennik.Models.Przedmiot", "Przedmiot")
                        .WithMany("Nauczania")
                        .HasForeignKey("PrzedmiotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dziennik.Models.Obecnosc", b =>
                {
                    b.HasOne("Dziennik.Models.Konto", "Konto")
                        .WithMany("Obecnosci")
                        .HasForeignKey("KontoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dziennik.Models.Lekcja", "Lekcja")
                        .WithMany("Obecnosci")
                        .HasForeignKey("LekcjaId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Dziennik.Models.Ocena", b =>
                {
                    b.HasOne("Dziennik.Models.Konto", "Konto")
                        .WithMany("Oceny")
                        .HasForeignKey("KontoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dziennik.Models.Nauczanie", "Nauczanie")
                        .WithMany("Ocena")
                        .HasForeignKey("NauczanieId");

                    b.HasOne("Dziennik.Models.Semestr", "Semestr")
                        .WithMany("oceny")
                        .HasForeignKey("SemestrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dziennik.Models.Wiadomosc", b =>
                {
                    b.HasOne("Dziennik.Models.Konto", "Nadawca")
                        .WithMany("wyslane")
                        .HasForeignKey("NadawcaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Dziennik.Models.Konto", "Odbiorca")
                        .WithMany("odebrane")
                        .HasForeignKey("OdbiorcaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Dziennik.Models.Wydarzenie", b =>
                {
                    b.HasOne("Dziennik.Models.Nauczanie", "Nauczania")
                        .WithMany("Wydarzenia")
                        .HasForeignKey("NauczanieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
