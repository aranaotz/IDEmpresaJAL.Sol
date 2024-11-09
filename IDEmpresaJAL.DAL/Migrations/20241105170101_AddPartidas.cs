using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPartidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TProgramasPartidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Componente = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Partida = table.Column<string>(type: "nvarchar(46)", maxLength: 46, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    MontoDisponible = table.Column<decimal>(type: "decimal(20,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProgramasPartidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TProgramasPartidas_TProgramas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "TProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TProgramasPartidas_ProgramaId",
                table: "TProgramasPartidas",
                column: "ProgramaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TProgramasPartidas");
        }
    }
}
