using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addComponentePresupuestal1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TProgramaComponentes_TProgramas_ProgramaId",
                table: "TProgramaComponentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TProgramaComponentes",
                table: "TProgramaComponentes");

            migrationBuilder.RenameTable(
                name: "TProgramaComponentes",
                newName: "TProgramasComponente");

            migrationBuilder.RenameIndex(
                name: "IX_TProgramaComponentes_ProgramaId",
                table: "TProgramasComponente",
                newName: "IX_TProgramasComponente_ProgramaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TProgramasComponente",
                table: "TProgramasComponente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TProgramasComponente_TProgramas_ProgramaId",
                table: "TProgramasComponente",
                column: "ProgramaId",
                principalTable: "TProgramas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TProgramasComponente_TProgramas_ProgramaId",
                table: "TProgramasComponente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TProgramasComponente",
                table: "TProgramasComponente");

            migrationBuilder.RenameTable(
                name: "TProgramasComponente",
                newName: "TProgramaComponentes");

            migrationBuilder.RenameIndex(
                name: "IX_TProgramasComponente_ProgramaId",
                table: "TProgramaComponentes",
                newName: "IX_TProgramaComponentes_ProgramaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TProgramaComponentes",
                table: "TProgramaComponentes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TProgramaComponentes_TProgramas_ProgramaId",
                table: "TProgramaComponentes",
                column: "ProgramaId",
                principalTable: "TProgramas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
