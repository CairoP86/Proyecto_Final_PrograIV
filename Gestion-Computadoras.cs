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
    public partial class compu_mantenimiento : Form
    {
        public compu_mantenimiento()
        {
            InitializeComponent();
        }

        private void cargarComputadoras() {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM Computadoras";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
                dtvComputadoras.DataSource = dt;
            }
        }

        private void limpiarCampos()
        {
            txtMarca.Clear();
            txtSerie.Clear();
            cmbTipo.SelectedIndex = -1;
            cmbDepartamento.SelectedIndex = -1;
            cbmAsignado.SelectedIndex = -1;

            cbmCampo.SelectedIndex = -1;
            cbmDato.Items.Clear();
            cbmDato.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<string> filtros = new List<string>();
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                filtros.Add("Marca = @marca");
                parametros.Add(new SqlParameter("@marca", txtMarca.Text));
            }

            if (!string.IsNullOrWhiteSpace(txtSerie.Text))
            {
                filtros.Add("Serie = @serie");
                parametros.Add(new SqlParameter("@serie", txtSerie.Text));
            }

            if (!string.IsNullOrWhiteSpace(cmbTipo.Text))
            {
                filtros.Add("TipoEquipo = @tipo");
                parametros.Add(new SqlParameter("@tipo", cmbTipo.Text));
            }

            if (!string.IsNullOrWhiteSpace(cmbDepartamento.Text))
            {
                filtros.Add("IdDepartamento = @dep");
                parametros.Add(new SqlParameter("@dep", cmbDepartamento.Text));
            }

            if (!string.IsNullOrWhiteSpace(cbmAsignado.Text))
            {
                filtros.Add("IdEmpleado = @emp");
                parametros.Add(new SqlParameter("@emp", cbmAsignado.Text));
            }

            string consulta = "SELECT * FROM Computadoras";

            if (filtros.Count > 0)
            {
                consulta += " WHERE " + string.Join(" AND ", filtros);
            }

            DataTable dt = new DataTable();

            using (SqlConnection con = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.AddRange(parametros.ToArray());

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            dtvComputadoras.DataSource = dt;
        }

        private void cbmCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbmDato.SelectedIndex = -1;
            cbmDato.Items.Clear();

            string columna = cbmCampo.SelectedItem.ToString();
            string consulta = $"SELECT DISTINCT {columna} FROM Computadoras WHERE {columna} IS NOT NULL";

            using (SqlConnection con = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbmDato.Items.Add(reader[columna].ToString());
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void compu_mantenimiento_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM Computadoras";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.ObtenerConexion());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataColumn nombre in dt.Columns) { 
                cbmCampo.Items.Add(nombre.ColumnName);
            }

            cargarComputadoras();
        }

        private void cbmDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            string columna = cbmCampo.SelectedItem.ToString();
            string valor = cbmDato.SelectedItem.ToString();

            string consulta = $"SELECT * FROM Computadoras WHERE {columna} = @valor";

            DataTable dt = new DataTable();

            using (SqlConnection con = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.AddWithValue("@valor", valor);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            dtvComputadoras.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                txtMarca.Text = row["Marca"].ToString();
                cmbTipo.Text = row["TipoEquipo"].ToString();
                txtSerie.Text = row["Serie"].ToString();
                cmbDepartamento.Text = row["IdDepartamento"].ToString();
                cbmAsignado.Text = row["IdEmpleado"].ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtMarca.Text) ||
                string.IsNullOrWhiteSpace(txtSerie.Text) ||
                string.IsNullOrWhiteSpace(cmbTipo.Text) ||
                string.IsNullOrWhiteSpace(cmbDepartamento.Text) ||
                string.IsNullOrWhiteSpace(cbmAsignado.Text))
            {
                MessageBox.Show("Debe completar todos los campos para registrar la computadora.",
                                "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string consulta = @"INSERT INTO Computadoras 
                        (Marca, TipoEquipo, Serie, IdDepartamento, IdEmpleado)
                        VALUES (@marca, @tipo, @serie, @dep, @emp)";

            using (SqlConnection con = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                cmd.Parameters.AddWithValue("@tipo", cmbTipo.Text);
                cmd.Parameters.AddWithValue("@serie", txtSerie.Text);
                cmd.Parameters.AddWithValue("@dep", cmbDepartamento.Text);
                cmd.Parameters.AddWithValue("@emp", cbmAsignado.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Computadora agregada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            cargarComputadoras(); 
            limpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dtvComputadoras.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una computadora para actualizar.", "Advertencia",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // IDs tomados directamente del DataGridView
            int id = Convert.ToInt32(dtvComputadoras.CurrentRow.Cells["IdComputadora"].Value);

            if (string.IsNullOrWhiteSpace(txtMarca.Text) ||
                string.IsNullOrWhiteSpace(txtSerie.Text) ||
                string.IsNullOrWhiteSpace(cmbTipo.Text) ||
                string.IsNullOrWhiteSpace(cmbDepartamento.Text) ||
                string.IsNullOrWhiteSpace(cbmAsignado.Text))
            {
                MessageBox.Show("Debe completar todos los campos.", "Campos incompletos",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string consulta = @"UPDATE Computadoras
                        SET Marca = @marca,
                            TipoEquipo = @tipo,
                            Serie = @serie,
                            IdDepartamento = @dep,
                            IdEmpleado = @emp
                        WHERE IdComputadora = @id";

            using (SqlConnection con = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                cmd.Parameters.AddWithValue("@tipo", cmbTipo.Text);
                cmd.Parameters.AddWithValue("@serie", txtSerie.Text);
                cmd.Parameters.AddWithValue("@dep", cmbDepartamento.Text);
                cmd.Parameters.AddWithValue("@emp", cbmAsignado.Text);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Computadora actualizada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            cargarComputadoras();
            limpiarCampos();
        }

        private void dtvComputadoras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dtvComputadoras.Rows[e.RowIndex];

                txtMarca.Text = fila.Cells["Marca"].Value.ToString();
                cmbTipo.Text = fila.Cells["TipoEquipo"].Value.ToString();
                txtSerie.Text = fila.Cells["Serie"].Value.ToString();
                cmbDepartamento.Text = fila.Cells["IdDepartamento"].Value.ToString();
                cbmAsignado.Text = fila.Cells["IdEmpleado"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtvComputadoras.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una computadora para eliminar.", "Advertencia",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tomamos el ID directamente del DataGridView
            int id = Convert.ToInt32(dtvComputadoras.CurrentRow.Cells["IdComputadora"].Value);

            
            var confirm = MessageBox.Show("¿Seguro que desea eliminar esta computadora?",
                                          "Confirmar eliminación",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            string consulta = "DELETE FROM Computadoras WHERE IdComputadora = @id";

            using (SqlConnection con = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Computadora eliminada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            cargarComputadoras();
            limpiarCampos();
        }
    }
}
