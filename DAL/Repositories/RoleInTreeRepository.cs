using FamilyTree.DAL.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace FamilyTree.DAL.Repositories
{
    public class RoleInTreeRepository: IRepository
    {
        private static RoleInTreeRepository Instance { get; set; }
        private RoleInTreeRepository() { }
        public static RoleInTreeRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RoleInTreeRepository();
            }
            return Instance;
        }

        // создание новой роли для человека в дереве
        public async void CreateRoleInTree(RoleInTree roleInTree)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                INSERT INTO RoleInTree(IdPerson, IdTree, IdTypeRoleInTree)
                VALUES(@idPerson, @idTree, @idTypeRoleInTree)", connection);
            command.Parameters.AddWithValue("@idPerson", roleInTree.IdPerson);
            command.Parameters.AddWithValue("@idTree", roleInTree.IdTree);
            command.Parameters.AddWithValue("@idTypeRoleInTree", roleInTree.IdTypeRoleInTree);
            await command.ExecuteNonQueryAsync();
        }

        // список всез ролей
        public async Task<List<RoleInTree>> GetRoleInTree()
        {
            var roles = new List<RoleInTree>();
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select * from RoleInTree";
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

        // изменение роли человека 
        public async void ChangeRolePerson(int idPerson, int idTree, int idTypeRoleInTree)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                    UPDATE RoleInTree
                    SET IdTypeRoleInTree = @idTypeRoleInTree
                    WHERE IdPerson=@idPerson and idTree=@idTree", connection);
            command.Parameters.AddWithValue("@idPerson", idPerson);
            command.Parameters.AddWithValue("@idTypeRoleInTree", idTypeRoleInTree);
            command.Parameters.AddWithValue("@idTree", idTree);
            await command.ExecuteNonQueryAsync();
        }

        // создание роли 
        public async void CreateRole(RoleInTree roleInTree)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                INSERT INTO RoleInTree(IdPerson, IdTree, IdTypeRoleInTree)
                VALUES(@idPerson, @idTree, @idTypeRoleInTree)", connection);
            command.Parameters.AddWithValue("@idPerson", roleInTree.IdPerson);
            command.Parameters.AddWithValue("@idTree", roleInTree.IdTree);
            command.Parameters.AddWithValue("@idTypeRoleInTree", roleInTree.IdTypeRoleInTree);
            await command.ExecuteNonQueryAsync();
        }

        // удалить роли у древа
        public async void DeleteRolesInTree(int idTree)
        {
            var relationships = new List<Relationship>();
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"delete from RoleInTree
                    where IdTree=@id";
            command.Parameters.AddWithValue("@id", idTree);
            await command.ExecuteNonQueryAsync();
        }
    }
}
