using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addProgObservaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TProgramasObservaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProgramasObservaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TProgramasObservaciones_TProgramas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "TProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TProgramasObservaciones_ProgramaId",
                table: "TProgramasObservaciones",
                column: "ProgramaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TProgramasObservaciones");
        }
    }
}
