using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biblioteka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteka", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BibliotekaKsiazki",
                columns: table => new
                {
                    BibliotekaId = table.Column<int>(type: "int", nullable: false),
                    KsiazkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibliotekaKsiazki", x => new { x.BibliotekaId, x.KsiazkiId });
                    table.ForeignKey(
                        name: "FK_BibliotekaKsiazki_Biblioteka_BibliotekaId",
                        column: x => x.BibliotekaId,
                        principalTable: "Biblioteka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BibliotekaKsiazki_Ksiazki_KsiazkiId",
                        column: x => x.KsiazkiId,
                        principalTable: "Ksiazki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BibliotekaKsiazki_KsiazkiId",
                table: "BibliotekaKsiazki",
                column: "KsiazkiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BibliotekaKsiazki");

            migrationBuilder.DropTable(
                name: "Biblioteka");
        }
    }
}
