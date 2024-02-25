
namespace FastFoodStore.DAL.Models
{
    public class ProductMDAL
    {
        public int ProductMDALId { get; set; }  // 1. код товара
        public string MDAL_Product_Tag { get; set; } // 2. тэг товара (пиццы, соусы, роллы, стритфуды)
        public int MDAL_Product_PurchasedCount { get; set; } // 3. купленное количество для создания топа купленных товаров
        public string MDAL_Product_ImagePath { get; set; } // 4. ссылка на картинку для карточки продукта
        public string MDAL_Product_Name { get; set; } // 5. название продукта
        public string? MDAL_Product_Descriptiont { get; set; } // 6. Описание продукта
        public double MDAL_Product_Price { get; set; } //  7. Стоимость продукта в рублях
        public bool MDAL_Product_IsAvailability { get; set; } // 8. Доступность продукта. Если есть ингридиенты для приготовления продукта.
    }
}
