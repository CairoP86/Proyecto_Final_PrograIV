using System;
using System.Data.SqlClient;
using System.Text;

namespace Proyecto_Final_PrograIV
{
    public class UsuarioDAO
    {
        // =========================================
        // Cadena de conexión a la base de datos
        // =========================================
        private string cadenaConexion =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=db_SoporteTI;Integrated Security=True";

        // =========================================
        // Este método valida el login del usuario
        // Retorna el Rol si las credenciales son correctas
        // Retorna null si la cédula o clave no coinciden
        // =========================================
        public string ValidarLogin(string cedula, string clavePlano)
        {
            string rol = null;

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                string sql = @"SELECT Rol
                               FROM Usuarios
                               WHERE Cedula = @Cedula
                                 AND ClaveHash = @ClaveHash";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.Parameters.AddWithValue("@ClaveHash", GenerarHash(clavePlano));

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    rol = dr["Rol"].ToString();
            }

            return rol;
        }

        // =========================================
        // Este método indica si la contraseña ya expiró
        // Se considera expirada si han pasado 90 días
        // =========================================
        public bool ClaveExpirada(string cedula)
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                string sql = @"SELECT DATEDIFF(DAY, FechaCambioClave, GETDATE())
                               FROM Usuarios
                               WHERE Cedula = @ced";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@ced", cedula);

                cn.Open();
                int dias = Convert.ToInt32(cmd.ExecuteScalar());

                return dias >= 90;
            }
        }

        // =========================================
        // Este método indica si el usuario está obligado
        // a cambiar la contraseña al iniciar sesión
        // =========================================
        public bool DebeCambiarClave(string cedula)
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                string sql = @"SELECT DebeCambiarClave
                               FROM Usuarios
                               WHERE Cedula = @ced";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@ced", cedula);

                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        // =========================================
        // Este método obtiene el nombre del usuario
        // usando la cédula como identificador
        // =========================================
        public string ObtenerNombreUsuario(string cedula)
        {
            string nombre = "";

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                string sql = @"SELECT Nombre
                               FROM Usuarios
                               WHERE Cedula = @ced";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@ced", cedula);

                cn.Open();
                object resultado = cmd.ExecuteScalar();

                if (resultado != null)
                    nombre = resultado.ToString();
            }

            return nombre;
        }

        // =========================================
        // Este método genera el hash SHA256 de un texto
        // Se usa para guardar y comparar contraseñas
        // =========================================
        private string GenerarHash(string texto)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
