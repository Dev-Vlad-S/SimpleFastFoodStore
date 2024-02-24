using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.MappersWPFView
{
    public class MapperProduct
    {
        public static Models.ProductWPF? MapProductUp(BLL.Models.ProductMBLL Product)
        {
            if (Product.MBLL_Product_IsAvailability)
            {
                return new Models.ProductWPF()
                {
                    ProductWPFId = Product.ProductMBLLId,
                    WPF_Product_Tag = Product.MBLL_Product_Tag,
                    WPF_Product_PurchasedCount = Product.MBLL_Product_PurchasedCount,
                    WPF_Product_CountInBasket = 0,
                    WPF_Product_ImagePath = Product.MBLL_Product_ImagePath,
                    WPF_Product_Name = Product.MBLL_Product_Name,
                    WPF_Product_Descriptiont = Product.MBLL_Product_Descriptiont,
                    WPF_Product_Price = Product.MBLL_Product_Price,
                    WPF_Product_PriceOnCount = 0,
                };
            }
            else return null;
        }

        public static BLL.Models.ProductMBLL MapProductDown(ProductWPF Product)
        {
            return new BLL.Models.ProductMBLL()
            {
                ProductMBLLId = Product.ProductWPFId,
                MBLL_Product_Tag = Product.WPF_Product_Tag,
                MBLL_Product_PurchasedCount = Product.WPF_Product_PurchasedCount + Product.WPF_Product_CountInBasket,
                MBLL_Product_ImagePath = Product.WPF_Product_ImagePath,
                MBLL_Product_Name = Product.WPF_Product_Name,
                MBLL_Product_Descriptiont = Product.WPF_Product_Descriptiont,
                MBLL_Product_Price = Product.WPF_Product_Price
            };
        }
    }
}
