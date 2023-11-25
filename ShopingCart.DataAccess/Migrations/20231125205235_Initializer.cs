using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopingCart.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initializer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT ShopingCart ON;
                INSERT INTO ShopingCart (Id,UserId)
                VALUES 
                (1,1),
                (2,1),
                (3,1),
                (4,2),
                (5,2),
                (6,3)
            ");

            migrationBuilder.Sql(@"INSERT INTO ShopingDetails (ProductId, Count, ShopingCartId)
                                    VALUES
                                    (1,1,1),
                                    (2,1,2),
                                    (3,1,2),
                                    (3,5,3),
                                    (3,1,4),
                                    (1,4,5),
                                    (2,7,6)
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("TRUNCATE TABLE ShopingDetails");
            migrationBuilder.Sql(@"DELETE FROM [ShopingCart]
                                    DBCC CHECKIDENT ([ShopingCart], RESEED, 0)");
        }
    }
}
