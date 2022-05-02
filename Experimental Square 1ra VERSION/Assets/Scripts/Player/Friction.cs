using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    [SerializeField] private float friction;

    private GroundDetection groundDetection;
    private Rigidbody2D rb;
    
    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
       groundDetection = this.GetComponent<GroundDetection>();
    }
    
    private void FixedUpdate()
    {
        FrictionApply();
    }
    
    private void FrictionApply()

    {
         if(groundDetection.IsGround()) 
        {
            Vector2 fixedVelocity = rb.velocity;
            fixedVelocity.x *= friction;

            rb.velocity = fixedVelocity;
        }
    }

   
}
