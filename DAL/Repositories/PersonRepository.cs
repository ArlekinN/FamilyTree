using FamilyTree.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace FamilyTree.DAL.Repositories
{
    internal class PersonRepository: IRepository
    {
        private static PersonRepository Instance { get; set; }
        private PersonRepository() { }
        public static PersonRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new PersonRepository();
            }
            return Instance;
        }

        // создание человека
        public async void CreatePerson(Person person)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                INSERT INTO Person(Lastname, Firstname, Surname, Birthday, Gender, IdRoleInTree)
                VALUES(@lastname, @firstname, @surname, @birthday, @gender, @idRoleInTree)", connection);
            command.Parameters.AddWithValue("@lastname", person.Lastname);
            command.Parameters.AddWithValue("@firstname", person.Firstname);
            command.Parameters.AddWithValue("@surname", person.Surname);
            command.Parameters.AddWithValue("@birthday", person.Birthday);
            command.Parameters.AddWithValue("@gender", person.Gender);
            command.Parameters.AddWithValue("@idRoleInTree", person.IdRoleInTree);
            await command.ExecuteNonQueryAsync();
        }

        // список людей
        public async Task<List<Person>> GetPersons()
        {
            var persons = new List<Person>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select * from Person";
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    var person = new Person
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Lastname = reader["Lastname"].ToString(),
                        Firstname = reader["Firstname"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Birthday = reader["Birthday"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        IdRoleInTree = Convert.ToInt32(reader["IdRoleInTree"])
                    };
                    persons.Add(person);
                }
            }
            return persons;
        }

        // обновление роли человека в древе
        public async void UpdateRoleInTree(int id, int idRoleInTree)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                    UPDATE Person
                    SET IdRoleInTree = @idRoleInTree
                    WHERE Id=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@idRoleInTree", idRoleInTree);
            await command.ExecuteNonQueryAsync();
        }

        // очищение древа
        public async void ClearTree()
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                    UPDATE Person
                    SET IdRoleInTree = 3", connection);
            await command.ExecuteNonQueryAsync();
        }

        // создание нового древа
        public async void CreateNewRoot(int id)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                    UPDATE Person
                    SET IdRoleInTree = 1
                    WHERE Id=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }
    }
}
