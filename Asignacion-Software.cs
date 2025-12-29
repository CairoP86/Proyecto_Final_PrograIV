using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_PrograIV
{
    public partial class Asignacion_de_Software : Form
    {
        private string cedulaUsuario;

        public Asignacion_de_Software(string cedula)
        {
            InitializeComponent();
            cedulaUsuario = cedula;
        }

        // ===============================
        // CARGAR SOFTWARE
        // ===============================
        private void cargarSoftware()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdSoftware, Nombre FROM Software", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cbmSoftware.DataSource = dt;
                cbmSoftware.DisplayMember = "Nombre";
                cbmSoftware.ValueMember = "IdSoftware";
                cbmSoftware.SelectedIndex = -1;
            }
        }

        // ===============================
        // CARGAR COMPUTADORAS
        // ===============================
        private void cargarCompus()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
                SELECT 
                    IdComputadora,
                    Marca,
                    TipoEquipo,
                    Serie
                FROM Computadoras
                ORDER BY IdComputadora";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvComputadoras.DataSource = dt;

                dgvComputadoras.Columns["IdComputadora"].HeaderText = "ID";
                dgvComputadoras.Columns["Marca"].HeaderText = "Marca";
                dgvComputadoras.Columns["TipoEquipo"].HeaderText = "Tipo";
                dgvComputadoras.Columns["Serie"].HeaderText = "Serie";

                dgvComputadoras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvComputadoras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvComputadoras.MultiSelect = false;
                dgvComputadoras.ReadOnly = true;

                dgvComputadoras.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
                dgvComputadoras.DefaultCellStyle.SelectionForeColor = Color.White;

            }
        }

        private void dgvComputadoras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && txtLicenciasDisponibles.Text != "0")
                btnInstalar.Enabled = true;
        }


        // ===============================
        // LOAD
        // ===============================
        private void Asignacion_de_Software_Load(object sender, EventArgs e)
        {
            cargarSoftware();
            cargarCompus();

            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

            UsuarioDAO dao = new UsuarioDAO();
            txtTecnico.Text = dao.ObtenerNombreUsuario(cedulaUsuario);

            txtLicenciasDisponibles.ReadOnly = true;
            txtLicenciasDisponibles.Text = "";
            btnInstalar.Enabled = false;
        }

        // ===============================
        // CAMBIO DE SOFTWARE
        // ===============================
        private void cbmSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmSoftware.SelectedValue == null ||
                cbmSoftware.SelectedValue is DataRowView)
                return;

            if (!int.TryParse(cbmSoftware.SelectedValue.ToString(), out int idSoftware))
                return;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT LicenciasDisponibles FROM Software WHERE IdSoftware = @id", con);

                cmd.Parameters.AddWithValue("@id", idSoftware);

                int disponibles = Convert.ToInt32(cmd.ExecuteScalar());

                txtLicenciasDisponibles.Text = disponibles.ToString();

                if (disponibles <= 0)
                {
                    txtLicenciasDisponibles.ForeColor = Color.Red;
                    btnInstalar.Enabled = false;
                }
                else
                {
                    txtLicenciasDisponibles.ForeColor = Color.Green;
                    btnInstalar.Enabled = true;
                }
            }
        }

        // ===============================
        // INSTALAR SOFTWARE
        // ===============================
        private void btnInstalar_Click(object sender, EventArgs e)
        {
            // Validar software
            if (cbmSoftware.SelectedValue == null ||
                cbmSoftware.SelectedValue is DataRowView)
            {
                MessageBox.Show("Seleccione un software.");
                return;
            }

            // Validar computadora
            if (dgvComputadoras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una computadora.");
                return;
            }

            int idSoftware = Convert.ToInt32(cbmSoftware.SelectedValue);
            int idComputadora = Convert.ToInt32(
                dgvComputadoras.CurrentRow.Cells["IdComputadora"].Value
            );
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand check = new SqlCommand(
                    @"SELECT COUNT(*) 
          FROM InstalacionesSoftware 
          WHERE IdSoftware = @s AND IdComputadora = @c", con);

                check.Parameters.AddWithValue("@s", idSoftware);
                check.Parameters.AddWithValue("@c", idComputadora);

                int yaInstalado = Convert.ToInt32(check.ExecuteScalar());

                if (yaInstalado > 0)
                {
                    MessageBox.Show(
                        "Este software ya está instalado en la computadora seleccionada.",
                        "Instalación no permitida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }


            DialogResult confirm = MessageBox.Show(
                $"¿Confirmar instalación?\n\n" +
                $"Software: {cbmSoftware.Text}\n" +
                $"Computadora: {dgvComputadoras.CurrentRow.Cells["Marca"].Value} - " +
                $"{dgvComputadoras.CurrentRow.Cells["Serie"].Value}\n" +
                $"Fecha: {txtFecha.Text}\n" +
                $"Técnico: {txtTecnico.Text}",
                "Confirmar instalación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand insert = new SqlCommand(
                    @"INSERT INTO InstalacionesSoftware
                      (IdSoftware, IdComputadora, FechaInstalacion, TecnicoInstalo)
                      VALUES (@s, @c, @f, @t)", con);

                insert.Parameters.AddWithValue("@s", idSoftware);
                insert.Parameters.AddWithValue("@c", idComputadora);
                insert.Parameters.AddWithValue("@f", txtFecha.Text);
                insert.Parameters.AddWithValue("@t", cedulaUsuario);
                insert.ExecuteNonQuery();

                SqlCommand update = new SqlCommand(
                    @"UPDATE Software
                      SET LicenciasDisponibles = LicenciasDisponibles - 1,
                          LicenciasInstaladas = LicenciasInstaladas + 1
                      WHERE IdSoftware = @id", con);

                update.Parameters.AddWithValue("@id", idSoftware);
                update.ExecuteNonQuery();
            }

            MessageBox.Show("Software instalado correctamente.", "Éxito");

            // refrescar licencias
            cbmSoftware_SelectedIndexChanged(null, null);
        }
    }
}
