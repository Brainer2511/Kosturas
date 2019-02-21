namespace Kosturas.View
{
    partial class frmOrdenesPorCliente
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tblDetalleOrdenesClientes = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(77)))), ((int)(((byte)(4)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(935, 39);
            this.panel2.TabIndex = 119;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Kosturas.Properties.Resources.close_button_png_26;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(887, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 39);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.tblDetalleOrdenesClientes);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Location = new System.Drawing.Point(1, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(935, 240);
            this.groupBox1.TabIndex = 158;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(4, 10);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(110, 23);
            this.button7.TabIndex = 99;
            this.button7.Text = "Orden";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button7.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(807, 10);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 23);
            this.button6.TabIndex = 100;
            this.button6.Text = "Completada en";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button6.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(516, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 23);
            this.button5.TabIndex = 101;
            this.button5.Text = "Pagos";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button5.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(114, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 23);
            this.button4.TabIndex = 102;
            this.button4.Text = "Ordenada en";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button4.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // tblDetalleOrdenesClientes
            // 
            this.tblDetalleOrdenesClientes.AutoScroll = true;
            this.tblDetalleOrdenesClientes.ColumnCount = 1;
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDetalleOrdenesClientes.Location = new System.Drawing.Point(4, 39);
            this.tblDetalleOrdenesClientes.Name = "tblDetalleOrdenesClientes";
            this.tblDetalleOrdenesClientes.RowCount = 1;
            this.tblDetalleOrdenesClientes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetalleOrdenesClientes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetalleOrdenesClientes.Size = new System.Drawing.Size(927, 196);
            this.tblDetalleOrdenesClientes.TabIndex = 155;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(407, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 104;
            this.button2.Text = "Subtotal";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(623, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 105;
            this.button1.Text = "Saldo Pendiente";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.Control;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(248, 10);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(159, 23);
            this.button8.TabIndex = 113;
            this.button8.Text = "Total Orden";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button8.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.Control;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(713, 10);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 23);
            this.button9.TabIndex = 114;
            this.button9.Text = "Completada";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button9.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // frmOrdenesPorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(940, 287);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOrdenesPorCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmOrdenesPorCliente";
            this.Load += new System.EventHandler(this.frmOrdenesPorCliente_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.TableLayoutPanel tblDetalleOrdenesClientes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}