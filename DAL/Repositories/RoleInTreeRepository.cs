using FamilyTree.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;

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

        // список ролей в древе
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
                        Title = reader["Title"].ToString(),
                    };
                    roles.Add(role);
                }
            }
            return roles;
        }
    }
}
