namespace MidaiEsfe.Aplicacion.UI.WinForm
{
    partial class NotaPorModuloAgregar
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btbAgregar = new System.Windows.Forms.Button();
            this.cbIdEvalucion = new System.Windows.Forms.ComboBox();
            this.cbIdAsignacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(0, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(488, 47);
            this.label2.TabIndex = 20;
            this.label2.Text = "Aplicacion de control de notas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(67)))), ((int)(((byte)(133)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(488, 47);
            this.label4.TabIndex = 19;
            this.label4.Text = "Agregar notas por modulo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btbAgregar
            // 
            this.btbAgregar.Location = new System.Drawing.Point(167, 241);
            this.btbAgregar.Name = "btbAgregar";
            this.btbAgregar.Size = new System.Drawing.Size(142, 23);
            this.btbAgregar.TabIndex = 21;
            this.btbAgregar.Text = "Agregar Nota";
            this.btbAgregar.UseVisualStyleBackColor = true;
            this.btbAgregar.Click += new System.EventHandler(this.btbAgregar_Click);
            // 
            // cbIdEvalucion
            // 
            this.cbIdEvalucion.FormattingEnabled = true;
            this.cbIdEvalucion.Location = new System.Drawing.Point(75, 81);
            this.cbIdEvalucion.Name = "cbIdEvalucion";
            this.cbIdEvalucion.Size = new System.Drawing.Size(329, 21);
            this.cbIdEvalucion.TabIndex = 22;
            this.cbIdEvalucion.SelectionChangeCommitted += new System.EventHandler(this.cbIdEvalucion_SelectionChangeCommitted);
            // 
            // cbIdAsignacion
            // 
            this.cbIdAsignacion.FormattingEnabled = true;
            this.cbIdAsignacion.Location = new System.Drawing.Point(75, 132);
            this.cbIdAsignacion.Name = "cbIdAsignacion";
            this.cbIdAsignacion.Size = new System.Drawing.Size(329, 21);
            this.cbIdAsignacion.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Seleccione evaluacion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Seleccione estudiante:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Ingrese la nota";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(78, 184);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(100, 20);
            this.txtNota.TabIndex = 27;
            // 
            // NotaPorModuloAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 338);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbIdAsignacion);
            this.Controls.Add(this.cbIdEvalucion);
            this.Controls.Add(this.btbAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Name = "NotaPorModuloAgregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NotaPorModuloAgregar";
            this.Load += new System.EventHandler(this.NotaPorModuloAgregar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btbAgregar;
        private System.Windows.Forms.ComboBox cbIdEvalucion;
        private System.Windows.Forms.ComboBox cbIdAsignacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNota;
    }
}