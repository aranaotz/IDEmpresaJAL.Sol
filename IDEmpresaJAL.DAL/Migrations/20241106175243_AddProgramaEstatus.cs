using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramaEstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstatusProgramaId",
                table: "TProgramas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TProgramasEstatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProgramasEstatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TProgramas_EstatusProgramaId",
                table: "TProgramas",
                column: "EstatusProgramaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TProgramas_TProgramasEstatus_EstatusProgramaId",
                table: "TProgramas",
                column: "EstatusProgramaId",
                principalTable: "TProgramasEstatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TProgramas_TProgramasEstatus_EstatusProgramaId",
                table: "TProgramas");

            migrationBuilder.DropTable(
                name: "TProgramasEstatus");

            migrationBuilder.DropIndex(
                name: "IX_TProgramas_EstatusProgramaId",
                table: "TProgramas");

            migrationBuilder.DropColumn(
                name: "EstatusProgramaId",
                table: "TProgramas");
        }
    }
}
