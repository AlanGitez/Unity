using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{
    public Vidas actualizarVidas;
    
    void OnCollisionEnter()
    {
        actualizarVidas.PerderVidas();
        
    }
    void Start()
    {

    }
   
}
