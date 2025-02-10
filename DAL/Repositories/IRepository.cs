namespace FamilyTree.DAL.Repositories
{
    public abstract class IRepository
    {
        protected static string ConnectionString { get; } = $"Data Source={Path.Combine(AppContext.BaseDirectory, "FamilyTreeDB.db")}";
    } 
}
