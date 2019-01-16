using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
namespace Kosturas.ViewModels
{
    public class OrdenPrendaViewModel : TemDetallesOrdenPrenda
    {
        [NotMapped]
        public Panel Panel { get; set; }
        public Label lblPrenda;
        public Button btnPrioridad { get; set; }
        public Button btnDuplicar { get; set; }
        public Button btnCantidad { get; set; }
        public Button btnmascinco { get; set; }
        public Button btnmasuno { get; set; }
        public Button btnmenosuno { get; set; }
        public Button btnmenoscinco { get; set; }
        public Button btnagregartarea { get; set; }

        public OrdenPrendaViewModel(string prenda)
        {
            lblPrenda = new Label();
            lblPrenda.Size = new System.Drawing.Size(70, 45);
            lblPrenda.Location = new Point(0, 10);

           
            Panel = new Panel(); 
            Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Panel.Size = new Size(897, 50);
            Panel.BackColor = Color.DarkGray;
          
            lblPrenda.Text = prenda;
         
            #region btnPrioridad
            btnPrioridad = new Button();
            btnPrioridad.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\primera.png");
            btnPrioridad.BackColor = System.Drawing.Color.DarkGray;
            btnPrioridad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnPrioridad.Location = new Point(634, 6);
            btnPrioridad.FlatAppearance.BorderSize = 0;
            btnPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPrioridad.Size = new System.Drawing.Size(32, 34);
            btnPrioridad.TabIndex = 142;
            btnPrioridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnPrioridad.UseVisualStyleBackColor = false;
            #endregion

            #region btnDuplicar
            btnDuplicar = new Button();
            btnDuplicar.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\duplicar.png");
            btnDuplicar.BackColor = System.Drawing.Color.DarkGray;
            btnDuplicar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnDuplicar.Location = new Point(666, 6);
            btnDuplicar.FlatAppearance.BorderSize = 0;
            btnDuplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDuplicar.Size = new System.Drawing.Size(32, 34);
            btnDuplicar.TabIndex = 142;
            btnDuplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnDuplicar.UseVisualStyleBackColor = false;
            #endregion
              
            #region btnCantidad
            btnCantidad = new Button();
            btnCantidad.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\qrd.png");
            btnCantidad.BackColor = System.Drawing.Color.DarkGray;
            btnCantidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnCantidad.Location = new Point(698, 6);
            btnCantidad.FlatAppearance.BorderSize = 0;
            btnCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCantidad.Size = new System.Drawing.Size(32, 34);
            btnCantidad.TabIndex = 142;
            btnCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnCantidad.UseVisualStyleBackColor = false;
            #endregion


            #region btnmascinco
            btnmascinco = new Button();

            btnmascinco.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\cincomas.png");
            btnmascinco.BackColor = System.Drawing.Color.DarkGray;
            btnmascinco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnmascinco.Location = new Point(730, 6);
            btnmascinco.FlatAppearance.BorderSize = 0;
            btnmascinco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnmascinco.Size = new System.Drawing.Size(32, 34);
            btnmascinco.TabIndex = 142;
            btnmascinco.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnmascinco.UseVisualStyleBackColor = false;
            #endregion

            #region btnmasuno
            btnmasuno = new Button();
            btnmasuno.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\unomas.png");
            btnmasuno.BackColor = System.Drawing.Color.DarkGray;
            btnmasuno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnmasuno.Location = new Point(762, 6);
            btnmasuno.FlatAppearance.BorderSize = 0;
            btnmasuno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnmasuno.Size = new System.Drawing.Size(32, 34);
            btnmasuno.TabIndex = 142;
            btnmasuno.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnmasuno.UseVisualStyleBackColor = false;
            #endregion

            #region btnmenosuno
            btnmenosuno = new Button();
            btnmenosuno.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\unomenos.png");
            btnmenosuno.BackColor = System.Drawing.Color.DarkGray;
            btnmenosuno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnmenosuno.Location = new Point(794, 6);
            btnmenosuno.FlatAppearance.BorderSize = 0;
            btnmenosuno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnmenosuno.Size = new System.Drawing.Size(32, 34);
            btnmenosuno.TabIndex = 142;
            btnmenosuno.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnmenosuno.UseVisualStyleBackColor = false;
            #endregion


            #region btnmenoscinco
            btnmenoscinco = new Button();
            btnmenoscinco.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\cincomenos.png");
            btnmenoscinco.BackColor = System.Drawing.Color.DarkGray;
            btnmenoscinco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnmenoscinco.Location = new Point(828, 6);
            btnmenoscinco.FlatAppearance.BorderSize = 0;
            btnmenoscinco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnmenoscinco.Size = new System.Drawing.Size(32, 34);
            btnmenoscinco.TabIndex = 142;
            btnmenoscinco.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnmenoscinco.UseVisualStyleBackColor = false;
            #endregion


            #region btnagregartarea
            btnagregartarea = new Button();
            btnagregartarea.Image = Image.FromFile("C:\\Users\\Erickxon\\Desktop\\Nueva carpeta\\Nueva carpeta\\Kosturas\\Imagenes\\taps.png");
            btnagregartarea.BackColor = System.Drawing.Color.DarkGray;
            btnagregartarea.Location = new Point(860, 6);
            btnagregartarea.FlatAppearance.BorderSize = 0;
            btnagregartarea.FlatStyle = FlatStyle.Flat;
            btnagregartarea.ForeColor = Color.DarkGray;
            btnagregartarea.Size = new System.Drawing.Size(32, 34);
            btnagregartarea.TabIndex = 142;
            btnagregartarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         
            #endregion
        }

    }
}
