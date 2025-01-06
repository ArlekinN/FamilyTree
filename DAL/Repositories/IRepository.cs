namespace FamilyTree.DAL.Repositories
{
    public abstract class IRepository
    {
        protected readonly string _connectionString = $"Data Source=FamilyTreeDB.db";
    }
}
