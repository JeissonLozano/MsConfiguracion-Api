using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MsCore.Infrastructure.Migrations
{
    public partial class _101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_TipoEquipo_IdTipoEquipo",
                schema: "MsCore",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_IdTipoEquipo",
                schema: "MsCore",
                table: "Equipo");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_IdTipoEquipo",
                schema: "MsCore",
                table: "Equipo",
                column: "IdTipoEquipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_TipoEquipo_IdTipoEquipo",
                schema: "MsCore",
                table: "Equipo",
                column: "IdTipoEquipo",
                principalSchema: "MsCore",
                principalTable: "TipoEquipo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_TipoEquipo_IdTipoEquipo",
                schema: "MsCore",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_IdTipoEquipo",
                schema: "MsCore",
                table: "Equipo");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_IdTipoEquipo",
                schema: "MsCore",
                table: "Equipo",
                column: "IdTipoEquipo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_TipoEquipo_IdTipoEquipo",
                schema: "MsCore",
                table: "Equipo",
                column: "IdTipoEquipo",
                principalSchema: "MsCore",
                principalTable: "TipoEquipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
