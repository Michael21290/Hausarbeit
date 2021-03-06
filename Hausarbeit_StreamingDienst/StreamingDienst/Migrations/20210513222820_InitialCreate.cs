﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StreamingDienst.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmTitel = table.Column<string>(nullable: true),
                    FilmLaenge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Leihpreis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kaufpreis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VideoData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Preis",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Betrag = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerienTitel = table.Column<string>(nullable: true),
                    AnzahlFolgen = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Vorname = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    IBAN = table.Column<string>(nullable: true),
                    BIC = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Geburtsdatum = table.Column<DateTime>(nullable: false),
                    Benutzername = table.Column<string>(nullable: true),
                    Gesperrt = table.Column<bool>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    Guthaben = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(nullable: true),
                    FilmID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Genre_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Folge",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolgenTitel = table.Column<int>(nullable: false),
                    FolgenLaenge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FPreisIDID = table.Column<int>(nullable: true),
                    FSerienIDID = table.Column<int>(nullable: true),
                    VideoData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folge", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Folge_Preis_FPreisIDID",
                        column: x => x.FPreisIDID,
                        principalTable: "Preis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Folge_Serie_FSerienIDID",
                        column: x => x.FSerienIDID,
                        principalTable: "Serie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFilm",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FUserIDID = table.Column<int>(nullable: true),
                    UFilmIDID = table.Column<int>(nullable: true),
                    USerienIDID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserFilm_User_FUserIDID",
                        column: x => x.FUserIDID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFilm_Film_UFilmIDID",
                        column: x => x.UFilmIDID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFilm_Serie_USerienIDID",
                        column: x => x.USerienIDID,
                        principalTable: "Serie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GFilmIDID = table.Column<int>(nullable: true),
                    FGenreIDID = table.Column<int>(nullable: true),
                    Bezeichnung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FilmGenre_Genre_FGenreIDID",
                        column: x => x.FGenreIDID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmGenre_Film_GFilmIDID",
                        column: x => x.GFilmIDID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_FGenreIDID",
                table: "FilmGenre",
                column: "FGenreIDID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GFilmIDID",
                table: "FilmGenre",
                column: "GFilmIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Folge_FPreisIDID",
                table: "Folge",
                column: "FPreisIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Folge_FSerienIDID",
                table: "Folge",
                column: "FSerienIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_FilmID",
                table: "Genre",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFilm_FUserIDID",
                table: "UserFilm",
                column: "FUserIDID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFilm_UFilmIDID",
                table: "UserFilm",
                column: "UFilmIDID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFilm_USerienIDID",
                table: "UserFilm",
                column: "USerienIDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "Folge");

            migrationBuilder.DropTable(
                name: "UserFilm");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Preis");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
