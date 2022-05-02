using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaLowCost
{
    class Productos : Almacen
    {

        List<Productos> prod;

        public Productos()
        {

            prod = new List<Productos>();

        }
        public string ID { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }


        public override void addProducto(Productos productos)
        {

            prod.Add(productos);

        }

        public override List<Productos> getProducto()
        {

            return prod;

        }
    }
}

