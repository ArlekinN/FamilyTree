﻿using FamilyTree.Models;
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

        public async void CreatePerson(Person person)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                INSERT INTO Person(Lastname, Firstname, Surname, Birthday, Gender, IdRoleInTree)
                VALUES(@lastname, @firstname, @surname, @birthday, @gender, 3)", connection);
            command.Parameters.AddWithValue("@lastname", person.Lastname);
            command.Parameters.AddWithValue("@firstname", person.Firstname);
            command.Parameters.AddWithValue("@surname", person.Surname);
            command.Parameters.AddWithValue("@birthday", person.Birthday);
            command.Parameters.AddWithValue("@gender", person.Gender);
            await command.ExecuteNonQueryAsync();
        }
    }
}
