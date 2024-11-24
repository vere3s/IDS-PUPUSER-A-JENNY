using System;

namespace PupuseriaJenny.Forms
{
    partial class ProveerdorEdicion
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
            this.tbDireccionP = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.btnCancelarP = new System.Windows.Forms.Button();
            this.btnAceptarP = new System.Windows.Forms.Button();
            this.tbTelefonoP = new System.Windows.Forms.TextBox();
            this.tbNombreP = new System.Windows.Forms.TextBox();
            this.tbIdProveedor = new System.Windows.Forms.TextBox();
            this.lblTelefonoP = new System.Windows.Forms.Label();
            this.lblNombreP = new System.Windows.Forms.Label();
            this.lblProveerdor = new System.Windows.Forms.Label();
            this.tbEmailP = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbDireccionP
            // 
            this.tbDireccionP.Location = new System.Drawing.Point(208, 178);
            this.tbDireccionP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDireccionP.Name = "tbDireccionP";
            this.tbDireccionP.Size = new System.Drawing.Size(200, 20);
            this.tbDireccionP.TabIndex = 61;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDireccion.Location = new System.Drawing.Point(83, 178);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(84, 20);
            this.lblDireccion.TabIndex = 60;
            this.lblDireccion.Text = "Dirección";
            // 
            // btnCancelarP
            // 
            this.btnCancelarP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarP.Location = new System.Drawing.Point(251, 273);
            this.btnCancelarP.Name = "btnCancelarP";
            this.btnCancelarP.Size = new System.Drawing.Size(104, 29);
            this.btnCancelarP.TabIndex = 59;
            this.btnCancelarP.Text = "Cancelar";
            this.btnCancelarP.UseVisualStyleBackColor = true;
            // 
            // btnAceptarP
            // 
            this.btnAceptarP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarP.Location = new System.Drawing.Point(107, 273);
            this.btnAceptarP.Name = "btnAceptarP";
            this.btnAceptarP.Size = new System.Drawing.Size(99, 29);
            this.btnAceptarP.TabIndex = 58;
            this.btnAceptarP.Text = "Aceptar";
            this.btnAceptarP.UseVisualStyleBackColor = true;
            // 
            // tbTelefonoP
            // 
            this.tbTelefonoP.Location = new System.Drawing.Point(208, 148);
            this.tbTelefonoP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTelefonoP.Name = "tbTelefonoP";
            this.tbTelefonoP.Size = new System.Drawing.Size(200, 20);
            this.tbTelefonoP.TabIndex = 56;
            // 
            // tbNombreP
            // 
            this.tbNombreP.Location = new System.Drawing.Point(208, 114);
            this.tbNombreP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNombreP.Name = "tbNombreP";
            this.tbNombreP.Size = new System.Drawing.Size(200, 20);
            this.tbNombreP.TabIndex = 55;
            this.tbNombreP.TextChanged += new System.EventHandler(this.tbNombreP_TextChanged);
            // 
            // tbIdProveedor
            // 
            this.tbIdProveedor.Location = new System.Drawing.Point(208, 63);
            this.tbIdProveedor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIdProveedor.Name = "tbIdProveedor";
            this.tbIdProveedor.ReadOnly = true;
            this.tbIdProveedor.Size = new System.Drawing.Size(71, 20);
            this.tbIdProveedor.TabIndex = 54;
            // 
            // lblTelefonoP
            // 
            this.lblTelefonoP.AutoSize = true;
            this.lblTelefonoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefonoP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTelefonoP.Location = new System.Drawing.Point(80, 148);
            this.lblTelefonoP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefonoP.Name = "lblTelefonoP";
            this.lblTelefonoP.Size = new System.Drawing.Size(79, 20);
            this.lblTelefonoP.TabIndex = 52;
            this.lblTelefonoP.Text = "Telefono";
            // 
            // lblNombreP
            // 
            this.lblNombreP.AutoSize = true;
            this.lblNombreP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNombreP.Location = new System.Drawing.Point(79, 114);
            this.lblNombreP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreP.Name = "lblNombreP";
            this.lblNombreP.Size = new System.Drawing.Size(80, 20);
            this.lblNombreP.TabIndex = 50;
            this.lblNombreP.Text = "Nombres";
            // 
            // lblProveerdor
            // 
            this.lblProveerdor.AutoSize = true;
            this.lblProveerdor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveerdor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProveerdor.Location = new System.Drawing.Point(83, 63);
            this.lblProveerdor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProveerdor.Name = "lblProveerdor";
            this.lblProveerdor.Size = new System.Drawing.Size(28, 20);
            this.lblProveerdor.TabIndex = 49;
            this.lblProveerdor.Text = "ID";
            // 
            // tbEmailP
            // 
            this.tbEmailP.Location = new System.Drawing.Point(208, 208);
            this.tbEmailP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbEmailP.Name = "tbEmailP";
            this.tbEmailP.Size = new System.Drawing.Size(200, 20);
            this.tbEmailP.TabIndex = 57;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEmail.Location = new System.Drawing.Point(83, 206);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 20);
            this.lblEmail.TabIndex = 53;
            this.lblEmail.Text = "Email";
            // 
            // ProveerdorEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(487, 450);
            this.Controls.Add(this.tbDireccionP);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.btnCancelarP);
            this.Controls.Add(this.btnAceptarP);
            this.Controls.Add(this.tbEmailP);
            this.Controls.Add(this.tbTelefonoP);
            this.Controls.Add(this.tbNombreP);
            this.Controls.Add(this.tbIdProveedor);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTelefonoP);
            this.Controls.Add(this.lblNombreP);
            this.Controls.Add(this.lblProveerdor);
            this.Name = "ProveerdorEdicion";
            this.Text = "ProveerdorEdicion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void tbNombreP_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        public System.Windows.Forms.TextBox tbDireccionP;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Button btnCancelarP;
        private System.Windows.Forms.Button btnAceptarP;
        public System.Windows.Forms.TextBox tbTelefonoP;
        public System.Windows.Forms.TextBox tbNombreP;
        public System.Windows.Forms.TextBox tbIdProveedor;
        private System.Windows.Forms.Label lblTelefonoP;
        private System.Windows.Forms.Label lblNombreP;
        private System.Windows.Forms.Label lblProveerdor;
        public System.Windows.Forms.TextBox tbEmailP;
        private System.Windows.Forms.Label lblEmail;
    }
}