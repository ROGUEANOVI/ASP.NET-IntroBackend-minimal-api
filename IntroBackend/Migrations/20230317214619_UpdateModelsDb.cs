using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroBackend.Migrations
{
    public partial class UpdateModelsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stock_BeerId",
                table: "Stock",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Beer_BrandId",
                table: "Beer",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beer_Brand_BrandId",
                table: "Beer",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Beer_BeerId",
                table: "Stock",
                column: "BeerId",
                principalTable: "Beer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beer_Brand_BrandId",
                table: "Beer");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Beer_BeerId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_BeerId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Beer_BrandId",
                table: "Beer");
        }
    }
}
