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
    public partial class Evaluaciones : Form
    {
        public Evaluaciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nueva_Evaluacion Nueva_Evaluacion = new Nueva_Evaluacion();
            this.Hide();
            Nueva_Evaluacion.ShowDialog();
            this.Show();
        }
    }
}
