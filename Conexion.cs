using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_PrograIV
{
    internal class Conexion
    {
        private static string cadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_SoporteTI;Integrated Security=True";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        // Método de prueba opcional
        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (var con = ObtenerConexion())
                {
                    con.Open();
                    mensaje = "Conexión exitosa.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al conectar: " + ex.Message;
                return false;
            }
        }
    }
}
