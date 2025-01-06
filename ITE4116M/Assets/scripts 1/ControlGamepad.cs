using UnityEngine;
using UnityEngine.InputSystem;

public class ControlGamepad : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float runSpeedMultiplier = 2f;

    private Vector2 moveInput;
    private bool isRunning;
    private Rigidbody rb;

    private PlayerControls playerControls; // Reference to the generated InputActions class

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerControls = new PlayerControls(); // Create an instance of PlayerControls
    }

    private void OnEnable()
    {
        playerControls.Enable(); // Enable the input actions

        // Bind the move input action
        playerControls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Move.canceled += ctx => moveInput = Vector2.zero; // Stop movement when input is canceled

        // Bind the interact action
        playerControls.Player.Interact.performed += ctx => Interact();

        // Bind the run action
        playerControls.Player.Run.performed += ctx => isRunning = true;
        playerControls.Player.Run.canceled += ctx => isRunning = false;

        // Bind the menu action
        playerControls.Player.Menu.performed += ctx => OpenMenu();
    }

    private void OnDisable()
    {
        playerControls.Disable(); // Disable the input actions
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float speed = isRunning ? moveSpeed * runSpeedMultiplier : moveSpeed;
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void Interact()
    {
        Debug.Log("Interact button pressed!");
        // Interaction logic
    }

    private void OpenMenu()
    {
        Debug.Log("Menu button pressed!");
        // Menu logic
    }
}