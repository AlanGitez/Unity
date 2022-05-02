using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoFinPartida : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip completado;
    public AudioClip gameOver;
    

    public void ReproduceSonido(AudioClip sonido)
    {
        audioSource.clip = sonido;
        audioSource.loop = false;
        audioSource.Play();
    }
    public void GameOver()
    {
        ReproduceSonido(gameOver);
    }

    public void NivelCompletado()
    {
        ReproduceSonido(completado);
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
