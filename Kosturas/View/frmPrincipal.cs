using Domain;
using Kosturas.Model;
using Kosturas.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kosturas.ViewModels;
using Microsoft.Reporting.WinForms;
using System.Diagnostics;
using System.IO;


namespace Kosturas
{
    public partial class frmPrincipal : Form
    {

        DataContextLocal db = new DataContextLocal();
        public int ClienteId { get; set; }
        public int Clientename { get; set; }
        public string ClienteTex { get; set; }
        Color ColorEntrada;
        public int ClientePosicion { get; set; }
        int rowCount = 0;
        int IdOrden = 0;
        public List<OrdenDetalleViewModel> listaTareas = new List<OrdenDetalleViewModel>();
        public List<OrdenPrendaViewModel> listaPrendas = new List<OrdenPrendaViewModel>();


        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Close();
            Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

      




            
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Close();
            Close();
        }



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            var mn=frm.MinimizeBox;
            Close();
        }

        private void pvEmpleado_Click(object sender, EventArgs e)
        {
            
            this.Opacity = 0.85;
            Program.abrirform = 1;
            frmPin empleado=new frmPin();
            empleado.ShowDialog();
          
        }

        private void pvOrdenes_Click(object sender, EventArgs e)
        {
            frmTotalOrden totalOrden = new frmTotalOrden();
            totalOrden.ShowDialog();
        }

        private void pvOrdenesFecha_Click(object sender, EventArgs e)
        {
            frmOrdenPorDia ordenPorDia = new frmOrdenPorDia();
            ordenPorDia.ShowDialog();
        }

        private void pvMensajes_Click(object sender, EventArgs e)
        {
            frmReportesSMS reportesSMS = new frmReportesSMS();
            reportesSMS.ShowDialog();
        }

        private void btnNuevaOrden_Click(object sender, EventArgs e)
        {

         
            Form1 form = new Form1(null,null);
            this.Opacity = 0.80;

            form.ShowDialog();
            this.Opacity = 1;
        }

        private void btnConfirguracion_Click(object sender, EventArgs e)
        {
          
            this.Opacity = 0.85;
            Program.abrirform = 2;
            frmPin empleado = new frmPin();
            empleado.ShowDialog();

            this.Opacity = 1;

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            String x = "";


            x = this.txtTelefono.Text + e.KeyChar;

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
                BorrarPanel();
                CargarClienteTelefono(x);



            }

           
               

          
            
            
        }

        private void CargarCliente(string texbox)
        {

            

            
            var query = db.Clientes.Where(j => j.Nombre.Contains(texbox.ToString())).Select(t => new { t.ClienteId, t.Abreviatura, t.TelefonoPrincipal, t.Nombre, t.Email, t.Notas }).ToList();

            foreach (var item in query)
      
            {



                var botonesdos = new TextBox();
                botonesdos.Size = new Size(80, 30);
                botonesdos.Multiline = true;
         
                //  botonesdos.Click +=  new EventHandler(ClickMensaje);
                botonesdos.Text = item.Abreviatura;
          
               
                botonesdos.Name = item.ClienteId.ToString();
                botonesdos.KeyPress += new KeyPressEventHandler(ClickTexbox1);
            
                botonesdos.BorderStyle = System.Windows.Forms.BorderStyle.None;
              //  botonesdos.Size = new System.Drawing.Size(131, 34);
                botonesdos.TabIndex = 143;

                var botonestres = new TextBox();
           
                botonestres.Text = item.TelefonoPrincipal;
                botonestres.Name = item.ClienteId.ToString();
                botonestres.Multiline = true;
                botonestres.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonestres.Size = new System.Drawing.Size(110, 30);
                botonestres.KeyPress += new KeyPressEventHandler(ClickTexbox2);
                botonestres.TabIndex = 143;
                var botonescuatro = new TextBox();
                botonescuatro.Text = item.Nombre;
                botonescuatro.Name = item.ClienteId.ToString();
                botonescuatro.Multiline = true;
                botonescuatro.KeyPress += new KeyPressEventHandler(ClickTexbox3);
                botonescuatro.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonescuatro.Size = new System.Drawing.Size(110, 30);
                botonescuatro.TabIndex = 143;

                var botonecinco = new TextBox();
                botonecinco.Text = item.Email;
                botonecinco.Name = item.Email;
                botonecinco.Multiline = true;
                botonecinco.KeyPress += new KeyPressEventHandler(ClickTexbox4);
                botonecinco.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonecinco.Size = new System.Drawing.Size(150, 30);
                botonecinco.TabIndex = 143;

                var botonesseis = new TextBox();
                botonesseis.Text = item.Notas;
                botonesseis.Name = item.Notas;
                botonesseis.Multiline = true;
                botonesseis.KeyPress += new KeyPressEventHandler(ClickTexbox5);
                botonesseis.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonesseis.Size = new System.Drawing.Size(340, 30);
                botonesseis.TabIndex = 143;


                var NuevaOrden = new Button();


                NuevaOrden.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura10.png");

                NuevaOrden.BackColor = System.Drawing.Color.White;
                NuevaOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                NuevaOrden.FlatAppearance.BorderSize = 0;
                NuevaOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                NuevaOrden.Size = new System.Drawing.Size(32, 34);
                NuevaOrden.TabIndex = 142;
                NuevaOrden.UseVisualStyleBackColor = false;

                NuevaOrden.Name = item.ClienteId.ToString();
                NuevaOrden.Click += new EventHandler(ClickNuevaOrden);

                var optenerordenes = new Button();


                optenerordenes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura11.png");
                optenerordenes.Name = item.ClienteId.ToString();
                optenerordenes.BackColor = System.Drawing.Color.White;
                optenerordenes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                optenerordenes.FlatAppearance.BorderSize = 0;
                optenerordenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                optenerordenes.Size = new System.Drawing.Size(32, 34);
                optenerordenes.TabIndex = 142;


                optenerordenes.Click += new EventHandler(ClickCargarOrdenSinCompletar);
                optenerordenes.UseVisualStyleBackColor = false;

                var guardarcambios = new Button();



                guardarcambios.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura12.png");
                guardarcambios.Name = item.ClienteId.ToString();
                guardarcambios.BackColor = System.Drawing.Color.White;
                guardarcambios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                guardarcambios.FlatAppearance.BorderSize = 0;
                guardarcambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                guardarcambios.Size = new System.Drawing.Size(32, 34);
                guardarcambios.TabIndex = 142;
                guardarcambios.UseVisualStyleBackColor = false;
                guardarcambios.Click += new EventHandler(ClickGuardarCambios);


                var unirseldas = new Button();


                unirseldas.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura13.png");
                unirseldas.Name = item.ClienteId.ToString();
                unirseldas.BackColor = System.Drawing.Color.White;
                unirseldas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                unirseldas.FlatAppearance.BorderSize = 0;
                unirseldas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                unirseldas.Size = new System.Drawing.Size(32, 34);
                unirseldas.TabIndex = 142;
                unirseldas.UseVisualStyleBackColor = false;


                var detalleclientes = new Button();



                detalleclientes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura14.png");
                detalleclientes.Name = item.ClienteId.ToString();
                detalleclientes.BackColor = System.Drawing.Color.White;
                detalleclientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                detalleclientes.FlatAppearance.BorderSize = 0;
                detalleclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                detalleclientes.Size = new System.Drawing.Size(32, 34);
                detalleclientes.TabIndex = 142;
                detalleclientes.Click += new EventHandler(ClickDetalleCliente);
                detalleclientes.UseVisualStyleBackColor = false;


                var Email = new Button();



                Email.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura15.png");
                Email.Name = item.ClienteId.ToString();
                Email.BackColor = System.Drawing.Color.White;
                Email.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                Email.FlatAppearance.BorderSize = 0;
                Email.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                Email.Size = new System.Drawing.Size(32, 34);
                Email.TabIndex = 142;
                Email.UseVisualStyleBackColor = false;

                var aumentocredito = new Button();



                aumentocredito.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura16.png");
                aumentocredito.Name = item.ClienteId.ToString();
                aumentocredito.BackColor = System.Drawing.Color.White;
                aumentocredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                aumentocredito.FlatAppearance.BorderSize = 0;
                aumentocredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                aumentocredito.Size = new System.Drawing.Size(32, 34);
                aumentocredito.TabIndex = 142;
                aumentocredito.UseVisualStyleBackColor = false;

                tableLayoutPanel1.Controls.Add(botonesdos);
                tableLayoutPanel1.Controls.Add(botonestres);
                tableLayoutPanel1.Controls.Add(botonescuatro);
                tableLayoutPanel1.Controls.Add(botonecinco);
                tableLayoutPanel1.Controls.Add(botonesseis);
                tableLayoutPanel1.Controls.Add(NuevaOrden);
                tableLayoutPanel1.Controls.Add(optenerordenes);
                tableLayoutPanel1.Controls.Add(guardarcambios);
                tableLayoutPanel1.Controls.Add(unirseldas);
                tableLayoutPanel1.Controls.Add(detalleclientes);
                tableLayoutPanel1.Controls.Add(Email);
                tableLayoutPanel1.Controls.Add(aumentocredito);
         

            }
        

            if (query.Count > 0)
            {

               // x = "";
                //dataGridView1.ClearSelection();

            }
             
         }
        private void CargarClienteTelefono(string texbox)
        {



            var d = 0;
            var f = 0;
            var o = 0;
            var query = db.Clientes.Where(j => j.TelefonoPrincipal.Contains(texbox.ToString())).Select(t => new { t.ClienteId, t.Abreviatura, t.TelefonoPrincipal, t.Nombre, t.Email, t.Notas }).ToList();

            foreach (var item in query)

            {



                var botonesdos = new TextBox();
                //  botonesdos.Click +=  new EventHandler(ClickMensaje);
                botonesdos.Text = item.Abreviatura;
                botonesdos.Name = item.ClienteId.ToString();
                botonesdos.KeyPress += new KeyPressEventHandler(ClickTexbox1);
                botonesdos.Multiline = true;
                botonesdos.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonesdos.Size = new System.Drawing.Size(131, 34);
                botonesdos.TabIndex = 143;

                var botonestres = new TextBox();
                botonestres.Text = item.TelefonoPrincipal;
                botonestres.Name = item.ClienteId.ToString();
                botonestres.Multiline = true;
                botonestres.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonestres.Size = new System.Drawing.Size(131, 34);
                botonestres.KeyPress += new KeyPressEventHandler(ClickTexbox2);
                botonestres.TabIndex = 143;
                var botonescuatro = new TextBox();
                botonescuatro.Text = item.Nombre;
                botonescuatro.Name = item.ClienteId.ToString();
                botonescuatro.Multiline = true;
                botonescuatro.KeyPress += new KeyPressEventHandler(ClickTexbox3);
                botonescuatro.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonescuatro.Size = new System.Drawing.Size(131, 34);
                botonescuatro.TabIndex = 143;

                var botonecinco = new TextBox();
                botonecinco.Text = item.Email;
                botonecinco.Name = item.Email;
                botonecinco.Multiline = true;
                botonecinco.KeyPress += new KeyPressEventHandler(ClickTexbox4);
                botonecinco.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonecinco.Size = new System.Drawing.Size(131, 34);
                botonecinco.TabIndex = 143;

                var botonesseis = new TextBox();
                botonesseis.Text = item.Notas;
                botonesseis.Name = item.Notas;
                botonesseis.Multiline = true;
                botonesseis.KeyPress += new KeyPressEventHandler(ClickTexbox5);
                botonesseis.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonesseis.Size = new System.Drawing.Size(290, 34);
                botonesseis.TabIndex = 143;


                var NuevaOrden = new Button();


                NuevaOrden.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura10.png");

                NuevaOrden.BackColor = System.Drawing.Color.White;
                NuevaOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                NuevaOrden.FlatAppearance.BorderSize = 0;
                NuevaOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                NuevaOrden.Size = new System.Drawing.Size(32, 34);
                NuevaOrden.TabIndex = 142;
                NuevaOrden.UseVisualStyleBackColor = false;

                NuevaOrden.Name = item.ClienteId.ToString();
                NuevaOrden.Click += new EventHandler(ClickNuevaOrden);

                var optenerordenes = new Button();


                optenerordenes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura11.png");
                optenerordenes.Name = item.ClienteId.ToString();
                optenerordenes.BackColor = System.Drawing.Color.White;
                optenerordenes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                optenerordenes.FlatAppearance.BorderSize = 0;
                optenerordenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                optenerordenes.Size = new System.Drawing.Size(32, 34);
                optenerordenes.TabIndex = 142;
                optenerordenes.UseVisualStyleBackColor = false;

                var guardarcambios = new Button();



                guardarcambios.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura12.png");
                guardarcambios.Name = item.ClienteId.ToString();
                guardarcambios.BackColor = System.Drawing.Color.White;
                guardarcambios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                guardarcambios.FlatAppearance.BorderSize = 0;
                guardarcambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                guardarcambios.Size = new System.Drawing.Size(32, 34);
                guardarcambios.TabIndex = 142;
                guardarcambios.UseVisualStyleBackColor = false;
                guardarcambios.Click += new EventHandler(ClickGuardarCambios);


                var unirseldas = new Button();


                unirseldas.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura13.png");
                unirseldas.Name = item.ClienteId.ToString();
                unirseldas.BackColor = System.Drawing.Color.White;
                unirseldas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                unirseldas.FlatAppearance.BorderSize = 0;
                unirseldas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                unirseldas.Size = new System.Drawing.Size(32, 34);
                unirseldas.TabIndex = 142;
                unirseldas.UseVisualStyleBackColor = false;


                var detalleclientes = new Button();



                detalleclientes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura14.png");
                detalleclientes.Name = item.ClienteId.ToString();
                detalleclientes.BackColor = System.Drawing.Color.White;
                detalleclientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                detalleclientes.FlatAppearance.BorderSize = 0;
                detalleclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                detalleclientes.Size = new System.Drawing.Size(32, 34);
                detalleclientes.TabIndex = 142;
                detalleclientes.Click += new EventHandler(ClickDetalleCliente);
                detalleclientes.UseVisualStyleBackColor = false;


                var Email = new Button();



                Email.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura15.png");
                Email.Name = item.ClienteId.ToString();
                Email.BackColor = System.Drawing.Color.White;
                Email.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                Email.FlatAppearance.BorderSize = 0;
                Email.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                Email.Size = new System.Drawing.Size(32, 34);
                Email.TabIndex = 142;
                Email.UseVisualStyleBackColor = false;

                var aumentocredito = new Button();



                aumentocredito.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura16.png");
                aumentocredito.Name = item.ClienteId.ToString();
                aumentocredito.BackColor = System.Drawing.Color.White;
                aumentocredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                aumentocredito.FlatAppearance.BorderSize = 0;
                aumentocredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                aumentocredito.Size = new System.Drawing.Size(32, 34);
                aumentocredito.TabIndex = 142;
                aumentocredito.UseVisualStyleBackColor = false;

                tableLayoutPanel1.Controls.Add(botonesdos);
                tableLayoutPanel1.Controls.Add(botonestres);
                tableLayoutPanel1.Controls.Add(botonescuatro);
                tableLayoutPanel1.Controls.Add(botonecinco);
                tableLayoutPanel1.Controls.Add(botonesseis);
                tableLayoutPanel1.Controls.Add(NuevaOrden);
                tableLayoutPanel1.Controls.Add(optenerordenes);
                tableLayoutPanel1.Controls.Add(guardarcambios);
                tableLayoutPanel1.Controls.Add(unirseldas);
                tableLayoutPanel1.Controls.Add(detalleclientes);
                tableLayoutPanel1.Controls.Add(Email);
                tableLayoutPanel1.Controls.Add(aumentocredito);


            }


            if (query.Count > 0)
            {

                // x = "";
                //dataGridView1.ClearSelection();

            }

        }
        void ClickTexbox1(object sender, KeyPressEventArgs e)
       {
            ClientePosicion = 1;
            if (e.KeyChar =='\b'){
                TextBox box = sender as TextBox;
                ClienteTex = box.Text;
                Clientename = int.Parse(box.Name);
                ClienteTex = ClienteTex.Remove(ClienteTex.Length - 1);
            }
           else if (e.KeyChar!=null)
            { 
                TextBox box = sender as TextBox;
            ClienteTex = box.Text+e.KeyChar;
            Clientename = int.Parse(box.Name);
     }
        }
        void ClickTexbox2(object sender, KeyPressEventArgs e)
        {
            ClientePosicion = 2;
            if (e.KeyChar == '\b')
            {
                TextBox box = sender as TextBox;
                ClienteTex = box.Text;
                Clientename = int.Parse(box.Name);
                ClienteTex = ClienteTex.Remove(ClienteTex.Length - 1);
            }
            else if (e.KeyChar != null)
            {
                TextBox box = sender as TextBox;
                ClienteTex = box.Text + e.KeyChar;
                Clientename = int.Parse(box.Name);
            }
        }
        void ClickTexbox5(object sender, KeyPressEventArgs e)
        {
            ClientePosicion = 5;
            if (e.KeyChar == '\b')
            {
                TextBox box = sender as TextBox;
                ClienteTex = box.Text;
                Clientename = int.Parse(box.Name);
                ClienteTex = ClienteTex.Remove(ClienteTex.Length - 1);
            }
            else if (e.KeyChar != null)
            {
                TextBox box = sender as TextBox;
                ClienteTex = box.Text + e.KeyChar;
                Clientename = int.Parse(box.Name);
            }
        }
        void ClickTexbox3(object sender, KeyPressEventArgs e)
        {
            ClientePosicion = 3;
            if (e.KeyChar == '\b')
            {
                TextBox box = sender as TextBox;
                ClienteTex = box.Text;
                Clientename = int.Parse(box.Name);
                ClienteTex = ClienteTex.Remove(ClienteTex.Length - 1);
            }
            else if (e.KeyChar != null)
            {
                TextBox box = sender as TextBox;
                ClienteTex = box.Text + e.KeyChar;
                Clientename = int.Parse(box.Name);
            }
        }
        void ClickTexbox4(object sender, KeyPressEventArgs e)
        {
            ClientePosicion = 4;
            if (e.KeyChar == '\b')
            {
                TextBox box = sender as TextBox;
                ClienteTex = box.Text;
                Clientename = int.Parse(box.Name);
                ClienteTex = ClienteTex.Remove(ClienteTex.Length - 1);
            }
            else if (e.KeyChar != null)
            {
                TextBox box = sender as TextBox;
                ClienteTex = box.Text + e.KeyChar;
                Clientename = int.Parse(box.Name);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
 {
            String x="";
         

            x =this.txtNombre.Text+e.KeyChar;
          
            if (e.KeyChar == '\b')
            {
                if (x.Length == 1)
                {
                    x = x.Remove(x.Length - 1);
                    BorrarPanel();
                }else
                { 
                x = x.Remove(x.Length - 2);
                    BorrarPanel();
                }
            }


            if (x != "")
            {
                BorrarPanel();
                CargarCliente(x);



            }
          
         
        }
        private void reportButton_Click()
        {
            DataGridViewImageColumn NuevaOrden = new DataGridViewImageColumn();
            NuevaOrden.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura10.png");

        }
        private void txtOrden_KeyPress(object sender, KeyPressEventArgs e)
        {

            string x = "";
            x = txtOrden.Text;
            if (x != "")
            {


                var query = db.Clientes.Where(j => j.Nombre.StartsWith(x.ToString())).Select(t => new { t.ClienteId, t.Abreviatura, t.TelefonoPrincipal, t.Nombre, t.Email, t.Notas }).ToList();


            }
         
        }

            private void PressClick(object sender, MouseEventArgs e)
        {
       
        }

        private void txtTelefono_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (txtTelefono.Text != "" && txtTelefono.Font.Italic == true)
                {
                    txtTelefono.Text = "";
                    txtTelefono.ForeColor = SystemColors.WindowText;
                    txtTelefono.Font = new Font(txtTelefono.Font, FontStyle.Regular);
                }
                else
                {
                    txtTelefono.ForeColor = SystemColors.WindowText;
                    txtTelefono.Font = new Font(txtTelefono.Font, FontStyle.Regular);
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name== "a" && e.RowIndex >= 0)
            //{
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            //    DataGridViewButtonCell cell = this.dataGridView1.Rows[e.RowIndex].Cells["a"] as DataGridViewButtonCell;
            //    Icon icono = new Icon(Environment.CurrentDirectory + @"C:\Users\Erickxon\Desktop\ccc\Iconos1\nuevo.ico");
            //    e.Graphics.DrawIcon(icono, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

            //    this.dataGridView1.Rows[e.RowIndex].Height = icono.Height + 8;
            //    this.dataGridView1.Columns[e.ColumnIndex].Width = icono.Width + 8;

            //    e.Handled = true;

            //}


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //   MessageBox.Show(e.ColumnIndex+"prueba"+e.RowIndex);

  

            if (e.ColumnIndex == 6) {
            //    int valor = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

           //    Form1 form = new Form1(valor);
             //   form.ShowDialog();
//
            }else if(e.ColumnIndex==7)
                
            {
                frmEmpleado empleado = new frmEmpleado();
                empleado.ShowDialog();

            }

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_MouseEnter(object sender, EventArgs e)
        {
          //  this.txtNombre.Text = "";
        }

        private void txtNombre_MouseLeave(object sender, EventArgs e)
        {

          //  this.txtNombre.Text = "Dijite su nombre";
        }

        private void txtNombre_MouseClick(object sender, MouseEventArgs e)
        {

           // this.txtNombre.Text = "";
        }
        void ClickNuevaOrden(object sender, EventArgs e)
        {

            this.Opacity = 0.90;
            Button btn = sender as Button;
            var id = int.Parse(btn.Name);
     
            var valor = id; 
         Form1 form = new Form1(valor,null);

       

            form.ShowDialog();

            this.Opacity = 1;
       
          
           

        }

        void ClickGuardarCambios(object sender, EventArgs e)
        {
            Cliente sucursal = db.Clientes.Find(Clientename);
            if (ClientePosicion == 1) { 
            sucursal.Abreviatura = ClienteTex;
            }
            if (ClientePosicion == 2)
            {
                sucursal.TelefonoPrincipal = ClienteTex;
            }
            if (ClientePosicion == 3)
            {
                sucursal.Nombre = ClienteTex;
            }
            if (ClientePosicion == 4)
            {
                sucursal.Email = ClienteTex;
            }
            if (ClientePosicion == 5)
            {
                sucursal.Notas = ClienteTex;
            }
           
            db.Entry(sucursal).State = EntityState.Modified;
            db.SaveChanges();


        }
        void ClickDetalleCliente(object sender, EventArgs e)
        {
            this.Opacity = 0.99;
            Button btn = sender as Button;
            var id = int.Parse(btn.Name);
            frmImformacionCliente frmImformacion = new frmImformacionCliente(id);
            frmImformacion.Location = new Point(0,50);
            frmImformacion.ShowDialog();
        }

        void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0 || e.Row == 8)
            {
                Graphics g = e.Graphics;
                Rectangle r = e.CellBounds;
                g.FillRectangle(Brushes.GreenYellow, r);
            }
        }

        void tableLayoutPanel1_CellPaintdos(object sender, PaintEventArgs e)
        {
            //TableLayoutPanel panel = sender as TableLayoutPanel;
            //var iddos = panel.Name;
            //Graphics g = e.Graphics;
            //RowStyle r = e.Dispose;
            //g.FillRectangles(Brushes.Aqua,r.);
            //  MessageBox.Show(iddos);
            // BackColor = Color.Gray;
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            this.txtTelefono.Text = "";
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            this.txtTelefono.Text = "Dijite Numero Teléfono";
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            this.txtNombre.Text = "Dijite Nombre Cliente";
        }

        private void txtOrden_Enter(object sender, EventArgs e)
        {
            this.txtOrden.Text = "";
        }

        private void txtOrden_Leave(object sender, EventArgs e)
        {
            this.txtOrden.Text = "Dijite Numero Orden";
        }

        private void btnHerramientas_Click(object sender, EventArgs e)
        {

            frmReportesCajasTotales registros = new frmReportesCajasTotales();
            registros.Location = new Point(0, 110);
            registros.ShowDialog();
        }
        private void BorrarPanel()
        {
            var totaldos = tableLayoutPanel1.Controls.Count;
            var litdos = tableLayoutPanel1.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.Controls[0]);
            }

        }
        void ClickRemoverPagos(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var id = int.Parse(btn.Text);

            var query = db.Pagos.Where(q => q.OrdenId == id).ToList();
            //Pagos pago = new Pagos();
            Pagos pago = query.FirstOrDefault();
            db.Entry(pago).State = EntityState.Deleted;
            //db.Pagos.Where(q => q.OrdenId == id).ToList();
           // db.Pagos.Remove(pago);
           db.SaveChanges();
           

        }
        void ClickImprimirOrden(object sender, EventArgs e)

        {
            Button btn = sender as Button;
            var id = int.Parse(btn.Text);


            ReporteImagen reporte = new ReporteImagen(id);
            reporte.ShowDialog();
            //FrmFactura frm = new FrmFactura(id);
            //frm.ShowDialog();
            // frmReporteFactura form = new frmReporteFactura(id);
            //form.ShowDialog();
            


            try
            {
            




            }
            catch (Exception)
            {

                throw;
            }
        }

        void ClickEditarOrden(object sender, EventArgs e)
         {
            Button btn = sender as Button;
            var id = int.Parse(btn.Text);
            Program.Editar = 1;
            Form1 form = new Form1(null,id);
            form.ShowDialog();
        }
        void ClickCompletarOrden(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var id = int.Parse(btn.Text);

            CompletarAgregarPago agregarPago = new CompletarAgregarPago(id);
            this.Opacity = 0.80;
            agregarPago.ShowDialog();
            this.Opacity = 1;

        }
        private void BorrarPanelOrdenes()
        {
            var totaldos = tlpOrdenesClientes.Controls.Count;
            var litdos = tlpOrdenesClientes.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tlpOrdenesClientes.Controls.Remove(tlpOrdenesClientes.Controls[0]);
            }

        }
        void ClickCargarOrdenTotal(int Id)
        {
            BorrarPanelOrdenes();

            listaTareas = new List<OrdenDetalleViewModel>();
            listaPrendas = new List<OrdenPrendaViewModel>();

           
            var id = Id;


            var Colores = true;

            rowCount = 0;

            var query = db.Ordenes.Where(q => q.ClienteId == id).ToList();



            foreach (var itemdos in query)

            {


                var orden = db.Ordenes.Find(itemdos.OrdenId);
              
              
                    foreach (var prenda in orden.Prendas)

                    {
                        var panelViewPrenda = new OrdenPrendaViewModel(string.Empty);




                        panelViewPrenda.panelPrenda.Click += new EventHandler(ClickCargarOrdenSinCompletar);
                        panelViewPrenda.panelPrenda.Name = prenda.DetalleOrdenPrendaId.ToString();
                        panelViewPrenda.panelPrenda.Size = new Size(1380, 30);
                        panelViewPrenda.lblPrenda.Text = prenda.Prenda.TipoRopa.ToString() + "X" + prenda.Cantidad;





                        panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.lblPrenda);

                    panelViewPrenda.btnagregartarea.Text = prenda.OrdenId.ToString();
                    panelViewPrenda.btnagregartarea.Location = new Point(1308, 0);
                    panelViewPrenda.btnagregartarea.Click += new EventHandler(ClickImprimirOrden);
                    panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.btnagregartarea);

                    panelViewPrenda.btncompletarOrden.Text = prenda.OrdenId.ToString();
                    panelViewPrenda.btncompletarOrden.Click += new EventHandler(ClickCompletarOrden);
                    panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.btncompletarOrden);

                    listaPrendas.Add(panelViewPrenda);
                        rowCount += 1;
                        tlpOrdenesClientes.RowCount = rowCount;
                        this.tlpOrdenesClientes.Controls.Add(listaPrendas.Last().panelPrenda, 0, rowCount);

                        foreach (var tarea in prenda.DetalleTareas)
                        {

                            var panelViewTarea = new OrdenDetalleViewModel(string.Empty, string.Empty, 0);

              

                        panelViewTarea.panelTarea.Click += new EventHandler(ClickCargarOrdenSinCompletar);
                            panelViewTarea.panelTarea.MouseEnter += new EventHandler(MouseoverDos);
                            panelViewTarea.panelTarea.MouseLeave += new EventHandler(MouseleaveDos);
                            panelViewTarea.panelTarea.Size = new Size(1380, 30);
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
                      


                        panelViewTarea.lblTarea.Location = new Point(80, 10);
                        panelViewTarea.lblTarea.Size = new Size(110, 45);
                        panelViewTarea.lblTarea.Size = new System.Drawing.Size(115, 45);
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblTarea);

                            panelViewTarea.lblDetalleTarea.Text = tarea.Detalle.DetalleTareas.ToString();
                        panelViewTarea.lblDetalleTarea.Location = new Point(200, 10);
                        panelViewTarea.lblDetalleTarea.Size = new System.Drawing.Size(150, 34);
                           panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDetalleTarea);

                            panelViewTarea.lblPrecio.Text = tarea.Detalle.Precio.ToString();
                        panelViewTarea.lblPrecio.Location = new Point(400, 10);
                        panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblPrecio);

                        panelViewTarea.txtTotalPrecio.Text = (tarea.Descuento).ToString() + "%";

                        panelViewTarea.txtTotalPrecio.Location = new Point(600, 10);
                        panelViewTarea.panelTarea.Controls.Add(panelViewTarea.txtTotalPrecio);

                        panelViewTarea.lblSubTotal.Text = (tarea.Subtotal).ToString();

                        panelViewTarea.lblSubTotal.Location = new Point(800, 10);
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
                        panelViewTarea.lblAfiliado.Location = new Point(1100, 10);
                        panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblAfiliado);

                        panelViewTarea.lblDescripcion.Text = (tarea.Descripcion).ToString();
                        panelViewTarea.lblDescripcion.Location = new Point(915, 10);
                        panelViewTarea.lblDescripcion.Size = new Size(150, 34);
                       

                        panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDescripcion);

                        listaTareas.Add(panelViewTarea);
                            rowCount += 1;
                            tlpOrdenesClientes.RowCount = rowCount;
                            this.tlpOrdenesClientes.Controls.Add(listaTareas.Last().panelTarea, 0, rowCount);
                        }





                    }
                

            }

        }
        void ClickCargarOrdenSinCompletar(object sender, EventArgs e)
        {

            BorrarPanelOrdenes();

            listaTareas = new List<OrdenDetalleViewModel>();
            listaPrendas = new List<OrdenPrendaViewModel>();

            Button btn = sender as Button;
            var id = int.Parse(btn.Name);
            IdOrden = id;
           
            var Colores = true;

            rowCount = 0;
            
            var query = db.Ordenes.Where(q => q.ClienteId == id).ToList();
            if (query.Count > 0&&query.FirstOrDefault().Pagos.Count>0)
            {
                var resultado = query.FirstOrDefault().Pagos.FirstOrDefault().Monto;
                lblTotalOrdenes.Text = resultado.ToString();
                var idDetale = query.FirstOrDefault().Prendas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleOrdenesId;
                var detallesO = db.OrdenDetalleTareas.Find(idDetale).Subtotal;
            }

            

            foreach (var itemdos in query)

            {
                
               
                var orden = db.Ordenes.Find(itemdos.OrdenId);
                var  idDetaleOrden = orden.Prendas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleOrdenesId;
                var detallesOrden = db.OrdenDetalleTareas.Find(idDetaleOrden);
                
                if (detallesOrden.Estado==false)
                {
                    foreach (var prenda in orden.Prendas)

                    {
                        var panelViewPrenda = new OrdenPrendaViewModel(string.Empty);




                        panelViewPrenda.panelPrenda.Click += new EventHandler(ClickCargarOrdenSinCompletar);
                        panelViewPrenda.panelPrenda.Name = prenda.DetalleOrdenPrendaId.ToString();
                        panelViewPrenda.panelPrenda.Size = new Size(1380, 30);
                        panelViewPrenda.lblPrenda.Text = prenda.Prenda.TipoRopa.ToString() + "X" + prenda.Cantidad;



                        panelViewPrenda.btncompletarOrden.Text = prenda.OrdenId.ToString();//1345, 0
                        panelViewPrenda.btncompletarOrden.Click += new EventHandler(ClickCompletarOrden);
                        panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.btncompletarOrden);

                        panelViewPrenda.btnPrioridad.Text = prenda.OrdenId.ToString();
                        panelViewPrenda.btnPrioridad.Location = new Point(1234, 0);
                        panelViewPrenda.btnPrioridad.Click += new EventHandler(ClickEditarOrden);
                        panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.btnPrioridad);

                        panelViewPrenda.btnCantidad.Text = prenda.OrdenId.ToString();
                        panelViewPrenda.btnCantidad.Location = new Point(1271, 0);
                        panelViewPrenda.btnCantidad.Click += new EventHandler(ClickRemoverPagos);
                        panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.btnCantidad);

                        panelViewPrenda.btnagregartarea.Text = prenda.OrdenId.ToString();
                        panelViewPrenda.btnagregartarea.Location = new Point(1308, 0);
                        panelViewPrenda.btnagregartarea.Click += new EventHandler(ClickImprimirOrden);
                        panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.btnagregartarea);


                        panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.lblPrenda);

                        listaPrendas.Add(panelViewPrenda);
                        rowCount += 1;
                        tlpOrdenesClientes.RowCount = rowCount;
                        this.tlpOrdenesClientes.Controls.Add(listaPrendas.Last().panelPrenda, 0, rowCount);

                        foreach (var tarea in prenda.DetalleTareas)
                        {

                            var panelViewTarea = new OrdenDetalleViewModel(string.Empty, string.Empty, 0);



                            panelViewTarea.panelTarea.Click += new EventHandler(ClickCargarOrdenSinCompletar);
                            panelViewTarea.panelTarea.Size = new Size(1380, 30);
                            panelViewTarea.panelTarea.MouseEnter += new EventHandler(MouseoverDos);
                            panelViewTarea.panelTarea.MouseLeave += new EventHandler(MouseleaveDos);
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

                            panelViewTarea.lblTarea.Location = new Point(80, 10);
                            panelViewTarea.lblTarea.Size = new Size(110, 45);
                          
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblTarea);

                            panelViewTarea.lblDetalleTarea.Text = tarea.Detalle.DetalleTareas.ToString();
                           
                            panelViewTarea.lblDetalleTarea.Location = new Point(200, 10);
                            panelViewTarea.lblDetalleTarea.Size = new System.Drawing.Size(150, 34);
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDetalleTarea);

                            panelViewTarea.lblPrecio.Text = tarea.Detalle.Precio.ToString();
                            
                            panelViewTarea.lblPrecio.Location = new Point(400, 10);
                       
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblPrecio);

                            panelViewTarea.txtTotalPrecio.Text = ( tarea.Descuento).ToString()+"%";
                            
                            panelViewTarea.txtTotalPrecio.Location = new Point(600, 10);
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.txtTotalPrecio);

                            panelViewTarea.lblSubTotal.Text = (tarea.Subtotal).ToString();
                            
                            panelViewTarea.lblSubTotal.Location = new Point(800, 10);
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
                           
                           
                            panelViewTarea.lblAfiliado.Location = new Point(1100, 10);
                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblAfiliado);

                            panelViewTarea.lblDescripcion.Text = (tarea.Descripcion).ToString();
                            panelViewTarea.lblDescripcion.Location = new Point(915, 10);
                            panelViewTarea.lblDescripcion.Size = new Size(150, 34);
                          

                            panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDescripcion);
                            listaTareas.Add(panelViewTarea);
                            rowCount += 1;
                            tlpOrdenesClientes.RowCount = rowCount;
                            this.tlpOrdenesClientes.Controls.Add(listaTareas.Last().panelTarea, 0, rowCount);
                        }





                    }
                }

            }

        }


        void MouseoverDos(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
            ColorEntrada = btr.BackColor;
        



            object id = btr.Name;
         
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;



        }
        void MouseleaveDos(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;




        

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        void ClickCambiarEstadoTarea(object sender, EventArgs e)
        {
            frmPin pin = new frmPin();
            this.Opacity = 0.80;
            pin.ShowDialog();
            this.Opacity = 1;
            if (Program.Pin != null)
            {
                var Mensaje = MessageBox.Show("Esta Seguro desea Completar Orden", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Mensaje == DialogResult.Yes)
                {
                    Button btn = sender as Button;
                    var id = int.Parse(btn.Text);

                    var detallesOrden = db.OrdenDetalleTareas.Find(id);
                    var orden = db.Ordenes.Find(detallesOrden.Prenda.OrdenId);
                    detallesOrden.Estado = true;
                    detallesOrden.EmpleadoActualizo = Program.Pin;
                    orden.EmpleadoActualizo = Program.Pin;
                    orden.EmpleadoCompleto = Program.Pin;
                    db.SaveChanges();
                    var panelTarea = listaTareas.Where(m => m.DetalleOrdenesId == detallesOrden.DetalleOrdenesId).FirstOrDefault();
                    panelTarea.btnEstado.BackColor = Color.OliveDrab;

                }
            }
        }

        private void ckbOrdenesCompletadas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbOrdenesCompletadas.Checked == true) { 
          
            var id = IdOrden;


            ClickCargarOrdenTotal(id);
            }
            else { BorrarPanelOrdenes(); }
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

        private void button31_MouseDown(object sender, MouseEventArgs e)
        {

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

        private void button35_MouseHover(object sender, EventArgs e)
        {

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

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button21_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button21_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button18_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button15_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button16_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button20_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button20_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button19_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button19_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pvBuscarOrden_Click(object sender, EventArgs e)
        {
            

         var NombreCliente=  db.Ordenes.Find(int.Parse(txtOrden.Text)).Cliente.Nombre;
            var IdCliente= db.Ordenes.Find(int.Parse(txtOrden.Text)).Cliente.ClienteId;
            ClickCargarOrdenTotal(IdCliente);
            CargarCliente(NombreCliente);
        }
        //void PruebaClick_2(object sender, EventArgs e)
        //{
        //    Button btn = sender as Button;

        //    if (e.ColumnIndex == 5)
        //    {
        //        string j = e;
        //        Form1 form = new Form1();
        //        form.ShowDialog();

        //        MessageBox.Show(e.RowIndex + "Prueba" + e.ColumnIndex);

        //    }
        //    if (e.ColumnIndex == 6)
        //    {
        //        MessageBox.Show(e.RowIndex + "Prueba" + e.ColumnIndex);

        //    }
        //    if (e.ColumnIndex == 7)
        //    {
        //        MessageBox.Show(e.RowIndex + "Prueba" + e.ColumnIndex);

        //    }
        //}
    }
}
