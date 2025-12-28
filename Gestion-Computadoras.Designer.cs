namespace Proyecto_Final_PrograIV
{
    partial class compu_mantenimiento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbmAsignado = new System.Windows.Forms.ComboBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.cbmTipo = new System.Windows.Forms.ComboBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dtvComputadoras = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtvComputadoras)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(43, 74);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(353, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(72, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos del Equipo ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = " Empleado Asignado :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Serie:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Marca:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cmbDepartamento);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbmAsignado);
            this.groupBox2.Controls.Add(this.txtSerie);
            this.groupBox2.Controls.Add(this.txtMarca);
            this.groupBox2.Controls.Add(this.cbmTipo);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnActualizar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(43, 155);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(353, 459);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbDepartamento.Location = new System.Drawing.Point(164, 174);
            this.cmbDepartamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(165, 24);
            this.cmbDepartamento.TabIndex = 18;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(20, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Departamento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(16, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Busqueda por marca o serie :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(574, 27);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(125, 31);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbmAsignado
            // 
            this.cbmAsignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmAsignado.FormattingEnabled = true;
            this.cbmAsignado.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbmAsignado.Location = new System.Drawing.Point(164, 224);
            this.cbmAsignado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbmAsignado.Name = "cbmAsignado";
            this.cbmAsignado.Size = new System.Drawing.Size(165, 24);
            this.cbmAsignado.TabIndex = 11;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(104, 127);
            this.txtSerie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(225, 22);
            this.txtSerie.TabIndex = 10;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(104, 39);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(225, 22);
            this.txtMarca.TabIndex = 9;
            // 
            // cbmTipo
            // 
            this.cbmTipo.FormattingEnabled = true;
            this.cbmTipo.Location = new System.Drawing.Point(104, 83);
            this.cbmTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbmTipo.Name = "cbmTipo";
            this.cbmTipo.Size = new System.Drawing.Size(225, 24);
            this.cbmTipo.TabIndex = 8;
            this.cbmTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(23, 370);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(280, 30);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(23, 338);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(281, 28);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.btnAgregar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(23, 304);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(281, 30);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBuscar);
            this.groupBox3.Controls.Add(this.btnBuscar);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(402, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(740, 65);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(265, 27);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(258, 26);
            this.txtBuscar.TabIndex = 0;
            // 
            // dtvComputadoras
            // 
            this.dtvComputadoras.BackgroundColor = System.Drawing.Color.White;
            this.dtvComputadoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvComputadoras.GridColor = System.Drawing.Color.White;
            this.dtvComputadoras.Location = new System.Drawing.Point(402, 155);
            this.dtvComputadoras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtvComputadoras.Name = "dtvComputadoras";
            this.dtvComputadoras.ReadOnly = true;
            this.dtvComputadoras.RowHeadersWidth = 51;
            this.dtvComputadoras.RowTemplate.Height = 24;
            this.dtvComputadoras.Size = new System.Drawing.Size(741, 459);
            this.dtvComputadoras.TabIndex = 6;
            this.dtvComputadoras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtvComputadoras_CellClick);
            // 
            // compu_mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1209, 654);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dtvComputadoras);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "compu_mantenimiento";
            this.Text = "Gestion de Computadoras";
            this.Load += new System.EventHandler(this.compu_mantenimiento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtvComputadoras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbmTipo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.ComboBox cbmAsignado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dtvComputadoras;
    }
}