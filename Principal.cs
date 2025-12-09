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


    public partial class Principal : Form
    {
        string rolUsuario;
        string cedulaUsuario;


        public Principal(string rol, string cedula)
        {
            InitializeComponent();
            rolUsuario = rol;
            cedulaUsuario = cedula;

            AplicarPermisosSegunRol();
        }

        private void AplicarPermisosSegunRol()
        {
            if (rolUsuario == "Empleado")
            {
                computadorasToolStripMenuItem.Enabled = false;
                softwareToolStripMenuItem.Enabled = false;
                instalacionDeSoftwareToolStripMenuItem.Enabled = false;
                ticketsToolStripMenuItem.Enabled = true;
            }

            if (rolUsuario == "Tecnico")
            {
                computadorasToolStripMenuItem.Enabled = false;
                softwareToolStripMenuItem.Enabled = false;
                instalacionDeSoftwareToolStripMenuItem.Enabled = true;
                ticketsToolStripMenuItem.Enabled = true;
            }

            if (rolUsuario == "TI")
            {
                computadorasToolStripMenuItem.Enabled = true;
                softwareToolStripMenuItem.Enabled = true;
                instalacionDeSoftwareToolStripMenuItem.Enabled = true;
                ticketsToolStripMenuItem.Enabled = true;
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            UsuarioDAO dao = new UsuarioDAO();
            string nombreUsuario = dao.ObtenerNombreUsuario(cedulaUsuario);

            toolStripStatusLabelUsuario.Text = $"Usuario: {nombreUsuario}";
            toolStripStatusLabelRol.Text = $"Rol: {rolUsuario}";

            toolStripStatusLabelFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x200; // CS_NOCLOSE
                return cp;
            }
        }



       
        // MÉTODO SEGURO PARA ABRIR FORMULARIOS
        // ============================
        private void AbrirFormulario(Form form)
        {
            try
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.BringToFront();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el formulario.\n\nError: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========================
        //  MENÚ - USUARIOS
        // ========================
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios form = new Usuarios();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BringToFront();
            form.Show();
        }


        // ========================
        //  MENÚ - COMPUTADORAS
        // ========================
        private void computadorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compu_mantenimiento form = new compu_mantenimiento();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BringToFront();
            form.Show();
        }


        // ========================
        //  MENÚ - SOFTWARE
        // ========================
        private void softwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Software form = new Software();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BringToFront();
            form.Show();
        }


        // ========================
        //  MENÚ - INSTALACIÓN SOFTWARE
        // ========================
        private void instalacionDeSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Asignacion_de_Software form = new Asignacion_de_Software();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BringToFront();
            form.Show();
        }


        // ========================
        //  MENÚ - TICKETS
        // ========================
        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Tickets());
        }

        // ========================
        //  MENÚ - ACERCA DE
        // ========================
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema de Soporte TI\nProyecto Final - Programación IV",
                "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ========================
        //  MENÚ - SALIR
        // ========================
       

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
