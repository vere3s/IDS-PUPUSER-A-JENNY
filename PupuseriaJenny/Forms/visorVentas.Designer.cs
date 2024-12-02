namespace PupuseriaJenny.Forms
{
    partial class visorVentas
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dpFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dpInicio = new System.Windows.Forms.DateTimePicker();
            this.crvVisorVentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.splitContainer1.Panel1.Controls.Add(this.btnMostrar);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dpFinal);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dpInicio);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crvVisorVentas);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrar.Location = new System.Drawing.Point(135, 262);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(95, 34);
            this.btnMostrar.TabIndex = 24;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(45, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Fecha final";
            // 
            // dpFinal
            // 
            this.dpFinal.CustomFormat = "yyyy-MM-dd";
            this.dpFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFinal.Location = new System.Drawing.Point(45, 207);
            this.dpFinal.Name = "dpFinal";
            this.dpFinal.Size = new System.Drawing.Size(144, 26);
            this.dpFinal.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Fecha de inicio";
            // 
            // dpInicio
            // 
            this.dpInicio.CustomFormat = "yyyy-MM-dd";
            this.dpInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpInicio.Location = new System.Drawing.Point(45, 128);
            this.dpInicio.Name = "dpInicio";
            this.dpInicio.Size = new System.Drawing.Size(144, 26);
            this.dpInicio.TabIndex = 20;
            // 
            // crvVisorVentas
            // 
            this.crvVisorVentas.ActiveViewIndex = -1;
            this.crvVisorVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVisorVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVisorVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVisorVentas.Location = new System.Drawing.Point(0, 0);
            this.crvVisorVentas.Name = "crvVisorVentas";
            this.crvVisorVentas.Size = new System.Drawing.Size(530, 450);
            this.crvVisorVentas.TabIndex = 1;
            this.crvVisorVentas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // visorVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "visorVentas";
            this.Text = "reporteVentas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpInicio;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVisorVentas;
    }
}