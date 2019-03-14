using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System;

public class DatabaseConnection
{
    private string dbPath;

    public DatabaseConnection()
    {
        dbPath = $"URI=file:{Application.persistentDataPath}/endless.db";
        CreateSchema();
    }

    public List<T> QueryAndCollect<T>(string query, Func<SqliteDataReader, T> collector, params SqliteParameter[] queryParams)
    {
        List<T> rows = new List<T>();
        SqliteConnection connection = new SqliteConnection(dbPath);
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = query;
        command.Parameters.AddRange(queryParams);
        SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            rows.Add(collector(reader));
        }
        reader.Close();
        connection.Close();
        return rows;
    }

    public void StoreObjects<T>(List<T> objects, Func<T, SqliteCommand, T> inserter)
    {
        SqliteConnection connection = new SqliteConnection(dbPath);
        connection.Open();
        foreach (T t in objects)
        {
            T result = inserter(t, connection.CreateCommand());
        }
        connection.Close();
    }

    public void UpdateRow<T>(T rowObject, Func<T, SqliteCommand, T> updater)
    {
        SqliteConnection connection = new SqliteConnection(dbPath);
        connection.Open();
        T result = updater(rowObject, connection.CreateCommand());
        connection.Close();
    }
    

    private void UpdateDatabase(string query, params SqliteParameter[] queryParams)
    {
        SqliteConnection connection = new SqliteConnection(dbPath);
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.Clone();
        command.CommandType = CommandType.Text;
        command.CommandText = query;
        command.Parameters.AddRange(queryParams);
        command.ExecuteNonQuery();
        connection.Close();
    }

    private void Puff()
    {
        string puffstring = "INSERT INTO player(id, name) VALUES(1, \"janne\");" +
            "INSERT INTO player(id, name) VALUES(2, \"patrik\");" +
            "INSERT INTO player(id, name) VALUES(3, \"emil\");" +
            "INSERT INTO playerscore(id, player_id, score) VALUES(1, 1, 1000);" +
            "INSERT INTO playerscore(id, player_id, score) VALUES(2, 2, 900);" +
            "INSERT INTO playerscore(id, player_id, score) VALUES(3, 3, 800);";
        UpdateDatabase(puffstring);
    }

    private void CreateSchema()
    {
        string preCommands = "DROP TABLE IF EXISTS player; DROP TABLE IF EXISTS playerscore; ";

        string player = "CREATE TABLE IF NOT EXISTS player" +
            "(" +
            "id INTEGER PRIMARY KEY AUTOINCREMENT," +
            "name VARCHAR(255) NOT NULL" +
            ");";

        string playerScore = "CREATE TABLE IF NOT EXISTS playerscore" +
            "(" +
            "id INTEGER PRIMARY KEY AUTOINCREMENT," +
            "player_id INT NOT NULL," +
            "score INT NOT NULL," +
            "FOREIGN KEY (player_id) REFERENCES player(id)" +
            ");";
        
        string schema = $"{player}{playerScore}";
        UpdateDatabase(schema);
    }
    
}