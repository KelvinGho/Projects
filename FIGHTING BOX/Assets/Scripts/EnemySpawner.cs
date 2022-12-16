using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    float randX;
    Vector2 WhereToSpawn;
    public float spawnrate = 2f;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnrate;
            randX = Random.Range(-9.5f, 9.5f);
            WhereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Enemy, WhereToSpawn, Quaternion.identity);

        }


    }
}
