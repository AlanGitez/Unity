using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float speed;

    private float inputX, inputY;
    private bool isMove;
    
    private Rigidbody2D rb;
    private Animator anim;

   private void Awake() {
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
   }

    void Start()
    {
        
    }

    private void Update() {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

    }

    
    void FixedUpdate()
    {
        Move();
        

    }

    private void LateUpdate() {
        anim.SetFloat("moveX", inputX);
        anim.SetFloat("moveY", inputY);
    }

    private void Move(){
        float moveX = inputX * speed;
        float moveY = inputY * speed;

        rb.velocity = new Vector2(moveX, moveY);
    }
}
