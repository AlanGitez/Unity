using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Camera cam;


    public float speed;


    private void Awake()
    {


        rb = GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        PlayerRotation();
    }

    private void FixedUpdate()
    {
        Movement();
    }


    private void Movement()
    {

        float HInput = Input.GetAxisRaw("Horizontal");
        float VInput = Input.GetAxisRaw("Vertical");

        Vector2 velocity = new Vector2(HInput * speed, VInput * speed);

        if (HInput != 0 || VInput != 0)
        {

            rb.velocity = velocity;
        }
        else rb.velocity = Vector2.zero;

    }

    private void PlayerRotation()
    {

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float angle = AngleBetweenPoints.AngleCalculate(mousePos, rb.transform.position);

        rb.rotation = AngleBetweenPoints.AngleCalculate(mousePos, rb.transform.position);

    }
}
