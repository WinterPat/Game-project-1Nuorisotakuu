using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour
{
    public int scoreToGive;

    private ScoreManager1 theScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
        }
    }
}
