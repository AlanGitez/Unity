using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Entity
{
    
    [SerializeField] private float speed;
    [SerializeField] private float desactivateTime;
    private Rigidbody2D rb;
    private Transform parent;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();      
    }
      
    
    private IEnumerator Desactivate()
    {           
        yield return new WaitForSeconds(desactivateTime); 

        if(this.gameObject.activeInHierarchy)
        {
            transform.position = transform.parent.position;
            this.gameObject.SetActive(false);
        }
    
    }

    private void Movement()
    {     
        
        if (parent.position.x > 0) speed *= (-1);
        
        Vector2 vectorMove = new Vector2(speed, 0f);

        rb.velocity = vectorMove;
    }

    private void OnEnable()
    {
        
        Movement();
        StartCoroutine(Desactivate());
    }

    private void OnDisable()
    {
        if(this.gameObject != null)
        {
            parent = GetComponentInParent<Transform>();   
        }
    }
}
