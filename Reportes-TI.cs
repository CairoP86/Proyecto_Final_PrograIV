using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Final_PrograIV
{
    public partial class Reportes_TI : Form
    {
        public Reportes_TI()
        {
            InitializeComponent();
        }

        private void EjecutarConsulta(string query)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                dataGridView1.DataSource = dt;
            }
        }

        private void cbmModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbmReporte.Items.Clear();

            if (cbmModulo.SelectedItem == null)
                return;

            string modulo = cbmModulo.SelectedItem.ToString();

            switch (modulo)
            {
                case "Usuario":
                    cbmReporte.Items.Add("Cantidad total de usuarios");
                    cbmReporte.Items.Add("Cantidad de usuarios por rol");
                    cbmReporte.Items.Add("Últimos 5 usuarios agregados");
                    cbmReporte.Items.Add("Cantidad de técnicos");
                    cbmReporte.Items.Add("Usuarios creados por día");
                    break;

                case "Software":
                    cbmReporte.Items.Add("Cantidad total de softwares");
                    cbmReporte.Items.Add("Total de licencias instaladas");
                    cbmReporte.Items.Add("Total de licencias disponibles");
                    cbmReporte.Items.Add("Stock vs instaladas por software");
                    cbmReporte.Items.Add("Cantidad por tipo de licencia");
                    break;

                case "Computadora":
                    cbmReporte.Items.Add("Cantidad total de computadoras");
                    cbmReporte.Items.Add("Cantidad por tipo de equipo");
                    cbmReporte.Items.Add("Cantidad por marca");
                    cbmReporte.Items.Add("Cantidad por departamento");
                    cbmReporte.Items.Add("Cantidad por empleado");
                    break;

                case "Tiquete":
                    cbmReporte.Items.Add("Total de tiquetes");
                    cbmReporte.Items.Add("Tiquetes por estado");
                    cbmReporte.Items.Add("Total de tiquetes asignados");
                    cbmReporte.Items.Add("Últimos 5 tiquetes generados");
                    cbmReporte.Items.Add("Tiquetes por técnico asignado");
                    break;
            }

            if (cbmReporte.Items.Count > 0)
                cbmReporte.SelectedIndex = 0;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbmReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmModulo.SelectedItem == null || cbmReporte.SelectedItem == null)
                return;

            string modulo = cbmModulo.SelectedItem.ToString();
            string reporte = cbmReporte.SelectedItem.ToString();

            string query = "";


            if (modulo == "Usuario")
            {
                switch (reporte)
                {
                    case "Cantidad total de usuarios":
                        query = "SELECT COUNT(*) AS TotalUsuarios FROM Usuarios";
                        break;

                    case "Cantidad de usuarios por rol":
                        query = "SELECT Rol, COUNT(*) AS Total FROM Usuarios GROUP BY Rol";
                        break;

                    case "Últimos 5 usuarios agregados":
                        query = "SELECT TOP 5 * FROM Usuarios ORDER BY Fecha_Creacion DESC";
                        break;

                    case "Cantidad de técnicos":
                        query = "SELECT COUNT(*) AS TotalTecnicos FROM Usuarios WHERE Rol = 'Tecnico'";
                        break;

                    case "Usuarios creados por día":
                        query = @"SELECT CAST(Fecha_Creacion AS DATE) AS Dia, COUNT(*) AS Total
                          FROM Usuarios
                          GROUP BY CAST(Fecha_Creacion AS DATE)
                          ORDER BY Dia DESC";
                        break;
                }
            }

            if (modulo == "Software")
            {
                switch (reporte)
                {
                    case "Cantidad total de softwares":
                        query = "SELECT COUNT(*) AS TotalSoftware FROM Software";
                        break;

                    case "Total de licencias instaladas":
                        query = "SELECT SUM(LicenciasInstaladas) AS TotalInstaladas FROM Software";
                        break;

                    case "Total de licencias disponibles":
                        query = "SELECT SUM(LicenciasDisponibles) AS TotalDisponibles FROM Software";
                        break;

                    case "Stock vs instaladas por software":
                        query = "SELECT Nombre, StockLicencias, LicenciasInstaladas FROM Software";
                        break;

                    case "Cantidad por tipo de licencia":
                        query = "SELECT TipoLicencia, COUNT(*) AS Total FROM Software GROUP BY TipoLicencia";
                        break;
                }
            }

            if (modulo == "Computadora")
            {
                switch (reporte)
                {
                    case "Cantidad total de computadoras":
                        query = "SELECT COUNT(*) AS TotalComputadoras FROM Computadoras";
                        break;

                    case "Cantidad por tipo de equipo":
                        query = "SELECT TipoEquipo, COUNT(*) AS Total FROM Computadoras GROUP BY TipoEquipo";
                        break;

                    case "Cantidad por marca":
                        query = "SELECT Marca, COUNT(*) AS Total FROM Computadoras GROUP BY Marca";
                        break;

                    case "Cantidad por departamento":
                        query = "SELECT IdDepartamento, COUNT(*) AS Total FROM Computadoras GROUP BY IdDepartamento";
                        break;

                    case "Cantidad por empleado":
                        query = "SELECT IdEmpleado, COUNT(*) AS Total FROM Computadoras GROUP BY IdEmpleado";
                        break;
                }
            }


            if (modulo == "Tiquete")
            {
                switch (reporte)
                {
                    case "Total de tiquetes":
                        query = "SELECT COUNT(*) AS TotalTiquetes FROM Tiquetes";
                        break;

                    case "Tiquetes por estado":
                        query = "SELECT IdEstado, COUNT(*) AS Total FROM Tiquetes GROUP BY IdEstado";
                        break;

                    case "Total de tiquetes asignados":
                        query = "SELECT COUNT(*) AS TotalAsignados FROM Tiquetes WHERE TecnicoAsignado IS NOT NULL";
                        break;

                    case "Últimos 5 tiquetes generados":
                        query = "SELECT TOP 5 * FROM Tiquetes ORDER BY FechaCreacion DESC";
                        break;

                    case "Tiquetes por técnico asignado":
                        query = @"SELECT TecnicoAsignado, COUNT(*) AS Total 
                          FROM Tiquetes 
                          WHERE TecnicoAsignado IS NOT NULL
                          GROUP BY TecnicoAsignado";
                        break;
                }
            }

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("No se pudo generar la consulta.");
                return;
            }

            EjecutarConsulta(query);
        }

        private void Reportes_TI_Load(object sender, EventArgs e)
        {
            cbmModulo.Items.Clear();

            cbmModulo.Items.Add("Usuario");
            cbmModulo.Items.Add("Software");
            cbmModulo.Items.Add("Computadora");
            cbmModulo.Items.Add("Tiquete");

            cbmModulo.SelectedIndex = 0;
        }
    }
}
