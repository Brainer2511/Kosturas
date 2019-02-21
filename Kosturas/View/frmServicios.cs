using Domain;
using Kosturas.Model;
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

namespace Kosturas.View
{
    public partial class frmServicios : Form
    {
        public DataContextLocal db = new DataContextLocal();
        Color ColorEntrada;
        public frmServicios()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Servicios servicio = new Servicios();

                servicio.VisualizarServicio = txtVisualizarServicio.Text;
                servicio.NombreServicio = txtNombreServicio.Text;
                servicio.Prefijo = txtPrefijo.Text;
                servicio.Impuesto = cmbImpuesto.SelectedIndex.ToString();
                servicio.Afiliado = cmbAfiliado.SelectedIndex.ToString();
                servicio.Descuentos = cmbDescuentos.SelectedIndex.ToString();
                servicio.Alerta = ckbAlerta.Checked;
                servicio.Habilitar = ckbHabilitar.Checked;
                servicio.Imagen = txtRutaServicio.Text;




                db.Servicios.Add(servicio);
                db.SaveChanges();

                MessageBox.Show("Dato Insertado");
                dvgServicios.DataSource = db.Servicios.ToList();
            }
            catch (Exception)
            {

            }

           
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnActualizar.Visible = false;
                this.cmbImpuesto.Items.Add("Prueba");
                dvgServicios.DataSource = db.Servicios.ToList();


                var ofertas =
         from a in db.Ofertas

         select new { Names = a.Descripcion };

                cmbDescuentos.DataSource = ofertas.ToList();
                cmbDescuentos.DisplayMember = "Names";




                var afiliados =
         from a in db.Afiliados

         select new { Names = a.Nombre };

                cmbAfiliado.DataSource = afiliados.ToList();
                cmbAfiliado.DisplayMember = "Names";
            }
            catch (Exception)
            {

            }
           
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dvgServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a = e.RowIndex;

                if (a != -1)
                {

                    this.btnActualizar.Visible = true;
                    this.btnGuardar.Visible = false;

                    txtVisualizarServicio.Text = dvgServicios.SelectedRows[0].Cells[1].Value.ToString();
                    txtNombreServicio.Text = dvgServicios.SelectedRows[0].Cells[2].Value.ToString();
                    txtPrefijo.Text = dvgServicios.SelectedRows[0].Cells[3].Value.ToString();
                    cmbImpuesto.SelectedIndex = int.Parse(dvgServicios.SelectedRows[0].Cells[4].Value.ToString());
                    cmbDescuentos.SelectedIndex = int.Parse(dvgServicios.SelectedRows[0].Cells[5].Value.ToString());
                    cmbAfiliado.SelectedIndex = int.Parse(dvgServicios.SelectedRows[0].Cells[6].Value.ToString());
                    var check = dvgServicios.SelectedRows[0].Cells[7].Value.ToString();
                    if (check == "True")
                    {
                        ckbAlerta.Checked = true;
                    }
                    else
                    {
                        ckbAlerta.Checked = false;
                    }
                    var checkdos = dvgServicios.SelectedRows[0].Cells[8].Value.ToString();
                    if (checkdos == "True")
                    {
                        ckbHabilitar.Checked = true;
                    }
                    else
                    {
                        ckbHabilitar.Checked = false;
                    }
                    var checktres = dvgServicios.SelectedRows[0].Cells[9].Value.ToString();
                    if (checktres == "True")
                    {
                        ckbImprimirEtiqueta.Checked = true;
                    }
                    else
                    {
                        ckbImprimirEtiqueta.Checked = false;
                    }

                }
            }
            catch (Exception)
            {

            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Servicios servicio = db.Servicios.Find(int.Parse(dvgServicios.SelectedRows[0].Cells[0].Value.ToString()));

                servicio.VisualizarServicio = txtVisualizarServicio.Text;
                servicio.NombreServicio = txtNombreServicio.Text;
                servicio.Prefijo = txtPrefijo.Text;
                servicio.Impuesto = cmbImpuesto.SelectedIndex.ToString();
                servicio.Afiliado = cmbAfiliado.SelectedIndex.ToString();
                servicio.Descuentos = cmbDescuentos.SelectedIndex.ToString();
                servicio.Alerta = ckbAlerta.Checked;
                servicio.Habilitar = ckbHabilitar.Checked;
                servicio.Imagen = txtRutaServicio.Text;
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Dato Actualizado");

                dvgServicios.DataSource = db.Servicios.ToList();
            }
            catch (Exception)
            {

              
            }

           
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtRutaServicio.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception)
            {

            }

           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImagen_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnImagen_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
