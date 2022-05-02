using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    // MOVIMIENTO
    public Vector2[] randomDir = new Vector2[3];
    public float speed;

    // ROTACION
    private float rotationDir;

    // REFERENCIAS
    private Rigidbody2D rb;
    public ParticleSystem explosionEffect;
   
    
    private void Awake() { 
        
        rb = GetComponent<Rigidbody2D>(); 
        
    }

    void Start()
    {
       Move(speed);
       rotationDir = Random.Range(-1f, 1.01f);
    }

    void Update()
    {
        
    }

    private void FixedUpdate() {
        Rotation(rotationDir);
    }

    private void Move(float speed){
        float[] changeDirection = {-1, 1};
        float randomChange = changeDirection[Random.Range(0, changeDirection.Length)];

        rb.AddForce(randomDir[Random.Range(0,randomDir.Length)] * speed * randomChange);
    }

    private void Rotation(float dirAndSpeed){
        rb.angularVelocity = 200f * dirAndSpeed;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Bullet"){
            ParticleSystem effect = Instantiate(explosionEffect, transform.position,transform.rotation) as ParticleSystem;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
