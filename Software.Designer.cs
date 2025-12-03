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
            this.dgvDatosUsuario = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbmCampo = new System.Windows.Forms.ComboBox();
            this.cbmDato = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellido1 = new System.Windows.Forms.TextBox();
            this.txtApellido2 = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cbmTipoLic = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosUsuario)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDatosUsuario
            // 
            this.dgvDatosUsuario.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatosUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosUsuario.Location = new System.Drawing.Point(397, 84);
            this.dgvDatosUsuario.Name = "dgvDatosUsuario";
            this.dgvDatosUsuario.RowHeadersWidth = 51;
            this.dgvDatosUsuario.RowTemplate.Height = 24;
            this.dgvDatosUsuario.Size = new System.Drawing.Size(434, 511);
            this.dgvDatosUsuario.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.cbmCampo);
            this.groupBox2.Controls.Add(this.cbmDato);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnActualizar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtApellido1);
            this.groupBox2.Controls.Add(this.txtApellido2);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.cbmTipoLic);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(22, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 523);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Seleccione el dato :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 186);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 22);
            this.textBox1.TabIndex = 16;
            // 
            // cbmCampo
            // 
            this.cbmCampo.FormattingEnabled = true;
            this.cbmCampo.Location = new System.Drawing.Point(171, 65);
            this.cbmCampo.Name = "cbmCampo";
            this.cbmCampo.Size = new System.Drawing.Size(166, 24);
            this.cbmCampo.TabIndex = 9;
            // 
            // cbmDato
            // 
            this.cbmDato.FormattingEnabled = true;
            this.cbmDato.Location = new System.Drawing.Point(171, 108);
            this.cbmDato.Name = "cbmDato";
            this.cbmDato.Size = new System.Drawing.Size(166, 24);
            this.cbmDato.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Seleccione el campo :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Versión:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(162, 469);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(71, 35);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar ";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(255, 469);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(71, 35);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(250, 412);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(76, 35);
            this.btnActualizar.TabIndex = 12;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(162, 412);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(69, 35);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar ";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nombre:";
            // 
            // txtApellido1
            // 
            this.txtApellido1.Location = new System.Drawing.Point(171, 306);
            this.txtApellido1.Name = "txtApellido1";
            this.txtApellido1.Size = new System.Drawing.Size(166, 22);
            this.txtApellido1.TabIndex = 9;
            // 
            // txtApellido2
            // 
            this.txtApellido2.Location = new System.Drawing.Point(171, 264);
            this.txtApellido2.Name = "txtApellido2";
            this.txtApellido2.Size = new System.Drawing.Size(166, 22);
            this.txtApellido2.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(171, 148);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(166, 22);
            this.txtNombre.TabIndex = 6;
            // 
            // cbmTipoLic
            // 
            this.cbmTipoLic.FormattingEnabled = true;
            this.cbmTipoLic.Location = new System.Drawing.Point(171, 224);
            this.cbmTipoLic.Name = "cbmTipoLic";
            this.cbmTipoLic.Size = new System.Drawing.Size(166, 24);
            this.cbmTipoLic.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Licencias Instaladas :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Stock de Licencia :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo de Licencia :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 49);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos del Software";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 360);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = " Licencias disponibles :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(171, 358);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(166, 22);
            this.textBox2.TabIndex = 18;
            // 
            // Software
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(856, 617);
            this.Controls.Add(this.dgvDatosUsuario);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Software";
            this.Text = "Software";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosUsuario)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatosUsuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbmCampo;
        private System.Windows.Forms.ComboBox cbmDato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApellido1;
        private System.Windows.Forms.TextBox txtApellido2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cbmTipoLic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
    }
}