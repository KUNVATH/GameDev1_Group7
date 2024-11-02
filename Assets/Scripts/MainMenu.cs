using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartPvPPlay()
    {
        SceneManager.LoadScene("PvP");
    }

    public void StartAIPlay()
    {
        SceneManager.LoadScene("PvAI");
    }

    public void ShowInstructions()
    {
        SceneManager.LoadScene("IntroGame");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    void start(){

    }
}