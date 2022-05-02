using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Entity
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        
        if (transform.parent.position.x > 0) speed *= (-1);
             
        Vector2 vectorMove = new Vector2(speed, 0f);

        rb.velocity = vectorMove;
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
