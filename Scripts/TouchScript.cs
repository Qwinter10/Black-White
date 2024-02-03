using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class TouchScript : MonoBehaviour
{
    private bool isDragging = false; // флаг для определения, удерживается ли палец на экране
    private float minX, maxX; // минимальное и максимальное значение координаты X персонажа

    private void Start()
    {
        // Получаем размеры экрана в пикселях
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Преобразуем размеры экрана в мировые координаты
        Vector3 screenMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 screenMax = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 0));

        // Получаем минимальное и максимальное значение координаты X
        minX = screenMin.x;
        maxX = screenMax.x;
    }

    private void Update()
    {
        // Проверяем, есть ли касание на экране
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Если касание только начинается
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                // Проверяем, находится ли касание над персонажем
                if (GetComponent<Collider2D>().OverlapPoint(touchPos))
                {
                    isDragging = true;
                }
            }
            // Если касание завершилось или прекратилось
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }
    }

    private void FixedUpdate()
    {
        // Перемещаем персонажа
        if (isDragging)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            float targetX = Mathf.Clamp(touchPos.x, minX, maxX);
            if (-1.42587 < targetX && targetX < 1.735095)
            {
                transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
            }
        
        }
    }
}