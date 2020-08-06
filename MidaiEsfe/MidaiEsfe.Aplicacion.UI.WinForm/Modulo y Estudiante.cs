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
    public partial class Modulo_y_Estudiante : Form
    {
        public Modulo_y_Estudiante()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nueva_Asignacion Nueva_Asignacion = new Nueva_Asignacion();
            this.Hide();
            Nueva_Asignacion.ShowDialog();
            this.Show();
        }
    }
}
