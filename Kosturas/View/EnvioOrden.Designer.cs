namespace Kosturas.View
{
    partial class EnvioOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnvioOrden));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbHora = new System.Windows.Forms.ComboBox();
            this.cmbMinutos = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtpago = new System.Windows.Forms.TextBox();
            this.ckbNopagar = new System.Windows.Forms.CheckBox();
            this.cmbTipoPago = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnNumero = new System.Windows.Forms.Button();
            this.ckbEnviarSMS = new System.Windows.Forms.CheckBox();
            this.ckbEnviarEmail = new System.Windows.Forms.CheckBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalDos = new System.Windows.Forms.Label();
            this.lblVisitas = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtCalcularCambio = new System.Windows.Forms.TextBox();
            this.lblCalcularCambio = new System.Windows.Forms.Label();
            this.lblCAmbio = new System.Windows.Forms.Label();
            this.lblresultado = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Location = new System.Drawing.Point(1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(950, 39);
            this.panel2.TabIndex = 124;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(889, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 39);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(7, 7);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(319, 29);
            this.label21.TabIndex = 12;
            this.label21.Text = "Enviar Orden Selecionada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 125;
            this.label1.Text = "Fecha Y Hora Recogida:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 126;
            this.label2.Text = "Cantidad Pago Ahora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(639, 484);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 127;
            this.label3.Text = "Cantidad:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(331, 73);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(19, 30);
            this.dtpFecha.TabIndex = 130;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // cmbHora
            // 
            this.cmbHora.FormattingEnabled = true;
            this.cmbHora.Location = new System.Drawing.Point(439, 73);
            this.cmbHora.Name = "cmbHora";
            this.cmbHora.Size = new System.Drawing.Size(60, 21);
            this.cmbHora.TabIndex = 131;
            // 
            // cmbMinutos
            // 
            this.cmbMinutos.FormattingEnabled = true;
            this.cmbMinutos.Location = new System.Drawing.Point(518, 72);
            this.cmbMinutos.Name = "cmbMinutos";
            this.cmbMinutos.Size = new System.Drawing.Size(69, 21);
            this.cmbMinutos.TabIndex = 132;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(697, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 359);
            this.panel1.TabIndex = 133;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Informacion de Dia Selecionado";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Total Reservado:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Status:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Trabajando:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Total:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(55, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(109, 323);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Normal";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(99, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 13);
            this.label14.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 188);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Total Sobrante:";
            // 
            // txtpago
            // 
            this.txtpago.Location = new System.Drawing.Point(143, 137);
            this.txtpago.Multiline = true;
            this.txtpago.Name = "txtpago";
            this.txtpago.Size = new System.Drawing.Size(137, 32);
            this.txtpago.TabIndex = 134;
            // 
            // ckbNopagar
            // 
            this.ckbNopagar.AutoSize = true;
            this.ckbNopagar.Location = new System.Drawing.Point(311, 147);
            this.ckbNopagar.Name = "ckbNopagar";
            this.ckbNopagar.Size = new System.Drawing.Size(71, 17);
            this.ckbNopagar.TabIndex = 135;
            this.ckbNopagar.Text = "No Pagar";
            this.ckbNopagar.UseVisualStyleBackColor = true;
            this.ckbNopagar.CheckedChanged += new System.EventHandler(this.ckbNopagar_CheckedChanged);
            // 
            // cmbTipoPago
            // 
            this.cmbTipoPago.FormattingEnabled = true;
            this.cmbTipoPago.Location = new System.Drawing.Point(427, 148);
            this.cmbTipoPago.Name = "cmbTipoPago";
            this.cmbTipoPago.Size = new System.Drawing.Size(211, 21);
            this.cmbTipoPago.TabIndex = 136;
            this.cmbTipoPago.SelectedIndexChanged += new System.EventHandler(this.cmbTipoPago_SelectedIndexChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(353, 257);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(285, 32);
            this.txtEmail.TabIndex = 137;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(353, 309);
            this.txtTelefono.Multiline = true;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(189, 32);
            this.txtTelefono.TabIndex = 138;
            // 
            // btnNumero
            // 
            this.btnNumero.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNumero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNumero.Location = new System.Drawing.Point(548, 309);
            this.btnNumero.Name = "btnNumero";
            this.btnNumero.Size = new System.Drawing.Size(90, 32);
            this.btnNumero.TabIndex = 139;
            this.btnNumero.Text = "Telefono";
            this.btnNumero.UseVisualStyleBackColor = false;
            this.btnNumero.MouseEnter += new System.EventHandler(this.btnNumero_MouseEnter);
            this.btnNumero.MouseLeave += new System.EventHandler(this.btnNumero_MouseLeave);
            // 
            // ckbEnviarSMS
            // 
            this.ckbEnviarSMS.AutoSize = true;
            this.ckbEnviarSMS.Checked = true;
            this.ckbEnviarSMS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbEnviarSMS.Location = new System.Drawing.Point(15, 317);
            this.ckbEnviarSMS.Name = "ckbEnviarSMS";
            this.ckbEnviarSMS.Size = new System.Drawing.Size(220, 17);
            this.ckbEnviarSMS.TabIndex = 140;
            this.ckbEnviarSMS.Text = "Enviar Notificacion de la Orden por SMS:";
            this.ckbEnviarSMS.UseVisualStyleBackColor = true;
            // 
            // ckbEnviarEmail
            // 
            this.ckbEnviarEmail.AutoSize = true;
            this.ckbEnviarEmail.Checked = true;
            this.ckbEnviarEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbEnviarEmail.Location = new System.Drawing.Point(15, 272);
            this.ckbEnviarEmail.Name = "ckbEnviarEmail";
            this.ckbEnviarEmail.Size = new System.Drawing.Size(284, 17);
            this.ckbEnviarEmail.TabIndex = 141;
            this.ckbEnviarEmail.Text = "Enviar Notificacion de la Orden por Correo Electronico:";
            this.ckbEnviarEmail.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.Black;
            this.btnEnviar.Location = new System.Drawing.Point(731, 446);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(106, 51);
            this.btnEnviar.TabIndex = 147;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            this.btnEnviar.MouseEnter += new System.EventHandler(this.btnNumero_MouseEnter);
            this.btnEnviar.MouseLeave += new System.EventHandler(this.btnNumero_MouseLeave);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ForeColor = System.Drawing.Color.Black;
            this.btnModificar.Location = new System.Drawing.Point(843, 446);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(106, 51);
            this.btnModificar.TabIndex = 148;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            this.btnModificar.MouseEnter += new System.EventHandler(this.btnNumero_MouseEnter);
            this.btnModificar.MouseLeave += new System.EventHandler(this.btnNumero_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(640, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 149;
            this.label4.Text = "Total:";
            // 
            // lblTotalDos
            // 
            this.lblTotalDos.AutoSize = true;
            this.lblTotalDos.Location = new System.Drawing.Point(680, 446);
            this.lblTotalDos.Name = "lblTotalDos";
            this.lblTotalDos.Size = new System.Drawing.Size(13, 13);
            this.lblTotalDos.TabIndex = 151;
            this.lblTotalDos.Text = "0";
            // 
            // lblVisitas
            // 
            this.lblVisitas.AutoSize = true;
            this.lblVisitas.Location = new System.Drawing.Point(694, 484);
            this.lblVisitas.Name = "lblVisitas";
            this.lblVisitas.Size = new System.Drawing.Size(13, 13);
            this.lblVisitas.TabIndex = 150;
            this.lblVisitas.Text = "1";
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(143, 72);
            this.txtFecha.Multiline = true;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(184, 32);
            this.txtFecha.TabIndex = 152;
            // 
            // txtCalcularCambio
            // 
            this.txtCalcularCambio.Location = new System.Drawing.Point(143, 190);
            this.txtCalcularCambio.Multiline = true;
            this.txtCalcularCambio.Name = "txtCalcularCambio";
            this.txtCalcularCambio.Size = new System.Drawing.Size(137, 32);
            this.txtCalcularCambio.TabIndex = 154;
            this.txtCalcularCambio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalcularCambio_KeyPress);
            // 
            // lblCalcularCambio
            // 
            this.lblCalcularCambio.AutoSize = true;
            this.lblCalcularCambio.Location = new System.Drawing.Point(12, 208);
            this.lblCalcularCambio.Name = "lblCalcularCambio";
            this.lblCalcularCambio.Size = new System.Drawing.Size(83, 13);
            this.lblCalcularCambio.TabIndex = 153;
            this.lblCalcularCambio.Text = "Calcular Cambio";
            // 
            // lblCAmbio
            // 
            this.lblCAmbio.AutoSize = true;
            this.lblCAmbio.Location = new System.Drawing.Point(308, 208);
            this.lblCAmbio.Name = "lblCAmbio";
            this.lblCAmbio.Size = new System.Drawing.Size(42, 13);
            this.lblCAmbio.TabIndex = 155;
            this.lblCAmbio.Text = "Cambio";
            // 
            // lblresultado
            // 
            this.lblresultado.AutoSize = true;
            this.lblresultado.Location = new System.Drawing.Point(391, 209);
            this.lblresultado.Name = "lblresultado";
            this.lblresultado.Size = new System.Drawing.Size(13, 13);
            this.lblresultado.TabIndex = 156;
            this.lblresultado.Text = "0";
            // 
            // EnvioOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(963, 509);
            this.Controls.Add(this.lblresultado);
            this.Controls.Add(this.lblCAmbio);
            this.Controls.Add(this.txtCalcularCambio);
            this.Controls.Add(this.lblCalcularCambio);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.lblTotalDos);
            this.Controls.Add(this.lblVisitas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.ckbEnviarEmail);
            this.Controls.Add(this.ckbEnviarSMS);
            this.Controls.Add(this.btnNumero);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cmbTipoPago);
            this.Controls.Add(this.ckbNopagar);
            this.Controls.Add(this.txtpago);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbMinutos);
            this.Controls.Add(this.cmbHora);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnvioOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnvioOrden";
            this.Load += new System.EventHandler(this.EnvioOrden_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EnvioOrden_Paint);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbHora;
        private System.Windows.Forms.ComboBox cmbMinutos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtpago;
        private System.Windows.Forms.CheckBox ckbNopagar;
        private System.Windows.Forms.ComboBox cmbTipoPago;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnNumero;
        private System.Windows.Forms.CheckBox ckbEnviarSMS;
        private System.Windows.Forms.CheckBox ckbEnviarEmail;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalDos;
        private System.Windows.Forms.Label lblVisitas;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtCalcularCambio;
        private System.Windows.Forms.Label lblCalcularCambio;
        private System.Windows.Forms.Label lblCAmbio;
        private System.Windows.Forms.Label lblresultado;
        private System.Windows.Forms.Label label5;
    }
}