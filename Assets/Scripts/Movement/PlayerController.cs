using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private InputActionReference dashAction;
    [SerializeField] private InputActionReference shootAction;

    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 12f;

    [Header("Dash")]
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 2f;

    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireCooldown = 0.2f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb2d;
    private Vector2 moveInput;
    private bool isFacingRight = true;
    private bool jumpRequested;
    private bool isDashing;
    private bool canDash = true;
    private float nextFireTime;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        dashAction.action.Enable();
        shootAction.action.Enable();

        jumpAction.action.performed += OnJump;
        dashAction.action.performed += OnDash;
    }

    private void OnDisable()
    {
        jumpAction.action.performed -= OnJump;
        dashAction.action.performed -= OnDash;

        moveAction.action.Disable();
        jumpAction.action.Disable();
        dashAction.action.Disable();
        shootAction.action.Disable();
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        jumpRequested = true;
    }

    private void OnDash(InputAction.CallbackContext ctx)
    {
        if (canDash && !isDashing)
            StartCoroutine(DashRoutine());
    }

    private void Update()
    {
        // ruch co klatkę
        moveInput = moveAction.action.ReadValue<Vector2>();

        // strzał
        if (shootAction.action.IsPressed() && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }

        FlipDirection();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            jumpRequested = false;
            return;
        }

        rb2d.linearVelocity = new Vector2(moveInput.x * speed, rb2d.linearVelocity.y);

        if (jumpRequested && IsGrounded())
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpPower);

        jumpRequested = false;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void FlipDirection()
    {
        if (moveInput.x > 0.01f && !isFacingRight)
        {
            isFacingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < -0.01f && isFacingRight)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(isFacingRight ? 1f : -1f);
    }

    private IEnumerator DashRoutine()
    {
        canDash = false;
        isDashing = true;

        float direction = isFacingRight ? 1f : -1f;
        float originalGravity = rb2d.gravityScale;
        rb2d.gravityScale = 0f;
        rb2d.linearVelocity = new Vector2(direction * dashSpeed, 0f);

        yield return new WaitForSeconds(dashDuration);

        rb2d.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}