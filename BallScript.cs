using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D ridgidbody;
    public Vector2 direction;
    public float speed;
    private int counter = 0;
    private bool cos_counter = true;
    private bool death = true;

    private void Start()
    {
        direction = new Vector2(UnityEngine.Random.Range(-1.5f, 1.5f), 1);
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (counter == 20 && speed < 20 && death)
        {
            speed += 2f;
            counter = 0;
        }
        ridgidbody.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallLeft"))
        {
            if (direction.x < 0) direction.x = -direction.x;
            cos_counter = true;
        }
        if (collision.gameObject.CompareTag("WallRight"))
        {
            if (direction.x > 0) direction.x = -direction.x;
            cos_counter = true;
        }
        if (collision.gameObject.CompareTag("topLeft") && cos_counter)
        {
            direction.y = -direction.y;
            direction.x = -2;
            cos_counter = false;
        }
        else if (collision.gameObject.CompareTag("midLeft") && cos_counter)
        {
            direction.y = -direction.y;
            direction.x = -1.5f;
            cos_counter = false;
        }
        else if (collision.gameObject.CompareTag("left") && cos_counter)
        {
            direction.y = -direction.y;
            direction.x = -1;
            cos_counter = false;
        }
        else if (collision.gameObject.CompareTag("smallLeft") && cos_counter)
        {
            direction.y = -direction.y;
            direction.x = -0.5f;
            cos_counter = false;
        }
        else if (collision.gameObject.CompareTag("middle") && cos_counter)
        {
            direction.y = -direction.y;
            direction.x = 0;
            cos_counter = false;
        }
        else if (collision.gameObject.CompareTag("smallRight") && cos_counter)
        {
            direction.y = -direction.y;
            direction.x = 0.5f;
            cos_counter = false;
        }
        else if (collision.gameObject.CompareTag("right") && cos_counter)
        {
            direction.y = -direction.y;
            direction.x = 1;
            cos_counter = false;
        }
        else if (collision.gameObject.CompareTag("smallRight") && cos_counter)
        {
            direction.y = -direction.y;
            direction.x = 1.5f;
            cos_counter = false;
        }
        else if (collision.gameObject.CompareTag("topRight") && cos_counter)
        {
            direction.y = -direction.y;
            direction.x = 2;
            cos_counter = false;
        }
        if (collision.gameObject.CompareTag("Roof"))
        {
            direction.y = -direction.y;
            cos_counter = true;
        }
        if (collision.gameObject.CompareTag("Killer_plat")) { death = false; speed = 0f; }

            counter++;
    }

}
