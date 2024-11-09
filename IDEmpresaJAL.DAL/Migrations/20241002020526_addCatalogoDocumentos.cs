using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addCatalogoDocumentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CDocumentosTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDocumentosTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosTipoCarga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCarga = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValidationExpression = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MensajeValidacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MensajeDescripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosTipoCarga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CDocumentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DireccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    TipoCargaId = table.Column<int>(type: "int", nullable: false),
                    Obligoatorio = table.Column<bool>(type: "bit", nullable: false),
                    Nacional = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    DireccionGeneralId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDocumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CDocumentos_CDireccionGeneral_DireccionGeneralId",
                        column: x => x.DireccionGeneralId,
                        principalTable: "CDireccionGeneral",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CDocumentos_CDocumentosTipo_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "CDocumentosTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CDocumentos_DocumentosTipoCarga_TipoCargaId",
                        column: x => x.TipoCargaId,
                        principalTable: "DocumentosTipoCarga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CDocumentosRequisitos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Requisito = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDocumentosRequisitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CDocumentosRequisitos_CDocumentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "CDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CDocumentos_DireccionGeneralId",
                table: "CDocumentos",
                column: "DireccionGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_CDocumentos_TipoCargaId",
                table: "CDocumentos",
                column: "TipoCargaId");

            migrationBuilder.CreateIndex(
                name: "IX_CDocumentos_TipoDocumentoId",
                table: "CDocumentos",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_CDocumentosRequisitos_DocumentoId",
                table: "CDocumentosRequisitos",
                column: "DocumentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDocumentosRequisitos");

            migrationBuilder.DropTable(
                name: "CDocumentos");

            migrationBuilder.DropTable(
                name: "CDocumentosTipo");

            migrationBuilder.DropTable(
                name: "DocumentosTipoCarga");
        }
    }
}
