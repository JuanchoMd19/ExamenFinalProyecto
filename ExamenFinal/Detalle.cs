using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal
{
    public class Detalle:Factura
    {
        string codigo_producto;
        double cantidad;
        public string Codigo_producto { get => codigo_producto; set => codigo_producto = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
    }
}