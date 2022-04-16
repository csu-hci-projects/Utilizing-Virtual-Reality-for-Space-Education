using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class WristMenu : MonoBehaviour
{
    public GameObject wristUI;
    public bool activeWrist = false;

    // Start is called before the first frame update
    void Start()
    {
        displayWristUI();
    }

    // system to run the wrist ui buttons
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
    public void RestartGame()
    {
        Debug.Log("Restart Game");
    }
    
    // creates the wrapper to tie in input system
    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)   
        {
            displayWristUI();
        }
    }

    public void displayWristUI()
    {
        if(activeWrist)
        {
            wristUI.SetActive(true);
            activeWrist = false;
        }
        else if (!activeWrist)
        {
            wristUI.SetActive(false);
            activeWrist = true;
        }
    }
}
