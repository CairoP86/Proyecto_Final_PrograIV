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
        // CARGA DE SOFTWARE
        // ===============================
        private void cargarSoftware()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string query = "SELECT IdSoftware, Nombre FROM Software";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbmSoftware.DataSource = dt;
                    cbmSoftware.DisplayMember = "Nombre";
                    cbmSoftware.ValueMember = "IdSoftware";
                    cbmSoftware.SelectedIndex = -1; // CLAVE
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando software: " + ex.Message);
            }
        }

        // ===============================
        // CARGA DE COMPUTADORAS
        // ===============================
        private void cargarCompus()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string query = @"
                SELECT 
                    IdComputadora,
                    CONCAT(
                        'PC-', IdComputadora, ' | ',
                        Marca, ' | ',
                        TipoEquipo, ' | ',
                        Serie
                    ) AS Descripcion
                FROM Computadoras
                ORDER BY IdComputadora";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbmComputadora.DataSource = dt;
                    cbmComputadora.DisplayMember = "Descripcion";   // 👈 lo que ve el usuario
                    cbmComputadora.ValueMember = "IdComputadora";   // 👈 lo que usa el sistema
                    cbmComputadora.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando computadoras: " + ex.Message);
            }
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

            btnInstalar.Enabled = false;
            lblLicenciasDisponibles.Text = "";
        }

        // ===============================
        // EVENTO COMBO SOFTWARE (CORREGIDO)
        // ===============================
        private void cbmSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Protección contra DataRowView
            if (cbmSoftware.SelectedValue == null ||
                cbmSoftware.SelectedValue is DataRowView)
                return;

            if (!int.TryParse(cbmSoftware.SelectedValue.ToString(), out int idSoftware))
                return;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT LicenciasDisponibles FROM Software WHERE IdSoftware = @id",
                    con);

                cmd.Parameters.AddWithValue("@id", idSoftware);

                int disponibles = Convert.ToInt32(cmd.ExecuteScalar());

                lblLicenciasDisponibles.Text = $"Licencias disponibles: {disponibles}";

                if (disponibles <= 0)
                {
                    lblLicenciasDisponibles.ForeColor = Color.Red;
                    btnInstalar.Enabled = false;
                }
                else
                {
                    lblLicenciasDisponibles.ForeColor = Color.Green;
                    btnInstalar.Enabled = true;
                }
            }
        }

        // ===============================
        // BOTÓN INSTALAR
        // ===============================
        private void btnInstalar_Click(object sender, EventArgs e)
        {
            if (cbmSoftware.SelectedValue == null ||
                cbmSoftware.SelectedValue is DataRowView)
            {
                MessageBox.Show("Debe seleccionar un software.");
                return;
            }

            if (cbmComputadora.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una computadora.");
                return;
            }

            if (!int.TryParse(cbmSoftware.SelectedValue.ToString(), out int idSoftware))
                return;

            int idComputadora = Convert.ToInt32(cbmComputadora.SelectedValue);
            string fecha = txtFecha.Text;

            // Confirmación visual
            DialogResult confirmacion = MessageBox.Show(
                $"¿Confirmar instalación?\n\n" +
                $"Software: {cbmSoftware.Text}\n" +
                $"Computadora: {cbmComputadora.Text}\n" +
                $"Fecha: {fecha}\n" +
                $"Técnico: {txtTecnico.Text}",
                "Confirmar instalación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
                return;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                // Insert instalación
                SqlCommand insert = new SqlCommand(
                    @"INSERT INTO InstalacionesSoftware
                      (IdSoftware, IdComputadora, FechaInstalacion, TecnicoInstalo)
                      VALUES (@software, @computadora, @fecha, @tecnico)", con);

                insert.Parameters.AddWithValue("@software", idSoftware);
                insert.Parameters.AddWithValue("@computadora", idComputadora);
                insert.Parameters.AddWithValue("@fecha", fecha);
                insert.Parameters.AddWithValue("@tecnico", cedulaUsuario);
                insert.ExecuteNonQuery();

                // Update licencias
                SqlCommand update = new SqlCommand(
                    @"UPDATE Software
                      SET LicenciasDisponibles = LicenciasDisponibles - 1,
                          LicenciasInstaladas = LicenciasInstaladas + 1
                      WHERE IdSoftware = @id", con);

                update.Parameters.AddWithValue("@id", idSoftware);
                update.ExecuteNonQuery();
            }

            MessageBox.Show("Software instalado correctamente.",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh UI
            cbmSoftware_SelectedIndexChanged(null, null);
        }
    }
}
