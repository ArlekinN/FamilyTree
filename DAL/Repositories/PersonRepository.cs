using FamilyTree.DAL.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using Serilog;

namespace FamilyTree.DAL.Repositories
{
    public class PersonRepository: IRepository
    {
        private static PersonRepository Instance { get; set; }
        private PersonRepository() { }
        public static PersonRepository GetInstance()
        {
            Instance ??= new PersonRepository();
            return Instance;
        }
        public async void CreatePerson(Person person)
        {
            Log.Information("Person Repository: Create Person");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                INSERT INTO Person(Lastname, Firstname, Surname, Birthday, Gender)
                VALUES(@lastname, @firstname, @surname, @birthday, @gender)", connection);
            command.Parameters.AddWithValue("@lastname", person.Lastname);
            command.Parameters.AddWithValue("@firstname", person.Firstname);
            command.Parameters.AddWithValue("@surname", person.Surname);
            command.Parameters.AddWithValue("@birthday", person.Birthday);
            command.Parameters.AddWithValue("@gender", person.Gender);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Person>> GetPersons()
        {
            Log.Information("Person Repository: Get Person");
            var persons = new List<Person>();
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand(@"select * from Person", connection );
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
