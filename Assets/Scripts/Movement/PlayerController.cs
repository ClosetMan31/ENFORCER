using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float jumpPower = 12f;

    [Header("Components")]
    public Rigidbody2D rb2d;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Vector2 moveInput;
    private bool isFacingRight = true;
    private bool isJumpPressed;

    //ruch input
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    //skok input
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
            isJumpPressed = true;
    }

    private void FixedUpdate()
    {
        // ruch
        rb2d.linearVelocity = new Vector2(moveInput.x * speed, rb2d.linearVelocity.y);

        //skok
        if (isJumpPressed && IsGrounded())
        rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpPower);
       

        isJumpPressed = false;

        
        FlipDirection();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
    //zwrot kierunku l/p
    private void FlipDirection()
    {
        if (moveInput.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
