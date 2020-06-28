using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;

    float inputAxis = 0f;

    float halfPlayerHeight;
    float screenHalfHeightInWorldUnits;

    void Start()
    {
        halfPlayerHeight = transform.localScale.y / 2f;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
    }

    void Update()
    {
        float velocity = inputAxis * speed;
        transform.Translate(Vector2.up * velocity * Time.deltaTime);

        // Prevent the player from exiting the screen
        if (transform.position.y + halfPlayerHeight > screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, screenHalfHeightInWorldUnits - halfPlayerHeight);
        }
        else if (transform.position.y - halfPlayerHeight < -screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, -screenHalfHeightInWorldUnits + halfPlayerHeight);
        }
    }

    public void OnMove(InputValue value)
    {
        inputAxis = value.Get<float>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            // Position where the ball hit the player
            float collisionIndex = transform.position.y - collision.transform.position.y;
            // Angle the bounce based on the collision index
            ball.direction = (ball.direction + Vector2.up * (collisionIndex * ball.directionMultiplier)).normalized;
            // Flip the ball direction
            ball.direction *= -1;
            // Increase the ball speed
            ball.speed += ball.speedIncrement;
            // Mark the ball as hit
            ball.hasBeenHit = true;
        }
    }


}
