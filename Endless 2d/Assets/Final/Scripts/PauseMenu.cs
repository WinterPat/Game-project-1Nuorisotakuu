﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;


    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameManager1>().Reset();
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName: "mainMenu");
        //Application.LoadLevel(mainMenuLevel);
    }
    public void Lesser()
    {
        Debug.Log("MOI");
   
        SceneManager.LoadScene(sceneName: "Endless with score");
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

    }
}