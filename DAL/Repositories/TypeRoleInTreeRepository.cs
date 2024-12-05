using FamilyTree.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace FamilyTree.DAL.Repositories
{
    internal class TypeRoleInTreeRepository: IRepository
    {
        private static TypeRoleInTreeRepository Instance { get; set; }
        private TypeRoleInTreeRepository() { }
        public static TypeRoleInTreeRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new TypeRoleInTreeRepository();
            }
            return Instance;
        }

        // список ролей в древе
        public async Task<List<TypeRoleInTree>> GetRoleInTree()
        {
            var roles = new List<TypeRoleInTree>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select * from RoleInTree";
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    var role = new TypeRoleInTree
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
