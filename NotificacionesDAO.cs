using System;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Final_PrograIV
{
    internal class NotificacionesDAO
    {
        // Crear notificación
        public static void Crear(string cedulaDestino, int? idTiquete, string mensaje)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                string query = @"INSERT INTO Notificaciones 
                                 (CedulaDestino, IdTiquete, Mensaje)
                                 VALUES (@cedula, @idTiquete, @mensaje)";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@cedula", cedulaDestino);
                cmd.Parameters.AddWithValue("@idTiquete", (object)idTiquete ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@mensaje", mensaje);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static int ContarNoVistas(string cedulaDestino)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM Notificaciones WHERE CedulaDestino = @ced AND Visto = 0";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@ced", cedulaDestino);

                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static void MarcarTodasComoVistas(string cedulaDestino)
{
    using (SqlConnection cn = Conexion.ObtenerConexion())
    {
        string query = @"UPDATE Notificaciones 
                         SET Visto = 1 
                         WHERE CedulaDestino = @ced AND Visto = 0";

        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.Parameters.AddWithValue("@ced", cedulaDestino);

        cn.Open();
        cmd.ExecuteNonQuery();
    }
}



        // Obtener notificaciones por cédula
        public static DataTable ObtenerPorUsuario(string cedulaDestino)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                string query = @"SELECT * FROM Notificaciones 
                                 WHERE CedulaDestino = @cedula
                                 ORDER BY Fecha DESC";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@cedula", cedulaDestino);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // Marcar como visto
        public static void MarcarComoVisto(int idNotificacion)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                string query = @"UPDATE Notificaciones SET Visto = 1
                                 WHERE IdNotificacion = @id";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", idNotificacion);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
