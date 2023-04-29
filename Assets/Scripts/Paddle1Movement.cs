using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1Movement : MonoBehaviour
{
    public float Speed = 4f;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;

    private bool running = false;

    void Update()
    {
        if (running)
        {
            float movVertical = 0f;
            if (Input.GetKey(upKey))
                movVertical = 1f;
            else if (Input.GetKey(downKey))
                movVertical = -1f;

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
}
