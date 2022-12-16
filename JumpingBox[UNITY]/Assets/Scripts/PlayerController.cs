using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    //movement
    float movement = 0;
   public float Speed;

    //bouncing
    bool Direction;
    public float SideLimit;
    float NewPosX;

    //jump
    Rigidbody2D rb;
    public bool isGrounded;
    public float jumpForce = 0;
    
    
    //died
    GameObject target;

    //score

    public Text score;
   static public int number;

    
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;

        Direction = true;

         rb = transform.GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Enemy");

        //score.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

        number = 0;

    }

  

    // Update is called once per frame
    void Update()
    {
        //bouncing
        if (Direction == true)
        {
            transform.Translate(Vector2.right* Speed * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.left *Speed * Time.deltaTime);

        }   

        
        //NewPosX = transform.position.x + movement;
        //if (NewPosX > SideLimit)
        //{
        //    NewPosX = SideLimit;
        //    Direction = false;
        //}
        //if (NewPosX < -SideLimit+0.3f)
        //{
        //    NewPosX = -SideLimit+0.3f ;

        //    Direction = true;

        //}
        //transform.position = new Vector2(NewPosX, transform.position.y);

       
        //jump
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }

        Score();
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground") && !isGrounded)
        {
            isGrounded = true;
        }
       
        if (collision.gameObject.tag == ("WallRight"))
        {
            Direction = false;

        }
        if (collision.gameObject.tag == ("WallLeft"))
        {
            Direction =true;

        }

        if (collision.gameObject.tag == ("Enemy") || collision.gameObject.tag==("DeathBox"))
        {           
            SceneManager.LoadScene("GameOver");
           
        }

        if (collision.gameObject.tag == ("LevelL") && !isGrounded)
        {
            isGrounded = true;
            //number += 1;

            AddScore(collision.gameObject.GetComponent<Transform>().position.y);
        }
        if (collision.gameObject.tag == ("LevelR") && !isGrounded)
        {
            isGrounded = true;
            //number += 1;

            AddScore(collision.gameObject.GetComponent<Transform>().position.y);
        }
       
    }

    void Score()
    {
        score.text = number.ToString();
        PlayerPrefs.SetInt("score", number);
    }

    void AddScore(float _y)
    {
        if (number > (int)(_y / 2.0f)) return; // klo score ny udh lbh bsr, g bkl msuk kbwh lg
        //Debug.Log("MSKK _y : " + _y);
        number = (int)(_y / 2.0f);
    }





   
}
