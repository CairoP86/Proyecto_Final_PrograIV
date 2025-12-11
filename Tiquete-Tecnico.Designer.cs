namespace Proyecto_Final_PrograIV
{
    partial class Tiquete_Tecnico
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTiquetesTecnico = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbmEstado = new System.Windows.Forms.ComboBox();
            this.btnEstado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiquetesTecnico)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mis Tiquetes Asignados";
            // 
            // dgvTiquetesTecnico
            // 
            this.dgvTiquetesTecnico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiquetesTecnico.Location = new System.Drawing.Point(60, 64);
            this.dgvTiquetesTecnico.Name = "dgvTiquetesTecnico";
            this.dgvTiquetesTecnico.Size = new System.Drawing.Size(676, 150);
            this.dgvTiquetesTecnico.TabIndex = 1;
            this.dgvTiquetesTecnico.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTiquetesTecnico_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion del tiquete seleccionado:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(261, 230);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(475, 72);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cambiar Estado: ";
            // 
            // cbmEstado
            // 
            this.cbmEstado.FormattingEnabled = true;
            this.cbmEstado.Items.AddRange(new object[] {
            "Generado",
            "Completado "});
            this.cbmEstado.Location = new System.Drawing.Point(261, 320);
            this.cbmEstado.Name = "cbmEstado";
            this.cbmEstado.Size = new System.Drawing.Size(151, 21);
            this.cbmEstado.TabIndex = 5;
            // 
            // btnEstado
            // 
            this.btnEstado.Location = new System.Drawing.Point(261, 366);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(151, 23);
            this.btnEstado.TabIndex = 6;
            this.btnEstado.Text = "Actualizar Estado";
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // Tiquete_Tecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEstado);
            this.Controls.Add(this.cbmEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTiquetesTecnico);
            this.Controls.Add(this.label1);
            this.Name = "Tiquete_Tecnico";
            this.Text = "Tiquete_Tecnico";
            this.Load += new System.EventHandler(this.Tiquete_Tecnico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiquetesTecnico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTiquetesTecnico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbmEstado;
        private System.Windows.Forms.Button btnEstado;
    }
}