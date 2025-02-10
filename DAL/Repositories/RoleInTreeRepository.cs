using FamilyTree.DAL.Models;
using Microsoft.Data.Sqlite;
using Serilog;
using SQLitePCL;

namespace FamilyTree.DAL.Repositories
{
    public class RoleInTreeRepository: IRepository
    {
        private static RoleInTreeRepository Instance { get; set; }
        private RoleInTreeRepository() { }
        public static RoleInTreeRepository GetInstance()
        {
            Instance ??= new RoleInTreeRepository();
            return Instance;
        }

        public async void CreateRoleInTree(RoleInTree roleInTree)
        {
            Log.Information("Role In Tree Repository: Create Role In Tree");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                INSERT INTO RoleInTree(IdPerson, IdTree, IdTypeRoleInTree)
                VALUES(@idPerson, @idTree, @idTypeRoleInTree)", connection);
            command.Parameters.AddWithValue("@idPerson", roleInTree.IdPerson);
            command.Parameters.AddWithValue("@idTree", roleInTree.IdTree);
            command.Parameters.AddWithValue("@idTypeRoleInTree", roleInTree.IdTypeRoleInTree);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<RoleInTree>> GetRoleInTree()
        {
            Log.Information("Role In Tree Repository: Get Role In Tree");
            var roles = new List<RoleInTree>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"select * from RoleInTree", connection );
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    var role = new RoleInTree
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdPerson = Convert.ToInt32(reader["IdPerson"]),
                        IdTree = Convert.ToInt32(reader["IdTree"]),
                        IdTypeRoleInTree = Convert.ToInt32(reader["IdTypeRoleInTree"])
                    };
                    roles.Add(role);
                }
            }
            return roles;
        }

        public async void ChangeRolePerson(int idPerson, int idTree, int idTypeRoleInTree)
        {
            Log.Information("Role In Tree Repository: Change Role Person");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                    UPDATE RoleInTree
                    SET IdTypeRoleInTree = @idTypeRoleInTree
                    WHERE IdPerson=@idPerson and idTree=@idTree", connection);
            command.Parameters.AddWithValue("@idPerson", idPerson);
            command.Parameters.AddWithValue("@idTypeRoleInTree", idTypeRoleInTree);
            command.Parameters.AddWithValue("@idTree", idTree);
            await command.ExecuteNonQueryAsync();
        }

        public async void CreateRole(RoleInTree roleInTree)
        {
            Log.Information("Role In Tree Repository: Create Role");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                INSERT INTO RoleInTree(IdPerson, IdTree, IdTypeRoleInTree)
                VALUES(@idPerson, @idTree, @idTypeRoleInTree)", connection);
            command.Parameters.AddWithValue("@idPerson", roleInTree.IdPerson);
            command.Parameters.AddWithValue("@idTree", roleInTree.IdTree);
            command.Parameters.AddWithValue("@idTypeRoleInTree", roleInTree.IdTypeRoleInTree);
            await command.ExecuteNonQueryAsync();
        }

        public async void DeleteRolesInTree(int idTree)
        {
            Log.Information("Role In Tree Repository: Delete Roles In Tree");
            var relationships = new List<Relationship>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var  command = new SqliteCommand(@"delete from RoleInTree
                    where IdTree=@id", connection );
            command.Parameters.AddWithValue("@id", idTree);
            await command.ExecuteNonQueryAsync();
        }
    }
}
