using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeEnvios.Migrations
{
    public partial class RemovingOrderIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Parcels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
