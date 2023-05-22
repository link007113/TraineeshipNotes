using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blok2.HamelenTravelDocus.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Gemeente");

            migrationBuilder.EnsureSchema(
                name: "Documenten");

            migrationBuilder.EnsureSchema(
                name: "Burgers");

            migrationBuilder.CreateTable(
                name: "Afdelingen",
                schema: "Gemeente",
                columns: table => new
                {
                    AfdelingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Afdeling__81D6EFF146F709A4", x => x.AfdelingID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "DocumentStatus",
                schema: "Documenten",
                columns: table => new
                {
                    DocumentStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentStatusNaam = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__AFDCAFBC680B4E5A", x => x.DocumentStatusID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                schema: "Documenten",
                columns: table => new
                {
                    DocumentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeNaam = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GeldigheidsduurInDagen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__DBA390C08322C474", x => x.DocumentTypeID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Personen",
                schema: "Burgers",
                columns: table => new
                {
                    PersoonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "varchar(54)", unicode: false, maxLength: 54, nullable: false),
                    Achternaam = table.Column<string>(type: "varchar(54)", unicode: false, maxLength: 54, nullable: false),
                    Tussenvoegsel = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    BSN = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    Adres = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Postcode = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    Woonplaats = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    OorspronkelijkeNaam = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Geboorteplaats = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Geboorteland = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personen__FA091400AA481FE2", x => x.PersoonID);
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                schema: "Gemeente",
                columns: table => new
                {
                    MedewerkerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersoonID = table.Column<int>(type: "int", nullable: false),
                    AfdelingID = table.Column<int>(type: "int", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medewerk__4CF73F23C65F8C2D", x => x.MedewerkerID);
                    table.ForeignKey(
                        name: "FK__Medewerke__Afdel__3E52440B",
                        column: x => x.AfdelingID,
                        principalSchema: "Gemeente",
                        principalTable: "Afdelingen",
                        principalColumn: "AfdelingID");
                    table.ForeignKey(
                        name: "FK__Medewerke__Manag__3D5E1FD2",
                        column: x => x.ManagerID,
                        principalSchema: "Gemeente",
                        principalTable: "Medewerkers",
                        principalColumn: "MedewerkerID");
                    table.ForeignKey(
                        name: "FK__Medewerke__Perso__3C69FB99",
                        column: x => x.PersoonID,
                        principalSchema: "Burgers",
                        principalTable: "Personen",
                        principalColumn: "PersoonID");
                });

            migrationBuilder.CreateTable(
                name: "Reisdocumenten",
                schema: "Documenten",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersoonID = table.Column<int>(type: "int", nullable: false),
                    DocumentNr = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DocumentTypeID = table.Column<int>(type: "int", nullable: false),
                    AanvraagMedewerkerID = table.Column<int>(type: "int", nullable: false),
                    AanvraagDatumTijd = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(sysdatetime())"),
                    AfgiftePlaats = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('Hamelen')"),
                    AfgifteDatum = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    VerloopDatum = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    BetaaldePrijs = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DocumentStatusId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reisdocu__1ABEEF6F6BB4F6BD", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Reisdocumenten_DocumentStatus",
                        column: x => x.DocumentStatusId,
                        principalSchema: "Documenten",
                        principalTable: "DocumentStatus",
                        principalColumn: "DocumentStatusID");
                    table.ForeignKey(
                        name: "FK_Reisdocumenten_DocumentType",
                        column: x => x.DocumentTypeID,
                        principalSchema: "Documenten",
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeID");
                    table.ForeignKey(
                        name: "FK_Reisdocumenten_Mederwerkers",
                        column: x => x.AanvraagMedewerkerID,
                        principalSchema: "Gemeente",
                        principalTable: "Medewerkers",
                        principalColumn: "MedewerkerID");
                    table.ForeignKey(
                        name: "FK_Reisdocumenten_Personen",
                        column: x => x.PersoonID,
                        principalSchema: "Burgers",
                        principalTable: "Personen",
                        principalColumn: "PersoonID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Afdeling__7375E70E311329D1",
                schema: "Gemeente",
                table: "Afdelingen",
                column: "Naam",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "UQ__Document__CCE1150022D6459A",
                schema: "Documenten",
                table: "DocumentStatus",
                column: "DocumentStatusNaam",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "UQ__Document__CFE34F3ED427BE44",
                schema: "Documenten",
                table: "DocumentType",
                column: "DocumentTypeNaam",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_AfdelingID",
                schema: "Gemeente",
                table: "Medewerkers",
                column: "AfdelingID");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_ManagerID",
                schema: "Gemeente",
                table: "Medewerkers",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_PersoonID",
                schema: "Gemeente",
                table: "Medewerkers",
                column: "PersoonID");

            migrationBuilder.CreateIndex(
                name: "UIX_Personen_Naam_BSN",
                schema: "Burgers",
                table: "Personen",
                columns: new[] { "Voornaam", "Tussenvoegsel", "Achternaam", "BSN" },
                unique: true,
                filter: "[Tussenvoegsel] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reisdocumenten_AanvraagMedewerkerID",
                schema: "Documenten",
                table: "Reisdocumenten",
                column: "AanvraagMedewerkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reisdocumenten_DocumentStatusId",
                schema: "Documenten",
                table: "Reisdocumenten",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reisdocumenten_DocumentTypeID",
                schema: "Documenten",
                table: "Reisdocumenten",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Reisdocumenten_PersoonID",
                schema: "Documenten",
                table: "Reisdocumenten",
                column: "PersoonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reisdocumenten",
                schema: "Documenten");

            migrationBuilder.DropTable(
                name: "DocumentStatus",
                schema: "Documenten");

            migrationBuilder.DropTable(
                name: "DocumentType",
                schema: "Documenten");

            migrationBuilder.DropTable(
                name: "Medewerkers",
                schema: "Gemeente");

            migrationBuilder.DropTable(
                name: "Afdelingen",
                schema: "Gemeente");

            migrationBuilder.DropTable(
                name: "Personen",
                schema: "Burgers");
        }
    }
}
