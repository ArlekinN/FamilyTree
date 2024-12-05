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

        // создание таблиц
        private static void CreateDatabase()
        {
            Batteries.Init();
            using var connection = new SqliteConnection($"Data Source={DbPath}");
            connection.OpenAsync().GetAwaiter().GetResult();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Person( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            Lastname VARCHAR(50) NOT NULL,
            Firstname VARCHAR(50) NOT NULL,
            Surname VARCHAR(50) NOT NULL,
            Birthday VARCHAR(50) NOT NULL,
            Gender VARCHAR(50) NOT NULL);

            CREATE TABLE IF NOT EXISTS TypeRoleInTree( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            Title VARCHAR(50) NOT NULL);
            
            CREATE TABLE IF NOT EXISTS Tree( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            IdPerson INTEGER NOT NULL,
            CurrentTree BOOl NOT NULL,
            FOREIGN KEY (IdPerson) REFERENCES Person(Id) ON DELETE CASCADE);
            
            CREATE TABLE IF NOT EXISTS RoleInTree( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            IdPerson INTEGER NOT NULL,
            IdTree INTEGER NOT NULL,
            IdTypeRoleInTree INTEGER NOT NULL,
            FOREIGN KEY (IdPerson) REFERENCES Person(Id) ON DELETE CASCADE,
            FOREIGN KEY (IdTree) REFERENCES Tree(Id) ON DELETE CASCADE,
            FOREIGN KEY (IdTypeRoleInTree) REFERENCES TypeRoleInTree(Id) ON DELETE CASCADE);

            CREATE TABLE IF NOT EXISTS TypeRelationship( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            Title VARCHAR(50) NOT NULL);

            CREATE TABLE IF NOT EXISTS Relationship(
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            IdPerson INTGER NOT NULL,
            IdRelative INTGER NOT NULL,
            IdTypeRelationship INT NOT NULL,
            IdTree INTEGER NOT NULL,
            FOREIGN KEY (IdPerson) REFERENCES Person(Id) ON DELETE CASCADE,
            FOREIGN KEY (IdRelative) REFERENCES Person(Id) ON DELETE CASCADE,
            FOREIGN KEY (IdTypeRelationship) REFERENCES TypeRelationship(Id) ON DELETE CASCADE,
            FOREIGN KEY (IdTree) REFERENCES Tree(Id) ON DELETE CASCADE);";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();
        }

        // заполнение таблиц
        private static void Seed()
        {
            Batteries.Init();
            using var connection = new SqliteConnection($"Data Source={DbPath}");
            connection.OpenAsync().GetAwaiter().GetResult();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"
            INSERT INTO Person(Id, Lastname, Firstname, Surname, Birthday, Gender)
            VALUES
                (1, 'Суханова', 'Марьям', 'Михайловна', '1950-01-01', 'Женщина'),
                (2, 'Галкина', 'Эмма', 'Семёновна', '1973-05-04', 'Женщина'),
                (3, 'Гаврилов', 'Егор', 'Семёнов', '1975-11-12', 'Мужчина'),
                (4, 'Лазарева', 'Маргарита', 'Романовна', '2022-08-05', 'Женщина'),
                (5, 'Лебедев', 'Михаил', 'Дмитриевич', '1980-07-05', 'Мужчина'),
                (6, 'Акимова', 'Анна', 'Андреевна', '2007-05-05', 'Женщина'),
                (7, 'Суханов', 'Игорь', 'Алексеевич', '1955-02-20', 'Мужчина');
            
            INSERT INTO TypeRoleInTree(Id, Title)
            VALUES
                (1, 'Корень'),
                (2, 'Ребенок'),
                (3, 'Отсутствует');

            INSERT INTO TypeRelationship(Id, Title)
            VALUES
                (1, 'супруг'),
                (2, 'ребенок'),
                (3, 'родитель');";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();

            command.CommandText = @"
            INSERT INTO Tree(Id, IdPerson, CurrentTree)
            VALUES
                (1, 1, true),
                (2, 7, false);";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();

            command.CommandText = @"
            INSERT INTO RoleInTree(Id, IdTree, IdPerson, IdTypeRoleInTree)
            VALUES
                (1, 1, 1, 1),
                (2, 1, 2, 2),
                (3, 1, 3, 2),
                (4, 1, 4, 2),
                (5, 1, 5, 2),
                (6, 1, 6, 3),
                (7, 1, 7, 3),
                (8, 2, 7, 1),
                (9, 2, 2, 2),
                (10, 2, 3, 2),
                (11, 2, 4, 2),
                (12, 2, 5, 2),
                (13, 2, 6, 2),
                (14, 2, 1, 3);";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();

            command.CommandText = @"
            INSERT INTO Relationship(Id, IdPerson, IdRelative, IdTypeRelationship, IdTree)
            VALUES
                (1, 1, 2, 3, 1), 
                (2, 1, 3, 3, 1),
                (3, 2, 1, 2, 1),
                (4, 3, 1, 2, 1),
                (5, 2, 5, 1, 1),
                (6, 5, 2, 1, 1),
                (7, 2, 4, 3, 1),
                (8, 5, 4, 3, 1),
                (9, 4, 2, 2, 1),
                (10, 4, 5, 2, 1),
                (11, 7, 3, 3, 2),
                (12, 7, 4, 3, 2),
                (13, 3, 7, 2, 2),
                (14, 4, 7, 2, 2),
                (15, 3, 2, 1, 2),
                (16, 2, 3, 1, 2),
                (17, 4, 6, 1, 2),
                (18, 6, 4, 1, 2),
                (19, 4, 5, 3, 2),
                (20, 6, 5, 3, 2),
                (21, 5, 4, 2, 2),
                (22, 5, 6, 2, 2);";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();
        }
    }
}
