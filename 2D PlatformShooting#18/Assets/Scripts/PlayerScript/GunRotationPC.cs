using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotationPC : MonoBehaviour
{
    //Gun And Player Dir
    Vector2 direction;
    public Transform Gun;
    private bool FacingRight = true;


    // Update is called once per frame
    void Update()
    {
        //PC

        //cursor Flip Player
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;

        if (direction.x >= 0 && !FacingRight)
        { // mouse is on Left side of player to the right

            Flip();


        }
        else if (direction.x < 0 && FacingRight)
        { // mouse is on Right side to the left

            Flip();
        }

        //gun follow cursor
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;


        Gun.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {

            //if (FacingRight)//right
            //{


            //    Gun.transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);


            //}
            //else
            if (!FacingRight)//left
            {


                Gun.transform.localRotation = Quaternion.Euler(180, -180, -rotationZ);

            }

        }

    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;
        // Multiply the player's x local scale by -1.
        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;.
        transform.Rotate(0, 180, 0);

    }
}
