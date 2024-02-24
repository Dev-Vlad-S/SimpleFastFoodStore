using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models
{
    public class ProductWPF 
    {
            public int ProductWPFId { get; set; }  // 1. код товара
            public string WPF_Product_Tag { get; set; } // 2. тэг товара (пиццы, соусы, роллы, стритфуды)
            public int WPF_Product_PurchasedCount { get; set; } // 3. купленное количество для создания топа купленных товаров
            public int WPF_Product_CountInBasket { get; set; } // 4. количество товара в корзине
            public string WPF_Product_ImagePath { get; set; } // 5. ссылка на картинку для карточки продукта
            public string WPF_Product_Name { get; set; } // 6. название продукта
            public string WPF_Product_Descriptiont { get; set; } // 7. описание продукта
            public double WPF_Product_Price { get; set; } //  8. стоимость продукта в рублях
            public double WPF_Product_PriceOnCount { get; set; } // 9. Цена за количество
    }
}
