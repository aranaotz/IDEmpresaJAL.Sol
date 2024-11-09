using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class comp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "TProgramasComponente");

            migrationBuilder.CreateTable(
                name: "TProgramasComponentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Componente = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Partida = table.Column<string>(type: "nvarchar(46)", maxLength: 46, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    MontoDisponible = table.Column<decimal>(type: "decimal(20,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProgramasComponentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TProgramasComponentes_TProgramas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "TProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TProgramasComponentes_ProgramaId",
                table: "TProgramasComponentes",
                column: "ProgramaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "TProgramasComponentes");

            migrationBuilder.CreateTable(
                name: "TProgramasComponente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Componente = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    MontoDisponible = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Partida = table.Column<string>(type: "nvarchar(46)", maxLength: 46, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProgramasComponente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TProgramasComponente_TProgramas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "TProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TProgramasComponente_ProgramaId",
                table: "TProgramasComponente",
                column: "ProgramaId");
        }
    }
}
