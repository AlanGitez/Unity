using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecutionState : MonoBehaviour
{
    public float chaseSpeed;
    public float maxDistance;
    public float atackSpeed;
    public Transform firePoint;
    public GameObject enemyBullet;

    private float distance;
    private bool atacking;
    private Vector2 dir;
    private float recoilSpeed;
    
    private VisionController visionController;
    private StatesMachine stateMachine;
    private AudioSource audioSource;
    private GameObject player;
    private Rigidbody2D rb;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        visionController = GetComponent<VisionController>();
        stateMachine = GetComponent<StatesMachine>();
        rb = GetComponent<Rigidbody2D>();
        
        recoilSpeed = -1 * chaseSpeed;
    }

    void FixedUpdate()
    {
        if(!visionController.PlayerDetection()){
            stateMachine.StatusUpdate(stateMachine.patrolState);
            return;
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance > maxDistance){
            PursuePlayer(chaseSpeed);
        }else if( distance <= maxDistance){
            PursuePlayer(recoilSpeed);
        }

        if(!atacking) StartCoroutine(Atack()); 
    }

    private void PursuePlayer(float directionSpeed){
        dir = (player.transform.position - transform.position);
        float movX = dir.normalized.x * directionSpeed * Time.fixedDeltaTime;
        float movY = dir.normalized.y * directionSpeed * Time.fixedDeltaTime;
        rb.velocity = new Vector2(movX, movY);

        Vector2 lookAt = player.transform.position - transform.position;

        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;
        rb.SetRotation(angle+90f);      
    }

    private void OnEnable() {
        atacking = false;

    }

    private IEnumerator Atack(){
        atacking = true;

        float distance = Vector2.Distance(player.transform.position, transform.position);

        if(enemyBullet != null && distance <= visionController.visionRadius){
            GameObject bullet = Instantiate(enemyBullet, firePoint.position, transform.rotation);
            yield return new WaitForSeconds(atackSpeed);
            audioSource.Play();
        }
        atacking = false;
        
    }

     private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
     }

}
