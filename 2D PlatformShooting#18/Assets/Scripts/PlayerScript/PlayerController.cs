    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
      
    [Header("PlayerMovement")]
    public float runSpeed = 4.0f;

    private float InputX;

    //GROUNDCHECK
    [SerializeField] private float JumpForce = 400f;// Amount of force added when the player jumps.
    public  LayerMask WhatIsGround;
    public  Transform OnGroundCheck;
    public Vector2 checkRadius;

    public bool IsGrounded;
    //JUMP
    public bool CanJump;
    private int JumpsValue;
    public int  extraJumpsValue;

    [Header("Items")]

    //Wing
    public GameObject Wing;
    public SpriteRenderer RightWingSprite;
    public SpriteRenderer LeftWingSprite;
    
    private bool WingsEnabled;
    private bool FlyEffect;

    private float FlyEffectTime;
    //SpriteFlashing
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    
    [Space]
    //Effect
    public GameObject PlayerExplodePrefab;
    
    public SpriteRenderer[] Stuns;
    public SpriteRenderer Tag;
    private bool GetStun;
    private int StunsValue;
    private bool Immune;
    private float ImmuneTime;
   
    

    private float RespawnTime;
    private float RespawnLeft;
    private bool RespawnValue;
    //public float knockbackForce;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        WingsEnabled = false;
        JumpsValue = 0;
        FlyEffectTime=0;

        //effect
        GetStun = false;
        StunsValue = 0;

        Immune = false;
        ImmuneTime = 0;

        RespawnTime = 0;
        RespawnValue = false;
        RespawnLeft = 3;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        //effect
        if (IsGrounded)
        {
            CanJump = true;
           
        }
       
        Rigidbody2D.velocity = new Vector2(InputX * runSpeed, Rigidbody2D.velocity.y);
      
        //ground check
        IsGrounded = Physics2D.OverlapBox(OnGroundCheck.position, checkRadius,0.0f, WhatIsGround);
        // IsGrounded = Physics2D.OverlapCircle(OnGroundCheck.position, checkRadius, WhatIsGround);//*CircleCollider

        //sprite flashing 
        if (WingsEnabled == true)
        {
            RightWingSprite.enabled = true;
            LeftWingSprite.enabled = true;
            FlyEffect = true;
        }
        else if (WingsEnabled == false)
        {
            RightWingSprite.enabled = false;
            LeftWingSprite.enabled = false;
            FlyEffect = false;
            FlyEffectTime = 0;
        }
        if (FlyEffect == true)
        {
            FlyEffectTime+=0.1f;
            if (FlyEffectTime >= 40)
            {
                SpriteBlinkingEffect();
            }
            if (FlyEffectTime >= 50)
            {
                WingsEnabled = false;
            }
        }

        //effect
        if (StunsValue == 0)
        {
            if (gameObject.name == "Player1")
            {
                GetStun = false;
                Stuns[0].enabled = false;
                Stuns[1].enabled = false;
                Stuns[2].enabled = false;
                Tag.color = Color.red;
            }
            if (gameObject.name == "Player2")
            {
                GetStun = false;
                Stuns[0].enabled = false;
                Stuns[1].enabled = false;
                Stuns[2].enabled = false;
                Tag.color = Color.blue;
            }
        }
        //respawn
        if (RespawnLeft>0&&RespawnValue == true)
        {
            RespawnTime += 0.1f;
            Respawn();
            StunsValue = 0;
            Immune = true;
        }
        if (RespawnTime > 5.0f)
        {
            Rigidbody2D.gravityScale = 1;
            RespawnValue = false;
            RespawnTime = 0;
            WingsEnabled = true;
            Immune = true;
        }
        if (Immune == true)
        {
            ImmuneTime += 0.1f;
        }
        if (ImmuneTime > 10.0f)
        {
            Immune = false;
            ImmuneTime = 0;
        }
        

    }
    //PLAYERMOVEMENT
    public void Move(InputAction.CallbackContext context)
    {
        if (GetStun == false)
        {
            InputX = context.ReadValue<Vector2>().x;
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {

        //jump
        if (GetStun == false)
        {
            if (context.performed && IsGrounded)
            {
                if (CanJump = true && JumpsValue == 0)
                {
                    Rigidbody2D.velocity = Vector2.up * JumpForce;
                    JumpsValue++;
                    Debug.Log(JumpsValue);
                }

            }
            if (context.performed && !IsGrounded)
            {

                if (CanJump == true && JumpsValue == 0)
                {
                    Rigidbody2D.velocity = Vector2.up * JumpForce;
                    JumpsValue++;
                    Debug.Log(JumpsValue);
                }
                else if (CanJump == true && JumpsValue < extraJumpsValue)
                {
                    Rigidbody2D.velocity = Vector2.up * JumpForce;
                    JumpsValue++;
                    Debug.Log(JumpsValue);

                }
            }
            if (JumpsValue >= extraJumpsValue)
            {
                CanJump = false;
                JumpsValue = 0;

            }
            if (!context.performed && IsGrounded)
            {
                JumpsValue = 0;
            }

            //Wings

            if (FlyEffect == true)
            {

                //PC
                //if (Application.platform == RuntimePlatform.WindowsPlayer)
                //{

                Rigidbody2D.velocity = Vector2.up * JumpForce;
                RightWingSprite.GetComponent<Animator>().Play("WingAnim");
                LeftWingSprite.GetComponent<Animator>().Play("WingAnim");

                // }
                //MOBILE
                //if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
                //{

                //    Rigidbody2D.velocity = Vector2.up * JumpForce;
                //    RightWingSprite.GetComponent<Animator>().Play("WingAnim");
                //    LeftWingSprite.GetComponent<Animator>().Play("WingAnim");

                //}
                //if (Input.GetKeyDown(KeyCode.DownArrow))
                //{

                //    WingsEnabled = false;
                //    extraJumps = extraJumpsValue;
                //}
            }

        }
    }

    ////////////////
    void Player1IsDead()
    {
        GameObject ExplodeParticleClone = Instantiate(PlayerExplodePrefab, transform.position, Quaternion.identity);

        Destroy(ExplodeParticleClone, 2.0f);
        RespawnValue = true;
        RespawnLeft--;


        if (RespawnLeft == 0)
        {
            RespawnValue = false;

           // SceneManager.LoadScene("BlueWins");
            SceneManager.LoadScene("Menu");
        }
    }
    void Player2IsDead()
    {
        GameObject ExplodeParticleClone = Instantiate(PlayerExplodePrefab, transform.position, Quaternion.identity);

        Destroy(ExplodeParticleClone, 2.0f);
        RespawnValue = true;
        RespawnLeft--;


        if (RespawnLeft == 0)
        {
            RespawnValue = false;
           // SceneManager.LoadScene("RedWins");
            SceneManager.LoadScene("Menu");

        }
    }

    void Respawn()
    {
        if (gameObject.name == "Player1")
        {
            gameObject.transform.position = new Vector3(0f, 7.44f, 0);

        }
        if (gameObject.name == "Player2")
        {
            gameObject.transform.position = new Vector3(-2.0f, 7.44f, 0);

        }
        Rigidbody2D.gravityScale = -1;

    }
    private IEnumerator StunTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StunsValue = 0;
        SendMessage("NotStunned", SendMessageOptions.DontRequireReceiver);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Wing(Clone)")
        {
            WingsEnabled = true;
            Destroy(other.gameObject);
            
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Immune == false)
        {
            if (other.gameObject.tag == "Bullet")
            {
                //Vector2 difference = (transform.position - other.transform.position).normalized;
                //Vector2 force = difference * knockbackForce;
                //Rigidbody2D.AddForce(force*5,ForceMode2D.Force); //if you don't want to take into consideration enemy's mass then use ForceMode.VelocityChange
                //Destroy(other.gameObject);

                Debug.Log("REDHIT");

                StunsValue++;

                if (StunsValue == 1)
                {
                    Stuns[0].enabled = true;
                    Stuns[1].enabled = false;
                    Stuns[2].enabled = false;
                }
                if (StunsValue == 2)
                {
                    Stuns[0].enabled = true;
                    Stuns[1].enabled = true;
                    Stuns[2].enabled = false;
                }
                if (StunsValue == 3)
                {
                    Stuns[0].enabled = true;
                    Stuns[1].enabled = true;
                    Stuns[2].enabled = true;
                }
                if (StunsValue == 4)
                {
                    GetStun = true;
                    Stuns[0].enabled = false;
                    Stuns[1].enabled = false;
                    Stuns[2].enabled = false;
                    Tag.color = Color.black;
                    StartCoroutine(StunTime(3.5f));
                    SendMessage("GetStunned", SendMessageOptions.DontRequireReceiver);
                }


            }
        }
        
    }
    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            spriteBlinkingTotalTimer = 0.0f;
            RightWingSprite.gameObject.GetComponent<SpriteRenderer>().enabled = true; 
            LeftWingSprite.gameObject.GetComponent<SpriteRenderer>().enabled = true;  
                                                                                      
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (RightWingSprite.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                RightWingSprite.gameObject.GetComponent<SpriteRenderer>().enabled = false; 
                 
            }
            else
            {
                RightWingSprite.gameObject.GetComponent<SpriteRenderer>().enabled = true;  
                
            }
            if (LeftWingSprite.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                LeftWingSprite.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                LeftWingSprite.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
   
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
       
        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        Gizmos.DrawWireCube(OnGroundCheck.position, checkRadius);
    }
   
}
