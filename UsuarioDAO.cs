using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_PrograIV
{
    public class UsuarioDAO
    {
        public string ValidarLogin(string cedula, string clavePlano)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT Rol, ClaveHash FROM Usuarios WHERE Cedula = @ced",
                    con
                );

                cmd.Parameters.AddWithValue("@ced", cedula);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return null;

                    string hashBD = dr["ClaveHash"].ToString();
                    string hashIngresado = Seguridad.GenerarHash(clavePlano);

                    if (hashBD != hashIngresado)
                        return null;

                    return dr["Rol"].ToString();
                }
            }
        }

        public bool ClaveExpirada(string cedula)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                string sql = @"SELECT DATEDIFF(DAY, FechaCambioClave, GETDATE())
                       FROM Usuarios
                       WHERE Cedula = @ced";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ced", cedula);

                int dias = Convert.ToInt32(cmd.ExecuteScalar());

                return dias >= 90;
            }
        }





        public string ObtenerNombreUsuario(string cedula)
        {
            string nombre = "";

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT Nombre FROM Usuarios WHERE Cedula = @ced",
                    con);

                cmd.Parameters.AddWithValue("@ced", cedula);
                var result = cmd.ExecuteScalar();

                if (result != null)
                    nombre = result.ToString();
            }

            return nombre;
        }





    }
}