using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // keep track of class instance
    private static InputManager _instance;
    // return our instance when class called
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private PlayerInput inputs;

    private void Awake()
    {
        // create our singleton
        if (_instance != null && _instance != this)
        {   // If there's another instance
            Destroy(this.gameObject);
        }
        else
        {   // assign instance to this script
            _instance = this;
        }
        inputs = new PlayerInput();
        // Hide mouse cursor upon play
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    // helper functions
    public Vector2 GetPlayerMovement()
    {
        return inputs.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return inputs.Player.Look.ReadValue<Vector2>();
    }

    public bool Jump()
    {
        return inputs.Player.Jump.triggered;    // return true if triggered is press
    }
}
