using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    private float randomX;
    Vector2 whereToSpawn;
    public float spawnDelay;
    float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        randomX = Random.Range(-6.39f, 6.39f);
        whereToSpawn = new Vector2(randomX, transform.position.y);
        GameObject Enemy = Instantiate(obj, whereToSpawn, Quaternion.identity);
        //Destroy(Enemy, 1.7f);
    }
    void SpawnRandomObject()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
