using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GunScript : MonoBehaviour
{
    
    //JoyStick
   
    
    //Bullet
    [Space]
    [Header("Bullet")]
   
    public GameObject Bullet;
    public Transform Muzzle;
    public GameObject MuzzleFlash;
    
    public float FireRate;//Need Check
    float CooldownTime;   //Need Check

    private bool GetStun = false;
    
    void Update()
    {

        //PCBulletShooting
        //if (Application.platform == RuntimePlatform.WindowsPlayer)
        //{
        //if (Input.GetMouseButtonDown(0))
        //{
        //   

        //}
    //}

    }
    public void Fire(InputAction.CallbackContext context)
    {
        if (GetStun == false)
        {
            if (context.performed)
            {
                if (Time.time > CooldownTime)
                {
                    CooldownTime = Time.time + 1 / FireRate;
                    MuzzleFlash.SetActive(true);

                    GameObject BulletClone = Instantiate(Bullet, Muzzle.position, Muzzle.rotation);
                    StartCoroutine(MuzzleOff());
                }
            }
        }
    }

  void GetStunned()
  {
    GetStun = true;    
  }
  void NotStunned()
  {
    GetStun = false;
  }
  IEnumerator MuzzleOff()   
  {
        
        yield return new WaitForSeconds(0.1f);
        MuzzleFlash.SetActive(false);

  }
   
}
