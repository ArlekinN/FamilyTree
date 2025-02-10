using FamilyTree.DAL.Models;
using Microsoft.Data.Sqlite;
using Serilog;
using SQLitePCL;
namespace FamilyTree.DAL.Repositories
{
    public class TypeRelationshipRepository: IRepository
    {
        private static TypeRelationshipRepository Instance { get; set; }
        private TypeRelationshipRepository() { }
        public static TypeRelationshipRepository GetInstance()
        {
            Instance ??= new TypeRelationshipRepository();
            return Instance;
        }

        public async Task<List<TypeRelationship>> GetRelationships()
        {
            Log.Information("Type Relationship Repository: Get Relationships");
            var typesRelationship = new List<TypeRelationship>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"select * from TypeRelationship", connection );
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
