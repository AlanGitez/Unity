using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionController : MonoBehaviour
{
    
    public float visionRadius;
    
    private GameObject player;
    
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    public bool PlayerDetection(){
        Vector2 vectorDireccion;
        vectorDireccion = player.transform.position - transform.position;

        RaycastHit2D hit=
        Physics2D.Raycast(
        transform.position, 
        vectorDireccion, 
        visionRadius,
        1 << LayerMask.NameToLayer("Default")       
        );
        if(!hit){
            return false;
        }else return hit.collider.tag == "Player";
        
        
    }
    
     private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
     }  
}
