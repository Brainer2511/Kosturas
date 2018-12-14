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
    public partial class frmCorreosSMS : Form
    {
        public frmCorreosSMS()
        {
            InitializeComponent();
        }

        private void frmCorreosSMS_Load(object sender, EventArgs e)
        {
            TextBox txt15 = new TextBox();
            txt15.Name = "txt15";
            txt15.Height = 300;
           // txt15.Click=
            this.Controls.Add(txt15);
        }
    }
}
