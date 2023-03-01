using ConsoleApp17;
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
            Menu menu = new Menu();
            bool EstadoPrograma = false;

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
                        menu.MostrarInventario(inventario);
                        break;
                    case 2:
                        menu.AgregarLibroAlCarrito(inventario, carrito);
                        break;
                    case 3:
                        menu.QuitarLibrosAlCarrito(carrito);
                        break;
                    case 4:
                        menu.FinalizarCompra(carrito);
                        if (carrito.LibrosEnCarrito.Count > 0)                                        //Si la lista tiene un libro y se elige pagar, finaliza el programa
                        {
                            EstadoPrograma = true;
                        }
                        break;
                    case 5:
                        EstadoPrograma = true;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. \n");
                        break;
                }
            } while (EstadoPrograma == false);
            Console.ReadKey();
        }
    }
}