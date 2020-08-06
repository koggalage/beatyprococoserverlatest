using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyPro.CRM.EF.Migrations
{
    public partial class after : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerInvoiceProducts_ProductId",
                table: "Tbl_CustomerInvoiceProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_CustomerInvoiceProducts_Tbl_Product_ProductId",
                table: "Tbl_CustomerInvoiceProducts",
                column: "ProductId",
                principalTable: "Tbl_Product",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_CustomerInvoiceProducts_Tbl_Product_ProductId",
                table: "Tbl_CustomerInvoiceProducts");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_CustomerInvoiceProducts_ProductId",
                table: "Tbl_CustomerInvoiceProducts");
        }
    }
}
