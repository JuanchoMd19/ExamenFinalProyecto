using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal
{
    public class Carrito:Producto
    {
        double rest_existencia;
        public double Rest_existencia { get => rest_existencia; set => rest_existencia = value; }
    }
}