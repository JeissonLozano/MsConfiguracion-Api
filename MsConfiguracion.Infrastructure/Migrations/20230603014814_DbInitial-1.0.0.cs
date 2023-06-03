using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MsConfiguracion.Infrastructure.Migrations
{
    public partial class DbInitial100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MsConfiguracion");

            migrationBuilder.CreateTable(
                name: "TipoEquipo",
                schema: "MsConfiguracion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreTipoEquipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEquipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                schema: "MsConfiguracion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                schema: "MsConfiguracion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoEquipo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipo_TipoEquipo_IdTipoEquipo",
                        column: x => x.IdTipoEquipo,
                        principalSchema: "MsConfiguracion",
                        principalTable: "TipoEquipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_IdTipoEquipo",
                schema: "MsConfiguracion",
                table: "Equipo",
                column: "IdTipoEquipo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo",
                schema: "MsConfiguracion");

            migrationBuilder.DropTable(
                name: "Zona",
                schema: "MsConfiguracion");

            migrationBuilder.DropTable(
                name: "TipoEquipo",
                schema: "MsConfiguracion");
        }
    }
}
