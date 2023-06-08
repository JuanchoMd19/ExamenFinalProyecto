<%@ Page Title="POS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pos.aspx.cs" Inherits="ExamenFinal.Pos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <p class="lead">
                &nbsp;
                <asp:TextBox ID="codigo" runat="server" Visible="false"></asp:TextBox>
                <asp:TextBox ID="nombre" runat="server" Visible="false"></asp:TextBox>
                <asp:TextBox ID="marca" runat="server" Visible="false"></asp:TextBox>
            </p>
            <p class="lead">
                <asp:Label ID="LabelAgregar" runat="server">Agregue cantidad de existencia a vender: </asp:Label>
                <asp:TextBox ID="TextBoxAgregar" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonAgregar" runat="server" class="btn btn-primary" Text="Aceptar" OnClick="ButtonAgregar_click" />
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
                                <asp:Button ID="ButtonCallAgregar" runat="server" class="btn btn-primary" Text="Agregar" OnClick="ButtonCallAgregar_click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="LabelEstado" runat="server"></asp:Label>
            </p>
            <p class="lead">&nbsp;</p>
            <p class="lead">
                Mostrar carrito de compras
               
                <asp:Button ID="BtnMostrarCarrito" runat="server" Text="Mostrar" OnClick="BtnMostrarCarrito_Click" />
                <asp:GridView ID="GridViewCarrito" runat="server" AutoGenerateColumns="False" class="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Código del producto" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" />
                        <asp:BoundField DataField="Rest_existencia" HeaderText="Cantidad" />
                    </Columns>
                </asp:GridView>
            </p>
            <p class="lead">&nbsp;</p>
            <p class="lead">
                Ingrese NIT:
                <asp:TextBox ID="TextBoxNit" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonNit" runat="server" class="btn btn-primary" Text="Buscar" OnClick="ButtonBuscar_click" />
                <asp:Label ID="LabelNit" runat="server"></asp:Label>
            </p>
            <p class="lead">
                <asp:Panel ID="PanelCliente" GroupingText="Datos del cliente" runat="server" Visible="false">
                    NIT:
                    <asp:TextBox ID="TextBoxNitRead" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    Nombres:
                    <asp:TextBox ID="TextBoxNombreCliente" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    Apellidos:
                    <asp:TextBox ID="TextBoxApellidoCliente" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    Dirección:
                    <asp:TextBox ID="TextBoxDireccionCliente" runat="server"></asp:TextBox>
                    <br /><br />
                    Teléfono:
                    <asp:TextBox ID="TextBoxTelefonoCliente" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonGuardarCliente" runat="server" class="btn btn-primary" Text="Guardar cliente" OnClick="ButtonGuardarCliente_click" />
                </asp:Panel>
            </p>
            <p class="lead">
                <asp:Panel ID="PanelFactura" GroupingText="Datos de la factura" runat="server" Visible="false">
                    Número de factura:
                    <asp:TextBox ID="TextBoxNoFactura" runat="server" enabled="false"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    NIT:
                    <asp:TextBox ID="TextBoxNitFactura" runat="server" enabled="false"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    Estado:
                    <asp:TextBox ID="TextBoxEstado" runat="server"></asp:TextBox>
                    <br /><br />
                    Fecha:
                    <asp:TextBox ID="TextBoxFecha" runat="server"></asp:TextBox>
                    <br /><br />
                    <asp:Calendar ID="CalendarFecha" runat="server" BackColor="White" BorderColor="#3366CC" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="130px" Width="154px" BorderWidth="1px" OnSelectionChanged="CalendarFecha_SelectionChanged" Visible="true">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" Font-Bold="True" BorderWidth="1px" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                    <br /><br />
                    <asp:Button ID="ButtonGuardarFactura" runat="server" class="btn btn-primary" Text="Ingresar factura con productos" OnClick="ButtonGuardarFactura_click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LabelFactura" runat="server"></asp:Label>
                </asp:Panel>
            </p>
            <p class="lead">&nbsp;</p>
        </section>
    </main>

</asp:Content>
