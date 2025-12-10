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
    public partial class Asignacion_de_Software : Form
    {
        private string cedulaUsuario;
        public Asignacion_de_Software(string cedula)
        {
            InitializeComponent();
            cedulaUsuario = cedula;
        }

        private void cargarSoftware()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string query = "SELECT IdSoftware, Nombre FROM Software";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cbmSoftware.DataSource = dt;
                    cbmSoftware.DisplayMember = "Nombre";    
                    cbmSoftware.ValueMember = "IdSoftware";  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando software: " + ex.Message);
            }
        }

        private void cargarCompus()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string query = "SELECT IdComputadora, IdComputadora FROM Computadoras";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cbmComputadora.DataSource = dt;
                    cbmComputadora.DisplayMember = "IdComputadora";
                    cbmComputadora.ValueMember = "IdComputadora";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando software: " + ex.Message);
            }
        }

        private void Asignacion_de_Software_Load(object sender, EventArgs e)
        {
            cargarSoftware();
            cargarCompus();
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            UsuarioDAO dao = new UsuarioDAO();
            string nombreUsuario = dao.ObtenerNombreUsuario(cedulaUsuario);
            txtTecnico.Text = nombreUsuario;

        }

        private void cbmComputadora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void btnInstalar_Click(object sender, EventArgs e)
        {
           
            if (cbmSoftware.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un software.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbmComputadora.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una computadora.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                MessageBox.Show("Debe ingresar la fecha de instalación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cedulaUsuario))
            {
                MessageBox.Show("No se pudo identificar al técnico que está instalando.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSoftware = Convert.ToInt32(cbmSoftware.SelectedValue);
            int idComputadora = Convert.ToInt32(cbmComputadora.SelectedValue);
            string fecha = txtFecha.Text;

          
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT LicenciasDisponibles FROM Software WHERE IdSoftware = @id",
                    con);

                cmd.Parameters.AddWithValue("@id", idSoftware);

                int disponibles = Convert.ToInt32(cmd.ExecuteScalar());

                if (disponibles <= 0)
                {
                    MessageBox.Show("No hay licencias disponibles para este software.",
                        "Sin licencias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

         
            // ================================
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand insert = new SqlCommand(
                    @"INSERT INTO InstalacionesSoftware 
              (IdSoftware, IdComputadora, FechaInstalacion, TecnicoInstalo)
              VALUES (@software, @computadora, @fecha, @tecnico)", con);

                insert.Parameters.AddWithValue("@software", idSoftware);
                insert.Parameters.AddWithValue("@computadora", idComputadora);
                insert.Parameters.AddWithValue("@fecha", fecha);
                insert.Parameters.AddWithValue("@tecnico", cedulaUsuario);

                insert.ExecuteNonQuery();
            }

           
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

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
        }
    }
}
