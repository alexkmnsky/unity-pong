using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 7.5f;
    public Vector2 direction;

    public float directionMultiplier;
    public float speedIncrement;

    public bool hasBeenHit = false;
    public float newBallSlowdown = 2f;

    float halfBallHeight;
    float screenHalfHeightInWorldUnits;

    void Start()
    {
        halfBallHeight = transform.localScale.y / 2f;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime / (hasBeenHit ? 1 : newBallSlowdown));

        // Bounce the ball off of the top and bottom of the screen
        bool hitTopOfScreen = transform.position.y + halfBallHeight > screenHalfHeightInWorldUnits;
        bool hitBottomOfScreen = transform.position.y - halfBallHeight < -screenHalfHeightInWorldUnits;
        if (hitTopOfScreen || hitBottomOfScreen)
        {
            direction *= new Vector2(1, -1);
        }
    }
}
