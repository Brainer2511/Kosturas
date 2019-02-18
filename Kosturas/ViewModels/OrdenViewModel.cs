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
  public  class OrdenViewModel:Ordenes
    {
        [NotMapped]
        public Panel Panel { get; set; }
        public Label lblId;
        public Label lblNombre;
        public Label lblLocalizacion;
        public Label lblFechaEntrada;
        public Label lblHoraEntrada;
        public Label lblTotal;
        public Label lblDetalles;
        public Label lblEstado;
        public Label lblMontoPagado;
        public Label lblMontoRestante;
        public Button btnEstado { get; set; }

        public OrdenViewModel()
        {


            Panel = new Panel();
       
            Panel.Size = new Size(1397, 40);
            Panel.BackColor = Color.White;



            #region lblId

            lblId = new Label();

            lblId.Location = new Point(0, 8);
            lblId.Size = new Size(100, 25);


            #endregion

            #region lblNombre
            lblNombre = new Label();

            lblNombre.Size = new Size(200, 25);
            lblNombre.Location = new Point(110, 8);
            #endregion

            #region lblFechaEntrada
             lblFechaEntrada = new Label();

            lblFechaEntrada.Size = new Size(150, 25);
            lblFechaEntrada.Location = new Point(315, 8);
            #endregion


            #region lblLocalizacion
            lblLocalizacion = new Label();

            lblLocalizacion.Location = new Point(545, 8);
            lblLocalizacion.Size = new Size(50, 25);
            #endregion

            #region lblHoraEntrada
            lblHoraEntrada = new Label();

            lblHoraEntrada.Location = new Point(680, 8);
            lblHoraEntrada.Size = new Size(110, 25);
            #endregion

            #region lblTotal
            lblTotal = new Label();

            lblTotal.Location = new Point(810, 8);
            lblTotal.Size = new Size(150, 25);
            #endregion


            #region lblDetalles
            lblDetalles = new Label();

            lblDetalles.Location = new Point(810, 8);
            lblDetalles.Size = new Size(150, 25);
            #endregion

            #region lblMontoPagado
            lblMontoPagado = new Label();

            lblMontoPagado.Location = new Point(980, 8);
            lblMontoPagado.Size = new Size(150, 25);
            #endregion


            #region lblMontoRestante
            lblMontoRestante = new Label();
            lblMontoRestante.Location = new Point(1150, 8);
            lblMontoRestante.Size = new Size(150, 25);
            #endregion

            #region btnEstado
            btnEstado = new Button();

            btnEstado.Location = new Point(1334, 2);
            btnEstado.Size = new Size(60, 36);
            btnEstado.FlatStyle = FlatStyle.Flat;
            btnEstado.ForeColor = Color.LightGray;
            btnEstado.BackColor = Color.LightGray;
            btnEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            #endregion

            #region lblEstado
            lblEstado = new Label();

            lblEstado.Location = new Point(980, 8);
            lblEstado.Size = new Size(150, 25);
            #endregion

            


        }
    }
}
