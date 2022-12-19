using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    public GameObject Platform;

    public GameObject[] PlatformSpawner;

 
    private int RandomStage;

    private int DSC1;
    private int DSC2;

    public float SpawnTime;

    public float SpawnDelay;
    // Start is called before the first frame update

    void Start()
    {
         
        InvokeRepeating("SpawnPlatform", SpawnTime, SpawnDelay);
        
    }

    void SpawnPlatform()
    {

        RandomStage = Random.Range(0, 5);


        if (RandomStage == 0)
        {
            SingleSpawn();
        }
        if (RandomStage == 1)
        {
            SingleSpawn();

        }
        if (RandomStage == 2)
        {
            SingleSpawn();

        }
        if (RandomStage == 3)
        {
            DoubleSpawn();

        }
        if (RandomStage == 4)
        {
            DoubleSpawn();

        }


    }

    void SingleSpawn()
    {
        GameObject newPlatform = Instantiate(Platform);
        newPlatform.transform.position = PlatformSpawner[RandomStage].transform.position;
    }
    void DoubleSpawn()
    {
      
        DSC1 = Random.Range(0, 2);       
        DSC2 = Random.Range(1, 3);
        if (DSC1 == 1 && DSC2 == 1)
        {

            DSC1 = 1;
            DSC2 = 2;

        }
        Instantiate(Platform, PlatformSpawner[DSC1].transform.position, Quaternion.identity);
        Instantiate(Platform, PlatformSpawner[DSC2].transform.position, Quaternion.identity);
       
        //Debug.Log("DSC1=" + DSC1);


        //Debug.Log("DSC2=" + DSC2);

    }
}
