using System;
using System.Collections.Generic;

namespace AppDatos
{
    class Program
    {
        Cliente c1 = new Cliente();
        Cliente c2 = new Cliente();
        Cliente c3 = new Cliente();
        Cliente c4 = new Cliente();

        List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args)
        {
            
            
        }

        private void cargaDatos() {
            clientes.Add(c1);
            clientes.Add(c2);
            clientes.Add(c3);
            clientes.Add(c4);

            int i = 0;
            string data;
            do {
                Console.WriteLine("Bienvenido. \nPorfavor, Ingrese su nombre para entrar en sistema.");
                data = Console.ReadLine();
                clientes[i].setName(data);
                Console.WriteLine("Ingrese su apellido.");
                data = Console.ReadLine();
                clientes[i].setApellido(data);

            } while (i<clientes.Capacity);
           
        }
    }
}
