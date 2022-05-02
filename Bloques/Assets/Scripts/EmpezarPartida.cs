using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmpezarPartida : MonoBehaviour
{
    public ElementoInteractivo pantalla;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || pantalla.pulsado)
        {
            Puntos.puntos = 0;
            Vidas.vidas = 3;
            SceneManager.LoadScene(1);
            
        }
    }
}
