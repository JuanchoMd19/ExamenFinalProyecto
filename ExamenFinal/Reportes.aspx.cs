using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ExamenFinal
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private List<RepMasVendidos> LeerRepMasVendidos()
        {
            List<RepMasVendidos> data = new List<RepMasVendidos>();
            string archivo = Server.MapPath("~/json/RepMasVendidos.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            if (jsonStream != null)
                data = JsonConvert.DeserializeObject<List<RepMasVendidos>>(json);
            return data;
        }
        private List<Detalle> LeerDetalle()
        {
            List<Detalle> data = new List<Detalle>();
            string archivo = Server.MapPath("~/json/Detalle.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            if (jsonStream != null)
                data = JsonConvert.DeserializeObject<List<Detalle>>(json);
            return data;
        }
        private List<Producto> LeerProducto()
        {
            List<Producto> data = new List<Producto>();
            string archivo = Server.MapPath("~/json/Productos.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            if (jsonStream != null)
                data = JsonConvert.DeserializeObject<List<Producto>>(json);
            return data;
        }
        protected void ButtonMostrarRep1_Click(object sender, EventArgs e)
        {
            List<RepMasVendidos> datosRep;
            datosRep = LeerRepMasVendidos();
            GridViewRep1.DataSource = datosRep;
            GridViewRep1.DataBind();
        }
        protected void CalendarFechaInicial_SelectionChanged(object sender, EventArgs e)
        {
            TextBoxFechaInicial.Text = CalendarFechaInicial.SelectedDate.ToString("dd/MM/yyyy");
        }
        protected void CalendarFechaFinal_SelectionChanged(object sender, EventArgs e)
        {
            TextBoxFechaFinal.Text = CalendarFechaFinal.SelectedDate.ToString("dd/MM/yyyy");
        }
        protected void ButtonMostrarRep2_Click(object sender, EventArgs e)
        {
            LabelRep2Y3.Text = "Reporte del total de ventas";
            DateTime f1 = Convert.ToDateTime(TextBoxFechaInicial.Text);
            DateTime f2 = Convert.ToDateTime(TextBoxFechaFinal.Text);
            double total = 0;
            List<Detalle> detalles = LeerDetalle();
            List<Producto> productos = LeerProducto();
            Producto temp;
            for (int i = 0; i < detalles.Count; i++)
            {
                if ((f1 <= detalles[i].Fecha) && (f2 >= detalles[i].Fecha))
                {
                    temp = productos.Find(x => x.Codigo == detalles[i].Codigo_producto);
                    total = total + (detalles[i].Cantidad * temp.P_venta);
                }
            }
            TextBoxCantidad.Text = "Q" + total.ToString();
        }
        protected void ButtonMostrarRep3_Click(object sender, EventArgs e)
        {
            LabelRep2Y3.Text = "Reporte del total de Ganancias";
            DateTime f1 = Convert.ToDateTime(TextBoxFechaInicial.Text);
            DateTime f2 = Convert.ToDateTime(TextBoxFechaFinal.Text);
            double total = 0;
            List<Detalle> detalles = LeerDetalle();
            List<Producto> productos = LeerProducto();
            Producto temp;
            for (int i = 0; i < detalles.Count; i++)
            {
                if ((f1 <= detalles[i].Fecha) && (f2 >= detalles[i].Fecha))
                {
                    temp = productos.Find(x => x.Codigo == detalles[i].Codigo_producto);
                    total = total + (detalles[i].Cantidad * (temp.P_venta - temp.P_compra));
                }
            }
            TextBoxCantidad.Text = "Q" + total.ToString();
        }
    }
}