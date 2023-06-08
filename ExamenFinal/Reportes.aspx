<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ExamenFinal.Reportes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Reportes</h1>
            <p class="lead">
                Reporte de Productos más vendidos
                <asp:Button ID="ButtonMostrarRep1" runat="server" Text="Mostrar" OnClick="ButtonMostrarRep1_Click" />
                <asp:GridView ID="GridViewRep1" runat="server" AutoGenerateColumns="False" class="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Descripción" />
                    </Columns>
                </asp:GridView>
            </p>
            <p class="lead">
                <asp:Panel ID="PanelRep2y3" GroupingText="Reporte de ventas totales y ganancias" runat="server">
                    <asp:Calendar ID="CalendarFechaInicial" runat="server" BackColor="White" BorderColor="#3366CC" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="130px" Width="154px" BorderWidth="1px" OnSelectionChanged="CalendarFechaInicial_SelectionChanged">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" Font-Bold="True" BorderWidth="1px" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                    <br />
                    Fecha inicial:
                    <asp:TextBox ID="TextBoxFechaInicial" runat="server" Enabled="false"></asp:TextBox>
                    <br /><br />

                    <asp:Calendar ID="CalendarFechaFinal" runat="server" BackColor="White" BorderColor="#3366CC" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="130px" Width="154px" BorderWidth="1px" OnSelectionChanged="CalendarFechaFinal_SelectionChanged">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" Font-Bold="True" BorderWidth="1px" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                    <br />
                    Fecha final:
                    <asp:TextBox ID="TextBoxFechaFinal" runat="server" Enabled="false"></asp:TextBox>
                    <br />
                </asp:Panel>
                <br />
                <asp:Button ID="ButtonMostrarRep2" runat="server" Text="Mostrar reporte de las ventas totales" OnClick="ButtonMostrarRep2_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonMostrarRep3" runat="server" Text="Mostrar reporte de ganancias" OnClick="ButtonMostrarRep3_Click" />
                <br /> <br />
                <asp:Label ID="LabelRep2Y3" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBoxCantidad" runat="server" Enabled="false"></asp:TextBox>
            </p>
        </section>
    </main>

</asp:Content>
