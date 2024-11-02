using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManagerPvAI : MonoBehaviour
{
    public Button buttonRock;
    public Button buttonPaper;
    public Button buttonScissors;

    public Image player1ChoiceImage;
    public Image player2ChoiceImage;

    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    private int player1Score = 0;
    private int player2Score = 0;
    private Sprite player1Choice;
    private Sprite player2Choice;

    public void BackToGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRockClick()
    {
        OnButtonClick(rockSprite);
    }

    public void OnPaperClick()
    {
        OnButtonClick(paperSprite);
    }

    public void OnScissorsClick()
    {
        OnButtonClick(scissorsSprite);
    }

    public Sprite GetRandomChoice()
    {
        int choice = Random.Range(0, 3);
        switch (choice)
        {
            case 0: return rockSprite;
            case 1: return paperSprite;
            case 2: return scissorsSprite;
            default: return rockSprite;
        }
    }

    private void OnButtonClick(Sprite choiceSprite)
    {
        player1Choice = choiceSprite;
        player1ChoiceImage.sprite = choiceSprite;

        player2Choice = GetRandomChoice();
        player2ChoiceImage.sprite = player2Choice;

        DetermineWinner();
    }

    private void DetermineWinner()
    {
        if (player1Choice == player2Choice)
        {
            return;
        }
        if ((player1Choice == rockSprite && player2Choice == scissorsSprite) ||
            (player1Choice == paperSprite && player2Choice == rockSprite) ||
            (player1Choice == scissorsSprite && player2Choice == paperSprite))
        {
            player1Score++;
        }
        else
        {
            player2Score++;
        }

        UpdateScore();
        //CheckGameResult();
    }

    private void UpdateScore()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    // private void CheckGameResult()
    // {
    //     if (player1Score == player2Score + 3)
    //     {
    //         SceneManager.LoadScene("MainMenu");
    //     }
    //     else if (player1Score == player2Score - 3)
    //     {
    //         SceneManager.LoadScene("MainMenu");
    //     }
    // }

    void Start()
    {

    }
    void Update()
    {
        if (player1Score == player2Score + 3)
        {
            SceneManager.LoadScene("PlayerWin");
        }
        else if (player1Score == player2Score - 3)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
