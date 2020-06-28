using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float gameDuration;
    public float gameOverDuration;
    public float flashingScoreDuration;

    public GameObject score;
    public GameObject gameOver;
    public Text winner;

    public PlayerController player1;
    public PlayerController player2;

    private string GetWinnerText()
    {
        if (player1.score > player2.score)
        {
            return "Player 1 wins!";
        }
        else if (player1.score < player2.score)
        {
            return "Player 2 wins!";
        }
        else
        {
            return "Tie!";
        }
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > gameDuration + gameOverDuration)
        {
            SceneManager.LoadScene("Splash");
        }
        else if (Time.timeSinceLevelLoad > gameDuration)
        {
            score.SetActive(false);
            gameOver.SetActive(true);
            winner.text = GetWinnerText();
        }
        else if (Time.timeSinceLevelLoad > gameDuration - flashingScoreDuration)
        {
            score.SetActive((int)(Time.timeSinceLevelLoad / 0.25) % 2 == 0);
        }
    }
}
