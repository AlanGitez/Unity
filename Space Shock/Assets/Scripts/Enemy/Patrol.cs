using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float waitingTime;

    private Vector3 posIni;
    private GameObject target;
    private Vector3 direction;
    private Rigidbody2D rb;
    private EnemyTracking enemyTracking;
    
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        
        enemyTracking = FindObjectOfType<EnemyTracking>();

    }

    void Start()
    {
        TargetUpdate();
        //StartCoroutine(EnemyPatrol());
    }

    void Update()
    {
        
    }

    private void TargetUpdate(){
        float randomPosX = Random.Range(-13, 13);
        float randomPosY = Random.Range(-8, 8);
        if(target == null && gameObject != null){
            target = new GameObject("Target");
            target.transform.position = new Vector2(randomPosX, randomPosY);
            
            return;
        }
        if(transform.position == target.transform.position){
            rb.velocity = Vector2.zero;
            target.transform.position = new Vector2(randomPosX, randomPosY);
        }
    }

    private void Move(){
        rb.MovePosition(transform.position + (direction * speed) * Time.fixedDeltaTime);

        transform.LookAt(target.transform.position);
    }

    /*private IEnumerator EnemyPatrol(){
        float distance = Vector2.Distance(transform.position, target.transform.position);

        while(distance > 0.05){
           direction = (target.transform.position - transform.position).normalized;
          navMeshController.MoveToTarget(target, direction, speed);

           yield return null; 
        }

        transform.position = target.transform.position;
        yield return new WaitForSeconds(waitingTime);

        TargetUpdate();
        StartCoroutine(EnemyPatrol());
    } */

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        if(target != null){
        Gizmos.DrawWireSphere(target.transform.position, 2f);
        }

    }
}
