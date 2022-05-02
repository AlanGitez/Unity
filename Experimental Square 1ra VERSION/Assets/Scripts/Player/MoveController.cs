
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveController : MonoBehaviour
{
    [SerializeField] private float impulseForce;
    [SerializeField] private float speed;
    private bool flying;
    private float hMove;

    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) flying = true;
        if(Input.GetMouseButtonUp(0)) flying = false;
        
        hMove = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        ClickImpulse();
        HorizontalMove();
    }

    private void ClickImpulse()
    {
        Vector2 impulseVector = new Vector2(rb.velocity.x, impulseForce);

        if (flying)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(impulseVector, ForceMode2D.Impulse);
        }
    }

    private void HorizontalMove()
    {  
        Vector2 horizontalVec = new Vector2(hMove * speed, rb.velocity.y);

        rb.velocity = horizontalVec;
    }
}
