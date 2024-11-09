using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DireccionGeneralId",
                table: "TUsuarioGenerales",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TUsuarioGenerales_DireccionGeneralId",
                table: "TUsuarioGenerales",
                column: "DireccionGeneralId");

            migrationBuilder.AddForeignKey(
                name: "FK_TUsuarioGenerales_CDireccionGeneral_DireccionGeneralId",
                table: "TUsuarioGenerales",
                column: "DireccionGeneralId",
                principalTable: "CDireccionGeneral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TUsuarioGenerales_CDireccionGeneral_DireccionGeneralId",
                table: "TUsuarioGenerales");

            migrationBuilder.DropIndex(
                name: "IX_TUsuarioGenerales_DireccionGeneralId",
                table: "TUsuarioGenerales");

            migrationBuilder.DropColumn(
                name: "DireccionGeneralId",
                table: "TUsuarioGenerales");
        }
    }
}
