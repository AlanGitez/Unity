using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
   [SerializeField] private Transform damageArea;
   [SerializeField] private float ratio;
   
   protected override void OnActivate()
   {
        Collider2D[] hits = Physics2D.OverlapCircleAll(damageArea.position, ratio);
        foreach(var hit in hits)
        {
            if(hit == null) continue;

            var h = hit.GetComponent<Health>();

            if(h == null) continue;
            OnHit(h);
        }
   }

    private void OnDrawGizmos()
    {   
        Color color = Color.green;

        Gizmos.color = color;
        Gizmos.DrawWireSphere(damageArea.position, ratio);
    }
   
}
