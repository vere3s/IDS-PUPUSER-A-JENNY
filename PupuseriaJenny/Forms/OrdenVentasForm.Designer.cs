namespace PupuseriaJenny.Forms
{
    partial class OrdenVentasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenVentasForm));
            this.spcVentas = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvProductosDetalles = new System.Windows.Forms.DataGridView();
            this.idDetalleVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lbOrden = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMesa = new System.Windows.Forms.Label();
            this.tbOrden = new System.Windows.Forms.TextBox();
            this.tbMesa = new System.Windows.Forms.TextBox();
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
            this.btnCobrar = new PupuseriaJenny.Custom.RJButton();
            this.btnEliminarProducto = new PupuseriaJenny.Custom.RJButton();
            this.rjButton4 = new PupuseriaJenny.Custom.RJButton();
            this.rjButton5 = new PupuseriaJenny.Custom.RJButton();
            this.btnPedidosAbiertos = new PupuseriaJenny.Custom.RJButton();
            this.btnCancelarVenta = new PupuseriaJenny.Custom.RJButton();
            this.btnSalir = new PupuseriaJenny.Custom.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.spcVentas)).BeginInit();
            this.spcVentas.Panel1.SuspendLayout();
            this.spcVentas.Panel2.SuspendLayout();
            this.spcVentas.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosDetalles)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.dgvProductosDetalles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 585);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvProductosDetalles
            // 
            this.dgvProductosDetalles.AllowUserToAddRows = false;
            this.dgvProductosDetalles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvProductosDetalles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductosDetalles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProductosDetalles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductosDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductosDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDetalleVenta,
            this.idProducto,
            this.nombreProducto,
            this.Cantidad,
            this.precioProducto,
            this.totalPrecio});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvProductosDetalles, 2);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductosDetalles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductosDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductosDetalles.EnableHeadersVisualStyles = false;
            this.dgvProductosDetalles.Location = new System.Drawing.Point(3, 61);
            this.dgvProductosDetalles.Name = "dgvProductosDetalles";
            this.dgvProductosDetalles.ReadOnly = true;
            this.dgvProductosDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductosDetalles.Size = new System.Drawing.Size(325, 286);
            this.dgvProductosDetalles.TabIndex = 4;
            // 
            // idDetalleVenta
            // 
            this.idDetalleVenta.DataPropertyName = "idDetalleVenta";
            this.idDetalleVenta.HeaderText = "idDetalleVenta";
            this.idDetalleVenta.Name = "idDetalleVenta";
            this.idDetalleVenta.ReadOnly = true;
            this.idDetalleVenta.Visible = false;
            // 
            // idProducto
            // 
            this.idProducto.DataPropertyName = "idProducto";
            this.idProducto.HeaderText = "idProducto";
            this.idProducto.Name = "idProducto";
            this.idProducto.ReadOnly = true;
            this.idProducto.Visible = false;
            // 
            // nombreProducto
            // 
            this.nombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreProducto.DataPropertyName = "nombreProducto";
            this.nombreProducto.HeaderText = "Producto";
            this.nombreProducto.Name = "nombreProducto";
            this.nombreProducto.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // precioProducto
            // 
            this.precioProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.precioProducto.DataPropertyName = "precioProducto";
            this.precioProducto.HeaderText = "Precio";
            this.precioProducto.Name = "precioProducto";
            this.precioProducto.ReadOnly = true;
            // 
            // totalPrecio
            // 
            this.totalPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalPrecio.DataPropertyName = "totalPrecio";
            this.totalPrecio.HeaderText = "Total";
            this.totalPrecio.Name = "totalPrecio";
            this.totalPrecio.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 411);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 171);
            this.panel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.cbCortesia, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbSubTotal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbDescuento, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbCortesia, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbTotal, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbSubTotal, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbDescuento, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbCortesia, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbTotal, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnCobrar, 3, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(325, 171);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // cbCortesia
            // 
            this.cbCortesia.AutoSize = true;
            this.cbCortesia.BackColor = System.Drawing.Color.Transparent;
            this.cbCortesia.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbCortesia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCortesia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cbCortesia.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.cbCortesia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cbCortesia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cbCortesia.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCortesia.Location = new System.Drawing.Point(84, 84);
            this.cbCortesia.Margin = new System.Windows.Forms.Padding(0);
            this.cbCortesia.MinimumSize = new System.Drawing.Size(29, 39);
            this.cbCortesia.Name = "cbCortesia";
            this.cbCortesia.Size = new System.Drawing.Size(29, 39);
            this.cbCortesia.TabIndex = 9;
            this.cbCortesia.UseVisualStyleBackColor = false;
            this.cbCortesia.CheckedChanged += new System.EventHandler(this.cbCortesia_CheckedChanged);
            // 
            // lbSubTotal
            // 
            this.lbSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSubTotal.AutoSize = true;
            this.lbSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubTotal.ForeColor = System.Drawing.Color.White;
            this.lbSubTotal.Location = new System.Drawing.Point(8, 10);
            this.lbSubTotal.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.lbSubTotal.Name = "lbSubTotal";
            this.lbSubTotal.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lbSubTotal.Size = new System.Drawing.Size(72, 37);
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
            this.lbDescuento.Location = new System.Drawing.Point(8, 47);
            this.lbDescuento.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.lbDescuento.Name = "lbDescuento";
            this.lbDescuento.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lbDescuento.Size = new System.Drawing.Size(73, 37);
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
            this.lbCortesia.Location = new System.Drawing.Point(8, 84);
            this.lbCortesia.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.lbCortesia.Name = "lbCortesia";
            this.lbCortesia.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lbCortesia.Size = new System.Drawing.Size(72, 37);
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
            this.lbTotal.Location = new System.Drawing.Point(8, 121);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lbTotal.Size = new System.Drawing.Size(68, 40);
            this.lbTotal.TabIndex = 3;
            this.lbTotal.Text = "Total Orden:";
            // 
            // tbSubTotal
            // 
            this.tbSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSubTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubTotal.Location = new System.Drawing.Point(116, 13);
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
            this.tbDescuento.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescuento.Location = new System.Drawing.Point(116, 50);
            this.tbDescuento.MaximumSize = new System.Drawing.Size(200, 50);
            this.tbDescuento.MinimumSize = new System.Drawing.Size(100, 25);
            this.tbDescuento.Name = "tbDescuento";
            this.tbDescuento.ReadOnly = true;
            this.tbDescuento.Size = new System.Drawing.Size(140, 35);
            this.tbDescuento.TabIndex = 5;
            this.tbDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDescuento.TextChanged += new System.EventHandler(this.tbDescuento_TextChanged);
            // 
            // tbCortesia
            // 
            this.tbCortesia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCortesia.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbCortesia.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCortesia.Location = new System.Drawing.Point(116, 87);
            this.tbCortesia.MaximumSize = new System.Drawing.Size(200, 50);
            this.tbCortesia.MinimumSize = new System.Drawing.Size(100, 25);
            this.tbCortesia.Name = "tbCortesia";
            this.tbCortesia.ReadOnly = true;
            this.tbCortesia.Size = new System.Drawing.Size(140, 35);
            this.tbCortesia.TabIndex = 6;
            this.tbCortesia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTotal
            // 
            this.tbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.Location = new System.Drawing.Point(116, 124);
            this.tbTotal.MaximumSize = new System.Drawing.Size(200, 50);
            this.tbTotal.MinimumSize = new System.Drawing.Size(100, 25);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(140, 35);
            this.tbTotal.TabIndex = 7;
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel6
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 2);
            this.panel6.Controls.Add(this.btnEliminarProducto);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 353);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(325, 52);
            this.panel6.TabIndex = 8;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 2);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Controls.Add(this.lbOrden, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.tbNombre, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lbMesa, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tbOrden, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.tbMesa, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(325, 52);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // lbOrden
            // 
            this.lbOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOrden.AutoSize = true;
            this.lbOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrden.Location = new System.Drawing.Point(198, 3);
            this.lbOrden.Margin = new System.Windows.Forms.Padding(3);
            this.lbOrden.Name = "lbOrden";
            this.lbOrden.Size = new System.Drawing.Size(124, 20);
            this.lbOrden.TabIndex = 7;
            this.lbOrden.Text = "Orden";
            this.lbOrden.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbNombre
            // 
            this.tbNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(68, 29);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.ReadOnly = true;
            this.tbNombre.Size = new System.Drawing.Size(124, 26);
            this.tbNombre.TabIndex = 3;
            this.tbNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Empleado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMesa
            // 
            this.lbMesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMesa.AutoSize = true;
            this.lbMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMesa.Location = new System.Drawing.Point(3, 3);
            this.lbMesa.Margin = new System.Windows.Forms.Padding(3);
            this.lbMesa.Name = "lbMesa";
            this.lbMesa.Size = new System.Drawing.Size(59, 20);
            this.lbMesa.TabIndex = 0;
            this.lbMesa.Text = "Mesa";
            this.lbMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbOrden
            // 
            this.tbOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrden.Location = new System.Drawing.Point(198, 29);
            this.tbOrden.Name = "tbOrden";
            this.tbOrden.ReadOnly = true;
            this.tbOrden.Size = new System.Drawing.Size(124, 26);
            this.tbOrden.TabIndex = 8;
            this.tbOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMesa
            // 
            this.tbMesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMesa.Location = new System.Drawing.Point(3, 29);
            this.tbMesa.Name = "tbMesa";
            this.tbMesa.ReadOnly = true;
            this.tbMesa.Size = new System.Drawing.Size(59, 26);
            this.tbMesa.TabIndex = 6;
            this.tbMesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.flpCategorias.Controls.Add(this.rjButton5);
            this.flpCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCategorias.Location = new System.Drawing.Point(3, 3);
            this.flpCategorias.Name = "flpCategorias";
            this.flpCategorias.Size = new System.Drawing.Size(319, 58);
            this.flpCategorias.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(328, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(134, 58);
            this.panel4.TabIndex = 34;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            this.panel5.Controls.Add(this.btnPedidosAbiertos);
            this.panel5.Controls.Add(this.btnCancelarVenta);
            this.panel5.Controls.Add(this.btnSalir);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 457);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(459, 57);
            this.panel5.TabIndex = 1;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCobrar.BackColor = System.Drawing.Color.Red;
            this.btnCobrar.BackgroundColor = System.Drawing.Color.Red;
            this.btnCobrar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCobrar.BorderRadius = 5;
            this.btnCobrar.BorderSize = 0;
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCobrar.FlatAppearance.BorderSize = 0;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.Color.White;
            this.btnCobrar.Location = new System.Drawing.Point(262, 124);
            this.btnCobrar.MinimumSize = new System.Drawing.Size(100, 40);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(100, 40);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.TextColor = System.Drawing.Color.White;
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarProducto.BackColor = System.Drawing.Color.Red;
            this.btnEliminarProducto.BackgroundColor = System.Drawing.Color.Red;
            this.btnEliminarProducto.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEliminarProducto.BorderRadius = 5;
            this.btnEliminarProducto.BorderSize = 0;
            this.btnEliminarProducto.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEliminarProducto.FlatAppearance.BorderSize = 0;
            this.btnEliminarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProducto.ForeColor = System.Drawing.Color.White;
            this.btnEliminarProducto.Location = new System.Drawing.Point(84, 6);
            this.btnEliminarProducto.MinimumSize = new System.Drawing.Size(100, 40);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(172, 40);
            this.btnEliminarProducto.TabIndex = 5;
            this.btnEliminarProducto.Text = "Eliminar Producto";
            this.btnEliminarProducto.TextColor = System.Drawing.Color.White;
            this.btnEliminarProducto.UseVisualStyleBackColor = false;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
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
            // btnPedidosAbiertos
            // 
            this.btnPedidosAbiertos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPedidosAbiertos.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPedidosAbiertos.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnPedidosAbiertos.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPedidosAbiertos.BorderRadius = 5;
            this.btnPedidosAbiertos.BorderSize = 0;
            this.btnPedidosAbiertos.FlatAppearance.BorderSize = 0;
            this.btnPedidosAbiertos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidosAbiertos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedidosAbiertos.ForeColor = System.Drawing.Color.White;
            this.btnPedidosAbiertos.Image = ((System.Drawing.Image)(resources.GetObject("btnPedidosAbiertos.Image")));
            this.btnPedidosAbiertos.Location = new System.Drawing.Point(125, 8);
            this.btnPedidosAbiertos.Name = "btnPedidosAbiertos";
            this.btnPedidosAbiertos.Size = new System.Drawing.Size(105, 46);
            this.btnPedidosAbiertos.TabIndex = 4;
            this.btnPedidosAbiertos.Text = "Pedidos abiertos";
            this.btnPedidosAbiertos.TextColor = System.Drawing.Color.White;
            this.btnPedidosAbiertos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPedidosAbiertos.UseVisualStyleBackColor = false;
            this.btnPedidosAbiertos.Click += new System.EventHandler(this.btnPedidosAbiertos_Click);
            // 
            // btnCancelarVenta
            // 
            this.btnCancelarVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarVenta.BackColor = System.Drawing.Color.Red;
            this.btnCancelarVenta.BackgroundColor = System.Drawing.Color.Red;
            this.btnCancelarVenta.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancelarVenta.BorderRadius = 5;
            this.btnCancelarVenta.BorderSize = 0;
            this.btnCancelarVenta.FlatAppearance.BorderSize = 0;
            this.btnCancelarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarVenta.ForeColor = System.Drawing.Color.White;
            this.btnCancelarVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarVenta.Image")));
            this.btnCancelarVenta.Location = new System.Drawing.Point(236, 8);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(104, 46);
            this.btnCancelarVenta.TabIndex = 3;
            this.btnCancelarVenta.Text = "Cancelar Venta";
            this.btnCancelarVenta.TextColor = System.Drawing.Color.White;
            this.btnCancelarVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarVenta.UseVisualStyleBackColor = false;
            this.btnCancelarVenta.Click += new System.EventHandler(this.btnCancelarVenta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSalir.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnSalir.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSalir.BorderRadius = 5;
            this.btnSalir.BorderSize = 0;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(346, 8);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 46);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextColor = System.Drawing.Color.White;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // OrdenVentasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 585);
            this.Controls.Add(this.spcVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "OrdenVentasForm";
            this.Text = "Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OrdenVentasForm_Load);
            this.spcVentas.Panel1.ResumeLayout(false);
            this.spcVentas.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcVentas)).EndInit();
            this.spcVentas.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosDetalles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flpProductos;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button6;
        private Custom.RJButton btnSalir;
        private Custom.RJButton btnCobrar;
        private Custom.RJButton btnCancelarVenta;
        private Custom.RJButton rjButton4;
        private Custom.RJButton rjButton5;
        private System.Windows.Forms.Panel panel6;
        private Custom.RJButton btnEliminarProducto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lbOrden;
        private System.Windows.Forms.TextBox tbOrden;
        private Custom.RJButton btnPedidosAbiertos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrecio;
    }
}