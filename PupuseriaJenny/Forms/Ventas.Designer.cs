namespace PupuseriaJenny.Forms
{
    partial class Ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventas));
            this.spcVentas = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbCortesia = new System.Windows.Forms.CheckBox();
            this.lbSubTotal = new System.Windows.Forms.Label();
            this.lbDescuento = new System.Windows.Forms.Label();
            this.lbCortesia = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.tbSubTotal = new System.Windows.Forms.TextBox();
            this.tbDescuento = new System.Windows.Forms.TextBox();
            this.tbCortesia = new System.Windows.Forms.TextBox();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.dgvProductosDetalles = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbMesa = new System.Windows.Forms.Label();
            this.tbMesa = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flpCategorias = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flpProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rjButton3 = new PupuseriaJenny.Custom.RJButton();
            this.rjButton4 = new PupuseriaJenny.Custom.RJButton();
            this.rjButton5 = new PupuseriaJenny.Custom.RJButton();
            this.rjButton2 = new PupuseriaJenny.Custom.RJButton();
            this.rjButton1 = new PupuseriaJenny.Custom.RJButton();
            this.nombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spcVentas)).BeginInit();
            this.spcVentas.Panel1.SuspendLayout();
            this.spcVentas.Panel2.SuspendLayout();
            this.spcVentas.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosDetalles)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flpCategorias.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.flpProductos.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcVentas
            // 
            this.spcVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcVentas.Location = new System.Drawing.Point(0, 0);
            this.spcVentas.Name = "spcVentas";
            // 
            // spcVentas.Panel1
            // 
            this.spcVentas.Panel1.BackColor = System.Drawing.Color.White;
            this.spcVentas.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // spcVentas.Panel2
            // 
            this.spcVentas.Panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.spcVentas.Panel2.Controls.Add(this.splitContainer1);
            this.spcVentas.Size = new System.Drawing.Size(800, 585);
            this.spcVentas.SplitterDistance = 331;
            this.spcVentas.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvProductosDetalles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 585);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 412);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 170);
            this.panel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.rjButton3, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.cbCortesia, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbSubTotal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbDescuento, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbCortesia, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbTotal, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbSubTotal, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbDescuento, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbCortesia, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbTotal, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(325, 170);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // cbCortesia
            // 
            this.cbCortesia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbCortesia.AutoSize = true;
            this.cbCortesia.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCortesia.Location = new System.Drawing.Point(84, 71);
            this.cbCortesia.Name = "cbCortesia";
            this.cbCortesia.Size = new System.Drawing.Size(15, 28);
            this.cbCortesia.TabIndex = 9;
            this.cbCortesia.UseVisualStyleBackColor = true;
            // 
            // lbSubTotal
            // 
            this.lbSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSubTotal.AutoSize = true;
            this.lbSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubTotal.ForeColor = System.Drawing.Color.White;
            this.lbSubTotal.Location = new System.Drawing.Point(8, 0);
            this.lbSubTotal.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.lbSubTotal.Name = "lbSubTotal";
            this.lbSubTotal.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lbSubTotal.Size = new System.Drawing.Size(68, 34);
            this.lbSubTotal.TabIndex = 0;
            this.lbSubTotal.Text = "SubTotal:";
            // 
            // lbDescuento
            // 
            this.lbDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDescuento.AutoSize = true;
            this.lbDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescuento.ForeColor = System.Drawing.Color.White;
            this.lbDescuento.Location = new System.Drawing.Point(8, 34);
            this.lbDescuento.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.lbDescuento.Name = "lbDescuento";
            this.lbDescuento.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lbDescuento.Size = new System.Drawing.Size(68, 34);
            this.lbDescuento.TabIndex = 1;
            this.lbDescuento.Text = "Descuento:";
            // 
            // lbCortesia
            // 
            this.lbCortesia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCortesia.AutoSize = true;
            this.lbCortesia.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCortesia.ForeColor = System.Drawing.Color.White;
            this.lbCortesia.Location = new System.Drawing.Point(8, 68);
            this.lbCortesia.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.lbCortesia.Name = "lbCortesia";
            this.lbCortesia.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lbCortesia.Size = new System.Drawing.Size(64, 34);
            this.lbCortesia.TabIndex = 2;
            this.lbCortesia.Text = "Cortesía:";
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.White;
            this.lbTotal.Location = new System.Drawing.Point(8, 102);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lbTotal.Size = new System.Drawing.Size(68, 34);
            this.lbTotal.TabIndex = 3;
            this.lbTotal.Text = "Total:";
            // 
            // tbSubTotal
            // 
            this.tbSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubTotal.Location = new System.Drawing.Point(116, 3);
            this.tbSubTotal.MaximumSize = new System.Drawing.Size(200, 50);
            this.tbSubTotal.MinimumSize = new System.Drawing.Size(100, 25);
            this.tbSubTotal.Name = "tbSubTotal";
            this.tbSubTotal.ReadOnly = true;
            this.tbSubTotal.Size = new System.Drawing.Size(140, 35);
            this.tbSubTotal.TabIndex = 4;
            this.tbSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDescuento
            // 
            this.tbDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescuento.Location = new System.Drawing.Point(116, 37);
            this.tbDescuento.MaximumSize = new System.Drawing.Size(200, 50);
            this.tbDescuento.MinimumSize = new System.Drawing.Size(100, 25);
            this.tbDescuento.Name = "tbDescuento";
            this.tbDescuento.ReadOnly = true;
            this.tbDescuento.Size = new System.Drawing.Size(140, 35);
            this.tbDescuento.TabIndex = 5;
            this.tbDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCortesia
            // 
            this.tbCortesia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCortesia.Enabled = false;
            this.tbCortesia.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCortesia.Location = new System.Drawing.Point(116, 71);
            this.tbCortesia.MaximumSize = new System.Drawing.Size(200, 50);
            this.tbCortesia.MinimumSize = new System.Drawing.Size(100, 25);
            this.tbCortesia.Name = "tbCortesia";
            this.tbCortesia.Size = new System.Drawing.Size(140, 35);
            this.tbCortesia.TabIndex = 6;
            this.tbCortesia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTotal
            // 
            this.tbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.Location = new System.Drawing.Point(116, 105);
            this.tbTotal.MaximumSize = new System.Drawing.Size(200, 50);
            this.tbTotal.MinimumSize = new System.Drawing.Size(100, 25);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(140, 35);
            this.tbTotal.TabIndex = 7;
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvProductosDetalles
            // 
            this.dgvProductosDetalles.AllowUserToAddRows = false;
            this.dgvProductosDetalles.AllowUserToDeleteRows = false;
            this.dgvProductosDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreProducto,
            this.costoUnitarioProducto,
            this.precioProducto});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvProductosDetalles, 2);
            this.dgvProductosDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductosDetalles.Location = new System.Drawing.Point(3, 61);
            this.dgvProductosDetalles.Name = "dgvProductosDetalles";
            this.dgvProductosDetalles.ReadOnly = true;
            this.dgvProductosDetalles.Size = new System.Drawing.Size(325, 345);
            this.dgvProductosDetalles.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.lbMesa);
            this.panel2.Controls.Add(this.tbMesa);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 46);
            this.panel2.TabIndex = 6;
            // 
            // lbMesa
            // 
            this.lbMesa.AutoSize = true;
            this.lbMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMesa.Location = new System.Drawing.Point(13, 9);
            this.lbMesa.Margin = new System.Windows.Forms.Padding(3);
            this.lbMesa.Name = "lbMesa";
            this.lbMesa.Size = new System.Drawing.Size(56, 20);
            this.lbMesa.TabIndex = 0;
            this.lbMesa.Text = "Mesa: ";
            this.lbMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMesa
            // 
            this.tbMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMesa.Location = new System.Drawing.Point(65, 3);
            this.tbMesa.Margin = new System.Windows.Forms.Padding(10);
            this.tbMesa.Name = "tbMesa";
            this.tbMesa.Size = new System.Drawing.Size(66, 26);
            this.tbMesa.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.tbNombre);
            this.panel3.Location = new System.Drawing.Point(171, 6);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(154, 46);
            this.panel3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbNombre
            // 
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(73, 6);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(84, 26);
            this.tbNombre.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer1.Size = new System.Drawing.Size(465, 585);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 34;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Controls.Add(this.flpCategorias, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(465, 60);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // flpCategorias
            // 
            this.flpCategorias.AutoScroll = true;
            this.flpCategorias.BackColor = System.Drawing.Color.White;
            this.flpCategorias.Controls.Add(this.rjButton4);
            this.flpCategorias.Controls.Add(this.rjButton5);
            this.flpCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCategorias.Location = new System.Drawing.Point(3, 3);
            this.flpCategorias.Name = "flpCategorias";
            this.flpCategorias.Size = new System.Drawing.Size(319, 54);
            this.flpCategorias.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(328, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(134, 54);
            this.panel4.TabIndex = 34;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(103, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 9);
            this.textBox1.MinimumSize = new System.Drawing.Size(250, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 26);
            this.textBox1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.flpProductos, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(465, 521);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // flpProductos
            // 
            this.flpProductos.Controls.Add(this.button6);
            this.flpProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProductos.Location = new System.Drawing.Point(3, 3);
            this.flpProductos.Name = "flpProductos";
            this.flpProductos.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.flpProductos.Size = new System.Drawing.Size(459, 452);
            this.flpProductos.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.Location = new System.Drawing.Point(10, 10);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(144, 110);
            this.button6.TabIndex = 1;
            this.button6.Text = "Pupusa";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.rjButton2);
            this.panel5.Controls.Add(this.rjButton1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 461);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(459, 57);
            this.panel5.TabIndex = 1;
            // 
            // rjButton3
            // 
            this.rjButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rjButton3.BackColor = System.Drawing.Color.OrangeRed;
            this.rjButton3.BackgroundColor = System.Drawing.Color.OrangeRed;
            this.rjButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton3.BorderRadius = 5;
            this.rjButton3.BorderSize = 0;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton3.ForeColor = System.Drawing.Color.White;
            this.rjButton3.Location = new System.Drawing.Point(262, 139);
            this.rjButton3.MinimumSize = new System.Drawing.Size(100, 40);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(100, 40);
            this.rjButton3.TabIndex = 4;
            this.rjButton3.Text = "Cobrar";
            this.rjButton3.TextColor = System.Drawing.Color.White;
            this.rjButton3.UseVisualStyleBackColor = false;
            // 
            // rjButton4
            // 
            this.rjButton4.BackColor = System.Drawing.Color.DodgerBlue;
            this.rjButton4.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.rjButton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton4.BorderRadius = 5;
            this.rjButton4.BorderSize = 0;
            this.rjButton4.FlatAppearance.BorderSize = 0;
            this.rjButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton4.ForeColor = System.Drawing.Color.White;
            this.rjButton4.Location = new System.Drawing.Point(3, 3);
            this.rjButton4.Name = "rjButton4";
            this.rjButton4.Size = new System.Drawing.Size(104, 46);
            this.rjButton4.TabIndex = 8;
            this.rjButton4.Text = "Categorias";
            this.rjButton4.TextColor = System.Drawing.Color.White;
            this.rjButton4.UseVisualStyleBackColor = false;
            // 
            // rjButton5
            // 
            this.rjButton5.BackColor = System.Drawing.Color.DodgerBlue;
            this.rjButton5.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.rjButton5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton5.BorderRadius = 5;
            this.rjButton5.BorderSize = 0;
            this.rjButton5.FlatAppearance.BorderSize = 0;
            this.rjButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton5.ForeColor = System.Drawing.Color.White;
            this.rjButton5.Location = new System.Drawing.Point(113, 3);
            this.rjButton5.Name = "rjButton5";
            this.rjButton5.Size = new System.Drawing.Size(104, 46);
            this.rjButton5.TabIndex = 9;
            this.rjButton5.Text = "Categorias";
            this.rjButton5.TextColor = System.Drawing.Color.White;
            this.rjButton5.UseVisualStyleBackColor = false;
            // 
            // rjButton2
            // 
            this.rjButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rjButton2.BackColor = System.Drawing.Color.RoyalBlue;
            this.rjButton2.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 5;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(236, 9);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(104, 46);
            this.rjButton2.TabIndex = 3;
            this.rjButton2.Text = "Eliminar Venta";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            // 
            // rjButton1
            // 
            this.rjButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rjButton1.BackColor = System.Drawing.Color.RoyalBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 5;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(346, 9);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(104, 46);
            this.rjButton1.TabIndex = 2;
            this.rjButton1.Text = "Salir";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // nombreProducto
            // 
            this.nombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreProducto.DataPropertyName = "nombreProducto";
            this.nombreProducto.HeaderText = "nombreProducto";
            this.nombreProducto.Name = "nombreProducto";
            this.nombreProducto.ReadOnly = true;
            // 
            // costoUnitarioProducto
            // 
            this.costoUnitarioProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costoUnitarioProducto.DataPropertyName = "costoUnitarioProducto";
            this.costoUnitarioProducto.HeaderText = "costoUnitarioProducto";
            this.costoUnitarioProducto.Name = "costoUnitarioProducto";
            this.costoUnitarioProducto.ReadOnly = true;
            // 
            // precioProducto
            // 
            this.precioProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.precioProducto.DataPropertyName = "precioProducto";
            this.precioProducto.HeaderText = "precioProducto";
            this.precioProducto.Name = "precioProducto";
            this.precioProducto.ReadOnly = true;
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 585);
            this.Controls.Add(this.spcVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Ventas";
            this.Text = "Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.spcVentas.Panel1.ResumeLayout(false);
            this.spcVentas.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcVentas)).EndInit();
            this.spcVentas.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosDetalles)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flpCategorias.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.flpProductos.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcVentas;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flpCategorias;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbMesa;
        private System.Windows.Forms.CheckBox cbCortesia;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.TextBox tbCortesia;
        private System.Windows.Forms.TextBox tbDescuento;
        private System.Windows.Forms.TextBox tbSubTotal;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbCortesia;
        private System.Windows.Forms.Label lbDescuento;
        private System.Windows.Forms.Label lbSubTotal;
        private System.Windows.Forms.Label lbMesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProductosDetalles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flpProductos;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button6;
        private Custom.RJButton rjButton1;
        private Custom.RJButton rjButton3;
        private Custom.RJButton rjButton2;
        private Custom.RJButton rjButton4;
        private Custom.RJButton rjButton5;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioProducto;
    }
}