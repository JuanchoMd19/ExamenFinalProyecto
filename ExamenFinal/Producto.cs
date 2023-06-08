using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal
{
    public class Producto
    {
        string codigo;
        string nombre;
        string marca;
        string descripcion;
        string imagen;
        double p_compra;
        double p_venta;
        double existencia;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public double P_compra { get => p_compra; set => p_compra = value; }
        public double P_venta { get => p_venta; set => p_venta = value; }
        public double Existencia { get => existencia; set => existencia = value; }
    }
}