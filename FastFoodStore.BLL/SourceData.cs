using FastFoodStore.DAL.DB.Providers.Sqlite;
using FastFoodStore.BLL.MappersBLL;
using FastFoodStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodStore.BLL
{
    public class SourceData
    {
        private readonly ContextDataObjectsSqliteDB contextDataObjectsSqliteDB;

        public SourceData()
        {
            contextDataObjectsSqliteDB = new FactoryContextDataObjectsSqliteDB().CreateDbContext(Array.Empty<string>());
        }

        public IEnumerable<BLL.Models.ProductMBLL> GetAllProductsFromDB()
        {
            return contextDataObjectsSqliteDB.ProductsMDAL.Select(MapperProduct.MapProductUp).ToList();
        }

        public bool UpdatePurchasedCountProductsInDataSource(BLL.Models.ProductMBLL productMBLL)
        {
            bool isSave = false;
            var productDAL = contextDataObjectsSqliteDB.ProductsMDAL.FirstOrDefault(prod => prod.ProductMDALId == productMBLL.ProductMBLLId);
            var productFromStore = BLL.MappersBLL.MapperProduct.MapProductDown(productMBLL);
            productDAL.MDAL_Product_PurchasedCount = productFromStore.MDAL_Product_PurchasedCount;

            try
            {
                contextDataObjectsSqliteDB.SaveChanges();
                isSave = true;
            }
            catch (Exception ex)
            {
                
            }
            return isSave;
        }
    }
}
