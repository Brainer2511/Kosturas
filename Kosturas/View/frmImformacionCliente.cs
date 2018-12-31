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
    public partial class frmImformacionCliente : Form
    {

        DataContextLocal db = new DataContextLocal();
        public int ClienteId { get; set; }
        private Cliente cliente = new Cliente();
        public frmImformacionCliente(int clienteId = 0)
        {
            ClienteId = clienteId;
            cliente = db.Clientes.Find(clienteId);
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void frmImformacionCliente_Load(object sender, EventArgs e)
        {

            var medios =
      from a in db.MediosPago

      select new { Names = a.FormaPago };

            this.cmbMediosPago.DataSource = medios.ToList();
            this.cmbMediosPago.DisplayMember = "Names";
            if (ClienteId > 0)
            {
                cargar();
            }

        }
        private void cargar()
        {
            txtNombre.Text = cliente.Nombre;
            txtEmail.Text = cliente.Email;
            txtCalle.Text = cliente.Calle;
            txtCiudad.Text = cliente.Ciudad;
            txtTelefonoPrincipal.Text = cliente.TelefonoPrincipal;
            txtTelefono2.Text = cliente.TelefonoDos;
            txtTelefono3.Text = cliente.Telefonotres;
       
            txtCodigoPostal.Text = cliente.Codigopostal;
            label25.Text = cliente.EmpleadoInserta;
            label24.Text = cliente.Fecha;
            label28.Text = cliente.Empleadoactualiza;
            label27.Text = cliente.FechaModificacion;
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.99;
            this.Close();
            Program.abrirform = 3;

            frmPin frmPin = new frmPin();
            frmPin.ShowDialog();
            Cliente cliente = db.Clientes.Find(ClienteId);


            cliente.Nombre = txtNombre.Text;
            cliente.Email = txtEmail.Text;
            cliente.Calle = txtCalle.Text;
            cliente.Ciudad = txtCiudad.Text;
            cliente.TelefonoPrincipal = txtTelefonoPrincipal.Text;
            cliente.TelefonoDos = txtTelefono2.Text;
            cliente.Telefonotres = txtTelefono3.Text;

            cliente.Codigopostal = txtCodigoPostal.Text;
            cliente.FechaModificacion = DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss");
            cliente.Empleadoactualiza = Program.Pin;


         

            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
            frmPrincipal frm = new frmPrincipal();
        
            frm.Opacity = 1;
            frm.Show();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.button2.BackColor = System.Drawing.Color.OliveDrab;
            this.button2.ForeColor = System.Drawing.Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {

            this.button2.BackColor = Color.White;
            this.button2.ForeColor = System.Drawing.Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.btnVerOrdenes.BackColor = System.Drawing.Color.OliveDrab;
            this.btnVerOrdenes.ForeColor = System.Drawing.Color.Black;
        }

        private void btnVerOrdenes_MouseLeave(object sender, EventArgs e)
        {

            this.btnVerOrdenes.BackColor = Color.White;
            this.btnVerOrdenes.ForeColor = System.Drawing.Color.Black;
        }

        private void btnHacerEfecto_MouseEnter(object sender, EventArgs e)
        {
            this.btnHacerEfecto.BackColor = System.Drawing.Color.OliveDrab;
            this.btnHacerEfecto.ForeColor = System.Drawing.Color.White;
        }

        private void btnHacerEfecto_MouseLeave(object sender, EventArgs e)
        {

            this.btnHacerEfecto.BackColor = Color.White;
            this.btnHacerEfecto.ForeColor = System.Drawing.Color.Black;
        }

        private void button29_MouseEnter(object sender, EventArgs e)
        {
            this.button29.BackColor = System.Drawing.Color.OliveDrab;
            this.button29.ForeColor = System.Drawing.Color.White;
        }

        private void button29_MouseLeave(object sender, EventArgs e)
        {

            this.button29.BackColor = Color.White;
            this.button29.ForeColor = System.Drawing.Color.Black;
        }

        private void button32_MouseEnter(object sender, EventArgs e)
        {
            this.button32.BackColor = System.Drawing.Color.OliveDrab;
            this.button32.ForeColor = System.Drawing.Color.White;
        }

        private void button32_MouseLeave(object sender, EventArgs e)
        {

            this.button32.BackColor = Color.White;
            this.button32.ForeColor = System.Drawing.Color.Black;
        }

        private void button31_MouseEnter(object sender, EventArgs e)
        {
            this.button31.BackColor = System.Drawing.Color.OliveDrab;
            this.button31.ForeColor = System.Drawing.Color.White;
        }

        private void button31_MouseLeave(object sender, EventArgs e)
        {

            this.button31.BackColor = Color.White;
            this.button31.ForeColor = System.Drawing.Color.Black;
        }

        private void button35_MouseEnter(object sender, EventArgs e)
        {
            this.button35.BackColor = System.Drawing.Color.OliveDrab;
            this.button35.ForeColor = System.Drawing.Color.White;
        }

        private void button35_MouseLeave(object sender, EventArgs e)
        {

            this.button35.BackColor = Color.White;
            this.button35.ForeColor = System.Drawing.Color.Black;
        }

        private void button30_MouseEnter(object sender, EventArgs e)
        {
            this.button30.BackColor = System.Drawing.Color.OliveDrab;
            this.button30.ForeColor = System.Drawing.Color.White;
        }

        private void button30_MouseLeave(object sender, EventArgs e)
        {

            this.button30.BackColor = Color.White;
            this.button30.ForeColor = System.Drawing.Color.Black;
        }

        private void button33_MouseEnter(object sender, EventArgs e)
        {
            this.button33.BackColor = System.Drawing.Color.OliveDrab;
            this.button33.ForeColor = System.Drawing.Color.White;
        }

        private void button33_MouseLeave(object sender, EventArgs e)
        {

            this.button33.BackColor = Color.White;
            this.button33.ForeColor = System.Drawing.Color.Black;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            this.button4.BackColor = System.Drawing.Color.OliveDrab;
            this.button4.ForeColor = System.Drawing.Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {

            this.button4.BackColor = Color.White;
            this.button4.ForeColor = System.Drawing.Color.Black;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            this.button3.BackColor = System.Drawing.Color.OliveDrab;
            this.button3.ForeColor = System.Drawing.Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {

            this.button3.BackColor = Color.White;
            this.button3.ForeColor = System.Drawing.Color.Black;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            this.button5.BackColor = System.Drawing.Color.OliveDrab;
            this.button5.ForeColor = System.Drawing.Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {

            this.button5.BackColor = Color.White;
            this.button5.ForeColor = System.Drawing.Color.Black;
        }

        private void cmbMediosPago_MouseEnter(object sender, EventArgs e)
        {

            this.cmbMediosPago.BackColor = System.Drawing.Color.OliveDrab;
            this.cmbMediosPago.ForeColor = System.Drawing.Color.White;
        }

        private void cmbMediosPago_MouseLeave(object sender, EventArgs e)
        {
            this.cmbMediosPago.BackColor = Color.White;
            this.cmbMediosPago.ForeColor = System.Drawing.Color.Black;
        }
    }
}
