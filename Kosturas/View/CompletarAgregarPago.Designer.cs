namespace Kosturas.View
{
    partial class CompletarAgregarPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompletarAgregarPago));
            this.btnAgregarPago = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnCompletar = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPagos = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblresultado = new System.Windows.Forms.Label();
            this.lblCAmbio = new System.Windows.Forms.Label();
            this.txtCalcularCambio = new System.Windows.Forms.TextBox();
            this.lblCalcularCambio = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarPago
            // 
            this.btnAgregarPago.BackColor = System.Drawing.Color.White;
            this.btnAgregarPago.Location = new System.Drawing.Point(178, 179);
            this.btnAgregarPago.Name = "btnAgregarPago";
            this.btnAgregarPago.Size = new System.Drawing.Size(100, 48);
            this.btnAgregarPago.TabIndex = 116;
            this.btnAgregarPago.Text = "Agregar Pago";
            this.btnAgregarPago.UseVisualStyleBackColor = false;
            this.btnAgregarPago.Click += new System.EventHandler(this.btnAgregarPago_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 39);
            this.panel2.TabIndex = 115;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(377, 0);
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
            this.label10.Location = new System.Drawing.Point(3, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(240, 24);
            this.label10.TabIndex = 12;
            this.label10.Text = "Completar/Agregar Pago";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::Kosturas.Properties.Resources.close_button_png_26;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(1276, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(58, 39);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // btnCompletar
            // 
            this.btnCompletar.BackColor = System.Drawing.Color.White;
            this.btnCompletar.Location = new System.Drawing.Point(42, 179);
            this.btnCompletar.Name = "btnCompletar";
            this.btnCompletar.Size = new System.Drawing.Size(100, 48);
            this.btnCompletar.TabIndex = 114;
            this.btnCompletar.Text = "Completar";
            this.btnCompletar.UseVisualStyleBackColor = false;
            this.btnCompletar.Click += new System.EventHandler(this.btnCompletar_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(63, 74);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(178, 20);
            this.txtMonto.TabIndex = 113;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtPin_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 112;
            this.label4.Text = "Monto:";
            // 
            // cbPagos
            // 
            this.cbPagos.FormattingEnabled = true;
            this.cbPagos.Location = new System.Drawing.Point(270, 73);
            this.cbPagos.Name = "cbPagos";
            this.cbPagos.Size = new System.Drawing.Size(142, 21);
            this.cbPagos.TabIndex = 117;
            this.cbPagos.SelectedIndexChanged += new System.EventHandler(this.cbPagos_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(312, 179);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 48);
            this.btnCancelar.TabIndex = 118;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // lblresultado
            // 
            this.lblresultado.AutoSize = true;
            this.lblresultado.Location = new System.Drawing.Point(389, 129);
            this.lblresultado.Name = "lblresultado";
            this.lblresultado.Size = new System.Drawing.Size(13, 13);
            this.lblresultado.TabIndex = 160;
            this.lblresultado.Text = "0";
            // 
            // lblCAmbio
            // 
            this.lblCAmbio.AutoSize = true;
            this.lblCAmbio.Location = new System.Drawing.Point(306, 128);
            this.lblCAmbio.Name = "lblCAmbio";
            this.lblCAmbio.Size = new System.Drawing.Size(42, 13);
            this.lblCAmbio.TabIndex = 159;
            this.lblCAmbio.Text = "Cambio";
            // 
            // txtCalcularCambio
            // 
            this.txtCalcularCambio.Location = new System.Drawing.Point(88, 125);
            this.txtCalcularCambio.Multiline = true;
            this.txtCalcularCambio.Name = "txtCalcularCambio";
            this.txtCalcularCambio.Size = new System.Drawing.Size(153, 19);
            this.txtCalcularCambio.TabIndex = 158;
            // 
            // lblCalcularCambio
            // 
            this.lblCalcularCambio.AutoSize = true;
            this.lblCalcularCambio.Location = new System.Drawing.Point(-1, 128);
            this.lblCalcularCambio.Name = "lblCalcularCambio";
            this.lblCalcularCambio.Size = new System.Drawing.Size(83, 13);
            this.lblCalcularCambio.TabIndex = 157;
            this.lblCalcularCambio.Text = "Calcular Cambio";
            // 
            // CompletarAgregarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 243);
            this.Controls.Add(this.lblresultado);
            this.Controls.Add(this.lblCAmbio);
            this.Controls.Add(this.txtCalcularCambio);
            this.Controls.Add(this.lblCalcularCambio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cbPagos);
            this.Controls.Add(this.btnAgregarPago);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCompletar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CompletarAgregarPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompletarAgregarPago";
            this.Load += new System.EventHandler(this.CompletarAgregarPago_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarPago;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnCompletar;
        public System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPagos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblresultado;
        private System.Windows.Forms.Label lblCAmbio;
        private System.Windows.Forms.TextBox txtCalcularCambio;
        private System.Windows.Forms.Label lblCalcularCambio;
    }
}