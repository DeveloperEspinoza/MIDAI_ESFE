using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MidaiEsfe.Aplicacion.EntidadesDeNegocio;
using MidaiEsfe.Aplicacion.LogicaDeNegocio;

namespace MidaiEsfe.Aplicacion.UI.WinForm
{
    public partial class NotaPorModulo : Form
    {
        //INTANCIAR BL Y EN
        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas> _listaNotas = new List<EntidadesDeNegocio.Notas>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL _blNotas = new NotasBL();

        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones> _listaEvaluaciones = new List<EntidadesDeNegocio.Evaluaciones>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL _blEvaluaciones = new EvaluacionesBL();

        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo> _listaAsignacionDeModulo = new List<EntidadesDeNegocio.Asignacion_De_Modulo>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL _blAsignacionModulo = new AsignacionDeModuloBL();

        public NotaPorModulo()
        {
            InitializeComponent();          

            _listaEvaluaciones = _blEvaluaciones.ObtenerTodos();
            cbIdAsignacion.DataSource = _listaEvaluaciones;
            cbIdAsignacion.DisplayMember = "Detalle";
            cbIdAsignacion.ValueMember = "Id";
        }
     

      

        private void button1_Click(object sender, EventArgs e)
        {
            NotaPorModuloAgregar Notas = new NotaPorModuloAgregar();
            this.Hide();
            Notas.ShowDialog();
            this.Show();
        }

        private void NotaPorModulo_Load(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL _Notas = new MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas> listaNotas = new List<EntidadesDeNegocio.Notas>();
            listaNotas = _Notas.ObtenerTodos();
            dgvNotasPorModulo.DataSource = listaNotas;

        }

        private void dgvNotasPorModulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
