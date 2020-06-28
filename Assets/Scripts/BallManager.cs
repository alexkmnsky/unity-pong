using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab;

    public PlayerController leftPlayer;
    public PlayerController rightPlayer;

    float screenHalfWidthInWorldUnits;

    GameObject ball;
    float halfBallWidth;

    void ResetBall(Vector2 direction)
    {
        // Destroy the current ball if it exsits
        if (ball != null) { Destroy(ball.gameObject); }
        // Instantiate a new ball
        ball = (GameObject)Instantiate(ballPrefab, transform);
        // Get the Ball Script component
        Ball ballComponent = ball.gameObject.GetComponent<Ball>();
        // Set the direction of the ball
        ballComponent.direction = direction;
        halfBallWidth = ball.transform.localScale.x / 2f;
    }

    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;

        // Create a new ball at game start
         Vector2 direction = Vector2.right;
        // Randomly select direction
        if (Random.Range(0, 2) == 1) { direction *= -1; }
        ResetBall(direction);
    }

    void Update()
    {
        // Detect if ball went off screen, destory current ball and reset
        if (ball.transform.position.x - halfBallWidth > screenHalfWidthInWorldUnits)
        {
            leftPlayer.score += 1;
            ResetBall(Vector2.right);
        }
        else if (ball.transform.position.x + halfBallWidth < -screenHalfWidthInWorldUnits)
        {
            rightPlayer.score += 1;
            ResetBall(Vector2.left);
        }
    }
}
