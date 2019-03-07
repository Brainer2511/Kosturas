using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;
using Twilio.Rest.Api.V2010.Account;
using Kosturas.Model;
using Kosturas.ViewModels;
using Domain;
using System.Data.Entity;

namespace Kosturas.View
{

    public partial class frmNuevaVenta : Form
    {
        public DataContextLocal db = new DataContextLocal();
        public int? ClienteId { get; set; }
        int pagina = 1;
        int paginas = 0;
        Color ColorEntrada;
        int rowCount = 0;
        int Descuento = 0;

        public int ventaId;
        public List<OrdenDetalleViewModel> listaProductos = new List<OrdenDetalleViewModel>();

        public frmNuevaVenta()
        {
            InitializeComponent();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void btnvacio_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {

                using (var db = new DataContextLocal())
                {
                    var Mensaje = MessageBox.Show("Esta Seguro desea Salir Y Borrar Esa Venta Del Sistema", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Mensaje == DialogResult.Yes)
                    {


                  
                        var detalle = db.DetalleVentas.Where(q => q.VentaId == ventaId).ToList();
                        if (detalle.Count > 0)

                        {
                            foreach (var item in detalle)
                            {
                                db.DetalleVentas.Remove(item);
                                db.SaveChanges();
                            }
                          

                        }








                        Ventas venta = db.Ventas.Find(ventaId);
                        db.Ventas.Remove(venta);
                        db.SaveChanges();





                        this.Close();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmNuevaVenta_Load(object sender, EventArgs e)
        {
            try
            {

                cmbProvincia.DataSource = db.Provincias.ToList();
                cmbProvincia.DisplayMember = "nombre";
                cmbProvincia.ValueMember = "numeroProvincia";

                var Venta = new Ventas
                {
                    FeEnt = DateTime.Today,


                };
                db.Ventas.Add(Venta);
                db.SaveChanges();
                ventaId = Venta.VentaId;

                cmbDatosClientes.Visible = false;
                cbmMedioPago.DataSource = db.MediosPago.ToList();
                cbmMedioPago.DisplayMember = "FormaPago";
                cbmMedioPago.ValueMember = "MedioPagoId";
                cmbabreviatura.Items.Add("Sr");
                cmbabreviatura.Items.Add("Sra");
                cmbabreviatura.Items.Add("Srita");

                this.pv2.Visible = false;
                this.pv1.Visible = false;
                this.lbl1.Visible = false;
                this.lbl2.Visible = false;
                var productos = db.Productos.Take(28).ToList();
                var x = 0;
                var y = 0;
                var l = 0;
                var total = db.Productos.Count();
                paginas = total / 28;
                if (total % 28 > 0)
                {
                    paginas += 1;

                }
                if (paginas > 1)
                {
                    this.pv2.Visible = true;
                    this.pv1.Visible = true;
                    this.lbl1.Visible = true;
                    this.lbl2.Visible = true;
                    this.lbl2.Text = paginas.ToString();


                }
                foreach (var item in productos)
                {

                    var botones = new Button();
                    botones.BackgroundImageLayout = ImageLayout.Center;
                 
                    botones.Text = item.Nombre;
                    botones.Name = item.ProductoId.ToString();
                    botones.Location = new Point(x, y);
                    botones.Size = new Size(100, 100);
                    botones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                    botones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    botones.Click += new EventHandler(ClickPrendas);
                    botones.MouseLeave += new EventHandler(Mouseleave);
                    botones.MouseEnter += new EventHandler(Mouseover);
                    this.Prueba.Controls.Add(botones);


                    if (l == 3)
                    {

                        l = 0;
                        x = 0;
                        y += 100;

                    }
                    else
                    {
                        x += 100;

                        l += 1;
                    }
                }
            }
            catch (Exception)
            {

            }

       
        }

        void Mouseover(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;

        }
        void Mouseleave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;


        }
        void ClickPrendas(object sender, EventArgs e)
        {
            try
            {
                txttelefonoprincipal_Validated(sender, e);


                tbpDatos.RowCount = rowCount;
                Button btn = sender as Button;
                var id = int.Parse(btn.Name);
                var productos = db.Productos.Find(id);






                var NombreProducto = productos.Nombre;
                var PrecioProducto = productos.PrecioVenta;
                CargarPanelProductos(productos.ProductoId, NombreProducto, PrecioProducto);
            }
            catch (Exception)
            {

               
            }

          
      

        }
        public void CargarPanelProductos(int aiProducto, string NombreProducto, double PrecioProducto)
        {

            try
            {
                var id = aiProducto;
                var productos = db.Productos.Where(q => q.ProductoId == id).ToList();
                listaProductos = new List<OrdenDetalleViewModel>();
                var Colores = true;
                foreach (var item in productos)
                {

                    var panelViewProductos = new OrdenDetalleViewModel(string.Empty, string.Empty, 0);



                    panelViewProductos.panelTarea.Size = new Size(897, 45);
                    panelViewProductos.panelTarea.MouseEnter += new EventHandler(Mouseovertabla);
                    panelViewProductos.panelTarea.MouseLeave += new EventHandler(Mouseleavetabla);
                    panelViewProductos.panelTarea.Name = item.CodigoId.ToString();

                    if (Colores == true)
                    {
                        panelViewProductos.panelTarea.BackColor = Color.White;
                        Colores = false;
                    }
                    else
                    {
                        panelViewProductos.panelTarea.BackColor = Color.WhiteSmoke;
                        Colores = true;
                    }



                    panelViewProductos.lblTarea.Text = item.Nombre.ToString();

                    panelViewProductos.lblTarea.Location = new Point(0, 0);

                    panelViewProductos.lblTarea.Size = new Size(90, 45);



                    panelViewProductos.txtPrecio.Text = "1";

                    panelViewProductos.txtPrecio.KeyPress += new KeyPressEventHandler(ClickPrecioneTecla);
                    panelViewProductos.txtPrecio.Location = new Point(115, 0);

                    panelViewProductos.txtPrecio.Size = new System.Drawing.Size(100, 34);


                    panelViewProductos.lblPrecio.Text = item.PrecioVenta.ToString();

                    panelViewProductos.lblPrecio.Location = new Point(230, 0);



                    panelViewProductos.cmbDescuentos.Name = item.ProductoId.ToString();
                    panelViewProductos.cmbDescuentos.DataSource = db.Ofertas.ToList();
                    panelViewProductos.cmbDescuentos.DisplayMember = "Descripcion";
                    panelViewProductos.cmbDescuentos.ValueMember = "OfertaId";
                    panelViewProductos.cmbDescuentos.SelectedIndexChanged += new EventHandler(ClickDescuento);

                    panelViewProductos.cmbDescuentos.Location = new Point(325, 0);


                    panelViewProductos.lblSubTotal.Text = item.PrecioVenta.ToString();

                    panelViewProductos.lblSubTotal.Location = new Point(452, 0);



                    panelViewProductos.panelTarea.Controls.Add(panelViewProductos.lblTarea);
                    panelViewProductos.panelTarea.Controls.Add(panelViewProductos.txtPrecio);
                    panelViewProductos.panelTarea.Controls.Add(panelViewProductos.cmbDescuentos);
                    panelViewProductos.panelTarea.Controls.Add(panelViewProductos.lblPrecio);

                    panelViewProductos.panelTarea.Controls.Add(panelViewProductos.lblSubTotal);

                    listaProductos.Add(panelViewProductos);
                    rowCount += 1;
                    tbpDatos.RowCount = rowCount;
                    this.tbpDatos.Controls.Add(listaProductos.Last().panelTarea, 0, rowCount);

                    var ultimatarea = listaProductos.Last();
                    var CantidadArticulos = int.Parse(ultimatarea.txtPrecio.Text);

                    var detalleVenta = new DetalleVentas { Precio = double.Parse(ultimatarea.lblPrecio.Text), Cantidad = CantidadArticulos, Descuento = Descuento, Subtotal = double.Parse(ultimatarea.lblSubTotal.Text), CodigoId = aiProducto, VentaId = ventaId };
                    db.DetalleVentas.Add(detalleVenta);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

              
            }
          
          
          
        }
        private void ClickPrecioneTecla(object sender, KeyPressEventArgs e)
        {
            try
            {
                GuardarCambiosProductos();
                TextBox btn = sender as TextBox;
                var iddos = btn.Name;
                var id = btn.Text;
                String x = "";


                x = id + e.KeyChar;

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


                if (x != "")
                {
                    var ultimatarea = listaProductos.Last();

                    if (!string.IsNullOrEmpty(ultimatarea.txtPrecio.Text))
                    {

                        ultimatarea.lblSubTotal.Text = (int.Parse(x) * int.Parse(ultimatarea.lblPrecio.Text)).ToString();
                        lblDescuentoAbajo.Text = "0,00";




                    }

                    GuardarCambiosProductos();
                }
            }
            catch (Exception)
            {

            }

          


        }
        void ClickDescuento(object sender, EventArgs e)
        {
            try
            {
                ComboBox btn = sender as ComboBox;

                var ultimatarea = listaProductos.Last();

                if (btn.SelectedIndex == 0)
                {
                    ultimatarea.lblSubTotal.Text = (int.Parse(ultimatarea.txtPrecio.Text) * int.Parse(ultimatarea.lblPrecio.Text)).ToString();
                    lblDescuentoAbajo.Text = "0,00";
                    lblSubTotalabajo.Text = (int.Parse(ultimatarea.txtPrecio.Text) * int.Parse(ultimatarea.lblPrecio.Text)).ToString();
                    lblTotal.Text = (int.Parse(ultimatarea.txtPrecio.Text) * int.Parse(ultimatarea.lblPrecio.Text)).ToString();
                    txtpangandoahora.Text = (int.Parse(ultimatarea.txtPrecio.Text) * int.Parse(ultimatarea.lblPrecio.Text)).ToString();
                }


                if (btn.SelectedIndex > 0)
                {
                    var posicion = btn.SelectedValue;
                    var query = db.Ofertas.Find(posicion);

                    var ultimoPrecio = int.Parse(ultimatarea.txtPrecio.Text) * int.Parse(ultimatarea.lblPrecio.Text);
                    var PorsentajeDescuento = query.DescuentoPorsentaje;
                    Descuento = query.DescuentoPorsentaje;
                    var Resultado = (ultimoPrecio * (PorsentajeDescuento) / 100);
                    var ResutadoDescuento = ultimoPrecio - Resultado;
                    ultimatarea.lblSubTotal.Text = ResutadoDescuento.ToString();
                    lblDescuentoAbajo.Text = Resultado.ToString();



                }

                GuardarCambiosProductos();
            }
            catch (Exception)
            {

                
            }

           
        }
            void Mouseovertabla(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;

            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;

        }
        void Mouseleavetabla(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;

            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;


        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                String x = "";


                x = this.txtEfectivo.Text + e.KeyChar;

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




                var total = int.Parse(this.txtpangandoahora.Text);
                if (x != "")
                {
                    var residuo = int.Parse(x);
                    var Resultado = residuo - total;
                    lblResultado.Text = Resultado.ToString();
                }
            }
            catch (Exception)
            {

              
            }
           
        }

        private void button37_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button37_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

      

        private void txttelefonoprincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                String x = "";


                x = this.txttelefonoprincipal.Text + e.KeyChar;

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


                if (x != "")
                {



                    var query = db.Clientes.Where(j => j.TelefonoPrincipal==x.ToString()).Select(t => new { t.ClienteId, t.TelefonoPrincipal, t.Nombre }).ToList();
                    if (query.Count > 0)
                    {
                        cmbDatosClientes.Visible = true;
                        cmbDatosClientes.Items.Clear();

                        foreach (var item in query)
                        {
                            cmbDatosClientes.Items.Add(item.Nombre + "--------------------------------" + item.TelefonoPrincipal);


                        }
                    }
                    else
                    {
                        cmbDatosClientes.Visible = false;
                    }

                }
            }
            catch (Exception)
            {

                
            }

          
        }

        private void txttelefonoprincipal_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttelefonoprincipal.Text.Trim()) || txttelefonoprincipal.Text.Trim() == "Teléfono Cliente")
            {

                txttelefonoprincipal.Text = "";
                txttelefonoprincipal.Focus();
                txttelefonoprincipal.ForeColor = Color.Black;
            }
        }

        private void cmbDatosClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox btr = sender as ComboBox;



                


                var CantidadCaracteres = btr.SelectedItem.ToString();
                var CantidadTotalCaracteres = CantidadCaracteres.Length;
                var CantidadReal = CantidadTotalCaracteres - 8;
                var Telefono = CantidadCaracteres.Remove(0, CantidadReal);
                var query = db.Clientes.Where(j => j.TelefonoPrincipal==Telefono).Select(t => new { t.ClienteId, t.Abreviatura, t.TelefonoPrincipal, t.TelefonoDos, t.Nombre, t.Email, t.Direcion, t.Cedula }).ToList();

                if (query.Count > 0)
                {
                    cmbabreviatura.SelectedItem = query.FirstOrDefault().Abreviatura;
                    txtNombre.Text = query.FirstOrDefault().Nombre;
                   
                
                    txtCodigoPostal.Text = query.FirstOrDefault().Cedula;
                    txtEmail.Text = query.FirstOrDefault().Email;
                    txtDirecion.Text= query.FirstOrDefault().Direcion;
                    txttelefonodos.Text = query.FirstOrDefault().TelefonoDos;
                  
                    txttelefonoprincipal.Text = query.FirstOrDefault().TelefonoPrincipal;

                    txtNombre.ForeColor = Color.Black;
                    txtDirecion.ForeColor = Color.Black;
                 
                    txtCodigoPostal.ForeColor = Color.Black;
                    txtEmail.ForeColor = Color.Black;
                  
                    txttelefonodos.ForeColor = Color.Black;
                   
                    txttelefonoprincipal.ForeColor = Color.Black;

                    cmbDatosClientes.Visible = false;
                    ClienteId = query.FirstOrDefault().ClienteId;


              
                }
            }
            catch (Exception)
            {

             
            }
      

        }

        private void txttelefonoprincipal_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttelefonoprincipal.Text.Trim()) || txttelefonoprincipal.Text.Trim() == "Teléfono Cliente")
            {
                MessageBox.Show("El Nombre es un Dato Obligatorio");
                txttelefonoprincipal.Text = "";
                txttelefonoprincipal.Focus();
                txttelefonoprincipal.ForeColor = Color.Black;
            }
        }

        private void txttelefonoprincipal_Leave(object sender, EventArgs e)
        {
            if (txttelefonoprincipal.Text == "") { 
            txttelefonoprincipal.Text = "Teléfono Cliente";
            txttelefonoprincipal.ForeColor = Color.Silver;
            }
        }

        private void txttelefonodos_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttelefonodos.Text.Trim()) || txttelefonodos.Text.Trim() == "Teléfono 2")
            {

                txttelefonodos.Text = "";
               
                txttelefonodos.ForeColor = Color.Black;
            }
        }

        private void txttelefonodos_MouseLeave(object sender, EventArgs e)
        {
            if (txttelefonodos.Text == "")
            {
                txttelefonodos.Text = "Teléfono 2";
                txttelefonodos.ForeColor = Color.Silver;
            }
        }

        private void txttelefonotres_MouseEnter(object sender, EventArgs e)
        {
          
        }

        private void txttelefonotres_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void txtCalle_MouseEnter(object sender, EventArgs e)
        {
          
        }

        private void txtCalle_MouseLeave(object sender, EventArgs e)
        {
        }

        private void txtNombre_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || txtNombre.Text.Trim() == "Nombre Cliente")
            {

                txtNombre.Text = "";
              
                txtNombre.ForeColor = Color.Black;
            }
        }

        private void txtNombre_MouseLeave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre Cliente";
                txtNombre.ForeColor = Color.Silver;
            }
        }

        private void txtEmail_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()) || txtEmail.Text.Trim() == "Correo Cliente")
            {

                txtEmail.Text = "";
                
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_MouseLeave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Correo Cliente";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtCiudad_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void txtCiudad_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void txtNotas_MouseEnter(object sender, EventArgs e)
        {
         
        }

        private void txtNotas_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void txtCodigoPostal_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoPostal.Text.Trim()) || txtCodigoPostal.Text.Trim() == "Codigo Postal")
            {

                txtCodigoPostal.Text = "";
          
                txtCodigoPostal.ForeColor = Color.Black;
            }
        }

        private void txtCodigoPostal_MouseLeave(object sender, EventArgs e)
        {
            if (txtCodigoPostal.Text == "")
            {
                txtCodigoPostal.Text = "Codigo Postal";
                txtCodigoPostal.ForeColor = Color.Silver;
            }
        }
        void GuardarCambiosProductos()
        {
            try
            {
                using (var db = new DataContextLocal())
                {

                    var ultimatarea = listaProductos.Last();



                    var consulta = db.DetalleVentas.Where(q => q.VentaId == ventaId).ToList();
                    var IdDetalle = consulta.LastOrDefault().DetalleVentasId;

                    var CantidadArticulos = int.Parse(ultimatarea.txtPrecio.Text);

                    DetalleVentas detalle = db.DetalleVentas.Find(IdDetalle);

                    detalle.Cantidad = CantidadArticulos;
                    detalle.Subtotal = double.Parse(ultimatarea.lblSubTotal.Text);
                    detalle.Descuento = Descuento;

                    try
                    {
                        db.Entry(detalle).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }


                    SumatoriaPrecios();

                }
            }
            catch (Exception)
            {

                
            }
           


        }


        void SumatoriaPrecios()
        {
            try
            {
                using (var db = new DataContextLocal())
                {
                    var Detalle = db.DetalleVentas.Where(q => q.VentaId == ventaId).ToList();

                    txtpangandoahora.Text = Detalle.Sum(q => q.Subtotal).ToString();
                    lblTotal.Text = Detalle.Sum(q => q.Subtotal).ToString();
                    var Venta = db.Ventas.Find(ventaId);
                    Venta.TotalOrden = double.Parse(txtpangandoahora.Text);
                    db.Entry(Venta).State = EntityState.Modified;
                    db.SaveChanges();
                    var Subtotal = 0.0;
                    var Descuento = 0.0;
                    var ultimatarea = listaProductos.Last();
                    foreach (var item in Detalle)
                    {
                        var Cantidad = item.Cantidad;
                        var Precio = item.Precio;
                        Subtotal += (Cantidad * Precio);
                        Descuento += ((Cantidad * Precio) * item.Descuento / 100);
                        lblSubTotalabajo.Text = Subtotal.ToString();
                        lblDescuentoAbajo.Text = Descuento.ToString();
                    }





                }

            }
            catch (Exception)
            {

           
            }

          


            
        }
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {

                if (ClienteId == null)
                {








                    if (txtEmail.Text.Trim() == "Correo Cliente")
                    {

                        txtEmail.Text = "";

                    }


                    if (txttelefonodos.Text.Trim() == "Teléfono 2")
                    {

                        txttelefonodos.Text = "";

                    }



                    if (txtDirecion.Text.Trim() == "Dirrecion")
                    {

                        txtDirecion.Text = "";

                    }

                    if (txtCodigoPostal.Text.Trim() == "Cedula")
                    {

                        txtCodigoPostal.Text = "";

                    }

                    if (txtDirecion.Text.Trim() == "Ciudad")
                    {

                        txtDirecion.Text = "";

                    }


                    {
                        Cliente cliente = new Cliente();
                        cliente.Nombre = txtNombre.Text;
                        cliente.Email = txtEmail.Text;
                        cliente.TelefonoPrincipal = txttelefonoprincipal.Text;
                        cliente.Direcion = txttelefonodos.Text;
                        cliente.TelefonoDos = txtDirecion.Text;
                        cliente.numeroProvincia = int.Parse(cmbProvincia.SelectedValue.ToString());
                        cliente.numeroDistrito = int.Parse(cmbDistrito.SelectedValue.ToString());
                        cliente.numeroCanton = int.Parse(cmbCanton.SelectedValue.ToString());
                        cliente.Cedula = txtCodigoPostal.Text;
                        if (cmbabreviatura.SelectedValue != null)
                        {
                            cliente.Abreviatura = cmbabreviatura.SelectedValue.ToString();
                        }
                        db.Clientes.Add(cliente);
                        db.SaveChanges();
                        var querys = db.Clientes.ToList();
                        var ultimoIdCliente = querys.LastOrDefault().ClienteId;

                        var querydos = db.Ordenes.ToList();
                        var ultimaIdOrden = querydos.LastOrDefault().OrdenId;

                        Ordenes orden = db.Ordenes.Find(ultimaIdOrden);

                        orden.ClienteId = ultimoIdCliente;


                        db.Entry(orden).State = EntityState.Modified;
                        db.SaveChanges();



                        GuardarCambiosProductos();


                        frmPin pins = new frmPin();
                        this.Opacity = 0.80;
                        pins.ShowDialog();

                        this.Opacity = 1;

                        var querysr = db.Clientes.Where(q => q.TelefonoPrincipal == txttelefonoprincipal.Text).ToList();
                        if (querysr.Count > 0)
                        {
                           

                            using (var db = new DataContextLocal())
                            {
                                var Ventas = db.Ventas.Find(ventaId);



                                var TotalVenta = int.Parse(Ventas.TotalOrden.ToString());
                                var CantidadPagada = int.Parse(txtpangandoahora.Text);
                                var Resultado = TotalVenta - CantidadPagada;
                                Ventas.CantidadRestante = Resultado;
                                Ventas.EmpleadoRealizo = Program.Pin;
                                Ventas.CantidadPagada = double.Parse(txtpangandoahora.Text);
                                Ventas.ClienteId = ultimoIdCliente;

                                db.Entry(Ventas).State = EntityState.Modified;
                                db.SaveChanges();

                            }




                        }
                        this.Close();

                    }


                }else

                { 
                GuardarCambiosProductos();


                frmPin pin = new frmPin();
                this.Opacity = 0.80;
                pin.ShowDialog();

                this.Opacity = 1;

                var query = db.Clientes.Where(q => q.TelefonoPrincipal == txttelefonoprincipal.Text).ToList();
                if (query.Count > 0)
                {
                    var clienteid = db.Clientes.Where(q => q.TelefonoPrincipal == txttelefonoprincipal.Text).FirstOrDefault().ClienteId;

                    using (var db = new DataContextLocal())
                    {
                        var Ventas = db.Ventas.Find(ventaId);



                        var TotalVenta = int.Parse(Ventas.TotalOrden.ToString());
                        var CantidadPagada = int.Parse(txtpangandoahora.Text);
                        var Resultado = TotalVenta - CantidadPagada;
                        Ventas.CantidadRestante = Resultado;
                        Ventas.EmpleadoRealizo = Program.Pin;
                        Ventas.CantidadPagada = double.Parse(txtpangandoahora.Text);
                        Ventas.ClienteId = clienteid;

                        db.Entry(Ventas).State = EntityState.Modified;
                        db.SaveChanges();

                    }




                }
                this.Close();
                }
            }
            catch (Exception)
            {

                
            }

           
        }

        private void txtDirecion_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDirecion.Text.Trim()) || txtDirecion.Text.Trim() == "Dirrecion")
            {

                txtDirecion.Text = "";

                txtDirecion.ForeColor = Color.Black;
            }
        }

        private void txtDirecion_MouseLeave(object sender, EventArgs e)
        {
            if (txtDirecion.Text == "")
            {
                txtDirecion.Text = "Dirrecion";
                txtDirecion.ForeColor = Color.Silver;
            }
        }

        private void txtDirecion_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDirecion.Text.Trim()) || txtDirecion.Text.Trim() == "Dirrecion")
            {
                MessageBox.Show("LA Dirrecion Es un dato Obligatorio");
                txtDirecion.Text = "";
                txtDirecion.Focus();

            }
        }

        private void txtCodigoPostal_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoPostal.Text.Trim()) || txtCodigoPostal.Text.Trim() == "Cedula")
            {
                MessageBox.Show("El Numero Cedula Es un dato Obligatorio");
                txtCodigoPostal.Text = "";
                txtCodigoPostal.Focus();

            }
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()) || txtEmail.Text.Trim() == "Correo Cliente")
            {
                MessageBox.Show("El Correo Es un dato Obligatorio");
                txtEmail.Text = "";
                txtEmail.Focus();

            }
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || txtNombre.Text.Trim() == "Nombre Cliente")
            {
                MessageBox.Show("El Nombre Es un dato Obligatorio");
                txtNombre.Text = "";
                txtNombre.Focus();

            }
        }


        public void GetCantones(int numeroProvincia)
        {

            var cantones = db.Cantones.Where(m => m.numeroProvincia == numeroProvincia).OrderBy(c => c.nombre);
            cmbCanton.DataSource = cantones.ToList();
            cmbCanton.DisplayMember = "nombre";
            cmbCanton.ValueMember = "numeroCanton";
        }

        public void GetDistritos(int numeroProvincia, int numeroCanton)
        {

            var distritos = db.Distritos.Where(m => m.numeroProvincia == numeroProvincia && m.numeroCanton == numeroCanton).OrderBy(c => c.nombre);
            cmbDistrito.DataSource = distritos.ToList();
            cmbDistrito.DisplayMember = "nombre";
            cmbDistrito.ValueMember = "numeroDistrito";
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbProvincia.SelectedIndex != -1)
            {
                var item = (Provincia)this.cmbProvincia.SelectedItem;
                GetCantones(item.numeroProvincia);
            }

        }

        private void cmbCanton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCanton.SelectedIndex != -1)
            {
                var item = (Canton)this.cmbCanton.SelectedItem;
                GetDistritos(item.numeroProvincia, item.numeroCanton);
            }
        }

        private void txttelefonodos_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttelefonodos.Text.Trim()) || txttelefonodos.Text.Trim() == "Dirrecion")
            {
                MessageBox.Show("LA Dirrecion Es un dato Obligatorio");
                txttelefonodos.Text = "";
                txttelefonodos.Focus();

            }
        }
    }
}
