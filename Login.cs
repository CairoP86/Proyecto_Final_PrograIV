using System;
using System.Windows.Forms;

namespace Proyecto_Final_PrograIV
{
    public partial class Login : Form
    {
        // ===============================
        // VARIABLES GLOBALES
        // ===============================

        // Controla si la contraseña está visible
        private bool mostrarClave = false;

        // Cadena de conexión (usada para el cambio de contraseña)
        private string cadenaConexion =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=db_SoporteTI;Integrated Security=True";

        // ===============================
        // CONSTRUCTOR
        // ===============================
        public Login()
        {
            InitializeComponent();

            // Contraseña OCULTA por defecto
            txtClave.PasswordChar = '*';

            // (opcional) si usas multiline
            txtClave.Multiline = true;
        }

        // ===============================
        // BOTÓN VER / OCULTAR CONTRASEÑA 👁️
        // ===============================
        private void btnVerClave_Click(object sender, EventArgs e)
        {
            mostrarClave = !mostrarClave;

            // Alterna mostrar / ocultar
            txtClave.PasswordChar = mostrarClave ? '\0' : '*';
        }

        // ===============================
        // BOTÓN INICIAR SESIÓN
        // ===============================
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show(
                    "Debe ingresar cédula y contraseña.",
                    "Campos obligatorios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string cedula = txtCedula.Text.Trim();
            string clavePlano = txtClave.Text.Trim();

            UsuarioDAO user = new UsuarioDAO();

            // Validar credenciales
            string rol = user.ValidarLogin(cedula, clavePlano);

            if (rol == null)
            {
                MessageBox.Show(
                    "Cédula o contraseña incorrecta.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // ¿Debe cambiar la contraseña?
            if (user.DebeCambiarClave(cedula))
            {
                FrmCambioClaveSimple frmCambio =
                    new FrmCambioClaveSimple(cadenaConexion, cedula);

                frmCambio.ShowDialog();
                this.Hide();
                return; // ⛔ no continúa al menú
            }

            // Login exitoso → menú principal
            Principal menu = new Principal(rol, cedula);
            menu.Show();
            this.Hide();
        }

        // ===============================
        // BOTÓN SALIR
        // ===============================
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
