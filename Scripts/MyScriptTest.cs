using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class MyScriptTest : MonoBehaviour
{
    private bool isDragging = false; // ���� ��� �����������, ������������ �� ����� �� ������
    private float minX, maxX; // ����������� � ������������ �������� ���������� X ���������

    private void Start()
    {
        // �������� ������� ������ � ��������
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // ����������� ������� ������ � ������� ����������
        Vector3 screenMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 screenMax = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 0));

        // �������� ����������� � ������������ �������� ���������� X
        minX = screenMin.x;
        maxX = screenMax.x;
    }

    private void Update()
    {
        // ���������, ���� �� ������� �� ������
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ���� ������� ������ ����������
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                // ���������, ��������� �� ������� ��� ����������
                if (GetComponent<Collider2D>().OverlapPoint(touchPos))
                {
                    isDragging = true;
                }
            }
            // ���� ������� ����������� ��� ������������
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }
    }

    private void FixedUpdate()
    {
        // ���������� ���������
        if (isDragging)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            float targetX = Mathf.Clamp(touchPos.x, minX, maxX);
            if (targetX < -4) targetX = -4f;
            if (targetX > 5) targetX = 5f;
            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);

        }
    }
}
