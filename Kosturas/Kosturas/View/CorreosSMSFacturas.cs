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
    public partial class CorreosSMSFacturas : Form
    {
        public DataContextLocal db = new DataContextLocal();
        Color ColorEntrada;
        public CorreosSMSFacturas()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            Templeis templeis = db.Templeis.Find(1);

            templeis.TempleiSMS = txtPlantillaSMS.Text;
            templeis.TempleiEmail = txtPlantillaCorreo.Text;
            templeis.DirrecTempleiFactura = txtPlantillaFactura.Text;
            templeis.DirrecTempleiVenta = txtPlantillaVenta.Text;
            templeis.DirrecTempleiFacturaMaciva = txtPlantillaCorreoMacivo.Text;
            templeis.SubTempleiFactura = txtSubFActura.Text;
            templeis.SubTempleiVenta = txtSubCorreo.Text;
            templeis.SubTempleiFacturaMaciva = txtSubMaciva.Text;

        
            db.Entry(templeis).State = EntityState.Modified;
            db.SaveChanges();

            MessageBox.Show("Dato Actualizado");
        }

        private void CorreosSMSFacturas_Load(object sender, EventArgs e)
        {
          
            Templeis templeis = db.Templeis.Find(1);

            txtPlantillaSMS.Text = templeis.TempleiSMS;
            txtPlantillaCorreo.Text = templeis.TempleiEmail;
            txtPlantillaFactura.Text = templeis.DirrecTempleiFactura;
            txtPlantillaVenta.Text = templeis.DirrecTempleiVenta;
            txtPlantillaCorreoMacivo.Text = templeis.DirrecTempleiFacturaMaciva;
             txtSubFActura.Text= templeis.SubTempleiFactura;
            txtSubCorreo.Text=templeis.SubTempleiVenta;
            txtSubMaciva.Text= templeis.SubTempleiFacturaMaciva;


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtPlantillaFactura_MouseEnter(object sender, EventArgs e)
        {
       
        }
    }
}
