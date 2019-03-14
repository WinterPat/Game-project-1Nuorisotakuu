using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Database
{
    class Query
    {
        public static string ALL_PLAYERS = "SELECT * FROM player";
        public static string ALL_PLAYER_SCORES = "SELECT playerscore.id, player.id, playerscore.score, player.name FROM player, playerscore where player.id = playerscore.player_id";
    }
}
