using Assets.Classes;
using System.Collections.Generic;
using UnityEngine;
using Assets.Database;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreboardController : MonoBehaviour
{
    private DatabaseConnection dbConn;
    private List<PlayerScore> scores;
    private Text text;
    private Button back;

    // Start is called before the first frame update
    void Start()
    {
        back = GameObject.Find("back_to_mainmenu").GetComponent<Button>();
        back.onClick.AddListener(() => SceneManager.LoadScene(sceneName: "mainMenu"));

        text = GameObject.Find("scoreboard_text").GetComponent<Text>();
        dbConn = new DatabaseConnection();
        scores = dbConn.QueryAndCollect(Query.ALL_PLAYER_SCORES, Collect.PlayerScoresWithName);
        scores.Sort((a, b) => b.Score.CompareTo(a.Score));
        PrintScores();
    }

    private void PrintScores()
    {
        string final = "";
        foreach (PlayerScore ps in scores)
        {
            final += $"{ps.Player_name}\t{ps.Score}\n";
        }
        Debug.Log(final);
        text.text = final;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
