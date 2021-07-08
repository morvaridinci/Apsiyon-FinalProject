using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Apartments_BillId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_BillId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Apartments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BillId",
                table: "Bills",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Apartments_BillId",
                table: "Bills",
                column: "BillId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
