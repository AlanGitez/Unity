using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda
{
    class Almacen
    {
        private string nombreAlmacen;
        private double dineroTotal;
        private double dineroTransaccion;

        List<Productos> productos;

        public Almacen( ) {

            productos = new List<Productos>();
            this.nombreAlmacen = "Almacen de Alan";

        }
        public void setStock(Productos prod) {

            productos.Add(prod);

        }

        public List<Productos> getStock() {

            return productos;
        }

        public double pagar(double pago) {

            dineroTransaccion = pago;
            dineroTotal = dineroTransaccion + dineroTotal;

            return dineroTotal;
        }
    }
}
