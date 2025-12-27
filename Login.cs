using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_PrograIV
{
    public partial class Login : Form
    {
        // ===============================
        // VARIABLES GLOBALES DEL LOGIN
        // ===============================

        // Cadena de conexión (ajústala a la real)
        private string cadenaConexion =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=db_SoporteTI;Integrated Security=True";

        // Se llena cuando el usuario hace login correcto
        private int idUsuarioActual;

        public Login()
        {
            InitializeComponent();
        }

        // ===============================
        // LOAD
        // ===============================
        private void Login_Load(object sender, EventArgs e)
        {
            // Por defecto ocultamos la contraseña
            txtClave.UseSystemPasswordChar = true;
        }

        // ===============================
        // BOTÓN INICIAR SESIÓN
        // ===============================
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // 1️⃣ Validación básica
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe ingresar cédula y contraseña.");
                return;
            }

            string cedula = txtCedula.Text.Trim();
            string clavePlano = txtClave.Text.Trim();

            UsuarioDAO user = new UsuarioDAO();

            // 2️⃣ Validar credenciales
            string rol = user.ValidarLogin(cedula, clavePlano);

            if (rol == null)
            {
                MessageBox.Show("Cédula o contraseña incorrecta.");
                return;
            }

            // 3️⃣ Obtener el ID del usuario (OBLIGATORIO)
           

            // 4️⃣ ¿Debe cambiar la clave?
            if (user.DebeCambiarClave(cedula))
            {
                FrmCambioClaveSimple frm = new FrmCambioClaveSimple(cadenaConexion, cedula);

                frm.ShowDialog();
                this.Hide();
                return;
                // ⛔ no sigue al menú
            }

            // 5️⃣ Login normal
            Principal menu = new Principal(rol, cedula);
            menu.Show();
            this.Hide();
        }

        // validar login 




        // ===============================
        // BOTÓN SALIR
        // ===============================
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ===============================
        // MOSTRAR / OCULTAR CONTRASEÑA
        // ===============================
        private void chkMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !chkMostrarClave.Checked;
        }

        private void txtCedula_Enter(object sender, EventArgs e) { }

        private void txtClave_TextChanged(object sender, EventArgs e) { }

        private void txtClave_Leave(object sender, EventArgs e) { }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
