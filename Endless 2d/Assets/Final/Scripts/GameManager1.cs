using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{

    public Transform platformGenerator1;
    private Vector3 platformStartPoint;

    public PlayerControllerF thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer1[] platformList;

    private ScoreManager1 theScoreManager;

    public DeathMenu1 theDeathScreen;

    public PauseMenu thePause;

    void Start()
    {
        platformStartPoint = platformGenerator1.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager1>();


    }

    
    void Update()
    {
        
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCo");//
    }


    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer1>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator1.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

   


    /*public IEnumerator RestartGameCo()//oottaa hetken ja resetoi sitten
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer1>();
        for(int i = 0; i< platformList.Length;i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator1.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
