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
    public partial class Evaluacion : Form
    {
        public Evaluacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EvaluacionAgregar Nueva_Evaluacion = new EvaluacionAgregar();
            this.Hide();
            Nueva_Evaluacion.ShowDialog();
            this.Show();
        }

        private void Evaluacion_Activated(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones> lista = new List<EntidadesDeNegocio.Evaluaciones>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

        private void Evaluacion_Load(object sender, EventArgs e)
        {

        }
    }
}
