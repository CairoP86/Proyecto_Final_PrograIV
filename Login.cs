using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_PrograIV
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        
        // LOAD
        
        private void Login_Load(object sender, EventArgs e)
        {
            

            // 🔥 Clave inicia sin ocultar SOLO si tiene placeholder
            txtClave.UseSystemPasswordChar = false;
            
        }



        // BOTÓN INICIAR SESIÓN

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // 1️⃣ Validación básica de campos
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe ingresar cédula y contraseña.");
                return;
            }

            string cedula = txtCedula.Text.Trim();
            string clavePlano = txtClave.Text.Trim();

            // 2️⃣ Generar hash de la contraseña ingresada
            string claveHash = Seguridad.GenerarHash(clavePlano);

            UsuarioDAO user = new UsuarioDAO();

            // 3️⃣ Validar credenciales
            string rol = user.ValidarLogin(cedula, claveHash);

            if (rol == null)
            {
                MessageBox.Show("Cédula o contraseña incorrecta.");
                return;
            }

            // 4️⃣ Validar expiración (12 horas en prueba)
            if (user.ClaveExpirada(cedula))
            {
                MessageBox.Show(
                    "Su contraseña ha expirado.\n\nContacte al departamento de TI para que se la renueven.",
                    "Acceso bloqueado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 5️⃣ Acceso correcto
            MessageBox.Show("Bienvenido al sistema.");

            Principal menu = new Principal(rol, cedula);
            menu.Show();
            this.Hide();
        }




        // BOTÓN SALIR

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // PLACEHOLDER FUNCTIONS
        
        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = placeholder;
                txt.ForeColor = Color.Gray;
            }
        }

        private void RemovePlaceholder(TextBox txt, string placeholder)
        {
            if (txt.Text == placeholder)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        
        // CÉDULA EVENTS
        
        private void txtCedula_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtCedula, "Ejemplo: 050112233");
        }

        
        // CONTRASEÑA EVENTS
       
        private void txtClave_Enter(object sender, EventArgs e)
        {

        }


        private void txtClave_Leave(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}