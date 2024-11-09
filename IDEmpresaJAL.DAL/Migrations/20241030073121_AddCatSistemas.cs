using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCatSistemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CSistemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sistema = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RutaImagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TamanoImagen = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DescripcionImagen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MensajeVisible = table.Column<bool>(type: "bit", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Session = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSistemas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CSistemas");
        }
    }
}
