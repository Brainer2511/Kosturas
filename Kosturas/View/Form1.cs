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
using Kosturas.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using BarcodeLib;

namespace Kosturas.View
{
    public partial class Form1 : Form
    {
        DataContextLocal db = new DataContextLocal();
        public Prenda prenda = new Prenda();
        public Tarea tarea = new Tarea();
        public Ofertas oferta = new Ofertas();
        public DetalleTarea detalle = new DetalleTarea();
        public Servicios servicio = new Servicios();
        public List<OrdenDetalleViewModel> listaTareas = new List<OrdenDetalleViewModel>();
        public List<OrdenPrendaViewModel> listaPrendas = new List<OrdenPrendaViewModel>();
        Color ColorEntrada;
        int IdOrden = 0;
        public System.Windows.Forms.Panel TableDos;
        public System.Windows.Forms.TextBox labelprecio;
        public System.Windows.Forms.Label labeldetalle;
        public System.Windows.Forms.Label labeltarea;
      
        public int ordenId;
        bool istarea;
        public Label lblprecioTarea = new Label();
        public Label lblCantidad = new Label();
        int cantidad = 1;
        public List<OrdenDetalleViewModel> listatareas = new List<OrdenDetalleViewModel>();
        public List<OrdenPrendaViewModel> listaprendas = new List<OrdenPrendaViewModel>();
        int rowCount = 0;
     
        public int? ClienteId { get; set; }
        public int OrdenId { get; set; }
        string Combo1 = "";
        string Combo2 = "";

      


        int m = 0;
        int Datox = 0;
        int DAtoY = 0;
        int DAtoYdos = 50;
        int paginas = 0;
        
     
        int pagina = 1;
       
        public int DAto;
        public object x { get; set; }
        private Cliente cliente = new Cliente();
        private Ordenes orden = new Ordenes();


        public Form1(int? clienteId, int? ordenId)
        {
            ClienteId = clienteId;
            if (ordenId != null) { OrdenId = ordenId.Value; }
           
                if (clienteId!=null){
                
                cliente = db.Clientes.Find(clienteId);
                }
            if (Program.Editar == 1)
            {
                ordenId= OrdenId;
                OrdenId = ordenId.Value;
                orden = db.Ordenes.Find(OrdenId);
                
                cliente = db.Clientes.Find(orden.ClienteId);
                ClienteId = cliente.ClienteId;
                
            }
        
            InitializeComponent();

        }
      
        private void Form1_Load(object sender, EventArgs e)
        {

          
           


        
            istarea = false;
            if (ClienteId == null) {
                var Orden = new Ordenes
                {
                    FeEnt = DateTime.Now,
                 
                    
                  };
            db.Ordenes.Add(Orden);
            db.SaveChanges();
                ordenId = Orden.OrdenId;


                CodigoBarras sucursal = new CodigoBarras();





                var Codigo = CodigoBarras(ordenId);
             

                sucursal.Imagen = (Codigo);
                sucursal.OrdenId = Orden.OrdenId;
                db.CodigoBarras.Add(sucursal);
                db.SaveChanges();

            }
            if (Program.Editar == 1)
            {
                if (ClienteId > 0)
                {
                    cargar();
                }
                cmbabreviatura.Enabled = false;
                txtNombre.Enabled =false;
                txtEmail.Enabled = false;
                txtCalle.Enabled = false;
                txtCiudad.Enabled = false;
                txttelefonoprincipal.Enabled = false;
                txtNotas.Enabled = false;
                txttelefonodos.Enabled = false;
                txttelefonotres.Enabled = false;
                txtCodigoPostal.Enabled = false;

                ClickCargarOrdenEditadas();
                ordenId = orden.OrdenId;

             
            }
            else
            if(ClienteId>0)
            {
                var Orden = new Ordenes
                {
                    FeEnt = DateTime.Now,
                    ClienteId = ClienteId


                };
                db.Ordenes.Add(Orden);
                db.SaveChanges();
                cmbabreviatura.Enabled = false;
                txtNombre.Enabled = false;
                txtEmail.Enabled = false;
                txtCalle.Enabled = false;
                txtCiudad.Enabled = false;
                txttelefonoprincipal.Enabled = false;
                txtNotas.Enabled = false;
                txttelefonodos.Enabled = false;
                txttelefonotres.Enabled = false;
                txtCodigoPostal.Enabled = false;
                ordenId = Orden.OrdenId;

                CodigoBarras sucursal = new CodigoBarras();





                var Codigo = CodigoBarras(ordenId);


                sucursal.Imagen = (Codigo);
                sucursal.OrdenId = ordenId;
                db.CodigoBarras.Add(sucursal);
                db.SaveChanges();
            }
            if (ClienteId > 0)
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

        public string CodigoBarras(int idOrden)
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            barcode.IncludeLabel = true;
            barcode.Encode(BarcodeLib.TYPE.CODE128, idOrden.ToString(), Color.Black, Color.White, 300, 50);

            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\CodigosBarras\"; // <---
            if (Directory.Exists(appPath) == false)                                              // <---
            {                                                                                    // <---
                Directory.CreateDirectory(appPath);                                              // <---
            }                                                                                    // <---

            appPath += idOrden.ToString()+".png";
            barcode.SaveImage(appPath, SaveTypes.PNG);
           
            return appPath;

        }
        void Mouseover(object sender, EventArgs e)
        {

        }
        void Mouseleave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;


        }
        void MouseoverCombo(object sender, EventArgs e)
        {
            ComboBox btr = sender as ComboBox;

            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;


        }
      
