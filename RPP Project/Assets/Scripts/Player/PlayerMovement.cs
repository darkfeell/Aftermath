using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpeed;
    public Rigidbody2D rb;
    private Vector2 movDirection;
    private Vector3 mousePosition;
    public bool canDash = true;
    public bool isDashing;
    public float dashPower;
    public float dashTime;
    public float dashCooldown;
    public Camera cam;
    public Animator anim;
    
    void Update()
    {
        
        
        
        
        if (isDashing)
        {
            return;
        }
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        movDirection = new Vector2(inputX, inputY).normalized;
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition); 

        if (Input.GetKeyDown(KeyCode.Space) && canDash && PauseMenu.isGamePaused == false)
        {
            StartCoroutine(Dash());
        }
    }
    void FixedUpdate()
    {
        Vector2 lookDirection = mousePosition - transform.position;
        float angle = (Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg) - 90f;
        rb.rotation = angle; 
        if (isDashing)
        {
            return;
        }
        Move();
        if(movDirection.x == 0 && movDirection.y == 0)
        {
            anim.SetBool("isWalking", false);
        }
    }
    void Move()
    {
        rb.velocity = new Vector2(movDirection.x * movSpeed, movDirection.y * movSpeed);
        anim.SetBool("isWalking", true);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(movDirection.x * dashPower, movDirection.y * dashPower);
        ParticleObserver.OnParticleSpawnEvent(transform.position);
        AudioObserver.OnPlaySfxEvent("dash");
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    void OnEnable()
    {
        GameManager.instance.SetMovScript(this);
    }
}
//