using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour
{
    public int nivelACargar;
    public float tiempoRetraso;

    public Vidas vidas;

    
    public void ActivarCarga()
    {
        Invoke("CargarNivel" , tiempoRetraso);
    }

    void CargarNivel()
    {
        if (!EsUltimoNivel())
        {
            Vidas.vidas++;
            vidas.ActualizarMarcadorVidas();
        }
        
        
        SceneManager.LoadScene(nivelACargar);

    }

    public bool EsUltimoNivel()
    {
        if (nivelACargar == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        // return nivelACargar == 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
