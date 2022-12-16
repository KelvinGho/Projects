using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject platformPrefab;

	public int numberOfPlatforms = 200;
    public float levelWidth = 0;
	public float minY = 0;
	public float maxY = 0;
   // public GameObject Doodler;
    // Use this for initialization
    Vector2 spawnPosition =  new Vector2();
    //float randx;
    //float randy;

    void Start () {


        for (int i = 0; i < numberOfPlatforms; i++)
		{
			spawnPosition.y += Random.Range(minY, maxY)-platformPrefab.transform.position.y;
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
		}

    }
    void Update()
    {
        //if (Doodler.transform.position.y >= spawnPosition.y)
        //{
        //    randy += Random.Range(Doodler.transform.position.y + 10.0f, Doodler.transform.position.y + 20.0f);
        //    randx = Random.Range(-2, 2);
        //    Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        //
        //    Vector3 spawnPosition = new Vector3(randx, randy, 0);
        //}
    }
}
