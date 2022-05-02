using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool imStructure;
    [SerializeField] private bool imDropperStructure;
    [SerializeField] private bool imEnemy;
    private Structure structure;
    private DropperStructure dropperStructure;
    private Enemy enemy;

    public float maxHealth = 100;   
    public float currentHealth;

    private void Awake()
    {
        structure = this.gameObject.GetComponent<Structure>();
        dropperStructure = this.gameObject.GetComponent<DropperStructure>();
        enemy = this.gameObject.GetComponent<Enemy>();
    }
    private float percentage
    {
        get { return this.currentHealth / this.maxHealth; }
    }

    void Start()
    {
        this.currentHealth = this.maxHealth;
    }


    public void TakeDamage(float damage) 
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if (currentHealth <= 0) 
        {
            if (imStructure) TargetSelectionToDamage(structure);
            if (imDropperStructure) TargetSelectionToDamage(dropperStructure);
            if (imEnemy) TargetSelectionToDamage(enemy);
        }
    }

    private void TargetSelectionToDamage(Structure target)
    {
        target = this.gameObject.GetComponent<Structure>();
        if (target == null) return;

        target.setDestroyed(true);
        Dead(target);

    }

    private void RestoreHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
    }

    public void Dead(Structure target)
    {
        print(target.GetID() + " Has been DESTROYED!");

        if (imDropperStructure)
        {
            var t = this.gameObject.GetComponent<DropperStructure>();
            t.DropItem();
        }
    
        this.gameObject.SetActive(false);
    }

}
