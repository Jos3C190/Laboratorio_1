using Lab_1_programación;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    public class Menu
    {
        //------------------------------------------------------------------------------------
        //Metodo del switch para mostrar el inventario de libros

        public void MostrarInventario(List<Libro> inventario)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Inventario de libros: \n");
            for (int i = 0; i < inventario.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inventario[i].ObtenerTitulo()} \n" +
                    $"Autor: {inventario[i].ObtenerAutor()} \n" +
                    $"Categoria: {inventario[i].ObtenerCategoria()}\n" +
                    $"Descripción: {inventario[i].ObtenerDescripcion()} \n" +
                    $"Precio: ${inventario[i].ObtenerPrecio()} \n" +
                    $"Cantidad en inventario: {inventario[i].ObtenerCantidad()} \n");
            }
            Console.ResetColor();
        }

        //------------------------------------------------------------------------------------
        //Metodo del switch para agregar un libro al carrito

        public void AgregarLibroAlCarrito(List<Libro> inventario, CarritoDeCompras carrito)
        {
            Console.WriteLine("Titulos: \n");
            for (int i = 0; i < inventario.Count; i++)                                                       //Se imprime una lista con los titulos y su inventario
            {
                Console.WriteLine($"{i + 1}. {inventario[i].ObtenerTitulo()},   Disponibles: {inventario[i].ObtenerCantidad()},  Precio: ${inventario[i].ObtenerPrecio()}");
            }

            Console.WriteLine("\n" +
                "Ingrese el número del libro que desea agregar al carrito: ");                               //Se pregunta al usuario el libro que desea agregar
            int NoLibro = Convert.ToInt32(Console.ReadLine());

            if (NoLibro > 0 && NoLibro <= inventario.Count)
            {
                int CantidadLibro = inventario[NoLibro - 1].ObtenerCantidad();                               //Se resta 1 a la variable NoLibro (NoLibro-1) porque en la lista comienza desde cero, pero en el enunciado desde 1
                if (CantidadLibro > 0)                                                                       //es decir, 1.LibroUno = 0, 2.LibroDos = 1
                {
                    Libro libro = inventario[NoLibro - 1];
                    carrito.AgregarLibro(libro);                                                             //Metodo de la clase CarritoDeCompras que se encarga de añadir el libro y restarlo de su inventario

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"El libro '{libro.ObtenerTitulo()}' ha sido agregado al carrito de compras. \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Libro agotado \n");
                }
            }
            else
            {
                Console.WriteLine("Número de libro no válido.\n");
            }
        }

        //------------------------------------------------------------------------------------
        //Metodo del switch para quitar un libro del carrito 

        public void QuitarLibrosAlCarrito(CarritoDeCompras carrito)
        {
            if (carrito.LibrosEnCarrito.Count > 0)
            {
                Console.WriteLine("Libros en el carrito de compras: \n");                                  //Se imprimen los titulos de los libros en el carrito de compras
                for (int i = 0; i < carrito.LibrosEnCarrito.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {carrito.LibrosEnCarrito[i].ObtenerTitulo()}");
                }

                Console.WriteLine("\n" +
                    "Ingrese el número del libro que desea quitar del carrito:");                          //Se pregunta al usuario el libro que desea quitar
                int NoLibroQuitar = Convert.ToInt32(Console.ReadLine());

                if (NoLibroQuitar > 0 && NoLibroQuitar <= carrito.LibrosEnCarrito.Count)
                {
                    Libro libroQuitar = carrito.LibrosEnCarrito[NoLibroQuitar - 1];
                    carrito.RemoverLibro(libroQuitar);                                                     ////Metodo de la clase CarritoDeCompras que se encarga de quitar el libro y aumentarlo a su inventario

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"El libro '{libroQuitar.ObtenerTitulo()}' ha sido quitado del carrito de compras. \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Número de libro no válido. \n");
                }
            }
            else
            {
                Console.WriteLine("\n" +
                    "El carrito de compras está vacío. \n");
            }
        }

        //------------------------------------------------------------------------------------
        //Metodo del switch para calcular pago y finalizar

        public void FinalizarCompra(CarritoDeCompras carrito)
        {
            if (carrito.LibrosEnCarrito.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Libros en el carrito de compras: \n");                                 //Se imprimen los libros del carrito y su precio
                foreach (Libro libro in carrito.LibrosEnCarrito)
                {
                    Console.WriteLine($"{libro.ObtenerTitulo()}  Precio: {libro.ObtenerPrecio()}");
                }
                Console.WriteLine($"\n " +
                    $"Total a pagar: ${carrito.CalcularTotal()} \n");                                     //Se llama al metodo CalcularTotal de la clase CarritoDeCompras para obtener el monto a pagar
                Console.WriteLine("--GRACIAS POR SU COMPRA--");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\n" +
                    "El carrito de compras está vacío. \n");
            }
        }
    }
}
