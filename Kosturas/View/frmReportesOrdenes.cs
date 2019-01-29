using Kosturas.Model;
using Kosturas.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kosturas.View
{
    public partial class frmReportesOrdenes : Form
    {
        DataContextLocal db = new DataContextLocal();
        int rowCount = 0;
        Color ColorEntrada;
        public List<OrdenDetalleViewModel> listaTareas = new List<OrdenDetalleViewModel>();
        public List<OrdenPrendaViewModel> listaPrendas = new List<OrdenPrendaViewModel>();
        public List<OrdenViewModel> listaOrdenes = new List<OrdenViewModel>();
        public List<OrdenDetalleViewModel> listaPagos = new List<OrdenDetalleViewModel>();
        public frmReportesOrdenes()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnVerOrdenes_Click(object sender, EventArgs e)
        {
          
            var a = this.txtDesde.Text;

            var b = this.txtHasta.Text;

            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            this.txtDesde.Text = a;
            this.txtHasta.Text = b;

            cargarOrdenesTotales(a, b);
        }
        void cargarOrdenesTotales(string a, string b)
        {


            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            var query = db.Ordenes.Where(q => q.FeEnt >= fdesde && q.FeEnt <= fhasta).ToList();



            var Colores = true;
            foreach (var itemdos in query)

            {

                var OrdenView = new OrdenViewModel();
                OrdenView.Panel.Click += new EventHandler(ClickCargarOrden);
                OrdenView.Panel.Click += new EventHandler(ClickPAgos);
                OrdenView.Panel.Size = new Size(1397, 20);
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
           
                OrdenView.lblId.Location = new Point(0, 0);
                OrdenView.lblId.Size = new Size(100, 20);


                OrdenView.lblNombre.Text = itemdos.Cliente.Nombre.ToString();
             
                OrdenView.lblNombre.Size = new Size(200, 20);
                OrdenView.lblNombre.Location = new Point(110, 0);


                OrdenView.lblFechaEntrada.Text = itemdos.FechaEnt.ToString();
              
                OrdenView.lblFechaEntrada.Size = new Size(105, 20);
                OrdenView.lblFechaEntrada.Location = new Point(315, 0);


                OrdenView.lblLocalizacion.Text = itemdos.Localizacion.ToString();
               
                OrdenView.lblLocalizacion.Location = new Point(445, 0);
                OrdenView.lblLocalizacion.Size = new Size(50, 20);


                OrdenView.lblHoraEntrada.Text = itemdos.FechaSalida.ToString();
              
                OrdenView.lblHoraEntrada.Location = new Point(540, 0);
                OrdenView.lblHoraEntrada.Size = new Size(105, 20);

                OrdenView.lblTotal.Text = itemdos.TotalOrden.ToString();
     
                OrdenView.lblTotal.Location = new Point(685, 0);
                OrdenView.lblTotal.Size = new Size(105, 20);

                OrdenView.lblMontoPagado.Text = itemdos.CantidadPagada.ToString();
            
                OrdenView.lblMontoPagado.Location = new Point(835, 0);
                OrdenView.lblMontoPagado.Size = new Size(105, 20);

                OrdenView.lblMontoRestante.Text = itemdos.CantidadRestante.ToString();
               
                OrdenView.lblMontoRestante.Location = new Point(975, 0);
                OrdenView.lblMontoRestante.Size = new Size(105, 20);

                if (itemdos.Prendas.FirstOrDefault().DetalleTareas.FirstOrDefault().Estado == true)
                {
                    OrdenView.lblEstado.Text = "Si";

                    OrdenView.lblEstado.Location = new Point(1125, 0);
                    OrdenView.lblEstado.Size = new Size(105, 20);

                }
                else
                {
                    OrdenView.lblEstado.Text = "No";

                    OrdenView.lblEstado.Location = new Point(1125, 0);
                    OrdenView.lblEstado.Size = new Size(105, 20);

                }






                OrdenView.Panel.Controls.Add(OrdenView.lblId);
                OrdenView.Panel.Controls.Add(OrdenView.lblNombre);
                OrdenView.Panel.Controls.Add(OrdenView.lblLocalizacion);
                OrdenView.Panel.Controls.Add(OrdenView.lblFechaEntrada);

                OrdenView.Panel.Controls.Add(OrdenView.lblHoraEntrada);
                OrdenView.Panel.Controls.Add(OrdenView.lblTotal);
                OrdenView.Panel.Controls.Add(OrdenView.lblMontoPagado);
                OrdenView.Panel.Controls.Add(OrdenView.lblMontoRestante);
                OrdenView.Panel.Controls.Add(OrdenView.lblEstado);


                AutoMapper.Mapper.Map(itemdos, OrdenView);
                listaOrdenes.Add(OrdenView);
                rowCount += 1;
                tlpOrdenesTotales.RowCount = rowCount;
                this.tlpOrdenesTotales.Controls.Add(listaOrdenes.Last().Panel, 0, rowCount);



            }

        }


        void ClickCargarOrdenes(string a, string b)
        {











            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);

            //   dgvTotalOrdenes.DataSource = db.Ordenes.Where(q => q.FeEnt >= fdesde && q.FeEnt <= fhasta).Select(t=>new {t.OrdenId,t.Cliente.Nombre,t.FeEnt,t.FechaSalida,t.CantidadPagada }).ToList();





        }


        void ClickPAgos(object sender, EventArgs e)
        {
            listaPagos = new List<OrdenDetalleViewModel>();
            Panel btn = sender as Panel;
            var id = int.Parse(btn.Name);

            var Colores = true;

            rowCount = 0;

           
            var orden = db.Pagos.Where(q => q.OrdenId == id).ToList();

         



                foreach (var pago in orden.ToList())
                {

                    var panelViewTarea = new OrdenDetalleViewModel(string.Empty, string.Empty, 0);



                    panelViewTarea.panelTarea.MouseEnter += new EventHandler(MouseoverDos);
                    panelViewTarea.panelTarea.MouseLeave += new EventHandler(MouseleaveDos);
                    panelViewTarea.panelTarea.Size = new Size(370, 30);
                    panelViewTarea.panelTarea.Name = pago.PagoId.ToString();
                   
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

                    panelViewTarea.lblId.Text = pago.Fecha.ToString();
               
                    panelViewTarea.lblId.Location = new Point(0, 0);
                    panelViewTarea.lblId.Size = new Size(65, 20);
                    panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblId);

                    panelViewTarea.lblTarea.Text =pago.Monto.ToString();
                  
                    panelViewTarea.lblTarea.Location = new Point(80, 0);
                    panelViewTarea.lblTarea.Size = new Size(65, 20);

                    panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblTarea);

                    panelViewTarea.lblDetalleTarea.Text = pago.MediosPago.FormaPago.ToString();
                   
                    panelViewTarea.lblDetalleTarea.Location = new Point(150, 0);
                    panelViewTarea.lblDetalleTarea.Size = new Size(65, 20);

                    panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDetalleTarea);

                    panelViewTarea.lblPrecio.Text =pago.EmpleadoRealizo.ToString();
                   
                    panelViewTarea.lblPrecio.Location = new Point(225, 0);
                    panelViewTarea.lblPrecio.Size = new Size(65, 20);

                    panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblPrecio);

                panelViewTarea.lblDescuento.Text = pago.Puntos.ToString();
               
                panelViewTarea.lblDescuento.Location = new Point(300, 0);
                panelViewTarea.lblDescuento.Size = new Size(45, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDescuento);

                listaPagos.Add(panelViewTarea);
                    rowCount += 1;
                    tblDetalleOrdenesClientes.RowCount = rowCount;
                    this.tlpPagos.Controls.Add(listaPagos.Last().panelTarea, 0, rowCount);
                }





            }

        
       
        private void dgvTotalOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

    void ClickCargarOrden(object sender, EventArgs e)
    {
        listaTareas = new List<OrdenDetalleViewModel>();
        listaPrendas = new List<OrdenPrendaViewModel>();

        BorrarPanelDetalleOrdenes();
            BorrarPanelPagos();
        Panel btn = sender as Panel;
        var id = int.Parse(btn.Name);

        var Colores = true;

        rowCount = 0;


        var orden = db.Ordenes.Find(id);

        label8.Text = orden.EmpleadoRealizo;
        label9.Text = orden.EmpleadoActualizo;
        label11.Text = orden.EmpleadoCompleto;






        foreach (var prenda in orden.Prendas)

        {
            var panelViewPrenda = new OrdenPrendaViewModel(string.Empty);




            panelViewPrenda.panelPrenda.Name = prenda.DetalleOrdenPrendaId.ToString();

            panelViewPrenda.lblPrenda.Text = prenda.Prenda.TipoRopa.ToString() + "X" + prenda.Cantidad;




            panelViewPrenda.panelPrenda.Controls.Add(panelViewPrenda.lblPrenda);
            listaPrendas.Add(panelViewPrenda);
            rowCount += 1;
            tblDetalleOrdenesClientes.RowCount = rowCount;
            this.tblDetalleOrdenesClientes.Controls.Add(listaPrendas.Last().panelPrenda, 0, rowCount);

            foreach (var tarea in prenda.DetalleTareas)
            {

                var panelViewTarea = new OrdenDetalleViewModel(string.Empty, string.Empty, 0);



                panelViewTarea.panelTarea.MouseEnter += new EventHandler(MouseoverDos);
                panelViewTarea.panelTarea.MouseLeave += new EventHandler(MouseleaveDos);
                panelViewTarea.panelTarea.Size = new Size(1020, 30);
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

                panelViewTarea.lblId.Text = tarea.Prenda.OrdenId.ToString();
             
                panelViewTarea.lblId.Location = new Point(0, 0);
                panelViewTarea.lblId.Size = new Size(65, 20);
                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblId);

                panelViewTarea.lblTarea.Text = tarea.Detalle.Tarea.NombreTareas.ToString();
             
                panelViewTarea.lblTarea.Location = new Point(90, 0);
                panelViewTarea.lblTarea.Size = new Size(135, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblTarea);

                panelViewTarea.lblDetalleTarea.Text = tarea.Detalle.DetalleTareas.ToString();
               
                panelViewTarea.lblDetalleTarea.Location = new Point(230, 0);
                panelViewTarea.lblDetalleTarea.Size = new Size(135, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDetalleTarea);

                panelViewTarea.lblPrecio.Text = tarea.Detalle.Precio.ToString();
                
                panelViewTarea.lblPrecio.Location = new Point(400, 0);
                panelViewTarea.lblPrecio.Size = new Size(65, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblPrecio);

                panelViewTarea.txtTotalPrecio.Text = (tarea.Descuento).ToString();
        
                panelViewTarea.txtTotalPrecio.Location = new Point(480, 0);
                panelViewTarea.txtTotalPrecio.Size = new Size(65, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.txtTotalPrecio);

                panelViewTarea.lblSubTotal.Text = (tarea.Subtotal).ToString();
              
                panelViewTarea.lblSubTotal.Location = new Point(560, 0);
                panelViewTarea.lblSubTotal.Size = new Size(65, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblSubTotal);


                panelViewTarea.lblDescuento.Text = ("").ToString();
             
                panelViewTarea.lblDescuento.Location = new Point(640, 0);
                panelViewTarea.lblDescuento.Size = new Size(135, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDescuento);

                    if (tarea.AfiliadoId > 0)
                    {
                        var nombre = db.Afiliados.Find(tarea.AfiliadoId);
                        panelViewTarea.lblAfiliado.Text = (nombre.Nombre);
                    }
                    else
                    {
                        panelViewTarea.lblAfiliado.Text = "";
                    }

                   
               
                panelViewTarea.lblAfiliado.Location = new Point(800, 0);
                panelViewTarea.lblAfiliado.Size = new Size(105, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblAfiliado);

                panelViewTarea.lblEmpleado.Text = (tarea.EmpleadoActualizo).ToString();
              
                panelViewTarea.lblEmpleado.Location = new Point(935, 0);
                panelViewTarea.lblEmpleado.Size = new Size(90, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblEmpleado);

                listaTareas.Add(panelViewTarea);
                rowCount += 1;
                tblDetalleOrdenesClientes.RowCount = rowCount;
                this.tblDetalleOrdenesClientes.Controls.Add(listaTareas.Last().panelTarea, 0, rowCount);
            }





        }
    }
        

       


        void MouseoverDos(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
        
         



            object id = btr.Name;
            ColorEntrada = btr.BackColor;
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
        private void BorrarPanelDetalleOrdenes()
        {
            var totaldos = tblDetalleOrdenesClientes.Controls.Count;
            var litdos = tblDetalleOrdenesClientes.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tblDetalleOrdenesClientes.Controls.Remove(tblDetalleOrdenesClientes.Controls[0]);
            }

        }
        private void BorrarPanelPagos()
        {
            var totaldos = tlpPagos.Controls.Count;
            var litdos = tlpPagos.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tlpPagos.Controls.Remove(tlpPagos.Controls[0]);
            }

        }
    

        void Mouseover(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
            ColorEntrada = btr.BackColor;
        



            object id = btr.Name;
           
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;


        }
        void Mouseleave(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerOrdenes_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnVerOrdenes_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
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

        private void button33_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button33_MouseLeave(object sender, EventArgs e)
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

        private void button17_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button17_MouseLeave(object sender, EventArgs e)
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

        private void frmReportesOrdenes_Load(object sender, EventArgs e)
        {
            var a = DateTime.Today.ToShortDateString();// dtDesde.Value.ToShortDateString();

            var b = DateTime.Today.ToShortDateString();// dtpHasta.Value.ToShortDateString();


            this.txtDesde.Text = a;
            this.txtHasta.Text = b;
        }
        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {

            var a = dtDesde.Value.ToShortDateString();



            this.txtDesde.Text = a;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {

            var b = dtpHasta.Value.ToShortDateString();


            this.txtHasta.Text = b;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

     

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void grbNewOrder_Enter(object sender, EventArgs e)
        {

        }

        private void tlpOrdenesTotales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tblDetalleOrdenesClientes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tlpPagos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
