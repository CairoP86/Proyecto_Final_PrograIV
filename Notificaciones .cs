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
    public partial class Notificaciones : Form
    {
        public Notificaciones()
        {
            InitializeComponent();
        }


        private void Notificaciones_Load(object sender, EventArgs e)
        {

            // 1. Mostrar notificaciones en pantalla
            CargarNotificaciones();

            // Marcar como vistas
            NotificacionesDAO.MarcarTodasComoVistas(cedulaActual);

            // Actualizar el menú principal
            ((Principal)Application.OpenForms["Principal"])?.ActualizarNotificacionesMenu();
        }


        private void CargarNotificaciones()
        {
            flowNotificaciones.Controls.Clear();

            // Obtener notificaciones DE ESTE USUARIO
            DataTable dt = NotificacionesDAO.ObtenerPorUsuario(cedulaActual);

            foreach (DataRow row in dt.Rows)
            {
                Panel tarjeta = new Panel();
                tarjeta.Width = flowNotificaciones.Width - 25;
                tarjeta.Height = 70;
                tarjeta.BackColor = Color.WhiteSmoke;
                tarjeta.Margin = new Padding(5);
                tarjeta.BorderStyle = BorderStyle.FixedSingle;

                // Texto de la notificación
                Label lbl = new Label();
                lbl.Text = $"{row["Mensaje"]}\n{Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy HH:mm")}";
                lbl.Dock = DockStyle.Fill;
                lbl.Font = new Font("Segoe UI", 10);
                lbl.TextAlign = ContentAlignment.MiddleLeft;

                tarjeta.Controls.Add(lbl);
                flowNotificaciones.Controls.Add(tarjeta);

                // MARCAR COMO VISTA
                NotificacionesDAO.MarcarComoVisto((int)row["IdNotificacion"]);
            }
        }
        string cedulaActual; // la del usuario logueado

        public Notificaciones(string cedula)
        {
            InitializeComponent();
            cedulaActual = cedula;
        }

    }
}
