using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehiculo : MonoBehaviour
{
    public void arrancarMotor(){
        print("Poniendo motor en marcha");
    }

    protected void pararMotor(){
        print("Deteniendo motor");

    }

    public virtual void conducir(){
        print("Concepto basico de conduccion");

    }
}
