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
    public partial class Software : Form
    {
        private int idSoftwareSeleccionado = 0;
        public Software()
        {
            InitializeComponent();
        }

        public DataTable CargarSoftware()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = @"SELECT IdSoftware, Nombre, Version, TipoLicencia, 
                                   StockLicencias, LicenciasDisponibles, LicenciasInstaladas 
                            FROM Software";

                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable BuscarSoftware()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = @"SELECT Nombre, Version, TipoLicencia, 
                                   StockLicencias, LicenciasDisponibles, LicenciasInstaladas
                            FROM Software
                            WHERE 1 = 1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    consulta += " AND Nombre LIKE @nom";
                    cmd.Parameters.AddWithValue("@nom", "%" + txtNombre.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtVersion.Text))
                {
                    consulta += " AND Version LIKE @ver";
                    cmd.Parameters.AddWithValue("@ver", "%" + txtVersion.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(cbmTipoLic.Text))
                {
                    consulta += " AND TipoLicencia LIKE @tipo";
                    cmd.Parameters.AddWithValue("@tipo", "%" + cbmTipoLic.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtStockLic.Text))
                {
                    consulta += " AND StockLicencias LIKE @stock";
                    cmd.Parameters.AddWithValue("@stock", "%" + txtStockLic.Text + "%");
                }

                cmd.CommandText = consulta;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtVersion.Clear();
            cbmTipoLic.SelectedIndex = -1;
            txtStockLic.Clear();


            txtLicenDisponibles.Clear();
            txtTipoLicInstalada.Clear();


            cbmCampo.SelectedIndex = -1;
            
            

            txtNombre.Focus(); 
        }

        private void CargarCampos()
        {
            cbmCampo.Items.Clear();

            cbmCampo.Items.Add("Nombre");
            cbmCampo.Items.Add("Version");
            cbmCampo.Items.Add("TipoLicencia");
        }

        private void cbmCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmCampo.SelectedIndex == -1)
                return;

           

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string columna = cbmCampo.SelectedItem.ToString();
                string consulta = $"SELECT DISTINCT {columna} FROM Software ORDER BY {columna}";

                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        
                    }
                }
            }
        }

        private void cbmDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmCampo.SelectedIndex == -1 )
                return;

            string campo = cbmCampo.SelectedItem.ToString();
           

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = $"SELECT * FROM Software WHERE {campo} = @val";

                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    dgvSoftware.DataSource = dt;
                }
            }
        }

        private void cmbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbVersion_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbmTipoLic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbmTipoLicInstalada_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbStockLic_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbLicenDisponibles_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatosUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvSoftware.Rows[e.RowIndex];

            idSoftwareSeleccionado = Convert.ToInt32(fila.Cells["IdSoftware"].Value);

            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtVersion.Text = fila.Cells["Version"].Value.ToString();
            cbmTipoLic.Text = fila.Cells["TipoLicencia"].Value.ToString();
            txtStockLic.Text = fila.Cells["StockLicencias"].Value.ToString();
            txtLicenDisponibles.Text = fila.Cells["LicenciasDisponibles"].Value.ToString();
            txtTipoLicInstalada.Text = fila.Cells["LicenciasInstaladas"].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
        string.IsNullOrWhiteSpace(txtVersion.Text) ||
        string.IsNullOrWhiteSpace(cbmTipoLic.Text) ||
        string.IsNullOrWhiteSpace(txtStockLic.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string insertar = @"INSERT INTO Software 
                    (Nombre, Version, TipoLicencia, StockLicencias, LicenciasDisponibles, LicenciasInstaladas)
                    VALUES (@nom, @ver, @tipo, @stock, @stock, 0)";

                    using (SqlCommand cmd = new SqlCommand(insertar, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@ver", txtVersion.Text);
                        cmd.Parameters.AddWithValue("@tipo", cbmTipoLic.Text);
                        cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStockLic.Text));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Software agregado correctamente.");
                dgvSoftware.DataSource = CargarSoftware();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSoftwareSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un software para actualizar.");
                return;
            }

            if (!int.TryParse(txtStockLic.Text, out int stock))
            {
                MessageBox.Show("El stock debe ser un número válido.");
                return;
            }

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string actualizar = @"UPDATE Software SET
                Nombre = @nom,
                Version = @ver,
                TipoLicencia = @tipo,
                StockLicencias = @stock,
                LicenciasDisponibles = @stock
            WHERE IdSoftware = @id";

                using (SqlCommand cmd = new SqlCommand(actualizar, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@ver", txtVersion.Text);
                    cmd.Parameters.AddWithValue("@tipo", cbmTipoLic.Text);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@id", idSoftwareSeleccionado);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Software actualizado.");
            dgvSoftware.DataSource = CargarSoftware();
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) &&
                string.IsNullOrWhiteSpace(txtVersion.Text) &&
                string.IsNullOrWhiteSpace(cbmTipoLic.Text) &&
                string.IsNullOrWhiteSpace(txtStockLic.Text))
            {
                dgvSoftware.DataSource = CargarSoftware();
                return;
            }

            dgvSoftware.DataSource = BuscarSoftware();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSoftwareSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un software para eliminar.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                // 1️⃣ Obtener licencias instaladas reales
                string obtenerLicencias = @"SELECT LicenciasInstaladas
                                    FROM Software
                                    WHERE IdSoftware = @id";

                int licenciasInstaladas;

                using (SqlCommand cmdLic = new SqlCommand(obtenerLicencias, conn))
                {
                    cmdLic.Parameters.AddWithValue("@id", idSoftwareSeleccionado);
                    licenciasInstaladas = Convert.ToInt32(cmdLic.ExecuteScalar());
                }

                // 2️⃣ Bloquear eliminación si hay licencias
                if (licenciasInstaladas > 0)
                {
                    MessageBox.Show(
                        $"No se puede eliminar el software porque tiene {licenciasInstaladas} licencia(s) instalada(s).",
                        "Eliminación bloqueada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // 3️⃣ Eliminar instalaciones (solo porque no hay licencias)
                string eliminarInstalaciones = @"DELETE FROM InstalacionesSoftware
                                         WHERE IdSoftware = @id";

                using (SqlCommand cmdInst = new SqlCommand(eliminarInstalaciones, conn))
                {
                    cmdInst.Parameters.AddWithValue("@id", idSoftwareSeleccionado);
                    cmdInst.ExecuteNonQuery();
                }

                // 4️⃣ Confirmar eliminación
                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este software?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                    return;

                // 5️⃣ Eliminar software
                string eliminarSoftware = "DELETE FROM Software WHERE IdSoftware = @id";

                using (SqlCommand cmdEliminar = new SqlCommand(eliminarSoftware, conn))
                {
                    cmdEliminar.Parameters.AddWithValue("@id", idSoftwareSeleccionado);
                    cmdEliminar.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Software eliminado correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            dgvSoftware.DataSource = CargarSoftware();
            Limpiar();
            idSoftwareSeleccionado = 0;
        }

        private void Software_Load(object sender, EventArgs e)
        {
            dgvSoftware.DataSource = CargarSoftware();
            CargarCampos();
            cbmTipoLic.Items.Clear();
            cbmTipoLic.Items.Add("Libre");
            cbmTipoLic.Items.Add("Pago");
            cbmTipoLic.SelectedIndex = 0;
        }
    }
}
