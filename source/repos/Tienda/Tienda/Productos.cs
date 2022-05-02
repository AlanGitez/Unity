using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda
{
    class Productos
    {
        private string ID;
        private string nombre;
        private double precio;
                                
        public Productos(string ID, string nombre, double precio) {
            this.ID = ID;
            this.nombre = nombre;
            this.precio = precio;
        }


    }
}
