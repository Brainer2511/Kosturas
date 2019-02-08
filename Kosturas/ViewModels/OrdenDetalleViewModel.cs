using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kosturas.ViewModels
{
    public class OrdenDetalleViewModel : TemDetallesOrdenes
    {
        [NotMapped]
        public Panel Panel { get; set; }
        public Panel panelTarea { get; set; }
        
        public Label lblTarea;
        public Label lblDetalleTarea;
        public Label lblDescuento;
        public Label lblId;
        public Label lblSubTotal;
        public Label lblEmpleado;
        public Label lblAfiliado;
        public Label lblPrecio;
        public TextBox txtPrecio;
        public TextBox txtDescripcion;
        public Label lblDescripcion;
        public Label txtTotalPrecio;
        public Button btnBorrarTarea { get; set; }
        public Button btnEstado { get; set; }

        public OrdenDetalleViewModel(string tarea, string detalle, double precio)
        {



            #region panelTarea

            panelTarea = new Panel();
            //  Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelTarea.Size = new Size(1020, 40);
            //  Panel.Location = new Point(0,0);
            panelTarea.BackColor = Color.White;

            #endregion

            #region lblTarea
            lblTarea = new Label();
            lblTarea.Size = new System.Drawing.Size(70, 45);
            lblTarea.Location = new Point(0, 10);
            Panel = new Panel();
          //  Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Panel.Size = new Size(897, 45);
          //  Panel.Location = new Point(0,0);
            Panel.BackColor = Color.White;

            lblTarea.Text = tarea;

            #endregion
            #region lblId
            lblId = new Label();

            lblId.Size = new System.Drawing.Size(90, 34);
            lblId.Location = new Point(755, 10);



            #endregion

            #region lblDetalleTarea
            lblDetalleTarea = new Label();
            lblDetalleTarea.Size = new System.Drawing.Size(90, 34);
            lblDetalleTarea.Location = new Point(92, 10);


            lblDetalleTarea.Text = detalle;

            #endregion

            #region lblDescuento
            lblDescuento = new Label();
          
            lblDescuento.Size = new System.Drawing.Size(90, 34);
            lblDescuento.Location = new Point(330, 10);


            #endregion

            #region lblSubTotal
            lblSubTotal = new Label();

            lblSubTotal.Size = new System.Drawing.Size(90, 34);
            lblSubTotal.Location = new Point(800, 10);


            #endregion

            #region lblAfiliado
            lblAfiliado = new Label();
           
            lblAfiliado.Size = new System.Drawing.Size(90, 34);
            lblAfiliado.Location = new Point(755, 10);



            #endregion

            #region lblEmpleado
            lblEmpleado = new Label();

            lblEmpleado.Size = new System.Drawing.Size(90, 34);
            lblEmpleado.Location = new Point(755, 10);



            #endregion

            #region txtPrecioDetalleTarea
            txtPrecio = new TextBox();
            txtPrecio.Size = new System.Drawing.Size(50, 34);
            txtPrecio.Location = new Point(188, 10);



            txtPrecio.Text = precio.ToString();

            #endregion

            #region txtPrecio
            lblPrecio = new Label();
            lblPrecio.Size = new System.Drawing.Size(50, 34);
            lblPrecio.Location = new Point(188, 10);



            txtPrecio.Text = precio.ToString();

            #endregion

            #region txtDescripcion

            txtDescripcion = new TextBox();
            txtDescripcion.Size = new System.Drawing.Size(250, 34);
          
            txtDescripcion.Location = new Point(550, 10);




            txtPrecio.Text = precio.ToString();

            #endregion

            #region Descripcion

            lblDescripcion = new Label();
            lblDescripcion.Size = new System.Drawing.Size(250, 34);

            lblDescripcion.Location = new Point(550, 10);




            txtPrecio.Text = precio.ToString();

            #endregion

            #region txtTotalPrecio
            txtTotalPrecio = new Label();
            txtTotalPrecio.Size = new System.Drawing.Size(97, 15);
            txtTotalPrecio.Location = new Point(517, 8);



            txtPrecio.Text = precio.ToString();

            #endregion

         
            #region btnBorrarTarea
            btnBorrarTarea = new Button();
            btnBorrarTarea.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\equis.png");
            btnBorrarTarea.BackColor = System.Drawing.Color.DarkGray;
            btnBorrarTarea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnBorrarTarea.Location = new Point(860, 6);
            btnBorrarTarea.FlatAppearance.BorderSize = 0;
            btnBorrarTarea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBorrarTarea.Size = new System.Drawing.Size(32, 34);
            btnBorrarTarea.TabIndex = 142;
            btnBorrarTarea.UseVisualStyleBackColor = false;
            #endregion

            #region btnEstado
            btnEstado = new Button();

            btnEstado.Location = new Point(958, 2);
            btnEstado.Size = new Size(60, 36);
            btnEstado.FlatStyle = FlatStyle.Flat;
            btnEstado.ForeColor = Color.LightGray;
            btnEstado.BackColor = Color.LightGray;
            btnEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            #endregion

        }
    }
}
