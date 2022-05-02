using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaCaca : Weapon
{
    public GameObject Bullet;
    [SerializeField] private float shootPower;
    

    protected override void OnActivate() {
        if (Bullet != null)
        {
            GameObject bullet = Instantiate(Bullet, this.GetComponentInParent<Transform>().position, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

            Vector2 shootVector = this.GetComponentInParent<Transform>().up * shootPower;
            rbBullet.AddForce(shootVector, ForceMode2D.Impulse);


            print("PUM!");
        }
        else print("NO AMMUNITION!");

    }
}
