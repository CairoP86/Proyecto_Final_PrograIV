using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_PrograIV
{
    public partial class Tiquete_Empleado : Form
    {
        private string cedulaUsuarioActual;
        public Tiquete_Empleado(string cedula)
        {
            InitializeComponent();
            cedulaUsuarioActual = cedula;
        }

        public DataTable CargarMisTiquetes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        T.IdTiquete,
                        T.Descripcion,
                        E.Nombre AS Estado,
                        T.FechaCreacion,
                        T.TecnicoAsignado
                    FROM Tiquetes T
                    INNER JOIN EstadoTiquete E
                        ON T.IdEstado = E.IdEstado
                    WHERE T.CedulaEmpleado = @ced
                    ORDER BY T.IdTiquete DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ced", cedulaUsuarioActual);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        private void Tiquete_Empleado_Load(object sender, EventArgs e)
        {
           
            txtCedula.Text = cedulaUsuarioActual;
            txtCedula.Enabled = false;

            
            dgvTiquetes.DataSource = CargarMisTiquetes();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción del problema.",
                                "Campos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string insertar = @"
                    INSERT INTO Tiquetes (CedulaEmpleado, Descripcion, IdEstado)
                    VALUES (@ced, @desc, 1)";   

                using (SqlCommand cmd = new SqlCommand(insertar, conn))
                {
                    cmd.Parameters.AddWithValue("@ced", cedulaUsuarioActual);
                    cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text.Trim());

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Tiquete creado correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            
            dgvTiquetes.DataSource = CargarMisTiquetes();

            // Limpiar campo
            txtDescripcion.Clear();
        }
    }
}
