using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDestroyer : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Wing;
    public GameObject Bomb;
    public GameObject TNT;

    void OnTriggerEnter2D(Collider2D other)
    {
       
        
        if (other.gameObject.tag == "Bomb")
        {
            GameObject.Find("Bomb(Clone)").SendMessage("BombDestroyed", SendMessageOptions.DontRequireReceiver);
          
        }
        if (other.gameObject.tag=="Wing")
        {
            GameObject.Find("Wing(Clone)").SendMessage("WingDestroyed", SendMessageOptions.DontRequireReceiver);
                        
        }
        
        if (other.gameObject.tag=="TNT")
        {
            Debug.Log("HAELAELLWELAWELAEW");
            GameObject.Find("TNT(Clone)").SendMessage("TNTDestroyed", SendMessageOptions.DontRequireReceiver);
                           
        }
        
        if (other.gameObject.name == "Player1")
        {           
            GameObject.Find("Player1").SendMessage("Player1IsDead", SendMessageOptions.DontRequireReceiver);
        }
        if (other.gameObject.name == "Player2")
        {
           
            GameObject.Find("Player2").SendMessage("Player2IsDead", SendMessageOptions.DontRequireReceiver);
        }
    }
   
}
