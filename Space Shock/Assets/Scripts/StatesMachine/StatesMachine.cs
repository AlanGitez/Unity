using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StatesMachine : MonoBehaviour
{
    
    public PatrolState patrolState;
    public AlertState alertState;
    public PersecutionState persecutionState;
    public MonoBehaviour initialState;

    private MonoBehaviour currentState;

  
    private void Start() {
        StatusUpdate(initialState);
    }
    
    public void StatusUpdate(MonoBehaviour nextState){
        if(currentState != null){
            currentState.enabled = false;
        } 
        currentState = nextState;
        currentState.enabled = true;
    }   
}
