using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class EndingScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
