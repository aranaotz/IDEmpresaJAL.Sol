using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class editTipoCarga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CDocumentos_DocumentosTipoCarga_TipoCargaId",
                table: "CDocumentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentosTipoCarga",
                table: "DocumentosTipoCarga");

            migrationBuilder.RenameTable(
                name: "DocumentosTipoCarga",
                newName: "CDocumentosTipoCarga");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CDocumentosTipoCarga",
                table: "CDocumentosTipoCarga",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CDocumentos_CDocumentosTipoCarga_TipoCargaId",
                table: "CDocumentos",
                column: "TipoCargaId",
                principalTable: "CDocumentosTipoCarga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CDocumentos_CDocumentosTipoCarga_TipoCargaId",
                table: "CDocumentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CDocumentosTipoCarga",
                table: "CDocumentosTipoCarga");

            migrationBuilder.RenameTable(
                name: "CDocumentosTipoCarga",
                newName: "DocumentosTipoCarga");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentosTipoCarga",
                table: "DocumentosTipoCarga",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CDocumentos_DocumentosTipoCarga_TipoCargaId",
                table: "CDocumentos",
                column: "TipoCargaId",
                principalTable: "DocumentosTipoCarga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
