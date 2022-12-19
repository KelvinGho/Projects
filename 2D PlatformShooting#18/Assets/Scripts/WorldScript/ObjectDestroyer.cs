using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
 

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            Destroy(other.gameObject);
        }
       
        if (other.tag == "Object")
        {
            Destroy(other.gameObject);
        }
    }
   
}