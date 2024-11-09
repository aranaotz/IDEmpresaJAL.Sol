using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addRUsuarioRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "TUsuarioGenerales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "RUsuarioRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RUsuarioRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RUsuarioRol_CRoles_RolId",
                        column: x => x.RolId,
                        principalTable: "CRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RUsuarioRol_TUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RUsuarioRol_RolId",
                table: "RUsuarioRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_RUsuarioRol_UsuarioId",
                table: "RUsuarioRol",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RUsuarioRol");

            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "TUsuarioGenerales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
