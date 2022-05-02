using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    private Vector3 direction;

    private Rigidbody2D rb;
    private Shooter shooter;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();   
    }

    private void Start() { 
        
        
        Shoot();
    }
   

    private void Shoot(){
        Vector3 aimPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (aimPoint - transform.position).normalized;

        if(aimPoint != Vector3.zero){
            //rb.velocity = (direction * bulletSpeed);
            rb.velocity = rb.transform.up * bulletSpeed; 
        }
    }


    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
