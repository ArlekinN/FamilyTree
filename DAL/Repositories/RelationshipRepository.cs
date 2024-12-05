using FamilyTree.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace FamilyTree.DAL.Repositories
{
    internal class RelationshipRepository: IRepository
    {
        private static RelationshipRepository Instance { get; set; }
        private RelationshipRepository() { }
        public static RelationshipRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RelationshipRepository();
            }
            return Instance;
        }

        // создание отношений
        public async void CreateRelationship(Relationship relationship)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                INSERT INTO Relationship(IdPerson, IdRelative, IdTypeRelationship, IdTree)
                VALUES(@idPerson, @idRelative, @idTypeRelationship, @idTree)", connection);
            command.Parameters.AddWithValue("@idPerson", relationship.IdPerson);
            command.Parameters.AddWithValue("@idRelative", relationship.IdRelative);
            command.Parameters.AddWithValue("@idTypeRelationship", relationship.IdTypeRelationship);
            command.Parameters.AddWithValue("@idTree", relationship.IdTree);
            await command.ExecuteNonQueryAsync();
        }

        // список отношений
        public async Task<List<Relationship>> GetRelationships()
        {
            var relationships = new List<Relationship>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select * from Relationship";
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    var relationship = new Relationship
                    {
                        IdPerson = Convert.ToInt32(reader["IdPerson"]),
                        IdRelative = Convert.ToInt32(reader["IdRelative"]),
                        IdTypeRelationship = Convert.ToInt32(reader["IdTypeRelationship"])
                    };
                    relationships.Add(relationship);
                }
            }
            return relationships;
        }

        // Список всех потомков у конкретного человека
        public async Task<List<int>> GetListDescendant(int id)
        {
            var idListDescendant = new List<int>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select idRelative from Relationship
                    where IdTypeRelationship=3 and IdPerson=@id";
            command.Parameters.AddWithValue("@id", id);
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    idListDescendant.Add(Convert.ToInt32(reader["IdRelative"]));
                }
            }
            var listChildCurrentAncestor = idListDescendant.GetRange(0, idListDescendant.Count);
            foreach (var descendant in listChildCurrentAncestor)
            {
                var newDescendants = GetListDescendant(descendant).Result;
                foreach (var newDescendant in newDescendants)
                {
                    idListDescendant.Add(newDescendant);
                }  
            }
            return idListDescendant;
        }

        // список id людей у которых есть дети
        public async Task<List<int>> GetIdPersonWithChild()
        {
            var personsWithChilds = new List<int>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select IdPerson from Relationship
                where IdTypeRelationship=3";
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    personsWithChilds.Add(Convert.ToInt32(reader["IdPerson"]));
                }
            }
            return personsWithChilds;
        }

        // удаление всех отношений
        public async void DeleteRelationship()
        {
            var relationships = new List<Relationship>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"delete from Relationship";
            await command.ExecuteNonQueryAsync();
        }
    }
}
