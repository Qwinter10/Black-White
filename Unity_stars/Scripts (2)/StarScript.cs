using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarScript : MonoBehaviour
{
    public SpriteRenderer[] sprites;
    public int coloredCount;
    bool tru = false;




    public CircleCollider2D Collider;
    public SpriteRenderer spriteRenderer;

    public Color FFFF02 { get; private set; }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<CircleCollider2D>();

    }
    
    void Update()
    {
        /*foreach (SpriteRenderer sprite in sprites)
        {
            if (sprite.color != FFFF02)
            {
                
                coloredCount++;
            }
        }
        */
        
        

    }

    public void ReastartLevel()

   {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {

            spriteRenderer.color = new Color(0.25f, 0.23f, 0.18f, 0.5f);
            //coloredCount++;
            
            



            Collider.isTrigger = true;
            Collider.enabled = false;
            

        }
        

    }
        
}
