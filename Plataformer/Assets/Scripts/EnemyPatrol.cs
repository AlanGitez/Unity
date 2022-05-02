using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
   

    private GameObject target;
    public float speed = 1.5f;
    public float minX;
    public float maxX;
    public float waitingTime;

    private bool isDead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // target = GetComponent<GameObject>();
        // posInitial = new Vector2(5f, -3.5f);
    }
    void Start()
    {
       // transform.position = posInitial;
        TargetUpdate();
        StartCoroutine("PatrolToTarget");
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    

    private void TargetUpdate()
    {
        if (target == null)
        {
            target = new GameObject("Target");
            target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
            return;
        }
        if (target.transform.position.x == minX)
        {
            target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (target.transform.position.x == maxX)
        {
            target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(transform.position, target.transform.position) > 0.05)
        {
            Vector2 direction = target.transform.position - transform.position;
            float xDirection = direction.x;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
           
            yield return null;
        }
        transform.position = new Vector2(target.transform.position.x, transform.position.y);      
        transform.localScale = new Vector3((transform.localScale.x * -1), 1, 1);

        yield return new WaitForSeconds(waitingTime);

        TargetUpdate();
        StartCoroutine("PatrolToTarget");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FootDetection")
        {
            Debug.Log("Me Tocaste");
        }
    }
    private void Dead()
    {
        isDead = true;
        rb.velocity = Vector2.zero;

    }
}
