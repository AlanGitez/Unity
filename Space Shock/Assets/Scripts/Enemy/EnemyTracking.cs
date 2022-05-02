using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    // ELEMENTOS RAYCAST Y MOVIMIENTO 
    public GameObject firePoint;
    public float visionRadius;
    public float maxDistance;
    public float speed;
    private float distance;
    
    public bool playerDetected;

    // ATAQUE
    public float atackSpeed;
    public bool atacking;
    private Vector3 target, direction;
    private Vector3 posIni;

    // REFERENCIAS
    public GameObject player;
    public GameObject enemyBullet;
    private Rigidbody2D rb;

    private void Awake() {
       
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        posIni = transform.position;
    }

    private void FixedUpdate() {
        EnemyFollow();
    }

    private void EnemyFollow(){
        target = posIni;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            player.transform.position - transform.position,
            visionRadius,
            1 << LayerMask.NameToLayer("Default")
        );
       
        if(hit.collider != null){
            if(hit.collider.tag == "Player"){
                Debug.Log("te vi puto");
                target = player.transform.position;
            } 
        }
        

        distance = Vector2.Distance(target, transform.position);
        direction = (target - transform.position).normalized;

        if(target != posIni && distance < visionRadius) {
            Move();
            Rotation();
            if(!atacking) StartCoroutine(Atack(atackSpeed)); 
        }

        if(target != posIni && distance < 0.02f){
            transform.position = target;
        }
        Debug.DrawLine(transform.position, player.transform.position, Color.green);  
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, maxDistance);

    }

    private void Move(){
        if(distance > maxDistance){
            rb.MovePosition(transform.position + (direction * speed) * Time.fixedDeltaTime);
        }else if(distance < maxDistance){
            rb.MovePosition(transform.position + (direction * -speed) * Time.fixedDeltaTime);
        }
        if (distance == maxDistance){
            rb.velocity = Vector3.zero;
        }
        
    }

    private void Rotation(){
        Vector2 lookAtPlayer = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookAtPlayer.y, lookAtPlayer.x) * Mathf.Deg2Rad;

        transform.up = -lookAtPlayer;
    }

    private IEnumerator Atack(float seconds){
        atacking = true;
        
        if(target == player.transform.position && enemyBullet != null){
            Instantiate(enemyBullet, firePoint.transform.position, transform.rotation);

            yield return new WaitForSeconds(seconds);
        } 
        atacking = false;         
    }
}



