using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    public GameObject weaponPrefab;
    

    private bool justDropped;

    [SerializeField] private float maxTimeDropped = 4f;
    [SerializeField] private float currentTimeDropped;

    void Start()
    {
        justDropped = true;
        Invoke("ActivatePickupMode", 1f);
    }

    
    void Update()
    {
        if (currentTimeDropped < maxTimeDropped) 
        {
            currentTimeDropped += Time.deltaTime;  
        }
        //SI PASO DEMASIADO TIEMPO DROPEADO Y SIN RECOGER, DESAPARECE DE LA ESCENA.
        if (currentTimeDropped >= maxTimeDropped) 
        {
            Inactivate();
        }
    }

    private void ActivatePickupMode() {

        justDropped = false;
    
    }

    private void Inactivate() 
    {
        currentTimeDropped = maxTimeDropped;
        this.gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        currentTimeDropped = 0f;
    }

    public void DropActivate(bool value)
    {
        
        this.gameObject.SetActive(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (justDropped) return;

        WeaponManager manager = collision.GetComponent<WeaponManager>();

        if (manager == null) return;
        if (manager.weaponSpotAvailable == false) return;

        var newWeapon = Instantiate(this.weaponPrefab);

        manager.PickUpWeapon(newWeapon.GetComponent<Weapon>());
        
        this.gameObject.SetActive(false);
        
    }
}
