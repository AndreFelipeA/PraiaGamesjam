using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Vector2 smoothInputVelocity;
    [SerializeField]
    
    private float smoothInputSpeed;

    private bool facingLeft = false;
    // Update is called once per frame
    public bool isDead = false;

    public delegate void GameOver();
    public static event GameOver OnGameOver;
    
    private void Awake() {
        rb = this.GetComponent<Rigidbody2D>();
        
    }
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
        animator.SetBool("dying", true);
        StartCoroutine(EndGame());

    }

    IEnumerator EndGame()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        if(OnGameOver != null)
        {
            OnGameOver();
        }
    }

}
