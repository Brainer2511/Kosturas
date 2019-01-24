﻿using Domain;
using Kosturas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kosturas.ViewModels;
using System.Data.Entity;

namespace Kosturas.View
{
    public partial class frmOrdenPorDia : Form
    {

        DataContextLocal db = new DataContextLocal();
        Empleado Empleado = new Empleado();
        int rowCount = 0;
        int resultado = 0;
        Color ColorEntrada;
        public Panel Panel { get; set; }
        public List<Panel> listapaneles = new List<Panel>();
        public List<OrdenDetalleViewModel> listaTareas = new List<OrdenDetalleViewModel>();
        public List<OrdenPrendaViewModel> listaPrendas = new List<OrdenPrendaViewModel>();
        public List<OrdenViewModel> listaOrdenes = new List<OrdenViewModel>();
        public frmOrdenPorDia()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrdenPorDia_Load(object sender, EventArgs e)
        {
            
         


            var Dia = dtprecogida.Value.DayOfWeek;

            var datos= db.Empleados.ToList();

            foreach (var itemdos in datos)

            {
                if (Dia.ToString() == "Monday") { 
                if (itemdos.Rol == "E") { 
                var horas= int.Parse(itemdos.HorasLunes.ToString());
                 resultado=resultado+horas;
                label10.Text = resultado.ToString() + ":" + "00";
                var nombre = itemdos.Nombre;
                label8.Text +=nombre + " , ";
                }
                }
                if (Dia.ToString() == "Tuesday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasMartes.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString() + ":" + "00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
            }
                
            var a = dtprecogida.Value.ToShortDateString();
            var desde = a + " 00:00";
            var hasta = a + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            var query = from l in db.Ordenes where l.FeEnt >= fdesde && l.FeEnt<=fhasta select l;
         //  this.dbgOdenesTotales.DataSource = query.Select(x => new { x.NumeroOrden, x.NombreCliente, x.FeEnt,x.Localizacion,x.HoraSalida, x.TotalOrden, x.CantidadPagada,x.CantidadRestante }).ToList();

            this.txtFecha.Text = a;
       
        }


private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            rowCount = 0;

            ActualizarPanelTrabajadores();
            BorrarPanelDetalleOrdenes();
            BorrarPanelOrdenes();
           
            var a = dtprecogida.Value.ToShortDateString();
            var desde = a + " 00:00";
            var hasta = a + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            this.txtFecha.Text = a;


            var ordenes = db.OrdenDetalleTareas.Where(q => q.Prenda.Orden.FeEnt >= fdesde && q.Prenda.Orden.FeEnt <= fhasta).ToList().Select(q => q.Duracion).Sum();
           
           var otra = ordenes / 60;

            var prueba = resultado * 60;

            var sfdg = prueba - ordenes;

            var sdh = sfdg / 60;
            label9.Text = sdh.ToString() + ":" + "00";
            var fddg = resultado - sdh;

            label6.Text = fddg.ToString() + ":" + "00";

            var query = (from l in db.Ordenes where l.FeEnt >= fdesde && l.FeEnt <= fhasta select l).ToList();

          
            var Colores = true;
            foreach (var itemdos in query)
             
            {

                var OrdenView = new OrdenViewModel();
                OrdenView.Panel.Click += new EventHandler(ClickCargarOrden);
                OrdenView.Panel.MouseEnter += new EventHandler(Mouseover);
                OrdenView.Panel.MouseLeave += new EventHandler(Mouseleave);
                if (Colores == true)
                {
                    OrdenView.Panel.BackColor = Color.White;
                    Colores = false;
                }
                else
                {
                    OrdenView.Panel.BackColor = Color.WhiteSmoke;
                    Colores = true;
                }
               
                OrdenView.Panel.Name = itemdos.OrdenId.ToString();

                OrdenView.lblId.Text = itemdos.OrdenId.ToString();

                OrdenView.lblNombre.Text = itemdos.Cliente.Nombre.ToString();

                OrdenView.lblFechaEntrada.Text = itemdos.FechaEnt.ToString();

                OrdenView.lblLocalizacion.Text = itemdos.Localizacion.ToString();

                OrdenView.lblHoraEntrada.Text = itemdos.HoraSalida.ToString();

                OrdenView.lblTotal.Text = itemdos.TotalOrden.ToString();

                OrdenView.lblMontoPagado.Text = itemdos.CantidadPagada.ToString();

                OrdenView.lblMontoRestante.Text = itemdos.CantidadRestante.ToString();


                if (itemdos.Prendas.SelectMany(q=>q.DetalleTareas).Where(w=>!w.Estado).Count()==0)
                {
                    OrdenView.btnEstado.BackColor = Color.OliveDrab;
                }

                OrdenView.btnEstado.Text = itemdos.OrdenId.ToString();
                OrdenView.btnEstado.Click += new EventHandler(ClickCambiarEstado);






                OrdenView.Panel.Controls.Add(OrdenView.lblId);
                OrdenView.Panel.Controls.Add(OrdenView.lblNombre);
                OrdenView.Panel.Controls.Add(OrdenView.lblLocalizacion);
                OrdenView.Panel.Controls.Add(OrdenView.lblFechaEntrada);

                OrdenView.Panel.Controls.Add(OrdenView.lblHoraEntrada);
                OrdenView.Panel.Controls.Add(OrdenView.lblTotal);
                OrdenView.Panel.Controls.Add(OrdenView.lblMontoPagado);
                OrdenView.Panel.Controls.Add(OrdenView.lblMontoRestante);
                OrdenView.Panel.Controls.Add(OrdenView.btnEstado);
              
                AutoMapper.Mapper.Map(itemdos, OrdenView);
                listaOrdenes.Add(OrdenView);
                rowCount += 1;
                tlpOrdenesTotales.RowCount = rowCount;
                this.tlpOrdenesTotales.Controls.Add(listaOrdenes.Last().Panel,0,rowCount);


                
            }
           
        }

