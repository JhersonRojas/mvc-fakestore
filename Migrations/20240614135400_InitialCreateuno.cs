using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc_fakestore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateuno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Proveedores",
                newName: "IdProveedor");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actualizado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proveedore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.RenameColumn(
                name: "IdProveedor",
                table: "Proveedores",
                newName: "id");
        }
    }
}
