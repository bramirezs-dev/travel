using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Infraestructure.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "editoriales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    sede = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editoriales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    ISBN = table.Column<int>(type: "int", maxLength: 13, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    sinopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    n_paginas = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    EditorialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_libros_editoriales_EditorialId",
                        column: x => x.EditorialId,
                        principalTable: "editoriales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "autores_has_libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    BookISBNId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores_has_libros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_autores_has_libros_autores_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "autores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_autores_has_libros_libros_BookISBNId",
                        column: x => x.BookISBNId,
                        principalTable: "libros",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_autores_has_libros_AuthorId",
                table: "autores_has_libros",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_autores_has_libros_BookISBNId",
                table: "autores_has_libros",
                column: "BookISBNId");

            migrationBuilder.CreateIndex(
                name: "IX_libros_EditorialId",
                table: "libros",
                column: "EditorialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "autores_has_libros");

            migrationBuilder.DropTable(
                name: "autores");

            migrationBuilder.DropTable(
                name: "libros");

            migrationBuilder.DropTable(
                name: "editoriales");
        }
    }
}
