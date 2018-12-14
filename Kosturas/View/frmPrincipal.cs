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
          
            //from c in dc.Organization
            //where SqlMethods.Like(c.Hierarchy, "%/12/%")
            //select *;

            //var clientes = db.Clientes.ToList();

            //foreach (var item in clientes)
            //{
            //    ListViewItem datos = new ListViewItem();

            //    datos = listView1.Items.Add(item.ClienteId.ToString());
            //    datos.SubItems.Add(item.Nombre);
            //}






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



                dataGridView1.DataSource = query;
                DataGridViewImageColumn NuevaOrden = new DataGridViewImageColumn();
                NuevaOrden.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\ayudados.jpg");
            
                dataGridView1.Columns.Add(NuevaOrden);

                DataGridViewImageColumn ObtenerOrdenesClientes = new DataGridViewImageColumn();
                ObtenerOrdenesClientes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\recargar.png");
                dataGridView1.Columns.Add(ObtenerOrdenesClientes);

                DataGridViewImageColumn GuardarCambios = new DataGridViewImageColumn();
                GuardarCambios.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\save.png");
                dataGridView1.Columns.Add(GuardarCambios);

                DataGridViewImageColumn dos = new DataGridViewImageColumn();
                dos.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\archivo flcha.png");
                dataGridView1.Columns.Add(dos);

                DataGridViewImageColumn detalleClientes = new DataGridViewImageColumn();
                detalleClientes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\ayuda.png");
                dataGridView1.Columns.Add(detalleClientes);

                DataGridViewImageColumn EnviarCorreo = new DataGridViewImageColumn();
                EnviarCorreo.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\abrir msj.png");
                dataGridView1.Columns.Add(EnviarCorreo);

                DataGridViewImageColumn AumentoCredito = new DataGridViewImageColumn();
                AumentoCredito.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\recargar.png");
                dataGridView1.Columns.Add(AumentoCredito);

                DataGridViewImageColumn ClienteMesu = new DataGridViewImageColumn();
                ClienteMesu.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\tarjeta.png");
                dataGridView1.Columns.Add(ClienteMesu);
            }
               

          
            
            
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            
            string x = "";
            x = txtNombre.Text;
            if (x!=""){ 
          
          
            var query = db.Clientes.Where(j => j.Nombre.StartsWith(x.ToString())).Select(t => new { t.ClienteId,t.Abreviatura, t.TelefonoPrincipal, t.Nombre, t.Email, t.Notas }).ToList();
 

        
            dataGridView1.DataSource = query;
                DataGridViewImageColumn NuevaOrden = new DataGridViewImageColumn();
                NuevaOrden.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\nuevo +.png");

                dataGridView1.Columns.Add(NuevaOrden);

                DataGridViewImageColumn ObtenerOrdenesClientes = new DataGridViewImageColumn();
                ObtenerOrdenesClientes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\recargar.png");
                dataGridView1.Columns.Add(ObtenerOrdenesClientes);

                DataGridViewImageColumn GuardarCambios = new DataGridViewImageColumn();
                GuardarCambios.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\save.png");
                dataGridView1.Columns.Add(GuardarCambios);

                DataGridViewImageColumn dos = new DataGridViewImageColumn();
                dos.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\archivo flcha.png");
                dataGridView1.Columns.Add(dos);

                DataGridViewImageColumn detalleClientes = new DataGridViewImageColumn();
                detalleClientes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\ayuda.png");
                dataGridView1.Columns.Add(detalleClientes);

                DataGridViewImageColumn EnviarCorreo = new DataGridViewImageColumn();
                EnviarCorreo.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\abrir msj.png");
                dataGridView1.Columns.Add(EnviarCorreo);

                DataGridViewImageColumn AumentoCredito = new DataGridViewImageColumn();
                AumentoCredito.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\recargar.png");
                dataGridView1.Columns.Add(AumentoCredito);

                DataGridViewImageColumn ClienteMesu = new DataGridViewImageColumn();
                ClienteMesu.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\tarjeta.png");
                dataGridView1.Columns.Add(ClienteMesu);

            }
        }
        private void reportButton_Click(object sender, EventArgs e)
        {
        //    Form1 form = new Form1();
        //    form.ShowDialog();
            
            MessageBox.Show(this, "prueba ");
        }
        private void txtOrden_KeyPress(object sender, KeyPressEventArgs e)
        {

            string x = "";
            x = txtOrden.Text;
            if (x != "")
            {


                var query = db.Clientes.Where(j => j.Nombre.StartsWith(x.ToString())).Select(t => new { t.ClienteId, t.Abreviatura, t.TelefonoPrincipal, t.Nombre, t.Email, t.Notas }).ToList();



                dataGridView1.DataSource = query;
                DataGridViewImageColumn NuevaOrden = new DataGridViewImageColumn();
                NuevaOrden.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\nuevo +.png");
             
                dataGridView1.Columns.Add(NuevaOrden);
      
                DataGridViewImageColumn ObtenerOrdenesClientes = new DataGridViewImageColumn();
                ObtenerOrdenesClientes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\recargar.png");
                dataGridView1.Columns.Add(ObtenerOrdenesClientes);

                DataGridViewImageColumn GuardarCambios = new DataGridViewImageColumn();
                GuardarCambios.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\save.png");
                dataGridView1.Columns.Add(GuardarCambios);

                DataGridViewImageColumn dos = new DataGridViewImageColumn();
                dos.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\archivo flcha.png");
                dataGridView1.Columns.Add(dos);

                DataGridViewImageColumn detalleClientes = new DataGridViewImageColumn();
                detalleClientes.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\ayuda.png");
                dataGridView1.Columns.Add(detalleClientes);

                DataGridViewImageColumn EnviarCorreo = new DataGridViewImageColumn();
                EnviarCorreo.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\abrir msj.png");
                dataGridView1.Columns.Add(EnviarCorreo);

                DataGridViewImageColumn AumentoCredito = new DataGridViewImageColumn();
                AumentoCredito.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\recargar.png");
                dataGridView1.Columns.Add(AumentoCredito);

                DataGridViewImageColumn ClienteMesu = new DataGridViewImageColumn();
                ClienteMesu.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\tarjeta.png");
                dataGridView1.Columns.Add(ClienteMesu);

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
                int valor = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

               Form1 form = new Form1(valor);
                form.ShowDialog();

            }else if(e.ColumnIndex==7)
                
            {
                frmEmpleado empleado = new frmEmpleado();
                empleado.ShowDialog();

            }

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

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
