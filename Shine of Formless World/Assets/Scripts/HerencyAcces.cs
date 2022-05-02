using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerencyAcces : MonoBehaviour
{
    Vehiculo vehiculo = new Vehiculo();
    Avion avion = new Avion();
    Coche coche = new Coche();

    private void Start() {
        avion.arrancarMotor();
        avion.conducir();

        coche.arrancarMotor();
        coche.conducir();

    }    

}
