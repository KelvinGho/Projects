using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenScript : MonoBehaviour
{
    public GameObject PoisonCloudPrefab;
    
    private GameObject PoisonCloudClone;

    public float VanishTime;//time to determine the poison cloud vanish

   
    void IsDead()
    {
       
        PoisonCloudClone= Instantiate(PoisonCloudPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
       
        Destroy(PoisonCloudClone, VanishTime);
    }

}
