namespace Kosturas.View
{
    partial class frmImpresionesAutomaticas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroImpresion = new System.Windows.Forms.TextBox();
            this.rbPlantillaTienda = new System.Windows.Forms.RadioButton();
            this.rbPlantillaPersonalizada = new System.Windows.Forms.RadioButton();
            this.rbPlantillaCliente = new System.Windows.Forms.RadioButton();
            this.rbVenta = new System.Windows.Forms.RadioButton();
            this.rbOrden = new System.Windows.Forms.RadioButton();
            this.ckbPrecio = new System.Windows.Forms.CheckBox();
            this.ckbCodigoBarras = new System.Windows.Forms.CheckBox();
            this.cmbServicios = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dvgImpresiones = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgImpresiones)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero De Imprecion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Imprimir Precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Imprimir Codigo Barras";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Servicios";
            // 
            // txtNumeroImpresion
            // 
            this.txtNumeroImpresion.Location = new System.Drawing.Point(156, 59);
            this.txtNumeroImpresion.Name = "txtNumeroImpresion";
            this.txtNumeroImpresion.Size = new System.Drawing.Size(241, 20);
            this.txtNumeroImpresion.TabIndex = 4;
            // 
            // rbPlantillaTienda
            // 
            this.rbPlantillaTienda.AutoSize = true;
            this.rbPlantillaTienda.Location = new System.Drawing.Point(156, 105);
            this.rbPlantillaTienda.Name = "rbPlantillaTienda";
            this.rbPlantillaTienda.Size = new System.Drawing.Size(182, 17);
            this.rbPlantillaTienda.TabIndex = 5;
            this.rbPlantillaTienda.TabStop = true;
            this.rbPlantillaTienda.Text = "Plantillas De Tienda Determinada";
            this.rbPlantillaTienda.UseVisualStyleBackColor = true;
            // 
            // rbPlantillaPersonalizada
            // 
            this.rbPlantillaPersonalizada.AutoSize = true;
            this.rbPlantillaPersonalizada.Location = new System.Drawing.Point(156, 151);
            this.rbPlantillaPersonalizada.Name = "rbPlantillaPersonalizada";
            this.rbPlantillaPersonalizada.Size = new System.Drawing.Size(130, 17);
            this.rbPlantillaPersonalizada.TabIndex = 6;
            this.rbPlantillaPersonalizada.TabStop = true;
            this.rbPlantillaPersonalizada.Text = "Plantilla Personalizada";
            this.rbPlantillaPersonalizada.UseVisualStyleBackColor = true;
            // 
            // rbPlantillaCliente
            // 
            this.rbPlantillaCliente.AutoSize = true;
            this.rbPlantillaCliente.Location = new System.Drawing.Point(156, 128);
            this.rbPlantillaCliente.Name = "rbPlantillaCliente";
            this.rbPlantillaCliente.Size = new System.Drawing.Size(191, 17);
            this.rbPlantillaCliente.TabIndex = 7;
            this.rbPlantillaCliente.TabStop = true;
            this.rbPlantillaCliente.Text = "Plantillas De Clientes Determinadas";
            this.rbPlantillaCliente.UseVisualStyleBackColor = true;
            // 
            // rbVenta
            // 
            this.rbVenta.AutoSize = true;
            this.rbVenta.Location = new System.Drawing.Point(156, 197);
            this.rbVenta.Name = "rbVenta";
            this.rbVenta.Size = new System.Drawing.Size(53, 17);
            this.rbVenta.TabIndex = 8;
            this.rbVenta.TabStop = true;
            this.rbVenta.Text = "Venta";
            this.rbVenta.UseVisualStyleBackColor = true;
            // 
            // rbOrden
            // 
            this.rbOrden.AutoSize = true;
            this.rbOrden.Location = new System.Drawing.Point(156, 174);
            this.rbOrden.Name = "rbOrden";
            this.rbOrden.Size = new System.Drawing.Size(54, 17);
            this.rbOrden.TabIndex = 9;
            this.rbOrden.TabStop = true;
            this.rbOrden.Text = "Orden";
            this.rbOrden.UseVisualStyleBackColor = true;
            // 
            // ckbPrecio
            // 
            this.ckbPrecio.AutoSize = true;
            this.ckbPrecio.Location = new System.Drawing.Point(156, 245);
            this.ckbPrecio.Name = "ckbPrecio";
            this.ckbPrecio.Size = new System.Drawing.Size(15, 14);
            this.ckbPrecio.TabIndex = 10;
            this.ckbPrecio.UseVisualStyleBackColor = true;
            // 
            // ckbCodigoBarras
            // 
            this.ckbCodigoBarras.AutoSize = true;
            this.ckbCodigoBarras.Location = new System.Drawing.Point(156, 278);
            this.ckbCodigoBarras.Name = "ckbCodigoBarras";
            this.ckbCodigoBarras.Size = new System.Drawing.Size(15, 14);
            this.ckbCodigoBarras.TabIndex = 11;
            this.ckbCodigoBarras.UseVisualStyleBackColor = true;
            // 
            // cmbServicios
            // 
            this.cmbServicios.FormattingEnabled = true;
            this.cmbServicios.Location = new System.Drawing.Point(156, 302);
            this.cmbServicios.Name = "cmbServicios";
            this.cmbServicios.Size = new System.Drawing.Size(241, 21);
            this.cmbServicios.TabIndex = 12;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(388, 349);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(388, 401);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(351, 23);
            this.btnActualizar.TabIndex = 15;
            this.btnActualizar.Text = "Actualizar Impresion";
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(521, 349);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // dvgImpresiones
            // 
            this.dvgImpresiones.BackgroundColor = System.Drawing.Color.White;
            this.dvgImpresiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgImpresiones.Location = new System.Drawing.Point(12, 464);
            this.dvgImpresiones.Name = "dvgImpresiones";
            this.dvgImpresiones.Size = new System.Drawing.Size(834, 150);
            this.dvgImpresiones.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(827, 39);
            this.panel2.TabIndex = 100;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Kosturas.Properties.Resources.close_button_png_26;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(767, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 39);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightGray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(270, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(303, 29);
            this.label10.TabIndex = 12;
            this.label10.Text = "Impresiones automaticas";
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
            // frmImpresionesAutomaticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(851, 626);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dvgImpresiones);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbServicios);
            this.Controls.Add(this.ckbCodigoBarras);
            this.Controls.Add(this.ckbPrecio);
            this.Controls.Add(this.rbOrden);
            this.Controls.Add(this.rbVenta);
            this.Controls.Add(this.rbPlantillaCliente);
            this.Controls.Add(this.rbPlantillaPersonalizada);
            this.Controls.Add(this.rbPlantillaTienda);
            this.Controls.Add(this.txtNumeroImpresion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmImpresionesAutomaticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmImpresionesAutomaticas";
            this.Load += new System.EventHandler(this.frmImpresionesAutomaticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgImpresiones)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroImpresion;
        private System.Windows.Forms.RadioButton rbPlantillaTienda;
        private System.Windows.Forms.RadioButton rbPlantillaPersonalizada;
        private System.Windows.Forms.RadioButton rbPlantillaCliente;
        private System.Windows.Forms.RadioButton rbVenta;
        private System.Windows.Forms.RadioButton rbOrden;
        private System.Windows.Forms.CheckBox ckbPrecio;
        private System.Windows.Forms.CheckBox ckbCodigoBarras;
        private System.Windows.Forms.ComboBox cmbServicios;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dvgImpresiones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}