using FastFoodStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodStore.DAL.DB.Providers.Sqlite
{
    public class ContextDataObjectsSqliteDB : DbContext
    {
        public DbSet<ProductMDAL> ProductsMDAL { get; set; }

        public ContextDataObjectsSqliteDB(DbContextOptions<ContextDataObjectsSqliteDB> options) : base(options) { }
    }
}
