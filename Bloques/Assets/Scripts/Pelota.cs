using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    public float velocidadDisparo = 100f;

    

    Rigidbody rig;

    bool enJuego;

    Vector3 posInicial;

    public Transform Barra;
    public Transform Hija;

    public ElementoInteractivo pantalla;

    // Start is called before the first frame update
    public void Start()
    {
        posInicial = transform.position;
        rig = GetComponent<Rigidbody>();
        
    }

    public void Reset()
    {
        transform.position = posInicial;
        transform.SetParent(Hija);
        enJuego = false;
        DetenerMovimiento();


    }
    public void DetenerMovimiento()
    {
        rig.isKinematic = true;
        rig.velocity = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {
        if (!enJuego && (Input.GetButtonDown("Fire1") || pantalla.pulsado))
        {
            enJuego = true;
            transform.SetParent(null);
            rig.isKinematic = false;
            rig.AddForce(new Vector3(velocidadDisparo, velocidadDisparo, 0));
        }
    }
}
