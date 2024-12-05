using Microsoft.Data.Sqlite;
using SQLitePCL;
namespace FamilyTree.DAL
{
    internal class Initialization
    {
        private static readonly string DbPath = "FamilyTreeDB.db";
        public static void InitializationData()
        {
            if (!File.Exists(DbPath))
            {
                CreateDatabase();
                Seed();
            }
        }

        private static void CreateDatabase()
        {
            Batteries.Init();
            using var connection = new SqliteConnection($"Data Source={DbPath}");
            connection.OpenAsync().GetAwaiter().GetResult();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"
            CREATE TABLE IF NOT EXISTS RoleInTree( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            Title VARCHAR(50) NOT NULL);

            CREATE TABLE IF NOT EXISTS Person( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            Lastname VARCHAR(50) NOT NULL,
            Firstname VARCHAR(50) NOT NULL,
            Surname VARCHAR(50) NOT NULL,
            Birthday VARCHAR(50) NOT NULL,
            Gender VARCHAR(50) NOT NULL,
            IdRoleInTree INTEGER NOT NULL,
            FOREIGN KEY (IdRoleInTree) REFERENCES RoleInTree(Id) ON DELETE CASCADE);
            
            CREATE TABLE IF NOT EXISTS TypeRelationship( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            Title VARCHAR(50) NOT NULL);

            CREATE TABLE IF NOT EXISTS Relationship(
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
            using var connection = new SqliteConnection($"Data Source={DbPath}");
            connection.OpenAsync().GetAwaiter().GetResult();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"
            INSERT INTO RoleInTree(Id, Title)
            VALUES
                (1, 'Корень'),
                (2, 'Ребенок'),
                (3, 'Отсутствует');";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();
            command.CommandText = @"
            INSERT INTO Person(Id, Lastname, Firstname, Surname, Birthday, Gender, IdRoleInTree)
            VALUES
                (1, 'Суханова', 'Марьям', 'Михайловна', '1950-01-01', 'Женщина', 1),
                (2, 'Галкина', 'Эмма', 'Семёновна', '1973-05-04', 'Женщина', 2),
                (3, 'Гаврилов', 'Егор', 'Семёнов', '1975-11-12', 'Мужчина', 2),
                (4, 'Лазарева', 'Маргарита', 'Романовна', '1994-08-05', 'Женщина', 2),
                (5, 'Лебедев', 'Михаил', 'Дмитриевич', '2004-07-05', 'Мужчина', 2),
                (6, 'Акимова', 'Анна', 'Андреевна', '2007-05-05', 'Женщина', 3),
                (7, 'Суханов', 'Игорь', 'Алексеевич', '1955-02-20', 'Мужчина', 3);

            INSERT INTO TypeRelationship(Id, Title)
            VALUES
                (1, 'супруг'),
                (2, 'ребенок'),
                (3, 'родитель');";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();

            command.CommandText = @"
            INSERT INTO Relationship(Id, IdPerson, IdRelative, IdTypeRelationship)
            VALUES
                (1, 1, 2, 3), 
                (2, 1, 3, 3),
                (3, 2, 1, 2),
                (4, 3, 1, 2),
                (5, 2, 5, 1),
                (6, 5, 2, 1),
                (7, 2, 4, 3),
                (8, 5, 4, 3),
                (9, 4, 2, 2),
                (10, 4, 5, 2);";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();
        }
    }
}
