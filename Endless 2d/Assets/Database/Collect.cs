using Assets.Classes;
using Mono.Data.Sqlite;
using System;

namespace Assets.Database
{
    class Collect
    {
        public static Func<SqliteDataReader, Player> Players = reader => new Player(reader.GetInt32(0), reader.GetString(1));
        public static Func<SqliteDataReader, PlayerScore> PlayerScoresWithName = reader => new PlayerScore(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3));

    }


}
