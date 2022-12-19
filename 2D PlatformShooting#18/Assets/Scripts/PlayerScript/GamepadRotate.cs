using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadRotate : MonoBehaviour
{
    private Vector2 GPadRotate;
    public GameObject Gun;
    private float RotationZ;
    private float PlayerRotation;
    public bool FacingRight = true;

    private bool GetStun = false;
    // Start is called before the first frame update
   
    public void Rotate(InputAction.CallbackContext Context)
    {
        if (GetStun == false)
        {
            GPadRotate = Context.ReadValue<Vector2>();
            GPadRotate = new Vector2(GPadRotate.x, GPadRotate.y);

            PlayerRotation = GPadRotate.x;

            if (FacingRight)
            {
                //Rotates the object if the player is facing right
                RotationZ = GPadRotate.x + GPadRotate.y * 90;
                Gun.transform.rotation = Quaternion.Euler(0f, 0f, RotationZ);
            }
            else
            {
                //Rotates the object if the player is facing left
                RotationZ = GPadRotate.x + GPadRotate.y * -90;
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
    }
    private void Flip()
    {
        // Flips the player.
        FacingRight = !FacingRight;

        transform.Rotate(0, 180, 0);
    }
    void GetStunned()
    {
        GetStun = true;
    }
    void NotStunned()
    {
        GetStun = false;
    }
}
