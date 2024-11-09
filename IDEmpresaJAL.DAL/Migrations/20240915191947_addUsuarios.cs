using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TUsuarioGenerales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUsuarioGenerales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUsuarioGenerales_TUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TUsuarioGenerales_UsuarioId",
                table: "TUsuarioGenerales",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TUsuarioGenerales");

            migrationBuilder.DropTable(
                name: "TUsuario");
        }
    }
}
