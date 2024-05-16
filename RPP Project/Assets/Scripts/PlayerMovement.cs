using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpeed;
    public Rigidbody2D rb;
    private Vector2 movDirection;
    public bool canDash = true;
    public bool isDashing;
    public float dashPower;
    public float dashTime;
    public float dashCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        movDirection = new Vector2(inputX, inputY).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        Move();
    }
    void Move()
    {
        rb.velocity = new Vector2(movDirection.x * movSpeed, movDirection.y * movSpeed);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(movDirection.x * dashPower, movDirection.y * dashPower);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
