using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal
{
    public class RepMasVendidos:Producto
    {
        int cantidad;
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}