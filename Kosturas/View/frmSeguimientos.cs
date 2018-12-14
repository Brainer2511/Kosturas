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
    public partial class frmSeguimientos : Form
    {
        public frmSeguimientos()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarCambios_MouseEnter(object sender, EventArgs e)
        {
            this.btnGuardarCambios.BackColor = System.Drawing.Color.OliveDrab;
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.White;
        }
    

        private void btnGuardarCambios_MouseLeave(object sender, EventArgs e)
        {

        this.btnGuardarCambios.BackColor = System.Drawing.SystemColors.Control;
        this.btnGuardarCambios.ForeColor = System.Drawing.Color.Black;
         }
    }
}
