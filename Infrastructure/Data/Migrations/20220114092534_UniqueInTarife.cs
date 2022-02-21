using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UniqueInTarife : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tarife_ClientId",
                table: "Tarife");

            migrationBuilder.CreateIndex(
                name: "IX_Tarife_ClientId_ServiciuId",
                table: "Tarife",
                columns: new[] { "ClientId", "ServiciuId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicii_Cod",
                table: "Servicii",
                column: "Cod",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tarife_ClientId_ServiciuId",
                table: "Tarife");

            migrationBuilder.DropIndex(
                name: "IX_Servicii_Cod",
                table: "Servicii");

            migrationBuilder.CreateIndex(
                name: "IX_Tarife_ClientId",
                table: "Tarife",
                column: "ClientId");
        }
    }
}
