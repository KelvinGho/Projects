using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingScript : MonoBehaviour
{
    public GameObject WingDestroyedPS;
    [SerializeField] private float speed = 2.5f;
    // Start is called before the first frame update

    void WingDestroyed()
    {
        GameObject WingPSClone = Instantiate(WingDestroyedPS, transform.position, Quaternion.identity);
        Destroy(WingPSClone, 2.0f);
        Destroy(gameObject);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.position += Vector3.left * speed * Time.fixedDeltaTime;
        }
    }
}
