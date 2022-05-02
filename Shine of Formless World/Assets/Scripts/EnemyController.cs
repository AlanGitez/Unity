using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<float> limitX;
    public List<float> limitY;
    public float visionRadius;
    public float patrolSpeed;
    public float waitingTime;
    public float persecutionSpeed;
    
    private GameObject player;
    private Transform playerTransform;
    private GameObject wayPoint;

    private Rigidbody2D rb;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;

        rb = GetComponent<Rigidbody2D>();

    }
    
    void Start()
    {
        WayPointUpdate();
        StartCoroutine(PatrolCicle());
    }
    
    void Update()
    {
        WayPointUpdate();
        /*
        if(Vision()){
            MoveToObjetive(playerTransform, persecutionSpeed);
        } else {
            WayPointUpdate();
            StartCoroutine(PatrolCicle());
        }
        */
    } 

    private void WayPointUpdate(){
        float randomPosX = Random.Range(limitX[0], limitX[1]);
        float randomPosY = Random.Range(limitY[0], limitY[1]);
        if(wayPoint == null){
            wayPoint = new GameObject("WayPoint");
            wayPoint.transform.position = new Vector2(randomPosX, randomPosY);
        }
    }

    private IEnumerator PatrolCicle(){
        while(Vector2.Distance(wayPoint.transform.position, transform.position)>= 0.05f){
            MoveToObjetive(wayPoint.transform, patrolSpeed);
            yield return null;
        } 
        yield return new WaitForSeconds(waitingTime);
        Destroy(wayPoint.gameObject);
        WayPointUpdate();
        StartCoroutine(PatrolCicle());

    }

    private void MoveToObjetive(Transform objetive, float pursuitSpeed){
        Vector2 dirMove = (objetive.position - transform.position).normalized;

        rb.velocity = new Vector2(dirMove.x, dirMove.y) * pursuitSpeed;

    }

    /*
    private bool Vision(){
        Vector2 direction = playerTransform.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast
        (transform.position, 
        direction, 
        visionRadius);
          
        return hit.collider.tag == "Player";   
    }
    */
}
