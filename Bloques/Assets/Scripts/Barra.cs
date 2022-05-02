using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    
    public ElementoInteractivo botonIzquierda;
    public ElementoInteractivo botonDerecha;



    // Start is called before the first frame update
    public float speed = 10f;
    Vector3 posInicial;
    
    void Start()
    {
        posInicial = transform.position;
    }

    public void Reset()
    {
        transform.position = posInicial;
        
    }
    // Update is called once per frame
    void Update()
    {

        // float horizontalMove = Input.GetAxisRaw("Horizontal"); ASI SE MUEVE SOLO CON TECLADO
        // ASI SE MUEVE CON TECLADO Y BOTONES TACTILES
        float direccion;
        if (botonIzquierda.pulsado)
        {
            direccion = -1;
        }
        else if (botonDerecha.pulsado)
        {
            direccion = 1;
        }
        else
        {
            direccion = Input.GetAxisRaw("Horizontal");
        }
        float posX = transform.position.x + (direccion * speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(posX, -7.5f, +7.5f), transform.position.y, transform.position.z);
    }
}
