using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_PrograIV
{
    public class UsuarioDAO
    {
        public string ValidarLogin(string cedula, string clave)
        {
            string rol = null;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT Rol FROM Usuarios WHERE Cedula=@ced AND Clave=@cla", con);

                cmd.Parameters.AddWithValue("@ced", cedula);
                cmd.Parameters.AddWithValue("@cla", clave);


                var result = cmd.ExecuteScalar();

                if (result != null)
                    rol = result.ToString();
            }

            return rol;  // Devuelve: Empleado, Tecnico o TI
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