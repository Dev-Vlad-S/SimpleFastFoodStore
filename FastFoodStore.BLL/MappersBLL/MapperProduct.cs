
namespace FastFoodStore.BLL.MappersBLL
{
    public static class MapperProduct
    {
        public static BLL.Models.ProductMBLL MapProductUp(DAL.Models.ProductMDAL Product)
        {
            return new BLL.Models.ProductMBLL()
            {
                ProductMBLLId = Product.ProductMDALId,
                MBLL_Product_Tag = Product.MDAL_Product_Tag,
                MBLL_Product_PurchasedCount = Product.MDAL_Product_PurchasedCount,
                MBLL_Product_ImagePath = Product.MDAL_Product_ImagePath,
                MBLL_Product_Name = Product.MDAL_Product_Name,
                MBLL_Product_Descriptiont = Product.MDAL_Product_Descriptiont,
                MBLL_Product_Price = Product.MDAL_Product_Price,
                MBLL_Product_IsAvailability = Product.MDAL_Product_IsAvailability
            };
        }

        public static DAL.Models.ProductMDAL MapProductDown(BLL.Models.ProductMBLL Product)
        {
            return new DAL.Models.ProductMDAL()
            {
                ProductMDALId = Product.ProductMBLLId,
                MDAL_Product_Tag = Product.MBLL_Product_Tag,
                MDAL_Product_PurchasedCount = Product.MBLL_Product_PurchasedCount,
                MDAL_Product_ImagePath = Product.MBLL_Product_ImagePath,
                MDAL_Product_Name = Product.MBLL_Product_Name,
                MDAL_Product_Descriptiont = Product.MBLL_Product_Descriptiont,
                MDAL_Product_Price = Product.MBLL_Product_Price,
            };
        }
    }
}
