using Kosturas.Model;
using Kosturas.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kosturas
{
    public partial class frmPrincipal : Form
    {

        DataContextLocal db = new DataContextLocal();
        public int ClienteId { get; set; }

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
            DataGridViewImageColumn NuevaOrden = new DataGridViewImageColumn();
            NuevaOrden.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura10.png");

     
          





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
            
          //  this.Opacity = 0.90;
            frmEmpleado empleado=new frmEmpleado();
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
            int a = 0;
            Form1 form = new Form1(a);
            form.ShowDialog();
        }

        private void btnConfirguracion_Click(object sender, EventArgs e)
        {
            frmMantenimientos mantenimientos = new frmMantenimientos();
            mantenimientos.ShowDialog();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";
            x = txtTelefono.Text;
            if (x != "")
            {


                var query = db.Clientes.Where(j => j.TelefonoPrincipal.StartsWith(x.ToString())).Select(t => new { t.ClienteId, t.Abreviatura, t.TelefonoPrincipal, t.Nombre, t.Email, t.Notas }).ToList();



              //  dataGridView1.DataSource = query;
                //DataGridViewImageColumn NuevaOrden = new DataGridViewImageColumn();
                //NuevaOrden.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura10.png");
            
                //dataGridView1.Columns.Add(NuevaOrden);

                //DataGridViewImageColumn ObtenerOrdenesClientes = new DataGridViewImageColumn();
                //ObtenerOrdenesClientes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura11.png");
                //dataGridView1.Columns.Add(ObtenerOrdenesClientes);

                //DataGridViewImageColumn GuardarCambios = new DataGridViewImageColumn();
                //GuardarCambios.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura12.png");
                //dataGridView1.Columns.Add(GuardarCambios);

                //DataGridViewImageColumn dos = new DataGridViewImageColumn();
                //dos.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura13.png");
                //dataGridView1.Columns.Add(dos);

                //DataGridViewImageColumn detalleClientes = new DataGridViewImageColumn();
                //detalleClientes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura14.png");
                //dataGridView1.Columns.Add(detalleClientes);

                //DataGridViewImageColumn EnviarCorreo = new DataGridViewImageColumn();
                //EnviarCorreo.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura15.png");
                //dataGridView1.Columns.Add(EnviarCorreo);

                //DataGridViewImageColumn AumentoCredito = new DataGridViewImageColumn();
                //AumentoCredito.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\Captura16.png");
                //dataGridView1.Columns.Add(AumentoCredito);

              }
               

          
            
            
        }

        private void CargarCliente(string texbox)
        {


            TableLayoutPanel Table = new TableLayoutPanel();
            Table.AutoScroll = true;
            Table.Location = new Point(1, 108);
            Table.Size = new Size(1120, 244);

            Table.Name = "Cliente";

            Table.ColumnCount = 12;

            // Table.RowCount = 10;

            var d = 0;
            var f = 0;
            var o = 0;
            var query = db.Clientes.Where(j => j.Nombre.StartsWith(texbox.ToString())).Select(t => new { t.ClienteId, t.Abreviatura, t.TelefonoPrincipal, t.Nombre, t.Email, t.Notas }).ToList();

            foreach (var item in query)
            {



                var botonesdos = new TextBox();
                botonesdos.Text = item.Abreviatura;
                botonesdos.Name = item.Abreviatura;
                botonesdos.Multiline = true;
                botonesdos.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonesdos.Size = new System.Drawing.Size(131, 34);
                botonesdos.TabIndex = 143;

                var botonestres = new TextBox();
                botonestres.Text = item.TelefonoPrincipal;
                botonestres.Name = item.TelefonoPrincipal;
                botonestres.Multiline = true;
                botonestres.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonestres.Size = new System.Drawing.Size(131, 34);
                botonestres.TabIndex = 143;
                var botonescuatro = new TextBox();
                botonescuatro.Text = item.Nombre;
                botonescuatro.Name = item.Nombre;
                botonescuatro.Multiline = true;
                botonescuatro.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonescuatro.Size = new System.Drawing.Size(131, 34);
                botonescuatro.TabIndex = 143;

                var botonecinco = new TextBox();
                botonecinco.Text = item.Email;
                botonecinco.Name = item.Email;
                botonecinco.Multiline = true;
                botonecinco.BorderStyle = System.Windows.Forms.BorderStyle.None;
                botonecinco.Size = new System.Drawing.Size(131, 34);
                botonecinco.TabIndex = 143;

                var botonesseis = new TextBox();
                botonesseis.Text = item.Notas;
                botonesseis.Name = item.Notas;
                botonesseis.Multiline = true;
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

                Table.Controls.Add(botonesdos);
                Table.Controls.Add(botonestres);
                Table.Controls.Add(botonescuatro);
                Table.Controls.Add(botonecinco);
                Table.Controls.Add(botonesseis);
                Table.Controls.Add(NuevaOrden);
                Table.Controls.Add(optenerordenes);
                Table.Controls.Add(guardarcambios);
                Table.Controls.Add(unirseldas);
                Table.Controls.Add(detalleclientes);
                Table.Controls.Add(Email);
                Table.Controls.Add(aumentocredito);
                //      d = +d + 100;
                //    f += f + 50;

            }
            this.Controls.Add(Table);

            if (query.Count > 0)
            {

               // x = "";
                //dataGridView1.ClearSelection();

            }
             
         }
            private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
       {
            string x;

            x =txtNombre.Text;



            if (x != "")
            {
                CargarCliente(x);



            }
            else {
             //   txtNombre_KeyPress(sender, e);
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



            //    dataGridView1.DataSource = query;
                reportButton_Click();

            }
          //  dataGridView1.Clear();
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
            Button btn = sender as Button;
            var id = int.Parse(btn.Name);
     
            var valor = id; 
         Form1 form = new Form1(valor);
            form.ShowDialog();


        }

        void ClickGuardarCambios(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var id = int.Parse(btn.Name);

            TableLayoutPanel table = sender as TableLayoutPanel;
            var iddos = int.Parse(table.Name);

            var valor = id;
            Form1 form = new Form1(valor);
            form.ShowDialog();


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
