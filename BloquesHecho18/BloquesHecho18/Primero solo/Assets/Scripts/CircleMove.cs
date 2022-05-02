using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    public float speedX = 10f;
    public float jumpForce = 200f;

    private bool canJump = true;
   
    Rigidbody2D rb2D;    
    
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float posX = transform.position.x + (horizontalMove. * speedX * Time.deltaTime);
        /*
        float jump = Input.GetAxisRaw("Jump");
        float posY = transform.position.y + (jump * speedY * Time.deltaTime);

        transform.position = new Vector2(posX, posY);
        */
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            rb2D.AddForce(transform.up * jumpForce);
            
        }

        
        transform.position = new Vector2(posX, transform.position.y);

    }
}
