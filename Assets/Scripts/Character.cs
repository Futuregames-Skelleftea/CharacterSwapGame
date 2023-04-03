using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public abstract class Character : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    protected Rigidbody rb;
    protected bool isGrounded;

    private PlayerInput playerInput;
    public InputAction moveAction;
    private InputAction jumpAction;
    public InputAction moveLeftAction;
    public InputAction moveRightAction;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Get the PlayerInput component and set up the actions
        playerInput = GetComponent<PlayerInput>();
        moveLeftAction = playerInput.actions.FindAction("MoveLeft");
        moveRightAction = playerInput.actions.FindAction("MoveRight");
        jumpAction = playerInput.actions.FindAction("Jump");
    }
    internal float moveInput = 0;
    float MoveRight = 0;
    float MoveLeft = 0;
    public virtual void Update()
    {
        float moveRight = moveRightAction.ReadValue<float>();
        float moveLeft = moveLeftAction.ReadValue<float>();

        if (moveRight != MoveRight || moveLeft != MoveLeft)
        {
            MoveRight = moveRight;
            MoveLeft = moveLeft;
            SetMovement(MoveRight - MoveLeft);
        }
        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0f);

        if (isGrounded && jumpAction.triggered)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }
    public void SetMovement(float move)
    {
        moveInput = move;
        Debug.Log("Move: " + moveInput);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    public void JumpButton()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }

    public abstract void AbilityButton();
}

