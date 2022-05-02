using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public bool isDead;
    Rigidbody2D rb2d;
    public float upForce = 200f;
    Animator anim;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        anim.SetTrigger("Die");
        GameController.instance.BirdDie();
        rb2d.velocity = Vector2.zero;
    }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                // rb2d.AddForce(new Vector2(0, upForce)); opcion 1
                rb2d.AddForce(Vector2.up * upForce); // opcion 2, mas comprimida.
                anim.SetTrigger("Flap");
        
            }
        
    }

}

