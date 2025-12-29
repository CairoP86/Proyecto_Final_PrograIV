using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_PrograIV
{
    public partial class Tiquete_Encargado : Form
    {
        // Guarda el ID del tiquete seleccionado en el DataGrid
        private int idSeleccionado = -1;

        public Tiquete_Encargado()
        {
            InitializeComponent();
        }

        // ===============================
        // CARGAR EMPLEADOS (QUIEN REPORTA)
        // ===============================
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

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbmEmpleado.DataSource = dt;
                cbmEmpleado.DisplayMember = "NombreCompleto"; // ✅ corregido
                cbmEmpleado.ValueMember = "Cedula";
                cbmEmpleado.SelectedIndex = -1;
            }
        }

        // ===============================
        // CARGAR TÉCNICOS
        // ===============================
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

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbmTecnico.DataSource = dt;
                cbmTecnico.DisplayMember = "NombreCompleto";
                cbmTecnico.ValueMember = "Cedula";
                cbmTecnico.SelectedIndex = -1;
            }
        }

        // ===============================
        // CARGAR ESTADOS
        // ===============================
        private void CargarEstados()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdEstado, Nombre FROM EstadoTiquete", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cbmEstado.DataSource = dt;
                cbmEstado.DisplayMember = "Nombre";
                cbmEstado.ValueMember = "IdEstado";
                cbmEstado.SelectedIndex = -1;
            }
        }

        // ===============================
        // CARGAR TIQUETES
        // ===============================
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

                // Mejora visual (opcional pero segura)
                dgvListaTiquetes.Columns["CedulaEmpleado"].Visible = false;
                dgvListaTiquetes.Columns["IdEstado"].Visible = false;
                dgvListaTiquetes.Columns["TecnicoAsignado"].Visible = false;
            }
        }

        // ===============================
        // LIMPIAR FORMULARIO
        // ===============================
        private void Limpiar()
        {
            cbmEmpleado.SelectedIndex = -1;
            cbmTecnico.SelectedIndex = -1;
            cbmEstado.SelectedIndex = -1;
            txtDescripcion.Clear();
            idSeleccionado = -1;
        }

        // ===============================
        // LOAD
        // ===============================
        private void Tiquete_Encargado_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarTecnicos();
            CargarEstados();
            CargarTiquetes();
        }

        // ===============================
        // INGRESAR NUEVO TIQUETE
        // ===============================
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (cbmEmpleado.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe seleccionar un empleado y escribir una descripción.");
                return;
            }

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Tiquetes (CedulaEmpleado, Descripcion, IdEstado, TecnicoAsignado)
                    VALUES (@emp, @desc, 1, @tec)", conn);

                cmd.Parameters.AddWithValue("@emp", cbmEmpleado.SelectedValue);
                cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);

                if (cbmTecnico.SelectedIndex == -1)
                    cmd.Parameters.AddWithValue("@tec", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@tec", cbmTecnico.SelectedValue);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Tiquete generado correctamente.");
            CargarTiquetes();
            Limpiar();
        }

        // ===============================
        // SELECCIÓN EN DATAGRID (ÚNICO EVENTO)
        // ===============================
        private void dgvListaTiquetes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaTiquetes.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgvListaTiquetes.SelectedRows[0];

            idSeleccionado = Convert.ToInt32(row.Cells["IdTiquete"].Value);
            txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();

            cbmEmpleado.SelectedValue = row.Cells["CedulaEmpleado"].Value.ToString();

            if (row.Cells["TecnicoAsignado"].Value == DBNull.Value)
                cbmTecnico.SelectedIndex = -1;
            else
                cbmTecnico.SelectedValue = row.Cells["TecnicoAsignado"].Value.ToString();

            cbmEstado.SelectedValue = Convert.ToInt32(row.Cells["IdEstado"].Value);
        }

        // ===============================
        // ACTUALIZAR TIQUETE
        // ===============================
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un tiquete.");
                return;
            }

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
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
                    WHERE IdTiquete = @id", conn);

                cmd.Parameters.AddWithValue("@emp", cbmEmpleado.SelectedValue);
                cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@est", cbmEstado.SelectedValue);
                cmd.Parameters.AddWithValue("@id", idSeleccionado);

                if (cbmTecnico.SelectedIndex == -1)
                    cmd.Parameters.AddWithValue("@tec", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@tec", cbmTecnico.SelectedValue);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Tiquete actualizado correctamente.");
            CargarTiquetes();
            Limpiar();
        }

        // ===============================
        // ELIMINAR TIQUETE
        // ===============================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un tiquete.");
                return;
            }

            if (MessageBox.Show("¿Desea eliminar este tiquete?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Tiquetes WHERE IdTiquete = @id", conn);
                cmd.Parameters.AddWithValue("@id", idSeleccionado);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Tiquete eliminado.");
            CargarTiquetes();
            Limpiar();
        }
    }
}
