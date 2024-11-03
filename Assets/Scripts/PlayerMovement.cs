using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public float moveSpeed = 12f;         // Player movement speed
    public float jumpForce = 15f;         // Jump force
    public float turnSpeed = 10f;         // Speed for turning
    public float gravityMultiplier = 50f; // Extra gravity multiplier
    public Transform cameraTransform;     // Reference to the camera's transform
    private bool isGrounded = true;       // Checks if player is grounded
    private bool jumpRequested = false;   // Flag for requesting a jump
    private Vector3 moveDirection;        // To store the movement direction

    public LayerMask groundLayer;

    void Start()
    {
        if (animator == null) {

            animator = GetComponent<Animator>();

        }

        if (rb == null) {

            rb = GetComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;  // Enable interpolation to reduce jitter

        }

        if (cameraTransform == null) {

            cameraTransform = Camera.main.transform;  // Use the main camera if none is assigned

        }
    }

    void Update() 
    {
        // Input check for jumping, handled in Update but executed in FixedUpdate
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {

            Debug.Log("Jump requested");
            jumpRequested = true;  // Set jump request flag

        }

        //check grounded status
        RaycastHit groundhit;
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, out groundhit, 1.0f, groundLayer))
        {
            isGrounded = true;
            Debug.Log("Player is grounded");
        }
        else
        {
            isGrounded = false;
            Debug.Log("Player is not grounded");
        }

        // Movement input
        float moveX = Input.GetAxisRaw("Horizontal"); // Left-right movement
        float moveZ = Input.GetAxisRaw("Vertical");   // Forward-back movement

        // Get the camera's forward and right directions, ignoring the Y component for forward direction
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f; // Ignore vertical camera tilt
        cameraForward.Normalize();

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0f; // Ignore vertical camera tilt
        cameraRight.Normalize();

        // Calculate movement direction relative to the camera
        moveDirection = (cameraForward * moveZ + cameraRight * moveX).normalized;

        // Check if the character is walking
        bool isWalking = moveDirection.magnitude > 0;
        animator.SetBool("isWalking", isWalking);  // Update walking animation

        // This following block of raycast code was aided by ChatGPT to fix an issue I had with the character not respecting collision boxes and physics
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, moveDirection, out hit, 1f)) {

            if (hit.collider.tag == "Wall") {

                // Prevent movement if a wall is detected in the direction of movement
                return;

            }
        }
    }

    void FixedUpdate() {

        // Handle movement in FixedUpdate to sync with physics
        if (moveDirection.magnitude > 0) {

            Vector3 movement = moveDirection * moveSpeed;
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);  // Use fixedDeltaTime for physics consistency

            // Rotate the player towards movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection) * Quaternion.Euler(0, 180f, 0);; // The Quaternion.Euler component is meant to fix an issue where my character, when exported from Blender, was facing the wrong direction
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime));

        }

        if (!isGrounded) {

            rb.AddForce(Vector3.down * gravityMultiplier, ForceMode.Acceleration);  // Apply extra gravity

        }

        // Handle jump request
        if (jumpRequested && isGrounded) {

            Debug.Log("Jump executed");
            Jump();  // Execute the jump
            jumpRequested = false;  // Reset the jump request flag

        }
    }

    void Jump() {

        // Trigger jump animation and apply force
        Debug.Log("Applying jump force");
        animator.SetTrigger("isJumping");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //isGrounded = false;

    }

    private void OnCollisionEnter(Collision collision) {

        // Check if the collision normal is upwards (indicating the player is on a surface)
        foreach (ContactPoint contact in collision.contacts) {
            
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f) { // Check if the normal is mostly upward

                Debug.Log("Collision with surface. Grounded = true.");
                //isGrounded = true;
                return;

            }
        }
    }

    private void OnCollisionExit(Collision collision) {

        // Reset grounded flag when leaving any surface
        Debug.Log("Left the surface. Grounded = false.");
        //isGrounded = false;
        
    }
}
