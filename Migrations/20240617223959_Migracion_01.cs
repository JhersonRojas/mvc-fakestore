using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc_fakestore.Migrations
{
    /// <inheritdoc />
    public partial class Migracion_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                }
            );

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IdProveedor = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IdProveedor);
                }
            );

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false,
                        defaultValueSql: "NEWID()"
                    ),
                    Nombre = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: false
                    ),
                    Apellido = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: true
                    ),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: false
                    ),
                    Dni = table.Column<string>(
                        type: "nvarchar(30)",
                        maxLength: 30,
                        nullable: false
                    ),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actualizado = table.Column<DateTime>(
                        type: "datetime2",
                        maxLength: 30,
                        nullable: true
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                }
            );

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false,
                        defaultValueSql: "NEWID()"
                    ),
                    Nombre = table.Column<string>(
                        type: "nvarchar(150)",
                        maxLength: 150,
                        nullable: false
                    ),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<string>(
                        type: "nvarchar(10)",
                        maxLength: 10,
                        nullable: false
                    ),
                    Precio = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actualizado = table.Column<DateTime>(
                        type: "datetime2",
                        maxLength: 100,
                        nullable: false
                    ),
                    Descripcion = table.Column<string>(
                        type: "nvarchar(500)",
                        maxLength: 500,
                        nullable: false
                    ),
                    FkCategoria = table.Column<int>(type: "int", nullable: false),
                    FkProveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_FkCategoria",
                        column: x => x.FkCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Productos_Proveedores_FkProveedor",
                        column: x => x.FkProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    IdVenta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: false
                    ),
                    Total = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: false
                    ),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Ventas_Productos_FkProducto",
                        column: x => x.FkProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_FkUsuario",
                        column: x => x.FkUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FkCategoria",
                table: "Productos",
                column: "FkCategoria"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FkProveedor",
                table: "Productos",
                column: "FkProveedor"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_FkProducto",
                table: "Ventas",
                column: "FkProducto"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_FkUsuario",
                table: "Ventas",
                column: "FkUsuario"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Ventas");

            migrationBuilder.DropTable(name: "Productos");

            migrationBuilder.DropTable(name: "Usuarios");

            migrationBuilder.DropTable(name: "Categorias");

            migrationBuilder.DropTable(name: "Proveedores");
        }
    }
}
