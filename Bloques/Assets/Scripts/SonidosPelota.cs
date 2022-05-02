using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosPelota : MonoBehaviour
{
    
    public AudioSource rebote;
    public AudioSource punto;
    public AudioSource error;

    void OnCollisionEnter(Collision otro)
    {
       if (otro.gameObject.CompareTag("Bloque"))
        {
            punto.Play();
        }
       if (otro.gameObject.CompareTag("Agua"))
        {
            error.Play();
        }
        else
        {
            rebote.Play();
        }
    }
  
}
