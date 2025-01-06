using Microsoft.Extensions.Configuration;

namespace FamilyTree.DAL.Repositories
{
    public abstract class IRepository
    {
        protected readonly string _connectionString;

        protected IRepository()
        {
            _connectionString = LoadConnectionString();
        }

        private static string LoadConnectionString()
        {
            var configuration = ConfigManager.GetConfig();
            return configuration.GetConnectionString("DataSource");
        }
    }
}
