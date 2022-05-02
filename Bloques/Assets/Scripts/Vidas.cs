using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Vidas : MonoBehaviour
{
    public static int vidas = 3;

    public Text textoVidas;
    
    public Pelota pelotaReset;
    public Barra barraReset;

    public SiguienteNivel siguienteNivel;
    public GameObject gameOver;

    public SonidoFinPartida sonidoFinPartida;

    public void ActualizarMarcadorVidas()
    {
        textoVidas.text = "Vidas: " + Vidas.vidas;
    }

// Start is called before the first frame update
    void Start()
    {
         ActualizarMarcadorVidas();
    }

    public void PerderVidas()
    {
        if (vidas <= 0) return;
        Vidas.vidas--;
        ActualizarMarcadorVidas();
       
        if (vidas <= 0)
        {
            sonidoFinPartida.GameOver();
            gameOver.SetActive(true);
            pelotaReset.DetenerMovimiento();
            barraReset.enabled = false;

            siguienteNivel.nivelACargar = 0;
            siguienteNivel.ActivarCarga();

            


        }

        barraReset.Reset();
        pelotaReset.Reset();

        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}

