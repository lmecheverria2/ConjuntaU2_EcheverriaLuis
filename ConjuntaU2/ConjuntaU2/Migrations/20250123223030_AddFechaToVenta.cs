using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConjuntaU2.Migrations
{
    /// <inheritdoc />
    public partial class AddFechaToVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Productos_ProductoId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_ProductoId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "FechaVenta",
                table: "Ventas",
                newName: "Fecha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Ventas",
                newName: "FechaVenta");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Ventas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ProductoId",
                table: "Ventas",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Productos_ProductoId",
                table: "Ventas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
