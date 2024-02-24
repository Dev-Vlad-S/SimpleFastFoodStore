using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodStore.DAL.DB.Providers.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsMDAL",
                columns: table => new
                {
                    ProductMDALId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MDAL_Product_Tag = table.Column<string>(type: "TEXT", nullable: false),
                    MDAL_Product_PurchasedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MDAL_Product_ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    MDAL_Product_Name = table.Column<string>(type: "TEXT", nullable: false),
                    MDAL_Product_Descriptiont = table.Column<string>(type: "TEXT", nullable: false),
                    MDAL_Product_Price = table.Column<double>(type: "REAL", nullable: false),
                    MDAL_Product_IsAvailability = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsMDAL", x => x.ProductMDALId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsMDAL");
        }
    }
}
