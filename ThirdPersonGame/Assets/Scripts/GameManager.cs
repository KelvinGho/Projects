using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] EnemyPrefab;
    public GameObject[] SpawnPoints;


   
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
    }

   
    void EnemySpawn()
    {
    
        for (int idx=0;idx<5;idx++)
        {
            Instantiate(EnemyPrefab[idx],SpawnPoints[idx].transform.position, Quaternion.identity);
           
        }
    }
}
