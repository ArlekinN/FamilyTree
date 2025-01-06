using Microsoft.Extensions.Configuration;


namespace FamilyTree.DAL.Repositories
{
    internal static class ConfigManager
    {
        public static IConfiguration GetConfig()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            return configuration;
        }  
    }
}
