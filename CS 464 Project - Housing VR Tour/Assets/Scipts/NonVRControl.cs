using UnityEngine;

[RequireComponent(typeof(CharacterController))] // SCRIPT DOES NOT RUN WITHOUT "CHARACTERCONTROLLER"
public class NonVRControl : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    // keep track of camera transform
    private Transform cameraTransform;

    private InputManager inputManager;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;    // get camera transform value
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // create ONE instance of inputManager to store so not called everytime
        Vector2 movement = inputManager.GetPlayerMovement();
        // move character
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;    // consider camera facing direction
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        //if (move != vector3.zero)
        //{
        //    gameobject.transform.forward = move;
        //}

        // Changes the height position of the player..
        if (inputManager.Jump() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}