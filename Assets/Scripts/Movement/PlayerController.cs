using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Dash")]
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;
    private bool isDashing;
    private bool canDash = true;

    [Header("Movement")]
    public float speed = 5f;
    public float jumpPower = 12f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireCooldown = 0.2f;

    private float nextFireTime;

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
    //strzał
    private void Shoot()
    {
        //tworzenie objektu + kierunek z klasy Bullet
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity);

        float direction = isFacingRight ? 1f : -1f;

        bullet.GetComponent<Bullet>().SetDirection(direction);
    }

    //dash czytanie
    private void Update()
    {
        // dash input
        if (Keyboard.current.leftShiftKey.wasPressedThisFrame
            && canDash
            && !isDashing)
        {
            StartCoroutine(Dash());
        }

        // strzał input
        if (Keyboard.current.fKey.wasPressedThisFrame
            && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
            return;
        //ruch
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

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        float direction = isFacingRight ? 1f : -1f;

        rb2d.linearVelocity = new Vector2(direction * dashSpeed, 0f);

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}
