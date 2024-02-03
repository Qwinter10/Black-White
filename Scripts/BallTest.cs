using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTest : MonoBehaviour
{
    public float initialSpeed = 5f; // ��������� �������� ������
    public float accelerationRate = 0.1f; // ����������� ���������

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ������ ��������� ����������� ��������
        Vector2 initialDirection = new Vector2(1f, 1f).normalized;
        rb.velocity = initialDirection * initialSpeed;
    }

    void Update()
    {

        // �������� ����� �� ��������
        AccelerateBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) ReflectBall(Vector2.up);
        if (collision.gameObject.CompareTag("Roof")) ReflectBall(Vector2.down);
        if (collision.gameObject.CompareTag("WallLeft")) ReflectBall(Vector2.right);
        if (collision.gameObject.CompareTag("WallRight")) ReflectBall(Vector2.left);
        if (collision.gameObject.CompareTag("Killer_plat")) initialSpeed = 0f;
    }

    void ReflectBall(Vector2 reflectionDirection)
    {
        // ������ � ���������� ����
        Vector2 newDirection = reflectionDirection.normalized;
        rb.velocity = newDirection * (rb.velocity.magnitude + accelerationRate);
    }

    void AccelerateBall()
    {
        // �������� ����� �� ��������
        rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + accelerationRate * Time.deltaTime);
    }
}
