using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smena : MonoBehaviour
{
    public int coloredCount;





    public CircleCollider2D Collider;
    public SpriteRenderer spriteRenderer;

    public Color FFFF02 { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<CircleCollider2D>();
    }
    public void ReastartLevel()

    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {

            
            coloredCount++;

            if (coloredCount == 3)
            {
                ReastartLevel();
            }





        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
