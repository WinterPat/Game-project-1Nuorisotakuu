using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager1 : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;
    
    public bool scoreIncreasing;

    void Start()
    { 
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

   
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        scoreText.text = "Score:" + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score:" + Mathf.Round(hiScoreCount);
    }

    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("CurrentScore", scoreCount);
    }
    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
    
}
