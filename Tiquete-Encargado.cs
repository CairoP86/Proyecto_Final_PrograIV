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

namespace Proyecto_Final_PrograIV
{
    public partial class Tiquete_Encargado : Form
    {

        int idSeleccionado = -1;
        public Tiquete_Encargado()
        {
            InitializeComponent();
        }

        private void CargarEmpleados()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
            SELECT Cedula,
                   CONCAT(Nombre, ' ', Apellido1, ' ', Apellido2) AS NombreCompleto
            FROM Usuarios
            ORDER BY NombreCompleto";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbmEmpleado.DataSource = dt;
                cbmEmpleado.DisplayMember = "Nombre";
                cbmEmpleado.ValueMember = "Cedula";

                cbmEmpleado.SelectedIndex = -1; 
            }
        }

        private void CargarTecnicos()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
            SELECT Cedula,
                   CONCAT(Nombre, ' ', Apellido1, ' ', Apellido2) AS NombreCompleto
            FROM Usuarios
            WHERE Rol IN ('Tecnico', 'TI')
            ORDER BY NombreCompleto";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbmTecnico.DataSource = dt;
                cbmTecnico.DisplayMember = "NombreCompleto";
                cbmTecnico.ValueMember = "Cedula";

                cbmTecnico.SelectedIndex = -1;
            }
        }

        private void CargarEstados()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT IdEstado, Nombre FROM EstadoTiquete";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbmEstado.DataSource = dt;
                cbmEstado.DisplayMember = "Nombre";
                cbmEstado.ValueMember = "IdEstado";
                cbmEstado.SelectedIndex = -1;
            }
        }

        private void CargarTiquetes()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
            SELECT 
                t.IdTiquete,
                t.CedulaEmpleado,
                u.Nombre + ' ' + u.Apellido1 AS Empleado,
                t.Descripcion,
                t.IdEstado,
                e.Nombre AS Estado,
                t.TecnicoAsignado,
                tec.Nombre + ' ' + tec.Apellido1 AS Tecnico,
                t.FechaCreacion,
                t.FechaAtencion
            FROM Tiquetes t
            INNER JOIN Usuarios u ON u.Cedula = t.CedulaEmpleado
            INNER JOIN EstadoTiquete e ON e.IdEstado = t.IdEstado
            LEFT JOIN Usuarios tec ON tec.Cedula = t.TecnicoAsignado";

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);

                dgvListaTiquetes.DataSource = dt;
            }
        }


        private void Limpiar()
        {
            cbmEmpleado.SelectedIndex = -1;
            cbmTecnico.SelectedIndex = -1;
            cbmEstado.SelectedIndex = -1;
            txtDescripcion.Clear();
            idSeleccionado = -1;
        }

        private void Tiquete_Encargado_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarTecnicos();
            CargarEstados();
            CargarTiquetes();
            

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (cbmEmpleado.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe seleccionar un empleado y escribir una descripción.");
                return;
            }

            int estadoInicial = 1; // Generado

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                INSERT INTO Tiquetes (CedulaEmpleado, Descripcion, IdEstado, TecnicoAsignado)
                VALUES (@emp, @desc, @est, @tec)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@emp", cbmEmpleado.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@est", estadoInicial);

                    if (cbmTecnico.SelectedIndex == -1)
                        cmd.Parameters.AddWithValue("@tec", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@tec", cbmTecnico.SelectedValue.ToString());

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Tiquete generado correctamente.");
            CargarTiquetes();
            Limpiar();
        }

        private void dgvListaTiquetes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idSeleccionado = Convert.ToInt32(dgvListaTiquetes.Rows[e.RowIndex].Cells["IdTiquete"].Value);
            txtDescripcion.Text = dgvListaTiquetes.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un tiquete de la lista.");
                return;
            }

            if (cbmEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un estado.");
                return;
            }

            if (cbmEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un empleado.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción.");
                return;
            }

            // ==========
            // Capturar valores
            // ==========

            int nuevoEstado = (int)cbmEstado.SelectedValue;
            string empleado = cbmEmpleado.SelectedValue.ToString();

            // Tecnico puede ser null (si no asignó a nadie)
            string tecnico = cbmTecnico.SelectedIndex == -1
                             ? null
                             : cbmTecnico.SelectedValue.ToString();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
        UPDATE Tiquetes
        SET 
            CedulaEmpleado = @emp,
            Descripcion = @desc,
            IdEstado = @est,
            TecnicoAsignado = @tec,
            FechaAtencion = CASE 
                                WHEN @est = 3 THEN GETDATE()
                                ELSE FechaAtencion
                            END
        WHERE IdTiquete = @id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@emp", empleado);
                cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@est", nuevoEstado);

                if (tecnico == null)
                    cmd.Parameters.AddWithValue("@tec", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@tec", tecnico);

                cmd.Parameters.AddWithValue("@id", idSeleccionado);

                cmd.ExecuteNonQuery();

                // ============================
                // 🔔 NOTIFICACIONES AUTOMÁTICAS
                // ============================

                // 1. Notificación al técnico cuando el TI asigna uno
                if (!string.IsNullOrEmpty(tecnico))
                {
                    NotificacionesDAO.Crear(
                        tecnico,
                        idSeleccionado,
                        $"Se te ha asignado el ticket #{idSeleccionado}."
                    );
                }

                
            }

            MessageBox.Show("Tiquete actualizado correctamente.");

            CargarTiquetes();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un tiquete para eliminar.");
                return;
            }

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Tiquetes WHERE IdTiquete = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idSeleccionado);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Tiquete eliminado.");
            CargarTiquetes();
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT t.IdTiquete, u.Nombre + ' ' + u.Apellido1 AS Empleado, 
                       t.Descripcion, e.Nombre AS Estado,
                       tec.Nombre + ' ' + tec.Apellido1 AS Tecnico
                FROM Tiquetes t
                INNER JOIN Usuarios u ON u.Cedula = t.CedulaEmpleado
                INNER JOIN EstadoTiquete e ON e.IdEstado = t.IdEstado
                LEFT JOIN Usuarios tec ON tec.Cedula = t.TecnicoAsignado
                WHERE 1 = 1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (cbmEmpleado.SelectedIndex != -1)
                {
                    query += " AND t.CedulaEmpleado = @emp";
                    cmd.Parameters.AddWithValue("@emp", cbmEmpleado.SelectedValue);
                }

                if (!string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    query += " AND t.Descripcion LIKE @desc";
                    cmd.Parameters.AddWithValue("@desc", "%" + txtDescripcion.Text + "%");
                }

                cmd.CommandText = query;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                dgvListaTiquetes.DataSource = dt;
            }
        }

        private void dgvListaTiquetes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaTiquetes.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgvListaTiquetes.SelectedRows[0];

            idSeleccionado = Convert.ToInt32(row.Cells["IdTiquete"].Value);

            // Descripción
            txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();

            // Empleado
            cbmEmpleado.SelectedValue = row.Cells["CedulaEmpleado"].Value.ToString();

            // Técnico
            if (row.Cells["TecnicoAsignado"].Value == DBNull.Value)
                cbmTecnico.SelectedIndex = -1;
            else
                cbmTecnico.SelectedValue = row.Cells["TecnicoAsignado"].Value.ToString();

            // Estado
            cbmEstado.SelectedValue = Convert.ToInt32(row.Cells["IdEstado"].Value);
        }
    }
}
