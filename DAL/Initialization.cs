using Microsoft.Data.Sqlite;
using SQLitePCL;
using System.Collections.Generic;
namespace FamilyTree.DAL
{
    internal class Initialization
    {
        private static readonly string dbPath = "FamilyTreeDB.db";
        public static void InitializationData()
        {
            if (!File.Exists(dbPath))
            {
                CreateDatabase();
                Seed();
            }
        }
        private static void CreateDatabase()
        {
            Batteries.Init();
            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.OpenAsync().GetAwaiter().GetResult();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"CREATE TABLE IF NOT EXISTS Person( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            Lastname VARCHAR(50) NOT NULL,
            Firstname VARCHAR(50) NOT NULL,
            Surname VARCHAR(50) NOT NULL,
            Birthdate DATE NOT NULL,
            Genre VARCHAR(50) NOT NULL,
            TreeRoot Bool NOT NULL);
            
            CREATE TABLE IF NOT EXISTS TypeRelationship( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            Title VARCHAR(50) NOT NULL);

            CREATE TABLE IF NOT EXISTS Relationships(
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            IdPerson INTGER NOT NULL,
            IdRelative INTGER NOT NULL,
            IdTypeRelationship INT NOT NULL,
            FOREIGN KEY (IdPerson) REFERENCES Person(Id) ON DELETE CASCADE,
            FOREIGN KEY (IdRelative) REFERENCES Person(Id) ON DELETE CASCADE,
            FOREIGN KEY (IdTypeRelationship) REFERENCES TypeRelationship(Id) ON DELETE CASCADE);";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();
        }

        private static void Seed()
        {
            Batteries.Init();
            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.OpenAsync().GetAwaiter().GetResult();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"
            INSERT INTO Person(Id, Lastname, Firstname, Surname, Birthdate, Genre, TreeRoot)
            VALUES
                (1, 'Суханова', 'Марьям', 'Михайловна', '1950-01-01', 'Женщина', true),
                (2, 'Галкина', 'Эмма', 'Семёновна', '1973-05-04', 'Женщина', false),
                (3, 'Гаврилов', 'Егор', 'Семёнов', '1975-11-12', 'Мужчина', false),
                (4, 'Лазарева', 'Маргарита', 'Романовна', '1994-08-05', 'Женщина', false),
                (5, 'Лебедев', 'Михаил', 'Дмитриевич', '2004-07-05', 'Мужчина', false);

            INSERT INTO TypeRelationship(Id, Title)
            VALUES
                (1, 'супруг'),
                (2, 'ребенок'),
                (3, 'родиетль');";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();

            command.CommandText = @"
            INSERT INTO Relationships(Id, IdPerson, IdRelative, IdTypeRelationship)
            VALUES
                (1, 1, 2, 2), 
                (2, 1, 3, 2),
                (3, 2, 1, 3),
                (4, 3, 1, 3),
                (5, 2, 5, 1),
                (6, 5, 2, 1),
                (7, 2, 4, 2),
                (8, 5, 4, 2),
                (9, 4, 2, 3),
                (10, 4, 5, 3);";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();
        }
    }
}
