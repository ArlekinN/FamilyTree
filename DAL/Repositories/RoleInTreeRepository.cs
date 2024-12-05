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
    }
}
