using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{   
    public float BulletSpeed = 20.0f;
    public Rigidbody2D Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb.velocity = transform.right * BulletSpeed;

    }

    // Update is called once per frame
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        Debug.Log(HitInfo.name);

        TNTScript TNT = HitInfo.GetComponent<TNTScript>();
        if (TNT != null)
        {
            
            GameObject.Find("TNT(Clone)").SendMessage("TNTDestroyed", SendMessageOptions.DontRequireReceiver);
           
            Destroy(gameObject);
        }
        BombScript Bomb = HitInfo.GetComponent<BombScript>();
        if (Bomb != null)
        {
            GameObject.Find("Bomb(Clone)").SendMessage("BombDestroyed", SendMessageOptions.DontRequireReceiver);
          
            Destroy(gameObject);
        }
        WingScript Wing = HitInfo.GetComponent<WingScript>();
        if (Wing != null)
        {
            GameObject.Find("Wing(Clone)").SendMessage("WingDestroyed", SendMessageOptions.DontRequireReceiver);
            Destroy(Wing.gameObject);
            Destroy(gameObject);
        }
       
    }
}
