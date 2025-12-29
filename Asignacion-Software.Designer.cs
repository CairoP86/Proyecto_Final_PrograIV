namespace Proyecto_Final_PrograIV
{
    partial class Asignacion_de_Software
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLicenciasDisponibles = new System.Windows.Forms.Label();
            this.txtLicenciasDisponibles = new System.Windows.Forms.TextBox();
            this.txtTecnico = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbmSoftware = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnInstalar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvComputadoras = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputadoras)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvComputadoras);
            this.groupBox2.Controls.Add(this.lblLicenciasDisponibles);
            this.groupBox2.Controls.Add(this.txtLicenciasDisponibles);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTecnico);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbmSoftware);
            this.groupBox2.Controls.Add(this.txtFecha);
            this.groupBox2.Controls.Add(this.btnInstalar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(103, 165);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(744, 467);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // lblLicenciasDisponibles
            // 
            this.lblLicenciasDisponibles.AutoSize = true;
            this.lblLicenciasDisponibles.Location = new System.Drawing.Point(93, 59);
            this.lblLicenciasDisponibles.Name = "lblLicenciasDisponibles";
            this.lblLicenciasDisponibles.Size = new System.Drawing.Size(140, 16);
            this.lblLicenciasDisponibles.TabIndex = 19;
            this.lblLicenciasDisponibles.Text = "Licencias disponibles:";
            // 
            // txtLicenciasDisponibles
            // 
            this.txtLicenciasDisponibles.BackColor = System.Drawing.Color.White;
            this.txtLicenciasDisponibles.Location = new System.Drawing.Point(259, 59);
            this.txtLicenciasDisponibles.Name = "txtLicenciasDisponibles";
            this.txtLicenciasDisponibles.ReadOnly = true;
            this.txtLicenciasDisponibles.Size = new System.Drawing.Size(208, 22);
            this.txtLicenciasDisponibles.TabIndex = 18;
            // 
            // txtTecnico
            // 
            this.txtTecnico.Enabled = false;
            this.txtTecnico.Location = new System.Drawing.Point(253, 323);
            this.txtTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.txtTecnico.Name = "txtTecnico";
            this.txtTecnico.Size = new System.Drawing.Size(167, 22);
            this.txtTecnico.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(93, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Seleccione el Software:";
            // 
            // cbmSoftware
            // 
            this.cbmSoftware.FormattingEnabled = true;
            this.cbmSoftware.Location = new System.Drawing.Point(259, 20);
            this.cbmSoftware.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbmSoftware.Name = "cbmSoftware";
            this.cbmSoftware.Size = new System.Drawing.Size(208, 24);
            this.cbmSoftware.TabIndex = 13;
            this.cbmSoftware.SelectedIndexChanged += new System.EventHandler(this.cbmSoftware_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(93, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(441, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Seleccione la computadora donde se instalará el software";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(253, 295);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(168, 22);
            this.txtFecha.TabIndex = 9;
            // 
            // btnInstalar
            // 
            this.btnInstalar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnInstalar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstalar.ForeColor = System.Drawing.Color.White;
            this.btnInstalar.Location = new System.Drawing.Point(96, 360);
            this.btnInstalar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInstalar.Name = "btnInstalar";
            this.btnInstalar.Size = new System.Drawing.Size(371, 50);
            this.btnInstalar.TabIndex = 6;
            this.btnInstalar.Text = "Instalar";
            this.btnInstalar.UseVisualStyleBackColor = false;
            this.btnInstalar.Click += new System.EventHandler(this.btnInstalar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(93, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha instalacion :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(93, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tecnico que instaló  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(103, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(737, 78);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(52, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proceso de Instalacion Software";
            // 
            // dgvComputadoras
            // 
            this.dgvComputadoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComputadoras.Location = new System.Drawing.Point(96, 117);
            this.dgvComputadoras.Name = "dgvComputadoras";
            this.dgvComputadoras.RowHeadersWidth = 51;
            this.dgvComputadoras.RowTemplate.Height = 24;
            this.dgvComputadoras.Size = new System.Drawing.Size(574, 159);
            this.dgvComputadoras.TabIndex = 20;
            // 
            // Asignacion_de_Software
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(956, 678);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Asignacion_de_Software";
            this.Text = "Asignacion_de_Software";
            this.Load += new System.EventHandler(this.Asignacion_de_Software_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputadoras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbmSoftware;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Button btnInstalar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTecnico;
        private System.Windows.Forms.Label lblLicenciasDisponibles;
        private System.Windows.Forms.TextBox txtLicenciasDisponibles;
        private System.Windows.Forms.DataGridView dgvComputadoras;
    }
}