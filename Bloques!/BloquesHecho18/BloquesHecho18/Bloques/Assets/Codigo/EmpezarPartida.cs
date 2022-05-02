using UnityEngine;
using System.Collections;

public class EmpezarPartida : MonoBehaviour {

    public ElementoInteractivo pantalla;

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") || pantalla.pulsado)
        {
            Puntos.puntos = 0;
            Vidas.vidas = 3;
            Application.LoadLevel("Nivel01");
        }
	}
}
