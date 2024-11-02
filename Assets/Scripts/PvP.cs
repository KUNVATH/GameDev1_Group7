using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManagerPvP : MonoBehaviour
{
    public Button buttonRock;
    public Button buttonPaper;
    public Button buttonScissors;

    public Image player1ChoiceImage;
    public Image player2ChoiceImage;

    public Sprite notyet;
    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    public bool isPlayer1ChoiceMade = false;
    public bool isPlayer2ChoiceMade = false;

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

    public void OnButtonClick(Sprite choiceSprite)
    {
        if (!isPlayer1ChoiceMade)
        {
            player1Choice = choiceSprite;
            isPlayer1ChoiceMade = true;
            player1ChoiceImage.sprite = notyet;
        }
        else
        {
            player2Choice = choiceSprite;
            isPlayer2ChoiceMade = true;
            player1ChoiceImage.sprite = player1Choice;
            player2ChoiceImage.sprite = player2Choice;
            DetermineWinner();
            isPlayer1ChoiceMade = false;
        }
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
    }

    private void UpdateScore()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    void Start()
    {

    }

    void Update()
    {
        if (player1Score == player2Score + 3)
        {
            SceneManager.LoadScene("Player1Win");
        }
        else if (player1Score == player2Score - 3)
        {
            SceneManager.LoadScene("Player2Win");
        }
    }

}
