using Domain;
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

namespace Kosturas.View
{
    public partial class frmMonedasBilletes : Form
    {
        public int CierreId { get; set; }
        private CierreCaja cierre = new CierreCaja();
        DataContextLocal db = new DataContextLocal();
        Color ColorEntrada;
        public frmMonedasBilletes(int cierreId = 0)
        {
            CierreId = cierreId;
            cierre = db.CierreCajas.Find(cierreId);
            InitializeComponent();
        }

        private void frmMonedasBilletes_Load(object sender, EventArgs e)
        {

            txt5.Text = cierre.CantidadMonedas5;
            txt10.Text = cierre.CantidadMonedas10;
            txt25.Text = cierre.CantidadMonedas25;
            txt50.Text = cierre.CantidadMonedas50;
            txt100.Text = cierre.CantidadMonedas100;
            txt500.Text = cierre.CantidadMonedas500;

            txt1000.Text = cierre.CantidadBilletes1000;
            txt2000.Text = cierre.CantidadBilletes2000;
            txt5000.Text = cierre.CantidadBilletes5000;
            txt10000.Text = cierre.CantidadBilletes10000;
            txt20000.Text = cierre.CantidadBilletes20000;
            txt50000.Text = cierre.CantidadBilletes50000;

            lbl5.Text = (double.Parse(txt5.Text)*5).ToString() + ",00";
            lbl10.Text = (double.Parse(txt10.Text) * 10).ToString() + ",00";
            lbl25.Text = (double.Parse(txt25.Text) * 25).ToString() + ",00";
            lbl50.Text = (double.Parse(txt50.Text) * 50).ToString() + ",00";
            lbl100.Text = (double.Parse(txt100.Text) * 100).ToString() + ",00";
            lbl500.Text = (double.Parse(txt500.Text) * 500).ToString() + ",00";

            lbl1000.Text = (double.Parse(txt1000.Text) * 1000).ToString() + ",00";
            lbl2000.Text = (double.Parse(txt2000.Text) * 2000).ToString() + ",00";
            lbl5000.Text = (double.Parse(txt5000.Text) * 5000).ToString() + ",00";
            lbl10000.Text = (double.Parse(txt10000.Text) * 10000).ToString() + ",00";
            lbl20000.Text = (double.Parse(txt20000.Text) * 20000).ToString() + ",00";
            lbl50000.Text = (double.Parse(txt50000.Text) * 50000).ToString() + ",00";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
