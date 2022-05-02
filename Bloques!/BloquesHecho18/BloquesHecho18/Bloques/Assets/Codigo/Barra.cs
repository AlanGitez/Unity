using UnityEngine;
using System.Collections;

public class Barra : MonoBehaviour {

    public float velocidad = 0.4f;

    Vector3 posicionInicial;

    public ElementoInteractivo botonIzquierda;
    public ElementoInteractivo botonDerecha;

    // Use this for initialization
    void Start () {
        posicionInicial = transform.position;
	}

    public void Reset()
    {
        transform.position = posicionInicial;
    }
	
	// Update is called once per frame
	void Update () {

        float direccion = botonIzquierda.pulsado ? 
            -1 : 
            (botonDerecha.pulsado ? 
                1 : 
                Input.GetAxisRaw("Horizontal"));

        float posX = transform.position.x + (direccion * velocidad * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(posX, -8, 8), transform.position.y, transform.position.z);
    }
}
