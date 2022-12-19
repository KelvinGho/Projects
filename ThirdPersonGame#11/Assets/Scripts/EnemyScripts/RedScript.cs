using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedScript : MonoBehaviour
{
    public GameObject ExplosionPrefab;

    private GameObject ExplosionClone;
    public float VanishTime;
    // Start is called before the first frame update

    void IsDead()
    {
       ExplosionClone = Instantiate(ExplosionPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z),Quaternion.Euler(new Vector3(transform.rotation.x-90 , transform.rotation.y, transform.rotation.z)));
        Destroy(ExplosionClone, VanishTime);


    }
}
