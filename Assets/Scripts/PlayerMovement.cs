using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Transform otherObject;
    [SerializeField] float moveingSpeed;
    [SerializeField] float jumpingPower;
    private Vector2 vector2;
    [SerializeField] InputActionReference moveRef;
    [SerializeField] InputActionReference jumpRef;
    private Animator animator;
    private bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    AudioManager audioManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        moveRef.action.Enable();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        vector2 = moveRef.action.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        movePlayer();
        moveAnimation();
    }
    private void OnEnable()
    {
        jumpRef.action.Enable();
        jumpRef.action.started += Jump;
    }
    private void OnDisable() {
        jumpRef.action.started -= Jump;
    }
    private bool playerIsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.2f),
                                       CapsuleDirection2D.Vertical, 0, groundLayer);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        isGrounded = playerIsGrounded();
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            audioManager.playSFX(audioManager.jump);
        }
    }

    private void moveAnimation()
    {
        if (vector2 != Vector2.zero)
        {
            animator.SetFloat("moveX", vector2.x);
        }
        animator.SetBool("isRunning", rb.linearVelocity.magnitude > 0);
    }

    private void movePlayer()
    {
    
        rb.linearVelocity = new Vector2(vector2.x * moveingSpeed, rb.linearVelocity.y);
        if (transform.position.x > otherObject.transform.position.x && vector2.x > 0)
        {
            otherObject.position += new Vector3(vector2.x * moveingSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
