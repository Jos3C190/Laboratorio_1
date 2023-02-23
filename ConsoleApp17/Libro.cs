using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_programación
{
    public enum Categoria
    {
        Ficcion = 0,
        No_Ficcion = 1,
        Infantil = 2,
    }

    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CantidadEnInventario { get; set; }
        public Categoria Categoria { get; set; }

        public Libro(string titulo, string autor, string descripcion, decimal precio, int cantidadEnInventario, Categoria categoria)
        {
            Titulo = titulo;
            Autor = autor;
            Descripcion = descripcion;
            Precio = Convert.ToDecimal(precio);
            CantidadEnInventario = cantidadEnInventario;
            Categoria = categoria;
        }

        public decimal ObtenerPrecio()
        {
            return Precio;
        }

        public string ObtenerTitulo()
        {
            return Titulo;
        }

        public string ObtenerAutor()
        {
            return Autor;
        }

        public string ObtenerDescripcion()
        {
            return Descripcion;
        }

        public int ObtenerCantidad()
        {
            return CantidadEnInventario;
        }

        public Categoria ObtenerCategoria()
        {
            return Categoria;
        }

        public void DisminuirCantidad(int cantidad)
        {
            CantidadEnInventario -= cantidad;
        }

        public void AumentarCantidad(int cantidad)
        {
            CantidadEnInventario += cantidad;
        }
    }
}
