using Domain;
using Kosturas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        //   public Form1 DAto = new Form1();
    //    public Form1 DAtos = new Form1();

        public int ClienteId { get; set; }
        //public int Datox { get; set; }
        //public int DAtoY { get; set; }
        string leibol="1";
        string leiboldos = "";
        int m = 0;
        int Datox = 0;
        int DAtoY = 0;
        int DAtoYdos = 50;
        int paginas = 0;
        int pagina = 1;
        int dato = 0;
        public int DAto;
        public object x { get; set; }
        private Cliente cliente=new Cliente();
     //   public int Dato { get; set; }
        
        public Form1(int clienteId=0)
        {
           ClienteId = clienteId;
            cliente = db.Clientes.Find(clienteId);
            InitializeComponent();
            
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            //Table.Controls.Add(new Label { Text = "Type:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            //Table.Controls.Add(new ComboBox { Dock = DockStyle.Fill }, 0, 1);
            if (ClienteId>0)
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
                botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Click += new EventHandler(ClickPrendas);
                botones.MouseLeave += new EventHandler(Mouseleave);
                botones.MouseEnter += new EventHandler(Mouseover);
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
        void Mouseover(object sender, EventArgs e)
        {
            Button btr = sender as Button;

       
            object id = btr.Name;
            id= btr.BackColor =Color.OliveDrab;
            id = btr.ForeColor = Color.White;
          

        }
        void Mouseleave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = Color.White;
            id = btr.ForeColor = System.Drawing.Color.Black;
       

        }
        void MouseoverCombo(object sender, EventArgs e)
        {
            ComboBox btr = sender as ComboBox;


            object id = btr.Name;
            id = btr.BackColor = Color.OliveDrab;
            id = btr.ForeColor = Color.White;


        }
        void MouseleaveCombo(object sender, EventArgs e)
        {
            ComboBox btr = sender as ComboBox;


            object id = btr.Name;
            id = btr.BackColor = Color.White;
            id = btr.ForeColor = System.Drawing.Color.Black;


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

              //   this.label5.Text = Dato.ToString();
            Button btn = sender as Button;
            var id = int.Parse(btn.Name);
            prenda = db.Prendas.Find(id);

            var dato = db.Prendas.Where(u => u.PrendaId == id).ToList();

            Panel Table = new Panel();
            //  Table.AutoScroll = true;
            Table.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Table.Location = new Point(Datox, DAtoY);
            Table.Size = new Size(897, 50);
            Table.BackColor = Color.DarkGray;

            Table.Name = "P_" + prenda.PrendaId.ToString();

            var d = 0;
            var f = 0;
            var o = 0;
            foreach (var item in dato)
            {

                var botonesdos = new Label();
                botonesdos.Size = new System.Drawing.Size(70, 45);
                botonesdos.Location = new Point(0, 0);

                botonesdos.Text = item.TipoRopa+ " "+ "X";
                botonesdos.Name = item.TipoRopa;



                var Prioridad = new Button();


                Prioridad.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\primera.png");

                Prioridad.BackColor = System.Drawing.Color.DarkGray;
                Prioridad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                Prioridad.Location = new Point(634, 6);
                Prioridad.FlatAppearance.BorderSize = 0;
                Prioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                Prioridad.Size = new System.Drawing.Size(32, 34);
                Prioridad.TabIndex = 142;
                Prioridad.UseVisualStyleBackColor = false;


                Prioridad.Name = item.PrendaId.ToString();
                Prioridad.Click += new EventHandler(ClickNuevaOrden);

                var Duplicar = new Button();

                Duplicar.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\duplicar.png");

                Duplicar.BackColor = System.Drawing.Color.DarkGray;
                Duplicar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                Duplicar.FlatAppearance.BorderSize = 0;
                Duplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                Duplicar.Location = new Point(666, 6);
                Duplicar.Size = new System.Drawing.Size(32, 34);
                Duplicar.TabIndex = 142;
                Duplicar.UseVisualStyleBackColor = false;
                Duplicar.Click += new EventHandler(ClickDuplicar);

                Duplicar.Name = item.PrendaId.ToString();

                var cantidad = new Button();


                cantidad.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\qrd.png");

                cantidad.BackColor = System.Drawing.Color.DarkGray;
                cantidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                cantidad.FlatAppearance.BorderSize = 0;
                cantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                cantidad.Location = new Point(698, 6);
                cantidad.Size = new System.Drawing.Size(32, 34);
                cantidad.TabIndex = 142;
                cantidad.UseVisualStyleBackColor = false;
                cantidad.Click += new EventHandler(ClickCantidad);

                cantidad.Name = item.PrendaId.ToString();

                var mascinco = new Button();


                mascinco.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\cincomas.png");

                mascinco.BackColor = System.Drawing.Color.DarkGray;
                mascinco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                mascinco.FlatAppearance.BorderSize = 0;
                mascinco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                mascinco.Location = new Point(730, 6);
                mascinco.Size = new System.Drawing.Size(32, 34);
                mascinco.TabIndex = 142;
                mascinco.UseVisualStyleBackColor = false;
                mascinco.Click += new EventHandler(Clickcincomas);

                mascinco.Name = item.PrendaId.ToString();

                var masuno = new Button();


                masuno.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\unomas.png");

                masuno.BackColor = System.Drawing.Color.DarkGray;
                masuno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                masuno.FlatAppearance.BorderSize = 0;
                masuno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                masuno.Location = new Point(762, 6);
                masuno.Size = new System.Drawing.Size(32, 34);
                masuno.TabIndex = 142;
                masuno.UseVisualStyleBackColor = false;
                masuno.Click += new EventHandler(Clickunomas);

                masuno.Name = item.PrendaId.ToString();

                var menosuno = new Button();

                menosuno.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\unomenos.png");

                menosuno.BackColor = System.Drawing.Color.DarkGray;
                menosuno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                menosuno.FlatAppearance.BorderSize = 0;
                menosuno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                menosuno.Location = new Point(794, 6);
                menosuno.Size = new System.Drawing.Size(32, 34);
                menosuno.TabIndex = 142;
                menosuno.UseVisualStyleBackColor = false;
                menosuno.Click += new EventHandler(Clickunomenos);
                menosuno.Name = item.PrendaId.ToString();
                var menoscinco = new Button();

                menoscinco.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\cincomenos.png");

                menoscinco.BackColor = System.Drawing.Color.DarkGray;
                menoscinco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                menoscinco.FlatAppearance.BorderSize = 0;
                menoscinco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                menoscinco.Location = new Point(828, 6);
                menoscinco.Size = new System.Drawing.Size(32, 34);
                menoscinco.TabIndex = 142;
                menoscinco.UseVisualStyleBackColor = false;
                menoscinco.Click += new EventHandler(Clickcincomenos);

                menoscinco.Name = item.PrendaId.ToString();
                var agregartarea = new Button();

                agregartarea.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\taps.png");

                agregartarea.BackColor = System.Drawing.Color.DarkGray;
                agregartarea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                agregartarea.FlatAppearance.BorderSize = 0;
                agregartarea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                agregartarea.Location = new Point(860, 6);
                agregartarea.Size = new System.Drawing.Size(32, 34);
                agregartarea.TabIndex = 142;
                agregartarea.Click += new EventHandler(ClickAddtax);
                agregartarea.UseVisualStyleBackColor = false;

                agregartarea.Name = item.PrendaId.ToString();


                Table.Controls.Add(botonesdos);

                Table.Controls.Add(Prioridad);
                Table.Controls.Add(Duplicar);
                Table.Controls.Add(cantidad);
                Table.Controls.Add(mascinco);
                Table.Controls.Add(masuno);
                Table.Controls.Add(menosuno);
                Table.Controls.Add(menoscinco);
                Table.Controls.Add(agregartarea);



            }
         
            Panel TableDos = new Panel();
            TableDos.Name = "Ganazo";

            TableDos.Location = new Point(Datox, DAtoYdos);
            TableDos.Size = new Size(897, 45);
            TableDos.BackColor = Color.White;
            TableDos.MouseLeave += new EventHandler(Mouseleavetabla);
            TableDos.MouseEnter += new EventHandler(Mouseovertabla);
            TableDos.Click += new EventHandler(ClickBorrartax);

            TableDos.Name = prenda.PrendaId.ToString();



            var prueba =prenda.Tareas.FirstOrDefault().NombreTareas;
            var pruebadostres = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleTareas;
            var pruebados=prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().Precio;
      
            var labeltarea = new Label();
            labeltarea.Size = new System.Drawing.Size(70, 34);
            labeltarea.Location = new Point(0, 10);

            labeltarea.Text = prueba;
            labeltarea.Name = prueba;

            var labeldetalle = new Label();
            labeldetalle.Size = new System.Drawing.Size(50, 34);
            labeldetalle.Location = new Point(132, 10);
            labeldetalle.Text = pruebadostres;
            labeldetalle.Name = pruebadostres;

            var labelprecio = new Label();
            labelprecio.Size = new System.Drawing.Size(50, 34);
            labelprecio.Location = new Point(182, 10);
            labelprecio.Text = pruebados;
            labelprecio.Name = pruebados;

          


            var agregartareados = new Button();

            agregartareados.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\equis.png");
            agregartareados.Name = prenda.PrendaId.ToString();
            agregartareados.BackColor = System.Drawing.Color.White;
            agregartareados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            agregartareados.FlatAppearance.BorderSize = 0;
            agregartareados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            agregartareados.Location = new Point(860, 6);
            agregartareados.Size = new System.Drawing.Size(32, 34);
            agregartareados.TabIndex = 142;
            agregartareados.UseVisualStyleBackColor = false;
            agregartareados.Click += new EventHandler(ClickBorrartax);

          //  agregartareados.Name = "DatosPrendasDos";


            TableDos.Controls.Add(labeltarea);
            TableDos.Controls.Add(labeldetalle);
            TableDos.Controls.Add(labelprecio);
            TableDos.Controls.Add(agregartareados);

       

            
            //this.Controls.Add(Table);
            //this.Controls.Add(TableDos);
            this.panel3.Controls.Add(Table);
            this.panel3.Controls.Add(TableDos);


            this.label4.Text = prenda.TipoRopa;
                this.label3.Text = "Nueva Orden:";



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
                btnAtras.MouseLeave += new EventHandler(Mouseleave);
                btn.MouseEnter += new EventHandler(Mouseover);
                this.Prueba.Controls.Add(btnAtras);


                servicios();
            }
        void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            //if (e.Column == 1 && e.Row == 0)
            //    e.Graphics.DrawRectangle(new Pen(Color.Blue), e.CellBounds);

            if (e.Column == 1 && e.Row == 0)
            {
                var rectangle = e.CellBounds;
                rectangle.Inflate(-1, -1);

                ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.All); // 3D border
                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Red, ButtonBorderStyle.Dotted); // dotted border
            }
        }
       
        void Mouseovertabla(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
           

            object id = btr.Name;
            id = btr.BackColor = Color.YellowGreen;
            id = btr.ForeColor = Color.Black;


        }
        void Mouseleavetabla(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;


            object id = btr.Name;
            id = btr.BackColor = Color.White;
            id = btr.ForeColor = System.Drawing.Color.Black;


        }

        void ClickServicios(object sender, EventArgs e)
            {


                Button btn = sender as Button;
                var id = int.Parse(btn.Name);
                servicio = db.Servicios.Find(id);
                this.label4.Text = prenda.TipoRopa;
                this.label3.Text = "Nueva " + btn.Text + " Orden:";
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
                btnAtrasservicio.MouseLeave += new EventHandler(Mouseleave);
                btnAtrasservicio.MouseEnter += new EventHandler(Mouseover);
                this.Prueba.Controls.Add(btnAtrasservicio);
                Tareas(servicio);

            }

            void ClickTareaS(object sender, EventArgs e)
            {

                Button btn = sender as Button;
                var id = int.Parse(btn.Name);
                tarea = db.Tareas.Find(id);
                this.label4.Text = prenda.TipoRopa + "-" + btn.Text;
                this.label3.Text = "Nueva " + servicio.NombreServicio + " Orden:";
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
                btnAtrasTareas.MouseLeave += new EventHandler(Mouseleave);
                btnAtrasTareas.MouseEnter += new EventHandler(Mouseover);
                this.Prueba.Controls.Add(btnAtrasTareas);
                detalletarea(tarea);
            }
            void ClickDetalletareas(object sender, EventArgs e)
            {


                Button btn = sender as Button;
                var id = int.Parse(btn.Name);
                detalle = db.DetalleTareas.Find(id);
                this.label4.Text = prenda.TipoRopa + "-" + tarea.NombreTareas + "-" + btn.Text;
                this.label3.Text = "Nueva " + servicio.NombreServicio + " Orden:";
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
                this.label4.Text = prenda.TipoRopa + "-" + tarea.NombreTareas;
                this.label3.Text = "Nueva " + servicio.NombreServicio + " Orden:";
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
                btnAtrasTareas.MouseLeave += new EventHandler(Mouseleave);
                btnAtrasTareas.MouseEnter += new EventHandler(Mouseover);
                this.Prueba.Controls.Add(btnAtrasTareas);


                detalletarea(tarea);


            }

            void ClickAtrasPrendasInicio(object sender, EventArgs e)
            {

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
                    botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                    botones.Size = new Size(100, 100);
                    botones.Click += new EventHandler(ClickPrendas);
                    botones.MouseLeave += new EventHandler(Mouseleave);
                    botones.MouseEnter += new EventHandler(Mouseover);
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

                this.label4.Text = prenda.TipoRopa;
                this.label3.Text = "Nueva Orden:";
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
                    botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                    botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    botones.Click += new EventHandler(ClickServicios);
                    botones.MouseLeave += new EventHandler(Mouseleave);
                    botones.MouseEnter += new EventHandler(Mouseover);
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
                btnAtras.MouseLeave += new EventHandler(Mouseleave);
                btnAtras.MouseEnter += new EventHandler(Mouseover);
                this.Prueba.Controls.Add(btnAtras);


            }
            void ClickAtrasTarea(object sender, EventArgs e)
            {
                this.label4.Text = prenda.TipoRopa;
                this.label3.Text = "Nueva " + servicio.NombreServicio + " Orden:";
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
                    botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                    botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    botones.Location = new Point(x, y);
                    botones.Size = new Size(100, 100);
                    botones.Click += new EventHandler(ClickTareaS);
                    botones.MouseLeave += new EventHandler(Mouseleave);
                    botones.MouseEnter += new EventHandler(Mouseover);
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
                btnAtrasservicio.MouseLeave += new EventHandler(Mouseleave);
                btnAtrasservicio.MouseEnter += new EventHandler(Mouseover);
                this.Prueba.Controls.Add(btnAtrasservicio);


            }





        public void mostrarcontrolesDos()
        {

            var pruebados = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().Precio;
            this.txtPrecioTotal.Text = pruebados;
       

            var botonlimpiar = new Button();
            //   botonlimpiar.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Kosturas\\Resources\\search.png");
            botonlimpiar.Text = "Limpiar Precio";
            botonlimpiar.Name = "btnLimpiar";
            botonlimpiar.Location = new Point(0, 72);
            botonlimpiar.Size = new Size(100, 200);
            botonlimpiar.Click += new EventHandler(cliclBorrarPrecio);
            botonlimpiar.MouseLeave += new EventHandler(Mouseleave);
            botonlimpiar.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonlimpiar);

            var boton0 = new Button();
            boton0.Text = "0";
            boton0.Name = "btn0";
            boton0.Location = new Point(202, 222);
            boton0.Size = new Size(100, 50);
            boton0.Click += new EventHandler(btn0_Click);
            boton0.MouseLeave += new EventHandler(Mouseleave);
            boton0.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(boton0);

            var botonpor = new Button();
            botonpor.Text = "*";
            botonpor.Name = "btnPor";
            botonpor.Location = new Point(102, 222);
            botonpor.Size = new Size(100, 50);
            botonpor.Click += new EventHandler(btnpor_Click);
            botonpor.MouseLeave += new EventHandler(Mouseleave);
            botonpor.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonpor);

            var botonretroceso = new Button();
           
            botonretroceso.Name = "btnretroceso";
            botonretroceso.Location = new Point(302, 222);
            botonretroceso.Size = new Size(100, 50);
            botonretroceso.Click += new EventHandler(btnretroceso_Click);
            botonretroceso.MouseLeave += new EventHandler(Mouseleave);
            botonretroceso.MouseEnter += new EventHandler(Mouseover);
            botonretroceso.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\retroceso.png");

          

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
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);

                }
                if (i == 1)
                {
                    boton1.Click += new EventHandler(btn2_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);

                }
                if (i == 2)
                {
                    boton1.Click += new EventHandler(btn3_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);

                }
                if (i == 3)
                {
                    boton1.Click += new EventHandler(btn4_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);
                }
                if (i == 4)
                {
                    boton1.Click += new EventHandler(btn5_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);

                }
                if (i == 5)
                {
                    boton1.Click += new EventHandler(btn6_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);

                }
                if (i == 6)
                {
                    boton1.Click += new EventHandler(btn7_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);
                }
                if (i == 7)
                {
                    boton1.Click += new EventHandler(btn8_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);
                }
                if (i == 8)
                {
                    boton1.Click += new EventHandler(btn9_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);
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
            // botonmas.Text = "+";
            botonmas.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\mas.png");

            botonmas.Name = "btnmas";
            botonmas.Location = new Point(0, 330);
            botonmas.Size = new Size(76, 169);
            botonmas.Click += new EventHandler(ClickPrendas);
            botonmas.MouseLeave += new EventHandler(Mouseleave);
            botonmas.MouseEnter += new EventHandler(Mouseover);
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
            combo.Text = "Selecione una Oferta";
            combo.Name = "cmbofertas";
            combo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            combo.Location = new Point(3, 520);
            combo.Size = new Size(274, 30);
            combo.MouseLeave += new EventHandler(MouseleaveCombo);
            combo.MouseEnter += new EventHandler(MouseoverCombo);
            this.Prueba.Controls.Add(combo);
            var ofertas =
         from a in db.Ofertas

         select new { Names = a.Descripcion };

            combo.DataSource = ofertas.ToList();
            combo.DisplayMember = "Names";

            var combodos = new ComboBox();
            combodos.Text = "Selecione Un afiliado";
            combodos.Name = "cmbafiliados";
            combodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            combodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            combodos.Location = new Point(3, 560);
            combodos.Size = new Size(274, 30);
            combodos.MouseLeave += new EventHandler(MouseleaveCombo);
            combodos.MouseEnter += new EventHandler(MouseoverCombo);
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
            botox1.Size = new Size(45, 40);
            botox1.Click += new EventHandler(ClickPrendas);
            botox1.MouseLeave += new EventHandler(Mouseleave);
            botox1.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botox1);

            var botonimagen = new Button();
            // botonmas.Text = "+";
            botonimagen.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\asterisco.png");

            botonimagen.Name = "asterisco1";
            botonimagen.Location = new Point(333, 520);
            botonimagen.Size = new Size(45, 40);
            botonimagen.Click += new EventHandler(ClickPrendas);
            botonimagen.MouseLeave += new EventHandler(Mouseleave);
            botonimagen.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonimagen);

            var botonimagendos = new Button();
            // botonmas.Text = "+";
            botonimagendos.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\asterisco.png");

            botonimagendos.Name = "asterisco2";
            botonimagendos.Location = new Point(333, 560);
            botonimagendos.Size = new Size(45, 40);
            botonimagendos.Click += new EventHandler(ClickPrendas);
            botonimagendos.MouseLeave += new EventHandler(Mouseleave);
            botonimagendos.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonimagendos);


            var botox2 = new Button();
            botox2.Text = "X";
            botox2.Name = "btnx2";
            botox2.Location = new Point(283, 560);
            botox2.Size = new Size(45, 40);
            botox2.Click += new EventHandler(ClickPrendas);
            botox2.MouseLeave += new EventHandler(Mouseleave);
            botox2.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botox2);

            var precio = new Label();
            precio.AutoSize = true;
            precio.BackColor = System.Drawing.Color.White;
            precio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            precio.Location = new System.Drawing.Point(58, 15);
            precio.Name = "Precio";
            precio.Size = new System.Drawing.Size(35, 13);
            precio.TabIndex = 94;
         
            precio.Text = "" + pruebados;
            
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
            btnNuevoItem.Location = new System.Drawing.Point(277, 630);
            btnNuevoItem.Name = "btnNuevoItem";
            btnNuevoItem.Size = new System.Drawing.Size(106, 41);
            btnNuevoItem.TabIndex = 146;
            btnNuevoItem.Text = "Nuevo Item";
            btnNuevoItem.UseVisualStyleBackColor = false;
            btnNuevoItem.Click += new System.EventHandler(ClickAtrasPrendasInicio);
            btnNuevoItem.MouseLeave += new EventHandler(Mouseleave);
            btnNuevoItem.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(btnNuevoItem);


            var btnAtras = new Button();
            btnAtras.BackColor = System.Drawing.Color.WhiteSmoke;
            btnAtras.ForeColor = System.Drawing.Color.Black;
            btnAtras.Location = new System.Drawing.Point(49, 630);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new System.Drawing.Size(106, 41);
            btnAtras.TabIndex = 145;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = false;
            btnAtras.Click += new System.EventHandler(ClickAtrasprueba);
            btnAtras.MouseLeave += new EventHandler(Mouseleave);
            btnAtras.MouseEnter += new EventHandler(Mouseover);
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
            btnEnviar.Location = new System.Drawing.Point(1143, 821);// 1143; 821
            btnEnviar.Name = "btnEnviardos";
            btnEnviar.Size = new System.Drawing.Size(200, 44);
            btnEnviar.TabIndex = 74;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += new System.EventHandler(btnEnviar_Click);
            this.Controls.Add(btnEnviar);


        }


        public void mostrarcontroles(DetalleTarea detalle)
        {



            var botonlimpiar = new Button();
            botonlimpiar.Text = "Limpiar Precio";
            botonlimpiar.Name = "btnLimpiar";
            botonlimpiar.Location = new Point(0, 72);
            botonlimpiar.Size = new Size(100, 200);
            botonlimpiar.Click += new EventHandler(cliclBorrarPrecio);
            botonlimpiar.MouseLeave += new EventHandler(Mouseleave);
            botonlimpiar.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonlimpiar);

            var boton0 = new Button();
            boton0.Text = "0";
            boton0.Name = "btn0";
            boton0.Location = new Point(202, 222);
            boton0.Size = new Size(100, 50);
            boton0.Click += new EventHandler(btn0_Click);
            boton0.MouseLeave += new EventHandler(Mouseleave);
            boton0.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(boton0);

            var botonpor = new Button();
            botonpor.Text = "*";
            botonpor.Name = "btnPor";
            botonpor.Location = new Point(102, 222);
            botonpor.Size = new Size(100, 50);
            botonpor.Click += new EventHandler(btnpor_Click);
            botonpor.MouseLeave += new EventHandler(Mouseleave);
            botonpor.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonpor);

            var botonretroceso = new Button();
            botonretroceso.Text = "<-";
            botonretroceso.Name = "btnretroceso";
            botonretroceso.Location = new Point(302, 222);
            botonretroceso.Size = new Size(100, 50);
            botonretroceso.Click += new EventHandler(btnretroceso_Click);
            botonretroceso.MouseLeave += new EventHandler(Mouseleave);
            botonretroceso.MouseEnter += new EventHandler(Mouseover);
            botonretroceso.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\retroceso.png");

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
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);

                }
                if (i == 1)
                {
                    boton1.Click += new EventHandler(btn2_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);

                }
                if (i == 2)
                {
                    boton1.Click += new EventHandler(btn3_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);

                }
                if (i == 3)
                {
                    boton1.Click += new EventHandler(btn4_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);
                }
                if (i == 4)
                {
                    boton1.Click += new EventHandler(btn5_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);

                }
                if (i == 5)
                {
                    boton1.Click += new EventHandler(btn6_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);

                }
                if (i == 6)
                {
                    boton1.Click += new EventHandler(btn7_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);
                }
                if (i == 7)
                {
                    boton1.Click += new EventHandler(btn8_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);
                }
                if (i == 8)
                {
                    boton1.Click += new EventHandler(btn9_Click);
                    boton1.MouseLeave += new EventHandler(Mouseleave);
                    boton1.MouseEnter += new EventHandler(Mouseover);
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
           // botonmas.Text = "+";
            botonmas.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\mas.png");
            
            botonmas.Name = "btnmas";
            botonmas.Location = new Point(0, 330);
            botonmas.Size = new Size(76, 169);
            botonmas.Click += new EventHandler(ClickPrendas);
            botonmas.MouseLeave += new EventHandler(Mouseleave);
            botonmas.MouseEnter += new EventHandler(Mouseover);
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
            combo.Text = "Selecione una Oferta";
            combo.Name = "cmbofertas";
            combo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            combo.Location = new Point(3, 520);
            combo.Size = new Size(274, 30);
            combo.MouseLeave += new EventHandler(MouseleaveCombo);
            combo.MouseEnter += new EventHandler(MouseoverCombo);
            this.Prueba.Controls.Add(combo);
            var ofertas =
         from a in db.Ofertas

         select new { Names = a.Descripcion };

            combo.DataSource = ofertas.ToList();
            combo.DisplayMember = "Names";

            var combodos = new ComboBox();
            combodos.Text = "Selecione Un afiliado";
            combodos.Name = "cmbafiliados";
            combodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           combodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            combodos.Location = new Point(3, 560);
            combodos.Size = new Size(274, 30);
            combodos.MouseLeave += new EventHandler(MouseleaveCombo);
            combodos.MouseEnter += new EventHandler(MouseoverCombo);
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
            botox1.Size = new Size(45, 40);
            botox1.Click += new EventHandler(ClickPrendas);
            botox1.MouseLeave += new EventHandler(Mouseleave);
            botox1.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botox1);

            var botonimagen = new Button();
            // botonmas.Text = "+";
            botonimagen.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\asterisco.png");

            botonimagen.Name = "asterisco1";
            botonimagen.Location = new Point(333, 520);
            botonimagen.Size = new Size(45, 40);
            botonimagen.Click += new EventHandler(ClickPrendas);
            botonimagen.MouseLeave += new EventHandler(Mouseleave);
            botonimagen.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonimagen);

            var botonimagendos = new Button();
            // botonmas.Text = "+";
            botonimagendos.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\asterisco.png");

            botonimagendos.Name = "asterisco2";
            botonimagendos.Location = new Point(333, 560);
            botonimagendos.Size = new Size(45, 40);
            botonimagendos.Click += new EventHandler(ClickPrendas);
            botonimagendos.MouseLeave += new EventHandler(Mouseleave);
            botonimagendos.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonimagendos);


            var botox2 = new Button();
            botox2.Text = "X";
            botox2.Name = "btnx2";
            botox2.Location = new Point(283, 560);
            botox2.Size = new Size(45, 40);
            botox2.Click += new EventHandler(ClickPrendas);
            botox2.MouseLeave += new EventHandler(Mouseleave);
            botox2.MouseEnter += new EventHandler(Mouseover);
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
            btnNuevoItem.Location = new System.Drawing.Point(277, 630);
            btnNuevoItem.Name = "btnNuevoItem";
            btnNuevoItem.Size = new System.Drawing.Size(106, 41);
            btnNuevoItem.TabIndex = 146;
            btnNuevoItem.Text = "Nuevo Item";
            btnNuevoItem.UseVisualStyleBackColor = false;
            btnNuevoItem.Click += new System.EventHandler(ClickAtrasPrendasInicio);
            btnNuevoItem.MouseLeave += new EventHandler(Mouseleave);
            btnNuevoItem.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(btnNuevoItem);


            var btnAtras = new Button();
            btnAtras.BackColor = System.Drawing.Color.WhiteSmoke;
            btnAtras.ForeColor = System.Drawing.Color.Black;
            btnAtras.Location = new System.Drawing.Point(49, 630);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new System.Drawing.Size(106, 41);
            btnAtras.TabIndex = 145;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = false;
            btnAtras.Click += new System.EventHandler(ClickAtrasprueba);
            btnAtras.MouseLeave += new EventHandler(Mouseleave);
            btnAtras.MouseEnter += new EventHandler(Mouseover);
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
            btnEnviar.Location = new System.Drawing.Point(1143, 821);
            btnEnviar.Name = "btnEnviardos";
            btnEnviar.Size = new System.Drawing.Size(200, 44);
            btnEnviar.TabIndex = 74;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += new System.EventHandler(btnEnviar_Click);
            this.Controls.Add(btnEnviar);


            var pruebados = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().Precio;





            var Resultado = int.Parse(pruebados) * dato;

            this.txtPrecioTotal.Text = Resultado.ToString();
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
            frmPin pin = new frmPin();
            pin.ShowDialog();

            if (ClienteId == 0) { 
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
            cliente.Fecha = DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss");
            cliente.EmpleadoInserta = Program.Pin;
            


            db.Clientes.Add(cliente);
            db.SaveChanges();
            }
           
            
           

            Ordenes orden = new Ordenes();
            orden.NumeroOrden = "A";
            orden.FechaIngreso = DateTime.Now.ToString("dd/MM/yyyy");
            orden.HoraIngreso= DateTime.Now.ToString("HH:mm:ss");
            orden.HoraSalida =DateTime.Now.ToString("HH:mm:ss");
            orden.TotalOrden = this.txtPrecioTotal.Text;
            orden.EmpleadoRealizo = Program.Pin;
            if (ClienteId == 0) { 
            orden.NombreCliente = txtNombre.Text;
            }else
            {
                var pruebados = db.Clientes.Find(ClienteId).Nombre;
                orden.NombreCliente = pruebados;
            }
            orden.CantidadPagada= this.txtPrecioTotal.Text;
            db.Ordenes.Add(orden);
            db.SaveChanges();
            this.Close();
            frmPrincipal principal = new frmPrincipal();
            principal.Opacity = 1;
            principal.Show();
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
                botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Location = new Point(x, y);
                botones.Size = new Size(100, 100);
                botones.Click += new EventHandler(ClickServicios);
                botones.MouseLeave += new EventHandler(Mouseleave);
                botones.MouseEnter += new EventHandler(Mouseover);
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
                botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Name = item.TareaId.ToString();
                botones.Location = new Point(x, y);
                botones.Size = new Size(100, 100);
                botones.Click += new EventHandler(ClickTareaS);
                botones.MouseLeave += new EventHandler(Mouseleave);
                botones.MouseEnter += new EventHandler(Mouseover);
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
                botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                botones.Location = new Point(x, y);
                botones.Size = new Size(100, 100);
                botones.Click += new EventHandler(ClickDetalletareas);
                botones.MouseLeave += new EventHandler(Mouseleave);
                botones.MouseEnter += new EventHandler(Mouseover);
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
                    botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                    botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    botones.Size = new Size(100, 100);
                    botones.Click += new EventHandler(ClickPrendas);
                    botones.MouseLeave += new EventHandler(Mouseleave);
                    botones.MouseEnter += new EventHandler(Mouseover);
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
                    botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                    botones.Name = item.PrendaId.ToString();
                    botones.Location = new Point(x, y);
                    botones.Size = new Size(100, 100);
                    botones.Click += new EventHandler(ClickPrendas);
                    botones.MouseLeave += new EventHandler(Mouseleave);
                    botones.MouseEnter += new EventHandler(Mouseover);
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
            frmPrincipal frm = new frmPrincipal();
            frm.Opacity = 1;
            frm.Show();
            
        }

        private void dvgOrdenes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dvgOrdenes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                //dvgOrdenes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OliveDrab;

                //dvgOrdenes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
             
              
            }
        }

        private void dvgOrdenes_MouseEnter(object sender, EventArgs e)
        {
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
            
            if (txtPrecioTotal.Text == "0")
            {
                return;
            }
            else
            {
                txtPrecioTotal.Text = txtPrecioTotal.Text + "0";
            }
        }



        private void btnpor_Click(object sender, EventArgs e)
        {

            Multiplicacion multiplicacion = new Multiplicacion();
         //   Multiplicacion multiplicacion = (Multiplicacion)Application.OpenForms["Multiplicacion"];
           
            multiplicacion.ShowDialog();
     //       multiplicacion.txtCantidadDos.Text = txtPrecioTotal.Text;


        }

        private void ClickResultado(object sender, EventArgs e)
        {
            
          //  txtPrecioTotal.Text = txtPrecioTotal.Text* txtdato.Text;
           // txtPrecioTotal.Visible = false;
        }
        private void btnretroceso_Click(object sender, EventArgs e)
        {
            x = txtPrecioTotal.Text.Length;
         
            if (txtPrecioTotal.Text.Substring(0, 0) != "0")
            {
                //en caso de que sea, lo quitamos
                txtPrecioTotal.Text = txtPrecioTotal.Text.Substring(0, txtPrecioTotal.Text.Length - 1);
            }


            if (x.ToString() == "1")
            {
                txtPrecioTotal.Text = "0";

            }
        }

         

