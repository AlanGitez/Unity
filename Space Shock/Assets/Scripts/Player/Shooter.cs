using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject redBulletPref;
    public bool atacking;

    private AudioSource audioSource;

    private void Awake(){
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            atacking = true;
            Shoot();
        }
        atacking = false;
    }
        

    void Shoot(){
        GameObject bullet = Instantiate(redBulletPref, firePoint.position, firePoint.rotation);
        audioSource.Play();  
    }
}
