using FamilyTree.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;
namespace FamilyTree.DAL.Repositories
{
    internal class TypeRelationshipRepository: IRepository
    {
        private static TypeRelationshipRepository Instance { get; set; }
        private TypeRelationshipRepository() { }
        public static TypeRelationshipRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new TypeRelationshipRepository();
            }
            return Instance;
        }
        public async Task<List<TypeRelationship>> GetRelationships()
        {
            var typesRelationship = new List<TypeRelationship>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select * from TypeRelationship";
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    var typeRelationship = new TypeRelationship
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Title = reader["Title"].ToString()
                    };
                    typesRelationship.Add(typeRelationship);
                }
            }
            return typesRelationship;
        }
    }
}
