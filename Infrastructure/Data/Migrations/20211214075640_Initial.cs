using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Den = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sediu1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sediu2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Capital = table.Column<int>(type: "int", nullable: false),
                    CodJudJ = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NrOrdJ = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AnJ = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    AtCif = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NrCif = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CotaTva = table.Column<byte>(type: "tinyint", nullable: false),
                    SeriaFact = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NumeOperator = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    SiglaUrl = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Furnizori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtCif = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NrCif = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PrefixDen = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Den = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnizori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipuriDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Den = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipuriDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitatiDeMasura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Um = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitatiDeMasura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Den = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sediu1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sediu2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NrCont = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Banca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodJudJ = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NrOrdJ = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AnJ = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    AtCif = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NrCif = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    NumarContract = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DataContract = table.Column<DateTime>(type: "date", nullable: true),
                    Tara = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NrTva = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FirmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clienti_Firme_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conturi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valuta = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NrCont = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Banca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conturi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conturi_Firme_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receptii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrNir = table.Column<int>(type: "int", nullable: false),
                    DataNir = table.Column<DateTime>(type: "date", nullable: false),
                    NrDoc = table.Column<int>(type: "int", nullable: false),
                    DataDoc = table.Column<DateTime>(type: "date", nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BazaAch = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    TvaAch = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    ValAch = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    AdaosProc = table.Column<byte>(type: "tinyint", nullable: false),
                    Baza = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Tva = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Val = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    FirmaId = table.Column<int>(type: "int", nullable: false),
                    FurnizorId = table.Column<int>(type: "int", nullable: false),
                    TipDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptii_Firme_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptii_Furnizori_FurnizorId",
                        column: x => x.FurnizorId,
                        principalTable: "Furnizori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receptii_TipuriDocument_TipDocumentId",
                        column: x => x.TipDocumentId,
                        principalTable: "TipuriDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Magazine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numar = table.Column<int>(type: "int", nullable: false),
                    Den = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ComandaCadru = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Magazine_Clienti_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pozitii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numar = table.Column<int>(type: "int", nullable: false),
                    Den = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozitii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pozitii_Clienti_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materiale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrPozDoc = table.Column<byte>(type: "tinyint", nullable: false),
                    Den = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cant = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false),
                    Um = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CotaTvaAch = table.Column<byte>(type: "tinyint", nullable: false),
                    PretAch = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false),
                    BazaAch = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    TvaAch = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    ValAch = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    CotaTva = table.Column<byte>(type: "tinyint", nullable: false),
                    AdaosProc = table.Column<byte>(type: "tinyint", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false),
                    Baza = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Tva = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Val = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    CantUtilizata = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false),
                    CantRamasa = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false),
                    ReceptieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materiale_Receptii_ReceptieId",
                        column: x => x.ReceptieId,
                        principalTable: "Receptii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clienti_FirmaId_NrCif",
                table: "Clienti",
                columns: new[] { "FirmaId", "NrCif" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conturi_FirmaId",
                table: "Conturi",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Firme_NrCif",
                table: "Firme",
                column: "NrCif",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Furnizori_NrCif",
                table: "Furnizori",
                column: "NrCif",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Magazine_ClientId_Numar",
                table: "Magazine",
                columns: new[] { "ClientId", "Numar" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materiale_ReceptieId",
                table: "Materiale",
                column: "ReceptieId");

            migrationBuilder.CreateIndex(
                name: "IX_Pozitii_ClientId",
                table: "Pozitii",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptii_FirmaId",
                table: "Receptii",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptii_FurnizorId_DataDoc_NrDoc",
                table: "Receptii",
                columns: new[] { "FurnizorId", "DataDoc", "NrDoc" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receptii_NrNir",
                table: "Receptii",
                column: "NrNir",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receptii_TipDocumentId",
                table: "Receptii",
                column: "TipDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conturi");

            migrationBuilder.DropTable(
                name: "Magazine");

            migrationBuilder.DropTable(
                name: "Materiale");

            migrationBuilder.DropTable(
                name: "Pozitii");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UnitatiDeMasura");

            migrationBuilder.DropTable(
                name: "Receptii");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Furnizori");

            migrationBuilder.DropTable(
                name: "TipuriDocument");

            migrationBuilder.DropTable(
                name: "Firme");
        }
    }
}
