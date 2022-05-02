using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    // REFERENCIAS
    private Rigidbody2D rb;
    public Camera cam;

    // MOVIMIENTO
    private float inputX;
    private float inputY;
    
    public float aceleration; 
    public float recoilSpeed;    
    public float maxSpeed;
    private float currentSpeed;
    private bool isMove;
    
    
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
            
    }
    
    private void Start() {
    
    }
    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        
        if(inputX != 0 || inputY != 0){
            isMove = true;   
        }
    }

    private void FixedUpdate() {
        if(isMove)  Move();       
                    Rotation();
    }

    private void Move(){
        if(currentSpeed < maxSpeed){
            currentSpeed += aceleration;

        }else if(currentSpeed >= maxSpeed){
            currentSpeed = maxSpeed;
        }

        if(!isMove){
            currentSpeed -= aceleration;    
        } else if(currentSpeed <= 0){
            rb.velocity = Vector2.zero;
        }
        Vector2 verMove = (Vector2.up * inputY);
        Vector2 horMove = (Vector2.right * inputX);
        rb.velocity = new Vector2(horMove.x, verMove.y).normalized * currentSpeed; 
    }
   

    private void Rotation(){
        Vector3 worldMouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDirection = worldMouse - transform.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.SetRotation(angle-90f); 
    }
}
