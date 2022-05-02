using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform weaponSpot;

    public Weapon currentWeapon;

    public bool weaponSpotAvailable => this.currentWeapon == null;

    void Start()
    {
        Weapon[] weapons = this.GetComponentsInChildren<Weapon>();
        foreach (var w in weapons) {

            PickUpWeapon(w);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {

            if (currentWeapon == null)
            {
                print("I'm whitout WEAPON!");
                return;
            }
            if (currentWeapon != null) {

                currentWeapon.Activate();
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (currentWeapon == null) {

                print("I haven't WEAPON to drop!");
                return;
            }
            if (currentWeapon != null) {

                this.currentWeapon.DropWeapon();
                this.currentWeapon = null;
            }

        }
    }
    
    public void PickUpWeapon(Weapon weapon)
    {
        this.currentWeapon = weapon;

        weapon.transform.position = this.weaponSpot.position;
        weapon.transform.rotation = this.weaponSpot.rotation;
        weapon.transform.SetParent(this.weaponSpot);

    }
}
