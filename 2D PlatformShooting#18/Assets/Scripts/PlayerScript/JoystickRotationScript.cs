using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickRotationScript : MonoBehaviour
{
    public Joystick joystick;
    public GameObject Gun;
    Vector2 JoystickRotate;
    private float RotationZ;
    private float PlayerRotation;

    public bool FacingRight = true;

    void Update()
    {
        //Gets the input from the jostick
       JoystickRotate = new Vector2(joystick.Horizontal, joystick.Vertical);

        PlayerRotation = JoystickRotate.x;

        if (FacingRight)
        {
            //Rotates the object if the player is facing right
           RotationZ = JoystickRotate.x + JoystickRotate.y * 90;
           Gun.transform.rotation = Quaternion.Euler(0f, 0f, RotationZ);
        }
        else
        {
            //Rotates the object if the player is facing left
            RotationZ = JoystickRotate.x + JoystickRotate.y * -90;
           Gun.transform.rotation = Quaternion.Euler(0f, 180f, -RotationZ);
        }
        if (PlayerRotation < 0 && FacingRight)
        {
            // Executes the void: Flip()
            Flip();
        }
        else if (PlayerRotation >= 0 && !FacingRight)
        {
            // Executes the void: Flip()
            Flip();
        }
    }
    private void Flip()
    {
        // Flips the player.
        FacingRight = !FacingRight;

        transform.Rotate(0, 180, 0);
    }
}