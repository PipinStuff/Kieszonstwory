﻿// <auto-generated />
using System;
using Kieszonstwory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kieszonstwory.Migrations
{
    [DbContext(typeof(AplikacjaDbContext))]
    partial class AplikacjaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kieszonstwory.Models.DzikiStwor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseHP")
                        .HasColumnType("int");

                    b.Property<int>("BaseMoc")
                        .HasColumnType("int");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("LokalizacjaId")
                        .HasColumnType("int");

                    b.Property<int>("Moc")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Obrazek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Poziom")
                        .HasColumnType("int");

                    b.Property<int>("TypStworaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DzikiStwor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseHP = 50,
                            BaseMoc = 4,
                            HP = 50,
                            LokalizacjaId = 1,
                            Moc = 4,
                            Nazwa = "Skalniak",
                            Obrazek = "skalniak.png",
                            Poziom = 1,
                            TypStworaId = 2
                        },
                        new
                        {
                            Id = 2,
                            BaseHP = 40,
                            BaseMoc = 4,
                            HP = 40,
                            LokalizacjaId = 1,
                            Moc = 4,
                            Nazwa = "Ziemok",
                            Obrazek = "ziemok.png",
                            Poziom = 1,
                            TypStworaId = 1
                        },
                        new
                        {
                            Id = 3,
                            BaseHP = 30,
                            BaseMoc = 5,
                            HP = 30,
                            LokalizacjaId = 1,
                            Moc = 5,
                            Nazwa = "Taktoperz",
                            Obrazek = "taktoperz.png",
                            Poziom = 1,
                            TypStworaId = 3
                        },
                        new
                        {
                            Id = 4,
                            BaseHP = 15,
                            BaseMoc = 4,
                            HP = 15,
                            LokalizacjaId = 2,
                            Moc = 4,
                            Nazwa = "Szybkonóg",
                            Obrazek = "szybkonog.png",
                            Poziom = 1,
                            TypStworaId = 4
                        },
                        new
                        {
                            Id = 5,
                            BaseHP = 25,
                            BaseMoc = 5,
                            HP = 25,
                            LokalizacjaId = 2,
                            Moc = 5,
                            Nazwa = "Reed",
                            Obrazek = "reed.png",
                            Poziom = 1,
                            TypStworaId = 4
                        },
                        new
                        {
                            Id = 6,
                            BaseHP = 20,
                            BaseMoc = 2,
                            HP = 20,
                            LokalizacjaId = 2,
                            Moc = 2,
                            Nazwa = "Głąp",
                            Obrazek = "glap.png",
                            Poziom = 1,
                            TypStworaId = 3
                        },
                        new
                        {
                            Id = 7,
                            BaseHP = 30,
                            BaseMoc = 3,
                            HP = 30,
                            LokalizacjaId = 3,
                            Moc = 3,
                            Nazwa = "Bober",
                            Obrazek = "bober.png",
                            Poziom = 1,
                            TypStworaId = 5
                        },
                        new
                        {
                            Id = 8,
                            BaseHP = 40,
                            BaseMoc = 5,
                            HP = 40,
                            LokalizacjaId = 3,
                            Moc = 5,
                            Nazwa = "Płetw",
                            Obrazek = "pletw.png",
                            Poziom = 1,
                            TypStworaId = 5
                        },
                        new
                        {
                            Id = 9,
                            BaseHP = 35,
                            BaseMoc = 2,
                            HP = 35,
                            LokalizacjaId = 3,
                            Moc = 2,
                            Nazwa = "Krak",
                            Obrazek = "krak.png",
                            Poziom = 1,
                            TypStworaId = 5
                        });
                });

            modelBuilder.Entity("Kieszonstwory.Models.Esencja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TrenerId")
                        .HasColumnType("int");

                    b.Property<int>("TypId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypId");

                    b.ToTable("Esencja");
                });

            modelBuilder.Entity("Kieszonstwory.Models.Kieszonstwor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseHP")
                        .HasColumnType("int");

                    b.Property<bool>("CzyFav")
                        .HasColumnType("bit");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("LokalizacjaId")
                        .HasColumnType("int");

                    b.Property<int>("Moc")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Obrazek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Poziom")
                        .HasColumnType("int");

                    b.Property<int>("TrenerId")
                        .HasColumnType("int");

                    b.Property<int>("TypStworaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LokalizacjaId");

                    b.HasIndex("TrenerId");

                    b.HasIndex("TypStworaId");

                    b.ToTable("Kieszonstwory");
                });

            modelBuilder.Entity("Kieszonstwory.Models.Lokalizacja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lokalizacje");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nazwa = "Góry"
                        },
                        new
                        {
                            Id = 2,
                            Nazwa = "Polana"
                        },
                        new
                        {
                            Id = 3,
                            Nazwa = "Wybrzeże"
                        });
                });

            modelBuilder.Entity("Kieszonstwory.Models.Trener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Exp")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pokonane")
                        .HasColumnType("int");

                    b.Property<int>("Poziom")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Złapane")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Trenerzy");
                });

            modelBuilder.Entity("Kieszonstwory.Models.TypStwora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypyStworow");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nazwa = "ziemny",
                            Opis = "Żyją w ziemi"
                        },
                        new
                        {
                            Id = 2,
                            Nazwa = "skalny",
                            Opis = "Są z kamulca"
                        },
                        new
                        {
                            Id = 3,
                            Nazwa = "latający",
                            Opis = "Latają, chociaż czasami nie"
                        },
                        new
                        {
                            Id = 4,
                            Nazwa = "roślinny",
                            Opis = "Żyją w roślinach,jedzą rośliny"
                        },
                        new
                        {
                            Id = 5,
                            Nazwa = "wodny",
                            Opis = "Bul bul bul"
                        });
                });

            modelBuilder.Entity("Kieszonstwory.Models.Walka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DzikiStworId")
                        .HasColumnType("int");

                    b.Property<int>("KieszonstworId")
                        .HasColumnType("int");

                    b.Property<string>("Komunikat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LokalizacjaId")
                        .HasColumnType("int");

                    b.Property<bool>("Wynik")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DzikiStworId");

                    b.HasIndex("KieszonstworId");

                    b.ToTable("Walka");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Kieszonstwory.Models.Esencja", b =>
                {
                    b.HasOne("Kieszonstwory.Models.TypStwora", "Typ")
                        .WithMany()
                        .HasForeignKey("TypId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Typ");
                });

            modelBuilder.Entity("Kieszonstwory.Models.Kieszonstwor", b =>
                {
                    b.HasOne("Kieszonstwory.Models.Lokalizacja", "Lokalizacja")
                        .WithMany()
                        .HasForeignKey("LokalizacjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kieszonstwory.Models.Trener", "Trener")
                        .WithMany()
                        .HasForeignKey("TrenerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kieszonstwory.Models.TypStwora", "TypStwora")
                        .WithMany()
                        .HasForeignKey("TypStworaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lokalizacja");

                    b.Navigation("Trener");

                    b.Navigation("TypStwora");
                });

            modelBuilder.Entity("Kieszonstwory.Models.Trener", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kieszonstwory.Models.Walka", b =>
                {
                    b.HasOne("Kieszonstwory.Models.DzikiStwor", "DzikiStwor")
                        .WithMany()
                        .HasForeignKey("DzikiStworId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kieszonstwory.Models.Kieszonstwor", "Kieszonstwor")
                        .WithMany()
                        .HasForeignKey("KieszonstworId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DzikiStwor");

                    b.Navigation("Kieszonstwor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
