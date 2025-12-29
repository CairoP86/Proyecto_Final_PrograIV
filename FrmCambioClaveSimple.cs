using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_Final_PrograIV
{
    public partial class FrmCambioClaveSimple : Form
    {
        // ===============================
        // Variables de control visual
        // ===============================
        private bool mostrarClave = false;
        private bool mostrarConfirmar = false;

        // ===============================
        // Datos necesarios para guardar
        // ===============================
        private string cadenaConexion;
        private string cedulaUsuario;

        // ===============================
        // Constructor del formulario
        // Recibe conexión y cédula del usuario
        // ===============================
        public FrmCambioClaveSimple(string conexion, string cedula)
        {
            InitializeComponent();

            cadenaConexion = conexion;
            cedulaUsuario = cedula;

            // Las contraseñas inician ocultas
            txtClave.PasswordChar = '*';
            txtConfirmar.PasswordChar = '*';
        }

        // ===============================
        // Mostrar / ocultar campo Clave
        // ===============================
        private void btnVer_Click(object sender, EventArgs e)
        {
            mostrarClave = !mostrarClave;
            txtClave.PasswordChar = mostrarClave ? '\0' : '*';
        }

        // ===============================
        // Mostrar / ocultar Confirmar Clave
        // ===============================
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            mostrarConfirmar = !mostrarConfirmar;
            txtConfirmar.PasswordChar = mostrarConfirmar ? '\0' : '*';
        }

        // ===============================
        // Este método valida que:
        // - no estén vacías
        // - coincidan
        // - tengan mínimo 8 caracteres
        // ===============================
        private bool ValidarClave()
        {
            if (string.IsNullOrWhiteSpace(txtClave.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmar.Text))
            {
                MessageBox.Show("Debe completar ambos campos.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            if (txtClave.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (txtClave.Text.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.",
                                "Seguridad",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // ===============================
        // Botón Guardar
        // Valida y guarda la nueva clave
        // ===============================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarClave())
                return;

            // Se genera el HASH de la nueva clave
            string hash = GenerarHash(txtClave.Text);

            // Se guarda en la base de datos
            CambiarClave(hash);

            MessageBox.Show("Contraseña actualizada correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            // Volver al Login
            Login login = new Login();
            login.Show();

            this.Close();
        }

        // ===============================
        // Este método actualiza la contraseña:
        // - Guarda el hash
        // - Resetea DebeCambiarClave
        // - Actualiza la fecha de cambio
        // ===============================
        private void CambiarClave(string nuevaClaveHash)
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                string sql = @"UPDATE Usuarios
                               SET ClaveHash = @ClaveHash,
                                   DebeCambiarClave = 0,
                                   FechaCambioClave = GETDATE()
                               WHERE Cedula = @Cedula";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@ClaveHash", nuevaClaveHash);
                cmd.Parameters.AddWithValue("@Cedula", cedulaUsuario);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ===============================
        // Este método genera el hash SHA256
        // de un texto (contraseña)
        // ===============================
        private string GenerarHash(string texto)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        private void FrmCambioClaveSimple_Load(object sender, EventArgs e)
        {

        }
    }
}
