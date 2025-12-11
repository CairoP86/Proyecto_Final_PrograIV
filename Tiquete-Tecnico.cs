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
    public partial class Tiquete_Tecnico : Form
    {

        private string cedulaTecnico;   
        private int idTiqueteSeleccionado = -1;
        public Tiquete_Tecnico(string cedula)
        {
            InitializeComponent();
            cedulaTecnico = cedula;
        }

        private void CargarEstados()
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string query = @"
                    SELECT IdEstado, Nombre 
                    FROM EstadoTiquete
                    WHERE IdEstado IN (1, 3)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    cbmEstado.Items.Clear();

                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cbmEstado.DataSource = dt;
                    cbmEstado.DisplayMember = "Nombre";
                    cbmEstado.ValueMember = "IdEstado";
                    cbmEstado.SelectedIndex = -1; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estados: " + ex.Message);
            }
        }

        private void CargarTiquetesAsignados()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = @"
                SELECT 
	                T.IdTiquete,
	                T.Descripcion,
	                E.Nombre AS Estado,
	                T.FechaCreacion
                FROM Tiquetes T
                INNER JOIN EstadoTiquete E ON T.IdEstado = E.IdEstado
                WHERE T.TecnicoAsignado = @cedula";

                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@cedula", cedulaTecnico);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                dgvTiquetesTecnico.DataSource = dt;
            }
        }

        private void Tiquete_Tecnico_Load(object sender, EventArgs e)
        {
            CargarEstados();
            CargarTiquetesAsignados();
        }

        private void dgvTiquetesTecnico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idTiqueteSeleccionado =
                Convert.ToInt32(dgvTiquetesTecnico.CurrentRow.Cells["IdTiquete"].Value);

            txtDescripcion.Text =
                dgvTiquetesTecnico.CurrentRow.Cells["Descripcion"].Value.ToString();
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            if (idTiqueteSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un tiquete de la lista.");
                return;
            }

            if (cbmEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un nuevo estado.");
                return;
            }

            // Validamos SelectedValue
            if (cbmEstado.SelectedValue == null)
            {
                MessageBox.Show("Estado no válido, seleccione nuevamente.");
                return;
            }

            int nuevoEstado = Convert.ToInt32(cbmEstado.SelectedValue);

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string actualizar = @"
                UPDATE Tiquetes SET
                    IdEstado = @estado,
                    FechaAtencion = CASE
                        WHEN @estado = 3 THEN GETDATE()
                        ELSE FechaAtencion
                    END
                WHERE IdTiquete = @id";

                SqlCommand cmd = new SqlCommand(actualizar, conn);
                cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@id", idTiqueteSeleccionado);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Estado actualizado correctamente.");

            CargarTiquetesAsignados();
            txtDescripcion.Clear();
            idTiqueteSeleccionado = -1;
        }
    }
}
    

