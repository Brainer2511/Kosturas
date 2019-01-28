namespace Kosturas.View
{
    partial class frmVerCierreCajas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerCierreCajas));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnActualizaRegistros = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tlpCierresCajas = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1302, 39);
            this.panel2.TabIndex = 117;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 24);
            this.label10.TabIndex = 12;
            this.label10.Text = "Reporte Cierres";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDesde
            // 
            this.txtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesde.Location = new System.Drawing.Point(122, 47);
            this.txtDesde.Multiline = true;
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(187, 32);
            this.txtDesde.TabIndex = 156;
            // 
            // dtDesde
            // 
            this.dtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDesde.Location = new System.Drawing.Point(315, 47);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(18, 32);
            this.dtDesde.TabIndex = 155;
            this.dtDesde.Value = new System.DateTime(2019, 1, 9, 0, 0, 0, 0);
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 154;
            this.label1.Text = "Desde:";
            // 
            // txtHasta
            // 
            this.txtHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.Location = new System.Drawing.Point(122, 94);
            this.txtHasta.Multiline = true;
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(187, 32);
            this.txtHasta.TabIndex = 159;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Location = new System.Drawing.Point(315, 94);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(18, 32);
            this.dtpHasta.TabIndex = 158;
            this.dtpHasta.Value = new System.DateTime(2019, 1, 9, 0, 0, 0, 0);
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 157;
            this.label2.Text = "Hasta:";
            // 
            // btnActualizaRegistros
            // 
            this.btnActualizaRegistros.BackColor = System.Drawing.Color.White;
            this.btnActualizaRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizaRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizaRegistros.Location = new System.Drawing.Point(356, 47);
            this.btnActualizaRegistros.Name = "btnActualizaRegistros";
            this.btnActualizaRegistros.Size = new System.Drawing.Size(159, 79);
            this.btnActualizaRegistros.TabIndex = 160;
            this.btnActualizaRegistros.Text = "Ver Cierres";
            this.btnActualizaRegistros.UseVisualStyleBackColor = false;
            this.btnActualizaRegistros.Click += new System.EventHandler(this.btnActualizaRegistros_Click);
            this.btnActualizaRegistros.MouseEnter += new System.EventHandler(this.btnActualizaRegistros_MouseEnter);
            this.btnActualizaRegistros.MouseLeave += new System.EventHandler(this.btnActualizaRegistros_MouseLeave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tlpCierresCajas);
            this.groupBox2.Location = new System.Drawing.Point(1, 131);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1300, 552);
            this.groupBox2.TabIndex = 161;
            this.groupBox2.TabStop = false;
            // 
            // tlpCierresCajas
            // 
            this.tlpCierresCajas.AutoScroll = true;
            this.tlpCierresCajas.ColumnCount = 12;
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCierresCajas.Location = new System.Drawing.Point(5, 18);
            this.tlpCierresCajas.Name = "tlpCierresCajas";
            this.tlpCierresCajas.RowCount = 1;
            this.tlpCierresCajas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCierresCajas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCierresCajas.Size = new System.Drawing.Size(1286, 507);
            this.tlpCierresCajas.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1254, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 39);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmVerCierreCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1304, 721);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnActualizaRegistros);
            this.Controls.Add(this.txtHasta);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDesde);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerCierreCajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmVerCierreCajas";
            this.Load += new System.EventHandler(this.frmVerCierreCajas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnActualizaRegistros;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TableLayoutPanel tlpCierresCajas;
    }
}