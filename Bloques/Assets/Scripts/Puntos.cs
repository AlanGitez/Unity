using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puntos : MonoBehaviour
    {
    public static int puntos = 0;

    public Text textoPuntos;

    public GameObject nivelCompletado;
    public GameObject juegoCompletado;

    public SiguienteNivel siguienteNivel;

    public Pelota pelota;
    public Barra barra;

    public Transform contenedorBloques;

    public SonidoFinPartida sonidosFinPartida;

    void ActualizarMarcadorPuntos()
    {
        textoPuntos.text = "Puntos = " + Puntos.puntos;

    }

    // Start is called before the first frame update
    void Start()
    {
        ActualizarMarcadorPuntos();
    }

    public void GanarPuntos()
    {      
       Puntos.puntos++;
       ActualizarMarcadorPuntos();
        
       if (contenedorBloques.transform.childCount <= 0)
        {
            pelota.DetenerMovimiento();
            barra.enabled = false;
            
            if (siguienteNivel.EsUltimoNivel())
            {
                juegoCompletado.SetActive(true);                
            }
            else
            {
                nivelCompletado.SetActive(true);             
            }
            sonidosFinPartida.NivelCompletado();         
            siguienteNivel.ActivarCarga();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
