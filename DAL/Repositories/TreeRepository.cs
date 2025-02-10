using FamilyTree.DAL.Models;
using Microsoft.Data.Sqlite;
using Serilog;
using SQLitePCL;

namespace FamilyTree.DAL.Repositories
{
    public class TreeRepository: IRepository
    {
        private static TreeRepository Instance { get; set; }
        private TreeRepository() { }
        public static TreeRepository GetInstance()
        {
            Instance ??= new TreeRepository();
            return Instance;
        }

        public async Task<List<Tree>> GetTrees()
        {
            Log.Information("Tree Repository: Get Trees");
            var trees = new List<Tree>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"select * from Tree", connection );
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    var tree = new Tree
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdPerson = Convert.ToInt32(reader["IdPerson"]),
                        CurrentTree = Convert.ToBoolean(reader["CurrentTree"])
                    };
                    trees.Add(tree);
                }
            }
            return trees;
        }

        public async void ChangeCurrentTree(int id)
        {
            Log.Information("Tree Repository: Change Current Tree");
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                    UPDATE Tree
                    SET CurrentTree = false", connection );
            await command.ExecuteNonQueryAsync();
            
            command = new SqliteCommand(@"
                    UPDATE Tree
                    SET CurrentTree = true
                    Where IdPerson = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }

        public async void ChangeRootCurrentTree(int id)
        {
            Log.Information("Tree Repository: Change Root Current Tree");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                    UPDATE Tree
                    SET IdPerson = @id
                    Where CurrentTree = true", connection );
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }

        public async void CreateTree(int id)
        {
            Log.Information("Tree Repository: Create Tree");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                INSERT INTO Tree(idPerson, CurrentTree)
                VALUES(@idPerson,false)", connection);
            command.Parameters.AddWithValue("@idPerson", id);
            await command.ExecuteNonQueryAsync();
        }

        public async void DeleteTree(int id)
        {
            Log.Information("Tree Repository: Delete Tree");
            var relationships = new List<Relationship>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"delete from Tree
                    where Id=@id", connection );
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }
    }
}
