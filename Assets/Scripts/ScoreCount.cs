using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public Text player1Score;
    public Text player2Score;

    public PlayerController player1;
    public PlayerController player2;

    void Update()
    {
        player1Score.text = player1.score.ToString();
        player2Score.text = player2.score.ToString();
    }
}
