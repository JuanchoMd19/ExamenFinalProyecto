using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinal
{
    public partial class Pos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelAgregar.Visible = false;
            TextBoxAgregar.Visible = false;
            ButtonAgregar.Visible = false;
        }
        private List<Producto> LeerJson()
        {
            List<Producto> productos = new List<Producto>();
            string archivo = Server.MapPath("~/json/Productos.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            if (jsonStream != null)
                productos = JsonConvert.DeserializeObject<List<Producto>>(json);
            return productos;
        }
        private void GuardarJson(List<Producto> productos)
        {
            string json = JsonConvert.SerializeObject(productos);
            string archivo = Server.MapPath("~/json/Productos.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        protected void ButtonMostrar_Click(object sender, EventArgs e)
        {
            List<Producto> productos = new List<Producto>();
            productos = LeerJson();
            GridViewProductos.DataSource = productos;
            GridViewProductos.DataBind();
        }
        //Carrito de compras
        private void GuardarCarrito(List<Carrito> carrito)
        {
            string json = JsonConvert.SerializeObject(carrito);
            string archivo = Server.MapPath("~/json/Carrito.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        private List<Carrito> LeerCarrito()
        {
            List<Carrito> data = new List<Carrito>();
            string archivo = Server.MapPath("~/json/Carrito.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            if (jsonStream != null)
                data = JsonConvert.DeserializeObject<List<Carrito>>(json);
            return data;
        }
        protected void ButtonCallAgregar_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            if (btn.Text == "Agregar")
            {
                //Agregar valores del producto al carrito
                codigo.Text = row.Cells[1].Text;
                nombre.Text = row.Cells[2].Text;
                marca.Text = row.Cells[3].Text;
                //Diseño
                btn.CssClass = "btn btn-danger";
                btn.Text = "Cancelar";
                LabelAgregar.Visible = true;
                TextBoxAgregar.Visible = true;
                ButtonAgregar.Visible = true;
            }
            else if (btn.Text == "Cancelar")
            {
                List<Carrito> datos = new List<Carrito>();
                datos = LeerCarrito();

                if(datos.Find(x => x.Codigo == row.Cells[1].Text) != null)
                {
                    Carrito datoAnterior = datos.Find(x => x.Codigo == row.Cells[1].Text);
                    datos.Remove(datoAnterior);
                    GuardarCarrito(datos);
                }
                //Después de cancelar el producto
                btn.CssClass = "btn btn-primary";
                btn.Text = "Agregar";
                //Limpiar campos
                LabelAgregar.Visible = false;
                TextBoxAgregar.Visible = false;
                TextBoxAgregar.Text = "";
                ButtonAgregar.Visible = false;
            }
        }
        protected void ButtonAgregar_click(object sender, EventArgs e)
        {
            List<Carrito> datos = new List<Carrito>();
            datos = LeerCarrito();
            Carrito carrito = new Carrito();
            carrito.Codigo = codigo.Text;
            carrito.Nombre = nombre.Text;
            carrito.Marca = marca.Text;
            carrito.Rest_existencia = Convert.ToDouble(TextBoxAgregar.Text);

            datos.Add(carrito);
            GuardarCarrito(datos);
        }
        protected void BtnMostrarCarrito_Click(object sender, EventArgs e)
        {
            List<Carrito> datos = new List<Carrito>();
            datos = LeerCarrito();

            GridViewCarrito.DataSource = datos;
            GridViewCarrito.DataBind();
            //Limpiar campos
            LabelAgregar.Visible = false;
            TextBoxAgregar.Visible = false;
            TextBoxAgregar.Text = "";
            ButtonAgregar.Visible = false;
        }
        //Clientes
        private void GuardarCliente(List<Cliente> dato)
        {
            string json = JsonConvert.SerializeObject(dato);
            string archivo = Server.MapPath("~/json/Clientes.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        private List<Cliente> LeerClientes()
        {
            List<Cliente> data = new List<Cliente>();
            string archivo = Server.MapPath("~/json/Clientes.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            if (jsonStream != null)
                data = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return data;
        }
        //Factura
        private void GuardarFactura(List<Factura> dato)
        {
            string json = JsonConvert.SerializeObject(dato);
            string archivo = Server.MapPath("~/json/Facturas.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        private List<Factura> LeerFacturas()
        {
            List<Factura> data = new List<Factura>();
            string archivo = Server.MapPath("~/json/Facturas.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            if (jsonStream != null)
                data = JsonConvert.DeserializeObject<List<Factura>>(json);
            return data;
        }
        //Detalle de factura
        private void GuardarDetalle(List<Detalle> dato)
        {
            string json = JsonConvert.SerializeObject(dato);
            string archivo = Server.MapPath("~/json/Detalle.json");
            System.IO.File.WriteAllText(archivo, json);
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
        //Reporte de mas vendidos
        private void GuardarRep(List<RepMasVendidos> dato)
        {
            string json = JsonConvert.SerializeObject(dato);
            string archivo = Server.MapPath("~/json/RepMasVendidos.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        private List<RepMasVendidos> LeerRep()
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
        protected void ButtonBuscar_click(object sender, EventArgs e)
        {
            List<Cliente> datos = new List<Cliente>();
            datos = LeerClientes();
            if (datos.Find(x => x.Nit == TextBoxNit.Text) != null)
            {
                Cliente cliente = datos.Find(x => x.Nit == TextBoxNit.Text);
                TextBoxNitRead.Text = cliente.Nit;
                TextBoxNombreCliente.Text = cliente.Nombre;
                TextBoxApellidoCliente.Text = cliente.Apellido;
                TextBoxDireccionCliente.Text = cliente.Direccion;
                TextBoxTelefonoCliente.Text = cliente.Telefono;
                LabelNit.Text = "Cliente existente";
                PanelCliente.Visible = true;
                PanelCliente.Enabled = false;
                TextBoxNitFactura.Text = TextBoxNitRead.Text;
                PanelFactura.Visible = true;
                List<Factura> facturas;
                facturas = LeerFacturas();
                if (facturas.Count != 0)
                    TextBoxNoFactura.Text = Convert.ToString(Convert.ToInt32(facturas.Last().NoFactura) + 1);
                else
                    TextBoxNoFactura.Text = "0";
                
            }
            else
            {
                LabelNit.Text = "No se encontró el cliente";
                PanelCliente.Visible = true;
                PanelCliente.Enabled = true;
                TextBoxNitRead.ReadOnly = true;
                TextBoxNitRead.Text = TextBoxNit.Text;
                TextBoxNombreCliente.Text = "";
                TextBoxApellidoCliente.Text = "";
                TextBoxDireccionCliente.Text = "";
                TextBoxTelefonoCliente.Text = "";
            }
        }
        protected void ButtonGuardarCliente_click(object sender, EventArgs e)
        {
            List<Cliente> datos = new List<Cliente>();
            datos = LeerClientes();

            Cliente cliente = new Cliente();
            cliente.Nit = TextBoxNitRead.Text;
            cliente.Nombre = TextBoxNombreCliente.Text;
            cliente.Apellido = TextBoxApellidoCliente.Text;
            cliente.Direccion = TextBoxDireccionCliente.Text;
            cliente.Telefono = TextBoxTelefonoCliente.Text;

            datos.Add(cliente);
            GuardarCliente(datos);
            LabelNit.Text = "Cliente ingresado con éxito, proceda a ingresar los datos de la factura";
            PanelCliente.Enabled = false;
            TextBoxNitFactura.Text = TextBoxNitRead.Text;
            PanelFactura.Visible = true;

            //Factura
            List<Factura> facturas;
            facturas = LeerFacturas();
            if (facturas.Count != 0)
                TextBoxNoFactura.Text = Convert.ToString(Convert.ToInt32(facturas.Last().NoFactura) + 1);
            else
                TextBoxNoFactura.Text = "0";
        }
        protected void CalendarFecha_SelectionChanged(object sender, EventArgs e)
        {
            TextBoxFecha.Text = CalendarFecha.SelectedDate.ToString("dd/MM/yyyy");
        }
        protected void ButtonGuardarFactura_click(object sender, EventArgs e)
        {
            //Guardar factura
            List<Factura> datosFactura = new List<Factura>();
            datosFactura = LeerFacturas();

            Factura factura = new Factura();
            factura.NoFactura = TextBoxNoFactura.Text;
            factura.Nit = TextBoxNitFactura.Text;
            factura.Fecha = Convert.ToDateTime(TextBoxFecha.Text);
            factura.Estado = TextBoxEstado.Text;

            datosFactura.Add(factura);
            List<Factura> datosFacturaOrdenados =  datosFactura.OrderBy(x => x.NoFactura).ToList();

            //Guardar detalle
            List<Detalle> datosDetalle = new List<Detalle>();
            datosDetalle = LeerDetalle();

            List<Carrito> listaCarrito = new List<Carrito>();
            listaCarrito = LeerCarrito();

            List<Producto> listaProductos = new List<Producto>();
            listaProductos = LeerJson();

            List<RepMasVendidos> listaRep = new List<RepMasVendidos>();
            listaRep = LeerRep();

            foreach (Carrito icarro in listaCarrito)
            {
                Detalle detalle = new Detalle();
                Producto producto = new Producto();
                RepMasVendidos rep = new RepMasVendidos();

                //Detalle
                detalle.Codigo_producto = icarro.Codigo;
                detalle.Cantidad = icarro.Rest_existencia;
                detalle.NoFactura = factura.NoFactura;
                detalle.Fecha = factura.Fecha;

                datosDetalle.Add(detalle);
                
                //Actualizar existencia
                Producto productoAnterior = listaProductos.Find(x => x.Codigo == icarro.Codigo);
                producto = productoAnterior;
                producto.Existencia = producto.Existencia - icarro.Rest_existencia;

                listaProductos.Remove(productoAnterior);
                listaProductos.Add(producto);

                //Reporte mas ventas
                rep.Codigo = producto.Codigo;
                rep.Nombre = producto.Nombre;
                rep.Marca = producto.Marca;
                if (listaRep.Exists(x => x.Codigo == producto.Codigo))
                {
                    rep.Cantidad = rep.Cantidad + Convert.ToInt32(icarro.Rest_existencia);
                    RepMasVendidos repAnterior = listaRep.Find(x => x.Codigo == producto.Codigo);
                    listaRep.Remove(repAnterior);
                    listaRep.Add(rep);
                }
                else
                {
                    rep.Cantidad = Convert.ToInt32(icarro.Rest_existencia);
                    listaRep.Add(rep);
                }
                
            }
            List<RepMasVendidos> datosRMVOrdenados = listaRep.OrderByDescending(x => x.Cantidad).ToList();
            //Eliminar Carrito
            listaCarrito.Clear();
            //Guardar todo
            GuardarFactura(datosFacturaOrdenados);
            GuardarDetalle(datosDetalle);
            GuardarJson(listaProductos);
            GuardarRep(datosRMVOrdenados);
            GuardarCarrito(listaCarrito);
            LabelFactura.Text = "Datos de factura ingresados con éxito";
        }
    }
}