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
            }
        }

        private void limpiarCampos()
        {
            txtMarca.Clear();
            txtSerie.Clear();
            cbmTipo.SelectedIndex = -1;
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

            if (!string.IsNullOrWhiteSpace(cbmTipo.Text))
            {
                filtros.Add("TipoEquipo = @tipo");
                parametros.Add(new SqlParameter("@tipo", cbmTipo.Text));
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
            if (cbmCampo.SelectedItem == null)
                return;

            string columna = cbmCampo.SelectedItem.ToString();

            // Limpiar datos previos
            cbmDato.Items.Clear();
            cbmDato.Text = "";
            cbmDato.SelectedIndex = -1;

            string consulta = $"SELECT DISTINCT {columna} FROM Computadoras ORDER BY {columna}";

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr[columna] != DBNull.Value)
                        {
                            cbmDato.Items.Add(dr[columna].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando datos: " + ex.Message);
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

            
            cbmTipo.Items.Clear();
            cbmTipo.Items.Add("Laptop");
            cbmTipo.Items.Add("Escritorio");
            cbmTipo.SelectedIndex = 0;
            cargarDepartamentos();
            cargarComputadoras();

        }

        private void cbmDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmCampo.SelectedItem == null || cbmDato.SelectedItem == null)
                return;

            string columna = cbmCampo.SelectedItem.ToString();
            string valor = cbmDato.SelectedItem.ToString();

            string consulta = $"SELECT * FROM Computadoras WHERE {columna} = @valor";

            DataTable dt = new DataTable();

            using (SqlConnection con = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.AddWithValue("@valor", valor);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            dtvComputadoras.DataSource = dt;
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dtvComputadoras.Rows[e.RowIndex];

                txtMarca.Text = fila.Cells["Marca"].Value.ToString();
                cbmTipo.Text = fila.Cells["TipoEquipo"].Value.ToString();
                txtSerie.Text = fila.Cells["Serie"].Value.ToString();

                int idDep = Convert.ToInt32(fila.Cells["IdDepartamento"].Value);
                cmbDepartamento.SelectedValue = idDep;

                cargarEmpleadosPorDepartamento(idDep);

                cbmAsignado.SelectedValue = fila.Cells["IdEmpleado"].Value;
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
    }
}
