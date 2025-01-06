using FamilyTree.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace FamilyTree.DAL.Repositories
{
    public class PersonRepository: IRepository
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
                INSERT INTO Person(Lastname, Firstname, Surname, Birthday, Gender)
                VALUES(@lastname, @firstname, @surname, @birthday, @gender)", connection);
            command.Parameters.AddWithValue("@lastname", person.Lastname);
            command.Parameters.AddWithValue("@firstname", person.Firstname);
            command.Parameters.AddWithValue("@surname", person.Surname);
            command.Parameters.AddWithValue("@birthday", person.Birthday);
            command.Parameters.AddWithValue("@gender", person.Gender);
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
                    };
                    persons.Add(person);
                }
            }
            return persons;
        }
    }
}
