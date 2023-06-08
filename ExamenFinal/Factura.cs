using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal
{
    public class Factura
    {
        string noFactura;
        string nit;
        DateTime fecha;
        string estado;
        public string NoFactura { get => noFactura; set => noFactura = value; }
        public string Nit { get => nit; set => nit = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}