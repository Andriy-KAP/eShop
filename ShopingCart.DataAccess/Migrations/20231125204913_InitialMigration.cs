using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopingCart.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopingCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ShopingCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopingDetails", x => x.Id);
                    table.CheckConstraint("CK_Product_Count", "Count > 0 AND Count <= 10");
                    table.ForeignKey(
                        name: "FK_ShopingDetails_ShopingCart_ShopingCartId",
                        column: x => x.ShopingCartId,
                        principalTable: "ShopingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopingDetails_ShopingCartId",
                table: "ShopingDetails",
                column: "ShopingCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopingDetails");

            migrationBuilder.DropTable(
                name: "ShopingCart");
        }
    }
}
