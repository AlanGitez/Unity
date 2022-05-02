using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private float StartGameTime;
    [SerializeField] private float currentGameTime;

    private bool gameStarted => currentGameTime >= StartGameTime;
    
    void Start()
    {
          currentGameTime = 0;
    }

    
    void Update()
    {
        currentGameTime += Time.deltaTime;
    }
}
