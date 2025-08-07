using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed of the player movement
    [SerializeField] private float jumpForce = 10f; // Force applied when the player jumps
    [SerializeField] private LayerMask groundLayer; // Layer mask to identify ground objects
    [SerializeField] private Transform groundCheck; // Transform to check if the player is grounded
    private bool isGrounded; // Flag to check if the player is on the ground
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Animator animator; // Reference to the Animator component for animations
    private GameManager gameManager; // Reference to the GameManager script            
    private AudioManager audioManager; // Reference to the AudioManager script
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManager>(); // Find the GameManager in the scene
        audioManager = FindAnyObjectByType<AudioManager>(); // Find the AudioManager in the scene
    }
    

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver() || gameManager.IsGameWin()) return; // If the game is over, skip player input handling
        HandleMovement();
        HandleJump();
        UpdateAnimation();

    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if(moveInput > 0) transform.localScale = new Vector3(5, 5, 5); // Face right
        else if(moveInput < 0) transform.localScale = new Vector3(-5, 5, 5); // Face left
    }
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audioManager.PlayJumpSound(); // Play jump sound using AudioManager
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f; 
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }
}
