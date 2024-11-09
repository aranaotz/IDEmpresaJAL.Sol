using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addUsuariosSeguridad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TUsuarioSeguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUsuarioSeguridad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUsuarioSeguridad_TUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TUsuarioSeguridadSolicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCaducidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usada = table.Column<bool>(type: "bit", nullable: false),
                    Funcion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUsuarioSeguridadSolicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUsuarioSeguridadSolicitud_TUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TUsuarioSeguridad_UsuarioId",
                table: "TUsuarioSeguridad",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TUsuarioSeguridadSolicitud_UsuarioId",
                table: "TUsuarioSeguridadSolicitud",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TUsuarioSeguridad");

            migrationBuilder.DropTable(
                name: "TUsuarioSeguridadSolicitud");
        }
    }
}
