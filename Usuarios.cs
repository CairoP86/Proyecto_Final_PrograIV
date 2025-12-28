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
        private string rolUsuarioLogueado;
        private string cedulaUsuarioLogueado;




        public Usuarios(string rol, string cedula)
        {
            InitializeComponent();
            rolUsuarioLogueado = rol;
            cedulaUsuarioLogueado = cedula;
        }


        public DataTable cargarDatos()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = @"SELECT Cedula, Nombre, Apellido1, Apellido2, Rol, Fecha_Creacion 
                            FROM Usuarios";

                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;

        }

        // 🔍 Búsqueda simple por cédula o nombre (nuevo diseño)
        private DataTable BuscarUsuarios(string texto)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = @"
            SELECT Cedula, Nombre, Apellido1, Apellido2, Rol, Fecha_Creacion
            FROM Usuarios
            WHERE Cedula LIKE @texto
               OR Nombre LIKE @texto
               OR Apellido1 LIKE @texto
               OR Apellido2 LIKE @texto
            ORDER BY Nombre";

                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");

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
                string consulta = @"SELECT Cedula, Nombre, Apellido1, Apellido2,  Rol, Fecha_Creacion
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

            // 🔐 Solo TI puede resetear contraseñas
            if (!rolUsuarioLogueado.Equals("TI", StringComparison.OrdinalIgnoreCase))
            {
                btnResetClave.Visible = false;
            }
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

                    // 🔐 Contraseña inicial por defecto (solo para pruebas)
                    string claveGenerada = Seguridad.GenerarPassword(); // letras, números, símbolos
                    string hash = Seguridad.GenerarHash(claveGenerada);


                    string insertar = @"
                        INSERT INTO Usuarios
                                (
                                    Cedula,
                                    Nombre,
                                    Apellido1,
                                    Apellido2,
                                    ClaveHash,
                                    Rol,
                                    FechaCambioClave,
                                    DebeCambiarClave
                                )
                                VALUES
                                (
                                    @ced,
                                    @nom,
                                    @ape1,
                                    @ape2,
                                    @hash,
                                    @rol,
                                    GETDATE(),
                                    1
                                )";


                    using (SqlCommand cmd = new SqlCommand(insertar, conn))
                    {
                        cmd.Parameters.AddWithValue("@ced", txtCedula.Text);
                        cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@ape1", txtApellido1.Text);
                        cmd.Parameters.AddWithValue("@ape2", txtApellido2.Text);
                        cmd.Parameters.AddWithValue("@hash", hash);
                        cmd.Parameters.AddWithValue("@rol", cmbRol.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show(
                                 $"Usuario creado correctamente.\n\n" +
                                 $"Contraseña inicial:\n{claveGenerada}\n\n" +
                                 $"⚠️ Copie esta contraseña ahora.\n" +
                                 $"No se volverá a mostrar.",
                                  "Contraseña generada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                        );

                    }
                }

               
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
                                  SET Nombre=@nom, 
                                      Apellido1=@ape1, 
                                      Apellido2=@ape2, 
                                      Rol=@rol
                                  WHERE Cedula=@ced";

                    using (SqlCommand cmd = new SqlCommand(actualizar, conn))
                    {
                        cmd.Parameters.AddWithValue("@ced", txtCedula.Text);
                        cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@ape1", txtApellido1.Text);
                        cmd.Parameters.AddWithValue("@ape2", txtApellido2.Text);
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
           
            cmbRol.Text = dgvDatosUsuario.CurrentRow.Cells[4].Value.ToString();
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
            string texto = txtBuscar.Text.Trim();

            // Si está vacío, muestra todos
            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvDatosUsuario.DataSource = cargarDatos();
            }
            else
            {
                dgvDatosUsuario.DataSource = BuscarUsuarios(texto);
            }
        }







        private void btnResetClave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            string claveTemporal = Seguridad.GenerarPassword();

            string hash = Seguridad.GenerarHash(claveTemporal);


            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = @"UPDATE Usuarios
                                    SET ClaveHash = @hash,
                                     FechaCambioClave = GETDATE(),
                                        DebeCambiarClave = 1
                                      WHERE Cedula = @ced";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@hash", hash);
                        cmd.Parameters.AddWithValue("@ced", txtCedula.Text);
                        cmd.ExecuteNonQuery();
                        AuditoriaDAO.Registrar(
                        rolUsuarioLogueado,   // o cedula del TI si la tenés
                      "RESET_CLAVE",
                          "Usuarios",
                          null,
                        $"Reset de contraseña al usuario {txtCedula.Text}"
                   );
                    }
                  

                }

                // 3️⃣ Mostrar la clave SOLO AL TI
                MessageBox.Show(
                    $"Contraseña temporal:\n\n{claveTemporal}\n\nEl usuario debe usar esta contraseña hasta que TI se la renueve nuevamente.",
                     "Reset de contraseña",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al resetear contraseña: " + ex.Message);
            }
        }

        
    }
}
