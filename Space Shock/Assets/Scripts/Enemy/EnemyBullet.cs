using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;
    public float damageDone;  

    private Vector3 dir, target;

    private Rigidbody2D rb;
    private Transform player;
    
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    } 

    void Start()
    {   
       
        Shoot();
    }


    private void Shoot(){      
        if(player != null){
            target = player.position;
        }
        dir = (target - transform.position).normalized;
        float horMove = dir.x * bulletSpeed;
        float verMove = dir.y * bulletSpeed;
        rb.velocity = new Vector2(horMove, verMove);    
    }


    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
