namespace Kosturas.View
{
    partial class Form1
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
                db.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Prueba = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbabreviatura = new System.Windows.Forms.ComboBox();
            this.btnTelefonoDos = new System.Windows.Forms.Button();
            this.btnTelefonoPrincipal = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.btnTelefonoTres = new System.Windows.Forms.Button();
            this.btnDatosExtra = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.txttelefonotres = new System.Windows.Forms.TextBox();
            this.txttelefonodos = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.txttelefonoprincipal = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNuevaOrden = new System.Windows.Forms.Label();
            this.btnporsentaje = new System.Windows.Forms.Button();
            this.txtPrecioTotal = new System.Windows.Forms.TextBox();
            this.ckbasisnar = new System.Windows.Forms.CheckBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pv2 = new System.Windows.Forms.PictureBox();
            this.pv1 = new System.Windows.Forms.PictureBox();
            this.tbpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grbNewOrder = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Prueba.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pv1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grbNewOrder.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Prueba
            // 
            this.Prueba.Controls.Add(this.pv1);
            this.Prueba.Controls.Add(this.lbl1);
            this.Prueba.Controls.Add(this.pv2);
            this.Prueba.Controls.Add(this.lbl2);
            this.Prueba.Location = new System.Drawing.Point(2, 11);
            this.Prueba.Name = "Prueba";
            this.Prueba.Size = new System.Drawing.Size(401, 746);
            this.Prueba.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Detalles Clientes";
            // 
            // cmbabreviatura
            // 
            this.cmbabreviatura.AccessibleName = "";
            this.cmbabreviatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbabreviatura.FormattingEnabled = true;
            this.cmbabreviatura.Location = new System.Drawing.Point(96, 10);
            this.cmbabreviatura.Name = "cmbabreviatura";
            this.cmbabreviatura.Size = new System.Drawing.Size(121, 21);
            this.cmbabreviatura.TabIndex = 72;
            this.cmbabreviatura.Text = "Titulo";
            this.cmbabreviatura.MouseEnter += new System.EventHandler(this.cmbabreviatura_MouseEnter);
            this.cmbabreviatura.MouseLeave += new System.EventHandler(this.cmbabreviatura_MouseLeave);
            // 
            // btnTelefonoDos
            // 
            this.btnTelefonoDos.BackColor = System.Drawing.SystemColors.Control;
            this.btnTelefonoDos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTelefonoDos.Location = new System.Drawing.Point(342, 46);
            this.btnTelefonoDos.Name = "btnTelefonoDos";
            this.btnTelefonoDos.Size = new System.Drawing.Size(62, 23);
            this.btnTelefonoDos.TabIndex = 71;
            this.btnTelefonoDos.Text = "telefono";
            this.btnTelefonoDos.UseVisualStyleBackColor = false;
            this.btnTelefonoDos.MouseEnter += new System.EventHandler(this.btnTelefonoDos_MouseEnter);
            this.btnTelefonoDos.MouseLeave += new System.EventHandler(this.btnTelefonoDos_MouseLeave);
            // 
            // btnTelefonoPrincipal
            // 
            this.btnTelefonoPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.btnTelefonoPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTelefonoPrincipal.Location = new System.Drawing.Point(499, 11);
            this.btnTelefonoPrincipal.Name = "btnTelefonoPrincipal";
            this.btnTelefonoPrincipal.Size = new System.Drawing.Size(62, 23);
            this.btnTelefonoPrincipal.TabIndex = 70;
            this.btnTelefonoPrincipal.Text = "telefono";
            this.btnTelefonoPrincipal.UseVisualStyleBackColor = false;
            this.btnTelefonoPrincipal.MouseEnter += new System.EventHandler(this.btnTelefonoPrincipal_MouseEnter);
            this.btnTelefonoPrincipal.MouseLeave += new System.EventHandler(this.btnTelefonoPrincipal_MouseLeave);
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.SystemColors.Control;
            this.button37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button37.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button37.Location = new System.Drawing.Point(220, 9);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(28, 23);
            this.button37.TabIndex = 69;
            this.button37.Text = "X";
            this.button37.UseVisualStyleBackColor = false;
            this.button37.MouseEnter += new System.EventHandler(this.button37_MouseEnter);
            this.button37.MouseLeave += new System.EventHandler(this.button37_MouseLeave);
            // 
            // btnTelefonoTres
            // 
            this.btnTelefonoTres.BackColor = System.Drawing.SystemColors.Control;
            this.btnTelefonoTres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTelefonoTres.Location = new System.Drawing.Point(499, 49);
            this.btnTelefonoTres.Name = "btnTelefonoTres";
            this.btnTelefonoTres.Size = new System.Drawing.Size(62, 23);
            this.btnTelefonoTres.TabIndex = 68;
            this.btnTelefonoTres.Text = "telefono";
            this.btnTelefonoTres.UseVisualStyleBackColor = false;
            this.btnTelefonoTres.MouseEnter += new System.EventHandler(this.btnTelefonoTres_MouseEnter);
            this.btnTelefonoTres.MouseLeave += new System.EventHandler(this.btnTelefonoTres_MouseLeave);
            // 
            // btnDatosExtra
            // 
            this.btnDatosExtra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDatosExtra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatosExtra.Location = new System.Drawing.Point(8, 44);
            this.btnDatosExtra.Name = "btnDatosExtra";
            this.btnDatosExtra.Size = new System.Drawing.Size(240, 23);
            this.btnDatosExtra.TabIndex = 67;
            this.btnDatosExtra.Text = "Datos Extra";
            this.btnDatosExtra.UseVisualStyleBackColor = false;
            this.btnDatosExtra.MouseEnter += new System.EventHandler(this.btnDatosExtra_MouseEnter);
            this.btnDatosExtra.MouseLeave += new System.EventHandler(this.btnDatosExtra_MouseLeave);
            // 
            // button35
            // 
            this.button35.BackColor = System.Drawing.SystemColors.Control;
            this.button35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button35.Location = new System.Drawing.Point(452, 88);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(109, 23);
            this.button35.TabIndex = 66;
            this.button35.Text = "Opciones";
            this.button35.UseVisualStyleBackColor = false;
            this.button35.MouseEnter += new System.EventHandler(this.button35_MouseEnter);
            this.button35.MouseLeave += new System.EventHandler(this.button35_MouseLeave);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.SystemColors.Control;
            this.button32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button32.Location = new System.Drawing.Point(211, 88);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(113, 23);
            this.button32.TabIndex = 65;
            this.button32.Text = "Precio Unitario";
            this.button32.UseVisualStyleBackColor = false;
            this.button32.MouseEnter += new System.EventHandler(this.button32_MouseEnter);
            this.button32.MouseLeave += new System.EventHandler(this.button32_MouseLeave);
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.SystemColors.Control;
            this.button33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button33.Location = new System.Drawing.Point(824, 88);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(85, 23);
            this.button33.TabIndex = 64;
            this.button33.Text = "Afiliado";
            this.button33.UseVisualStyleBackColor = false;
            this.button33.MouseEnter += new System.EventHandler(this.button33_MouseEnter);
            this.button33.MouseLeave += new System.EventHandler(this.button33_MouseLeave);
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.SystemColors.Control;
            this.button34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button34.Location = new System.Drawing.Point(96, 88);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(121, 23);
            this.button34.TabIndex = 63;
            this.button34.Text = "Detalles  Tarea";
            this.button34.UseVisualStyleBackColor = false;
            this.button34.MouseEnter += new System.EventHandler(this.button34_MouseEnter);
            this.button34.MouseLeave += new System.EventHandler(this.button34_MouseLeave);
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.SystemColors.Control;
            this.button31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button31.Location = new System.Drawing.Point(321, 88);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(133, 23);
            this.button31.TabIndex = 62;
            this.button31.Text = "Descuento";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.MouseEnter += new System.EventHandler(this.button31_MouseEnter);
            this.button31.MouseLeave += new System.EventHandler(this.button31_MouseLeave);
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.SystemColors.Control;
            this.button30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button30.Location = new System.Drawing.Point(550, 88);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(271, 23);
            this.button30.TabIndex = 61;
            this.button30.Text = "Descripcion";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.MouseEnter += new System.EventHandler(this.button30_MouseEnter);
            this.button30.MouseLeave += new System.EventHandler(this.button30_MouseLeave);
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.SystemColors.Control;
            this.button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button29.Location = new System.Drawing.Point(8, 88);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(91, 23);
            this.button29.TabIndex = 60;
            this.button29.Text = "Tarea";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            this.button29.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button29_MouseDown);
            this.button29.MouseEnter += new System.EventHandler(this.button29_MouseEnter);
            this.button29.MouseLeave += new System.EventHandler(this.button29_MouseLeave);
            // 
            // txttelefonotres
            // 
            this.txttelefonotres.Location = new System.Drawing.Point(410, 49);
            this.txttelefonotres.Name = "txttelefonotres";
            this.txttelefonotres.Size = new System.Drawing.Size(83, 20);
            this.txttelefonotres.TabIndex = 59;
            this.txttelefonotres.Text = "Telefono 3";
            this.txttelefonotres.Enter += new System.EventHandler(this.txttelefonotres_Enter);
            this.txttelefonotres.Leave += new System.EventHandler(this.txttelefonotres_Leave);
            // 
            // txttelefonodos
            // 
            this.txttelefonodos.Location = new System.Drawing.Point(254, 46);
            this.txttelefonodos.Name = "txttelefonodos";
            this.txttelefonodos.Size = new System.Drawing.Size(87, 20);
            this.txttelefonodos.TabIndex = 58;
            this.txttelefonodos.Text = "Teléfono 2";
            this.txttelefonodos.Enter += new System.EventHandler(this.txttelefonodos_Enter);
            this.txttelefonodos.Leave += new System.EventHandler(this.txttelefonodos_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(673, 14);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 57;
            this.txtEmail.Text = "Correo Cliente";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(567, 14);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 56;
            this.txtNombre.Text = "Nombre Cliente";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(567, 51);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(100, 20);
            this.txtCalle.TabIndex = 55;
            this.txtCalle.Text = "Calle";
            this.txtCalle.Enter += new System.EventHandler(this.txtCalle_Enter);
            this.txtCalle.Leave += new System.EventHandler(this.txtCalle_Leave);
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(673, 51);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(100, 20);
            this.txtCiudad.TabIndex = 54;
            this.txtCiudad.Text = "Ciudad";
            this.txtCiudad.Enter += new System.EventHandler(this.txtCiudad_Enter);
            this.txtCiudad.Leave += new System.EventHandler(this.txtCiudad_Leave);
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(779, 51);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoPostal.TabIndex = 53;
            this.txtCodigoPostal.Text = "Codigo Postal";
            this.txtCodigoPostal.Enter += new System.EventHandler(this.txtCodigoPostal_Enter);
            this.txtCodigoPostal.Leave += new System.EventHandler(this.txtCodigoPostal_Leave);
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(779, 15);
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(110, 20);
            this.txtNotas.TabIndex = 52;
            this.txtNotas.Text = "Notas";
            this.txtNotas.Enter += new System.EventHandler(this.txttelefonoprincipal_Enter);
            this.txtNotas.Leave += new System.EventHandler(this.txttelefonoprincipal_Leave);
            // 
            // txttelefonoprincipal
            // 
            this.txttelefonoprincipal.Location = new System.Drawing.Point(254, 12);
            this.txttelefonoprincipal.Name = "txttelefonoprincipal";
            this.txttelefonoprincipal.Size = new System.Drawing.Size(239, 20);
            this.txttelefonoprincipal.TabIndex = 51;
            this.txttelefonoprincipal.Text = "Teléfono Cliente ";
            this.txttelefonoprincipal.Enter += new System.EventHandler(this.txtNotas_Enter);
            this.txttelefonoprincipal.Leave += new System.EventHandler(this.txtNotas_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblNuevaOrden);
            this.panel1.Controls.Add(this.btnporsentaje);
            this.panel1.Controls.Add(this.txtPrecioTotal);
            this.panel1.Controls.Add(this.ckbasisnar);
            this.panel1.Location = new System.Drawing.Point(3, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 44);
            this.panel1.TabIndex = 75;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(913, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "TOTAL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(179, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 56;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(66, 15);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 13);
            this.lblNombre.TabIndex = 55;
            // 
            // lblNuevaOrden
            // 
            this.lblNuevaOrden.AutoSize = true;
            this.lblNuevaOrden.BackColor = System.Drawing.Color.Black;
            this.lblNuevaOrden.ForeColor = System.Drawing.Color.White;
            this.lblNuevaOrden.Location = new System.Drawing.Point(25, 15);
            this.lblNuevaOrden.Name = "lblNuevaOrden";
            this.lblNuevaOrden.Size = new System.Drawing.Size(0, 13);
            this.lblNuevaOrden.TabIndex = 54;
            // 
            // btnporsentaje
            // 
            this.btnporsentaje.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnporsentaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnporsentaje.Location = new System.Drawing.Point(1050, 0);
            this.btnporsentaje.Name = "btnporsentaje";
            this.btnporsentaje.Size = new System.Drawing.Size(75, 44);
            this.btnporsentaje.TabIndex = 53;
            this.btnporsentaje.Text = "+-%";
            this.btnporsentaje.UseVisualStyleBackColor = false;
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.Location = new System.Drawing.Point(962, 0);
            this.txtPrecioTotal.Multiline = true;
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.Size = new System.Drawing.Size(82, 44);
            this.txtPrecioTotal.TabIndex = 52;
            this.txtPrecioTotal.Text = "0";
            // 
            // ckbasisnar
            // 
            this.ckbasisnar.AutoSize = true;
            this.ckbasisnar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckbasisnar.Location = new System.Drawing.Point(808, 15);
            this.ckbasisnar.Name = "ckbasisnar";
            this.ckbasisnar.Size = new System.Drawing.Size(92, 17);
            this.ckbasisnar.TabIndex = 51;
            this.ckbasisnar.Text = "Citar/Reserva";
            this.ckbasisnar.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(143, 722);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(13, 13);
            this.lbl1.TabIndex = 95;
            this.lbl1.Text = "1";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(205, 722);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(13, 13);
            this.lbl2.TabIndex = 96;
            this.lbl2.Text = "2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(4, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1325, 39);
            this.panel2.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(446, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nueva Orden-Selecione Tipo Prenda";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(1263, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(58, 39);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pv2
            // 
            this.pv2.BackColor = System.Drawing.Color.White;
            this.pv2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pv2.BackgroundImage")));
            this.pv2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pv2.ErrorImage = null;
            this.pv2.Location = new System.Drawing.Point(260, 705);
            this.pv2.Name = "pv2";
            this.pv2.Size = new System.Drawing.Size(39, 38);
            this.pv2.TabIndex = 93;
            this.pv2.TabStop = false;
            this.pv2.Click += new System.EventHandler(this.pv2_Click);
            // 
            // pv1
            // 
            this.pv1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pv1.BackgroundImage")));
            this.pv1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pv1.Location = new System.Drawing.Point(84, 705);
            this.pv1.Name = "pv1";
            this.pv1.Size = new System.Drawing.Size(39, 38);
            this.pv1.TabIndex = 92;
            this.pv1.TabStop = false;
            this.pv1.Click += new System.EventHandler(this.pv1_Click);
            // 
            // tbpDatos
            // 
            this.tbpDatos.AutoScroll = true;
            this.tbpDatos.ColumnCount = 1;
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbpDatos.Location = new System.Drawing.Point(1, 117);
            this.tbpDatos.Name = "tbpDatos";
            this.tbpDatos.RowCount = 1;
            this.tbpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbpDatos.Size = new System.Drawing.Size(912, 629);
            this.tbpDatos.TabIndex = 98;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNotas);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbpDatos);
            this.groupBox2.Controls.Add(this.txttelefonoprincipal);
            this.groupBox2.Controls.Add(this.txtCodigoPostal);
            this.groupBox2.Controls.Add(this.txtCiudad);
            this.groupBox2.Controls.Add(this.txtCalle);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txttelefonodos);
            this.groupBox2.Controls.Add(this.cmbabreviatura);
            this.groupBox2.Controls.Add(this.txttelefonotres);
            this.groupBox2.Controls.Add(this.btnTelefonoDos);
            this.groupBox2.Controls.Add(this.button29);
            this.groupBox2.Controls.Add(this.btnTelefonoPrincipal);
            this.groupBox2.Controls.Add(this.button30);
            this.groupBox2.Controls.Add(this.button37);
            this.groupBox2.Controls.Add(this.button31);
            this.groupBox2.Controls.Add(this.btnTelefonoTres);
            this.groupBox2.Controls.Add(this.button34);
            this.groupBox2.Controls.Add(this.btnDatosExtra);
            this.groupBox2.Controls.Add(this.button33);
            this.groupBox2.Controls.Add(this.button35);
            this.groupBox2.Controls.Add(this.button32);
            this.groupBox2.Location = new System.Drawing.Point(5, 48);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(914, 762);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            // 
            // grbNewOrder
            // 
            this.grbNewOrder.Controls.Add(this.Prueba);
            this.grbNewOrder.Location = new System.Drawing.Point(923, 48);
            this.grbNewOrder.Margin = new System.Windows.Forms.Padding(2);
            this.grbNewOrder.Name = "grbNewOrder";
            this.grbNewOrder.Padding = new System.Windows.Forms.Padding(2);
            this.grbNewOrder.Size = new System.Drawing.Size(406, 762);
            this.grbNewOrder.TabIndex = 100;
            this.grbNewOrder.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(6, 810);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1323, 74);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1336, 920);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbNewOrder);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Prueba.ResumeLayout(false);
            this.Prueba.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pv1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbNewOrder.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Prueba;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbabreviatura;
        private System.Windows.Forms.Button btnTelefonoDos;
        private System.Windows.Forms.Button btnTelefonoPrincipal;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button btnTelefonoTres;
        private System.Windows.Forms.Button btnDatosExtra;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.TextBox txttelefonotres;
        private System.Windows.Forms.TextBox txttelefonodos;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.TextBox txttelefonoprincipal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnporsentaje;
        private System.Windows.Forms.CheckBox ckbasisnar;
        private System.Windows.Forms.PictureBox pv2;
        private System.Windows.Forms.PictureBox pv1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNuevaOrden;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtPrecioTotal;
        public System.Windows.Forms.TableLayoutPanel tbpDatos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grbNewOrder;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}