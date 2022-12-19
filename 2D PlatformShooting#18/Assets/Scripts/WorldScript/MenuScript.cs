using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public SpriteRenderer BoxWar;
  
    public void StartGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene("Main");
        }
    }
 
}
