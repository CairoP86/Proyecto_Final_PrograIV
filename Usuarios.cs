using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Proyecto_Final_PrograIV
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            Conexion.ObtenerConexion();

        }

        public DataTable cargarDatos()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = @"SELECT Cedula, Nombre, Apellido1, Apellido2, Clave, Rol, Fecha_Creacion 
                            FROM Usuarios";

                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;

        }

        public DataTable BuscarUsuariosAvanzado()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                // Empezamos con un WHERE flexible
                string consulta = @"SELECT Cedula, Nombre, Apellido1, Apellido2, Clave, Rol, Fecha_Creacion
                            FROM Usuarios
                            WHERE 1 = 1 ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Si el campo no está vacío, se agrega a la consulta
                if (!string.IsNullOrWhiteSpace(txtCedula.Text))
                {
                    consulta += " AND Cedula LIKE @ced";
                    cmd.Parameters.AddWithValue("@ced", "%" + txtCedula.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    consulta += " AND Nombre LIKE @nom";
                    cmd.Parameters.AddWithValue("@nom", "%" + txtNombre.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtApellido1.Text))
                {
                    consulta += " AND Apellido1 LIKE @ape1";
                    cmd.Parameters.AddWithValue("@ape1", "%" + txtApellido1.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtApellido2.Text))
                {
                    consulta += " AND Apellido2 LIKE @ape2";
                    cmd.Parameters.AddWithValue("@ape2", "%" + txtApellido2.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(cmbRol.Text))
                {
                    consulta += " AND Rol LIKE @rol";
                    cmd.Parameters.AddWithValue("@rol", "%" + cmbRol.Text + "%");
                }

                cmd.CommandText = consulta;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            dgvDatosUsuario.DataSource = cargarDatos();
            CargarCampos();

        }

        private void CargarCampos()
        {
            cbmCampo.Items.Clear();

            cbmCampo.Items.Add("Cedula");
            cbmCampo.Items.Add("Nombre");
            cbmCampo.Items.Add("Apellido1");
            cbmCampo.Items.Add("Apellido2");
            cbmCampo.Items.Add("Rol");

           
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
        string.IsNullOrWhiteSpace(txtNombre.Text) ||
        string.IsNullOrWhiteSpace(txtApellido1.Text) ||
        string.IsNullOrWhiteSpace(txtClave.Text) ||
        string.IsNullOrWhiteSpace(cmbRol.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string insertar = @"INSERT INTO Usuarios 
                               (Cedula, Nombre, Apellido1, Apellido2, Clave, Rol)
                               VALUES (@ced, @nom, @ape1, @ape2, @cla, @rol)";

                    using (SqlCommand cmd = new SqlCommand(insertar, conn))
                    {
                        cmd.Parameters.AddWithValue("@ced", txtCedula.Text);
                        cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@ape1", txtApellido1.Text);
                        cmd.Parameters.AddWithValue("@ape2", txtApellido2.Text);
                        cmd.Parameters.AddWithValue("@cla", txtClave.Text);
                        cmd.Parameters.AddWithValue("@rol", cmbRol.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario agregado con éxito.");
                dgvDatosUsuario.DataSource = cargarDatos();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void limpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtApellido1.Clear();
            txtApellido2.Clear();
            txtClave.Clear();
            cmbRol.SelectedIndex = -1;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDatosUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Debe seleccionar un usuario para actualizar.");
                return;
            }

            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string actualizar = @"UPDATE Usuarios 
                                 SET Nombre=@nom, Apellido1=@ape1, Apellido2=@ape2, 
                                     Clave=@cla, Rol=@rol
                                 WHERE Cedula=@ced";

                    using (SqlCommand cmd = new SqlCommand(actualizar, conn))
                    {
                        cmd.Parameters.AddWithValue("@ced", txtCedula.Text);
                        cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@ape1", txtApellido1.Text);
                        cmd.Parameters.AddWithValue("@ape2", txtApellido2.Text);
                        cmd.Parameters.AddWithValue("@cla", txtClave.Text);
                        cmd.Parameters.AddWithValue("@rol", cmbRol.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario actualizado.");
                dgvDatosUsuario.DataSource = cargarDatos();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Ingrese una cédula para eliminar.");
                return;
            }

            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string eliminar = "DELETE FROM Usuarios WHERE Cedula=@ced";

                    using (SqlCommand cmd = new SqlCommand(eliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@ced", txtCedula.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario eliminado.");
                dgvDatosUsuario.DataSource = cargarDatos();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void dgvDatosUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCedula.Text = dgvDatosUsuario.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvDatosUsuario.CurrentRow.Cells[1].Value.ToString();
            txtApellido1.Text = dgvDatosUsuario.CurrentRow.Cells[2].Value.ToString();
            txtApellido2.Text = dgvDatosUsuario.CurrentRow.Cells[3].Value.ToString();
            txtClave.Text = dgvDatosUsuario.CurrentRow.Cells[4].Value.ToString();
            cmbRol.Text = dgvDatosUsuario.CurrentRow.Cells[5].Value.ToString();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void txtApellido1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void txtApellido1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Si TODO está vacío → mostrar todos los usuarios
            if (string.IsNullOrWhiteSpace(txtCedula.Text) &&
                string.IsNullOrWhiteSpace(txtNombre.Text) &&
                string.IsNullOrWhiteSpace(txtApellido1.Text) &&
                string.IsNullOrWhiteSpace(txtApellido2.Text) &&
                string.IsNullOrWhiteSpace(cmbRol.Text))
            {
                dgvDatosUsuario.DataSource = cargarDatos();
                return;
            }

            // Si hay al menos un campo → buscar
            dgvDatosUsuario.DataSource = BuscarUsuariosAvanzado();
        }

        private void cbmCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmCampo.SelectedIndex == -1)
                return;

            cbmDato.Items.Clear();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string columna = cbmCampo.SelectedItem.ToString();
                string consulta = $"SELECT DISTINCT {columna} FROM Usuarios ORDER BY {columna}";

                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        cbmDato.Items.Add(dr[columna].ToString());
                    }
                }
            }
        }

        private void cbmDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmCampo.SelectedIndex == -1 || cbmDato.SelectedIndex == -1)
                return;

            string campo = cbmCampo.SelectedItem.ToString();
            string valor = cbmDato.SelectedItem.ToString();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = $"SELECT * FROM Usuarios WHERE {campo} = @val";

                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@val", valor);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    dgvDatosUsuario.DataSource = dt;
                }
            }
        }
    }
}
