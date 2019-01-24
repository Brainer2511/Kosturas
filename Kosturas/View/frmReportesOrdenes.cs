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

            var a = dtDesde.Value.ToShortDateString();

            var b = dtpHasta.Value.ToShortDateString();

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
                OrdenView.lblId.BackColor = Color.Red;
                OrdenView.lblId.Location = new Point(0, 0);
                OrdenView.lblId.Size = new Size(100, 20);


                OrdenView.lblNombre.Text = itemdos.Cliente.Nombre.ToString();
                OrdenView.lblNombre.BackColor = Color.Red;
                OrdenView.lblNombre.Size = new Size(200, 20);
                OrdenView.lblNombre.Location = new Point(110, 0);


                OrdenView.lblFechaEntrada.Text = itemdos.FechaEnt.ToString();
                OrdenView.lblFechaEntrada.BackColor = Color.Red;
                OrdenView.lblFechaEntrada.Size = new Size(105, 20);
                OrdenView.lblFechaEntrada.Location = new Point(315, 0);


                OrdenView.lblLocalizacion.Text = itemdos.Localizacion.ToString();
                OrdenView.lblLocalizacion.BackColor = Color.Red;
                OrdenView.lblLocalizacion.Location = new Point(445, 0);
                OrdenView.lblLocalizacion.Size = new Size(50, 20);


                OrdenView.lblHoraEntrada.Text = itemdos.FechaSalida.ToString();
                OrdenView.lblHoraEntrada.BackColor = Color.Red;
                OrdenView.lblHoraEntrada.Location = new Point(540, 0);
                OrdenView.lblHoraEntrada.Size = new Size(105, 20);

                OrdenView.lblTotal.Text = itemdos.TotalOrden.ToString();
                OrdenView.lblTotal.BackColor = Color.Red;
                OrdenView.lblTotal.Location = new Point(685, 0);
                OrdenView.lblTotal.Size = new Size(105, 20);

                OrdenView.lblMontoPagado.Text = itemdos.CantidadPagada.ToString();
                OrdenView.lblMontoPagado.BackColor = Color.Red;
                OrdenView.lblMontoPagado.Location = new Point(835, 0);
                OrdenView.lblMontoPagado.Size = new Size(105, 20);

                OrdenView.lblMontoRestante.Text = itemdos.CantidadRestante.ToString();
                OrdenView.lblMontoRestante.BackColor = Color.Red;
                OrdenView.lblMontoRestante.Location = new Point(975, 0);
                OrdenView.lblMontoRestante.Size = new Size(105, 20);

                OrdenView.lblEstado.Text = "YES";
                OrdenView.lblEstado.BackColor = Color.Red;
                OrdenView.lblEstado.Location = new Point(1125, 0);
                OrdenView.lblEstado.Size = new Size(105, 20);






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
                    panelViewTarea.lblId.BackColor = Color.Red;
                    panelViewTarea.lblId.Location = new Point(0, 0);
                    panelViewTarea.lblId.Size = new Size(65, 20);
                    panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblId);

                    panelViewTarea.lblTarea.Text =pago.Monto.ToString();
                    panelViewTarea.lblTarea.BackColor = Color.Red;
                    panelViewTarea.lblTarea.Location = new Point(80, 0);
                    panelViewTarea.lblTarea.Size = new Size(65, 20);

                    panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblTarea);

                    panelViewTarea.lblDetalleTarea.Text = pago.MediosPago.FormaPago.ToString();
                    panelViewTarea.lblDetalleTarea.BackColor = Color.Red;
                    panelViewTarea.lblDetalleTarea.Location = new Point(150, 0);
                    panelViewTarea.lblDetalleTarea.Size = new Size(65, 20);

                    panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDetalleTarea);

                    panelViewTarea.lblPrecio.Text =pago.EmpleadoRealizo.ToString();
                    panelViewTarea.lblPrecio.BackColor = Color.Red;
                    panelViewTarea.lblPrecio.Location = new Point(225, 0);
                    panelViewTarea.lblPrecio.Size = new Size(65, 20);

                    panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblPrecio);

                panelViewTarea.lblDescuento.Text = pago.Puntos.ToString();
                panelViewTarea.lblDescuento.BackColor = Color.Red;
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
                panelViewTarea.lblId.BackColor = Color.Red;
                panelViewTarea.lblId.Location = new Point(0, 0);
                panelViewTarea.lblId.Size = new Size(65, 20);
                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblId);

                panelViewTarea.lblTarea.Text = tarea.Detalle.Tarea.NombreTareas.ToString();
                panelViewTarea.lblTarea.BackColor = Color.Red;
                panelViewTarea.lblTarea.Location = new Point(90, 0);
                panelViewTarea.lblTarea.Size = new Size(135, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblTarea);

                panelViewTarea.lblDetalleTarea.Text = tarea.Detalle.DetalleTareas.ToString();
                panelViewTarea.lblDetalleTarea.BackColor = Color.Red;
                panelViewTarea.lblDetalleTarea.Location = new Point(230, 0);
                panelViewTarea.lblDetalleTarea.Size = new Size(135, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblDetalleTarea);

                panelViewTarea.lblPrecio.Text = tarea.Detalle.Precio.ToString();
                panelViewTarea.lblPrecio.BackColor = Color.Red;
                panelViewTarea.lblPrecio.Location = new Point(400, 0);
                panelViewTarea.lblPrecio.Size = new Size(65, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblPrecio);

                panelViewTarea.txtTotalPrecio.Text = (tarea.Descuento).ToString();
                panelViewTarea.txtTotalPrecio.BackColor = Color.Red;
                panelViewTarea.txtTotalPrecio.Location = new Point(480, 0);
                panelViewTarea.txtTotalPrecio.Size = new Size(65, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.txtTotalPrecio);

                panelViewTarea.lblSubTotal.Text = (tarea.Subtotal).ToString();
                panelViewTarea.lblSubTotal.BackColor = Color.Red;
                panelViewTarea.lblSubTotal.Location = new Point(560, 0);
                panelViewTarea.lblSubTotal.Size = new Size(65, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblSubTotal);


                panelViewTarea.lblDescuento.Text = ("").ToString();
                panelViewTarea.lblDescuento.BackColor = Color.Red;
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

                   
                panelViewTarea.lblAfiliado.BackColor = Color.Red;
                panelViewTarea.lblAfiliado.Location = new Point(800, 0);
                panelViewTarea.lblAfiliado.Size = new Size(105, 20);

                panelViewTarea.panelTarea.Controls.Add(panelViewTarea.lblAfiliado);

                panelViewTarea.lblEmpleado.Text = (tarea.EmpleadoActualizo).ToString();
                panelViewTarea.lblEmpleado.BackColor = Color.Red;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
