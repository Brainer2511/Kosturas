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
    public partial class frmOfertas : Form
    {
        public DataContextLocal db = new DataContextLocal();
        public frmOfertas()
        {
            InitializeComponent();
        }

        private void frmOfertas_Load(object sender, EventArgs e)
        {
            this.btnActualizar.Visible = false;
            dvgOfertas.DataSource = db.Ofertas.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Ofertas oferta = new Ofertas();

            oferta.NumeroOferta = txtNumeroOferta.Text;
            oferta.Descripcion = txtDescripcion.Text;
            oferta.DescuentoPorsentaje = int.Parse(txtDescuento.Text);
            oferta.ImporteDescuento = txtImporte.Text;
            oferta.Habilitar = ckbHabilitar.Checked;


            db.Ofertas.Add(oferta);
            db.SaveChanges();

            MessageBox.Show("Oferta Guardada");
            dvgOfertas.DataSource = db.Ofertas.ToList();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Ofertas oferta = db.Ofertas.Find(int.Parse(dvgOfertas.SelectedRows[0].Cells[0].Value.ToString()));
            oferta.NumeroOferta = txtNumeroOferta.Text;
            oferta.Descripcion = txtDescripcion.Text;
            oferta.DescuentoPorsentaje = int.Parse(txtDescuento.Text);
            oferta.ImporteDescuento = txtImporte.Text;
            oferta.Habilitar = ckbHabilitar.Checked;


            db.Entry(oferta).State = EntityState.Modified;
            db.SaveChanges();

            MessageBox.Show("Oferta Actualizada");

            dvgOfertas.DataSource = db.Ofertas.ToList();
        }

        private void dvgOfertas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int a = e.RowIndex;

            if (a != -1)
            {

                this.btnActualizar.Visible = true;
                this.btnGuardar.Visible = false;
                txtNumeroOferta.Text= dvgOfertas.SelectedRows[0].Cells[1].Value.ToString();
                 txtDescripcion.Text= dvgOfertas.SelectedRows[0].Cells[2].Value.ToString();
                 txtDescuento.Text= dvgOfertas.SelectedRows[0].Cells[3].Value.ToString();
                 txtImporte.Text= dvgOfertas.SelectedRows[0].Cells[4].Value.ToString();
              
               var check = dvgOfertas.SelectedRows[0].Cells[5].Value.ToString();
                if (check == "True")
                {
                    ckbHabilitar.Checked = true;
                }
                else
                {
                    ckbHabilitar.Checked = false;
                }
           
           

            }
        }
    }
}
