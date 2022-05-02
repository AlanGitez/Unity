using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Todas las balas tiene una fuerza de disparo.
    //Realizan cierto da�o.
    //Destruyen ciertos objetos.
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.isKinematic = true;


    }

    void FixedUpdate()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
