using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject Wing;
    public GameObject Bomb;
    public GameObject TNT;

    public float SpawnTime;
    public float SpawnDelay;
    private int RandomObject;

    private int RandomPlace;
    // Start is called before the first frame update
    void Start()
    {
          InvokeRepeating("SpawnObjects", SpawnTime, SpawnDelay);

    }

    // Update is called once per frame
  
    void SpawnObjects()
    {

        RandomObject = Random.Range(0, 3);
        RandomPlace=Random.Range(0,3);
        if (RandomPlace == 0)
        {
            gameObject.transform.position = new Vector3(0, 8, 0);
            if (RandomObject == 0)
            {
                GameObject WingClone = Instantiate(Wing, transform.position, Quaternion.identity);
            }
            if (RandomObject == 1)
            {
                GameObject BombClone = Instantiate(Bomb, transform.position, Quaternion.identity);
            }
            if (RandomObject == 2)
            {
                GameObject TNTClone = Instantiate(TNT, transform.position, Quaternion.identity);
            }
        }
        if (RandomPlace == 1)
        {
            gameObject.transform.position = new Vector3(4, 8, 0);
            if (RandomObject == 0)
            {
                GameObject WingClone = Instantiate(Wing, transform.position, Quaternion.identity);
            }
            if (RandomObject == 1)
            {
                GameObject BombClone = Instantiate(Bomb, transform.position, Quaternion.identity);
            }
            if (RandomObject == 2)
            {
                GameObject TNTClone = Instantiate(TNT, transform.position, Quaternion.identity);
            }
        }
        if (RandomPlace == 2)
        {
            gameObject.transform.position = new Vector3(8, 8, 0);
            if (RandomObject == 0)
            {
                GameObject WingClone = Instantiate(Wing, transform.position, Quaternion.identity);
            }
            if (RandomObject == 1)
            {
                GameObject BombClone = Instantiate(Bomb, transform.position, Quaternion.identity);
            }
            if (RandomObject == 2)
            {
                GameObject TNTClone = Instantiate(TNT, transform.position, Quaternion.identity);
            }
        }

    }
}
