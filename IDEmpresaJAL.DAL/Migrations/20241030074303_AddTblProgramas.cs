using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTblProgramas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TProgramas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TipoProgramaId = table.Column<int>(type: "int", nullable: false),
                    DireccionGeneralId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjetivoGeneral = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    PermiteMultiplesProyectos = table.Column<bool>(type: "bit", nullable: false),
                    PermiteMultiplesConvocatorias = table.Column<bool>(type: "bit", nullable: false),
                    BancaId = table.Column<int>(type: "int", nullable: false),
                    Numcuenta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CLABE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Presupuesto = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    ClavePresupuestaria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigoDenominacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ClaveProgramaPresupuestal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescripcionPartida = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaFin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anio = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    SistemaId = table.Column<int>(type: "int", nullable: false),
                    VoBoArea = table.Column<bool>(type: "bit", nullable: false),
                    VoBoPlaneacion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProgramas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TProgramas_CBanca_BancaId",
                        column: x => x.BancaId,
                        principalTable: "CBanca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TProgramas_CDireccionGeneral_DireccionGeneralId",
                        column: x => x.DireccionGeneralId,
                        principalTable: "CDireccionGeneral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TProgramas_CSistemas_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "CSistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TProgramas_CTipoPrograma_TipoProgramaId",
                        column: x => x.TipoProgramaId,
                        principalTable: "CTipoPrograma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TProgramas_BancaId",
                table: "TProgramas",
                column: "BancaId");

            migrationBuilder.CreateIndex(
                name: "IX_TProgramas_DireccionGeneralId",
                table: "TProgramas",
                column: "DireccionGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_TProgramas_SistemaId",
                table: "TProgramas",
                column: "SistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_TProgramas_TipoProgramaId",
                table: "TProgramas",
                column: "TipoProgramaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TProgramas");
        }
    }
}
