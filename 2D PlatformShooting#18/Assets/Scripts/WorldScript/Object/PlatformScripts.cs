using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScripts : MonoBehaviour
{
    public GameObject Wing;
    public GameObject Bomb;
    public GameObject TNT;
    [SerializeField]private float speed=25;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position+=Vector3.left*speed*Time.fixedDeltaTime;
    }

 

}
