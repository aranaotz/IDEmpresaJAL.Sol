using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addCDireccionGeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CDireccionGeneral",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreDireccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreEncargado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EncargadoCargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EncargadoCorreo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TieneProgramas = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDireccionGeneral", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDireccionGeneral");
        }
    }
}
