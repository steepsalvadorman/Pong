using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2Movement : MonoBehaviour
{
public float Speed = 1f;
public KeyCode upKey = KeyCode.UpArrow;
public KeyCode downKey = KeyCode.DownArrow;
private bool running = false;
private bool isNpcControlled = false;
private BallMovement ball;

private void Start()
{
    ball = FindObjectOfType<BallMovement>();
}

void Update()
{
    if (running)
    {
        float movVertical = 0f;

        if (!isNpcControlled)
        {
            movVertical = Input.GetAxis("Vertical");
        }
        else
        {
            // Move the paddle automatically towards the ball
            float ballPosY = ball.transform.position.y;
            float paddlePosY = transform.position.y;

            if (ballPosY > paddlePosY)
            {
                movVertical = 1f;
            }
            else if (ballPosY < paddlePosY)
            {
                movVertical = -1f;
            }
        }

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(
                transform.position.y + movVertical * Speed * Time.deltaTime,
                -4f,
                4f
            ),
            transform.position.z
        );
    }
}

public void Run()
{
    running = true;
}

public void Stop()
{
    running = false;
}

public void ToggleNpcControlled()
{
    isNpcControlled = !isNpcControlled;
}
}
