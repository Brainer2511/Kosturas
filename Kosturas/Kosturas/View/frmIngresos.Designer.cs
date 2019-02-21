namespace Kosturas.View
{
    partial class frmIngresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresos));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.ckbEfectivo = new System.Windows.Forms.CheckBox();
            this.ckbTarjeta = new System.Windows.Forms.CheckBox();
            this.ckbCheque = new System.Windows.Forms.CheckBox();
            this.ckbCredito = new System.Windows.Forms.CheckBox();
            this.ckbPuntos = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tblDetallePagos = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tlpPagos = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1296, 39);
            this.panel2.TabIndex = 119;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(5, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 24);
            this.label10.TabIndex = 12;
            this.label10.Text = "Reporte Ingresos";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 178;
            this.label3.Text = "Buscar Por:";
            // 
            // cmbBusqueda
            // 
            this.cmbBusqueda.FormattingEnabled = true;
            this.cmbBusqueda.Location = new System.Drawing.Point(112, 54);
            this.cmbBusqueda.Name = "cmbBusqueda";
            this.cmbBusqueda.Size = new System.Drawing.Size(211, 21);
            this.cmbBusqueda.TabIndex = 177;
            // 
            // btnVerOrdenes
            // 
            this.btnVerOrdenes.BackColor = System.Drawing.SystemColors.Control;
            this.btnVerOrdenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerOrdenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerOrdenes.Location = new System.Drawing.Point(346, 54);
            this.btnVerOrdenes.Name = "btnVerOrdenes";
            this.btnVerOrdenes.Size = new System.Drawing.Size(159, 106);
            this.btnVerOrdenes.TabIndex = 176;
            this.btnVerOrdenes.Text = "Ver Reportes";
            this.btnVerOrdenes.UseVisualStyleBackColor = false;
            this.btnVerOrdenes.Click += new System.EventHandler(this.btnVerOrdenes_Click);
            this.btnVerOrdenes.MouseEnter += new System.EventHandler(this.btnVerOrdenes_MouseEnter);
            this.btnVerOrdenes.MouseLeave += new System.EventHandler(this.btnVerOrdenes_MouseLeave);
            // 
            // txtHasta
            // 
            this.txtHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.Location = new System.Drawing.Point(112, 128);
            this.txtHasta.Multiline = true;
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(187, 32);
            this.txtHasta.TabIndex = 175;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Location = new System.Drawing.Point(305, 128);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(18, 32);
            this.dtpHasta.TabIndex = 174;
            this.dtpHasta.Value = new System.DateTime(2019, 1, 9, 0, 0, 0, 0);
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 173;
            this.label2.Text = "Hasta:";
            // 
            // txtDesde
            // 
            this.txtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesde.Location = new System.Drawing.Point(112, 81);
            this.txtDesde.Multiline = true;
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(187, 32);
            this.txtDesde.TabIndex = 172;
            // 
            // dtDesde
            // 
            this.dtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDesde.Location = new System.Drawing.Point(305, 81);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(18, 32);
            this.dtDesde.TabIndex = 171;
            this.dtDesde.Value = new System.DateTime(2019, 1, 9, 0, 0, 0, 0);
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 170;
            this.label1.Text = "Desde:";
            // 
            // ckbEfectivo
            // 
            this.ckbEfectivo.AutoSize = true;
            this.ckbEfectivo.Checked = true;
            this.ckbEfectivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbEfectivo.Location = new System.Drawing.Point(544, 58);
            this.ckbEfectivo.Name = "ckbEfectivo";
            this.ckbEfectivo.Size = new System.Drawing.Size(108, 29);
            this.ckbEfectivo.TabIndex = 179;
            this.ckbEfectivo.Text = "Efectivo";
            this.ckbEfectivo.UseVisualStyleBackColor = true;
            // 
            // ckbTarjeta
            // 
            this.ckbTarjeta.AutoSize = true;
            this.ckbTarjeta.Checked = true;
            this.ckbTarjeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTarjeta.Location = new System.Drawing.Point(544, 96);
            this.ckbTarjeta.Name = "ckbTarjeta";
            this.ckbTarjeta.Size = new System.Drawing.Size(99, 29);
            this.ckbTarjeta.TabIndex = 180;
            this.ckbTarjeta.Text = "Tarjeta";
            this.ckbTarjeta.UseVisualStyleBackColor = true;
            // 
            // ckbCheque
            // 
            this.ckbCheque.AutoSize = true;
            this.ckbCheque.Checked = true;
            this.ckbCheque.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbCheque.Location = new System.Drawing.Point(544, 129);
            this.ckbCheque.Name = "ckbCheque";
            this.ckbCheque.Size = new System.Drawing.Size(107, 29);
            this.ckbCheque.TabIndex = 181;
            this.ckbCheque.Text = "Cheque";
            this.ckbCheque.UseVisualStyleBackColor = true;
            // 
            // ckbCredito
            // 
            this.ckbCredito.AutoSize = true;
            this.ckbCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbCredito.Location = new System.Drawing.Point(755, 91);
            this.ckbCredito.Name = "ckbCredito";
            this.ckbCredito.Size = new System.Drawing.Size(169, 29);
            this.ckbCredito.TabIndex = 183;
            this.ckbCredito.Text = "CreditoCliente";
            this.ckbCredito.UseVisualStyleBackColor = true;
            // 
            // ckbPuntos
            // 
            this.ckbPuntos.AutoSize = true;
            this.ckbPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbPuntos.Location = new System.Drawing.Point(755, 58);
            this.ckbPuntos.Name = "ckbPuntos";
            this.ckbPuntos.Size = new System.Drawing.Size(98, 29);
            this.ckbPuntos.TabIndex = 182;
            this.ckbPuntos.Text = "Puntos";
            this.ckbPuntos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.tblDetallePagos);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Location = new System.Drawing.Point(1, 165);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(823, 563);
            this.groupBox1.TabIndex = 184;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(389, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 104;
            this.button2.Text = "Total";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(5, 10);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 23);
            this.button7.TabIndex = 99;
            this.button7.Text = "Fecha";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button7.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(672, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 23);
            this.button5.TabIndex = 101;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.button5.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(106, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 23);
            this.button4.TabIndex = 102;
            this.button4.Text = "Medio Pago";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
            this.button4.MouseLeave += new System.EventHandler(this.button4_MouseLeave);
            // 
            // tblDetallePagos
            // 
            this.tblDetallePagos.AutoScroll = true;
            this.tblDetallePagos.ColumnCount = 1;
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetallePagos.Location = new System.Drawing.Point(3, 39);
            this.tblDetallePagos.Name = "tblDetallePagos";
            this.tblDetallePagos.RowCount = 1;
            this.tblDetallePagos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetallePagos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetallePagos.Size = new System.Drawing.Size(815, 196);
            this.tblDetallePagos.TabIndex = 155;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(531, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 105;
            this.button1.Text = "Subtotal";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.Control;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(247, 10);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(140, 23);
            this.button8.TabIndex = 113;
            this.button8.Text = "Codigo Cuenta";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.MouseEnter += new System.EventHandler(this.button8_MouseEnter);
            this.button8.MouseLeave += new System.EventHandler(this.button8_MouseLeave);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.tlpPagos);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(832, 165);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(465, 563);
            this.groupBox2.TabIndex = 185;
            this.groupBox2.TabStop = false;
            // 
            // tlpPagos
            // 
            this.tlpPagos.AutoScroll = true;
            this.tlpPagos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlpPagos.ColumnCount = 1;
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPagos.Location = new System.Drawing.Point(5, 11);
            this.tlpPagos.Name = "tlpPagos";
            this.tlpPagos.RowCount = 1;
            this.tlpPagos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPagos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPagos.Size = new System.Drawing.Size(455, 472);
            this.tlpPagos.TabIndex = 156;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(77)))), ((int)(((byte)(4)))));
            this.panel3.Controls.Add(this.lblTotalIngresos);
            this.panel3.Location = new System.Drawing.Point(5, 519);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 39);
            this.panel3.TabIndex = 121;
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIngresos.ForeColor = System.Drawing.Color.White;
            this.lblTotalIngresos.Location = new System.Drawing.Point(202, 8);
            this.lblTotalIngresos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new System.Drawing.Size(55, 24);
            this.lblTotalIngresos.TabIndex = 12;
            this.lblTotalIngresos.Text = "0,00 ";
            this.lblTotalIngresos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(5, 478);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 39);
            this.panel1.TabIndex = 120;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(202, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "TOTAL";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1301, 771);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ckbCredito);
            this.Controls.Add(this.ckbPuntos);
            this.Controls.Add(this.ckbCheque);
            this.Controls.Add(this.ckbTarjeta);
            this.Controls.Add(this.ckbEfectivo);
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
            this.Name = "frmIngresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmIngresos";
            this.Load += new System.EventHandler(this.frmIngresos_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.CheckBox ckbEfectivo;
        private System.Windows.Forms.CheckBox ckbTarjeta;
        private System.Windows.Forms.CheckBox ckbCheque;
        private System.Windows.Forms.CheckBox ckbCredito;
        private System.Windows.Forms.CheckBox ckbPuntos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.TableLayoutPanel tblDetallePagos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TableLayoutPanel tlpPagos;
    }
}