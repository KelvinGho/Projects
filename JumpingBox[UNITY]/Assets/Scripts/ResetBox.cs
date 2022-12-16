using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetBox: MonoBehaviour
{
    public GameObject Player;
 
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float NewPosY = 65;


        if (collision.gameObject.tag == ("LevelL"))
        {

            collision.gameObject.transform.position = new Vector2(-2.6f, (int)Player.transform.position.y + (int)NewPosY);

        }
        else
        if (collision.gameObject.tag == ("LevelR"))
        {
            collision.gameObject.transform.position = new Vector2(2.6f, (int)Player.transform.position.y + (int)NewPosY);
        }
        else
        if (collision.gameObject.tag == ("Ground"))
        {
            Destroy(collision.gameObject);
            //collision.gameObject.transform.position = new Vector2(3, (int)Player.transform.position.y + (int)NewPosY);
        }
       
        
        
    }
}
