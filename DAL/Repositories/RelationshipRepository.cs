﻿using FamilyTree.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;

namespace FamilyTree.DAL.Repositories
{
    internal class RelationshipRepository: IRepository
    {
        private static RelationshipRepository Instance { get; set; }
        private RelationshipRepository() { }
        public static RelationshipRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RelationshipRepository();
            }
            return Instance;
        }

        public async void CreateRelationship(Relationship relationship)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                INSERT INTO Relationship(IdPerson, IdRelative, IdTypeRelationship)
                VALUES(@idPerson, @idRelative, @idTypeRelationship)", connection);
            command.Parameters.AddWithValue("@idPerson", relationship.IdPerson);
            command.Parameters.AddWithValue("@idRelative", relationship.IdRelative);
            command.Parameters.AddWithValue("@idTypeRelationship", relationship.IdTypeRelationship);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Relationship>> GetRelationships()
        {
            var relationships = new List<Relationship>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select * from Relationship";
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    var relationship = new Relationship
                    {
                        IdPerson = Convert.ToInt32(reader["IdPerson"]),
                        IdRelative = Convert.ToInt32(reader["IdRelative"]),
                        IdTypeRelationship = Convert.ToInt32(reader["IdTypeRelationship"])
                    };
                    relationships.Add(relationship);
                }
            }
            return relationships;
        }
    }
}
