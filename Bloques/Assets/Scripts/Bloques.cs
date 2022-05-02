using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour
{
    public GameObject efectoParticulas;
    public Puntos puntos;
    private void OnCollisionEnter(Collision collision) // is trigger desactivado
    {
        Instantiate(efectoParticulas, transform.position, Quaternion.identity);
        transform.SetParent(null);
        Destroy(this.gameObject);
       
        puntos.GanarPuntos();
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
