using FamilyTree.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace FamilyTree.DAL.Repositories
{
    internal class TreeRepository: IRepository
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
            using var connection = new SqliteConnection(_connectionString);
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
                        IdPerson = Convert.ToInt32(reader["IdPerson"])
                    };
                    trees.Add(tree);
                }
            }
            return trees;
        }

        // изменение текущего дерева
        public async void ChangeCurrentTree(int id)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
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
    }
}
