using System;
using System.Web.UI.WebControls;

namespace Examen
{
    public partial class _Default : System.Web.UI.Page
    {
        OperacionesUsuarios operacionesUsuarios = new OperacionesUsuarios();
        OperacionesTecnicos operacionesTecnicos = new OperacionesTecnicos();
        OperacionesEquipos operacionesEquipos = new OperacionesEquipos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarUsuarios();
                MostrarTecnicos();
                MostrarEquipos();
            }
        }
        protected void CargarDatosEquipos()
        {
            OperacionesEquipos operacionesEquipos = new OperacionesEquipos();
            GridViewEquipos.DataSource = operacionesEquipos.MostrarEquipos();
            GridViewEquipos.DataBind();
        }
        protected void CargarDatosUsuarios()
        {
            OperacionesUsuarios operacionesUsuarios = new OperacionesUsuarios();
            GridViewUsuarios.DataSource = operacionesUsuarios.MostrarUsuarios();
            GridViewUsuarios.DataBind();
        }
        protected void MostrarUsuarios()
        {
            GridViewUsuarios.DataSource = operacionesUsuarios.MostrarUsuarios();
            GridViewUsuarios.DataBind();
        }

        protected void MostrarTecnicos()
        {
            GridViewTecnicos.DataSource = operacionesTecnicos.MostrarTecnicos();
            GridViewTecnicos.DataBind();
        }

        protected void MostrarEquipos()
        {
            GridViewEquipos.DataSource = operacionesEquipos.MostrarEquipos();
            GridViewEquipos.DataBind();
        }

        protected void GridViewUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewUsuarios.EditIndex = e.NewEditIndex;
            MostrarUsuarios();
        }

        protected void GridViewUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int usuarioID = Convert.ToInt32(GridViewUsuarios.DataKeys[e.RowIndex].Value);
            operacionesUsuarios.EliminarUsuario(usuarioID);
            MostrarUsuarios();
        }
        protected void GridViewUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewUsuarios.Rows[e.RowIndex];

            if (row.RowType == DataControlRowType.DataRow && GridViewUsuarios.EditIndex == e.RowIndex)
            {
                int usuarioID = Convert.ToInt32(GridViewUsuarios.DataKeys[e.RowIndex].Value);
                TextBox txtNombre = row.FindControl("txtNombre") as TextBox;
                TextBox txtCorreoElectronico = row.FindControl("txtCorreoElectronico") as TextBox;
                TextBox txtTelefono = row.FindControl("txtTelefono") as TextBox;

                if (txtNombre != null && txtCorreoElectronico != null && txtTelefono != null)
                {

                    Console.WriteLine("UsuarioID: " + usuarioID);

                    Console.WriteLine("Nuevo nombre: " + (txtNombre.Text ?? "N/A"));
                    Console.WriteLine("Nuevo correo: " + (txtCorreoElectronico.Text ?? "N/A"));
                    Console.WriteLine("Nuevo teléfono: " + (txtTelefono.Text ?? "N/A"));
                }
            }

            GridViewUsuarios.EditIndex = -1;
            CargarDatosUsuarios();
        }

        protected void GridViewUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewUsuarios.EditIndex = -1; 
            CargarDatosUsuarios();
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreUsuario.Text;
            string correo = txtCorreoUsuario.Text;
            string telefono = txtTelefonoUsuario.Text;

            operacionesUsuarios.InsertarUsuario(nombre, correo, telefono);
            MostrarUsuarios();
        }

        protected void GridViewTecnicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewTecnicos.EditIndex = e.NewEditIndex;
            MostrarTecnicos(); 
        }

        protected void GridViewTecnicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTecnicos.EditIndex = -1;
            MostrarTecnicos();
        }

        protected void GridViewTecnicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int tecnicoID = Convert.ToInt32(GridViewTecnicos.DataKeys[e.RowIndex].Value);
            TextBox txtNombreTecnico = (TextBox)GridViewTecnicos.Rows[e.RowIndex].FindControl("txtNombreTecnico");
            TextBox txtApellidoTecnico = (TextBox)GridViewTecnicos.Rows[e.RowIndex].FindControl("txtApellidoTecnico");
            TextBox txtEspecialidadTecnico = (TextBox)GridViewTecnicos.Rows[e.RowIndex].FindControl("txtEspecialidadTecnico");
            TextBox txtEmailTecnico = (TextBox)GridViewTecnicos.Rows[e.RowIndex].FindControl("txtEmailTecnico");
            TextBox txtTelefonoTecnico = (TextBox)GridViewTecnicos.Rows[e.RowIndex].FindControl("txtTelefonoTecnico");

            operacionesTecnicos.ActualizarTecnico(tecnicoID, txtNombreTecnico.Text, txtApellidoTecnico.Text, txtEspecialidadTecnico.Text, txtEmailTecnico.Text, txtTelefonoTecnico.Text);

            GridViewTecnicos.EditIndex = -1;
            MostrarTecnicos();
        }

        protected void GridViewTecnicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int tecnicoID = Convert.ToInt32(GridViewTecnicos.DataKeys[e.RowIndex].Value);
            operacionesTecnicos.EliminarTecnico(tecnicoID);
            MostrarTecnicos();
        }

        protected void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreTecnico.Text;
            string apellido = txtApellidoTecnico.Text;
            string especialidad = txtEspecialidadTecnico.Text;
            string email = txtEmailTecnico.Text;
            string telefono = txtTelefonoTecnico.Text;

            operacionesTecnicos.InsertarTecnico(nombre, apellido, especialidad, email, telefono);
            MostrarTecnicos(); 
        }

        protected void GridViewEquipos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEquipos.EditIndex = e.NewEditIndex;
            CargarDatosEquipos();
        }

        protected void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            string nombreEquipo = txtNombreEquipo.Text;
            string descripcion = txtDescripcionEquipo.Text;
            DateTime fechaAdquisicion = DateTime.Parse(txtFechaAdquisicionEquipo.Text);
            string estado = txtEstadoEquipo.Text;
            operacionesEquipos.InsertarEquipo(nombreEquipo, descripcion, fechaAdquisicion, estado);
            CargarDatosEquipos();
        }

        protected void GridViewEquipos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEquipos.EditIndex = -1;
            CargarDatosEquipos();
        }
        protected void GridViewEquipos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int equipoID = Convert.ToInt32(GridViewEquipos.DataKeys[e.RowIndex].Value);
            TextBox txtNombreEquipo = (TextBox)GridViewEquipos.Rows[e.RowIndex].FindControl("txtNombreEquipo");
            TextBox txtDescripcionEquipo = (TextBox)GridViewEquipos.Rows[e.RowIndex].FindControl("txtDescripcionEquipo");
            TextBox txtFechaAdquisicionEquipo = (TextBox)GridViewEquipos.Rows[e.RowIndex].FindControl("txtFechaAdquisicionEquipo");
            TextBox txtEstadoEquipo = (TextBox)GridViewEquipos.Rows[e.RowIndex].FindControl("txtEstadoEquipo");

            DateTime fechaAdquisicion = DateTime.Parse(txtFechaAdquisicionEquipo.Text);

            operacionesEquipos.ActualizarEquipo(equipoID, txtNombreEquipo.Text, txtDescripcionEquipo.Text, fechaAdquisicion, txtEstadoEquipo.Text);

            GridViewEquipos.EditIndex = -1;
            CargarDatosEquipos();
        }

        protected void GridViewEquipos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int equipoID = Convert.ToInt32(GridViewEquipos.DataKeys[e.RowIndex].Value);
            operacionesEquipos.EliminarEquipo(equipoID);
            CargarDatosEquipos(); 
        }
    }
}





