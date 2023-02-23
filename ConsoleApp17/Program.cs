using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_programación
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se crean algunos libros
            Libro libro1 = new Libro("El código Da Vinci", "Dan Brown", "Una obra de misterio y suspenso que sigue al profesor de simbología Robert Langdon mientras intenta descifrar un código oculto en una obra de Leonardo da Vinci.", (decimal)15.99, 10, (Categoria)0);
            Libro libro2 = new Libro("El diario de Ana Frank", "Ana Frank", "El diario íntimo de una niña judía de 13 años que vivió escondida con su familia durante la ocupación nazi de los Países Bajos.", (decimal)12.50, 5, (Categoria)1);
            Libro libro3 = new Libro("Cuentos de hadas de Grimm", "Hermanos Grimm", "Una colección de cuentos clásicos para niños, que incluye historias como \"Blancanieves y los siete enanitos\", \"La Cenicienta\" y \"Rapunzel\".", (decimal)15.75, 3, (Categoria)2);
            Libro libro4 = new Libro("El jardín de las mariposas", "Dot Hutchison", "En este emocionante thriller psicológico, un agente del FBI y su equipo investigan una serie de desapariciones que los llevan a descubrir un jardín misterioso", (decimal)7.50, 8, (Categoria)0);

            //Se crea un carrito vacio y los libros se almacenan en una lista
            CarritoDeCompras carrito = new CarritoDeCompras();
            List<Libro> inventario = new List<Libro>() { libro1, libro2, libro3, libro4 };
            bool EstadoPrograma = true;

            Console.WriteLine("----------------------------------- \n" +
                              "| WELCOME TO THE ONLINE BOOKSTORE | \n" +
                              "----------------------------------- \n");
            //Se pregunta al usuario que accion quiere realizar
            do
            {
                Console.WriteLine("Que desea hacer? \n" +
                "1. Ver inventario de libros. \n" +
                "2. Agregar libro al carrito de compras. \n" +
                "3. Quitar libro del carrito de compras. \n" +
                "4. Finalizar compra \n" +
                "5. Salir del programa");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MostrarInventario(inventario);
                        break;
                    case 2:
                        AgregarLibroAlCarrito(inventario, carrito);
                        break;
                    case 3:
                        QuitarLibrosAlCarrito(inventario, carrito);
                        break;
                    case 4:
                        FinalizarCompra(carrito);
                        if (carrito.LibrosEnCarrito.Count > 0)                                        //Si la lista tiene un libro y se elige pagar, finaliza el programa
                        {
                            EstadoPrograma = false;
                        }
                        break;
                    case 5:
                        EstadoPrograma = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. \n");
                        break;
                }
            } while (EstadoPrograma == true);
            Console.ReadKey();
        }
        //------------------------------------------------------------------------------------
        //Metodo del switch para mostrar el inventario de libros
        static void MostrarInventario(List<Libro> inventario)
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
        static void AgregarLibroAlCarrito(List<Libro> inventario, CarritoDeCompras carrito)
        {
            Console.WriteLine("Titulos: \n");
            for (int i = 0; i < inventario.Count; i++)                                                       //Se imprime una lista con los titulos y su inventario
            {
                Console.WriteLine($"{i + 1}. {inventario[i].ObtenerTitulo()},   Disponibles: {inventario[i].CantidadEnInventario}");
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
        static void QuitarLibrosAlCarrito(List<Libro> inventario, CarritoDeCompras carrito)
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
        static void FinalizarCompra(CarritoDeCompras carrito)
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