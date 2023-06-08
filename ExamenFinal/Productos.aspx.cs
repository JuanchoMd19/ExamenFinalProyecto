using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json;
namespace ExamenFinal
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUploadImagen.Visible = true;
            labelImagen.Visible = true;
            ButtonGuardar.Visible = true;
            ButtonEditar.Visible = false;
            ButtonEliminar.Visible = false;
            LabelEstado.Text = "";
            TextBoxCodigo.Enabled = true;
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
        protected void ButtonMostrar_Click(object sender, EventArgs e)
        {
            List<Producto> productos = new List<Producto>();
            productos = LeerJson();

            GridViewProductos.DataSource = productos;
            GridViewProductos.DataBind();
            //Limpiar campos
            TextBoxCodigo.Text = "";
            TextBoxNombre.Text = "";
            TextBoxMarca.Text = "";
            TextBoxDescripcion.Text = "";
            TextBoxP_compra.Text = "";
            TextBoxP_venta.Text = "";
            TextBoxExistencia.Text = "";
        }
        private void GuardarJson(List<Producto> productos)
        {
            string json = JsonConvert.SerializeObject(productos);
            string archivo = Server.MapPath("~/json/Productos.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            List<Producto> productos = new List<Producto>();
            productos = LeerJson();

            Producto producto = new Producto();
            producto.Codigo = TextBoxCodigo.Text;
            producto.Nombre = TextBoxNombre.Text; 
            producto.Marca = TextBoxMarca.Text;
            producto.Descripcion = TextBoxDescripcion.Text;
            producto.P_compra = Convert.ToDouble(TextBoxP_compra.Text);
            producto.P_venta = Convert.ToDouble(TextBoxP_venta.Text);
            producto.Existencia = Convert.ToDouble(TextBoxExistencia.Text);

            string archivo = "~/imagenes/" + FileUploadImagen.FileName;
            producto.Imagen = archivo;

            string archivoOrigen = Path.GetFileName(FileUploadImagen.FileName);

            try
            {
                FileUploadImagen.SaveAs(Server.MapPath("~/imagenes/") + archivoOrigen);
                LabelEstado.Text = "Exitosamente Subido";
            }
            catch (Exception ex)
            {
                LabelEstado.Text = "No se pudo subir, se generó el siguiente error:  " + ex.Message;
            }

            productos.Add(producto);


            GuardarJson(productos);
            //Limpiar campos
            TextBoxCodigo.Text = "";
            TextBoxNombre.Text = "";
            TextBoxMarca.Text = "";
            TextBoxDescripcion.Text = "";
            TextBoxP_compra.Text = "";
            TextBoxP_venta.Text = "";
            TextBoxExistencia.Text = "";
        }
        protected void ButtonCallEditar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            TextBoxCodigo.Text = row.Cells[1].Text;
            TextBoxNombre.Text = row.Cells[2].Text;
            TextBoxMarca.Text = row.Cells[3].Text;
            TextBoxDescripcion.Text = row.Cells[4].Text;
            TextBoxP_compra.Text =  row.Cells[5].Text;
            TextBoxP_venta.Text = row.Cells[6].Text;
            TextBoxExistencia.Text = row.Cells[7].Text;
            FileUploadImagen.Visible = false;
            labelImagen.Visible = false;
            ButtonGuardar.Visible = false;
            ButtonEditar.Visible = true;
            ButtonEliminar.Visible = false;
            LabelEstado.Text = "";
            TextBoxCodigo.Enabled = false;
        }
        protected void ButtonEditar_Click(object sender, EventArgs e)
        {
            List<Producto> productos = new List<Producto>();
            productos = LeerJson();
            

            Producto productoAnterior = productos.Find(x => x.Codigo == TextBoxCodigo.Text);
            Producto producto = new Producto();

            producto.Codigo = TextBoxCodigo.Text;
            producto.Nombre = TextBoxNombre.Text;
            producto.Marca = TextBoxMarca.Text;
            producto.Descripcion = TextBoxDescripcion.Text;
            producto.P_compra = Convert.ToDouble(TextBoxP_compra.Text);
            producto.P_venta = Convert.ToDouble(TextBoxP_venta.Text);
            producto.Existencia = Convert.ToDouble(TextBoxExistencia.Text);
            producto.Imagen = productoAnterior.Imagen;

            productos.Remove(productoAnterior);
            productos.Add(producto);

            GuardarJson(productos);
            LabelEstado.Text = "Elemento Editado";
            //Relistar productos
            List<Producto> Mostrarproductos = new List<Producto>();
            Mostrarproductos = LeerJson();

            GridViewProductos.DataSource = Mostrarproductos;
            GridViewProductos.DataBind();
            //Limpiar campos
            TextBoxCodigo.Text = "";
            TextBoxNombre.Text = "";
            TextBoxMarca.Text = "";
            TextBoxDescripcion.Text = "";
            TextBoxP_compra.Text = "";
            TextBoxP_venta.Text = "";
            TextBoxExistencia.Text = "";
        }
        protected void ButtonCallEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            TextBoxCodigo.Text = row.Cells[1].Text;
            TextBoxNombre.Text = row.Cells[2].Text;
            TextBoxMarca.Text = row.Cells[3].Text;
            TextBoxDescripcion.Text = row.Cells[4].Text;
            TextBoxP_compra.Text = row.Cells[5].Text;
            TextBoxP_venta.Text = row.Cells[6].Text;
            TextBoxExistencia.Text = row.Cells[7].Text;
            FileUploadImagen.Visible = false;
            labelImagen.Visible = false;
            ButtonGuardar.Visible = false;
            ButtonEditar.Visible = false;
            ButtonEliminar.Visible = true;
            LabelEstado.Text = "¿Está seguro de eliminar este elemento?";
            TextBoxCodigo.Enabled = false;

        }
        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            List<Producto> productos = new List<Producto>();
            productos = LeerJson();


            Producto productoAnterior = productos.Find(x => x.Codigo == TextBoxCodigo.Text);
            productos.Remove(productoAnterior);

            GuardarJson(productos);
            LabelEstado.Text = "Elemento Eliminado";

            //Relistar productos
            List<Producto> Mostrarproductos = new List<Producto>();
            Mostrarproductos = LeerJson();

            GridViewProductos.DataSource = Mostrarproductos;
            GridViewProductos.DataBind();
            //Limpiar campos
            TextBoxCodigo.Text = "";
            TextBoxNombre.Text = "";
            TextBoxMarca.Text = "";
            TextBoxDescripcion.Text = "";
            TextBoxP_compra.Text = "";
            TextBoxP_venta.Text = "";
            TextBoxExistencia.Text = "";
        }
    }
}