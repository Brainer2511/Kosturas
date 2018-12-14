using Domain;
using Kosturas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kosturas.View
{
    public partial class Form1 : Form
    {
        DataContextLocal db = new DataContextLocal();
        public Prenda prenda = new Prenda();
        public Tarea tarea = new Tarea();
        public DetalleTarea detalle = new DetalleTarea();
        public Servicios servicio = new Servicios();
        public int ClienteId { get; set; }
        int paginas = 0;
        int pagina = 1;
        public object x { get; set; }
        private Cliente cliente=new Cliente();
        
        public Form1(int clienteId=0)
        {
           ClienteId = clienteId;
            cliente = db.Clientes.Find(clienteId);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
            if (ClienteId>0 )
            {
                cargar();
            }

          
        
         
          
          
            this.pv2.Visible = false;
            this.pv1.Visible = false;
            this.lbl1.Visible = false;
            this.lbl2.Visible = false;


            cmbabreviatura.Items.Add("Sr");
            cmbabreviatura.Items.Add("Sra");
            cmbabreviatura.Items.Add("Srita");

            var prendas = db.Prendas.Take(28).ToList();
            var x = 0;
            var y = 0;
            var l = 0;
           var total = db.Prendas.Count();
            paginas = total / 28;
            if (total % 28 > 0) {
                paginas += 1;

            }
            if (paginas > 1)
            {
                this.pv2.Visible = true;
                this.pv1.Visible = true;
                this.lbl1.Visible = true;
                this.lbl2.Visible = true;
                this.lbl2.Text = paginas.ToString();


            }
            foreach (var item in prendas)
            {

                var botones = new Button();
                botones.BackgroundImageLayout = ImageLayout.Center;
                if (!string.IsNullOrEmpty(item.Imagen))
                {
                    botones.Image = Image.FromFile(@item.Imagen);
                }

                botones.Text = item.TipoRopa;
                botones.Name = item.PrendaId.ToString();
                botones.Location = new Point(x, y);
                botones.Size = new Size(100, 100);
                botones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Click += new EventHandler(ClickPrendas);
                this.Prueba.Controls.Add(botones);


                if (l == 3)
                {

                    l = 0;
                    x = 0;
                    y += 100;

                }
                else
                {
                    x += 100;

                    l += 1;
                }
            }




        }

        private void cargar()
        {
            txtNombre.Text = cliente.Nombre;
            txtEmail.Text = cliente.Email;
            txtCalle.Text = cliente.Calle;
            txtCiudad.Text = cliente.Ciudad;
            txtNotas.Text = cliente.Notas;
            txttelefonoprincipal.Text = cliente.TelefonoPrincipal;
            txttelefonodos.Text = cliente.TelefonoDos;
            txttelefonotres.Text = cliente.Telefonotres;
            txtCodigoPostal.Text = cliente.Codigopostal;
            
       
        }

        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            MessageBox.Show(this, @"you clicked " + e.SubItem.Text);
        }
        void ClickPrendas(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            var id = int.Parse(btn.Name);
            prenda = db.Prendas.Find(id);


            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dvgOrdenes);
            row.Cells[0].Value = prenda.TipoRopa;
            dvgOrdenes.Rows.Add(row);
            row = new DataGridViewRow();
            row.CreateCells(dvgOrdenes);
            row.Cells[0].Value = prenda.Tareas.FirstOrDefault().NombreTareas;
            row.Cells[1].Value = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().Precio;
            dvgOrdenes.Rows.Add(row);

            DataGridViewImageColumn NuevaOrden = new DataGridViewImageColumn();
            NuevaOrden.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\pesa.png");
            dvgOrdenes.Columns.Add(NuevaOrden);

            DataGridViewImageColumn DuplicarPrenda = new DataGridViewImageColumn();
            DuplicarPrenda.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\duplicar.png");
            dvgOrdenes.Columns.Add(DuplicarPrenda);


            DataGridViewImageColumn mascinco = new DataGridViewImageColumn();
            mascinco.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\cincomas.png");
            dvgOrdenes.Columns.Add(mascinco);

            DataGridViewImageColumn masuno = new DataGridViewImageColumn();
            masuno.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\unomas.png");
            dvgOrdenes.Columns.Add(masuno);


            DataGridViewImageColumn menoscinco = new DataGridViewImageColumn();
            menoscinco.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\cincomenos.png");
            dvgOrdenes.Columns.Add(menoscinco);

            DataGridViewImageColumn menosuno = new DataGridViewImageColumn();
            menosuno.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\unomenos.png");
            dvgOrdenes.Columns.Add(menosuno);

            DataGridViewImageColumn agregartarea = new DataGridViewImageColumn();
            agregartarea.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\nuevot.png");
            dvgOrdenes.Columns.Add(agregartarea);

            DataGridViewImageColumn eliminartarea = new DataGridViewImageColumn();
            eliminartarea.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\equis.png");
            dvgOrdenes.Columns.Add(eliminartarea);


            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < total; i++)
            {
                Prueba.Controls.Remove(Prueba.Controls[0]);
            }
            var btnAtras = new Button();
            btnAtras.BackColor = System.Drawing.Color.WhiteSmoke;
            btnAtras.ForeColor = System.Drawing.Color.Black;
            btnAtras.Location = new System.Drawing.Point(49, 600);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new System.Drawing.Size(106, 41);
            btnAtras.TabIndex = 145;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = false;
            btnAtras.Click += new System.EventHandler(ClickAtrasPrendasInicio);
            this.Prueba.Controls.Add(btnAtras);
            servicios();
        }

        void ClickServicios(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            var id = int.Parse(btn.Name);
            servicio = db.Servicios.Find(id);
            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < total; i++)
            {
                Prueba.Controls.Remove(Prueba.Controls[0]);
            }

            var btnAtrasservicio = new Button();
            btnAtrasservicio.BackColor = System.Drawing.Color.WhiteSmoke;
            btnAtrasservicio.ForeColor = System.Drawing.Color.Black;
            btnAtrasservicio.Location = new System.Drawing.Point(49, 600);
            btnAtrasservicio.Name = "btnAtrasServicio";
            btnAtrasservicio.Size = new System.Drawing.Size(106, 41);
            btnAtrasservicio.TabIndex = 145;
            btnAtrasservicio.Text = "Atras";
            btnAtrasservicio.UseVisualStyleBackColor = false;
            btnAtrasservicio.Click += new System.EventHandler(ClickAtrasServicio);
            this.Prueba.Controls.Add(btnAtrasservicio);
            Tareas(servicio);

        }

        void ClickTareaS(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            var id = int.Parse(btn.Name);
            tarea = db.Tareas.Find(id);
            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < total; i++)
            {
                Prueba.Controls.Remove(Prueba.Controls[0]);
            }

            var btnAtrasTareas = new Button();
            btnAtrasTareas.BackColor = System.Drawing.Color.WhiteSmoke;
            btnAtrasTareas.ForeColor = System.Drawing.Color.Black;
            btnAtrasTareas.Location = new System.Drawing.Point(49, 600);
            btnAtrasTareas.Name = "btnAtras";
            btnAtrasTareas.Size = new System.Drawing.Size(106, 41);
            btnAtrasTareas.TabIndex = 145;
            btnAtrasTareas.Text = "Atras";
            btnAtrasTareas.UseVisualStyleBackColor = false;
            btnAtrasTareas.Click += new System.EventHandler(ClickAtrasTarea);
            this.Prueba.Controls.Add(btnAtrasTareas);
            detalletarea(tarea);
        }
        void ClickDetalletareas(object sender, EventArgs e)
        {


            Button btn = sender as Button;
            var id = int.Parse(btn.Name);
            detalle = db.DetalleTareas.Find(id);
            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < total; i++)
            {
                Prueba.Controls.Remove(Prueba.Controls[0]);
            }
            mostrarcontroles(detalle);


        }

        void ClickAtrasprueba(object sender, EventArgs e)
        {


            // Button btn = sender as Button;
            //    var id = int.Parse(btn.Name);
            // var tarea = db.Tareas.ToList();
            // var tarea = db.Tareas.Find(id);
            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < total; i++)
            {
                Prueba.Controls.Remove(Prueba.Controls[0]);
            }

            var btnAtrasTareas = new Button();
            btnAtrasTareas.BackColor = System.Drawing.Color.WhiteSmoke;
            btnAtrasTareas.ForeColor = System.Drawing.Color.Black;
            btnAtrasTareas.Location = new System.Drawing.Point(49, 600);
            btnAtrasTareas.Name = "btnAtras";
            btnAtrasTareas.Size = new System.Drawing.Size(106, 41);
            btnAtrasTareas.TabIndex = 145;
            btnAtrasTareas.Text = "Atras";
            btnAtrasTareas.UseVisualStyleBackColor = false;
            btnAtrasTareas.Click += new System.EventHandler(ClickAtrasTarea);
            this.Prueba.Controls.Add(btnAtrasTareas);


            detalletarea(tarea);


        }

        void ClickAtrasPrendasInicio(object sender, EventArgs e) {

            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < total; i++)
            {
                Prueba.Controls.Remove(Prueba.Controls[0]);
            }
            var prendas = db.Prendas.Take(28).ToList();
         
            var x = 0;
            var y = 0;
            var l = 0;

            foreach (var item in prendas)
            {
                var botones = new Button();
                botones.BackgroundImageLayout = ImageLayout.Center;
                if (!string.IsNullOrEmpty(item.Imagen))
                {
                    botones.Image = Image.FromFile(@item.Imagen);
                }
                botones.Text = item.TipoRopa;
                botones.Name = item.PrendaId.ToString();
                botones.Location = new Point(x, y);
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Size = new Size(100, 100);
                botones.Click += new EventHandler(ClickPrendas);
                this.Prueba.Controls.Add(botones);


                if (l == 3)
                {

                    l = 0;
                    x = 0;
                    y += 100;

                }
                else
                {
                    x += 100;

                    l += 1;
                }
            }

        }

        void ClickAtrasServicio(object sender, EventArgs e)
        {
            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < total; i++)
            {
                Prueba.Controls.Remove(Prueba.Controls[0]);
            }

            var servicios = prenda.Tareas.Select(t => t.Servicio).Distinct().Take(28).ToList();
            var x = 0;
            var y = 0;
            var l = 0;

            foreach (var item in servicios)
            {
                var botones = new Button();
                botones.Text = item.NombreServicio;
                botones.Name = item.ServiciosId.ToString();
                botones.Location = new Point(x, y);
                botones.Size = new Size(100, 100);
                botones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Click += new EventHandler(ClickServicios);
                this.Prueba.Controls.Add(botones);


                if (l == 3)
                {

                    l = 0;
                    x = 0;
                    y += 100;

                }
                else
                {
                    x += 100;

                    l += 1;
                }
            }
            var btnAtras = new Button();
            btnAtras.BackColor = System.Drawing.Color.WhiteSmoke;
            btnAtras.ForeColor = System.Drawing.Color.Black;
            btnAtras.Location = new System.Drawing.Point(49, 600);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new System.Drawing.Size(106, 41);
            btnAtras.TabIndex = 145;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = false;
            btnAtras.Click += new System.EventHandler(ClickAtrasPrendasInicio);
            this.Prueba.Controls.Add(btnAtras);


        }
        void ClickAtrasTarea(object sender, EventArgs e)
        {
            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < total; i++)
            {
                Prueba.Controls.Remove(Prueba.Controls[0]);
            }
            var tareas = db.Tareas.Where(t => t.ServiciosId == servicio.ServiciosId && t.PrendaId == prenda.PrendaId).Take(28).ToList();
            var x = 0;
            var y = 0;
            var l = 0;

            foreach (var item in tareas)
            {
                var botones = new Button();
                botones.Text = item.NombreTareas;
                botones.Name = item.TareaId.ToString();
                botones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Location = new Point(x, y);
                botones.Size = new Size(100, 100);
                botones.Click += new EventHandler(ClickTareaS);
                this.Prueba.Controls.Add(botones);


                if (l == 3)
                {

                    l = 0;
                    x = 0;
                    y += 100;

                }
                else
                {
                    x += 100;

                    l += 1;
                }
            }

            var btnAtrasservicio = new Button();
            btnAtrasservicio.BackColor = System.Drawing.Color.WhiteSmoke;
            btnAtrasservicio.ForeColor = System.Drawing.Color.Black;
            btnAtrasservicio.Location = new System.Drawing.Point(49, 600);
            btnAtrasservicio.Name = "btnAtrasServicio";
            btnAtrasservicio.Size = new System.Drawing.Size(106, 41);
            btnAtrasservicio.TabIndex = 145;
            btnAtrasservicio.Text = "Atras";
            btnAtrasservicio.UseVisualStyleBackColor = false;
            btnAtrasservicio.Click += new System.EventHandler(ClickAtrasServicio);
            this.Prueba.Controls.Add(btnAtrasservicio);


        }




        public void mostrarcontroles(DetalleTarea detalle)
        {


            this.txtPrecioTotal.Text = detalle.Precio;

            var botonlimpiar = new Button();
            //   botonlimpiar.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Kosturas\\Resources\\search.png");
            botonlimpiar.Text = "Limpiar Precio";
            botonlimpiar.Name = "btnLimpiar";
            botonlimpiar.Location = new Point(0, 72);
            botonlimpiar.Size = new Size(100, 200);
            botonlimpiar.Click += new EventHandler(cliclBorrarPrecio);
            this.Prueba.Controls.Add(botonlimpiar);

            var boton0 = new Button();
            boton0.Text = "0";
            boton0.Name = "btn0";
            boton0.Location = new Point(202, 222);
            boton0.Size = new Size(100, 50);
            boton0.Click += new EventHandler(btn0_Click);
            this.Prueba.Controls.Add(boton0);

            var botonpor = new Button();
            botonpor.Text = "*";
            botonpor.Name = "btnPor";
            botonpor.Location = new Point(102, 222);
            botonpor.Size = new Size(100, 50);
            botonpor.Click += new EventHandler(btnpor_Click);
            this.Prueba.Controls.Add(botonpor);

            var botonretroceso = new Button();
            botonretroceso.Text = "<-";
            botonretroceso.Name = "btnretroceso";
            botonretroceso.Location = new Point(302, 222);
            botonretroceso.Size = new Size(100, 50);
            botonretroceso.Click += new EventHandler(btnretroceso_Click);
            this.Prueba.Controls.Add(botonretroceso);

            var x = 102;
            var y = 72;
            var l = 0;
            for (int i = 0; i < 9; i++)
            {
                var a = "a";
                var b = "b";
                int c = 0;
                c = i + 1;
                a = c.ToString();
                b = "btn" + c;
           
              
            
                var boton1 = new Button();
                boton1.Text = a;
                boton1.Name = b;
                boton1.Location = new Point(x, y);
                boton1.Size = new Size(100, 50);
                this.Prueba.Controls.Add(boton1);
                if (i == 0)
                {
                    boton1.Click += new EventHandler(btn1_Click);

                }
                if (i == 1)
                {
                    boton1.Click += new EventHandler(btn2_Click);

                }
                if (i == 2)
                {
                    boton1.Click += new EventHandler(btn3_Click);

                }
                if (i == 3)
                {
                    boton1.Click += new EventHandler(btn4_Click);
                }
                if (i == 4)
                {
                    boton1.Click += new EventHandler(btn5_Click);

                }
                if (i == 5)
                {
                    boton1.Click += new EventHandler(btn6_Click);

                }
                if (i == 6)
                {
                    boton1.Click += new EventHandler(btn7_Click);
                }
                if (i == 7)
                {
                    boton1.Click += new EventHandler(btn8_Click);
                }
                if (i == 8)
                {
                    boton1.Click += new EventHandler(btn9_Click);
                }
              


                if (l == 2)
                {

                    l = 0;
                    x = 102;
                    y += 50;

                }
                else
                {
                    x += 100;

                    l += 1;
                }

            }

            var botonmas = new Button();
            botonmas.Text = "+";
            botonmas.Name = "btnmas";
            botonmas.Location = new Point(0, 330);
            botonmas.Size = new Size(76, 169);
            botonmas.Click += new EventHandler(ClickPrendas);
            this.Prueba.Controls.Add(botonmas);


            var txtboxdato = new TextBox();
            // txtboxdato.Text = "+";
            txtboxdato.Name = "txtdato";
            txtboxdato.Location = new Point(79, 330);
            txtboxdato.Multiline = true;
            txtboxdato.Size = new Size(317, 169);
            //  txtboxdato.BackColor = System.Drawing.Color.Black;
            //  txtboxdato.Click += new EventHandler(ClickPrendas);
            this.Prueba.Controls.Add(txtboxdato);

            var combo = new ComboBox();
            combo.Text = "";
            combo.Name = "cmbofertas";
            combo.Location = new Point(3, 520);
            combo.Size = new Size(274, 21);
            //  combo.Click += new EventHandler(ClickPrendas);
            this.Prueba.Controls.Add(combo);
            var ofertas =
         from a in db.Ofertas

         select new { Names = a.Descripcion };

            combo.DataSource = ofertas.ToList();
            combo.DisplayMember = "Names";

            var combodos = new ComboBox();
            combodos.Text = "";
            combodos.Name = "cmbafiliados";
            combodos.Location = new Point(3, 550);
            combodos.Size = new Size(274, 21);
            //   combodos.Click += new EventHandler(ClickPrendas);
            this.Prueba.Controls.Add(combodos);

            var afiliados =
     from a in db.Afiliados

     select new { Names = a.Nombre };

            combodos.DataSource = afiliados.ToList();
            combodos.DisplayMember = "Names";



            var botox1 = new Button();
            botox1.Text = "X";
            botox1.Name = "btnx1";
            botox1.Location = new Point(283, 520);
            botox1.Size = new Size(30, 25);
            botox1.Click += new EventHandler(ClickPrendas);
            this.Prueba.Controls.Add(botox1);

            var botox2 = new Button();
            botox2.Text = "X";
            botox2.Name = "btnx2";
            botox2.Location = new Point(283, 550);
            botox2.Size = new Size(30, 25);
            botox2.Click += new EventHandler(ClickPrendas);
            this.Prueba.Controls.Add(botox2);



            var precio = new Label();
            precio.AutoSize = true;
            precio.BackColor = System.Drawing.Color.White;
            precio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            precio.Location = new System.Drawing.Point(58, 15);
            precio.Name = "Precio";
            precio.Size = new System.Drawing.Size(35, 13);
            precio.TabIndex = 94;
            precio.Text = "" + detalle.Precio;
            this.Prueba.Controls.Add(precio);

            var lblprecio = new Label();
            lblprecio.AutoSize = true;
            lblprecio.BackColor = System.Drawing.Color.White;
            lblprecio.Location = new System.Drawing.Point(12, 15);
            lblprecio.Name = "lblprecio";
            lblprecio.Size = new System.Drawing.Size(40, 13);
            lblprecio.TabIndex = 95;
            lblprecio.Text = "Precio:";
            this.Prueba.Controls.Add(lblprecio);


            var panelemcabezado = new Panel();
            panelemcabezado.Name = "paneencabezado";
            panelemcabezado.Location = new Point(3, 3);
            panelemcabezado.Size = new Size(398, 47);
            panelemcabezado.BackColor = System.Drawing.SystemColors.ActiveCaptionText;


            this.Prueba.Controls.Add(panelemcabezado);


            var btnNuevoItem = new Button();
            btnNuevoItem.BackColor = System.Drawing.Color.WhiteSmoke;
            btnNuevoItem.ForeColor = System.Drawing.Color.Black;
            btnNuevoItem.Location = new System.Drawing.Point(277, 600);
            btnNuevoItem.Name = "btnNuevoItem";
            btnNuevoItem.Size = new System.Drawing.Size(106, 41);
            btnNuevoItem.TabIndex = 146;
            btnNuevoItem.Text = "Nuevo Item";
            btnNuevoItem.UseVisualStyleBackColor = false;
            btnNuevoItem.Click += new System.EventHandler(ClickAtrasPrendasInicio);
            this.Prueba.Controls.Add(btnNuevoItem);


            var btnAtras = new Button();
            btnAtras.BackColor = System.Drawing.Color.WhiteSmoke;
            btnAtras.ForeColor = System.Drawing.Color.Black;
            btnAtras.Location = new System.Drawing.Point(49, 600);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new System.Drawing.Size(106, 41);
            btnAtras.TabIndex = 145;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = false;
            btnAtras.Click += new System.EventHandler(ClickAtrasprueba);
            this.Prueba.Controls.Add(btnAtras);

            var label2 = new Label();
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(0, 277);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(35, 13);
            label2.TabIndex = 147;
            label2.Text = "Tiempo De Respuesta(Minutos):";
            // label2.BackColor = System.Drawing.Color.Black;
            this.Prueba.Controls.Add(label2);

            var label3 = new Label();
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(0, 300);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(35, 13);
            label3.TabIndex = 148;
            label3.Text = "Descripcion:";
            // label3.BackColor = System.Drawing.Color.Black;
            this.Prueba.Controls.Add(label3);

            var btnTiempo = new Button();
            btnTiempo.Location = new System.Drawing.Point(216, 277);
            btnTiempo.Name = "btntiempo";
            btnTiempo.Size = new System.Drawing.Size(49, 27);
            btnTiempo.TabIndex = 149;
            btnTiempo.Text = "23";
            btnTiempo.UseVisualStyleBackColor = true;
            this.Prueba.Controls.Add(btnTiempo);

            var btnEnviar = new Button();
            btnEnviar.BackColor = System.Drawing.Color.GreenYellow;
            btnEnviar.Location = new System.Drawing.Point(1130, 763);
            btnEnviar.Name = "btnEnviardos";
            btnEnviar.Size = new System.Drawing.Size(200, 44);
            btnEnviar.TabIndex = 74;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += new System.EventHandler(btnEnviar_Click);
            this.Controls.Add(btnEnviar);


        }


        public void cliclBorrarPrecio(object sender, EventArgs e)
        {

            var precio = new Label();
            precio.Text = detalle.Precio;
            this.txtPrecioTotal.Text = "0";
            //  this.precio.Text = "0";


        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.Nombre = txtNombre.Text;
            cliente.TelefonoPrincipal = txttelefonoprincipal.Text;
            cliente.TelefonoDos = txttelefonodos.Text;
            cliente.Telefonotres = txttelefonotres.Text;
            cliente.Abreviatura = cmbabreviatura.SelectedIndex.ToString();
            cliente.Calle = txtCalle.Text;
            cliente.Ciudad = txtCiudad.Text;
            cliente.Codigopostal = txtCodigoPostal.Text;
            cliente.Email = txtEmail.Text;
            cliente.Notas = txtNotas.Text;
            cliente.TotalOrden = txtPrecioTotal.Text;



            db.Clientes.Add(cliente);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
        }


     
        public void servicios()
        {
            var servicios = prenda.Tareas.Select(t => t.Servicio).Distinct().Take(28).ToList();
            var x = 0;
            var y = 0;
            var l = 0;

            foreach (var item in servicios)
            {
                var botones = new Button();
                botones.BackgroundImageLayout = ImageLayout.Center;
                if (!string.IsNullOrEmpty(item.Imagen))
                {
                    botones.Image = Image.FromFile(@item.Imagen);
                }
                botones.Text = item.NombreServicio;
                botones.Name = item.ServiciosId.ToString();
                botones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Location = new Point(x, y);
                botones.Size = new Size(100, 100);
                botones.Click += new EventHandler(ClickServicios);
                this.Prueba.Controls.Add(botones);


                if (l == 3)
                {

                    l = 0;
                    x = 0;
                    y += 100;

                }
                else
                {
                    x += 100;

                    l += 1;
                }
            }

        }



        public void Tareas(Servicios servicio)
        {
            var tareas = db.Tareas.Where(t => t.ServiciosId == servicio.ServiciosId && t.PrendaId == prenda.PrendaId).Take(28).ToList();
            var x = 0;
            var y = 0;
            var l = 0;

            foreach (var item in tareas)
            {
                var botones = new Button();
                botones.BackgroundImageLayout = ImageLayout.Center;
                if (!string.IsNullOrEmpty(item.Imagen))
                {
                    botones.Image = Image.FromFile(@item.Imagen);
                }
                botones.Text = item.NombreTareas;
                botones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Name = item.TareaId.ToString();
                botones.Location = new Point(x, y);
                botones.Size = new Size(100, 100);
                botones.Click += new EventHandler(ClickTareaS);
                this.Prueba.Controls.Add(botones);


                if (l == 3)
                {

                    l = 0;
                    x = 0;
                    y += 100;

                }
                else
                {
                    x += 100;

                    l += 1;
                }
            }

        }



        public void detalletarea(Tarea tarea)



        {




            var detalletareas = db.DetalleTareas.Where(t => t.TareaId == tarea.TareaId).Take(28).ToList();
            var x = 0;
            var y = 0;
            var l = 0;

            foreach (var item in detalletareas)
            {
                var botones = new Button();
                botones.BackgroundImageLayout = ImageLayout.Center;
                if (!string.IsNullOrEmpty(item.Imagen))
                {
                    botones.Image = Image.FromFile(@item.Imagen);
                }
                botones.Text = item.DetalleTareas;
                botones.Name = item.DetalleTareaId.ToString();
                botones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Location = new Point(x, y);
                botones.Size = new Size(100, 100);
                botones.Click += new EventHandler(ClickDetalletareas);
                this.Prueba.Controls.Add(botones);


                if (l == 3)
                {

                    l = 0;
                    x = 0;
                    y += 100;

                }
                else
                {
                    x += 100;

                    l += 1;
                }
            }

        }

        private void button29_MouseDown(object sender, MouseEventArgs e)
        {
            // btnEnviar.BackColor = System.Drawing.Color.GreenYellow;
            //    BackColor = System.Drawing.Color.GreenYellow;
        }

        private void button29_MouseEnter(object sender, EventArgs e)
        {

            this.button29.BackColor = System.Drawing.Color.OliveDrab;
            this.button29.ForeColor = System.Drawing.Color.White;
        }

        private void button29_MouseLeave(object sender, EventArgs e)
        {

            this.button29.BackColor = System.Drawing.SystemColors.Control;
            this.button29.ForeColor = System.Drawing.Color.Black;
        }

        private void button34_MouseEnter(object sender, EventArgs e)
        {


            this.button34.BackColor = System.Drawing.Color.OliveDrab;
            this.button34.ForeColor = System.Drawing.Color.White;
        }

        private void button34_MouseLeave(object sender, EventArgs e)
        {

            this.button34.BackColor = System.Drawing.SystemColors.Control;
            this.button34.ForeColor = System.Drawing.Color.Black;
        }

        private void button32_MouseEnter(object sender, EventArgs e)
        {

            this.button32.BackColor = System.Drawing.Color.OliveDrab;
            this.button32.ForeColor = System.Drawing.Color.White;
        }

        private void button32_MouseLeave(object sender, EventArgs e)
        {

            this.button32.BackColor = System.Drawing.SystemColors.Control;
            this.button32.ForeColor = System.Drawing.Color.Black;
        }

        private void button31_MouseEnter(object sender, EventArgs e)
        {

            this.button31.BackColor = System.Drawing.Color.OliveDrab;
            this.button31.ForeColor = System.Drawing.Color.White;
        }

        private void button31_MouseLeave(object sender, EventArgs e)
        {

            this.button31.BackColor = System.Drawing.SystemColors.Control;
            this.button31.ForeColor = System.Drawing.Color.Black;
        }

        private void button35_MouseEnter(object sender, EventArgs e)
        {

            this.button35.BackColor = System.Drawing.Color.OliveDrab;
            this.button35.ForeColor = System.Drawing.Color.White;
        }

        private void button35_MouseLeave(object sender, EventArgs e)
        {

            this.button35.BackColor = System.Drawing.SystemColors.Control;
            this.button35.ForeColor = System.Drawing.Color.Black;
        }

        private void button30_MouseEnter(object sender, EventArgs e)
        {

            this.button30.BackColor = System.Drawing.Color.OliveDrab;
            this.button30.ForeColor = System.Drawing.Color.White;
        }

        private void button30_MouseLeave(object sender, EventArgs e)
        {

            this.button30.BackColor = System.Drawing.SystemColors.Control;
            this.button30.ForeColor = System.Drawing.Color.Black;
        }

        private void button33_MouseEnter(object sender, EventArgs e)
        {

            this.button33.BackColor = System.Drawing.Color.OliveDrab;
            this.button33.ForeColor = System.Drawing.Color.White;
        }

        private void button33_MouseLeave(object sender, EventArgs e)
        {

            this.button33.BackColor = System.Drawing.SystemColors.Control;
            this.button33.ForeColor = System.Drawing.Color.Black;
        }

        private void btnDatosExtra_MouseEnter(object sender, EventArgs e)
        {
            this.btnDatosExtra.BackColor = System.Drawing.Color.OliveDrab;
            this.btnDatosExtra.ForeColor = System.Drawing.Color.White;
        }

        private void btnDatosExtra_MouseLeave(object sender, EventArgs e)
        {

            this.btnDatosExtra.BackColor = System.Drawing.SystemColors.Control;
            this.btnDatosExtra.ForeColor = System.Drawing.Color.Black;
        }

        private void button37_MouseEnter(object sender, EventArgs e)
        {
            this.button37.BackColor = System.Drawing.Color.OliveDrab;
            this.button37.ForeColor = System.Drawing.Color.White;
        }

        private void button37_MouseLeave(object sender, EventArgs e)
        {

            this.button37.BackColor = System.Drawing.SystemColors.Control;
            this.button37.ForeColor = System.Drawing.Color.Black;
        }

        private void btnTelefonoDos_MouseEnter(object sender, EventArgs e)
        {
            this.btnTelefonoDos.BackColor = System.Drawing.Color.OliveDrab;
            this.btnTelefonoDos.ForeColor = System.Drawing.Color.White;
        }

        private void btnTelefonoDos_MouseLeave(object sender, EventArgs e)
        {

            this.btnTelefonoDos.BackColor = System.Drawing.SystemColors.Control;
            this.btnTelefonoDos.ForeColor = System.Drawing.Color.Black;
        }

        private void btnTelefonoPrincipal_MouseEnter(object sender, EventArgs e)
        {
            this.btnTelefonoPrincipal.BackColor = System.Drawing.Color.OliveDrab;
            this.btnTelefonoPrincipal.ForeColor = System.Drawing.Color.White;
        }

        private void btnTelefonoPrincipal_MouseLeave(object sender, EventArgs e)
        {

            this.btnTelefonoPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.btnTelefonoPrincipal.ForeColor = System.Drawing.Color.Black;
        }

        private void btnTelefonoTres_MouseEnter(object sender, EventArgs e)
        {
            this.btnTelefonoTres.BackColor = System.Drawing.Color.OliveDrab;
            this.btnTelefonoTres.ForeColor = System.Drawing.Color.White;
        }

        private void btnTelefonoTres_MouseLeave(object sender, EventArgs e)
        {

            this.btnTelefonoTres.BackColor = System.Drawing.SystemColors.Control;
            this.btnTelefonoTres.ForeColor = System.Drawing.Color.Black;
        }

        private void cmbabreviatura_MouseEnter(object sender, EventArgs e)
        {

            this.cmbabreviatura.BackColor = System.Drawing.Color.OliveDrab;
            this.cmbabreviatura.ForeColor = System.Drawing.Color.White;
        }

        private void cmbabreviatura_MouseLeave(object sender, EventArgs e)
        {
            this.cmbabreviatura.BackColor = System.Drawing.SystemColors.Control;
            this.cmbabreviatura.ForeColor = System.Drawing.Color.Black;
        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void pv2_Click(object sender, EventArgs e)
        {
            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
          
            if (pagina <paginas)
            {
                for (int i = 0; i < total; i++)
                {
                    Prueba.Controls.Remove(Prueba.Controls[0]);
                }
                pagina += 1;
                var skip = (pagina - 1)*28;
             

                var prendas = db.Prendas.OrderBy(t => t.PrendaId).Skip(skip).Take(28).ToList();
                var x = 0;
                var y = 0;
                var l = 0;
           
                
                foreach (var item in prendas)
                {

                    var botones = new Button();
                   // botones.BackgroundImageLayout = ImageLayout.Center;
                    if (!string.IsNullOrEmpty(item.Imagen))
                    {
                        botones.Image = Image.FromFile(@item.Imagen);
                    }

                    botones.Text = item.TipoRopa;
                    botones.Name = item.PrendaId.ToString();
                    botones.Location = new Point(x, y);
                    botones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                    botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    botones.Size = new Size(100, 100);
                    botones.Click += new EventHandler(ClickPrendas);
                    this.Prueba.Controls.Add(botones);


                    if (l == 3)
                    {

                        l = 0;
                        x = 0;
                        y += 100;

                    }
                    else
                    {
                        x += 100;

                        l += 1;
                    }
                }

            }


            }

        private void pv1_Click(object sender, EventArgs e)
        {

            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
          
            if (pagina != 1)
            {
                for (int i = 0; i < total; i++)
                {
                    Prueba.Controls.Remove(Prueba.Controls[0]);
                }
                pagina -= 1;
                var skip = (pagina - 1) * 28;


                var prendas = db.Prendas.OrderBy(t=>t.PrendaId).Take(28).Skip(skip).ToList();
                var x = 0;
                var y = 0;
                var l = 0;


                foreach (var item in prendas)
                {

                    var botones = new Button();
                    botones.BackgroundImageLayout = ImageLayout.Center;
                    if (!string.IsNullOrEmpty(item.Imagen))
                    {
                        botones.Image = Image.FromFile(@item.Imagen);
                    }

                    botones.Text = item.TipoRopa;
                    botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    botones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                    botones.Name = item.PrendaId.ToString();
                    botones.Location = new Point(x, y);
                    botones.Size = new Size(100, 100);
                    botones.Click += new EventHandler(ClickPrendas);
                    this.Prueba.Controls.Add(botones);


                    if (l == 3)
                    {

                        l = 0;
                        x = 0;
                        y += 100;

                    }
                    else
                    {
                        x += 100;

                        l += 1;
                    }
                }

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dvgOrdenes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            this.dvgOrdenes.BackColor = System.Drawing.Color.OliveDrab;
            this.dvgOrdenes.ForeColor = System.Drawing.Color.White;
        }

        private void dvgOrdenes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            this.dvgOrdenes.BackColor = System.Drawing.Color.OliveDrab;
            this.dvgOrdenes.ForeColor = System.Drawing.Color.White;
        }

        private void dvgOrdenes_MouseEnter(object sender, EventArgs e)
        {

            this.dvgOrdenes.BackColor = System.Drawing.Color.OliveDrab;
            this.dvgOrdenes.ForeColor = System.Drawing.Color.White;
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "0")
            {
                txtPrecioTotal.Text = "1";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "1";
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "0")
            {
                txtPrecioTotal.Text = "2";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "2";
            }
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "0")
            {
                txtPrecioTotal.Text = "3";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "3";
            }
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "0")
            {
                txtPrecioTotal.Text = "4";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "4";
            }
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "0")
            {
                txtPrecioTotal.Text = "5";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "5";
            }
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "0")
            {
                txtPrecioTotal.Text = "6";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "6";
            }
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "0")
            {
                txtPrecioTotal.Text = "7";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "7";
            }
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "0")
            {
                txtPrecioTotal.Text = "8";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "8";
            }
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "0")
            {
                txtPrecioTotal.Text = "9";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "9";
            }
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "1" || txtPrecioTotal.Text == "2" || txtPrecioTotal.Text == "3" || txtPrecioTotal.Text == "4" || txtPrecioTotal.Text == "5" || txtPrecioTotal.Text == "6" || txtPrecioTotal.Text == "7" || txtPrecioTotal.Text == "8" || txtPrecioTotal.Text == "9")
            {
                txtPrecioTotal.Text = "0";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "0";
            }
        }

        private void btnpor_Click(object sender, EventArgs e)
        {
             double a;
        double b;
        string c;

            a = Convert.ToDouble(this.txtPrecioTotal.Text);
            c = "*";
            this.txtPrecioTotal.Clear();
            this.txtPrecioTotal.Focus();
          
        }

        private void btnretroceso_Click(object sender, EventArgs e)
        {
            if (txtPrecioTotal.Text == "")
            {
                txtPrecioTotal.Text = "0";
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "0";
            }
        }

        private void dvgOrdenes_ColumnHeaderCellChanged(object sender, DataGridViewColumnEventArgs e)
        {

            this.dvgOrdenes.BackColor = System.Drawing.Color.OliveDrab;
            this.dvgOrdenes.ForeColor = System.Drawing.Color.White;
        }

        private void dvgOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 4)
            {
                frmEmpleado empleado = new frmEmpleado();
                empleado.Show();


                this.Close();
                //Form form = new Form1();
                //form.Close();
               
            }
            else if (e.ColumnIndex == 7)

            {
                frmEmpleado empleado = new frmEmpleado();
                empleado.ShowDialog();

            }
        }
    }
    }

