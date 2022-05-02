using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaLowCost
{
    abstract class Almacen
    {
        private double dineroActual;
        private double dineroDeVenta;

        abstract public void addProducto(Productos productos);
        abstract public List<Productos> getProducto();
    }
}
