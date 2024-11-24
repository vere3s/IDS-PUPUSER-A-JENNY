namespace PupuseriaJenny.Forms
{
    partial class DescargarInventarioForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnEliminarIngrediente = new PupuseriaJenny.Custom.RJButton();
            this.dgvIngredientesDetalles = new System.Windows.Forms.DataGridView();
            this.idIngrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreIngrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDetallePedidoIngrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flpCategorias = new System.Windows.Forms.FlowLayoutPanel();
            this.rjButton1 = new PupuseriaJenny.Custom.RJButton();
            this.rjButton2 = new PupuseriaJenny.Custom.RJButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpIngredientes = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDescargarIngredientes = new PupuseriaJenny.Custom.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientesDetalles)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.flpCategorias.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flpIngredientes.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvIngredientesDetalles, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(351, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 2);
            this.panel6.Controls.Add(this.btnEliminarIngrediente);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 363);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(345, 84);
            this.panel6.TabIndex = 37;
            // 
            // btnEliminarIngrediente
            // 
            this.btnEliminarIngrediente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarIngrediente.BackColor = System.Drawing.Color.Red;
            this.btnEliminarIngrediente.BackgroundColor = System.Drawing.Color.Red;
            this.btnEliminarIngrediente.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEliminarIngrediente.BorderRadius = 5;
            this.btnEliminarIngrediente.BorderSize = 0;
            this.btnEliminarIngrediente.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEliminarIngrediente.FlatAppearance.BorderSize = 0;
            this.btnEliminarIngrediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarIngrediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarIngrediente.ForeColor = System.Drawing.Color.White;
            this.btnEliminarIngrediente.Location = new System.Drawing.Point(84, 6);
            this.btnEliminarIngrediente.MinimumSize = new System.Drawing.Size(100, 40);
            this.btnEliminarIngrediente.Name = "btnEliminarIngrediente";
            this.btnEliminarIngrediente.Size = new System.Drawing.Size(192, 72);
            this.btnEliminarIngrediente.TabIndex = 5;
            this.btnEliminarIngrediente.Text = "Eliminar Ingrediente";
            this.btnEliminarIngrediente.TextColor = System.Drawing.Color.White;
            this.btnEliminarIngrediente.UseVisualStyleBackColor = false;
            this.btnEliminarIngrediente.Click += new System.EventHandler(this.btnEliminarIngrediente_Click);
            // 
            // dgvIngredientesDetalles
            // 
            this.dgvIngredientesDetalles.AllowUserToAddRows = false;
            this.dgvIngredientesDetalles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvIngredientesDetalles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIngredientesDetalles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvIngredientesDetalles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngredientesDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIngredientesDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientesDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idIngrediente,
            this.nombreIngrediente,
            this.precioDetallePedidoIngrediente,
            this.Cantidad});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvIngredientesDetalles, 2);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIngredientesDetalles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIngredientesDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngredientesDetalles.EnableHeadersVisualStyles = false;
            this.dgvIngredientesDetalles.Location = new System.Drawing.Point(3, 3);
            this.dgvIngredientesDetalles.Name = "dgvIngredientesDetalles";
            this.dgvIngredientesDetalles.ReadOnly = true;
            this.dgvIngredientesDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredientesDetalles.Size = new System.Drawing.Size(345, 354);
            this.dgvIngredientesDetalles.TabIndex = 36;
            // 
            // idIngrediente
            // 
            this.idIngrediente.DataPropertyName = "idIngrediente";
            this.idIngrediente.HeaderText = "idIngrediente";
            this.idIngrediente.Name = "idIngrediente";
            this.idIngrediente.ReadOnly = true;
            this.idIngrediente.Visible = false;
            // 
            // nombreIngrediente
            // 
            this.nombreIngrediente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreIngrediente.DataPropertyName = "nombreIngrediente";
            this.nombreIngrediente.HeaderText = "Ingrediente";
            this.nombreIngrediente.Name = "nombreIngrediente";
            this.nombreIngrediente.ReadOnly = true;
            // 
            // precioDetallePedidoIngrediente
            // 
            this.precioDetallePedidoIngrediente.DataPropertyName = "precioDetallePedidoIngrediente";
            this.precioDetallePedidoIngrediente.HeaderText = "Costo Unitario";
            this.precioDetallePedidoIngrediente.Name = "precioDetallePedidoIngrediente";
            this.precioDetallePedidoIngrediente.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flpCategorias, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(445, 450);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // flpCategorias
            // 
            this.flpCategorias.AutoScroll = true;
            this.flpCategorias.BackColor = System.Drawing.Color.White;
            this.flpCategorias.Controls.Add(this.rjButton1);
            this.flpCategorias.Controls.Add(this.rjButton2);
            this.flpCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCategorias.Location = new System.Drawing.Point(3, 3);
            this.flpCategorias.Name = "flpCategorias";
            this.flpCategorias.Size = new System.Drawing.Size(439, 39);
            this.flpCategorias.TabIndex = 37;
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.DodgerBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 5;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(3, 3);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(104, 46);
            this.rjButton1.TabIndex = 8;
            this.rjButton1.Text = "Categorias";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.DodgerBlue;
            this.rjButton2.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 5;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(113, 3);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(104, 46);
            this.rjButton2.TabIndex = 9;
            this.rjButton2.Text = "Categorias";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpIngredientes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 354);
            this.panel1.TabIndex = 38;
            // 
            // flpIngredientes
            // 
            this.flpIngredientes.BackColor = System.Drawing.Color.DarkSlateGray;
            this.flpIngredientes.Controls.Add(this.button2);
            this.flpIngredientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpIngredientes.Location = new System.Drawing.Point(0, 0);
            this.flpIngredientes.Name = "flpIngredientes";
            this.flpIngredientes.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.flpIngredientes.Size = new System.Drawing.Size(439, 354);
            this.flpIngredientes.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.Location = new System.Drawing.Point(10, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 110);
            this.button2.TabIndex = 1;
            this.button2.Text = "Pupusa";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDescargarIngredientes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 408);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 39);
            this.panel2.TabIndex = 39;
            // 
            // btnDescargarIngredientes
            // 
            this.btnDescargarIngredientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargarIngredientes.BackColor = System.Drawing.Color.Red;
            this.btnDescargarIngredientes.BackgroundColor = System.Drawing.Color.Red;
            this.btnDescargarIngredientes.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDescargarIngredientes.BorderRadius = 5;
            this.btnDescargarIngredientes.BorderSize = 0;
            this.btnDescargarIngredientes.FlatAppearance.BorderSize = 0;
            this.btnDescargarIngredientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarIngredientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargarIngredientes.ForeColor = System.Drawing.Color.White;
            this.btnDescargarIngredientes.Location = new System.Drawing.Point(167, -4);
            this.btnDescargarIngredientes.Name = "btnDescargarIngredientes";
            this.btnDescargarIngredientes.Size = new System.Drawing.Size(104, 46);
            this.btnDescargarIngredientes.TabIndex = 4;
            this.btnDescargarIngredientes.Text = "Descargar Ingredientes";
            this.btnDescargarIngredientes.TextColor = System.Drawing.Color.White;
            this.btnDescargarIngredientes.UseVisualStyleBackColor = false;
            this.btnDescargarIngredientes.Click += new System.EventHandler(this.btnDescargarIngredientes_Click);
            // 
            // DescargarInventarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DescargarInventarioForm";
            this.Text = "Descarga de Inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientesDetalles)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flpCategorias.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flpIngredientes.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvIngredientesDetalles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flpCategorias;
        private Custom.RJButton rjButton1;
        private Custom.RJButton rjButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpIngredientes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel6;
        private Custom.RJButton btnEliminarIngrediente;
        private System.Windows.Forms.Panel panel2;
        private Custom.RJButton btnDescargarIngredientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDetallePedidoIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    }
}