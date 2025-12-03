namespace Proyecto_Final_PrograIV
{
    partial class Tickets
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
            this.dgvInfoTicket = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbmUsuario = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbmTecnico = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDesc = new System.Windows.Forms.DataGridView();
            this.btnAsignarTecnico = new System.Windows.Forms.Button();
            this.btnCrearTicket = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInfoTicket
            // 
            this.dgvInfoTicket.BackgroundColor = System.Drawing.Color.White;
            this.dgvInfoTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoTicket.Location = new System.Drawing.Point(89, 120);
            this.dgvInfoTicket.Name = "dgvInfoTicket";
            this.dgvInfoTicket.RowHeadersWidth = 51;
            this.dgvInfoTicket.RowTemplate.Height = 24;
            this.dgvInfoTicket.Size = new System.Drawing.Size(810, 159);
            this.dgvInfoTicket.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tecnico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Estado";
            // 
            // cbmUsuario
            // 
            this.cbmUsuario.FormattingEnabled = true;
            this.cbmUsuario.Location = new System.Drawing.Point(170, 50);
            this.cbmUsuario.Name = "cbmUsuario";
            this.cbmUsuario.Size = new System.Drawing.Size(133, 24);
            this.cbmUsuario.TabIndex = 5;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(418, 53);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(111, 24);
            this.cmbEstado.TabIndex = 6;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(418, 93);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(111, 24);
            this.comboBox3.TabIndex = 7;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(585, 79);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(87, 30);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // cbmTecnico
            // 
            this.cbmTecnico.FormattingEnabled = true;
            this.cbmTecnico.Location = new System.Drawing.Point(170, 90);
            this.cbmTecnico.Name = "cbmTecnico";
            this.cbmTecnico.Size = new System.Drawing.Size(133, 24);
            this.cbmTecnico.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Descripción ";
            // 
            // dgvDesc
            // 
            this.dgvDesc.BackgroundColor = System.Drawing.Color.White;
            this.dgvDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDesc.Location = new System.Drawing.Point(87, 421);
            this.dgvDesc.Name = "dgvDesc";
            this.dgvDesc.RowHeadersWidth = 51;
            this.dgvDesc.RowTemplate.Height = 24;
            this.dgvDesc.Size = new System.Drawing.Size(812, 159);
            this.dgvDesc.TabIndex = 11;
            // 
            // btnAsignarTecnico
            // 
            this.btnAsignarTecnico.Location = new System.Drawing.Point(373, 586);
            this.btnAsignarTecnico.Name = "btnAsignarTecnico";
            this.btnAsignarTecnico.Size = new System.Drawing.Size(123, 30);
            this.btnAsignarTecnico.TabIndex = 12;
            this.btnAsignarTecnico.Text = "Asignar tecnico ";
            this.btnAsignarTecnico.UseVisualStyleBackColor = true;
            // 
            // btnCrearTicket
            // 
            this.btnCrearTicket.Location = new System.Drawing.Point(87, 587);
            this.btnCrearTicket.Name = "btnCrearTicket";
            this.btnCrearTicket.Size = new System.Drawing.Size(112, 30);
            this.btnCrearTicket.TabIndex = 13;
            this.btnCrearTicket.Text = "Crear Ticket";
            this.btnCrearTicket.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(767, 586);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(132, 30);
            this.btnGuardarCambios.TabIndex = 14;
            this.btnGuardarCambios.Text = "Guardiar Cambios ";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(660, 587);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 30);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.Location = new System.Drawing.Point(520, 587);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(120, 30);
            this.btnCambiarEstado.TabIndex = 16;
            this.btnCambiarEstado.Text = "Cambiar Estado ";
            this.btnCambiarEstado.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Usuario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(616, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tecnico Asignado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(389, 306);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Estado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(389, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Departamento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(92, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Asunto";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(170, 303);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 22);
            this.textBox1.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(445, 300);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 22);
            this.textBox2.TabIndex = 23;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(754, 300);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(145, 22);
            this.textBox3.TabIndex = 24;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(170, 343);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(195, 22);
            this.textBox4.TabIndex = 25;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(488, 343);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(152, 22);
            this.textBox5.TabIndex = 26;
            // 
            // Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 648);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.btnCrearTicket);
            this.Controls.Add(this.btnAsignarTecnico);
            this.Controls.Add(this.dgvDesc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbmTecnico);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.cbmUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvInfoTicket);
            this.Name = "Tickets";
            this.Text = "Tickets";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInfoTicket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbmUsuario;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbmTecnico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDesc;
        private System.Windows.Forms.Button btnAsignarTecnico;
        private System.Windows.Forms.Button btnCrearTicket;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
    }
}