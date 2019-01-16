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
    public partial class EnvioOrden : Form
    {

        DataContextLocal db = new DataContextLocal();
        private Cliente cliente = new Cliente();
        private Ordenes orden = new Ordenes();
        Empleado Empleado = new Empleado();
        int resultado = 0;
        public int ClienteId { get; set; }
        public int OrdenId { get; set; }
        public EnvioOrden(int clienteId = 0,int ordenId=0)
        {

            ClienteId = clienteId;
            OrdenId = ordenId;
            cliente = db.Clientes.Find(clienteId);
            orden = db.Ordenes.Find(ordenId);
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnvioOrden_Load(object sender, EventArgs e)
        {
            this.lblCalcularCambio.Visible = false;
            this.lblCAmbio.Visible = false;
            this.lblresultado.Visible = false;
            this.txtCalcularCambio.Visible = false;
            ActualizarPanelTrabajadores();
           
            this.dtpFecha.Value = dtpFecha.Value.AddDays(2);
            txtpago.Text = orden.TotalOrden.ToString();
            lblVisitas.Text = cliente.Visitas;
           lblTotalDos.Text= orden.TotalOrden.ToString();
            txtEmail.Text = cliente.Email;
            txtTelefono.Text = cliente.TelefonoPrincipal;
            cmbHora.Items.Add("15");
            cmbHora.Items.Add("16");
            cmbHora.Items.Add("17");
            cmbHora.Items.Add("18");

            cmbHora.SelectedIndex = 0;
            cmbMinutos.Items.Add("00");
            cmbMinutos.Items.Add("15");
            cmbMinutos.Items.Add("30");
            cmbMinutos.Items.Add("45");
            cmbMinutos.SelectedIndex = 0;
           
            var medios =
    from medio in db.MediosPago

    select new {medio.FormaPago };

            cmbTipoPago.DataSource = medios.Select(t=>t.FormaPago).ToList();

            
            cmbTipoPago.SelectedIndex = 1;
            var a = dtpFecha.Value.ToString();
            a = a.Remove(a.Length - 8);
            this.txtFecha.Text =a;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPin pin = new frmPin();
            pin.ShowDialog();
         


            Ordenes orden = db.Ordenes.Find(OrdenId);
            orden.NumeroOrden = orden.OrdenId.ToString();
            orden.HoraSalida =this.cmbHora.SelectedItem.ToString()+":"+this.cmbMinutos.SelectedItem.ToString();
         
            var a = int.Parse(orden.TotalOrden.ToString());
            var b = int.Parse(txtpago.Text);
            var c = a - b;
            orden.CantidadRestante = c;
            orden.EmpleadoRealizo = Program.Pin;
            orden.CantidadPagada = double.Parse(txtpago.Text);
            orden.FechaSalida = txtFecha.Text;
            if (ckbNopagar.Checked == false)
            {
              
                orden.MedioPago = cmbTipoPago.SelectedValue.ToString();
                
            }
            else {
                orden.MedioPago = "";
            }
           
            db.Entry(orden).State = EntityState.Modified;
            db.SaveChanges();

            Cliente cliente = db.Clientes.Find(ClienteId);
            var Visita = int.Parse(cliente.Visitas);
            Visita += 1;
            cliente.Visitas = Visita.ToString();
            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
            this.Close();
          

        }

        private void ckbNopagar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbNopagar.Checked == true)
            {
                this.txtpago.Text = "0";
                this.cmbTipoPago.Visible = false;

            }
            else
            {
                this.txtpago.Text =Program.TotalOrden;
                this.cmbTipoPago.Visible = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }
        void ActualizarPanelTrabajadores()
        {
            label10.Text = "";
            label8.Text = "";
            resultado = 0;
           var FechaHoy = DateTime.Today;
            var Dia = FechaHoy.DayOfWeek;

            var datos = db.Empleados.ToList();

            foreach (var itemdos in datos)

            {
                if (Dia.ToString() == "Monday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasLunes.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString();
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Tuesday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasMartes.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString();
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Wednesday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasMiercoles.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString();
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Thursday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasJueves.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString();
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Friday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasViernes.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString();
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Saturday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasSabado.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString();
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Sunday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasDomingo.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString();
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
            }


        }

        private void cmbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbTipoPago.SelectedIndex==0)
            {

                this.lblCalcularCambio.Visible = true;
                this.lblCAmbio.Visible = true;
                this.lblresultado.Visible = true;
                this.txtCalcularCambio.Visible = true;

            }
            else
            {

                this.lblCalcularCambio.Visible = false;
                this.lblCAmbio.Visible = false;
                this.lblresultado.Visible = false;
                this.txtCalcularCambio.Visible = false;
            }
        }

        private void txtCalcularCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            String x = "";


            x = this.txtCalcularCambio.Text + e.KeyChar;

            if (e.KeyChar == '\b')
            {
                if (x.Length == 1)
                {
                    x = x.Remove(x.Length - 1);
                   
                }
                else
                {
                    x = x.Remove(x.Length - 2);
                   
                }
            }


           

                var total = int.Parse(this.txtpago.Text);
            if (x != "") { 
            var residuo= int.Parse(x);
                var Resultado =  residuo- total;
                lblresultado.Text = Resultado.ToString();
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int x1=40;
            int y1=40;

            for (int i = 0; i < 6; i++)
            {
                Pen pen = new Pen(Color.White);
                e.Graphics.DrawLine(pen, 14, x1, 230, y1);
                x1 = x1 + 55;
                y1 = y1 + 55;
            }
         
        }

        private void EnvioOrden_Paint(object sender, PaintEventArgs e)
        {
            int x1 = 250;
            int y1 = 250;

            for (int i = 0; i < 3; i++)
            {
                Pen pen = new Pen(Color.Gray);
                e.Graphics.DrawLine(pen, 14, x1, 635, y1);
                x1 = x1 + 50;
                y1 = y1 + 50;
            }

        }
    }
}
