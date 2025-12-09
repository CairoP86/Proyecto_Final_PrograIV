using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_PrograIV
{
    internal class Conexion
    {
        private static string cadenaConexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=db_SoporteTI;Integrated Security=True";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }

}

