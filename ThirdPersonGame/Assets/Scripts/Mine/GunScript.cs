using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform hand;
    public float damage = 10;
    public float range = 100f;

    public float FireRate;
    private float nextTimeToFire = 0f;
    // public float impactforce=30.0f;
    // public Transform muzzle;
    bool ChangeFireRate = false;
    bool fired;

    public ParticleSystem muzzleflash;

    public AudioSource ShootAudio;
    public Camera TpsCam;
    
    public GameObject ImpactEffect;
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(hand);
           
    }

    // Update is called once per frame
    void Update()
    {
     
        if (ChangeFireRate == false)
        {
            if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && Input.GetMouseButton(1)&&Time.time>=nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / FireRate; 
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeFireRate = !ChangeFireRate;
            Debug.Log(ChangeFireRate);
        }
       
    }

    void Shoot()
    {

        muzzleflash.Play();
        ShootAudio.Play();
        RaycastHit hit;
        if(Physics.Raycast(TpsCam.transform.position,TpsCam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);

            EnemyScript target=  hit.transform.GetComponent<EnemyScript>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            //if(hit.rigidbody!=null)
            //{
            //    hit.rigidbody.AddForce(hit.normal * impactforce);
            //}


           GameObject ImpactGO= Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGO, 2f);
        }
        
    }

}
