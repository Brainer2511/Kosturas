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
            //Close();
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
            try
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
            catch (Exception)
            {

            }

         
               

          
            
            
        }

        private void CargarCliente(string texbox)
        {

            try
            {
                var query = db.Clientes.Where(j => j.Nombre.Contains(texbox.ToString())).Select(t => new { t.ClienteId, t.Abreviatura, t.TelefonoPrincipal, t.Nombre, t.Email }).ToList();

                foreach (var item in query)

                {



                    var botonesdos = new TextBox();
                    botonesdos.Size = new Size(80, 30);
                    botonesdos.Multiline = true;


                    botonesdos.Text = item.Abreviatura;


                    botonesdos.Name = item.ClienteId.ToString();
                    botonesdos.KeyPress += new KeyPressEventHandler(ClickTexbox1);

                    botonesdos.BorderStyle = System.Windows.Forms.BorderStyle.None;

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
            }
            catch (Exception)
            {

            }

            
      
        

            
             
         }
        private void CargarClienteIdOrden(string texbox)
        {


            try
            {
                var query = db.Clientes.Where(j => j.Nombre == (texbox.ToString())).Select(t => new { t.ClienteId, t.Abreviatura, t.TelefonoPrincipal, t.Nombre, t.Email }).ToList();

                foreach (var item in query)

                {



                    var botonesdos = new TextBox();
                    botonesdos.Size = new Size(80, 30);
                    botonesdos.Multiline = true;


                    botonesdos.Text = item.Abreviatura;


                    botonesdos.Name = item.ClienteId.ToString();
                    botonesdos.KeyPress += new KeyPressEventHandler(ClickTexbox1);

                    botonesdos.BorderStyle = System.Windows.Forms.BorderStyle.None;

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
            }
            catch (Exception)
            {

              
            }

          


         

        }
        private void CargarClienteTelefono(string texbox)
        {

            try
            {
                var query = db.Clientes.Where(j => j.TelefonoPrincipal.Contains(texbox.ToString())).Select(t => new { t.ClienteId, t.Abreviatura, t.TelefonoPrincipal, t.Nombre, t.Email, t.Direcion }).ToList();

                foreach (var item in query)

                {



                    var botonesdos = new TextBox();

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
            }
            catch (Exception)
            {

               
            }

        


          

        }
        void ClickTexbox1(object sender, KeyPressEventArgs e)
       {
            try
            {
                ClientePosicion = 1;
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
            catch (Exception)
            {

            }
    
        }
        void ClickTexbox2(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception)
            {

              
            }

           
        }
        void ClickTexbox5(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception)
            {

            }

         
        }
        void ClickTexbox3(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception)
            {

            }


        }
        void ClickTexbox4(object sender, KeyPressEventArgs e)
        {

            try
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
            catch (Exception)
            {

            }

        
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
 {

            try
            {
                String x = "";


                x = this.txtNombre.Text + e.KeyChar;

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
                    CargarCliente(x);



                }
            }
            catch (Exception)
            {

                
            }
          
          
         
        }
        private void reportButton_Click()
        {
            DataGridViewImageColumn NuevaOrden = new DataGridViewImageColumn();
            NuevaOrden.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura10.png");

        }
        private void txtOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {


                    var IdOrden = (int.Parse(txtOrden.Text));
                    var Query = db.Ordenes.Where(q => q.OrdenId == IdOrden).ToList();
                    if (Query.Count == 0)
                    {
                        BorrarPanel();
                        BorrarPanelOrdenes();
                    }
                    if (Query.Count > 0)
                    {
                        var NombreCliente = db.Ordenes.Find(int.Parse(txtOrden.Text)).Cliente.Nombre;
                        ClickCargarOrdenIdOrden(int.Parse(txtOrden.Text));
                        CargarClienteIdOrden(NombreCliente);
                    }

                }
            }
            catch (Exception)
            {
                
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



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

  

            if (e.ColumnIndex == 6) {
       
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
            try
            {
                Cliente sucursal = db.Clientes.Find(Clientename);
                if (ClientePosicion == 1)
                {
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
                    sucursal.Direcion = ClienteTex;
                }

                db.Entry(sucursal).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

            }

           


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
            try
            {
                Button btn = sender as Button;
                var id = int.Parse(btn.Text);

                var query = db.Pagos.Where(q => q.OrdenId == id).ToList();

                Pagos pago = query.FirstOrDefault();
                db.Entry(pago).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception)
            {

              
            }
           
           

        }
        void ClickImprimirOrden(object sender, EventArgs e)

        {

            try
            {
                Button btn = sender as Button;
                var id = int.Parse(btn.Text);

                var idDetalle = db.OrdenDetallePrendas.Where(q => q.DetalleOrdenPrendaId == id).FirstOrDefault().OrdenId;

                ReporteImagen reporte = new ReporteImagen(idDetalle, id);
                reporte.ShowDialog();
                //FrmFactura frm = new FrmFactura(idDetalle);
                //frm.ShowDialog();
                //frmReporteFactura form = new frmReporteFactura(id);
                //form.ShowDialog();
                //otro otro = new otro(idDetalle, id);
                //otro.ShowDialog();
                //Form2 otros = new Form2(idDetalle, id);
                //otros.ShowDialog();
            }
            catch (Exception)
            {

               
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
            try
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
                        if (query.FirstOrDefault().EstadoId == 6)
                        {
                            panelViewPrenda.panelPrenda.BackColor = Color.Gray;
                            panelViewPrenda.btncompletarOrden.BackColor = Color.Gray;
                            panelViewPrenda.btnPrioridad.BackColor = Color.Gray;
                            panelViewPrenda.btnCantidad.BackColor = Color.Gray;
                            panelViewPrenda.btnagregartarea.BackColor = Color.Gray;
                        }
                        if (query.FirstOrDefault().EstadoId == 5)
                        {
                            panelViewPrenda.panelPrenda.BackColor = Color.Lime;
                            panelViewPrenda.btncompletarOrden.BackColor = Color.Lime;
                            panelViewPrenda.btnPrioridad.BackColor = Color.Lime;
                            panelViewPrenda.btnCantidad.BackColor = Color.Lime;
                            panelViewPrenda.btnagregartarea.BackColor = Color.Lime;
                        }
                        if (query.FirstOrDefault().EstadoId == 1)
                        {
                            panelViewPrenda.panelPrenda.BackColor = Color.Blue;
                            panelViewPrenda.btncompletarOrden.BackColor = Color.Blue;
                            panelViewPrenda.btnPrioridad.BackColor = Color.Blue;
                            panelViewPrenda.btnCantidad.BackColor = Color.Blue;
                            panelViewPrenda.btnagregartarea.BackColor = Color.Blue;
                        }

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
            catch (Exception)
            {

            }

         

        }
        void ClickCargarOrdenIdOrden(int Id)
        {
            try
            {
                BorrarPanel();
                BorrarPanelOrdenes();

                listaTareas = new List<OrdenDetalleViewModel>();
                listaPrendas = new List<OrdenPrendaViewModel>();


                var id = Id;


                var Colores = true;

                rowCount = 0;

                var query = db.Ordenes.Where(q => q.OrdenId == id).ToList();


                lblTotalOrdenes.Text = query.Sum(q => q.TotalOrden).ToString();
                foreach (var itemdos in query)

                {


                    var orden = db.Ordenes.Find(itemdos.OrdenId);


                    foreach (var prenda in orden.Prendas)

                    {
                        var panelViewPrenda = new OrdenPrendaViewModel(string.Empty);




                        panelViewPrenda.panelPrenda.Click += new EventHandler(ClickCargarOrdenSinCompletar);
                        panelViewPrenda.panelPrenda.Name = prenda.DetalleOrdenPrendaId.ToString();

                        if (query.FirstOrDefault().EstadoId == 6)
                        {
                            panelViewPrenda.panelPrenda.BackColor = Color.Gray;
                            panelViewPrenda.btncompletarOrden.BackColor = Color.Gray;
                            panelViewPrenda.btnPrioridad.BackColor = Color.Gray;
                            panelViewPrenda.btnCantidad.BackColor = Color.Gray;
                            panelViewPrenda.btnagregartarea.BackColor = Color.Gray;
                        }
                        if (query.FirstOrDefault().EstadoId == 5)
                        {
                            panelViewPrenda.panelPrenda.BackColor = Color.Lime;
                            panelViewPrenda.btncompletarOrden.BackColor = Color.Lime;
                            panelViewPrenda.btnPrioridad.BackColor = Color.Lime;
                            panelViewPrenda.btnCantidad.BackColor = Color.Lime;
                            panelViewPrenda.btnagregartarea.BackColor = Color.Lime;
                        }
                        if (query.FirstOrDefault().EstadoId == 1)
                        {
                            panelViewPrenda.panelPrenda.BackColor = Color.Blue;
                            panelViewPrenda.btncompletarOrden.BackColor = Color.Blue;
                            panelViewPrenda.btnPrioridad.BackColor = Color.Blue;
                            panelViewPrenda.btnCantidad.BackColor = Color.Blue;
                            panelViewPrenda.btnagregartarea.BackColor = Color.Blue;
                        }

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

                        panelViewPrenda.btnPrioridad.Text = prenda.OrdenId.ToString();
                        panelViewPrenda.btnPrioridad.Location = new Point(1234, 0);
                        panelViewPrenda.btnPrioridad.Click += new EventHandler(ClickEditarOrden);
                        panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.btnPrioridad);

                        panelViewPrenda.btnCantidad.Text = prenda.OrdenId.ToString();
                        panelViewPrenda.btnCantidad.Image= Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Pago.png");
                        panelViewPrenda.btnCantidad.Location = new Point(1271, 0);
                        panelViewPrenda.btnCantidad.Click += new EventHandler(ClickRemoverPagos);
                        panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.btnCantidad);

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
            catch (Exception)
            {

            }

          

        }
        void ClickCargarOrdenSinCompletar(object sender, EventArgs e)
        {
            try
            {


                using (DataContextLocal cd=new DataContextLocal())
                {
                    BorrarPanelOrdenes();

                    listaTareas = new List<OrdenDetalleViewModel>();
                    listaPrendas = new List<OrdenPrendaViewModel>();

                    Button btn = sender as Button;
                    var id = int.Parse(btn.Name);
                    IdOrden = id;

                    var Colores = true;

                    rowCount = 0;

                    var query = cd.Ordenes.Where(q => q.ClienteId == id).ToList();
                    if (query.Count > 0 && query.FirstOrDefault().Pagos.Count > 0)
                    {
                        var resultado = query.FirstOrDefault().Pagos.FirstOrDefault().Monto;
                        lblTotalOrdenes.Text = resultado.ToString();
                        var idDetale = query.FirstOrDefault().Prendas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleOrdenesId;
                        var detallesO = cd.OrdenDetalleTareas.Find(idDetale).Subtotal;
                    }



                    foreach (var itemdos in query)

                    {


                        var orden = cd.Ordenes.Find(itemdos.OrdenId);
                        var idDetaleOrden = orden.Prendas.FirstOrDefault().DetalleTareas.FirstOrDefault().DetalleOrdenesId;
                        var detallesOrden = cd.OrdenDetalleTareas.Find(idDetaleOrden);

                        if (detallesOrden.Estado == false)
                        {
                            foreach (var prenda in orden.Prendas)

                            {
                                var panelViewPrenda = new OrdenPrendaViewModel(string.Empty);




                                panelViewPrenda.panelPrenda.Click += new EventHandler(ClickCargarOrdenSinCompletar);
                                panelViewPrenda.panelPrenda.Name = prenda.DetalleOrdenPrendaId.ToString();
                                if (query.FirstOrDefault().EstadoId == 6)
                                {
                                    panelViewPrenda.panelPrenda.BackColor = Color.Gray;
                                    panelViewPrenda.btncompletarOrden.BackColor = Color.Gray;
                                    panelViewPrenda.btnPrioridad.BackColor = Color.Gray;
                                    panelViewPrenda.btnCantidad.BackColor = Color.Gray;
                                    panelViewPrenda.btnagregartarea.BackColor = Color.Gray;
                                }
                                if (query.FirstOrDefault().EstadoId == 5)
                                {
                                    panelViewPrenda.panelPrenda.BackColor = Color.Lime;
                                    panelViewPrenda.btncompletarOrden.BackColor = Color.Lime;
                                    panelViewPrenda.btnPrioridad.BackColor = Color.Lime;
                                    panelViewPrenda.btnCantidad.BackColor = Color.Lime;
                                    panelViewPrenda.btnagregartarea.BackColor = Color.Lime;
                                }
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
                                panelViewPrenda.btnCantidad.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Pago.png");

                                panelViewPrenda.btnCantidad.Location = new Point(1271, 0);
                                panelViewPrenda.btnCantidad.Click += new EventHandler(ClickRemoverPagos);
                                panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.btnCantidad);

                                panelViewPrenda.btnagregartarea.Text = prenda.DetalleOrdenPrendaId.ToString();
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

                                    panelViewTarea.txtTotalPrecio.Text = (tarea.Descuento).ToString() + "%";

                                    panelViewTarea.txtTotalPrecio.Location = new Point(600, 10);
                                    panelViewTarea.panelTarea.Controls.Add(panelViewTarea.txtTotalPrecio);

                                    panelViewTarea.lblSubTotal.Text = (tarea.Subtotal).ToString();

                                    panelViewTarea.lblSubTotal.Location = new Point(800, 10);
                                    panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblSubTotal);
                                    if (tarea.AfiliadoId > 0)
                                    {
                                        var nombre = cd.Afiliados.Find(tarea.AfiliadoId);
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
            }
            catch (Exception)
            {


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
            try
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
            catch (Exception)
            {

                
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
            try
            {
                var IdOrden = (int.Parse(txtOrden.Text));
                var Query = db.Ordenes.Where(q => q.OrdenId == IdOrden).ToList();
                if (Query.Count == 0)
                {
                    BorrarPanel();
                    BorrarPanelOrdenes();
                }
                if (Query.Count > 0)
                {
                    var NombreCliente = db.Ordenes.Find(int.Parse(txtOrden.Text)).Cliente.Nombre;
                    ClickCargarOrdenIdOrden(int.Parse(txtOrden.Text));
                    CargarClienteIdOrden(NombreCliente);
                }
            }
            catch (Exception)
            {

                
            }

     
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {

            frmNuevaVenta form = new frmNuevaVenta();
            this.Opacity = 0.80;

            form.ShowDialog();
            this.Opacity = 1;
        }
      
    }
}
