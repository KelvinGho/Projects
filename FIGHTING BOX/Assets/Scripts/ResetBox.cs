using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBox : MonoBehaviour
{
    private float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 30)
        {
            transform.position = new Vector2(25,-5);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemy2")
        {
            Destroy(collision.gameObject);
        }
    }
}
