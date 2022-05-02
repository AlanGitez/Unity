using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{ 
    [SerializeField] protected bool canReappear;
    [SerializeField] protected bool destroyed;
    [SerializeField] protected bool dropperStructure; 
    protected string id;
    
    private Health h;

    public bool destructible;
    public float respawnCouldown;
    public bool getDestroyed => destroyed == true;
    public bool getCanReappear => canReappear == true;
   
    
    
    private void Awake()
    {
        h = this.gameObject.GetComponent<Health>();
        SetID();
    }
    
    protected string ID 
    {
        get => GetID();
        set => SetID();
    }
    

    public void setDestroyed(bool destroyed)
    {        
        if(h == null) return;

        if(h.currentHealth <= 0) this.destroyed = destroyed;    
    }
    public string GetID()
    {
        return this.id;
    }
    private void SetID()
    {
       this.id = this.gameObject.name;
    }
    
    protected void Respawn()
    {          
        this.gameObject.SetActive(true);

        h.currentHealth = h.maxHealth;
        destroyed = false;

    }

    
    protected virtual void OnDisable()
    {
        //EVALUA SI TIENE QUE RESPAWNEAR LA ESTRUCTURA.
        if (canReappear && destroyed) 
        {
            Invoke("Respawn", respawnCouldown);
        }
    }

}
