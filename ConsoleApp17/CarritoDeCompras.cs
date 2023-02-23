using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_programación
{
    public class CarritoDeCompras
    {

        private List<Libro> _librosEnCarrito = new List<Libro>();
        public IReadOnlyList<Libro> LibrosEnCarrito => _librosEnCarrito;

        public CarritoDeCompras()
        {
        }

        public void AgregarLibro(Libro libro)
        {
            _librosEnCarrito.Add(libro);                    //Agrega un libro al carrito de compras
            libro.DisminuirCantidad(1);                     //Quita 1 a su cantidad de inventario
        }

        public void RemoverLibro(Libro libro)
        {
            _librosEnCarrito.Remove(libro);                 //Remueve un libro del carrito de compras
            libro.AumentarCantidad(1);                      //Devuelve el libro al inventario (retorna 1 a su cantidad)
        }

        public decimal CalcularTotal()
        {
            decimal totalAPagar = 0;
            foreach (Libro libro in _librosEnCarrito)
            {
                totalAPagar += libro.ObtenerPrecio();       //Calcula el total a pagar de los libros en el carrito
            }
            return totalAPagar;

        }
    }
}