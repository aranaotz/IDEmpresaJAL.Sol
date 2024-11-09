using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriasSIGA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "CDocumentosRequisitos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CCategorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DireccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TieneEmpleados = table.Column<bool>(type: "bit", nullable: true),
                    EmpleadosMin = table.Column<int>(type: "int", nullable: true),
                    EmpleadosMax = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCategorias_CDireccionGeneral_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "CDireccionGeneral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CCategoriasTipoSolicitante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoSolicitanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCategoriasTipoSolicitante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCategoriasTipoSolicitante_CCategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CCategoriasTipoSolicitante_CTipoSolicitante_TipoSolicitanteId",
                        column: x => x.TipoSolicitanteId,
                        principalTable: "CTipoSolicitante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CCategorias_DireccionId",
                table: "CCategorias",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_CCategoriasTipoSolicitante_CategoriaId",
                table: "CCategoriasTipoSolicitante",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_CCategoriasTipoSolicitante_TipoSolicitanteId",
                table: "CCategoriasTipoSolicitante",
                column: "TipoSolicitanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CCategoriasTipoSolicitante");

            migrationBuilder.DropTable(
                name: "CCategorias");

            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "CDocumentosRequisitos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
