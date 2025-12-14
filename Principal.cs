using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Final_PrograIV;


namespace Proyecto_Final_PrograIV
{


    public partial class Principal : Form
    {

        string rolUsuario;
        string cedulaUsuario;


        public Principal(string rol, string cedula)
        {
            InitializeComponent();
            rolUsuario = rol.Trim().ToLower();
            
            cedulaUsuario = cedula;

            AplicarPermisosSegunRol();
        }

        private void AplicarPermisosSegunRol()
        {
            if (rolUsuario == "empleado")
            {
                computadorasToolStripMenuItem.Enabled = false;
                softwareToolStripMenuItem.Enabled = false;
                instalacionDeSoftwareToolStripMenuItem.Enabled = false;
                ticketsToolStripMenuItem.Enabled = true;
                reportesToolStripMenuItem.Enabled = false;
            }

            if (rolUsuario == "tecnico")
            {
                computadorasToolStripMenuItem.Enabled = false;
                softwareToolStripMenuItem.Enabled = false;
                instalacionDeSoftwareToolStripMenuItem.Enabled = true;
                ticketsToolStripMenuItem.Enabled = true;
            }

            if (rolUsuario == "ti")
            {
                computadorasToolStripMenuItem.Enabled = true;
                softwareToolStripMenuItem.Enabled = true;
                instalacionDeSoftwareToolStripMenuItem.Enabled = true;
                ticketsToolStripMenuItem.Enabled = true;
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            ActualizarNotificacionesMenu();

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
            Asignacion_de_Software form = new Asignacion_de_Software(cedulaUsuario);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BringToFront();
            form.Show();
        }


        // ========================
        //  MENÚ - TICKETS
        // ========================
        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rolUsuario == "empleado")
            {
                Tiquete_Empleado form = new Tiquete_Empleado(cedulaUsuario);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
                return;
            }

            if (rolUsuario == "tecnico")
            {
                Tiquete_Tecnico form = new Tiquete_Tecnico(cedulaUsuario);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
                return;
            }

            if (rolUsuario == "ti")   // encargado
            {
                Tiquete_Encargado form = new Tiquete_Encargado();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
                return;
            }

            MessageBox.Show("Rol no reconocido: " + rolUsuario);
        }

        // ========================
        //  MENÚ - ACERCA DE
        // ========================
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Sistema de Soporte TI\n" +
            "Proyecto Final - Programación IV\n\n" +
            "Desarrollado por:\n" +
            "• Cairo López\n" +
            "• Kevin Quirós\n" +
            "• Kevin Morera",
            "Acerca de",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
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

        private void reporteDeComputadorasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes_TI form = new Reportes_TI();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BringToFront();
            form.Show();
        }
        public void ActualizarNotificacionesMenu()
        {
            int nuevas = NotificacionesDAO.ContarNoVistas(cedulaUsuario);

            if (nuevas > 0)
            {
                notificacionesToolStripMenuItem.Text = $"Notificaciones ({nuevas})";
                notificacionesToolStripMenuItem.ForeColor = Color.Red; // opcional
            }
            else
            {
                notificacionesToolStripMenuItem.Text = "Notificaciones";
                notificacionesToolStripMenuItem.ForeColor = Color.Black; // color original
            }
        }



        private void toolStripStatusLabelUsuario_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            

            ActualizarNotificacionesMenu();
            Notificaciones form = new Notificaciones(cedulaUsuario);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BringToFront();
            form.Show();
        }
    }
}
