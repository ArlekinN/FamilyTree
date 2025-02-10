using FamilyTree.DAL.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace FamilyTree.DAL.Repositories
{
    public class TreeRepository: IRepository
    {
        private static TreeRepository Instance { get; set; }
        private TreeRepository() { }
        public static TreeRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new TreeRepository();
            }
            return Instance;
        }

        // список всех деревьев
        public async Task<List<Tree>> GetTrees()
        {
            var trees = new List<Tree>();
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select * from Tree";
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

        // изменение текущего древа
        public async void ChangeCurrentTree(int id)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"
                    UPDATE Tree
                    SET CurrentTree = false";
            await command.ExecuteNonQueryAsync();
            
            command = new SqliteCommand(@"
                    UPDATE Tree
                    SET CurrentTree = true
                    Where IdPerson = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }

        // изменение корня текущего древа
        public async void ChangeRootCurrentTree(int id)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command = new SqliteCommand(@"
                    UPDATE Tree
                    SET IdPerson = @id
                    Where CurrentTree = true", connection);
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }

        // создание нового древа
        public async void CreateTree(int id)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                INSERT INTO Tree(idPerson, CurrentTree)
                VALUES(@idPerson,false)", connection);
            command.Parameters.AddWithValue("@idPerson", id);
            await command.ExecuteNonQueryAsync();
        }

        // удаление древа
        public async void DeleteTree(int id)
        {
            var relationships = new List<Relationship>();
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"delete from Tree
                    where Id=@id";
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }
    }
}
