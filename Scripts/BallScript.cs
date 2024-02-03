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
    private bool death = true;

    private void Start()
    {
        direction = new Vector2(UnityEngine.Random.Range(-1.5f, 1.5f), 1);
    }

    private void Update()
    {
        if (counter == 20 && speed < 50 && death)
        {
            speed += 2f;
            counter = 0;
        }
        ridgidbody.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("topLeft"))
        {
            direction.y = -direction.y;
            direction.x = -2;
        }
        if (collision.gameObject.CompareTag("left"))
        {
            direction.y = -direction.y;
            direction.x = -1;
        }
        if (collision.gameObject.CompareTag("middle"))
        {
            direction.y = -direction.y;
            direction.x = 0;
        }
        if (collision.gameObject.CompareTag("right"))
        {
            direction.y = -direction.y;
            direction.x = 1;
        }
        if (collision.gameObject.CompareTag("topRight"))
        {
            direction.y = -direction.y;
            direction.x = 2;
        }
        if (collision.gameObject.CompareTag("Roof"))
        {
            direction.y = -direction.y;
        }
        if (collision.gameObject.CompareTag("WallLeft") || collision.gameObject.CompareTag("WallRight"))
        {
            direction.x = -direction.x;
        }
        if (collision.gameObject.CompareTag("Killer_plat")) { death = false; speed = 0f; }

            counter++;
    }

}
