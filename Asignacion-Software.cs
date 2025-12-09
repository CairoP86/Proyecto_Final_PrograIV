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
        public Asignacion_de_Software()
        {
            InitializeComponent();
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
            //Falta jalar el login actual 
        }

        private void cbmComputadora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
