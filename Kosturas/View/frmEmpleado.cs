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
    public partial class frmEmpleado : Form
    {
        public DataContextLocal db = new DataContextLocal();
        public  frmEmpleado()
        {
            InitializeComponent();
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {

            
            this.btnCancelar.Enabled = false;
            this.btnGuardar.Enabled = false;

            this.cargar();
            

            }
        public void cargar()
        {
            using (var en = new DataContext())
            {

                var primerempleado = db.Empleados.FirstOrDefault();



                this.txtbuscaEmpleado.Text = primerempleado.EmpleadoId.ToString();
                this.txtNombre.Text = primerempleado.Nombre;
                this.txtApellidos.Text = primerempleado.Apellidos;
                this.txtAlias.Text = primerempleado.Alias;
                this.txtEmal.Text = primerempleado.Email;
                this.ckbActivo.Checked = primerempleado.Activo;
                this.txtUsuario.Text = primerempleado.Usuario;
                this.ckbrecibeNotifi.Checked = primerempleado.ResivirNotifica;
                this.ckbRecibeinfo.Checked = primerempleado.RecibirInforme;
                this.ckbEditPagina.Checked = primerempleado.EditPagina;
                this.ckbEditPuntos.Checked = primerempleado.EditPuntosClinte;
                this.ckbEditSegunda.Checked = primerempleado.EditSegundaPagina;
                this.ckbapcedeTarjeta.Checked = primerempleado.ApcederTarjeta;
                this.ckbAbrirCajon.Checked = primerempleado.AbrirCajon;
                this.ckbEditCredito.Checked = primerempleado.EditCreditoClinte;


                this.duddesdelunes.Text = primerempleado.desdelunes.ToString();
                this.duddesdemartes.Text = primerempleado.desdemartes.ToString();
                this.duddesdemiercoles.Text = primerempleado.desdemiercoles.ToString();
                this.duddesdejueves.Text = primerempleado.desdejueves.ToString();
                this.duddesdeviernes.Text = primerempleado.desdeviernes.ToString();
                this.duddesdesabado.Text = primerempleado.desdesabado.ToString();
                this.duddesdedomingo.Text = primerempleado.desdedomingo.ToString();
                this.dudhastalunes.Text = primerempleado.hastalunes.ToString();
                this.dudhastamartes.Text = primerempleado.hastamartes.ToString();
                this.dudhastamiercoles.Text = primerempleado.hastamiercoles.ToString();
                this.dudhastajueves.Text = primerempleado.hastajueves.ToString();
                this.dudhastaviernes.Text = primerempleado.hastaviernes.ToString();
                this.dudhastasabado.Text = primerempleado.hastasabado.ToString();
                this.dudhastadomingo.Text = primerempleado.hastadomingo.ToString();
               
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();

            empleado.Nombre = txtNombre.Text;
            empleado.Apellidos = txtApellidos.Text;
            empleado.Alias = txtAlias.Text;
            empleado.Email = txtEmal.Text;
            empleado.Activo = ckbActivo.Checked;
            empleado.Usuario = txtUsuario.Text;
            empleado.Clave = txtClave.Text;
            empleado.RecibirInforme = ckbRecibeinfo.Checked;
            empleado.ResivirNotifica = ckbrecibeNotifi.Checked;
            empleado.EditPagina = ckbEditPagina.Checked;
            empleado.EditSegundaPagina = ckbEditSegunda.Checked;
            empleado.ApcederTarjeta = ckbapcedeTarjeta.Checked;
            empleado.AbrirCajon = ckbAbrirCajon.Checked;
            empleado.EditCreditoClinte = ckbEditCredito.Checked;
            empleado.EditPuntosClinte = ckbEditPuntos.Checked;
            empleado.desdelunes= TimeSpan.Parse(duddesdelunes.Value.ToString("HH:mm"));
            empleado.desdemartes = TimeSpan.Parse(duddesdemartes.Value.ToString("HH:mm"));
            empleado.desdemiercoles = TimeSpan.Parse(duddesdemiercoles.Value.ToString("HH:mm"));
            empleado.desdejueves = TimeSpan.Parse(duddesdejueves.Value.ToString("HH:mm"));
            empleado.desdesabado = TimeSpan.Parse(duddesdeviernes.Value.ToString("HH:mm"));
            empleado.desdeviernes = TimeSpan.Parse(duddesdesabado.Value.ToString("HH:mm"));
            empleado.desdedomingo = TimeSpan.Parse(duddesdedomingo.Value.ToString("HH:mm"));
            empleado.hastalunes = TimeSpan.Parse(dudhastalunes.Value.ToString("HH:mm"));
            empleado.hastamartes = TimeSpan.Parse(dudhastamartes.Value.ToString("HH:mm"));
            empleado.hastamiercoles = TimeSpan.Parse(dudhastamiercoles.Value.ToString("HH:mm"));
            empleado.hastajueves = TimeSpan.Parse(dudhastajueves.Value.ToString("HH:mm"));
            empleado.hastasabado = TimeSpan.Parse(dudhastaviernes.Value.ToString("HH:mm"));
            empleado.hastaviernes = TimeSpan.Parse(dudhastasabado.Value.ToString("HH:mm"));
            empleado.hastadomingo = TimeSpan.Parse(dudhastadomingo.Value.ToString("HH:mm"));


            db.Empleados.Add(empleado);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void ckbEditlunes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEditlunes.Checked == true)
            {
                duddesdelunes.Enabled = false;
                dudhastalunes.Enabled = false;

            }
            else
            {
                duddesdelunes.Enabled = true;
                dudhastalunes.Enabled = true;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
        }

        private void ckbEditmartes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEditmartes.Checked == true)
            {
                duddesdemartes.Enabled = false;
                dudhastamartes.Enabled = false;

            }
            else
            {
                duddesdemartes.Enabled = true;
                dudhastamartes.Enabled = true;
            }
        }

        private void ckbEditmiercoles_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEditmiercoles.Checked == true)
            {
                duddesdemiercoles.Enabled = false;
                dudhastamiercoles.Enabled = false;

            }
            else
            {
                duddesdemiercoles.Enabled = true;
                dudhastamiercoles.Enabled = true;
            }
        }

        private void ckbEditjueves_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEditjueves.Checked == true)
            {
                duddesdejueves.Enabled = false;
                dudhastajueves.Enabled = false;

            }
            else
            {
                duddesdejueves.Enabled = true;
                dudhastajueves.Enabled = true;
            }
        }

        private void ckbEditviernes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEditviernes.Checked == true)
            {
                duddesdeviernes.Enabled = false;
                dudhastaviernes.Enabled = false;

            }
            else
            {
                duddesdeviernes.Enabled = true;
                dudhastaviernes.Enabled = true;
            }
        }

        private void ckbEditsabado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEditsabado.Checked == true)
            {
                duddesdesabado.Enabled = false;
                dudhastasabado.Enabled = false;

            }
            else
            {
                duddesdesabado.Enabled = true;
                dudhastasabado.Enabled = true;
            }
        }

        private void ckbEditdomingo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEditdomingo.Checked == true)
            {
                duddesdedomingo.Enabled = false;
                dudhastadomingo.Enabled = false;

            }
            else
            {
                duddesdedomingo.Enabled = true;
                dudhastadomingo.Enabled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            this.btnCancelar.Enabled = false;
            this.btnGuardar.Enabled = false;
            int id = int.Parse(this.txtbuscaEmpleado.Text);
          

                var busquedaempleado = db.Empleados.Find(id);
                           

             

                
                this.txtNombre.Text = busquedaempleado.Nombre;
                this.txtApellidos.Text = busquedaempleado.Apellidos;
                this.txtAlias.Text = busquedaempleado.Alias;
                this.txtEmal.Text = busquedaempleado.Email;
                this.ckbActivo.Checked = busquedaempleado.Activo;
                this.txtUsuario.Text = busquedaempleado.Usuario;
                this.ckbrecibeNotifi.Checked = busquedaempleado.ResivirNotifica;
                this.ckbRecibeinfo.Checked = busquedaempleado.RecibirInforme;
                this.ckbEditPagina.Checked = busquedaempleado.EditPagina;
                this.ckbEditPuntos.Checked = busquedaempleado.EditPuntosClinte;
                this.ckbEditSegunda.Checked = busquedaempleado.EditSegundaPagina;
                this.ckbapcedeTarjeta.Checked = busquedaempleado.ApcederTarjeta;
                this.ckbAbrirCajon.Checked = busquedaempleado.AbrirCajon;
                this.ckbEditCredito.Checked = busquedaempleado.EditCreditoClinte;

                this.duddesdelunes.Text = busquedaempleado.desdelunes.ToString();
                this.duddesdemartes.Text = busquedaempleado.desdemartes.ToString();
                this.duddesdemiercoles.Text = busquedaempleado.desdemiercoles.ToString();
                this.duddesdejueves.Text = busquedaempleado.desdejueves.ToString();
                this.duddesdeviernes.Text = busquedaempleado.desdeviernes.ToString();
                this.duddesdesabado.Text = busquedaempleado.desdesabado.ToString();
                this.duddesdedomingo.Text = busquedaempleado.desdedomingo.ToString();
                this.dudhastalunes.Text = busquedaempleado.hastalunes.ToString();
                this.dudhastamartes.Text = busquedaempleado.hastamartes.ToString();
                this.dudhastamiercoles.Text = busquedaempleado.hastamiercoles.ToString();
                this.dudhastajueves.Text = busquedaempleado.hastajueves.ToString();
                this.dudhastaviernes.Text = busquedaempleado.hastaviernes.ToString();
                this.dudhastasabado.Text = busquedaempleado.hastasabado.ToString();
                this.dudhastadomingo.Text = busquedaempleado.hastadomingo.ToString();

            
      
        }

        private void dateTimePicker10_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardaarDos_Click(object sender, EventArgs e)
        {
            Empleado empleado = db.Empleados.Find(int.Parse(txtbuscaEmpleado.Text));

           

            empleado.Nombre = txtNombre.Text;
            empleado.Apellidos = txtApellidos.Text;
            empleado.Alias = txtAlias.Text;
            empleado.Email = txtEmal.Text;
            empleado.Activo = ckbActivo.Checked;
            empleado.Usuario = txtUsuario.Text;
            empleado.Clave = txtClave.Text;
            empleado.RecibirInforme = ckbRecibeinfo.Checked;
            empleado.ResivirNotifica = ckbrecibeNotifi.Checked;
            empleado.EditPagina = ckbEditPagina.Checked;
            empleado.EditSegundaPagina = ckbEditSegunda.Checked;
            empleado.ApcederTarjeta = ckbapcedeTarjeta.Checked;
            empleado.AbrirCajon = ckbAbrirCajon.Checked;
            empleado.EditCreditoClinte = ckbEditCredito.Checked;
            empleado.EditPuntosClinte = ckbEditPuntos.Checked;
            empleado.desdelunes = TimeSpan.Parse(duddesdelunes.Value.ToString("HH:mm"));
            empleado.desdemartes = TimeSpan.Parse(duddesdemartes.Value.ToString("HH:mm"));
            empleado.desdemiercoles = TimeSpan.Parse(duddesdemiercoles.Value.ToString("HH:mm"));
            empleado.desdejueves = TimeSpan.Parse(duddesdejueves.Value.ToString("HH:mm"));
            empleado.desdesabado = TimeSpan.Parse(duddesdeviernes.Value.ToString("HH:mm"));
            empleado.desdeviernes = TimeSpan.Parse(duddesdesabado.Value.ToString("HH:mm"));
            empleado.desdedomingo = TimeSpan.Parse(duddesdedomingo.Value.ToString("HH:mm"));
            empleado.hastalunes = TimeSpan.Parse(dudhastalunes.Value.ToString("HH:mm"));
            empleado.hastamartes = TimeSpan.Parse(dudhastamartes.Value.ToString("HH:mm"));
            empleado.hastamiercoles = TimeSpan.Parse(dudhastamiercoles.Value.ToString("HH:mm"));
            empleado.hastajueves = TimeSpan.Parse(dudhastajueves.Value.ToString("HH:mm"));
            empleado.hastasabado = TimeSpan.Parse(dudhastaviernes.Value.ToString("HH:mm"));
            empleado.hastaviernes = TimeSpan.Parse(dudhastasabado.Value.ToString("HH:mm"));
            empleado.hastadomingo = TimeSpan.Parse(dudhastadomingo.Value.ToString("HH:mm"));

            db.Entry(empleado).State = EntityState.Modified;
            db.SaveChanges();

            MessageBox.Show("Dato Actualizado");

        }

        private void btnNuevoEmpledo_Click(object sender, EventArgs e)
        {

            this.btnCancelar.Enabled = true;
            this.btnGuardar.Enabled = true;
            txtbuscaEmpleado.Text = "";
            txtNombre.Text="";
             txtApellidos.Text = "";
             txtAlias.Text = "";
              txtEmal.Text = "";
             ckbActivo.Checked = false;
              txtUsuario.Text = "";
             txtClave.Text = "";
             ckbRecibeinfo.Checked = false;
             ckbrecibeNotifi.Checked = false;
             ckbEditPagina.Checked = false;
             ckbEditSegunda.Checked = false;
             ckbapcedeTarjeta.Checked = false;
             ckbAbrirCajon.Checked = false;
             ckbEditCredito.Checked = false;
             ckbEditPuntos.Checked = false;
           duddesdelunes.Text= "00:00";
            duddesdemartes.Text = "00:00";
            duddesdemiercoles.Text = "00:00";
            duddesdejueves.Text = "00:00";
            duddesdeviernes.Text = "00:00";
            duddesdesabado.Text = "00:00";
            duddesdedomingo.Text = "00:00";
            dudhastalunes.Text = "00:00";
            dudhastamartes.Text = "00:00";
            dudhastamiercoles.Text = "00:00";
            dudhastajueves.Text = "00:00";
            dudhastaviernes.Text = "00:00";
            dudhastasabado.Text = "00:00";
            dudhastadomingo.Text = "00:00";

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.btnCancelar.Enabled = false;
            this.btnGuardar.Enabled = false;
            Empleado busquedaempleado = new Empleado();
            if (!string.IsNullOrEmpty(this.txtbuscaEmpleado.Text))
            {

                int id = int.Parse(this.txtbuscaEmpleado.Text);


                var listaempleados = db.Empleados.Where(x => x.EmpleadoId > id).ToList();
                busquedaempleado = listaempleados.FirstOrDefault();
                if (listaempleados.Count == 0) return;
            }
            else {
                busquedaempleado = db.Empleados.FirstOrDefault();

            }

            

        
            this.txtbuscaEmpleado.Text = busquedaempleado.EmpleadoId.ToString();

            this.txtNombre.Text = busquedaempleado.Nombre;
            this.txtApellidos.Text = busquedaempleado.Apellidos;
            this.txtAlias.Text = busquedaempleado.Alias;
            this.txtEmal.Text = busquedaempleado.Email;
            this.ckbActivo.Checked = busquedaempleado.Activo;
            this.txtUsuario.Text = busquedaempleado.Usuario;
            this.ckbrecibeNotifi.Checked = busquedaempleado.ResivirNotifica;
            this.ckbRecibeinfo.Checked = busquedaempleado.RecibirInforme;
            this.ckbEditPagina.Checked = busquedaempleado.EditPagina;
            this.ckbEditPuntos.Checked = busquedaempleado.EditPuntosClinte;
            this.ckbEditSegunda.Checked = busquedaempleado.EditSegundaPagina;
            this.ckbapcedeTarjeta.Checked = busquedaempleado.ApcederTarjeta;
            this.ckbAbrirCajon.Checked = busquedaempleado.AbrirCajon;
            this.ckbEditCredito.Checked = busquedaempleado.EditCreditoClinte;

            this.duddesdelunes.Text = busquedaempleado.desdelunes.ToString();
            this.duddesdemartes.Text = busquedaempleado.desdemartes.ToString();
            this.duddesdemiercoles.Text = busquedaempleado.desdemiercoles.ToString();
            this.duddesdejueves.Text = busquedaempleado.desdejueves.ToString();
            this.duddesdeviernes.Text = busquedaempleado.desdeviernes.ToString();
            this.duddesdesabado.Text = busquedaempleado.desdesabado.ToString();
            this.duddesdedomingo.Text = busquedaempleado.desdedomingo.ToString();
            this.dudhastalunes.Text = busquedaempleado.hastalunes.ToString();
            this.dudhastamartes.Text = busquedaempleado.hastamartes.ToString();
            this.dudhastamiercoles.Text = busquedaempleado.hastamiercoles.ToString();
            this.dudhastajueves.Text = busquedaempleado.hastajueves.ToString();
            this.dudhastaviernes.Text = busquedaempleado.hastaviernes.ToString();
            this.dudhastasabado.Text = busquedaempleado.hastasabado.ToString();
            this.dudhastadomingo.Text = busquedaempleado.hastadomingo.ToString();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.btnCancelar.Enabled = false;
            this.btnGuardar.Enabled = false;
            Empleado busquedaempleado = new Empleado();
            if (!string.IsNullOrEmpty(this.txtbuscaEmpleado.Text))
            {

                int id = int.Parse(this.txtbuscaEmpleado.Text);


                var listaempleados = db.Empleados.Where(x => x.EmpleadoId < id).OrderByDescending(x => x.EmpleadoId).ToList();
                busquedaempleado = listaempleados.FirstOrDefault();
                if (listaempleados.Count == 0) return;
            }
            else
            {
                busquedaempleado = db.Empleados.OrderByDescending(x => x.EmpleadoId).FirstOrDefault();

            }




            this.txtbuscaEmpleado.Text = busquedaempleado.EmpleadoId.ToString();

            this.txtNombre.Text = busquedaempleado.Nombre;
            this.txtApellidos.Text = busquedaempleado.Apellidos;
            this.txtAlias.Text = busquedaempleado.Alias;
            this.txtEmal.Text = busquedaempleado.Email;
            this.ckbActivo.Checked = busquedaempleado.Activo;
            this.txtUsuario.Text = busquedaempleado.Usuario;
            this.ckbrecibeNotifi.Checked = busquedaempleado.ResivirNotifica;
            this.ckbRecibeinfo.Checked = busquedaempleado.RecibirInforme;
            this.ckbEditPagina.Checked = busquedaempleado.EditPagina;
            this.ckbEditPuntos.Checked = busquedaempleado.EditPuntosClinte;
            this.ckbEditSegunda.Checked = busquedaempleado.EditSegundaPagina;
            this.ckbapcedeTarjeta.Checked = busquedaempleado.ApcederTarjeta;
            this.ckbAbrirCajon.Checked = busquedaempleado.AbrirCajon;
            this.ckbEditCredito.Checked = busquedaempleado.EditCreditoClinte;

            this.duddesdelunes.Text = busquedaempleado.desdelunes.ToString();
            this.duddesdemartes.Text = busquedaempleado.desdemartes.ToString();
            this.duddesdemiercoles.Text = busquedaempleado.desdemiercoles.ToString();
            this.duddesdejueves.Text = busquedaempleado.desdejueves.ToString();
            this.duddesdeviernes.Text = busquedaempleado.desdeviernes.ToString();
            this.duddesdesabado.Text = busquedaempleado.desdesabado.ToString();
            this.duddesdedomingo.Text = busquedaempleado.desdedomingo.ToString();
            this.dudhastalunes.Text = busquedaempleado.hastalunes.ToString();
            this.dudhastamartes.Text = busquedaempleado.hastamartes.ToString();
            this.dudhastamiercoles.Text = busquedaempleado.hastamiercoles.ToString();
            this.dudhastajueves.Text = busquedaempleado.hastajueves.ToString();
            this.dudhastaviernes.Text = busquedaempleado.hastaviernes.ToString();
            this.dudhastasabado.Text = busquedaempleado.hastasabado.ToString();
            this.dudhastadomingo.Text = busquedaempleado.hastadomingo.ToString();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            frmPrincipal principal = new frmPrincipal();
            principal.Opacity = 0.50;
            this.Close();
        }
    }


    }

