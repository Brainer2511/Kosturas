namespace Kosturas.View
{
    partial class frmReporteSMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteSMS));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBusqueda = new System.Windows.Forms.ComboBox();
            this.btnVerOrdenes = new System.Windows.Forms.Button();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tblDetalleSMS = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1296, 39);
            this.panel2.TabIndex = 120;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(5, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(228, 24);
            this.label10.TabIndex = 12;
            this.label10.Text = "Reporte Mensajes SMS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 187;
            this.label3.Text = "Buscar Por:";
            // 
            // cmbBusqueda
            // 
            this.cmbBusqueda.FormattingEnabled = true;
            this.cmbBusqueda.Location = new System.Drawing.Point(104, 43);
            this.cmbBusqueda.Name = "cmbBusqueda";
            this.cmbBusqueda.Size = new System.Drawing.Size(211, 21);
            this.cmbBusqueda.TabIndex = 186;
            // 
            // btnVerOrdenes
            // 
            this.btnVerOrdenes.BackColor = System.Drawing.SystemColors.Control;
            this.btnVerOrdenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerOrdenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerOrdenes.Location = new System.Drawing.Point(338, 43);
            this.btnVerOrdenes.Name = "btnVerOrdenes";
            this.btnVerOrdenes.Size = new System.Drawing.Size(159, 106);
            this.btnVerOrdenes.TabIndex = 185;
            this.btnVerOrdenes.Text = "Ver Reportes";
            this.btnVerOrdenes.UseVisualStyleBackColor = false;
            this.btnVerOrdenes.Click += new System.EventHandler(this.btnVerOrdenes_Click);
            this.btnVerOrdenes.MouseEnter += new System.EventHandler(this.btnVerOrdenes_MouseEnter);
            this.btnVerOrdenes.MouseLeave += new System.EventHandler(this.btnVerOrdenes_MouseLeave);
            // 
            // txtHasta
            // 
            this.txtHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.Location = new System.Drawing.Point(104, 117);
            this.txtHasta.Multiline = true;
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(187, 32);
            this.txtHasta.TabIndex = 184;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Location = new System.Drawing.Point(297, 117);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(18, 32);
            this.dtpHasta.TabIndex = 183;
            this.dtpHasta.Value = new System.DateTime(2019, 1, 9, 0, 0, 0, 0);
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 182;
            this.label2.Text = "Hasta:";
            // 
            // txtDesde
            // 
            this.txtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesde.Location = new System.Drawing.Point(104, 70);
            this.txtDesde.Multiline = true;
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(187, 32);
            this.txtDesde.TabIndex = 181;
            // 
            // dtDesde
            // 
            this.dtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDesde.Location = new System.Drawing.Point(297, 70);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(18, 32);
            this.dtDesde.TabIndex = 180;
            this.dtDesde.Value = new System.DateTime(2019, 1, 9, 0, 0, 0, 0);
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 179;
            this.label1.Text = "Desde:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.tblDetalleSMS);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Location = new System.Drawing.Point(2, 154);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1286, 563);
            this.groupBox1.TabIndex = 188;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(429, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 104;
            this.button2.Text = "Telefono Tres";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(5, 10);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(140, 23);
            this.button7.TabIndex = 99;
            this.button7.Text = "Nombre";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button7.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(712, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 23);
            this.button5.TabIndex = 101;
            this.button5.Text = "Total Ordenes";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.button5.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(146, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 23);
            this.button4.TabIndex = 102;
            this.button4.Text = "Telefono Principal";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
            this.button4.MouseLeave += new System.EventHandler(this.button4_MouseLeave);
            // 
            // tblDetalleSMS
            // 
            this.tblDetalleSMS.AutoScroll = true;
            this.tblDetalleSMS.ColumnCount = 1;
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleSMS.Location = new System.Drawing.Point(3, 39);
            this.tblDetalleSMS.Name = "tblDetalleSMS";
            this.tblDetalleSMS.RowCount = 1;
            this.tblDetalleSMS.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetalleSMS.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetalleSMS.Size = new System.Drawing.Size(1278, 519);
            this.tblDetalleSMS.TabIndex = 155;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(571, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 105;
            this.button1.Text = "Email";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.Control;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(287, 10);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(140, 23);
            this.button8.TabIndex = 113;
            this.button8.Text = "Telefono Dos";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.MouseEnter += new System.EventHandler(this.button8_MouseEnter);
            this.button8.MouseLeave += new System.EventHandler(this.button8_MouseLeave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(853, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 23);
            this.button3.TabIndex = 156;
            this.button3.Text = "Total Visitas";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(995, 10);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 23);
            this.button6.TabIndex = 157;
            this.button6.Text = "Total Puntos";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            this.button6.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.Control;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(1138, 10);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(140, 23);
            this.button9.TabIndex = 158;
            this.button9.Text = "Notas";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.MouseEnter += new System.EventHandler(this.button9_MouseEnter);
            this.button9.MouseLeave += new System.EventHandler(this.button9_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1248, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 39);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmReporteSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1299, 750);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBusqueda);
            this.Controls.Add(this.btnVerOrdenes);
            this.Controls.Add(this.txtHasta);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDesde);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteSMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmReporteSMS";
            this.Load += new System.EventHandler(this.frmReporteSMS_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBusqueda;
        private System.Windows.Forms.Button btnVerOrdenes;
        private System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.TableLayoutPanel tblDetalleSMS;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button8;
    }
}