        void ClickCambiarEstado(object sender, EventArgs e)
        {

            frmPin pin = new frmPin();
            this.Opacity = 0.80;
            pin.ShowDialog();

            this.Opacity = 1;
            

            if (Program.Pin != null) { 
            var Mensaje= MessageBox.Show("Esta Seguro desea Completar Orden","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (Mensaje == DialogResult.Yes)
                {
                    Button btn = sender as Button;
                    var id = int.Parse(btn.Text);

                    var Orden = db.Ordenes.Find(id);

                    Orden.Prendas.SelectMany(m => m.DetalleTareas).ToList().ForEach(w => { w.Estado = true; w.EmpleadoActualizo = Program.Pin; } );
                    foreach (var item in listaTareas)
                    {
                        item.btnEstado.BackColor = Color.OliveDrab;
                    }

                    Orden.EmpleadoActualizo = Program.Pin;
                    db.SaveChanges();
                    var ordenView = listaOrdenes.Where(w => w.OrdenId == Orden.OrdenId).FirstOrDefault();
                    ordenView.btnEstado.BackColor = Color.OliveDrab;

                }
            
               


            }
          



        }
        void ClickCambiarEstadoTarea(object sender, EventArgs e)
        {
            frmPin pin = new frmPin();
            this.Opacity = 0.80;
            pin.ShowDialog();
            this.Opacity = 1;
            if (Program.Pin != null)
            {
                var Mensaje = MessageBox.Show("Esta Seguro desea Completar Tarea", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Mensaje == DialogResult.Yes) { 
                Button btn = sender as Button;
                var id = int.Parse(btn.Text);

                var detallesOrden = db.OrdenDetalleTareas.Find(id);
                var orden = db.Ordenes.Find(detallesOrden.Prenda.OrdenId);
                detallesOrden.Estado = true;
                detallesOrden.EmpleadoActualizo = Program.Pin;
                orden.EmpleadoActualizo = Program.Pin;
                    db.SaveChanges();
                var panelTarea = listaTareas.Where(m => m.DetalleOrdenesId == detallesOrden.DetalleOrdenesId).FirstOrDefault();
                panelTarea.btnEstado.BackColor = Color.OliveDrab;
             
                }
            }
        }
        void ClickCargarOrden(object sender, EventArgs e)
        {
            listaTareas = new List<OrdenDetalleViewModel>();
            listaPrendas = new List<OrdenPrendaViewModel>();

            BorrarPanelDetalleOrdenes();
      
            Panel btn = sender as Panel;
            var id = int.Parse(btn.Name);
            var Colores = true;

            rowCount = 0;


            var orden = db.Ordenes.Find(id);
            
            label19.Text = orden.EmpleadoRealizo;
            label15.Text = orden.EmpleadoActualizo;
            label14.Text = orden.EmpleadoCompleto;
        

     

        
            
            foreach (var prenda in orden.Prendas)

            {
                var panelViewPrenda = new OrdenPrendaViewModel(string.Empty);



             
                panelViewPrenda.panelPrenda.Click += new EventHandler(ClickCargarOrden);
                panelViewPrenda.panelPrenda.Name = prenda.DetalleOrdenPrendaId.ToString();
                
                panelViewPrenda.lblPrenda.Text = prenda.Prenda.TipoRopa.ToString() + "X" + prenda.Cantidad;


           
              
                panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.lblPrenda);
                listaPrendas.Add(panelViewPrenda);
                rowCount += 1;
                tblDetalleOrdenesClientes.RowCount = rowCount;
                this.tblDetalleOrdenesClientes.Controls.Add(listaPrendas.Last().panelPrenda, 0, rowCount);
           
                foreach (var tarea in prenda.DetalleTareas)
                {
                   
                    var panelViewTarea = new OrdenDetalleViewModel(string.Empty, string.Empty,0);
                 
                  
           
                    panelViewTarea.panelTarea.Click += new EventHandler(ClickCargarOrden);
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
              panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblTarea);

              panelViewTarea.lblDetalleTarea.Text = tarea.Detalle.DetalleTareas.ToString();
              panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDetalleTarea);

           panelViewTarea.txtPrecio.Text = tarea.Detalle.Precio.ToString();
           panelViewTarea.panelTarea.Controls.Add(panelViewTarea.txtPrecio);

           panelViewTarea.txtTotalPrecio.Text =(prenda.Cantidad*tarea.Detalle.Precio).ToString();
           panelViewTarea.panelTarea.Controls.Add(panelViewTarea.txtTotalPrecio);

                    if (tarea.Estado == true)
                    {
                        panelViewTarea.btnEstado.BackColor = Color.OliveDrab;
                        panelViewTarea.btnEstado.ForeColor = Color.OliveDrab;
                        panelViewTarea.btnEstado.Text = tarea.DetalleOrdenesId.ToString();
                        panelViewTarea.btnEstado.Click += new EventHandler(ClickCambiarEstadoTarea);
                        panelViewTarea.panelTarea.Controls.Add(panelViewTarea.btnEstado);
                    } else
                    {
                       
                        panelViewTarea.btnEstado.Text = tarea.DetalleOrdenesId.ToString();
                        panelViewTarea.btnEstado.Click += new EventHandler(ClickCambiarEstadoTarea);
                        panelViewTarea.panelTarea.Controls.Add(panelViewTarea.btnEstado);
                    }


                    listaTareas.Add(panelViewTarea);
                    rowCount += 1;
                    tblDetalleOrdenesClientes.RowCount = rowCount;
                    this.tblDetalleOrdenesClientes.Controls.Add(listaTareas.Last().panelTarea,0,rowCount);
                }
                  


              

            }

