using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDir;
    private float elapsedTime;
    private Vector2 smoothInputVelocity;
    [SerializeField]
    
    private float smoothInputSpeed;
    // Update is called once per frame
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
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}
