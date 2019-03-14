using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{

    private Button newGame;
    private Button scoreBoard;
    private Button exit;

    // Start is called before the first frame update
    void Start()
    {
        newGame = GameObject.Find("new_game").GetComponent<Button>();
        scoreBoard = GameObject.Find("scoreboard").GetComponent<Button>();
        exit = GameObject.Find("exit").GetComponent<Button>();

        newGame.onClick.AddListener(() => SceneManager.LoadScene(sceneName: "Endless with score"));
        scoreBoard.onClick.AddListener(() => SceneManager.LoadScene(sceneName: "Scoreboard"));
        exit.onClick.AddListener(() => Application.Quit());
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
