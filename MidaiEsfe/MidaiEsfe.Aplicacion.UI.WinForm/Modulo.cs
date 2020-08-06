using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidaiEsfe.Aplicacion.UI.WinForm
{
    public partial class Modulo : Form
    {
        public Modulo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo_Modulo Nuevo_Modulo = new Nuevo_Modulo();
            this.Hide();
            Nuevo_Modulo.ShowDialog();
            this.Show();
        }
    }
}
