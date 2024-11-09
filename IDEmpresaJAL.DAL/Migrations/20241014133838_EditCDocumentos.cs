using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditCDocumentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CDocumentos_CDireccionGeneral_DireccionGeneralId",
                table: "CDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_CDocumentos_DireccionGeneralId",
                table: "CDocumentos");

            migrationBuilder.DropColumn(
                name: "DireccionGeneralId",
                table: "CDocumentos");

            migrationBuilder.CreateIndex(
                name: "IX_CDocumentos_DireccionId",
                table: "CDocumentos",
                column: "DireccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CDocumentos_CDireccionGeneral_DireccionId",
                table: "CDocumentos",
                column: "DireccionId",
                principalTable: "CDireccionGeneral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CDocumentos_CDireccionGeneral_DireccionId",
                table: "CDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_CDocumentos_DireccionId",
                table: "CDocumentos");

            migrationBuilder.AddColumn<Guid>(
                name: "DireccionGeneralId",
                table: "CDocumentos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CDocumentos_DireccionGeneralId",
                table: "CDocumentos",
                column: "DireccionGeneralId");

            migrationBuilder.AddForeignKey(
                name: "FK_CDocumentos_CDireccionGeneral_DireccionGeneralId",
                table: "CDocumentos",
                column: "DireccionGeneralId",
                principalTable: "CDireccionGeneral",
                principalColumn: "Id");
        }
    }
}
