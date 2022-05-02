using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 horMove;
    
    public float jumpForce = 4;
    /*
    private int jumpsMade;
    private int totalJumps = 2;
    */
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    private bool isGrounded;
   

    private Rigidbody2D rb2D;
    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        // MOVIMIENTO
        float movX = Input.GetAxisRaw("Horizontal");
        horMove = new Vector2(movX, 0f);      
  
        if (movX < 0)
        {
            sr.flipX = true;
            
        }
        else if (movX > 0) sr.flipX = false;

        // SALTO
        if (Input.GetButtonDown("Jump") && isGrounded == true)
         {   
             rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
         }
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void FixedUpdate()
    {
        float velocityX = horMove.normalized.x * speed;
        rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
    }
    private void LateUpdate()
    {
        anim.SetBool("idle", horMove == Vector2.zero);
        anim.SetFloat("velocityY", rb2D.velocity.y);
        anim.SetBool("grounded", isGrounded);
    }
  
}
