using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DeathMenu1 : MonoBehaviour
{
    public string mainMenuLevel;
    private Button saveButton;
    private InputField nameInput;
    private bool canSave = true;
    private EmilUseThis eut;

    void Start()
    {
        eut = new EmilUseThis();
        saveButton = GameObject.Find("SaveButton").GetComponent<Button>();
        nameInput = GameObject.Find("NameInputField").GetComponent<InputField>();
        saveButton.onClick.AddListener(() =>
        {
            if (canSave)
            {
                canSave = false;
                string name = nameInput.text;
                int score = (int)PlayerPrefs.GetFloat("CurrentScore");
                eut.SaveNameAndScore(name, score);
            }
        });
    }

    public void RestartGame()
    {
        FindObjectOfType<GameManager1>().Reset();
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(sceneName: "mainMenu");
        //Application.LoadLevel(mainMenuLevel);
    }
    public void Better()
    {
        Debug.Log("MOI");
        SceneManager.LoadScene(sceneName: "Endless with score");
    }
}
