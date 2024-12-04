namespace FamilyTree.DAL.Repositories
{
    internal abstract class IRepository
    {
        protected readonly string _connectionString = "Data Source= FamilyTreeDB.db";
    }
}
