using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb2d;

    //jump
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask Ground;
    public float radius = 0.6f;
    private bool IsGrounded;

    //double Jump
    private int jumpsLeft = 1;
    private int currentJump = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();

       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsGrounded);
        if (Input.GetKeyDown(KeyCode.W)&&(IsGrounded==true||currentJump<jumpsLeft))
        {
            rb2d.velocity = Vector2.up * jumpForce;

            currentJump++; 
        }

        if (IsGrounded == true)
        {
            currentJump = 0;
        }
     }

    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, Ground);

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

         transform.position += movement * Time.deltaTime * moveSpeed;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathBox")
        {
            SceneManager.LoadScene("P2Wins");
        }
      

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("P2Wins");
        }
    }
}
