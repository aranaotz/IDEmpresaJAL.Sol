using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CRecursoContenedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRecursoContenedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CRecurso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recurso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlControlador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlAccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContenedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRecurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CRecurso_CRecursoContenedor_ContenedorId",
                        column: x => x.ContenedorId,
                        principalTable: "CRecursoContenedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RRolRecurso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    RecursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RRolRecurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RRolRecurso_CRecurso_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "CRecurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RRolRecurso_CRoles_RolId",
                        column: x => x.RolId,
                        principalTable: "CRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CRecurso_ContenedorId",
                table: "CRecurso",
                column: "ContenedorId");

            migrationBuilder.CreateIndex(
                name: "IX_RRolRecurso_RecursoId",
                table: "RRolRecurso",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_RRolRecurso_RolId",
                table: "RRolRecurso",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RRolRecurso");

            migrationBuilder.DropTable(
                name: "CRecurso");

            migrationBuilder.DropTable(
                name: "CRoles");

            migrationBuilder.DropTable(
                name: "CRecursoContenedor");
        }
    }
}
