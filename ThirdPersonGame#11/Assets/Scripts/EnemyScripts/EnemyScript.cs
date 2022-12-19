using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    private Animator myAnim;
    private NavMeshAgent nma = null;

    //health
    public float health;
    public float DeadDelay; //enemy before it gone
    private float oldHealth;
    private float MaxDamage = 0;

    //damage
    public float Damage;

    //nav
    public GameObject BaseTarget;
    public GameObject PlayerTarget;

    //move    
    private float MaxSpeed;
    
    //stats
    private bool TookDamage;
    private bool IsDead;
    private bool ChangeTarget;
    
  
    

    // Start is called before the first frame update
    void Start()
    {

        //nma
        myAnim = GetComponent<Animator>();
        nma = GetComponent<NavMeshAgent>();
        BaseTarget = GameObject.FindGameObjectWithTag("Base");
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        ChangeTarget = false;


        //health                
        oldHealth = health;

        //stats
        DeadDelay = 0.5f;
        TookDamage = false;
        IsDead = false;
        MaxSpeed = nma.speed;

    }
   
    // Update is called once per frame
    void Update()
    {
        if (IsDead == false)
        {
           
            WalkAction();
        }
        if (TookDamage == true)
        {
           
            nma.speed+= 0.1f;
            if (nma.speed > MaxSpeed)
            {
              nma.speed = MaxSpeed;
            }         
          
        }
        

    }
    void WalkAction()//enemy walking
    {

        myAnim.SetBool("Walk Forward", true);
        if (ChangeTarget == false)
        {
            nma.destination=BaseTarget.transform.position;
        }
        else if(ChangeTarget==true)
        {
            nma.destination = PlayerTarget.transform.position;
            
        }
        //transform.LookAt(PlayerTarget);
        //Quaternion targetRotation = Quaternion.LookRotation(Target.transform.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

        //    transform.position += transform.forward * speed * Time.deltaTime;
        //transform.localPosition = new Vector3(transform.localPosition.x, -0.5f, transform.localPosition.z);
        //transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
    public void TakeDamage(float amount)//enemy take damage
    {
        //speed = 0;       
        nma.speed = 0;
           
        health -= amount;
        MaxDamage += amount;
        if (IsDead == false)
        {
            TookDamage = true;
            ChangeTarget = true;
            myAnim.Play("Take Damage");
        }
        if (health <= 0 && MaxDamage==oldHealth)
        {
            Die();
            TookDamage = false;

        }
    }
    void OnTriggerStay(Collider other){
       if(other.gameObject==BaseTarget||other.gameObject==PlayerTarget)
       {
        myAnim.Play("Stab Attack");
        
        BaseBehaviour target=transform.GetComponent<BaseBehaviour>();
        if (target != null)
            {
                target.BaseTakeDamage(Damage);
            }
       }
    }
    void Die()
    {
        IsDead = true;
        if (IsDead == true)
        {
            nma.isStopped = true;
            nma.speed = 0;
            SendMessage("IsDead",SendMessageOptions.DontRequireReceiver);
            myAnim.Play("Die");

            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + DeadDelay);
        }
        
    }

    
  
}

