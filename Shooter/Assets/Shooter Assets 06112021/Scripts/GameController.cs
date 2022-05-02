using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[] gameObj;
    private List<Structure> structure = new List<Structure>();
    
    private void Awake()
    {
        gameObj = GameObject.FindGameObjectsWithTag("Structure");
        

        for(int i = 0; i<gameObj.Length; i++)
        {
            structure.Add(gameObj[i].GetComponent<Structure>());
            
            if(structure[i] == null) continue;    
        }
    }
        
    private void Update()
    {
        
        for(int i = 0; i < structure.Count; i++)
        {
            if(structure[i] == null) print("No hay nada!");

            if(structure[i].getCanReappear && structure[i].getDestroyed)
            {
            
            //StartCoroutine(structure[i].Respawn());
            
            }
        }   
    }



}
