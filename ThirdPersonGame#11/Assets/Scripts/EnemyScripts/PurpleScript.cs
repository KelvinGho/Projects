using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PurpleScript : MonoBehaviour
{
    public GameObject Minion;
    public Transform SpawnMinion1;
    public Transform SpawnMinion2;

    // Start is called before the first frame update
    void IsDead()
    {
        Vector3[] SpawnPosition = new[] { new Vector3(SpawnMinion1.position.x,SpawnMinion1.position.y,SpawnMinion1.position.z), new Vector3(SpawnMinion2.position.x, SpawnMinion2.position.y, SpawnMinion2.position.z) };

        for (int i = 0; i < 2; i++)
        {
            Instantiate(Minion,SpawnPosition[i] , Quaternion.identity);
        }

    }
}
