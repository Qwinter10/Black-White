using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody2D ridgidbody;
    public Vector2 dierection;
    public float speed;
    public float accelerationRate = 0.1f;

    private void Start()
    {
        dierection = new Vector2(Random.Range(-1.5f, 1.5f), 1);
    }


    private void Update()
    {
        ridgidbody.velocity = dierection.normalized * (ridgidbody.velocity.magnitude + accelerationRate);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Roof"))
        {
            dierection.y = -dierection.y;
        }
        if (collision.gameObject.CompareTag("WallLeft") || collision.gameObject.CompareTag("WallRight"))
        {
            dierection.x = -dierection.x;
        }
    }

}