using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FastFoodStore.DAL.DB.Providers.Sqlite
{
    public class FactoryContextDataObjectsSqliteDB : IDesignTimeDbContextFactory<ContextDataObjectsSqliteDB>
    {
        public ContextDataObjectsSqliteDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextDataObjectsSqliteDB>();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("DBSettingsConnection.json");
            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("SqLiteConnectionString");
            optionsBuilder.UseSqlite(connectionString);
            return new ContextDataObjectsSqliteDB(optionsBuilder.Options);
        }
    }
}
