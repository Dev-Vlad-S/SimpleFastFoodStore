
namespace FastFoodStore.BLL.Models
{
    public record class ProductMBLL
    {
        public int ProductMBLLId { get; set; }  // 1. код товара
        public string MBLL_Product_Tag { get; set; } // 2. тэг товара (пиццы, соусы, роллы, стритфуды)
        public int MBLL_Product_PurchasedCount { get; set; } // 3. купленное количество для создания топа купленных товаров
        public string MBLL_Product_ImagePath { get; set; } // 4. ссылка на картинку для карточки продукта
        public string MBLL_Product_Name { get; set; } // 5. название продукта
        public string MBLL_Product_Descriptiont { get; set; } // 6. Описание продукта
        public double MBLL_Product_Price { get; set; } //  7. Стоимость продукта в рублях
        public bool MBLL_Product_IsAvailability { get; set; } // 8. Доступность продукта. Если есть ингридиенты для приготовления продукта.
    }
}
