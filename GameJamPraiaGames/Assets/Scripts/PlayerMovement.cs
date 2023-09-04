using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public Rigidbody2D rb;
    private Vector2 moveDir;
    private Vector2 smoothInputVelocity;
    [SerializeField]
    
    private float smoothInputSpeed;

    private bool facingLeft = false;
    // Update is called once per frame
    private bool isDead = false;
    
    void Start()
    {
        InteractionSystem.OnPlayerDead += IsDead;
    }



    void Update()
    {
        if(isDead == false)
        {

            ProcessInputs();
        }

    }

    void  FixedUpdate()
    {
        if(isDead == false)
        {
            Move();

        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        UnityEngine.Vector2 input = new UnityEngine.Vector2(moveX,moveY);

        moveDir = Vector2.SmoothDamp(moveDir, input, ref smoothInputVelocity, smoothInputSpeed);
        

        if(moveX != 0 || moveY != 0)
            animator.SetBool("moving", true);
        else
            animator.SetBool("moving", false);

        if(moveX > 0 && !facingLeft)
        {
            Flip();
        }
        if(moveX < 0 && facingLeft)
        {
            Flip();
        }
        
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);

    }

    void Flip()
    {
        UnityEngine.Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }


    public void IsDead()
    {
        isDead = true;
        moveDir = new Vector2(0,0);
        rb.velocity = new Vector2(0,0);
    }


}
