using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MendozaMejia_ForoControlRollback.Migrations
{
    /// <inheritdoc />
    public partial class Rollback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    cliente_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    direccion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    telefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cliente__47E34D64E50E807E", x => x.cliente_id);
                });

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    empleado_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    direccion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    telefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    salario = table.Column<double>(type: "float", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__empleado__6FBB65FDB75D3E0C", x => x.empleado_id);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    pedido_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaPedido = table.Column<DateTime>(type: "date", nullable: true),
                    cliente_id = table.Column<int>(type: "int", nullable: true),
                    empleado_id = table.Column<int>(type: "int", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pedido__CBE760762CEFB810", x => x.pedido_id);
                    table.ForeignKey(
                        name: "FK__pedido__cliente___4D94879B",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "cliente_id");
                    table.ForeignKey(
                        name: "FK__pedido__empleado__4E88ABD4",
                        column: x => x.empleado_id,
                        principalTable: "empleado",
                        principalColumn: "empleado_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_pedido_cliente_id",
                table: "pedido",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_empleado_id",
                table: "pedido",
                column: "empleado_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "empleado");
        }
    }
}