            dgvPagos.DataSource = db.Pagos.Where(q=>q.OrdenId==orden.OrdenId).ToList();
            //foreach (var item in query.Prenda.Orden.Prendas)

            //{


            //    var PanelPagos = new Panel();
            //    PanelPagos.Size = new Size(529, 30);
            //    PanelPagos.MouseEnter += new EventHandler(MouseoverDos);
            //    PanelPagos.MouseLeave += new EventHandler(MouseleaveDos);
            //    PanelPagos.BackColor = Color.White;
            //    PanelPagos.Name = item.DetalleOrdenPrendaId.ToString();

            //    var lblFecha = new Label();
            //    lblFecha.Location = new Point(0, 8);
            //    lblFecha.Size=new Size(97, 15);
             
            //    var fecha= item.Orden.FechaEnt.ToString();
            //    lblFecha.Text = fecha.Remove(fecha.Length - 8).ToString();


            //    var lblCantidadPagaga = new Label();
            //    lblCantidadPagaga.Location = new Point(98, 8);
            //    lblCantidadPagaga.Size = new Size(97,15);
            //    lblCantidadPagaga.Text = item.Orden.CantidadPagada.ToString();

            //    PanelPagos.Controls.Add(lblFecha);
            //    PanelPagos.Controls.Add(lblCantidadPagaga);





            //    this.tlpPagos.Controls.Add(PanelPagos);


         

