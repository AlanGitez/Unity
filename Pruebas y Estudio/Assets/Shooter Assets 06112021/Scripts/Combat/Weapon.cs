using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    //Couldown.
    //Da�o.
    //Pueden ser disparadas.
    //Deben estar equipadas.

    [Header("Weapon")]
    [SerializeField] private GameObject weaponItemPrefab;

    protected float currentCouldown;

    [SerializeField] private float maxCouldown = 1f;
    [SerializeField] private float damage;
    private bool isReady => this.currentCouldown >= this.maxCouldown;

    private void Awake()
    {
        this.currentCouldown = this.maxCouldown;
    }

    protected void Update()
    {       
        if (isReady == false) {

            this.currentCouldown += Time.deltaTime;           
        }
    }

    public void Activate()
    {
        if (this.isReady == false) print("I'm Reloading!");
        if (this.isReady == true) 
        {
            OnActivate();
            currentCouldown = 0f;
        }
    }

    public void OnHit(Health health) {

        health.TakeDamage(this.damage);
    }

    public void DropWeapon() 
    {
        //Instantiate(weaponItemPrefab, this.transform.position, Quaternion.identity);

        //PARA TERMINARLO, CREO YO, TENGO QUE HACER UN OBJECT POOLING.
        //var itemScript = this.weaponItemPrefab.GetComponent<WeaponItem>();

        //itemScript.DropActivate(true);
        //weaponItemPrefab.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        string str = weaponItemPrefab.tag;
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        ItemPool.Instance.GetWeaponItem(obj, str);

        Destroy(gameObject);
    }

    protected abstract void OnActivate();

}
