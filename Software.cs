using System;
using System.Data;
using System.Data.SqlClient;
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

        // =========================
        // CARGAR SOFTWARE
        // =========================
        private DataTable CargarSoftware()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"
                    SELECT IdSoftware, Nombre, Version, TipoLicencia,
                           StockLicencias, LicenciasDisponibles, LicenciasInstaladas
                    FROM Software";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        // =========================
        // LIMPIAR FORMULARIO
        // =========================
        private void Limpiar()
        {
            txtNombre.Clear();
            txtVersion.Clear();
            cbmTipoLic.SelectedIndex = -1;
            txtStockLic.Clear();
            txtLicenDisponibles.Clear();
            txtTipoLicInstalada.Clear();

            idSoftwareSeleccionado = 0;
            dgvSoftware.ClearSelection();

            txtNombre.Focus();
        }

        // =========================
        // LOAD
        // =========================
        private void Software_Load(object sender, EventArgs e)
        {
            dgvSoftware.DataSource = CargarSoftware();

            cbmTipoLic.Items.Clear();
            cbmTipoLic.Items.Add("Libre");
            cbmTipoLic.Items.Add("Pago");
            cbmTipoLic.SelectedIndex = 0;

            Limpiar();
        }

        // =========================
        // SELECCIÓN EN GRID
        // =========================
        private void dgvSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
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

        // =========================
        // AGREGAR
        // =========================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtVersion.Text) ||
                string.IsNullOrWhiteSpace(cbmTipoLic.Text) ||
                !int.TryParse(txtStockLic.Text, out int stock))
            {
                MessageBox.Show("Complete todos los campos correctamente.");
                return;
            }

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO Software
                    (Nombre, Version, TipoLicencia, StockLicencias, LicenciasDisponibles, LicenciasInstaladas)
                    VALUES (@nom, @ver, @tipo, @stock, @stock, 0)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@ver", txtVersion.Text);
                    cmd.Parameters.AddWithValue("@tipo", cbmTipoLic.Text);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Software agregado correctamente.");
            dgvSoftware.DataSource = CargarSoftware();
            Limpiar();
        }

        // =========================
        // ACTUALIZAR
        // =========================
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSoftwareSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un software para actualizar.");
                return;
            }

            if (!int.TryParse(txtStockLic.Text, out int stock))
            {
                MessageBox.Show("El stock debe ser numérico.");
                return;
            }

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"
                    UPDATE Software SET
                        Nombre = @nom,
                        Version = @ver,
                        TipoLicencia = @tipo,
                        StockLicencias = @stock,
                        LicenciasDisponibles = (@stock - LicenciasInstaladas)
                    WHERE IdSoftware = @id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
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

        // =========================
        // BUSCAR (UN SOLO TEXTO)
        // =========================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                dgvSoftware.DataSource = CargarSoftware();
                return;
            }

            DataTable dt = new DataTable();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"
                    SELECT IdSoftware, Nombre, Version, TipoLicencia,
                           StockLicencias, LicenciasDisponibles, LicenciasInstaladas
                    FROM Software
                    WHERE Nombre LIKE @txt OR Version LIKE @txt";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@txt", "%" + texto + "%");
                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }

            dgvSoftware.DataSource = dt;
            Limpiar();
        }

        // =========================
        // ELIMINAR
        // =========================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSoftwareSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un software para eliminar.");
                return;
            }

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string sqlLic = "SELECT LicenciasInstaladas FROM Software WHERE IdSoftware = @id";
                int instaladas;

                using (SqlCommand cmd = new SqlCommand(sqlLic, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idSoftwareSeleccionado);
                    instaladas = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (instaladas > 0)
                {
                    MessageBox.Show(
                        $"No se puede eliminar.\nLicencias instaladas: {instaladas}",
                        "Eliminación bloqueada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult r = MessageBox.Show(
                    "¿Desea eliminar este software?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r != DialogResult.Yes) return;

                string sqlDel = "DELETE FROM Software WHERE IdSoftware = @id";

                using (SqlCommand cmd = new SqlCommand(sqlDel, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idSoftwareSeleccionado);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Software eliminado correctamente.");
            dgvSoftware.DataSource = CargarSoftware();
            Limpiar();
        }

        // =========================
        // NUEVO
        // =========================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
