using System.Data;
using Mono.Data.Sqlite;
using System;
using Assets.Classes;

namespace Assets.Database
{
    class Insert
    {
        public static Func<Player, SqliteCommand, Player> Player = (player, command) => 
        {
            string query = "INSERT INTO player(name) VALUES(@name)";
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            command.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "name",
                    Value = player.Name
                }
            );
            command.ExecuteNonQuery();
            command.CommandText = "SELECT last_insert_rowid()";
            long id = (long)command.ExecuteScalar();
            player.Id = (int) id;
            return player;
        };


        public static Func<PlayerScore, SqliteCommand, PlayerScore> PlayerScore = (playerScore, command) =>
        {
            string query = "INSERT INTO playerscore(player_id, score) VALUES(@player_id, @score)";
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            command.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "player_id",
                    Value = playerScore.Player_id
                }
            );

            command.Parameters.Add(new SqliteParameter
            {
                ParameterName = "score",
                Value = playerScore.Score
            }
            );

            command.ExecuteNonQuery();
            command.CommandText = "SELECT last_insert_rowid()";
            long id = (long)command.ExecuteScalar();
            playerScore.Id = (int)id;
            return playerScore;
        };
    }
}
