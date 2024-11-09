using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addComponentePresupuestal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FechaInicio",
                table: "TProgramas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FechaFin",
                table: "TProgramas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TProgramaComponentes",
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
                    table.PrimaryKey("PK_TProgramaComponentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TProgramaComponentes_TProgramas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "TProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TProgramaComponentes_ProgramaId",
                table: "TProgramaComponentes",
                column: "ProgramaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TProgramaComponentes");

            migrationBuilder.AlterColumn<string>(
                name: "FechaInicio",
                table: "TProgramas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FechaFin",
                table: "TProgramas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
