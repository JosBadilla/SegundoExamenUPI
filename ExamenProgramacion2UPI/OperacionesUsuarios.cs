using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class OperacionesUsuarios
{
    private readonly string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

    public DataTable MostrarUsuarios()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
        }

        return dt;
    }

    public void InsertarUsuario(string nombre, string correo, string telefono)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (nombre, CorreoElectronico, Telefono) VALUES (@Nombre, @Correo, @Telefono)", con);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Correo", correo);
            cmd.Parameters.AddWithValue("@Telefono", telefono);
            cmd.ExecuteNonQuery();
        }
    }
    public void ActualizarUsuario(int id, string nombre, string correo, string telefono)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET nombre = @Nombre, CorreoElectronico = @Correo, Telefono = @Telefono WHERE UsuarioID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Correo", correo);
            cmd.Parameters.AddWithValue("@Telefono", telefono);
            cmd.ExecuteNonQuery();
        }
    }

    public void EliminarUsuario(int id)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Usuarios WHERE UsuarioID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
    }
}

