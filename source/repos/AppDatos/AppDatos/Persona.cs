using System;
using System.Collections.Generic;
using System.Text;

namespace AppDatos
{
    class Persona
    {
        private string nombre;
        private string apellido;
        private int edad;

        public void setName(string name)
        {
            this.nombre = name;
        }
        public string getName()
        {
            return this.nombre;
        }

        public void setApellido(string lastName)
        {
            this.apellido = lastName;
        }
        public string getApellido()
        {
            return this.apellido;
        }

        public void setEdad(int age)
        {
            this.edad = age;
        }
        public int getEdad()
        {
            return this.edad;
        }

    }
}
