using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCRM.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerEnqyuiry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerEnquiry",
                columns: table => new
                {
                    CustomerEnquiryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEnquiry", x => x.CustomerEnquiryID);
                    table.ForeignKey(
                        name: "FK_CustomerEnquiry_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEnquiry_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEnquiry_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEnquiry_CompanyId",
                table: "CustomerEnquiry",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEnquiry_CustomerId",
                table: "CustomerEnquiry",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEnquiry_ProductId",
                table: "CustomerEnquiry",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerEnquiry");
        }
    }
}
