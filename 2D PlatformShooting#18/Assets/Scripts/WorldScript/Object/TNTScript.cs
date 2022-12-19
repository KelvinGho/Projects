using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTScript : MonoBehaviour
{
    public float fieldOfImpact;

    public LayerMask layerToHit;

    public GameObject TNTDestroyedPS;

    public bool BombExplode = false;
    [SerializeField] private float speed = 2.5f;
   

    void Update()
    {
        if (BombExplode == true)
        {
            Explode();
        }
    }


    void TNTDestroyed()
    {

        GameObject TNTPSClone = Instantiate(TNTDestroyedPS, transform.position, Quaternion.identity);
        Destroy(TNTPSClone,2.0f);
        BombExplode = true;
        StartCoroutine(ExplodeTime(0.1f));
        
    }
    void Explode()
    {
       Collider2D[] objects=Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);

        foreach(Collider2D obj in objects)
        {
            Destroy(obj.gameObject);
            Debug.Log("HIT");
        }
    }
    private IEnumerator ExplodeTime(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        Destroy(gameObject);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.position += Vector3.left * speed * Time.fixedDeltaTime;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode

        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        Gizmos.DrawWireSphere(transform.position,fieldOfImpact);
    }
}
