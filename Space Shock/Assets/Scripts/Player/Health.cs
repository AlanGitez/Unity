using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHp;

    public float currentHp;
    private bool isDead;

    public Image healthBar;
    public Color fullHealtColor;
    public Color lowHealthColor;

    
    private void Update() {
        
    }

    public void TakeDamage(float amount){
        currentHp -= amount;
        HealthBarUpdate();

        if(currentHp <= 0f && !isDead){
            OnDeath();
        }
    }

    public void HealthBarUpdate(){

        healthBar.fillAmount = currentHp/maxHp;
        healthBar.color = Color.Lerp(lowHealthColor, fullHealtColor, currentHp/maxHp);
    }

    public void OnDeath(){
        isDead = true;

        gameObject.SetActive(false);
    }

    private void OnEnable() {
        currentHp = maxHp;
        HealthBarUpdate();

        isDead = false;
    }
}
