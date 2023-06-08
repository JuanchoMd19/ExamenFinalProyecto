<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="ExamenFinal.Productos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Productos</h1>
            <p class="lead">
                Código del producto
               
                <asp:TextBox ID="TextBoxCodigo" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                Nombre
               
                <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                Marca
               
                <asp:TextBox ID="TextBoxMarca" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                Descripción
               
                <asp:TextBox ID="TextBoxDescripcion" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                Precio de compra
               
                <asp:TextBox ID="TextBoxP_compra" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                Precio de venta
               
                <asp:TextBox ID="TextBoxP_venta" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                Existencia
               
                <asp:TextBox ID="TextBoxExistencia" runat="server"></asp:TextBox>
            </p>
            <p class="lead" id="subirImagen">
                <asp:label ID="labelImagen" runat="server">Subir Imagen</asp:label>
                <asp:FileUpload ID="FileUploadImagen" class="btn btn-secondary" runat="server" />
            </p>
            <p class="lead">
                <asp:Button ID="ButtonGuardar" runat="server" class="btn btn-primary" Text="Guardar" OnClick="ButtonGuardar_Click" />
                <asp:Button ID="ButtonEditar" runat="server" class="btn btn-success" Text="Editar" OnClick="ButtonEditar_Click" />
                <asp:Button ID="ButtonEliminar" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="ButtonEliminar_Click" />
                &nbsp;<asp:Label ID="LabelEstado" runat="server"></asp:Label>
            </p>
            <p class="lead">
                Mostrar Productos
               
                <asp:Button ID="ButtonMostrar" runat="server" Text="Mostrar" OnClick="ButtonMostrar_Click" />
                <asp:GridView ID="GridViewProductos" runat="server" AutoGenerateColumns="False" class="table table-striped">
                    <Columns>
                        <asp:ImageField DataImageUrlField="Imagen" ControlStyle-Width="100" ControlStyle-Height="100" HeaderText="Imagen">
                            <ControlStyle Height="100px" Width="100px"></ControlStyle>
                        </asp:ImageField>
                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="P_compra" HeaderText="Precio de compra" />
                        <asp:BoundField DataField="P_venta" HeaderText="Precio de venta" />
                        <asp:BoundField DataField="Existencia" HeaderText="Existencia" />
                         <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button ID="ButtonCallEditar" runat="server" class="btn btn-success" Text="Editar" OnClick="ButtonCallEditar_Click"  />
                                <asp:Button ID="ButtonCallEliminar" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="ButtonCallEliminar_Click"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </p>
            <p class="lead">&nbsp;</p>
        </section>
    </main>

</asp:Content>
