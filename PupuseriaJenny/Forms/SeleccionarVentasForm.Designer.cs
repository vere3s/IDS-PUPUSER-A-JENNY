namespace PupuseriaJenny.Forms
{
    partial class SeleccionarVentasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionarVentasForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpcionLlevar = new PupuseriaJenny.Custom.RJButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPedidosAbiertos = new PupuseriaJenny.Custom.RJButton();
            this.btnSalir = new PupuseriaJenny.Custom.RJButton();
            this.btnOpcionRestaurante = new PupuseriaJenny.Custom.RJButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(788, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "ORDEN VENTA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnOpcionLlevar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnOpcionRestaurante, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnOpcionLlevar
            // 
            this.btnOpcionLlevar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpcionLlevar.BackColor = System.Drawing.Color.White;
            this.btnOpcionLlevar.BackgroundColor = System.Drawing.Color.White;
            this.btnOpcionLlevar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOpcionLlevar.BorderRadius = 40;
            this.btnOpcionLlevar.BorderSize = 0;
            this.btnOpcionLlevar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpcionLlevar.FlatAppearance.BorderSize = 0;
            this.btnOpcionLlevar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcionLlevar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionLlevar.ForeColor = System.Drawing.Color.Black;
            this.btnOpcionLlevar.Location = new System.Drawing.Point(40, 175);
            this.btnOpcionLlevar.Margin = new System.Windows.Forms.Padding(40);
            this.btnOpcionLlevar.Name = "btnOpcionLlevar";
            this.btnOpcionLlevar.Size = new System.Drawing.Size(320, 145);
            this.btnOpcionLlevar.TabIndex = 3;
            this.btnOpcionLlevar.Text = "Llevar";
            this.btnOpcionLlevar.TextColor = System.Drawing.Color.Black;
            this.btnOpcionLlevar.UseVisualStyleBackColor = false;
            this.btnOpcionLlevar.Click += new System.EventHandler(this.btnOpcionLlevar_Click);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnPedidosAbiertos);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 363);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 84);
            this.panel1.TabIndex = 6;
            // 
            // btnPedidosAbiertos
            // 
            this.btnPedidosAbiertos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPedidosAbiertos.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPedidosAbiertos.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnPedidosAbiertos.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPedidosAbiertos.BorderRadius = 5;
            this.btnPedidosAbiertos.BorderSize = 0;
            this.btnPedidosAbiertos.FlatAppearance.BorderSize = 0;
            this.btnPedidosAbiertos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidosAbiertos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedidosAbiertos.ForeColor = System.Drawing.Color.White;
            this.btnPedidosAbiertos.Image = ((System.Drawing.Image)(resources.GetObject("btnPedidosAbiertos.Image")));
            this.btnPedidosAbiertos.Location = new System.Drawing.Point(220, 3);
            this.btnPedidosAbiertos.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.btnPedidosAbiertos.Name = "btnPedidosAbiertos";
            this.btnPedidosAbiertos.Size = new System.Drawing.Size(266, 84);
            this.btnPedidosAbiertos.TabIndex = 6;
            this.btnPedidosAbiertos.Text = "Pedidos abiertos";
            this.btnPedidosAbiertos.TextColor = System.Drawing.Color.White;
            this.btnPedidosAbiertos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPedidosAbiertos.UseVisualStyleBackColor = false;
            this.btnPedidosAbiertos.Click += new System.EventHandler(this.btnPedidosAbiertos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSalir.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSalir.BorderRadius = 5;
            this.btnSalir.BorderSize = 0;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(509, 3);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(268, 84);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextColor = System.Drawing.Color.White;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnOpcionRestaurante
            // 
            this.btnOpcionRestaurante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpcionRestaurante.BackColor = System.Drawing.Color.White;
            this.btnOpcionRestaurante.BackgroundColor = System.Drawing.Color.White;
            this.btnOpcionRestaurante.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOpcionRestaurante.BorderRadius = 40;
            this.btnOpcionRestaurante.BorderSize = 0;
            this.btnOpcionRestaurante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpcionRestaurante.FlatAppearance.BorderSize = 0;
            this.btnOpcionRestaurante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcionRestaurante.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionRestaurante.ForeColor = System.Drawing.Color.Black;
            this.btnOpcionRestaurante.Location = new System.Drawing.Point(440, 175);
            this.btnOpcionRestaurante.Margin = new System.Windows.Forms.Padding(40);
            this.btnOpcionRestaurante.Name = "btnOpcionRestaurante";
            this.btnOpcionRestaurante.Size = new System.Drawing.Size(320, 145);
            this.btnOpcionRestaurante.TabIndex = 4;
            this.btnOpcionRestaurante.Text = "Comer en Restaurante";
            this.btnOpcionRestaurante.TextColor = System.Drawing.Color.Black;
            this.btnOpcionRestaurante.UseVisualStyleBackColor = false;
            this.btnOpcionRestaurante.Click += new System.EventHandler(this.btnOpcionRestaurante_Click);
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 129);
            this.panel2.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 129);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(788, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione un tipo de orden";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeleccionarVentasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SeleccionarVentasForm";
            this.Text = "Seleccionar Tipo de Venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Custom.RJButton btnOpcionLlevar;
        private Custom.RJButton btnOpcionRestaurante;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Custom.RJButton btnSalir;
        private System.Windows.Forms.Panel panel1;
        private Custom.RJButton btnPedidosAbiertos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}