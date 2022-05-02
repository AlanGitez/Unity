using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiendaLowCost
{
    class Menu 
    {
        Almacen productos = new Productos();
        Bebidas bebidas = new Bebidas();
        Golosinas golosinas = new Golosinas();

        string res = "";
        bool condicion = false;

        public void Interfaz()
        {

            do
            {
                Console.Clear();
                Console.WriteLine("PANTALLA DE VENTA \\ \nPresione: \n1 - BEBIDAS. \n2 - GOLOSINAS.");
                int r;
                r = int.Parse(Console.ReadLine());
                switch (r)
                {

                    case 1:
                        if (bebidas.getProducto().Count.Equals(0))
                        {
                            Console.WriteLine("La lista de BEBIDAS esta vacia. Desea agregar alguna? s/n");
                            res = Console.ReadLine().ToLower();
                            if (res.Equals("s"))
                            {
                                agregarBebidas();
                                pieDeMenu();
                            }
                            else
                            {
                                pieDeMenu();
                            }
                        }                       
                        else
                        {
                            mostrarProductosAlmacenados(bebidas);

                            Console.WriteLine("PRESIONE: \n1: AGREGAR BEBIDAS AL STOCK \n2: VENDER UNA BEBIDA");
                            res = Console.ReadLine();
                            if (res.Equals("1"))
                            {
                                agregarBebidas();
                            }
                            else
                            {
                                Venta(bebidas);
                            }
                        }
                        break;

                    case 2:
                        if (golosinas.getProducto().Count.Equals(0))
                        {
                            Console.WriteLine("La lista de GOLOSINAS esta vacia. Desea agregar alguna? s/n");
                            res = Console.ReadLine().ToLower();
                            if (res.Equals("s"))
                            {
                                agregarGolosinas();
                                pieDeMenu();
                            }
                            else
                            {
                                pieDeMenu();
                            }
                        }
                        else
                        {
                            mostrarProductosAlmacenados(golosinas);

                            Console.WriteLine("PRESIONE: \n1: AGREGAR GOLOSINA AL STOCK \n2: VENDER UNA GOLOSINA");
                            res = Console.ReadLine();
                            if (res.Equals("1"))
                            {
                                agregarGolosinas();
                            }
                            else
                            {
                                
                            }
                        }
                        break;
                }

            } while (condicion);

        }

        private double solicitaPago()
        {
            // que quiere llevarse el cliente
            // verificar si lo tengo
            // ingresar dinero a la cuenta 

            double aPagar = 0;


            return aPagar;

        }

        private void Venta(Productos prod) {

            string nom = "";
            bool condicion = false;

            do
            {
                Console.Clear();
                Console.WriteLine("ingrese el NOMBRE del producto que desea el cliente");
                nom = Console.ReadLine();
               
                var inStock = prod.getProducto().Where(productos => productos.nombre.Equals(nom)).ToList();

                if (inStock.Count.Equals(0))
                {
                    Console.WriteLine("PRODUCTO NO DISPONIBLE EN STOCK. INGRESE OTRO PRODUCTO.");
                    condicion = true;
                }
                else {
                    for (int i = 0; i < inStock.Count; i++)
                    {
                        Console.WriteLine(
                            $"\n ID: {inStock[i].ID} " +
                            $"\n NOMBRE: {inStock[i].nombre} " +
                            $"\n PRECIO: {inStock[i].precio}" +
                            $"\n *****");
                    }

                }
            } while (condicion);

            
            

        }
        private void agregarBebidas() {

            Console.WriteLine("¿Cuantas BEBIDAS desea ingresar al sistema?");
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("ingrese el CODIGO del producto");
                var id = Console.ReadLine();
                
                Console.WriteLine("ingrese el NOMBRE del producto");
                var nombre = Console.ReadLine();
                
                Console.WriteLine("ingrese el PRECIO del producto");
                var precio = double.Parse(Console.ReadLine());

                bebidas.addProducto(new Bebidas

                {
                    ID = id,
                    nombre = nombre,
                    precio = precio
                });

                bebidas.count++;
            }
            Console.WriteLine("");
            Console.WriteLine($"Hay un total de {bebidas.count} almacenadas. ");

            mostrarProductosAlmacenados(bebidas);
        }

        private void agregarGolosinas() {

            Console.WriteLine("¿Cuantas GOLOSINAS desea ingresar al sistema?");
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("ingrese el CODIGO del producto");
                var id = Console.ReadLine();
                id.ToUpper();
                Console.WriteLine("ingrese el NOMBRE del producto");
                var nombre = Console.ReadLine();
                nombre.ToUpper();
                Console.WriteLine("ingrese el PRECIO del producto");
                var precio = double.Parse(Console.ReadLine());

                golosinas.addProducto(new Golosinas
                {
                    ID = id,
                    nombre = nombre,
                    precio = precio
                });

                golosinas.count++;
            }
            Console.WriteLine("");
            Console.WriteLine($"Hay un total de {golosinas.count} almacenadas. ");

            mostrarProductosAlmacenados(golosinas);
        }

        private void mostrarProductosAlmacenados(Productos producto) {
            for (int i = 0; i < producto.getProducto().Count; i++)
            {
                Console.WriteLine(
                    $"\n ID: {producto.getProducto()[i].ID} " +
                    $"\n NOMBRE: {producto.getProducto()[i].nombre} " +
                    $"\n PRECIO: {producto.getProducto()[i].precio}" +
                    $"\n *****");
            }
        }
        private void pieDeMenu() {
            Console.WriteLine("Desea volver al menu de inicio? s/n");
            res = Console.ReadLine();
            if (res.Equals("s"))
            {
                condicion = true;
            }
            else
            {
                condicion = false;
            }
        }
    }
}

