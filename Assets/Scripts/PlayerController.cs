using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for player movement
public class PlayerController : MonoBehaviour
{
    // Input action object
    private Player playerInput;
    // Character Controller object
    private CharacterController controller;
    // Player Vector3 velocity
    private Vector3 playerVelocity;
    // Bool to check if player is on ground
    // Used if implementing jumping animation
    private bool groundedPlayer;
    // Camera Transform value
    private Transform cameraMain;
    // Child object from player
    private Transform child;

    // Set player movement speed
    [SerializeField]
    private float playerSpeed = 2.0f;
    // Set gravity value
    [SerializeField]
    private float gravityValue = -9.81f;
    // Set camera object rotation speed
    // [SerializeField]
    // private float rotationSpeed = 4;

    // On awake get Input Action object and Character Controller
    private void Awake()
    {
        playerInput = new Player();
        controller = GetComponent<CharacterController>();
    }

    // When enabled activate player input
    private void OnEnable()
    {
        playerInput.Enable();
    }

    // When disabled diactivate player input
    private void OnDisable()
    {
        playerInput.Disable();
    }


    // On start initialized main camera object transform and child object
    private void Start()
    {
        cameraMain = Camera.main.transform;
        child = transform.GetChild(0).transform;
    }

    void Update()
    {
        // Check if player is on Ground
        groundedPlayer = controller.isGrounded;
        // If player on ground and not jumping set y velocity to 0
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Get Vector2 data from player input on move method in input action
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        // Set player movement to go with camera forward direction
        Vector3 move = (cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x);
        // Set vector y movement to 0
        move.y = 0f;
        // Initialize movement to character controller
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Make sure that the player object move forward
         if (move != Vector3.zero)
         {
            gameObject.transform.forward = move;
         }
        
        // If player jump, add gravity to pull down to ground
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        /*
        if(movementInput != Vector2.zero)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(child.localEulerAngles.x, cameraMain.localEulerAngles.y, child.localEulerAngles.z));
            child.rotation = Quaternion.Lerp(child.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
        */
    }
}
