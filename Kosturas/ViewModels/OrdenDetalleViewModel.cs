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
        public Label lblTarea;
        public Label lblDetalleTarea;
        public TextBox txtPrecio;
        public Button btnBorrarTarea { get; set; }

        public OrdenDetalleViewModel(string tarea, string detalle, double precio)
        {

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

            #region lblDetalleTarea
            lblDetalleTarea = new Label();
            lblDetalleTarea.Size = new System.Drawing.Size(90, 34);
            lblDetalleTarea.Location = new Point(92, 10);


            lblDetalleTarea.Text = detalle;

            #endregion

            #region txtPrecioDetalleTarea
            txtPrecio = new TextBox();
            txtPrecio.Size = new System.Drawing.Size(50, 34);
            txtPrecio.Location = new Point(188, 10);



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

        }
    }
}