            //}

        }

        void ActualizarPanelTrabajadores()
        {
            label10.Text = "";
            label8.Text = "";
            resultado = 0;
            var Dia = dtprecogida.Value.DayOfWeek;

            var datos = db.Empleados.ToList();

            foreach (var itemdos in datos)

            {
                if (Dia.ToString() == "Monday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasLunes.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString()+":"+"00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
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
                        label10.Text = resultado.ToString() + ":" + "00";
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
            }


        }

        private void button29_MouseEnter(object sender, EventArgs e)
        {

            this.button29.BackColor = System.Drawing.Color.OliveDrab;
            this.button29.ForeColor = System.Drawing.Color.White;
        }

        private void button29_MouseLeave(object sender, EventArgs e)
        {

            this.button29.BackColor = System.Drawing.SystemColors.Control;
            this.button29.ForeColor = System.Drawing.Color.Black;
        }

        private void button34_MouseEnter(object sender, EventArgs e)
        {

            this.button34.BackColor = System.Drawing.Color.OliveDrab;
            this.button34.ForeColor = System.Drawing.Color.White;
        }

        private void button34_MouseLeave(object sender, EventArgs e)
        {

            this.button34.BackColor = System.Drawing.SystemColors.Control;
            this.button34.ForeColor = System.Drawing.Color.Black;
        }

        private void button32_MouseEnter(object sender, EventArgs e)
        {

            this.button32.BackColor = System.Drawing.Color.OliveDrab;
            this.button32.ForeColor = System.Drawing.Color.White;
        }

        private void button32_MouseLeave(object sender, EventArgs e)
        {

            this.button32.BackColor = System.Drawing.SystemColors.Control;
            this.button32.ForeColor = System.Drawing.Color.Black;
        }

        private void button31_MouseEnter(object sender, EventArgs e)
        {

            this.button31.BackColor = System.Drawing.Color.OliveDrab;
            this.button31.ForeColor = System.Drawing.Color.White;
        }

        private void button31_MouseLeave(object sender, EventArgs e)
        {

            this.button31.BackColor = System.Drawing.SystemColors.Control;
            this.button31.ForeColor = System.Drawing.Color.Black;
        }

        private void button35_MouseEnter(object sender, EventArgs e)
        {

            this.button35.BackColor = System.Drawing.Color.OliveDrab;
            this.button35.ForeColor = System.Drawing.Color.White;
        }

        private void button35_MouseLeave(object sender, EventArgs e)
        {

            this.button35.BackColor = System.Drawing.SystemColors.Control;
            this.button35.ForeColor = System.Drawing.Color.Black;
        }

        private void button30_MouseEnter(object sender, EventArgs e)
        {

            this.button30.BackColor = System.Drawing.Color.OliveDrab;
            this.button30.ForeColor = System.Drawing.Color.White;
        }

        private void button30_MouseLeave(object sender, EventArgs e)
        {

            this.button30.BackColor = System.Drawing.SystemColors.Control;
            this.button30.ForeColor = System.Drawing.Color.Black;
        }

        private void button33_MouseEnter(object sender, EventArgs e)
        {

            this.button33.BackColor = System.Drawing.Color.OliveDrab;
            this.button33.ForeColor = System.Drawing.Color.White;
        }

        private void button33_MouseLeave(object sender, EventArgs e)
        {

            this.button33.BackColor = System.Drawing.SystemColors.Control;
            this.button33.ForeColor = System.Drawing.Color.Black;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {

            this.button7.BackColor = System.Drawing.Color.OliveDrab;
            this.button7.ForeColor = System.Drawing.Color.White;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {

            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.ForeColor = System.Drawing.Color.Black;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {

            this.button4.BackColor = System.Drawing.Color.OliveDrab;
            this.button4.ForeColor = System.Drawing.Color.White;
        }
        
        private void button4_MouseLeave(object sender, EventArgs e)
        {

            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.ForeColor = System.Drawing.Color.Black;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {

            this.button8.BackColor = System.Drawing.Color.OliveDrab;
            this.button8.ForeColor = System.Drawing.Color.White;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {

            this.button8.BackColor = System.Drawing.SystemColors.Control;
            this.button8.ForeColor = System.Drawing.Color.Black;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {

            this.button2.BackColor = System.Drawing.Color.OliveDrab;
            this.button2.ForeColor = System.Drawing.Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {

            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.ForeColor = System.Drawing.Color.Black;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {

            this.button5.BackColor = System.Drawing.Color.OliveDrab;
            this.button5.ForeColor = System.Drawing.Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {

            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.ForeColor = System.Drawing.Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

            this.button1.BackColor = System.Drawing.Color.OliveDrab;
            this.button1.ForeColor = System.Drawing.Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.ForeColor = System.Drawing.Color.Black;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {

            this.button9.BackColor = System.Drawing.Color.OliveDrab;
            this.button9.ForeColor = System.Drawing.Color.White;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {

            this.button9.BackColor = System.Drawing.SystemColors.Control;
            this.button9.ForeColor = System.Drawing.Color.Black;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {

            this.button6.BackColor = System.Drawing.Color.OliveDrab;
            this.button6.ForeColor = System.Drawing.Color.White;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {

            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.ForeColor = System.Drawing.Color.Black;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {

            this.button3.BackColor = System.Drawing.Color.OliveDrab;
            this.button3.ForeColor = System.Drawing.Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {

            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.ForeColor = System.Drawing.Color.Black;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {

            this.button11.BackColor = System.Drawing.Color.OliveDrab;
            this.button11.ForeColor = System.Drawing.Color.White;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {

            this.button11.BackColor = System.Drawing.SystemColors.Control;
            this.button11.ForeColor = System.Drawing.Color.Black;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {

            this.button10.BackColor = System.Drawing.Color.OliveDrab;
            this.button10.ForeColor = System.Drawing.Color.White;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {

            this.button10.BackColor = System.Drawing.SystemColors.Control;
            this.button10.ForeColor = System.Drawing.Color.Black;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {

            this.button13.BackColor = System.Drawing.Color.OliveDrab;
            this.button13.ForeColor = System.Drawing.Color.White;
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {

            this.button13.BackColor = System.Drawing.SystemColors.Control;
            this.button13.ForeColor = System.Drawing.Color.Black;
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {

            this.button14.BackColor = System.Drawing.Color.OliveDrab;
            this.button14.ForeColor = System.Drawing.Color.White;
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {

            this.button14.BackColor = System.Drawing.SystemColors.Control;
            this.button14.ForeColor = System.Drawing.Color.Black;
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {

            this.button12.BackColor = System.Drawing.Color.OliveDrab;
            this.button12.ForeColor = System.Drawing.Color.White;
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {

            this.button12.BackColor = System.Drawing.SystemColors.Control;
            this.button12.ForeColor = System.Drawing.Color.Black;
        }

        private void dbgOdenesTotales_ColumnDataPropertyNameChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //this.dbgOdenesTotales.BackColor = System.Drawing.Color.OliveDrab;
            //this.dbgOdenesTotales.ForeColor = System.Drawing.Color.White;
        }

        private void dbgOdenesTotales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void dbgOdenesTotales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;
            if (a != -1)
            {
            
              //  var t = dbgOdenesTotales.SelectedRows[0].Cells[0].Value.ToString();

       
                //var query = from l in db.Ordenes where l.NumeroOrden==t select l;
                //this.dgvPagosPorcliente.DataSource = query.Select(x => new { x.FeEnt, x.CantidadPagada,x.MedioPago, x.EmpleadoRealizo}).ToList();
              
            }
        }


        private void BorrarPanelDetalleOrdenes()
        {
            var totaldos = tblDetalleOrdenesClientes.Controls.Count;
            var litdos = tblDetalleOrdenesClientes.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tblDetalleOrdenesClientes.Controls.Remove(tblDetalleOrdenesClientes.Controls[0]);
            }

        }
        //private void BorrarPanelDetallePagos()
        //{
        //    var totaldos = tlpPagos.Controls.Count;
        //    var litdos = tlpPagos.Controls.OfType<Button>();
        //    for (int i = 0; i < totaldos; i++)
        //    {
        //        tlpPagos.Controls.Remove(tlpPagos.Controls[0]);
        //    }

        //}
        private void BorrarPanelOrdenes()
        {
            var totaldos = tlpOrdenesTotales.Controls.Count;
            var litdos = tlpOrdenesTotales.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tlpOrdenesTotales.Controls.Remove(tlpOrdenesTotales.Controls[0]);
            }

        }


        void Mouseover(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
            ColorEntrada = btr.BackColor;
            
            object id = btr.Name;
            id = btr.BackColor = Color.LightBlue;
           


        }
        void Mouseleave(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
         

            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;
          


        }

        void MouseoverDos(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
            ColorEntrada = btr.BackColor;

            object id = btr.Name;
            id = btr.BackColor = Color.GreenYellow;



        }
        void MouseleaveDos(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;



        }

        private void frmOrdenPorDia_Paint(object sender, PaintEventArgs e)
        {
       
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
            Pen pen = new Pen(Color.White);
            e.Graphics.DrawLine(pen, 14, 40, 387, 40);

            Pen pendos = new Pen(Color.White);
            e.Graphics.DrawLine(pendos, 14, 80, 387, 80);
        }
    }
}
