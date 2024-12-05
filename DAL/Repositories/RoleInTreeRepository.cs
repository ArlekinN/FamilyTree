using FamilyTree.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;

namespace FamilyTree.DAL.Repositories
{
    internal class RoleInTreeRepository: IRepository
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
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                INSERT INTO RoleInTree(IdPerson, IdTree, IdRoleInTree)
                VALUES(@idPerson, @idTree, @idRoleInTree)", connection);
            command.Parameters.AddWithValue("@idPerson", roleInTree.IdPerson);
            command.Parameters.AddWithValue("@idTree", roleInTree.IdTree);
            command.Parameters.AddWithValue("@idRoleInTree", roleInTree.IdTypeRoleInTree);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<RoleInTree>> GetRoleInTree()
        {
            var roles = new List<RoleInTree>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
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
                        IdPerson = Convert.ToInt32(reader["Lastname"]),
                        IdTree = Convert.ToInt32(reader["Firstname"]),
                        IdTypeRoleInTree = Convert.ToInt32(reader["Surname"])
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
            using var connection = new SqliteConnection(_connectionString);
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
    }
}
