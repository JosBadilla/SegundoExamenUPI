using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Examen
{
    public class OperacionesEquipos
    {
        public DataTable MostrarEquipos()
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                con.Open();
                string query = "SELECT * FROM Equipos";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public void InsertarEquipo(string nombreEquipo, string descripcion, DateTime fechaAdquisicion, string estado)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Equipos (NombreEquipo, Descripcion, FechaAdquisicion, Estado) VALUES (@NombreEquipo, @Descripcion, @FechaAdquisicion, @Estado)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreEquipo", nombreEquipo);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@FechaAdquisicion", fechaAdquisicion);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarEquipo(int equipoID, string nombreEquipo, string descripcion, DateTime fechaAdquisicion, string estado)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Equipos SET NombreEquipo = @NombreEquipo, Descripcion = @Descripcion, FechaAdquisicion = @FechaAdquisicion, Estado = @Estado WHERE EquipoID = @EquipoID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreEquipo", nombreEquipo);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@FechaAdquisicion", fechaAdquisicion);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@EquipoID", equipoID);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarEquipo(int equipoID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Equipos WHERE EquipoID = @EquipoID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EquipoID", equipoID);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
