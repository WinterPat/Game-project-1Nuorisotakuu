using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Classes;
using Assets.Database;
public class EmilUseThis
{
    // Start is called before the first frame update
    private DatabaseConnection dbConn;
    public EmilUseThis()
    {
        dbConn = new DatabaseConnection();
    }

    public void SaveNameAndScore(string name, int score)
    {
        List<Player> players = dbConn.QueryAndCollect("SELECT * FROM player", Collect.Players);
        Player player = players.Find(e => e.Name == name);

        if (player == null)
        {
            players = new List<Player>
            {
                new Player(0, name)
            };

            dbConn.StoreObjects(players, Insert.Player);
            player = players[0];
        }

        List<PlayerScore> scores = new List<PlayerScore>
        {
            new PlayerScore(0, player.Id, score, name)
        };

        Debug.Log(scores[0]);
        dbConn.StoreObjects(scores, Insert.PlayerScore);
    }   
}
