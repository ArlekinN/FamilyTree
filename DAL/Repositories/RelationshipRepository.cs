using FamilyTree.DAL.Models;
using Microsoft.Data.Sqlite;
using Serilog;
using SQLitePCL;

namespace FamilyTree.DAL.Repositories
{
    public class RelationshipRepository: IRepository
    {
        private static RelationshipRepository Instance { get; set; }
        private RelationshipRepository() { }
        public static RelationshipRepository GetInstance()
        {
            Instance ??= new RelationshipRepository();
            return Instance;
        }

        public async void CreateRelationship(Relationship relationship)
        {
            Log.Information("Relationship Repository: Create Relationship");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                INSERT INTO Relationship(IdPerson, IdRelative, IdTypeRelationship, IdTree)
                VALUES(@idPerson, @idRelative, @idTypeRelationship, @idTree)", connection);
            command.Parameters.AddWithValue("@idPerson", relationship.IdPerson);
            command.Parameters.AddWithValue("@idRelative", relationship.IdRelative);
            command.Parameters.AddWithValue("@idTypeRelationship", relationship.IdTypeRelationship);
            command.Parameters.AddWithValue("@idTree", relationship.IdTree);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Relationship>> GetRelationships()
        {
            Log.Information("Relationship Repository: Get Relationships");
            var relationships = new List<Relationship>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand (@"select * from Relationship", connection );
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

        public async Task<List<int>> GetListDescendant(int idPerson, int idTree)
        {
            Log.Information("Relationship Repository: Get List Descendant");
            var idListDescendant = new List<int>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"select idRelative from Relationship
                    where IdTypeRelationship=3 and IdPerson=@idPerson and IdTree=@idTree", connection );
            command.Parameters.AddWithValue("@idPerson", idPerson);
            command.Parameters.AddWithValue("@idTree", idTree);
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    idListDescendant.Add(Convert.ToInt32(reader["IdRelative"]));
                }
            }
            var listChildCurrentDescendant = idListDescendant.GetRange(0, idListDescendant.Count);
            foreach (var child in listChildCurrentDescendant)
            {
                var newDescendants = GetListDescendant(child, idTree).Result;
                foreach (var newDescendant in newDescendants)
                {
                    idListDescendant.Add(newDescendant);
                }  
            }
            return idListDescendant;
        }

        public async Task<List<int>> GetIdPersonWithChild(int idTree)
        {
            Log.Information("Relationship Repository: Get Id Person With Child");
            var personsWithChilds = new List<int>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"select IdPerson from Relationship
                where IdTypeRelationship=3 and idTree=@idTree", connection );
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

        public async void DeleteRelationship(int id)
        {
            Log.Information("Relationship Repository: Delete Relationship");
            var relationships = new List<Relationship>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"delete from Relationship
                    where idTree=@id", connection );
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<int>> GetListAncestors(int idPerson, int idTree)
        {
            Log.Information("Relationship Repository: Get List Ancestors");
            var idListAncestors = new List<int>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"select idPerson from Relationship
                    where IdTypeRelationship=3 and IdRelative=@idPerson and IdTree=@idTree", connection );
            command.Parameters.AddWithValue("@idPerson", idPerson);
            command.Parameters.AddWithValue("@idTree", idTree);
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    idListAncestors.Add(Convert.ToInt32(reader["IdPerson"]));
                }
            }
            var listParentsCurrentAncestor = idListAncestors.GetRange(0, idListAncestors.Count);
            foreach (var parent in listParentsCurrentAncestor)
            {
                var newAncestors = GetListAncestors(parent, idTree).Result;
                foreach (var item in newAncestors)
                {
                    idListAncestors.Add(item);
                }
            }
            return idListAncestors;
        }
    }
}
