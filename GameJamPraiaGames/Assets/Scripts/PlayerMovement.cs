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
    private float elapsedTime;
    private Vector2 smoothInputVelocity;
    [SerializeField]
    
    private float smoothInputSpeed;

    private bool facingLeft = false;
    // Update is called once per frame
    public GameObject aura;
    void Start(){
        aura = transform.Find("Aura").gameObject;
    }
    void Update()
    {
        ProcessInputs();

    }

    void  FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        UnityEngine.Vector2 input = new UnityEngine.Vector2(moveX,moveY);
        moveDir = Vector2.SmoothDamp(moveDir, input, ref smoothInputVelocity, smoothInputSpeed);

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
        //Unflip Aura
        UnityEngine.Vector3 auraScale = aura.transform.localScale;
        auraScale.x *= -1;
        aura.transform.localScale = auraScale;
        facingLeft = !facingLeft;
    }
}
