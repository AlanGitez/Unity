using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    [SerializeField] private Transform detector;
    [SerializeField] private float radius;
    private bool onGround;
    

    public bool IsGround()
    {
        onGround = Physics2D.OverlapCircle(detector.position, radius,
        3 << LayerMask.NameToLayer("Ground"));
        

        return onGround;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detector.transform.position, radius);
    }

}
