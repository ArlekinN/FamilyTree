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
                        Id = Convert.ToInt32(reader["Id"]),
                        IdPerson = Convert.ToInt32(reader["IdPerson"]),
                        IdRelative = Convert.ToInt32(reader["IdRelative"]),
                        IdTypeRelationship = Convert.ToInt32(reader["IdTypeRelationship"]),
                        IdTree = Convert.ToInt32(reader["IdTree"])
                    };
                    relationships.Add(relationship);
                }
            }
            return relationships;
        }

        // Список всех потомков у конкретного человека
        public async Task<List<int>> GetListDescendant(int idPerson, int idTree)
        {
            var idListDescendant = new List<int>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select idRelative from Relationship
                    where IdTypeRelationship=3 and IdPerson=@idPerson and IdTree=@idTree";
            command.Parameters.AddWithValue("@idPerson", idPerson);
            command.Parameters.AddWithValue("@idTree", idTree);
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
                var newDescendants = GetListDescendant(descendant, idTree).Result;
                foreach (var newDescendant in newDescendants)
                {
                    idListDescendant.Add(newDescendant);
                }  
            }
            return idListDescendant;
        }

        // список id людей у которых есть дети
        public async Task<List<int>> GetIdPersonWithChild(int idTree)
        {
            var personsWithChilds = new List<int>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select IdPerson from Relationship
                where IdTypeRelationship=3 and idTree=@idTree";
            command.Parameters.AddWithValue("@idTree", idTree);
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    personsWithChilds.Add(Convert.ToInt32(reader["IdPerson"]));
                }
            }
            return personsWithChilds;
        }

        // удаление всех отношений у древа
        public async void DeleteRelationship(int id)
        {
            var relationships = new List<Relationship>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"delete from Relationship
                    where idTree=@id";
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }
    }
}
