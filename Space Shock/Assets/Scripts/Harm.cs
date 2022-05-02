using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harm : MonoBehaviour
{
    private Health health;
    private AmmunitionDamage ammunition;

    private void Awake() {
        health = FindObjectOfType<Health>();
        ammunition = FindObjectOfType<AmmunitionDamage>();
    }

   private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<EnemyHealth>() == true){
           print("Haz dañado al enemy, por: "+ammunition.basicLaser); 
           //other.GetComponent<EnemyHealth>().TakeDamage(ammunition.basicLaser);
           EnemyHealth test = other.gameObject.GetComponent<EnemyHealth>();
           test.TakeDamage(ammunition.basicLaser);

        }
        if(other.gameObject.tag == "Player" && other.gameObject != null){
            other.GetComponent<Health>().TakeDamage(GetComponent<EnemyBullet>().damageDone);
        }

        Destroy(gameObject);
   }
}