        void MouseleaveCombo(object sender, EventArgs e)
        {
            ComboBox btr = sender as ComboBox;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;


        }
        private void cargar()
        {
            txtNombre.Text = cliente.Nombre;
            txtEmail.Text = cliente.Email;
            txtCalle.Text = cliente.Calle;
            txtCiudad.Text = cliente.Ciudad;
            txttelefonoprincipal.Text = cliente.TelefonoPrincipal;
            txtNotas.Text = cliente.Notas;
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

            tbpDatos.RowCount = rowCount;
            Button btn = sender as Button;
                var id = int.Parse(btn.Name);
                prenda = db.Prendas.Find(id);

  


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
            btnAtras.Click += new System.EventHandler(ClickAtrasPrendas);
            btnAtras.MouseLeave += new EventHandler(Mouseleave);
            btn.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(btnAtras);

       
            var prueba = prenda.Tareas.FirstOrDefault().NombreTareas;
            var pruebadostres = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleTareaId;
            var pruebados = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().Precio;
            var pruebadost = prenda.Tareas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleTareas;
            CargarPanelGenerico(prenda.PrendaId, prueba, pruebadostres, pruebados);
                istarea = false;
                

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
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;

        }
        void Mouseleavetabla(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;

            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

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
            foreach (Control item in tbpDatos.Controls.OfType<Control>())
            {
                if (item.Name == "Ganazo")
                    tbpDatos.Controls.Remove(item);
                if (item.Name == "GAnazodos")
                    tbpDatos.Controls.Remove(item);
            }


            var pruebados = detalle.Precio;
            var pruebauno = tarea.NombreTareas;
            var label = detalle.DetalleTareaId;


            this.ClickCargarPAnel(prenda.PrendaId, pruebauno, label, pruebados);


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
        void SumatoriaPrecios()
        {
            using (var db = new DataContextLocal())
            {
                var Orden = db.Ordenes.Find(ordenId);

                txtPrecioTotal.Text = Orden.Prendas.SelectMany(q => q.DetalleTareas).Sum(q => q.Subtotal).ToString();

            }        }

        void ActualizacionPrecios()
        {
            var Orden = db.Ordenes.Find(ordenId);
            Orden.TotalOrden = double.Parse(txtPrecioTotal.Text);
            db.Entry(Orden).State = EntityState.Modified;
            db.SaveChanges();
        }
        void GuardarCambiosTarea()
        {
         
            using (var db=new DataContextLocal())
            {
                var ordenDetalleTarea = new TemDetallesOrdenes();
                var ultimaTarea = listatareas.Last();
                ultimaTarea.Precio = double.Parse(ultimaTarea.txtPrecio.Text);
                AutoMapper.Mapper.Map(listatareas.Last(), ordenDetalleTarea);
               
                try
                {
                    db.Entry(ordenDetalleTarea).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch(Exception ex) 
                {
                    
                }

               
                SumatoriaPrecios();
               
            }


        }
        void GuardarCambiosDescuentoTarea()
        {

            using (var Tem = new DataContextLocal())
            {
                var ordenDetalleTarea = new TemDetallesOrdenes();
                var ultimaTarea = listatareas.Last();
                ultimaTarea.Precio = double.Parse(ultimaTarea.txtPrecio.Text);
                AutoMapper.Mapper.Map(listatareas.Last(), ordenDetalleTarea);

                try
                {
                    Tem.Entry(ordenDetalleTarea).State = EntityState.Modified;
                    Tem.SaveChanges();
                }
                catch (Exception ex)
                {

                }


     

            }


        }

        void ClickAtrasPrendasInicio(object sender, EventArgs e)
        {
            GuardarCambiosTarea();
            
            DAtoY = DAtoY + 95;
            DAtoYdos = DAtoYdos + 95;

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
        void ClickAtrasPrendas(object sender, EventArgs e)
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


        }


        public void cliclBorrarPrecio(object sender, EventArgs e)
        {
            BorrarPrecio();
            GuardarCambiosTarea();
            //var precio = new Label();
            //precio.Text = detalle.Precio.ToString();
            //this.txtPrecioTotal.Text = "0";
            

        }
        private void btnEnviar_Click(object sender, EventArgs e)

        {
            GuardarCambiosTarea();
            ActualizacionPrecios();
            this.Close();
            if (Program.Editar == 1)
            {

                this.Opacity = 0.80;
                EnvioOrden envio = new EnvioOrden(ClienteId.Value, OrdenId);

                envio.ShowDialog();
                this.Opacity = 1;
                this.Show();
            } else
            if (ClienteId == null) {

             






                    if (txtEmail.Text.Trim() == "Correo Cliente")
                    {

                        txtEmail.Text = "";

                    }
                   
            if (txtNotas.Text.Trim() == "Notas")
                    {

                        txtNotas.Text = "";

                    }
                    
            if (txttelefonodos.Text.Trim() == "Teléfono 2")
                    {

                        txttelefonodos.Text = "";

                    }
                    
            if (txttelefonotres.Text.Trim() == "Telefono 3")
                    {

                        txttelefonotres.Text = "";

                    }
                    
            if (txtCalle.Text.Trim() == "Calle")
                    {

                        txtCalle.Text = "";

                    }
                   
            if (txtCodigoPostal.Text.Trim() == "Codigo Postal")
                    {

                        txtCodigoPostal.Text = "";

                    }
                    
            if (txtCiudad.Text.Trim() == "Ciudad")
                    {

                        txtCiudad.Text = "";

                    }

                    
                    {
                        Cliente cliente = new Cliente();
                        cliente.Nombre = txtNombre.Text;
                        cliente.Email = txtEmail.Text;
                        cliente.TelefonoPrincipal = txttelefonoprincipal.Text;
                        cliente.TelefonoDos = txttelefonodos.Text;
                        cliente.Telefonotres = txttelefonotres.Text;
                        cliente.Notas = txtNotas.Text;
                        cliente.Calle = txtCalle.Text;
                        cliente.Ciudad = txtCiudad.Text;
                        cliente.Codigopostal = txtCodigoPostal.Text;
                        if (cmbabreviatura.SelectedValue != null)
                        {
                            cliente.Abreviatura = cmbabreviatura.SelectedValue.ToString();
                        }
                        db.Clientes.Add(cliente);
                        db.SaveChanges();
                        var query = db.Clientes.ToList();
                        var ultimoIdCliente = query.LastOrDefault().ClienteId;

                        var querydos = db.Ordenes.ToList();
                        var ultimaIdOrden = querydos.LastOrDefault().OrdenId;

                        Ordenes orden = db.Ordenes.Find(ultimaIdOrden);

                        orden.ClienteId = ultimoIdCliente;


                        db.Entry(orden).State = EntityState.Modified;
                        db.SaveChanges();



                        EnvioOrden envio = new EnvioOrden(ultimoIdCliente, ultimaIdOrden);
                        this.Hide();
                        envio.ShowDialog();
                        this.Show();
                    }
                

            }else
     
            if(ClienteId>0)
            {
                var querydos = db.Ordenes.ToList();
                var ultimaIdOrden = querydos.LastOrDefault().OrdenId;








                this.Opacity = 0.80;
                EnvioOrden envio = new EnvioOrden(ClienteId.Value, ultimaIdOrden);

                envio.ShowDialog();
                this.Opacity = 1;
                this.Show();
            }

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

            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button29_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button34_MouseEnter(object sender, EventArgs e)
        {

            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button34_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button32_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button32_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button31_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button31_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button35_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button35_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button30_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button30_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button33_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button33_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void btnDatosExtra_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnDatosExtra_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button37_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button37_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void btnTelefonoDos_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnTelefonoDos_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void btnTelefonoPrincipal_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnTelefonoPrincipal_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void btnTelefonoTres_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnTelefonoTres_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void cmbabreviatura_MouseEnter(object sender, EventArgs e)
        {

            ComboBox btr = sender as ComboBox;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void cmbabreviatura_MouseLeave(object sender, EventArgs e)
        {
            ComboBox btr = sender as ComboBox;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void pv2_Click(object sender, EventArgs e)
        {
            var total = Prueba.Controls.Count;
            var lit = Prueba.Controls.OfType<Button>();

            if (pagina < paginas)
            {
                for (int i = 0; i < total; i++)
                {
                    Prueba.Controls.Remove(Prueba.Controls[0]);
                }
                pagina += 1;
                var skip = (pagina - 1) * 28;


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


                var prendas = db.Prendas.OrderBy(t => t.PrendaId).Take(28).Skip(skip).ToList();
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


        private void BorrarPrecio()
        {
            var ultimatarea = listatareas.Last();
            ultimatarea.txtPrecio.Text = "0";
            ultimatarea.Precio = 0;

            GuardarCambiosTarea();
        }
        private void EditarPrecio(string numero)
        {
           var ultimatarea= listatareas.Last();
            ultimatarea.txtPrecio.Text += numero;
            if (!string.IsNullOrEmpty(ultimatarea.txtPrecio.Text))
            {
                ultimatarea.Precio = double.Parse(ultimatarea.txtPrecio.Text); 
            }
            else
            {
                ultimatarea.Precio = 0;
            }
            lblprecioTarea.Text = ultimatarea.txtPrecio.Text;
            GuardarCambiosTarea();
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
            EditarPrecio("1");
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
            EditarPrecio("2");
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
            EditarPrecio("3");
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
            EditarPrecio("4");
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
            EditarPrecio("5");
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
            EditarPrecio("6");
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
            EditarPrecio("7");
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
            EditarPrecio("8");
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
            EditarPrecio("9");
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
            EditarPrecio("0");
        }



        private void btnpor_Click(object sender, EventArgs e)
        {

            Multiplicacion multiplicacion = new Multiplicacion();
            //   Multiplicacion multiplicacion = (Multiplicacion)Application.OpenForms["Multiplicacion"];

            multiplicacion.ShowDialog();
                   multiplicacion.txtCantidadDos.Text = txtPrecioTotal.Text;


        }

        private void ClickResultado(object sender, EventArgs e)
        {

            //  txtPrecioTotal.Text = txtPrecioTotal.Text* txtdato.Text;
            // txtPrecioTotal.Visible = false;
        }
        private void btnretroceso_Click(object sender, EventArgs e)
        {
            var ultimaTarea = listatareas.Last();

           int x =ultimaTarea.txtPrecio.Text.Length;

            if (x>0)
            {
                if (ultimaTarea.txtPrecio.Text != "0")
                {                 
                   ultimaTarea.txtPrecio.Text = ultimaTarea.txtPrecio.Text.Substring(0,x-1);
                }


                if (x.ToString() == "1")
                {
                   ultimaTarea.txtPrecio.Text = "0";

                } 
            }
            GuardarCambiosTarea();
        }



        private void dvgOrdenes_ColumnHeaderCellChanged(object sender, DataGridViewColumnEventArgs e)
        {

            //this.dvgOrdenes.BackColor = System.Drawing.Color.OliveDrab;
            //this.dvgOrdenes.ForeColor = System.Drawing.Color.White;
        }
        void ClickNuevaOrden(object sender, EventArgs e)
        {
            Form1 empleado = new Form1(null,null);
            this.Opacity = 0.99;
            empleado.ShowDialog();
            this.Show();
            EnvioOrden envio = new EnvioOrden(ClienteId.Value);
            this.Hide();
            envio.ShowDialog();
            this.Show();
        }
        void ClickCerrarOrden(object sender, EventArgs e)
        {
            Form1 empleado = new Form1(null,null);

            empleado.ShowDialog();
            this.Close();

        }
        void ClickCantidad(object sender, EventArgs e)
        {
            frmCantidad empleado = new frmCantidad();

            this.Opacity = 0.85;
            Button btn = sender as Button;
            var id = int.Parse(btn.Text);
            var prendaView = listaprendas.Where(m => m.DetalleOrdenPrendaId == id).FirstOrDefault();
          
            empleado.ShowDialog();
            prendaView.Cantidad = int.Parse(empleado.txtCantidad.Text);
            var prenda = db.Prendas.Find(prendaView.PrendaId);
            prendaView.lblPrenda.Text = prenda.TipoRopa + "X" + prendaView.Cantidad;
            
            

        }

       
        void Clickcincomas(object sender, EventArgs e)
        {

          

            Button btn = sender as Button;
            var id = int.Parse(btn.Text);
            var prendaView = listaprendas.Where(m => m.DetalleOrdenPrendaId == id).FirstOrDefault();
            prendaView.Cantidad += 5;
            var prenda = db.Prendas.Find(prendaView.PrendaId);
            prendaView.lblPrenda.Text = prenda.TipoRopa + "X" + prendaView.Cantidad;

            var ordenDetallePrenda = db.OrdenDetallePrendas.Find(prendaView.DetalleOrdenPrendaId);
            ordenDetallePrenda.Cantidad += 5;
            db.Entry(ordenDetallePrenda).State=EntityState.Modified;
            db.SaveChanges();
            SumatoriaPrecios();

        }
        void Clickcincomenos(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            var id = int.Parse(btn.Text);
            var prendaView = listaprendas.Where(m => m.DetalleOrdenPrendaId == id).FirstOrDefault();
           
          
          
               if (prendaView.Cantidad <= 5)
            {
                prendaView.Cantidad = 1;

            }
               if (prendaView.Cantidad > 5)
            {
                prendaView.Cantidad -= 5;
            }
            var prenda = db.Prendas.Find(prendaView.PrendaId);
            prendaView.lblPrenda.Text = prenda.TipoRopa + "X" + prendaView.Cantidad;

            var Orden = db.Ordenes.Find(ordenId);
            Orden.TotalOrden = db.OrdenDetallePrendas.Where(m => m.OrdenId == Orden.OrdenId).SelectMany(w => w.DetalleTareas).Sum(q => q.Precio);
            var Total = double.Parse(Orden.TotalOrden.ToString());
            var DatoPrenda = prendaView.Cantidad;
            var Resultado = Total * DatoPrenda;
            txtPrecioTotal.Text = Resultado.ToString();

        }
        void Clickunomas(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var id = int.Parse(btn.Text);
            var prendaView = listaprendas.Where(m => m.DetalleOrdenPrendaId == id).FirstOrDefault();
            prendaView.Cantidad += 1;
            var prenda = db.Prendas.Find(prendaView.PrendaId);
            prendaView.lblPrenda.Text = prenda.TipoRopa + "X" + prendaView.Cantidad;

            var Orden = db.Ordenes.Find(ordenId);
            Orden.TotalOrden = db.OrdenDetallePrendas.Where(m => m.OrdenId == Orden.OrdenId).SelectMany(w => w.DetalleTareas).Sum(q => q.Precio);
            var Total = double.Parse(Orden.TotalOrden.ToString());
            var DatoPrenda = prendaView.Cantidad;
            var Resultado = Total * DatoPrenda;
            txtPrecioTotal.Text = Resultado.ToString();
        }
        void Clickunomenos(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var id = int.Parse(btn.Text);
            var prendaView = listaprendas.Where(m => m.DetalleOrdenPrendaId == id).FirstOrDefault();
          
         
         
              if (prendaView.Cantidad > 1)
            {
                prendaView.Cantidad -= 1;
            }
            var prenda = db.Prendas.Find(prendaView.PrendaId);
            prendaView.lblPrenda.Text = prenda.TipoRopa + "X" + prendaView.Cantidad;

            var Orden = db.Ordenes.Find(ordenId);
            Orden.TotalOrden = db.OrdenDetallePrendas.Where(m => m.OrdenId == Orden.OrdenId).SelectMany(w => w.DetalleTareas).Sum(q => q.Precio);
            var Total = double.Parse(Orden.TotalOrden.ToString());
            var DatoPrenda = prendaView.Cantidad;
            var Resultado = Total * DatoPrenda;
            txtPrecioTotal.Text = Resultado.ToString();
        }
        void ClickBorrartax(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            var iddos = btn.Name;
            var id = int.Parse(btn.Name);
            db.OrdenDetalleTareas.RemoveRange(db.OrdenDetalleTareas.Where(m => m.DetalleOrdenesId == id));
            db.SaveChanges();

            var viewTarea = listatareas.Where(f => f.DetalleOrdenesId == id).FirstOrDefault();
            if (viewTarea==null) { return ; }
            var detalleprendaid = viewTarea.DetalleOrdenPrendaId;
            this.tbpDatos.Controls.Remove(viewTarea.Panel);
            listatareas.Remove(viewTarea);
            var viewPrenda = listaprendas.Where(m => m.DetalleOrdenPrendaId == detalleprendaid).FirstOrDefault();
            if (viewPrenda != null)
            {
                if (listatareas.Where(u => u.DetalleOrdenPrendaId == viewPrenda.DetalleOrdenPrendaId).Count() == 0)
                {
                    this.tbpDatos.Controls.Remove(viewPrenda.Panel);
                    listaprendas.Remove(viewPrenda);
                    rowCount -= 2;
                    tbpDatos.RowCount = rowCount;
                }
                else
                {
                    rowCount -= 1;
                    tbpDatos.RowCount = rowCount;
                }

            }
            
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

        void ClickAddtax(object sender, EventArgs e)
        {
            GuardarCambiosTarea();
            var btn = (Button)sender;
            var id = int.Parse(btn.Text);
            var detalleprenda =db.OrdenDetallePrendas.Find(id);

            var tarea = detalleprenda.Prenda.Tareas.FirstOrDefault();
            var tareaView = new OrdenDetalleViewModel(tarea.NombreTareas, tarea.DetalleTareas.FirstOrDefault().DetalleTareas, tarea.DetalleTareas.FirstOrDefault().Precio);
            tareaView.DetalleOrdenPrendaId = detalleprenda.DetalleOrdenPrendaId;
            tareaView.Panel.MouseLeave += new EventHandler(Mouseleavetabla);
            tareaView.Panel.MouseEnter += new EventHandler(Mouseovertabla);
            tareaView.DetalleTareaId = tarea.DetalleTareas.FirstOrDefault().DetalleTareaId;
            tareaView.btnBorrarTarea.Name = "0";
            tareaView.btnBorrarTarea.Click += new EventHandler(ClickBorrartax);
            tareaView.Panel.Controls.Add(tareaView.lblTarea);
            tareaView.Panel.Controls.Add(tareaView.lblDetalleTarea);
            tareaView.Panel.Controls.Add(tareaView.txtPrecio);
            tareaView.Panel.Controls.Add(tareaView.lblDescuento);
            tareaView.Panel.Controls.Add(tareaView.txtDescripcion);
            tareaView.Panel.Controls.Add(tareaView.lblAfiliado);
            tareaView.Panel.Controls.Add(tareaView.btnBorrarTarea);
            tareaView.DetalleOrdenesId =0;
            var ultimatarea = listatareas.Where(t => t.DetalleOrdenPrendaId == tareaView.DetalleOrdenPrendaId).Last();
            listatareas.Add(tareaView);

            if (ultimatarea !=null)
            {
                foreach (var item in tbpDatos.Controls)
                {
                    Panel panel = (Panel)item;

                    if (panel == ultimatarea.Panel)
                    {
                        int rowB = tbpDatos.GetRow(panel);
                        rowCount += 1;
                        tbpDatos.RowCount = rowCount;
                        tbpDatos.Controls.Add(tareaView.Panel, 0, rowB + 1);
                    }                  
                    
                }                              
            }
            else
            {
                tbpDatos.Controls.Add(tareaView.Panel, 0, rowCount);
                
            }

            istarea = true;
            this.servicios(detalleprenda.PrendaId);
        }
        private void dvgOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 26)
            {

                Form1 empleado = new Form1(null,null);

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
            this.txtNotas.Text = "";
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
           // this.txtEmail.Text = "";
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
            //this.txttelefonoprincipal.Text = "";
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

  
        void ClickCargarPAnel(int aidControl, string Tarea, int detalle, double precio)
        {
       
            foreach (Control item in tbpDatos.Controls.OfType<Control>())
            {
                if (item.Name == "Ganazo")
                    tbpDatos.Controls.Remove(item);
                if (item.Name == "GAnazodos")
                    tbpDatos.Controls.Remove(item);
            }
            if (!istarea)
            {
                CargarPanelTodo(aidControl, Tarea, detalle, precio);
            }
            else {
                CargarPanelTarea(aidControl, Tarea, detalle, precio);
            }

            GuardarCambiosTarea();
            this.mostrarcontrolesDos(precio.ToString());
        }

        void ClickDuplicar(object sender, EventArgs e)
        {

        }
        private void BorrarPanel()
        {
            var totaldos = tbpDatos.Controls.Count;
            var litdos = tbpDatos.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tbpDatos.Controls.Remove(tbpDatos.Controls[0]);
            }

        }

        private void BorrarControles()
        {
            var totaldos = Prueba.Controls.Count;
            var litdos = Prueba.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                Prueba.Controls.Remove(Prueba.Controls[0]);
            }

        }

        public void servicios(int prendaId)

        {
            BorrarControles();
            var prenda=db.Prendas.Find(prendaId);
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



        public void mostrarcontrolesDos(string pre)
        {

         

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
          
            botonmas.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\mas.png");

            botonmas.Name = "btnmas";
            botonmas.Location = new Point(0, 330);
            botonmas.Size = new Size(76, 169);
          
            botonmas.MouseLeave += new EventHandler(Mouseleave);
            botonmas.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonmas);


            var txtboxdato = new TextBox();
          
            txtboxdato.Name = "txtdato";
            txtboxdato.Location = new Point(79, 330);
            txtboxdato.Multiline = true;
            txtboxdato.Size = new Size(317, 169);
        
            txtboxdato.KeyPress += new KeyPressEventHandler(ClickPrecioneTecla);
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
            combo.SelectedIndexChanged += new EventHandler(ClickaplicarDescuento);
            this.Prueba.Controls.Add(combo);
    

            combo.DataSource = db.Ofertas.ToList();
            combo.DisplayMember = "Descripcion";
            combo.ValueMember = "OfertaId";

            var combodos = new ComboBox();
            combodos.Text = "Selecione Un afiliado";
            combodos.Name = "cmbafiliados";
            combodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            combodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            combodos.Location = new Point(3, 560);
            combodos.Size = new Size(274, 30);
            combodos.SelectedIndexChanged += new EventHandler(ClickAfiliado);
            combodos.MouseLeave += new EventHandler(MouseleaveCombo);
            combodos.MouseEnter += new EventHandler(MouseoverCombo);
            this.Prueba.Controls.Add(combodos);


            combodos.DataSource = db.Afiliados.ToList();
            combodos.DisplayMember = "Nombre";
            combodos.ValueMember = "AfiliadoId";

            var botox1 = new Button();
            botox1.Text = "X";
            botox1.Name = "btnx1";
            botox1.Location = new Point(283, 520);
            botox1.Size = new Size(45, 40);
            botox1.Click += new EventHandler(ClickRestaurarCombo1);
            botox1.MouseLeave += new EventHandler(Mouseleave);
            botox1.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botox1);

            var botonimagen = new Button();
            // botonmas.Text = "+";
            botonimagen.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\asterisco.png");

            botonimagen.Name = "asterisco1";
            botonimagen.Location = new Point(333, 520);
            botonimagen.Size = new Size(45, 40);
           // botonimagen.Click += new EventHandler(ClickPrendas);
            botonimagen.MouseLeave += new EventHandler(Mouseleave);
            botonimagen.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonimagen);

            var botonimagendos = new Button();
            // botonmas.Text = "+";
            botonimagendos.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\asterisco.png");

            botonimagendos.Name = "asterisco2";
            botonimagendos.Location = new Point(333, 560);
            botonimagendos.Size = new Size(45, 40);
           // botonimagendos.Click += new EventHandler(ClickPrendas);
            botonimagendos.MouseLeave += new EventHandler(Mouseleave);
            botonimagendos.MouseEnter += new EventHandler(Mouseover);
            this.Prueba.Controls.Add(botonimagendos);


            var botox2 = new Button();
            botox2.Text = "X";
            botox2.Name = "btnx2";
            botox2.Location = new Point(283, 560);
            botox2.Size = new Size(45, 40);
            botox2.Click += new EventHandler(ClickRestaurarCombo2);
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

            precio.Text = "" + pre;
            lblprecioTarea = precio;
            this.Prueba.Controls.Add(lblprecioTarea);

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
            btnEnviar.Location = new System.Drawing.Point(1130, 14);// 1134; 14
            btnEnviar.Name = "btnEnviardos";
            btnEnviar.Size = new System.Drawing.Size(180, 44);
            btnEnviar.TabIndex = 74;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += new System.EventHandler(btnEnviar_Click);
            this.groupBox1.Controls.Add(btnEnviar);
            
       

        }
        
             public void ClickAfiliado(object sender, EventArgs e) { }
        public void ClickaplicarDescuento(object sender, EventArgs e) { }
         public void ClickRestaurarCombo2(object sender, EventArgs e) { }
         public void ClickRestaurarCombo1(object sender, EventArgs e) { }


        public void CargarPanelTodo(int aidControl, string Tarea, int detalle, double precio)
        {
            DAtoY = DAtoY += 50;
            DAtoYdos = DAtoYdos += 50;
            var id = aidControl;
            prenda = db.Prendas.Find(id);

            var detalletarea = db.DetalleTareas.Find(detalle);
            var Orden = db.Ordenes.Find(ordenId);
            var ordenPrenda = new TemDetallesOrdenPrenda { OrdenId = Orden.OrdenId, Cantidad =1, PrendaId = prenda.PrendaId };
        db.OrdenDetallePrendas.Add(ordenPrenda);
            db.SaveChanges();
          
            var prendaView = new OrdenPrendaViewModel(prenda.TipoRopa + " X"+cantidad);
        prendaView.DetalleOrdenPrendaId = ordenPrenda.DetalleOrdenPrendaId;
            prendaView.PrendaId = prenda.PrendaId;
            prendaView.Cantidad = 1;
          
       

            prendaView.btnagregartarea.Click += new EventHandler(ClickAddtax);
            prendaView.btnagregartarea.Text = prendaView.DetalleOrdenPrendaId.ToString();

           
            prendaView.btnDuplicar.Click += new EventHandler(ClickDuplicar);
            prendaView.btnDuplicar.Text = prendaView.DetalleOrdenPrendaId.ToString();
          
            prendaView.btnmascinco.Click += new EventHandler(Clickcincomas);
            prendaView.btnmascinco.Text = prendaView.DetalleOrdenPrendaId.ToString();

            prendaView.btnmasuno.Click += new EventHandler(Clickunomas);
            prendaView.btnmasuno.Text = prendaView.DetalleOrdenPrendaId.ToString();

            prendaView.btnmenosuno.Click += new EventHandler(Clickunomenos);
            prendaView.btnmenosuno.Text = prendaView.DetalleOrdenPrendaId.ToString();


            prendaView.btnmenoscinco.Click += new EventHandler(Clickcincomenos);
            prendaView.btnmenoscinco.Text = prendaView.DetalleOrdenPrendaId.ToString();

            prendaView.btnCantidad.Click += new EventHandler(ClickCantidad);
            prendaView.btnCantidad.Text = prendaView.DetalleOrdenPrendaId.ToString();

            prendaView.Panel.Controls.Add(prendaView.btnCantidad);
            prendaView.Panel.Controls.Add(prendaView.btnmascinco);
            prendaView.Panel.Controls.Add(prendaView.btnDuplicar);
            prendaView.Panel.Controls.Add(prendaView.btnmasuno);
            prendaView.Panel.Controls.Add(prendaView.btnmenosuno);
            prendaView.Panel.Controls.Add(prendaView.btnmenoscinco);
            prendaView.Panel.Controls.Add(prendaView.btnagregartarea);
            prendaView.Panel.Controls.Add(prendaView.lblPrenda);
            prendaView.Panel.Controls.Add(prendaView.btnPrioridad);

            listaprendas.Add(prendaView);
            rowCount += 1;
            tbpDatos.RowCount = rowCount;
            this.tbpDatos.Controls.Add(listaprendas.Last().Panel,0, rowCount);
            var detalletareatenporal = new TemDetallesOrdenes { DetalleOrdenPrendaId = ordenPrenda.DetalleOrdenPrendaId, DetalleTareaId = detalletarea.DetalleTareaId,Precio=detalletarea.Precio };
        db.OrdenDetalleTareas.Add(detalletareatenporal);
            db.SaveChanges();
            var tareaView = new OrdenDetalleViewModel(tarea.NombreTareas, detalletarea.DetalleTareas, detalletarea.Precio);
            AutoMapper.Mapper.Map(detalletareatenporal,tareaView);
        tareaView.DetalleOrdenPrendaId = prendaView.DetalleOrdenPrendaId;
            tareaView.Panel.MouseLeave += new EventHandler(Mouseleavetabla);
        tareaView.Panel.MouseEnter += new EventHandler(Mouseovertabla);
        tareaView.DetalleTareaId = detalletarea.DetalleTareaId;
            tareaView.btnBorrarTarea.Name= detalletareatenporal.DetalleOrdenesId.ToString();
            tareaView.btnBorrarTarea.Click += new EventHandler(ClickBorrartax);
        tareaView.Panel.Controls.Add(tareaView.lblTarea);
            tareaView.Panel.Controls.Add(tareaView.lblDescuento);
            tareaView.Panel.Controls.Add(tareaView.lblDetalleTarea);
            tareaView.Panel.Controls.Add(tareaView.lblAfiliado);
            tareaView.Panel.Controls.Add(tareaView.txtPrecio);
            tareaView.Panel.Controls.Add(tareaView.txtDescripcion);
            tareaView.Panel.Controls.Add(tareaView.btnBorrarTarea);
            tareaView.DetalleOrdenesId = detalletareatenporal.DetalleOrdenesId;
            rowCount += 1;
            tbpDatos.RowCount = rowCount;
            listatareas.Add(tareaView);
            this.tbpDatos.Controls.Add(listatareas.Last().Panel,0,rowCount);
        }
        public void CargarPanelGenerico(int aidControl, string Tarea, int detalle, double precio)
        {
            
            var id = aidControl;
            prenda = db.Prendas.Find(id);

            var detalletarea = db.DetalleTareas.Find(detalle);
            var Orden = db.Ordenes.Find(ordenId);
            var ordenPrenda = new TemDetallesOrdenPrenda { OrdenId = Orden.OrdenId, Cantidad = 1, PrendaId = prenda.PrendaId };
          
            var prendaView = new OrdenPrendaViewModel(prenda.TipoRopa + " X" + cantidad);
            prendaView.DetalleOrdenPrendaId = ordenPrenda.DetalleOrdenPrendaId;
            prendaView.Panel.Name = "GAnazodos";
            prendaView.PrendaId = prenda.PrendaId;
            prendaView.Cantidad = 1;



            prendaView.btnagregartarea.Click += new EventHandler(ClickAddtax);
            prendaView.btnagregartarea.Text = prendaView.DetalleOrdenPrendaId.ToString();


            prendaView.btnDuplicar.Click += new EventHandler(ClickDuplicar);
            prendaView.btnDuplicar.Text = prendaView.DetalleOrdenPrendaId.ToString();

            prendaView.btnmascinco.Click += new EventHandler(Clickcincomas);
            prendaView.btnmascinco.Text = prendaView.DetalleOrdenPrendaId.ToString();

            prendaView.btnmasuno.Click += new EventHandler(Clickunomas);
            prendaView.btnmasuno.Text = prendaView.DetalleOrdenPrendaId.ToString();

            prendaView.btnmenosuno.Click += new EventHandler(Clickunomenos);
            prendaView.btnmenosuno.Text = prendaView.DetalleOrdenPrendaId.ToString();


            prendaView.btnmenoscinco.Click += new EventHandler(Clickcincomenos);
            prendaView.btnmenoscinco.Text = prendaView.DetalleOrdenPrendaId.ToString();

            prendaView.btnCantidad.Click += new EventHandler(ClickCantidad);
            prendaView.btnCantidad.Text = prendaView.DetalleOrdenPrendaId.ToString();

            prendaView.Panel.Controls.Add(prendaView.btnCantidad);
            prendaView.Panel.Controls.Add(prendaView.btnmascinco);
            prendaView.Panel.Controls.Add(prendaView.btnDuplicar);
            prendaView.Panel.Controls.Add(prendaView.btnmasuno);
            prendaView.Panel.Controls.Add(prendaView.btnmenosuno);
            prendaView.Panel.Controls.Add(prendaView.btnmenoscinco);
            prendaView.Panel.Controls.Add(prendaView.btnagregartarea);
            prendaView.Panel.Controls.Add(prendaView.lblPrenda);
            prendaView.Panel.Controls.Add(prendaView.btnPrioridad);

            listaprendas.Add(prendaView);
            rowCount += 1;
            tbpDatos.RowCount = rowCount;
            this.tbpDatos.Controls.Add(listaprendas.Last().Panel, 0, rowCount);
            var detalletareatenporal = new TemDetallesOrdenes { DetalleOrdenPrendaId = ordenPrenda.DetalleOrdenPrendaId, DetalleTareaId = detalletarea.DetalleTareaId, Precio = detalletarea.Precio };
            
            var tareaView = new OrdenDetalleViewModel(Tarea, detalletarea.DetalleTareas, detalletarea.Precio);
            AutoMapper.Mapper.Map(detalletareatenporal, tareaView);
            tareaView.DetalleOrdenPrendaId = prendaView.DetalleOrdenPrendaId;
            tareaView.Panel.Name = "Ganazo";
            tareaView.Panel.MouseLeave += new EventHandler(Mouseleavetabla);
            tareaView.Panel.MouseEnter += new EventHandler(Mouseovertabla);
            tareaView.DetalleTareaId = detalletarea.DetalleTareaId;
            tareaView.btnBorrarTarea.Name = detalletareatenporal.DetalleOrdenesId.ToString();
            tareaView.btnBorrarTarea.Click += new EventHandler(ClickBorrartax);
            tareaView.Panel.Controls.Add(tareaView.lblTarea);
            tareaView.Panel.Controls.Add(tareaView.lblDescuento);
            tareaView.Panel.Controls.Add(tareaView.lblDetalleTarea);
            tareaView.Panel.Controls.Add(tareaView.lblAfiliado);
            tareaView.Panel.Controls.Add(tareaView.txtPrecio);
            tareaView.Panel.Controls.Add(tareaView.txtDescripcion);
            tareaView.Panel.Controls.Add(tareaView.btnBorrarTarea);
            tareaView.DetalleOrdenesId = detalletareatenporal.DetalleOrdenesId;
            rowCount += 1;
            tbpDatos.RowCount = rowCount;
            listatareas.Add(tareaView);
            this.tbpDatos.Controls.Add(listatareas.Last().Panel, 0, rowCount);
        }
        void ClickCargarOrdenEditadas()
        {

           

            listaTareas = new List<OrdenDetalleViewModel>();
            listaPrendas = new List<OrdenPrendaViewModel>();

            IdOrden = OrdenId;

            var Colores = true;

            rowCount = 0;

            var query = db.Ordenes.Where(q => q.OrdenId == OrdenId).ToList();

            var idDetale = query.FirstOrDefault().Prendas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleOrdenesId;
            var detallesO = db.OrdenDetalleTareas.Find(idDetale).Subtotal;

            foreach (var itemdos in query)

            {


                var orden = db.Ordenes.Find(itemdos.OrdenId);
                var idDetaleOrden = orden.Prendas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleOrdenesId;
                var detallesOrden = db.OrdenDetalleTareas.Find(idDetaleOrden);

                if (detallesOrden.Estado == false)
                {
                    foreach (var prenda in orden.Prendas)

                    {
                        var panelViewPrenda = new OrdenPrendaViewModel(string.Empty);





                        panelViewPrenda.Panel.Name = prenda.DetalleOrdenPrendaId.ToString();
                        panelViewPrenda.Panel.Size = new Size(897, 45);
                        panelViewPrenda.lblPrenda.Text = prenda.Prenda.TipoRopa.ToString() + "X" + prenda.Cantidad;




                        panelViewPrenda.Panel.Controls.Add(panelViewPrenda.lblPrenda);


                        panelViewPrenda.btnagregartarea.Click += new EventHandler(ClickAddtax);
                        panelViewPrenda.btnagregartarea.Text = panelViewPrenda.DetalleOrdenPrendaId.ToString();


                        panelViewPrenda.btnDuplicar.Click += new EventHandler(ClickDuplicar);
                        panelViewPrenda.btnDuplicar.Text = panelViewPrenda.DetalleOrdenPrendaId.ToString();

                        panelViewPrenda.btnmascinco.Click += new EventHandler(Clickcincomas);
                        panelViewPrenda.btnmascinco.Text = panelViewPrenda.DetalleOrdenPrendaId.ToString();

                        panelViewPrenda.btnmasuno.Click += new EventHandler(Clickunomas);
                        panelViewPrenda.btnmasuno.Text = panelViewPrenda.DetalleOrdenPrendaId.ToString();

                        panelViewPrenda.btnmenosuno.Click += new EventHandler(Clickunomenos);
                        panelViewPrenda.btnmenosuno.Text = panelViewPrenda.DetalleOrdenPrendaId.ToString();


                        panelViewPrenda.btnmenoscinco.Click += new EventHandler(Clickcincomenos);
                        panelViewPrenda.btnmenoscinco.Text = panelViewPrenda.DetalleOrdenPrendaId.ToString();

                        panelViewPrenda.btnCantidad.Click += new EventHandler(ClickCantidad);
                        panelViewPrenda.btnCantidad.Text = panelViewPrenda.DetalleOrdenPrendaId.ToString();

                        panelViewPrenda.Panel.Controls.Add(panelViewPrenda.btnCantidad);
                        panelViewPrenda.Panel.Controls.Add(panelViewPrenda.btnmascinco);
                        panelViewPrenda.Panel.Controls.Add(panelViewPrenda.btnDuplicar);
                        panelViewPrenda.Panel.Controls.Add(panelViewPrenda.btnmasuno);
                        panelViewPrenda.Panel.Controls.Add(panelViewPrenda.btnmenosuno);
                        panelViewPrenda.Panel.Controls.Add(panelViewPrenda.btnmenoscinco);
                        panelViewPrenda.Panel.Controls.Add(panelViewPrenda.btnagregartarea);
                        panelViewPrenda.Panel.Controls.Add(panelViewPrenda.lblPrenda);
                        panelViewPrenda.Panel.Controls.Add(panelViewPrenda.btnPrioridad);

                        listaPrendas.Add(panelViewPrenda);
                        rowCount += 1;
                        tbpDatos.RowCount = rowCount;
                        this.tbpDatos.Controls.Add(listaPrendas.Last().Panel, 0, rowCount);

                        foreach (var tarea in prenda.DetalleTareas)
                        {

                            var panelViewTarea = new OrdenDetalleViewModel(string.Empty, string.Empty, 0);



                            panelViewTarea.panelTarea.Size = new Size(897, 45);
                            panelViewTarea.panelTarea.MouseEnter += new EventHandler(Mouseovertabla);
                            panelViewTarea.panelTarea.MouseLeave += new EventHandler(Mouseleavetabla);
                            panelViewTarea.panelTarea.Name = tarea.DetalleOrdenesId.ToString();
                            panelViewTarea.DetalleOrdenesId = tarea.DetalleOrdenesId;
                            if (Colores == true)
                            {
                                panelViewTarea.panelTarea.BackColor = Color.White;
                                Colores = false;
                            }
                            else
                            {
                                panelViewTarea.panelTarea.BackColor = Color.WhiteSmoke;
                                Colores = true;
                            }



                            panelViewTarea.lblTarea.Text = tarea.Detalle.Tarea.NombreTareas.ToString();

                            panelViewTarea.lblTarea.Location = new Point(0, 10);
                           
                            panelViewTarea.lblTarea.Size = new Size(110, 45);

                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblTarea);

                            panelViewTarea.lblDetalleTarea.Text = tarea.Detalle.DetalleTareas.ToString();

                            panelViewTarea.lblDetalleTarea.Location = new Point(115, 10);
                     
                            panelViewTarea.lblDetalleTarea.Size = new System.Drawing.Size(150, 34);
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDetalleTarea);

                            panelViewTarea.lblPrecio.Text = tarea.Detalle.Precio.ToString();
                       
                            panelViewTarea.lblPrecio.Location = new Point(270, 10);

                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblPrecio);

                            panelViewTarea.txtTotalPrecio.Text = (tarea.Descuento).ToString() + "%";
                           
                            panelViewTarea.txtTotalPrecio.Location = new Point(325, 10);
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.txtTotalPrecio);

                            panelViewTarea.lblSubTotal.Text = (tarea.Subtotal).ToString();
                          
                            panelViewTarea.lblSubTotal.Location = new Point(462, 10);
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblSubTotal);
                            if (tarea.AfiliadoId > 0)
                            {
                                var nombre = db.Afiliados.Find(tarea.AfiliadoId);
                                panelViewTarea.lblAfiliado.Text = (nombre.Nombre);

                            }
                            else
                            {
                                panelViewTarea.lblAfiliado.Text = "";
                            }


                            panelViewTarea.lblAfiliado.Location = new Point(768, 10);
                            
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblAfiliado);

                            panelViewTarea.lblDescripcion.Text = (tarea.Descripcion).ToString();
                            
                            panelViewTarea.lblDescripcion.Location = new Point(555, 10);
                            panelViewTarea.lblDescripcion.Size = new Size(210, 34);


                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDescripcion);

                            panelViewTarea.btnBorrarTarea.Name = tarea.DetalleOrdenesId.ToString();
                            panelViewTarea.btnBorrarTarea.Click += new EventHandler(ClickBorrartax);
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.btnBorrarTarea);

                            listaTareas.Add(panelViewTarea);
                            rowCount += 1;
                            tbpDatos.RowCount = rowCount;
                            this.tbpDatos.Controls.Add(listaTareas.Last().panelTarea, 0, rowCount);
                        }





                    }
                }

            }

        }

        public void CargarPanelTarea(int aidControl, string Tarea, int detalle, double precio)
        {
            
          
            var id = aidControl;
            prenda = db.Prendas.Find(id);
        
            var detalletarea = db.DetalleTareas.Find(detalle);

            var lastTarea = listatareas.Last();
            lastTarea.DetalleTareaId = detalle;
            lastTarea.txtPrecio.Text = precio.ToString();
            lastTarea.Precio = precio;

            var ordenDetalleTarea = new TemDetallesOrdenes();
            AutoMapper.Mapper.Map(lastTarea, ordenDetalleTarea);
            db.OrdenDetalleTareas.Add(ordenDetalleTarea);
            db.SaveChanges();
            
            var tareaView = lastTarea;
            tareaView.lblTarea.Text = Tarea;
            tareaView.DetalleOrdenesId = ordenDetalleTarea.DetalleOrdenesId;
            tareaView.lblDetalleTarea.Text = detalletarea.DetalleTareas;
            tareaView.txtPrecio.Text= detalletarea.Precio.ToString();            
            tareaView.btnBorrarTarea.Name = lastTarea.DetalleOrdenesId.ToString();
            tareaView.btnBorrarTarea.Click += new EventHandler(ClickBorrartax);            
        }

        void GuardarCambiosAfiliado(int id)
        {
            GuardarCambiosTarea();
            using (var db = new DataContextLocal())
            {
                var ordenDetalleTarea = new TemDetallesOrdenes();
                var ultimaTarea = listatareas.Last();
                ultimaTarea.AfiliadoId = id;
                AutoMapper.Mapper.Map(listatareas.Last(), ordenDetalleTarea);
                var query = db.Afiliados.Find(id);
                var porsentaje = double.Parse(query.Porsentaje);
                var PrecioTarea = ultimaTarea.Subtotal;
                var MontoIngreso = PrecioTarea * porsentaje / 100;
                var MontoPago = PrecioTarea - MontoIngreso;
                try
                {
                    db.Entry(ordenDetalleTarea).State = EntityState.Modified;
                    db.SaveChanges();

                    Provedor   provedor = new Provedor();
                    provedor.FechaIngreso = DateTime.Today;
                    provedor.MontoIngreso = MontoIngreso;
                    provedor.MontoPago = MontoPago;
                    provedor.idServicio = id;

                    db.Provedor.Add(provedor);
                    db.SaveChanges();
                
                }
                catch (Exception ex)
                {

                }



            }

        }

       private void ClickPrecioneTecla(object sender, KeyPressEventArgs e)
        {

            TextBox btn = sender as TextBox;
            var iddos = btn.Name;
            var id = btn.Text;
            String x = "";


            x = id + e.KeyChar;

            if (e.KeyChar == '\b')
            {
                if (x.Length == 1)
                {
                    x = x.Remove(x.Length - 1);
                    BorrarPanel();
                }
                else
                {
                    x = x.Remove(x.Length - 2);
                    BorrarPanel();
                }
            }


            if (x != "")
            {
                var ultimatarea = listatareas.Last();

                if (!string.IsNullOrEmpty(ultimatarea.txtPrecio.Text))
                {
                 
                    ultimatarea.txtDescripcion.Text = x;
                    //GuardarCambiosTarea();
                }


            }

          
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || txtNombre.Text.Trim() == "Nombre Cliente")
            {
                MessageBox.Show("El Nombre Es un dato Obligatorio");
                txtNombre.Text = "";
                txtNombre.Focus();

            }
        }
    }
    
}

