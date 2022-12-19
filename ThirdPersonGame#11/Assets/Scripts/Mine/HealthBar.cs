using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //base health
    public Image BaseHealthBar;
    public float BaseCurrentHealth;
    private float BaseMaxHealth=100;

    //player health
    public Image PlayerHealthBar;
    public float PlayerCurrentHealth;
    private float PlayerMaxHealth=100;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BaseHealthBar.fillAmount = BaseCurrentHealth/BaseMaxHealth;
        PlayerHealthBar.fillAmount=PlayerCurrentHealth/PlayerMaxHealth;
    }
     //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
    }

    
}
