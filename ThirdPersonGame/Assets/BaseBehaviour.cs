using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{   
    //Base Health
    public float BaseHealth;
    private float oldHealth;
    private float MaxDamage = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        oldHealth = BaseHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BaseTakeDamage(float amount)//Base take damage
    {
        BaseHealth -= amount;
        MaxDamage += amount;
        Debug.Log("BASE/LOSE!!");
        if (BaseHealth <= 0 && MaxDamage >= oldHealth)
        {
            Debug.Log("BASE/LOSE!!");
            //Lose;
           
        }
    }
}
