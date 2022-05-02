using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonSalir : MonoBehaviour
{
    public bool enJuego;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enJuego)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("Saliste del juego");
                Application.Quit();
            }
        }
    }
}
