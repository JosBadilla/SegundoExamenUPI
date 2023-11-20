<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Examen._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenimiento</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1>Mantenimiento de Usuarios</h1>
            <div>
                <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="UsuarioID"
                    OnRowEditing="GridViewUsuarios_RowEditing" OnRowCancelingEdit="GridViewUsuarios_RowCancelingEdit"
                    OnRowUpdating="GridViewUsuarios_RowUpdating" OnRowDeleting="GridViewUsuarios_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="UsuarioID" HeaderText="UsuarioID" ReadOnly="True" SortExpression="UsuarioID" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                        <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" SortExpression="CorreoElectronico" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <h3>Agregar Usuario</h3>
                <asp:TextBox ID="txtNombreUsuario" runat="server" placeholder="Nombre"></asp:TextBox>
                <asp:TextBox ID="txtCorreoUsuario" runat="server" placeholder="Correo Electrónico"></asp:TextBox>
                <asp:TextBox ID="txtTelefonoUsuario" runat="server" placeholder="Teléfono"></asp:TextBox>
                <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar" OnClick="btnAgregarUsuario_Click" />
            </div>
        </div>

<div class="container mt-5">
    <h1>Mantenimiento de Técnicos</h1>
    <asp:GridView ID="GridViewTecnicos" runat="server" AutoGenerateColumns="False" DataKeyNames="TecnicoID"
        OnRowEditing="GridViewTecnicos_RowEditing" OnRowCancelingEdit="GridViewTecnicos_RowCancelingEdit"
        OnRowUpdating="GridViewTecnicos_RowUpdating" OnRowDeleting="GridViewTecnicos_RowDeleting">
        <Columns>
            <asp:BoundField DataField="TecnicoID" HeaderText="TecnicoID" ReadOnly="True" SortExpression="TecnicoID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" SortExpression="Especialidad" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <asp:TextBox ID="txtNombreTecnico" runat="server" placeholder="Nombre"></asp:TextBox>
    <asp:TextBox ID="txtApellidoTecnico" runat="server" placeholder="Apellido"></asp:TextBox>
    <asp:TextBox ID="txtEspecialidadTecnico" runat="server" placeholder="Especialidad"></asp:TextBox>
    <asp:TextBox ID="txtEmailTecnico" runat="server" placeholder="Email"></asp:TextBox>
    <asp:TextBox ID="txtTelefonoTecnico" runat="server" placeholder="Teléfono"></asp:TextBox>
    <asp:Button ID="btnAgregarTecnico" runat="server" Text="Agregar Técnico" OnClick="btnAgregarTecnico_Click" />
</div>


<div class="container mt-5">
    <h1>Mantenimiento de Equipos</h1>
    <asp:GridView ID="GridViewEquipos" runat="server" AutoGenerateColumns="False" DataKeyNames="EquipoID"
        OnRowEditing="GridViewEquipos_RowEditing" OnRowCancelingEdit="GridViewEquipos_RowCancelingEdit"
        OnRowUpdating="GridViewEquipos_RowUpdating" OnRowDeleting="GridViewEquipos_RowDeleting">
        <Columns>
            <asp:BoundField DataField="EquipoID" HeaderText="EquipoID" ReadOnly="True" SortExpression="EquipoID" />
            <asp:BoundField DataField="NombreEquipo" HeaderText="Nombre Equipo" SortExpression="NombreEquipo" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
            <asp:BoundField DataField="FechaAdquisicion" HeaderText="Fecha Adquisición" SortExpression="FechaAdquisicion" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <asp:TextBox ID="txtNombreEquipo" runat="server" placeholder="Nombre del Equipo"></asp:TextBox>
    <asp:TextBox ID="txtDescripcionEquipo" runat="server" placeholder="Descripción"></asp:TextBox>
    <asp:TextBox ID="txtFechaAdquisicionEquipo" runat="server" placeholder="Fecha de Adquisición"></asp:TextBox>
    <asp:TextBox ID="txtEstadoEquipo" runat="server" placeholder="Estado"></asp:TextBox>
    <asp:Button ID="btnAgregarEquipo" runat="server" Text="Agregar Equipo" OnClick="btnAgregarEquipo_Click" />
</div>

    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.1/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>


