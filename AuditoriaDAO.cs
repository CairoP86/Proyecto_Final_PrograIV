using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_PrograIV
{
    internal class AuditoriaDAO
    {
        public static void Registrar(
         string cedula,
         string accion,
         string entidad,
         int? idEntidad,
         string detalle = null)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                string sql = @"INSERT INTO Auditoria
                           (CedulaUsuario, Accion, Entidad, IdEntidad, Detalle)
                           VALUES (@ced, @acc, @ent, @id, @det)";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ced", cedula);
                    cmd.Parameters.AddWithValue("@acc", accion);
                    cmd.Parameters.AddWithValue("@ent", entidad);
                    cmd.Parameters.AddWithValue("@id", (object)idEntidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@det", (object)detalle ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
    