private void dvgOrdenes_ColumnHeaderCellChanged(object sender, DataGridViewColumnEventArgs e)
        {

            //this.dvgOrdenes.BackColor = System.Drawing.Color.OliveDrab;
            //this.dvgOrdenes.ForeColor = System.Drawing.Color.White;
        }
        void ClickNuevaOrden(object sender, EventArgs e)
        {
            Form1 empleado = new Form1();

            empleado.ShowDialog();
            this.Close();

        }
        void ClickCerrarOrden(object sender, EventArgs e)
        {
            Form1 empleado = new Form1();

            empleado.ShowDialog();
            this.Close();

        }
        void ClickCantidad(object sender, EventArgs e)
        {
            frmCantidad empleado = new frmCantidad();
          
            this.Opacity = 0.85;
              label5.Text=empleado.txtCantidad.Text;
            empleado.ShowDialog();
           // this.Close();

        }

        //   List<string> lista = Panel.Controls.OfType<Label>().Select(x => x.Text).ToList();
        void Clickcincomas(object sender, EventArgs e)
        {
          

            var a = int.Parse(label5.Text);
            var b = a + 5;
            label5.Text = b.ToString();
         
        }
        void Clickcincomenos(object sender, EventArgs e)
        {

            var a = int.Parse(label5.Text);
            if (a <= 5)
            {
                label5.Text = "1";

            }
            if (a > 5)
            {
                var b = a - 5;
                label5.Text = b.ToString();
            }

        }
        void Clickunomas(object sender, EventArgs e)
        {
           
            var a = int.Parse(label5.Text);
            var b = a + 1;
            label5.Text = b.ToString();

        }
        void Clickunomenos(object sender, EventArgs e)
        {
            
            var a = int.Parse(label5.Text);
            if (a > 1)
            {
                var b = a - 1;
                label5.Text = b.ToString();
            }

        }
        void ClickBorrartax(object sender, EventArgs e)
        {

            var totalbotones = Prueba.Controls.Count;
            var litdos = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < totalbotones; i++)
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
                botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                botones.Size = new Size(100, 100);
                botones.Click += new EventHandler(ClickPrendas);
                botones.MouseLeave += new EventHandler(Mouseleave);
                botones.MouseEnter += new EventHandler(Mouseover);
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

            Button btr = sender as Button;


            object id = btr.Name;


      
            var total = panel3.Controls.Count;
            var totaldos = total;
            
        
            if (totaldos == 3&&m<=0) { 
            var lit = panel3.Controls.OfType<Button>();
            for (int i = 0; i < total; i++)
            {
                panel3.Controls.Remove(panel3.Controls[0]);
            }
            Form1 form = new Form1();
            form.ShowDialog();
            }

          
            if (totaldos == 4&&m==0)
            {

                for (int i = total; i <= total; i++)
                {
                    panel3.Controls.Remove(panel3.Controls[total-1]);
                }
           
             
                DAtoYdos = DAtoYdos - 90;
            }
            if (totaldos == 6 && m == 0)
            {


                panel3.Controls.Remove(panel3.Controls[5]);
                panel3.Controls.Remove(panel3.Controls[4]);
                m = m + 10;
            }
            if (totaldos == 6&&m<=0)
            {

                for (int i = total; i <= total; i++)
                {
                    panel3.Controls.Remove(panel3.Controls[total - 1]);
                }
              //  panel3.Controls.Remove(panel3.Controls[4]);
                   DAtoY = DAtoY-50;
                DAtoYdos = DAtoYdos-45;
            }
            if (totaldos == 8&&m<=0)
            {

                for (int i = total; i <= total; i++)
                {
                    panel3.Controls.Remove(panel3.Controls[total - 1]);
                }
              //  panel3.Controls.Remove(panel3.Controls[6]);
                DAtoY = DAtoY - 50;
                DAtoYdos = DAtoYdos - 45;
            }
            if (totaldos == 10&& m <= 0)
            {

                for (int i = total; i <= total; i++)
                {
                    panel3.Controls.Remove(panel3.Controls[total - 1]);
                }
             //   panel3.Controls.Remove(panel3.Controls[8]);
                DAtoY = DAtoY - 50;
                DAtoYdos = DAtoYdos - 45;
            }
            if (totaldos == 12&&m <= 0)
            {

                for (int i = total; i <= total; i++)
                {
                    panel3.Controls.Remove(panel3.Controls[total - 1]);
                }
             //   panel3.Controls.Remove(panel3.Controls[10]);
                DAtoY = DAtoY - 50;
                DAtoYdos = DAtoYdos - 45;
            }
         //   totaldos = totaldos - 1;

            if (totaldos == 5 && m == 0)
            {
             
              
                 panel3.Controls.Remove(panel3.Controls[4]);
                 panel3.Controls.Remove(panel3.Controls[3]);
                DAtoY = DAtoY - 45;
                DAtoYdos = DAtoYdos - 50;
            }
            //if (totaldos == 4 && m == 2)
            //{


            //    panel3.Controls.Remove(panel3.Controls[3]);
            //    panel3.Controls.Remove(panel3.Controls[2]);
            //    DAtoY = DAtoY - 45;
            //    DAtoYdos = DAtoYdos - 50;
            //  //  m = m - 3;
            //}
            if (totaldos == 7 && m<=0)
            {
             

                panel3.Controls.Remove(panel3.Controls[6]);
                panel3.Controls.Remove(panel3.Controls[5]);
                DAtoY = DAtoY - 45;
                DAtoYdos = DAtoYdos - 50;
                
            }

            if ( totaldos == 7 && m == 2)
            {


                panel3.Controls.Remove(panel3.Controls[6]);
                panel3.Controls.Remove(panel3.Controls[5]);
                DAtoY = DAtoY - 45;
                DAtoYdos = DAtoYdos - 50;
                m = m - 3;
            }

            if (totaldos == 9 && m <= 0)
            {


                panel3.Controls.Remove(panel3.Controls[8]);
                panel3.Controls.Remove(panel3.Controls[7]);
                DAtoY = DAtoY - 45;
                DAtoYdos = DAtoYdos - 50;
            }
            if (totaldos == 11 && m <= 0)
            {


                panel3.Controls.Remove(panel3.Controls[10]);
                panel3.Controls.Remove(panel3.Controls[9]);
                DAtoY = DAtoY - 45;
                DAtoYdos = DAtoYdos - 50;
            }
            if (totaldos == 13 && m <= 0)
            {


                panel3.Controls.Remove(panel3.Controls[12]);
                panel3.Controls.Remove(panel3.Controls[11]);
                DAtoY = DAtoY - 45;
                DAtoYdos = DAtoYdos - 50;
            }
        
                if (int.Parse(m.ToString()) ==2)
                {
                    for (int i = total; i <= total; i++)
                    {
                        panel3.Controls.Remove(panel3.Controls[total - 1]);
                    }

                    //    totaldos=totaldos - 1;

                    DAtoYdos = DAtoYdos - 90;
                }
            if (m == 10)
            {
                this.m = 2;
            }
            
            if (int.Parse(m.ToString()) == 1)
            {
                for (int i = total; i <= total; i++)
                {
                    panel3.Controls.Remove(panel3.Controls[total - 1]);
                }


                // this.m = m - 1;
                DAtoYdos = DAtoYdos - 90;
            }
            if (int.Parse(m.ToString()) == 3)
            {
                for (int i = total; i <= total; i++)
                {
                    panel3.Controls.Remove(panel3.Controls[total - 1]);
                }


                // this.m = m - 1;
                DAtoYdos = DAtoYdos - 90;
            }
            if (int.Parse(m.ToString()) == 4)
            {
                for (int i = total; i <= total; i++)
                {
                    panel3.Controls.Remove(panel3.Controls[total - 1]);
                }


                // this.m = m - 1;
                DAtoYdos = DAtoYdos - 90;
            }
            if (int.Parse(m.ToString()) == 5)
            {
                for (int i = total; i <= total; i++)
                {
                    panel3.Controls.Remove(panel3.Controls[total - 1]);
                }


                // this.m = m - 1;
                DAtoYdos = DAtoYdos - 90;
            }

            if (m > 0)
            {
                this.m = m - 1;
            }
           else
                if (m<0)
                {
                    this.m = 2;

                }
           
            
        }


        private void Clonar(object src, object tgt)
        {
            PropertyInfo[] props = src.GetType().GetProperties();
            foreach (PropertyInfo pi in props)
            {
                if (pi.CanWrite)
                    pi.SetValue(tgt, pi.GetValue(src, null), null);
            }
        }
        void ClickDuplicar(object sender, EventArgs e)
        {
             var totalbotones = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < totalbotones; i++)
            {
                Prueba.Controls.Remove(Prueba.Controls[0]);
            }

            mostrarcontrolesDos();
            Button btr = sender as Button;

            object iddos = btr.Name;
            var asdfa = btr.Name;

        
        var total = panel3.Controls.Count;
            if (total == 3) { 
            this.Datox = 0;
                this.DAtoY = 0;
                this.DAtoYdos = 50;
            }
            if (total == 5)
            {
                this.Datox = 0;
                this.DAtoY =95;
                this.DAtoYdos = 145;
            }
            if (total == 7)
            {
                this.Datox = 0;
                this.DAtoY = 190;
                this.DAtoYdos = 240;
            }
            if (total == 9)
            {
                this.Datox = 0;
                this.DAtoY = 218;
                this.DAtoYdos = 268;
            }
            if (total == 11)
            {
                this.Datox = 0;
                this.DAtoY = 218;
                this.DAtoYdos = 268;
            }

            if (m==1) {

               // var d = Datox;
                DAtoY = DAtoY + 95+45;
               // var f = DAtoY;
                DAtoYdos = DAtoYdos + 95;
              //  var o = DAtoYdos;
            }
            if (m == 2)
            {

                // var d = Datox;
                DAtoY = DAtoY + 90;
                // var f = DAtoY;
                DAtoYdos = DAtoYdos + 90;
                //  var o = DAtoYdos;
            }
            if(m==0)
            {

               // var d = Datox;
                DAtoY = DAtoY + 95;
              //  var f = DAtoY;
                DAtoYdos = DAtoYdos + 95;
             //   var o = DAtoYdos;
            }

           

         
            Button btn = sender as Button;
            var id = int.Parse(btn.Name);
            prenda = db.Prendas.Find(id);
            var dato = db.Prendas.Where(u => u.PrendaId == id).ToList();

            Panel Table = new Panel();
            Table.AutoScroll = true;
            Table.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Table.Location = new Point(Datox, DAtoY);
            Table.Size = new Size(897, 50);
            Table.BackColor = Color.DarkGray;

            Table.Name = "DatosPrendas";


            foreach (var item in dato)
            {

                var botonesdos = new Label();
                botonesdos.Size = new System.Drawing.Size(70, 45);
                botonesdos.Location = new Point(0, 0);

                botonesdos.Text = item.TipoRopa + " " + "X"+label5.Text;
                botonesdos.Name = item.TipoRopa;



                var Prioridad = new Button();


                Prioridad.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\primera.png");

                Prioridad.BackColor = System.Drawing.Color.DarkGray;
                Prioridad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                Prioridad.Location = new Point(634, 6);
                Prioridad.FlatAppearance.BorderSize = 0;
                Prioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                Prioridad.Size = new System.Drawing.Size(32, 34);
                Prioridad.TabIndex = 142;
                Prioridad.UseVisualStyleBackColor = false;


                Prioridad.Name = item.PrendaId.ToString();
                Prioridad.Click += new EventHandler(ClickNuevaOrden);

                var Duplicar = new Button();

                Duplicar.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\duplicar.png");

                Duplicar.BackColor = System.Drawing.Color.DarkGray;
                Duplicar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                Duplicar.FlatAppearance.BorderSize = 0;
                Duplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                Duplicar.Location = new Point(666, 6);
                Duplicar.Size = new System.Drawing.Size(32, 34);
                Duplicar.TabIndex = 142;
                Duplicar.UseVisualStyleBackColor = false;
                Duplicar.Click += new EventHandler(ClickDuplicar);

                Duplicar.Name = item.PrendaId.ToString();

                var cantidad = new Button();


                cantidad.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\qrd.png");

                cantidad.BackColor = System.Drawing.Color.DarkGray;
                cantidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                cantidad.FlatAppearance.BorderSize = 0;
                cantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                cantidad.Location = new Point(698, 6);
                cantidad.Size = new System.Drawing.Size(32, 34);
                cantidad.TabIndex = 142;
                cantidad.Click += new EventHandler(ClickCantidad);
                
                cantidad.UseVisualStyleBackColor = false;


                cantidad.Name = item.PrendaId.ToString();

                var mascinco = new Button();


                mascinco.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\cincomas.png");

                mascinco.BackColor = System.Drawing.Color.DarkGray;
                mascinco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                mascinco.FlatAppearance.BorderSize = 0;
                mascinco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                mascinco.Location = new Point(730, 6);
                mascinco.Size = new System.Drawing.Size(32, 34);
                mascinco.TabIndex = 142;
                mascinco.UseVisualStyleBackColor = false;
                mascinco.Click += new EventHandler(Clickcincomas);

                mascinco.Name = item.PrendaId.ToString();

                var masuno = new Button();


                masuno.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\unomas.png");

                masuno.BackColor = System.Drawing.Color.DarkGray;
                masuno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                masuno.FlatAppearance.BorderSize = 0;
                masuno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                masuno.Location = new Point(762, 6);
                masuno.Size = new System.Drawing.Size(32, 34);
                masuno.TabIndex = 142;
                masuno.UseVisualStyleBackColor = false;
                masuno.Click += new EventHandler(Clickunomas);

                masuno.Name = item.PrendaId.ToString();

                var menosuno = new Button();

                menosuno.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\unomenos.png");

                menosuno.BackColor = System.Drawing.Color.DarkGray;
                menosuno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                menosuno.FlatAppearance.BorderSize = 0;
                menosuno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                menosuno.Location = new Point(794, 6);
                menosuno.Size = new System.Drawing.Size(32, 34);
                menosuno.TabIndex = 142;
                menosuno.UseVisualStyleBackColor = false;
                menosuno.Click += new EventHandler(Clickunomenos);
                menosuno.Name = item.PrendaId.ToString();
                var menoscinco = new Button();

                menoscinco.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\cincomenos.png");

                menoscinco.BackColor = System.Drawing.Color.DarkGray;
                menoscinco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                menoscinco.FlatAppearance.BorderSize = 0;
                menoscinco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                menoscinco.Location = new Point(826, 6);
                menoscinco.Size = new System.Drawing.Size(32, 34);
                menoscinco.TabIndex = 142;
                menoscinco.UseVisualStyleBackColor = false;
                menoscinco.Click += new EventHandler(Clickcincomenos);

                menoscinco.Name = item.PrendaId.ToString();
                var agregartarea = new Button();

                agregartarea.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\taps.png");

                agregartarea.BackColor = System.Drawing.Color.DarkGray;
                agregartarea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                agregartarea.FlatAppearance.BorderSize = 0;
                agregartarea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                agregartarea.Location = new Point(858, 6);
                agregartarea.Size = new System.Drawing.Size(32, 34);
                agregartarea.TabIndex = 142;
                agregartarea.UseVisualStyleBackColor = false;
                agregartarea.Click += new EventHandler(ClickAddtax);
                agregartarea.Name = item.PrendaId.ToString();


                Table.Controls.Add(botonesdos);

                Table.Controls.Add(Prioridad);
                Table.Controls.Add(Duplicar);
                Table.Controls.Add(cantidad);
                Table.Controls.Add(mascinco);
                Table.Controls.Add(masuno);
                Table.Controls.Add(menosuno);
                Table.Controls.Add(menoscinco);
                Table.Controls.Add(agregartarea);



            }


            Panel TableDos = new Panel();

            TableDos.Location = new Point(Datox, DAtoYdos);
            TableDos.Size = new Size(897, 45);
            TableDos.BackColor = Color.White;
            TableDos.MouseLeave += new EventHandler(Mouseleavetabla);
            TableDos.MouseEnter += new EventHandler(Mouseovertabla);

            TableDos.Name = "DatosPrendasDos";



            var prueba = prenda.Tareas.FirstOrDefault().NombreTareas;
            var pruebadostres = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleTareas;
            var pruebados = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().Precio;

            var labeltarea = new Label();
            labeltarea.Size = new System.Drawing.Size(70, 34);
            labeltarea.Location = new Point(0, 10);

            labeltarea.Text = prueba;
            labeltarea.Name = prueba;

            var labeldetalle = new Label();
            labeldetalle.Size = new System.Drawing.Size(50, 34);
            labeldetalle.Location = new Point(132, 10);
            labeldetalle.Text = pruebadostres;
            labeldetalle.Name = pruebadostres;

            var labelprecio = new Label();
            labelprecio.Size = new System.Drawing.Size(50, 34);
            labelprecio.Location = new Point(182, 10);
            labelprecio.Text = pruebados;
            labelprecio.Name = pruebados;




            var agregartareados = new Button();

            agregartareados.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\equis.png");

            agregartareados.BackColor = System.Drawing.Color.White;
            agregartareados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            agregartareados.FlatAppearance.BorderSize = 0;
            agregartareados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            agregartareados.Location = new Point(860, 6);
            agregartareados.Size = new System.Drawing.Size(32, 34);
            agregartareados.TabIndex = 142;
            agregartareados.UseVisualStyleBackColor = false;
            agregartareados.Click += new EventHandler(ClickBorrartax);

       


            TableDos.Controls.Add(labeltarea);
            TableDos.Controls.Add(labeldetalle);
            TableDos.Controls.Add(labelprecio);
            TableDos.Controls.Add(agregartareados);

            this.panel3.Controls.Add(Table);
            this.panel3.Controls.Add(TableDos);
            if (m == 1)
            {
                var dtres = Datox;
                DAtoY = DAtoY;
                var ftres = DAtoY;
                DAtoYdos = DAtoYdos  + 45;
                var otres = DAtoYdos;

                Panel Tabletres = new Panel();

                Tabletres.Location = new Point(dtres, otres);
                Tabletres.Size = new Size(897, 45);
                Tabletres.BackColor = Color.White;
                Tabletres.MouseLeave += new EventHandler(Mouseleavetabla);
                Tabletres.MouseEnter += new EventHandler(Mouseovertabla);

                Tabletres.Name = "DatosPrendasDos";



                var pruebatres = prenda.Tareas.FirstOrDefault().NombreTareas;
                var pruebadostres2 = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleTareas;
                var pruebados2 = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().Precio;

                var labeltareatres = new Label();
                labeltareatres.Size = new System.Drawing.Size(70, 34);
                labeltareatres.Location = new Point(0, 10);

                labeltareatres.Text = pruebatres;
                labeltareatres.Name = pruebatres;

                var labeldetalletres = new Label();
                labeldetalletres.Size = new System.Drawing.Size(50, 34);
                labeldetalletres.Location = new Point(132, 10);
                labeldetalletres.Text = pruebadostres2;
                labeldetalletres.Name = pruebadostres2;

                var labelpreciotres = new Label();
                labelpreciotres.Size = new System.Drawing.Size(50, 34);
                labelpreciotres.Location = new Point(182, 10);
                labelpreciotres.Text = pruebados2;
                labelpreciotres.Name = pruebados2;




                var agregartareadostres = new Button();

                agregartareadostres.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\equis.png");

                agregartareadostres.BackColor = System.Drawing.Color.White;
                agregartareadostres.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                agregartareadostres.FlatAppearance.BorderSize = 0;
                agregartareadostres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                agregartareadostres.Location = new Point(860, 6);
                agregartareadostres.Size = new System.Drawing.Size(32, 34);
                agregartareadostres.TabIndex = 142;
                agregartareadostres.UseVisualStyleBackColor = false;
                agregartareadostres.Click += new EventHandler(ClickBorrartax);




                Tabletres.Controls.Add(labeltareatres);
                Tabletres.Controls.Add(labeldetalletres);
                Tabletres.Controls.Add(labelpreciotres);
                Tabletres.Controls.Add(agregartareadostres);
                
                this.panel3.Controls.Add(Tabletres);
             //   m = m + 1;
            }else
            if (m == 2)
            {
                var dtres = Datox;
                DAtoY = DAtoY + 40;
                var ftres = DAtoY;
                DAtoYdos = DAtoYdos + 45;
                var otres = DAtoYdos;

                Panel Tabletres = new Panel();

                Tabletres.Location = new Point(dtres, otres);
                Tabletres.Size = new Size(897, 45);
                Tabletres.BackColor = Color.White;
                Tabletres.MouseLeave += new EventHandler(Mouseleavetabla);
                Tabletres.MouseEnter += new EventHandler(Mouseovertabla);

                Tabletres.Name = "DatosPrendasDos";



                var pruebatres = prenda.Tareas.FirstOrDefault().NombreTareas;
                var pruebadostres2 = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleTareas;
                var pruebados2 = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().Precio;

                var labeltareatres = new Label();
                labeltareatres.Size = new System.Drawing.Size(70, 34);
                labeltareatres.Location = new Point(0, 10);

                labeltareatres.Text = pruebatres;
                labeltareatres.Name = pruebatres;

                var labeldetalletres = new Label();
                labeldetalletres.Size = new System.Drawing.Size(50, 34);
                labeldetalletres.Location = new Point(132, 10);
                labeldetalletres.Text = pruebadostres2;
                labeldetalletres.Name = pruebadostres2;

                var labelpreciotres = new Label();
                labelpreciotres.Size = new System.Drawing.Size(50, 34);
                labelpreciotres.Location = new Point(182, 10);
                labelpreciotres.Text = pruebados2;
                labelpreciotres.Name = pruebados2;




                var agregartareadostres = new Button();

                agregartareadostres.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\equis.png");

                agregartareadostres.BackColor = System.Drawing.Color.White;
                agregartareadostres.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                agregartareadostres.FlatAppearance.BorderSize = 0;
                agregartareadostres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                agregartareadostres.Location = new Point(860, 6);
                agregartareadostres.Size = new System.Drawing.Size(32, 34);
                agregartareadostres.TabIndex = 142;
                agregartareadostres.UseVisualStyleBackColor = false;
                agregartareadostres.Click += new EventHandler(ClickBorrartax);




                Tabletres.Controls.Add(labeltareatres);
                Tabletres.Controls.Add(labeldetalletres);
                Tabletres.Controls.Add(labelpreciotres);
                Tabletres.Controls.Add(agregartareadostres);


                Panel Tablecuatro = new Panel();

                Tablecuatro.Location = new Point(dtres, otres+45);
                Tablecuatro.Size = new Size(897, 45);
                Tablecuatro.BackColor = Color.White;
                Tablecuatro.MouseLeave += new EventHandler(Mouseleavetabla);
                Tablecuatro.MouseEnter += new EventHandler(Mouseovertabla);

                Tablecuatro.Name = "DatosPrendasDos";



                var pruebacuatro = prenda.Tareas.FirstOrDefault().NombreTareas;
                var pruebadoscuatro = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleTareas;
                var pruebadoscuatros = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().Precio;

                var labeltareacuatro = new Label();
                labeltareacuatro.Size = new System.Drawing.Size(70, 34);
                labeltareacuatro.Location = new Point(0, 10);

                labeltareacuatro.Text = pruebacuatro;
                labeltareacuatro.Name = pruebacuatro;

                var labeldetallecuatro = new Label();
                labeldetallecuatro.Size = new System.Drawing.Size(50, 34);
                labeldetallecuatro.Location = new Point(132, 10);
                labeldetallecuatro.Text = pruebadoscuatro;
                labeldetallecuatro.Name = pruebadoscuatro;

                var labelpreciocuatro = new Label();
                labelpreciocuatro.Size = new System.Drawing.Size(50, 34);
                labelpreciocuatro.Location = new Point(182, 10);
                labelpreciocuatro.Text = pruebadoscuatros;
                labelpreciocuatro.Name = pruebadoscuatros;




                var agregartareadoscuatro = new Button();

                agregartareadoscuatro.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\equis.png");

                agregartareadoscuatro.BackColor = System.Drawing.Color.White;
                agregartareadoscuatro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                agregartareadoscuatro.FlatAppearance.BorderSize = 0;
                agregartareadoscuatro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                agregartareadoscuatro.Location = new Point(860, 6);
                agregartareadoscuatro.Size = new System.Drawing.Size(32, 34);
                agregartareadoscuatro.TabIndex = 142;
                agregartareadoscuatro.UseVisualStyleBackColor = false;
                agregartareadoscuatro.Click += new EventHandler(ClickBorrartax);




                Tablecuatro.Controls.Add(labeltareacuatro);
                Tablecuatro.Controls.Add(labeldetallecuatro);
                Tablecuatro.Controls.Add(labelpreciocuatro);
                Tablecuatro.Controls.Add(agregartareadoscuatro);

                this.panel3.Controls.Add(Tabletres);
                this.panel3.Controls.Add(Tablecuatro);
                m = m + 2;
            }
        }
        void ClickAddtax(object sender, EventArgs e)
        {
            var total = panel3.Controls.Count;
            if (m<=0)
            {
                this.m = 0;
            }
           
            m = m + 1;
            if (total == 3)
            {
                this.Datox = 0;
                this.DAtoY = 0;
                this.DAtoYdos = 50;
            }

           
            var l = e;
            var d = Datox;
         
            DAtoYdos = DAtoYdos + 45;
            var o = DAtoYdos;

            Panel TableDos = new Panel();

            TableDos.Location = new Point(d, o);
            TableDos.Size = new Size(897, 45);
            TableDos.BackColor = Color.White;
            TableDos.MouseLeave += new EventHandler(Mouseleavetabla);
            TableDos.MouseEnter += new EventHandler(Mouseovertabla);

            TableDos.Name = m.ToString();



            var prueba = prenda.Tareas.FirstOrDefault().NombreTareas;
            var pruebadostres = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleTareas;
            var pruebados = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().Precio;

            var labeltarea = new Label();
            labeltarea.Size = new System.Drawing.Size(70, 34);
            labeltarea.Location = new Point(0, 10);

            labeltarea.Text = prueba;
            labeltarea.Name = prueba;

            var labeldetalle = new Label();
            labeldetalle.Size = new System.Drawing.Size(50, 34);
            labeldetalle.Location = new Point(132, 10);
            labeldetalle.Text = pruebadostres;
            labeldetalle.Name = pruebadostres;

            var labelprecio = new Label();
            labelprecio.Size = new System.Drawing.Size(50, 34);
            labelprecio.Location = new Point(182, 10);
            labelprecio.Text = pruebados;
            labelprecio.Name = pruebados;




            var agregartareados = new Button();

            agregartareados.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\equis.png");

            agregartareados.BackColor = System.Drawing.Color.White;
            agregartareados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            agregartareados.FlatAppearance.BorderSize = 0;
            agregartareados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            agregartareados.Location = new Point(860, 6);
            agregartareados.Size = new System.Drawing.Size(32, 34);
            agregartareados.TabIndex = 142;
            agregartareados.UseVisualStyleBackColor = false;
            agregartareados.Click += new EventHandler(ClickBorrartax);

            agregartareados.Name = "DatosPrendasDos";


            TableDos.Controls.Add(labeltarea);
            TableDos.Controls.Add(labeldetalle);
            TableDos.Controls.Add(labelprecio);
            TableDos.Controls.Add(agregartareados);

           
            this.panel3.Controls.Add(TableDos);

        }
        private void dvgOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(e.ColumnIndex.ToString());

            if (e.ColumnIndex == 26)
            {

                Form1 empleado = new Form1();
        
                empleado.ShowDialog();
                this.Close();

          

            }
            else if (e.ColumnIndex == 7)

            {
                frmEmpleado empleado = new frmEmpleado();
                empleado.ShowDialog();

            }
            else if (e.ColumnIndex == 21)

            {
                //this.label5.ForeColor = Color.White;
                //this.label5.BackColor = Color.OliveDrab;
                //var a = int.Parse(label5.Text);
                //var b = a + 5;
                //label5.Text=b.ToString();
            }
            else if (e.ColumnIndex == 22)

            {
                //this.label5.ForeColor = Color.White;
                //this.label5.BackColor = Color.OliveDrab;
                //var a = int.Parse(label5.Text);
                //var b = a + 1;
                //label5.Text = b.ToString();
            }
            else if (e.ColumnIndex == 23)

            {
                //this.label5.ForeColor = Color.White;
                //this.label5.BackColor = Color.OliveDrab;
                //var a = int.Parse(label5.Text);
                //if (a > 1)
                //{
                //    var b = a - 1;
                //    label5.Text = b.ToString();
                //}
            }
            else if (e.ColumnIndex == 24)

            {
            //    this.label5.ForeColor = Color.White;
            //    this.label5.BackColor = Color.OliveDrab;
            //    var a = int.Parse(label5.Text);
            //    if (a <= 5)
            //    {
            //        label5.Text ="1";

            //    }
            //    if (a > 5) {
            //        var b = a - 5;
            //        label5.Text = b.ToString();
             //  }
                
            }
            else if (e.ColumnIndex == 25)

            {
                //  frmEmpleado empleado = new frmEmpleado();
                //  empleado.ShowDialog();
                //this.label5.BackColor = Color.OliveDrab;
                //this.label5.ForeColor = Color.White;
     
            }

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //  int valor = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            if (e.RowIndex >= 0) {
            // dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].DataGridView.DefaultCellStyle.BackColor = Color.OliveDrab;
          }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //dataGridView1.DefaultCellStyle.BackColor = Color.Gray;
            }
        }

        private void dvgOrdenes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //dvgOrdenes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;

                //dvgOrdenes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
              
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txttelefonoprincipal_Enter(object sender, EventArgs e)
        {
            this.txttelefonoprincipal.Text = "";
        }

        private void txttelefonoprincipal_Leave(object sender, EventArgs e)
        {
        //    this.txttelefonoprincipal.Text = "Teléfono Cliente ";
        }

        private void txttelefonodos_Enter(object sender, EventArgs e)
        {
            this.txttelefonodos.Text = "";
        }

        private void txttelefonodos_Leave(object sender, EventArgs e)
        {
        //    this.txttelefonodos.Text = "Teléfono 2";
        }

        private void txttelefonotres_Enter(object sender, EventArgs e)
        {
            this.txttelefonotres.Text = "";
        }

        private void txttelefonotres_Leave(object sender, EventArgs e)
        {
         //   this.txttelefonotres.Text = "Teléfono 3";
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
         //   this.txtNombre.Text = "Nombre Cliente";
        }

        private void txtCalle_Enter(object sender, EventArgs e)
        {
            this.txtCalle.Text = "";
        }

        private void txtCalle_Leave(object sender, EventArgs e)
        {
         //   this.txtCalle.Text = "Calle";
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            this.txtEmail.Text = "";
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
          //  this.txtEmail.Text = "Correo Cliente";
        }

        private void txtCiudad_Enter(object sender, EventArgs e)
        {
            this.txtCiudad.Text = "";
        }

        private void txtCiudad_Leave(object sender, EventArgs e)
        {
          //  this.txtCiudad.Text = "Ciudad";
        }

        private void txtNotas_Enter(object sender, EventArgs e)
        {
            this.txtNotas.Text = "";
        }

        private void txtNotas_Leave(object sender, EventArgs e)
        {
         //   this.txtNotas.Text = "Notas";
        }

        private void txtCodigoPostal_Enter(object sender, EventArgs e)
        {
            this.txtCodigoPostal.Text = "";
        }

        private void txtCodigoPostal_Leave(object sender, EventArgs e)
        {
          //  this.txtCodigoPostal.Text = "Codigo Postal";
        }
    }
    }

