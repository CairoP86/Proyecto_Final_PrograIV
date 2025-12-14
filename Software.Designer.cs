namespace Proyecto_Final_PrograIV
{
    partial class Software
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
            this.dgvSoftware = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLicenDisponibles = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.cbmCampo = new System.Windows.Forms.ComboBox();
            this.cbmDato = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStockLic = new System.Windows.Forms.TextBox();
            this.txtTipoLicInstalada = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cbmTipoLic = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoftware)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSoftware
            // 
            this.dgvSoftware.BackgroundColor = System.Drawing.Color.White;
            this.dgvSoftware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoftware.Location = new System.Drawing.Point(298, 68);
            this.dgvSoftware.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSoftware.Name = "dgvSoftware";
            this.dgvSoftware.RowHeadersWidth = 51;
            this.dgvSoftware.RowTemplate.Height = 24;
            this.dgvSoftware.Size = new System.Drawing.Size(326, 415);
            this.dgvSoftware.TabIndex = 5;
            this.dgvSoftware.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosUsuario_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLicenDisponibles);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtVersion);
            this.groupBox2.Controls.Add(this.cbmCampo);
            this.groupBox2.Controls.Add(this.cbmDato);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnActualizar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtStockLic);
            this.groupBox2.Controls.Add(this.txtTipoLicInstalada);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.cbmTipoLic);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(16, 58);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(263, 425);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // txtLicenDisponibles
            // 
            this.txtLicenDisponibles.Location = new System.Drawing.Point(128, 291);
            this.txtLicenDisponibles.Margin = new System.Windows.Forms.Padding(2);
            this.txtLicenDisponibles.Name = "txtLicenDisponibles";
            this.txtLicenDisponibles.ReadOnly = true;
            this.txtLicenDisponibles.Size = new System.Drawing.Size(126, 20);
            this.txtLicenDisponibles.TabIndex = 18;
            this.txtLicenDisponibles.TextChanged += new System.EventHandler(this.cmbLicenDisponibles_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 292);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = " Licencias disponibles :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Seleccione el dato :";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(128, 151);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(2);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(126, 20);
            this.txtVersion.TabIndex = 16;
            this.txtVersion.TextChanged += new System.EventHandler(this.cmbVersion_TextChanged);
            // 
            // cbmCampo
            // 
            this.cbmCampo.FormattingEnabled = true;
            this.cbmCampo.Location = new System.Drawing.Point(128, 53);
            this.cbmCampo.Margin = new System.Windows.Forms.Padding(2);
            this.cbmCampo.Name = "cbmCampo";
            this.cbmCampo.Size = new System.Drawing.Size(126, 21);
            this.cbmCampo.TabIndex = 9;
            this.cbmCampo.SelectedIndexChanged += new System.EventHandler(this.cbmCampo_SelectedIndexChanged);
            // 
            // cbmDato
            // 
            this.cbmDato.FormattingEnabled = true;
            this.cbmDato.Location = new System.Drawing.Point(128, 88);
            this.cbmDato.Margin = new System.Windows.Forms.Padding(2);
            this.cbmDato.Name = "cbmDato";
            this.cbmDato.Size = new System.Drawing.Size(126, 21);
            this.cbmDato.TabIndex = 10;
            this.cbmDato.SelectedIndexChanged += new System.EventHandler(this.cbmDato_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Seleccione el campo :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 151);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Versión:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(122, 381);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(53, 28);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar ";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(191, 381);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(53, 28);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(188, 335);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(57, 28);
            this.btnActualizar.TabIndex = 12;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(122, 335);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(52, 28);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar ";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nombre:";
            // 
            // txtStockLic
            // 
            this.txtStockLic.Location = new System.Drawing.Point(128, 249);
            this.txtStockLic.Margin = new System.Windows.Forms.Padding(2);
            this.txtStockLic.Name = "txtStockLic";
            this.txtStockLic.Size = new System.Drawing.Size(126, 20);
            this.txtStockLic.TabIndex = 9;
            this.txtStockLic.TextChanged += new System.EventHandler(this.cmbStockLic_TextChanged);
            // 
            // txtTipoLicInstalada
            // 
            this.txtTipoLicInstalada.Location = new System.Drawing.Point(128, 214);
            this.txtTipoLicInstalada.Margin = new System.Windows.Forms.Padding(2);
            this.txtTipoLicInstalada.Name = "txtTipoLicInstalada";
            this.txtTipoLicInstalada.ReadOnly = true;
            this.txtTipoLicInstalada.Size = new System.Drawing.Size(126, 20);
            this.txtTipoLicInstalada.TabIndex = 8;
            this.txtTipoLicInstalada.TextChanged += new System.EventHandler(this.cbmTipoLicInstalada_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(128, 120);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(126, 20);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.TextChanged += new System.EventHandler(this.cmbNombre_TextChanged);
            // 
            // cbmTipoLic
            // 
            this.cbmTipoLic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmTipoLic.FormattingEnabled = true;
            this.cbmTipoLic.Location = new System.Drawing.Point(128, 182);
            this.cbmTipoLic.Margin = new System.Windows.Forms.Padding(2);
            this.cbmTipoLic.Name = "cbmTipoLic";
            this.cbmTipoLic.Size = new System.Drawing.Size(126, 21);
            this.cbmTipoLic.TabIndex = 5;
            this.cbmTipoLic.SelectedIndexChanged += new System.EventHandler(this.cbmTipoLic_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 214);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Licencias Instaladas :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 251);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Stock de Licencia :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo de Licencia :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(263, 40);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos del Software";
            // 
            // Software
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(642, 501);
            this.Controls.Add(this.dgvSoftware);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Software";
            this.Text = "Software";
            this.Load += new System.EventHandler(this.Software_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoftware)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSoftware;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.ComboBox cbmCampo;
        private System.Windows.Forms.ComboBox cbmDato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStockLic;
        private System.Windows.Forms.TextBox txtTipoLicInstalada;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cbmTipoLic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLicenDisponibles;
        private System.Windows.Forms.Label label9;
    }
}