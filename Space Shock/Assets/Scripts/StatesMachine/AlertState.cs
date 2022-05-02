using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : MonoBehaviour
{
    public float turningAngle;
    public float searchTime;

    private float searchingTime;
    private Vector2 alertPosition;

    private StatesMachine statesMachine;
    private VisionController visionController;
    private GameObject player;
    private Rigidbody2D rb;

    private void Awake() {
        statesMachine = GetComponent<StatesMachine>();
        visionController = GetComponent<VisionController>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(visionController.PlayerDetection()){
            statesMachine.StatusUpdate(statesMachine.persecutionState);
            return;
        }

        searchingTime += Time.deltaTime;
        transform.Rotate(0f, 0f, turningAngle * Time.deltaTime);

        if(searchingTime >= searchTime){
            statesMachine.StatusUpdate(statesMachine.patrolState);
            turningAngle = 0f;
        }             
    }

    private void OnEnable() {
        alertPosition = transform.position;
        rb.velocity = Vector2.zero;
        searchingTime = 0f;
    }
}
