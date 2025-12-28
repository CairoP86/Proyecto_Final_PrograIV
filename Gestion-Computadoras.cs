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
        private bool cargandoDatos = false;
        public compu_mantenimiento()
        {
            InitializeComponent();

        }

        private void cargarDepartamentos()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string consulta = "SELECT IdDepartamento, Nombre FROM Departamentos";

                    SqlCommand cmd = new SqlCommand(consulta, con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cmbDepartamento.DataSource = dt;
                    cmbDepartamento.DisplayMember = "Nombre";          
                    cmbDepartamento.ValueMember = "IdDepartamento";    
                    cmbDepartamento.SelectedIndex = -1;                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando departamentos: " + ex.Message);
            }
        }

        private void cargarEmpleadosPorDepartamento(int idDepartamento)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    string consulta = @"
                    SELECT Empleados.IdEmpleado,
                    Usuarios.Nombre + ' ' + Usuarios.Apellido1 AS NombreCompleto
                    FROM Usuarios
                    INNER JOIN Empleados ON Usuarios.Cedula = Empleados.Cedula
                    WHERE Empleados.IdDepartamento = @dep";

                    SqlCommand cmd = new SqlCommand(consulta, con);
                    cmd.Parameters.AddWithValue("@dep", idDepartamento);

                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cbmAsignado.DataSource = dt;
                    cbmAsignado.DisplayMember = "NombreCompleto";
                    cbmAsignado.ValueMember = "IdEmpleado";
                    cbmAsignado.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
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

                dtvComputadoras.Columns["IdComputadora"].Visible = false;
                dtvComputadoras.Columns["IdDepartamento"].Visible = false;
                dtvComputadoras.Columns["IdEmpleado"].Visible = false;


                dtvComputadoras.Columns["Marca"].HeaderText = "Marca";
                dtvComputadoras.Columns["TipoEquipo"].HeaderText = "Tipo";
                dtvComputadoras.Columns["Serie"].HeaderText = "Serie";


                dtvComputadoras.Columns["Marca"].Width = 120;
                dtvComputadoras.Columns["TipoEquipo"].Width = 100;
                dtvComputadoras.Columns["Serie"].Width = 150;
            }

            dtvComputadoras.ClearSelection();

        }

        private void limpiarCampos()
        {
            cargandoDatos = true;

            txtMarca.Clear();
            txtSerie.Clear();
            cbmTipo.SelectedIndex = -1;
            cmbDepartamento.SelectedIndex = -1;
            cbmAsignado.SelectedIndex = -1;

            dtvComputadoras.ClearSelection();

            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            cargandoDatos = false;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            DataTable dt = new DataTable();

            string consulta = @"
        SELECT IdComputadora, Marca, TipoEquipo, Serie, IdDepartamento, IdEmpleado
        FROM Computadoras
        WHERE (@texto = '' 
               OR Marca LIKE '%' + @texto + '%' 
               OR Serie LIKE '%' + @texto + '%')
        ORDER BY Marca";

            using (SqlConnection con = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.AddWithValue("@texto", texto);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            dtvComputadoras.DataSource = dt;

           


        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.SuppressKeyPress = true;
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
                
            }

            
            cbmTipo.Items.Clear();
            cbmTipo.Items.Add("Laptop");
            cbmTipo.Items.Add("Escritorio");
            cbmTipo.SelectedIndex = 0;
            cargarDepartamentos();
            cargarComputadoras();


            dtvComputadoras.ReadOnly = true;
            dtvComputadoras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtvComputadoras.MultiSelect = false;

            dtvComputadoras.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dtvComputadoras.DefaultCellStyle.SelectionForeColor = Color.White;

            // habilitar botones
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtMarca.Text) ||
                string.IsNullOrWhiteSpace(txtSerie.Text) ||
                cbmTipo.SelectedIndex == -1 ||
                cmbDepartamento.SelectedIndex == -1 ||
                cbmAsignado.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe completar todos los campos para registrar la computadora.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string consulta = @"INSERT INTO Computadoras
                        (Marca, TipoEquipo, Serie, IdDepartamento, IdEmpleado)
                        VALUES (@marca, @tipo, @serie, @dep, @emp)";

            using (SqlConnection con = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                cmd.Parameters.AddWithValue("@tipo", cbmTipo.Text);
                cmd.Parameters.AddWithValue("@serie", txtSerie.Text);

               
                cmd.Parameters.AddWithValue("@dep", Convert.ToInt32(cmbDepartamento.SelectedValue));
                cmd.Parameters.AddWithValue("@emp", Convert.ToInt32(cbmAsignado.SelectedValue));

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show(
                "Computadora agregada correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

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
                string.IsNullOrWhiteSpace(cbmTipo.Text) ||
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
                cmd.Parameters.AddWithValue("@tipo", cbmTipo.Text);
                cmd.Parameters.AddWithValue("@serie", txtSerie.Text);
                cmd.Parameters.AddWithValue("@dep",
                Convert.ToInt32(cmbDepartamento.SelectedValue));
                cmd.Parameters.AddWithValue("@emp",
                    Convert.ToInt32(cbmAsignado.SelectedValue));
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Computadora actualizada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            cargarComputadoras();
            limpiarCampos();
        }

        private void dtvComputadoras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cargandoDatos) return;
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dtvComputadoras.Rows[e.RowIndex];

            txtMarca.Text = fila.Cells["Marca"].Value.ToString();
            cbmTipo.Text = fila.Cells["TipoEquipo"].Value.ToString();
            txtSerie.Text = fila.Cells["Serie"].Value.ToString();

            int idDep = Convert.ToInt32(fila.Cells["IdDepartamento"].Value);
            cmbDepartamento.SelectedValue = idDep;

            cargarEmpleadosPorDepartamento(idDep);
            cbmAsignado.SelectedValue = fila.Cells["IdEmpleado"].Value;

            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtvComputadoras.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una computadora para eliminar.", "Advertencia",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartamento.SelectedItem == null)
                return;

         
            DataRowView fila = (DataRowView)cmbDepartamento.SelectedItem;

           
            int idDep = Convert.ToInt32(fila["IdDepartamento"]);

       
            cargarEmpleadosPorDepartamento(idDep);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
