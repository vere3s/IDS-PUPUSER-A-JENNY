namespace PupuseriaJenny.Forms
{
    partial class UsuarioEdicion
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
            this.components = new System.ComponentModel.Container();
            this.cbIDRol = new System.Windows.Forms.ComboBox();
            this.cbIDEmpleado = new System.Windows.Forms.ComboBox();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIDUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Notificador = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Notificador)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIDRol
            // 
            this.cbIDRol.BackColor = System.Drawing.Color.GhostWhite;
            this.cbIDRol.FormattingEnabled = true;
            this.cbIDRol.Location = new System.Drawing.Point(39, 413);
            this.cbIDRol.Margin = new System.Windows.Forms.Padding(2);
            this.cbIDRol.Name = "cbIDRol";
            this.cbIDRol.Size = new System.Drawing.Size(291, 21);
            this.cbIDRol.TabIndex = 43;
            // 
            // cbIDEmpleado
            // 
            this.cbIDEmpleado.BackColor = System.Drawing.Color.GhostWhite;
            this.cbIDEmpleado.FormattingEnabled = true;
            this.cbIDEmpleado.Location = new System.Drawing.Point(35, 328);
            this.cbIDEmpleado.Margin = new System.Windows.Forms.Padding(2);
            this.cbIDEmpleado.Name = "cbIDEmpleado";
            this.cbIDEmpleado.Size = new System.Drawing.Size(291, 21);
            this.cbIDEmpleado.TabIndex = 42;
            // 
            // tbContraseña
            // 
            this.tbContraseña.BackColor = System.Drawing.Color.GhostWhite;
            this.tbContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContraseña.Location = new System.Drawing.Point(39, 232);
            this.tbContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.Size = new System.Drawing.Size(291, 26);
            this.tbContraseña.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(34, 207);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(30, 288);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Empleado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(34, 379);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Rol";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(203, 500);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 35);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(34, 500);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(112, 35);
            this.btnGuardar.TabIndex = 36;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // tbUsuario
            // 
            this.tbUsuario.BackColor = System.Drawing.Color.GhostWhite;
            this.tbUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsuario.Location = new System.Drawing.Point(39, 144);
            this.tbUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(291, 26);
            this.tbUsuario.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(34, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Usuario";
            // 
            // tbIDUsuario
            // 
            this.tbIDUsuario.BackColor = System.Drawing.Color.GhostWhite;
            this.tbIDUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIDUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIDUsuario.Location = new System.Drawing.Point(39, 56);
            this.tbIDUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIDUsuario.Name = "tbIDUsuario";
            this.tbIDUsuario.ReadOnly = true;
            this.tbIDUsuario.Size = new System.Drawing.Size(76, 26);
            this.tbIDUsuario.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "IDUsuario";
            // 
            // Notificador
            // 
            this.Notificador.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.Notificador.ContainerControl = this;
            // 
            // UsuarioEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(361, 566);
            this.Controls.Add(this.cbIDRol);
            this.Controls.Add(this.cbIDEmpleado);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIDUsuario);
            this.Controls.Add(this.label1);
            this.Name = "UsuarioEdicion";
            this.Text = "UsuarioEdicion";
            ((System.ComponentModel.ISupportInitialize)(this.Notificador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbIDRol;
        public System.Windows.Forms.ComboBox cbIDEmpleado;
        public System.Windows.Forms.TextBox tbContraseña;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbIDUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider Notificador;
    }
}