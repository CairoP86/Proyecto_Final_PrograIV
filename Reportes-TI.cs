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

                if (dataGridView1.Columns.Contains("ClaveHash"))
                    dataGridView1.Columns["ClaveHash"].Visible = false;

                if (dataGridView1.Columns.Contains("DebeCambiarClave"))
                    dataGridView1.Columns["DebeCambiarClave"].Visible = false;

                if (dataGridView1.Columns.Contains("Activo"))
                    dataGridView1.Columns["Activo"].Visible = false;

                // Renombrar encabezados para que sean entendibles por negocio
                if (dataGridView1.Columns.Contains("IdComputadora"))
                    dataGridView1.Columns["IdComputadora"].HeaderText = "Equipo";

                if (dataGridView1.Columns.Contains("MarcaEquipo"))
                    dataGridView1.Columns["MarcaEquipo"].HeaderText = "Marca";

                if (dataGridView1.Columns.Contains("TipoEquipo"))
                    dataGridView1.Columns["TipoEquipo"].HeaderText = "Tipo de equipo";

                if (dataGridView1.Columns.Contains("CedulaEmpleado"))
                    dataGridView1.Columns["CedulaEmpleado"].HeaderText = "Cédula empleado";

                if (dataGridView1.Columns.Contains("NombreEmpleado"))
                    dataGridView1.Columns["NombreEmpleado"].HeaderText = "Nombre";

                if (dataGridView1.Columns.Contains("ApellidoEmpleado"))
                    dataGridView1.Columns["ApellidoEmpleado"].HeaderText = "Apellido";

                if (dataGridView1.Columns.Contains("FechaInstalacion"))
                    dataGridView1.Columns["FechaInstalacion"].HeaderText = "Fecha de instalación";

                if (dataGridView1.Columns.Contains("TipoLicencia"))
                    dataGridView1.Columns["TipoLicencia"].HeaderText = "Licencia";

                // Renombrar encabezados para que sean entendibles para negocio

                if (dataGridView1.Columns.Contains("IdComputadora"))
                    dataGridView1.Columns["IdComputadora"].HeaderText = "Equipo";

                if (dataGridView1.Columns.Contains("TipoEquipo"))
                    dataGridView1.Columns["TipoEquipo"].HeaderText = "Tipo de equipo";

                if (dataGridView1.Columns.Contains("Marca"))
                    dataGridView1.Columns["Marca"].HeaderText = "Marca";

                if (dataGridView1.Columns.Contains("Serie"))
                    dataGridView1.Columns["Serie"].HeaderText = "Serie";

                if (dataGridView1.Columns.Contains("Cedula"))
                    dataGridView1.Columns["Cedula"].HeaderText = "Cédula";

                if (dataGridView1.Columns.Contains("Nombre"))
                    dataGridView1.Columns["Nombre"].HeaderText = "Nombre";

                if (dataGridView1.Columns.Contains("Apellido1"))
                    dataGridView1.Columns["Apellido1"].HeaderText = "Apellido";

                if (dataGridView1.Columns.Contains("Departament"))
                    dataGridView1.Columns["Departament"].HeaderText = "Departamento";

                if (dataGridView1.Columns.Contains("Estado"))
                    dataGridView1.Columns["Estado"].HeaderText = "Estado del tiquete";

                // Renombrar encabezado si existe la columna
                if (dataGridView1.Columns.Contains("IdTiquete"))
                {
                    dataGridView1.Columns["IdTiquete"].HeaderText = "N° Tiquete";
                    dataGridView1.Columns["IdTiquete"].Width = 80; // opcional
                }

                if (dataGridView1.Columns.Contains("Cedula"))
                    dataGridView1.Columns["Cedula"].HeaderText = "Cédula";

                if (dataGridView1.Columns.Contains("Apellido"))
                    dataGridView1.Columns["Apellido"].HeaderText = "Apellido";

                if (dataGridView1.Columns.Contains("Rol"))
                    dataGridView1.Columns["Rol"].HeaderText = "Rol";




                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;



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
                    cbmReporte.Items.Add("Licencias instaladas por equipo");
                    cbmReporte.Items.Add("Total de licencias disponibles");
                    cbmReporte.Items.Add("Stock vs instaladas por software");
                    cbmReporte.Items.Add("Softwares clasificados por tipo de licencia");
                    break;

                case "Computadora":
                    cbmReporte.Items.Add("Cantidad total de computadoras");
                    cbmReporte.Items.Add("Cantidad por tipo de equipo");
                    cbmReporte.Items.Add("Cantidad por marca");
                    cbmReporte.Items.Add("Cantidad por departamento");
                    cbmReporte.Items.Add("Cantidad por empleado");
                    cbmReporte.Items.Add("Computadoras asignadas");
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
                        query = "SELECT \r\n    " +
                            "Cedula,\r\n    Nombre,\r\n " +
                            "   Apellido1,\r\n    Rol,\r\n  " +
                            "  Activo\r\nFROM Usuarios\r\n" +
                            "ORDER BY Rol, Nombre;\r\n";
                        break;

                    case "Cantidad de usuarios por rol":
                        query = "SELECT Cedula, Nombre, Apellido1, Rol\r\nFROM Usuarios\r\n" +
                            "ORDER BY Rol, Nombre;\r\n";
                        break;

                    case "Últimos 5 usuarios agregados":
                        query = "SELECT TOP 5 * FROM Usuarios ORDER BY Fecha_Creacion DESC";
                        break;

                    case "Cantidad de técnicos":
                        query = @"SELECT  Cedula, Nombre, Apellido1,Apellido2, Activo, Fecha_Creacion
                            FROM Usuarios
                             WHERE Rol = 'Tecnico'";
                        break;

                    case "Usuarios creados por día":
                        query = @"SELECT CAST(Fecha_Creacion AS DATE) AS Dia, Cedula, Nombre,
                             Apellido1, Apellido2,  Rol FROM Usuarios
                            ORDER BY Fecha_Creacion DESC";
                        break;

                    


                }
            }

            if (modulo == "Software")
            {
                switch (reporte)
                {
                    case "Cantidad total de softwares":
                        query = "SELECT\r\n    IdSoftware,\r\n    Nombre,\r\n  TipoLicencia,\r\n  StockLicencias," +
                            "\r\n LicenciasInstaladas,\r\n LicenciasDisponibles\r\nFROM Software\r\nORDER BY Nombre;\r\n";
                        break;

                    case "Licencias instaladas por equipo":
                        query = @"SELECT 
                                s.Nombre        AS Software,
                                s.TipoLicencia,
                                c.IdComputadora,
                                c.Marca         AS MarcaEquipo,
                                c.TipoEquipo,
                                u.Cedula        AS CedulaEmpleado,
                                u.Nombre        AS NombreEmpleado,
                                u.Apellido1     AS ApellidoEmpleado,
                                i.FechaInstalacion
                            FROM InstalacionesSoftware i
                            INNER JOIN Software s 
                                ON i.IdSoftware = s.IdSoftware
                            INNER JOIN Computadoras c 
                                ON i.IdComputadora = c.IdComputadora
                            INNER JOIN Empleados e 
                                ON c.IdEmpleado = e.IdEmpleado
                            INNER JOIN Usuarios u 
                                ON e.Cedula = u.Cedula
                            ORDER BY i.FechaInstalacion DESC;
                            ";
                        break;


                    case "Total de licencias disponibles":
                        query = "SELECT \r\n    Nombre AS Software,\r\n " +
                            "   TipoLicencia,\r\n    StockLicencias,\r\n  " +
                            "  LicenciasInstaladas,\r\n  " +
                            "  LicenciasDisponibles\r\nFROM Software\r\n" +
                            "WHERE LicenciasDisponibles > 0\r\n" +
                            "ORDER BY LicenciasDisponibles DESC;\r\n";
                        break;

                    case "Stock vs instaladas por software":
                        query = "SELECT Nombre, StockLicencias, LicenciasInstaladas FROM Software";
                        break;

                    case "Softwares clasificados por tipo de licencia":
                        query = "SELECT\r\n    TipoLicencia,\r\n    Nombre AS Software,\r\n " +
                            "   StockLicencias,\r\n    LicenciasInstaladas,\r\n  " +
                            "  LicenciasDisponibles\r\n" +
                            "FROM Software\r\nORDER BY TipoLicencia, Nombre;\r\n";
                        break;
                }
            }

            if (modulo == "Computadora")
            {
                switch (reporte)
                {
                    case "Cantidad total de computadoras":
                        query = "SELECT\r\n    TipoEquipo,\r\n  " +
                            "  Marca,\r\n   " +
                            " COUNT(*) AS Total\r\n" +
                            "FROM Computadoras\r\n" +
                            "GROUP BY TipoEquipo, Marca\r\n" +
                            "ORDER BY TipoEquipo, Marca;\r\n";
                        break;

                    case "Cantidad por tipo de equipo":
                        query = "SELECT TipoEquipo, COUNT(*) AS Total FROM Computadoras GROUP BY TipoEquipo";
                        break;

                    case "Cantidad por marca":
                        query = "SELECT Marca, COUNT(*) AS Total FROM Computadoras GROUP BY Marca";
                        break;

                    case "Cantidad por departamento":
                        query = @" SELECT d.Nombre AS Departamento,
                          COUNT(c.IdComputadora) AS Total FROM Computadoras c
                         INNER JOIN Departamentos d  ON c.IdDepartamento = d.IdDepartamento
                         GROUP BY d.Nombre
                            ORDER BY d.Nombre";
                         break;

                    case "Cantidad por empleado":
                        query = @" SELECT  u.Nombre + ' ' + u.Apellido1 AS Empleado, COUNT(c.IdComputadora) AS Total
                         FROM Computadoras c INNER JOIN Empleados e   ON c.IdEmpleado = e.IdEmpleado INNER JOIN Usuarios u
                         ON e.Cedula = u.Cedula GROUP BY u.Nombre, u.Apellido1 ORDER BY Empleado";
                        break;

                    case "Computadoras asignadas":
                        query = @"
                          SELECT 
                           c.IdComputadora,
                         c.Marca,
                         c.TipoEquipo,
                         c.Serie,
                         u.Cedula,
                         u.Nombre,
                         u.Apellido1,
                         d.Nombre AS Departamento
                        FROM Computadoras c
                        INNER JOIN Empleados e 
                        ON c.IdEmpleado = e.IdEmpleado
                         INNER JOIN Usuarios u 
                           ON e.Cedula = u.Cedula
                        INNER JOIN Departamentos d 
                       ON c.IdDepartamento = d.IdDepartamento
                         ORDER BY d.Nombre, u.Nombre";
                        break;

                }
            }


            if (modulo == "Tiquete")
            {
                switch (reporte)
                {
                    case "Total de tiquetes":
                        query = "SELECT \r\n    t.IdTiquete,\r\n " +
                            "   t.Descripcion,\r\n " +
                            "   e.Nombre AS Estado,\r\n   " +
                            " t.FechaCreacion,\r\n    u.Nombre + ' ' + u.Apellido1 AS Tecnico\r\n" +
                            "FROM Tiquetes t\r\nINNER JOIN EstadoTiquete e ON t.IdEstado = e.IdEstado\r\n" +
                            "LEFT JOIN Usuarios u ON t.TecnicoAsignado = u.Cedula\r\n" +
                            "ORDER BY t.FechaCreacion DESC;\r\n";
                        break;

                    case "Tiquetes por estado":
                        query = @"
                        SELECT 
                        e.Nombre AS Estado,
                         COUNT(*) AS Total
                         FROM Tiquetes t
                         INNER JOIN EstadoTiquete e 
                        ON t.IdEstado = e.IdEstado
                        GROUP BY e.Nombre
                         ORDER BY e.Nombre";
                        break;


                    case "Total de tiquetes asignados":
                        query = "SELECT \r\n    u.Cedula,\r\n    u.Nombre,\r\n   " +
                            " u.Apellido1,\r\n    COUNT(*) AS TotalAsignados\r\n" +
                            "FROM Tiquetes t\r\n" +
                            "INNER JOIN Usuarios u \r\n  " +
                            "  ON t.TecnicoAsignado = u.Cedula\r\n" +
                            "GROUP BY u.Cedula, u.Nombre, u.Apellido1\r\n" +
                            "ORDER BY TotalAsignados DESC;\r\n";

                        break;

                    case "Últimos 5 tiquetes generados":
                        query = "SELECT TOP 5 * FROM Tiquetes ORDER BY FechaCreacion DESC";
                        break;

                    case "Tiquetes por técnico asignado":
                        query = @"
        SELECT 
            u.Cedula AS TecnicoAsignado,
            u.Nombre + ' ' + u.Apellido1 AS Tecnico,
            COUNT(*) AS Total
        FROM Tiquetes t
        INNER JOIN Usuarios u 
            ON t.TecnicoAsignado = u.Cedula
        GROUP BY u.Cedula, u.Nombre, u.Apellido1
        ORDER BY Total DESC";
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Validar que sea la columna IdTiquete
            if (dataGridView1.Columns[e.ColumnIndex].Name == "IdTiquete"
                && e.Value != null
                && int.TryParse(e.Value.ToString(), out int id))
            {
                // Mostrar formato visual sin tocar el valor real
                e.Value = $"TQ-{id:D5}";
                e.FormattingApplied = true;
            }
        }

    }
}
