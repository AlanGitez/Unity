using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHp;
    public float respawnTime;
    public GameObject[] respawnPoints = new GameObject[4];

    private float currentHp;
    private bool isDead;
    private Vector2 posIni;
    
    public Image healthBar;
    public Color fullHealtColor;
    public Color lowHealthColor;

    private StatesMachine statesMachine;

    private void Awake() {
        statesMachine = FindObjectOfType<StatesMachine>();
    }

    private void Start() {
        posIni = transform.position;
    }
    
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
        Invoke("EnemyRespawn", respawnTime);
    }

    private void EnemyRespawn(){
        transform.position = posIni;
        gameObject.SetActive(true);

        statesMachine.StatusUpdate(statesMachine.initialState);
    }


    private void OnEnable() {
        currentHp = maxHp;
        HealthBarUpdate();

        isDead = false;
    }
}
