namespace PupuseriaJenny.Forms
{
    partial class Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compras));
            this.lbProveedor = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.dgvComprasDetalles = new System.Windows.Forms.DataGridView();
            this.nombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flpCategorias = new System.Windows.Forms.FlowLayoutPanel();
            this.rjButton4 = new PupuseriaJenny.Custom.RJButton();
            this.rjButton6 = new PupuseriaJenny.Custom.RJButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBbuscar = new System.Windows.Forms.PictureBox();
            this.tBxBuscar = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flpProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rjButton2 = new PupuseriaJenny.Custom.RJButton();
            this.rjButton1 = new PupuseriaJenny.Custom.RJButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbProveedor = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.rjBtnPagar = new PupuseriaJenny.Custom.RJButton();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.spcVentas = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dTPFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flpCategorias.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBbuscar)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.flpProductos.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcVentas)).BeginInit();
            this.spcVentas.Panel1.SuspendLayout();
            this.spcVentas.Panel2.SuspendLayout();
            this.spcVentas.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbProveedor
            // 
            this.lbProveedor.AutoSize = true;
            this.lbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProveedor.Location = new System.Drawing.Point(13, 9);
            this.lbProveedor.Margin = new System.Windows.Forms.Padding(3);
            this.lbProveedor.Name = "lbProveedor";
            this.lbProveedor.Size = new System.Drawing.Size(85, 20);
            this.lbProveedor.TabIndex = 0;
            this.lbProveedor.Text = "Proveedor:";
            this.lbProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(3, 9);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(3);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 20);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre: ";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbNombre
            // 
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(73, 6);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(84, 26);
            this.tbNombre.TabIndex = 3;
            // 
            // dgvComprasDetalles
            // 
            this.dgvComprasDetalles.AllowUserToAddRows = false;
            this.dgvComprasDetalles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvComprasDetalles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComprasDetalles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvComprasDetalles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprasDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvComprasDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprasDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreProducto,
            this.costoUnitarioProducto,
            this.precioProducto});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvComprasDetalles, 2);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComprasDetalles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvComprasDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComprasDetalles.EnableHeadersVisualStyles = false;
            this.dgvComprasDetalles.Location = new System.Drawing.Point(3, 119);
            this.dgvComprasDetalles.Name = "dgvComprasDetalles";
            this.dgvComprasDetalles.ReadOnly = true;
            this.dgvComprasDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprasDetalles.Size = new System.Drawing.Size(325, 345);
            this.dgvComprasDetalles.TabIndex = 4;
            // 
            // nombreProducto
            // 
            this.nombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreProducto.DataPropertyName = "nombreProducto";
            this.nombreProducto.HeaderText = "Producto";
            this.nombreProducto.Name = "nombreProducto";
            this.nombreProducto.ReadOnly = true;
            // 
            // costoUnitarioProducto
            // 
            this.costoUnitarioProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costoUnitarioProducto.DataPropertyName = "Cantidad";
            this.costoUnitarioProducto.HeaderText = "Cantidad";
            this.costoUnitarioProducto.Name = "costoUnitarioProducto";
            this.costoUnitarioProducto.ReadOnly = true;
            // 
            // precioProducto
            // 
            this.precioProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.precioProducto.DataPropertyName = "precioProducto";
            this.precioProducto.HeaderText = "Precio";
            this.precioProducto.Name = "precioProducto";
            this.precioProducto.ReadOnly = true;
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
            this.splitContainer1.SplitterDistance = 64;
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(465, 64);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // flpCategorias
            // 
            this.flpCategorias.AutoScroll = true;
            this.flpCategorias.BackColor = System.Drawing.Color.White;
            this.flpCategorias.Controls.Add(this.rjButton4);
            this.flpCategorias.Controls.Add(this.rjButton6);
            this.flpCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCategorias.Location = new System.Drawing.Point(3, 3);
            this.flpCategorias.Name = "flpCategorias";
            this.flpCategorias.Size = new System.Drawing.Size(319, 58);
            this.flpCategorias.TabIndex = 33;
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
            // rjButton6
            // 
            this.rjButton6.BackColor = System.Drawing.Color.DodgerBlue;
            this.rjButton6.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.rjButton6.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton6.BorderRadius = 5;
            this.rjButton6.BorderSize = 0;
            this.rjButton6.FlatAppearance.BorderSize = 0;
            this.rjButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton6.ForeColor = System.Drawing.Color.White;
            this.rjButton6.Location = new System.Drawing.Point(113, 3);
            this.rjButton6.Name = "rjButton6";
            this.rjButton6.Size = new System.Drawing.Size(104, 46);
            this.rjButton6.TabIndex = 9;
            this.rjButton6.Text = "Categorias";
            this.rjButton6.TextColor = System.Drawing.Color.White;
            this.rjButton6.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pBbuscar);
            this.panel4.Controls.Add(this.tBxBuscar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(328, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(134, 58);
            this.panel4.TabIndex = 34;
            // 
            // pBbuscar
            // 
            this.pBbuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBbuscar.BackColor = System.Drawing.Color.White;
            this.pBbuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBbuscar.BackgroundImage")));
            this.pBbuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBbuscar.Image = ((System.Drawing.Image)(resources.GetObject("pBbuscar.Image")));
            this.pBbuscar.Location = new System.Drawing.Point(103, 9);
            this.pBbuscar.Name = "pBbuscar";
            this.pBbuscar.Size = new System.Drawing.Size(31, 26);
            this.pBbuscar.TabIndex = 3;
            this.pBbuscar.TabStop = false;
            // 
            // tBxBuscar
            // 
            this.tBxBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBxBuscar.Location = new System.Drawing.Point(3, 9);
            this.tBxBuscar.MinimumSize = new System.Drawing.Size(250, 25);
            this.tBxBuscar.Name = "tBxBuscar";
            this.tBxBuscar.Size = new System.Drawing.Size(250, 26);
            this.tBxBuscar.TabIndex = 2;
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(465, 517);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // flpProductos
            // 
            this.flpProductos.Controls.Add(this.button6);
            this.flpProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProductos.Location = new System.Drawing.Point(3, 3);
            this.flpProductos.Name = "flpProductos";
            this.flpProductos.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.flpProductos.Size = new System.Drawing.Size(459, 448);
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
            this.panel5.Location = new System.Drawing.Point(3, 457);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(459, 57);
            this.panel5.TabIndex = 1;
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
            this.rjButton2.Text = "Eliminar Compra";
            this.rjButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.lblNombre);
            this.panel3.Controls.Add(this.tbNombre);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(153, 46);
            this.panel3.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.lbProveedor);
            this.panel2.Controls.Add(this.tbProveedor);
            this.panel2.Location = new System.Drawing.Point(171, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 46);
            this.panel2.TabIndex = 6;
            // 
            // tbProveedor
            // 
            this.tbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProveedor.Location = new System.Drawing.Point(89, 9);
            this.tbProveedor.Margin = new System.Windows.Forms.Padding(10);
            this.tbProveedor.Name = "tbProveedor";
            this.tbProveedor.Size = new System.Drawing.Size(66, 26);
            this.tbProveedor.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 470);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 112);
            this.panel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.Controls.Add(this.lbTotal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rjBtnPagar, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbTotal, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(325, 112);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.White;
            this.lbTotal.Location = new System.Drawing.Point(8, 0);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lbTotal.Size = new System.Drawing.Size(74, 112);
            this.lbTotal.TabIndex = 3;
            this.lbTotal.Text = "Total:";
            // 
            // rjBtnPagar
            // 
            this.rjBtnPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rjBtnPagar.BackColor = System.Drawing.Color.OrangeRed;
            this.rjBtnPagar.BackgroundColor = System.Drawing.Color.OrangeRed;
            this.rjBtnPagar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjBtnPagar.BorderRadius = 5;
            this.rjBtnPagar.BorderSize = 0;
            this.rjBtnPagar.Cursor = System.Windows.Forms.Cursors.Default;
            this.rjBtnPagar.FlatAppearance.BorderSize = 0;
            this.rjBtnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjBtnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjBtnPagar.ForeColor = System.Drawing.Color.White;
            this.rjBtnPagar.Location = new System.Drawing.Point(276, 3);
            this.rjBtnPagar.MinimumSize = new System.Drawing.Size(100, 40);
            this.rjBtnPagar.Name = "rjBtnPagar";
            this.rjBtnPagar.Size = new System.Drawing.Size(100, 40);
            this.rjBtnPagar.TabIndex = 4;
            this.rjBtnPagar.Text = "Pagar";
            this.rjBtnPagar.TextColor = System.Drawing.Color.White;
            this.rjBtnPagar.UseVisualStyleBackColor = false;
            // 
            // tbTotal
            // 
            this.tbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.Location = new System.Drawing.Point(159, 3);
            this.tbTotal.MaximumSize = new System.Drawing.Size(200, 50);
            this.tbTotal.MinimumSize = new System.Drawing.Size(100, 25);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(111, 35);
            this.tbTotal.TabIndex = 7;
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.spcVentas.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvComprasDetalles, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 585);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.Controls.Add(this.dTPFecha);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(6, 64);
            this.panel6.Margin = new System.Windows.Forms.Padding(6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(153, 46);
            this.panel6.TabIndex = 8;
            // 
            // dTPFecha
            // 
            this.dTPFecha.Location = new System.Drawing.Point(86, 9);
            this.dTPFecha.Name = "dTPFecha";
            this.dTPFecha.Size = new System.Drawing.Size(232, 20);
            this.dTPFecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 585);
            this.Controls.Add(this.spcVentas);
            this.Name = "Compras";
            this.Text = "Compras";
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasDetalles)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flpCategorias.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBbuscar)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.flpProductos.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.spcVentas.Panel1.ResumeLayout(false);
            this.spcVentas.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcVentas)).EndInit();
            this.spcVentas.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbProveedor;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.DataGridView dgvComprasDetalles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Custom.RJButton rjBtnPagar;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbProveedor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flpCategorias;
        private Custom.RJButton rjButton4;
        private Custom.RJButton rjButton6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBbuscar;
        private System.Windows.Forms.TextBox tBxBuscar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flpProductos;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel5;
        private Custom.RJButton rjButton2;
        private Custom.RJButton rjButton1;
        private System.Windows.Forms.SplitContainer spcVentas;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dTPFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioProducto;
    }
}