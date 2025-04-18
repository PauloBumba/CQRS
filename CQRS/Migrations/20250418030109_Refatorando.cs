using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS.Migrations
{
    /// <inheritdoc />
    public partial class Refatorando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_produtct",
                table: "produtct");

            migrationBuilder.RenameTable(
                name: "produtct",
                newName: "product");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "product",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "produtct");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "produtct",
                newName: "Nome");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produtct",
                table: "produtct",
                column: "Id");
        }
    }
}
