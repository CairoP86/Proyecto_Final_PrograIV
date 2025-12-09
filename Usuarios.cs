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
            String consulta = "SELECT Cedula, Nombre, Apellido1, Apellido2, Clave, Rol, Fecha_Creacion FROM Usuarios";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.ObtenerConexion()); 
            SqlDataAdapter da = new SqlDataAdapter(cmd); 
            da.Fill(dt);
            return dt;
       
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            dgvDatosUsuario.DataSource = cargarDatos();

        }

        private void cbmCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
        string.IsNullOrWhiteSpace(txtNombre.Text) ||
        string.IsNullOrWhiteSpace(txtApellido1.Text) ||
        string.IsNullOrWhiteSpace(txtApellido2.Text) ||
        string.IsNullOrWhiteSpace(txtClave.Text) ||
        string.IsNullOrWhiteSpace(cmbRol.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string insertar = "INSERT INTO Usuarios (Cedula, Nombre, Apellido1, Apellido2, Clave, Rol) " +
                                      "VALUES (@ced, @nom, @ape1, @ape2, @cla, @rol)";

                    using (SqlCommand cmd = new SqlCommand(insertar, conn)) // <-- usar 'conn' aquí
                    {
                        cmd.Parameters.AddWithValue("@ced", txtCedula.Text.Trim());
                        cmd.Parameters.AddWithValue("@nom", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@ape1", txtApellido1.Text.Trim());
                        cmd.Parameters.AddWithValue("@ape2", txtApellido2.Text.Trim());
                        cmd.Parameters.AddWithValue("@cla", txtClave.Text.Trim());

                        // Mejor usar cmbRol.Text en vez de SelectedItem.ToString() por seguridad
                        cmd.Parameters.AddWithValue("@rol", cmbRol.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario agregado exitosamente.", "Registro exitoso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvDatosUsuario.DataSource = cargarDatos();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if ((txtCedula.Text == "") || (txtNombre.Text == "") || (txtApellido1.Text == "") || (txtApellido2.Text == "") || (txtClave.Text == "") || (cmbRol.Text == ""))
            {
                MessageBox.Show("Faltan datos para ACTUALIZAR en la base de datos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                String actualizar = "UPDATE Usuarios SET Cedula=@ced, Nombre=@nom, Apellido1=@ape1, Apellido2=@ape2, Clave=@cla, Rol=@rol WHERE Cedula=@ced";
                SqlCommand cmd = new SqlCommand(actualizar, Conexion.ObtenerConexion());

                cmd.Parameters.AddWithValue("@ced", txtCedula.Text);
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmd.Parameters.AddWithValue("@ape1", txtApellido1.Text);
                cmd.Parameters.AddWithValue("@ape2", txtApellido2.Text);
                cmd.Parameters.AddWithValue("@cla", txtClave.Text);
                cmd.Parameters.AddWithValue("@rol", cmbRol.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Datos actualizados a la base de datos", "Actualiozacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvDatosUsuario.DataSource = cargarDatos();

                limpiarCampos();
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((txtCedula.Text == "")) 
            {
                MessageBox.Show("Por favor, complete el campo de la cedula para eliminar resgitro", "Campo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                String eliminar = "DELETE FROM Usuarios WHERE Cedula=@ced";
                SqlCommand cmd = new SqlCommand(eliminar, Conexion.ObtenerConexion());

                cmd.Parameters.AddWithValue("@ced", txtCedula.Text);
             
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario eliminado exitosamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvDatosUsuario.DataSource = cargarDatos();

                limpiarCampos();
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
    }
}
