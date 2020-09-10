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
    public partial class NotaPorModuloAgregar : Form
    {
        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones> _listaEvaluciones = new List<EntidadesDeNegocio.Evaluaciones>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL _blEv = new LogicaDeNegocio.EvaluacionesBL();

        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo> _listaAsignacionModulo = new List<EntidadesDeNegocio.Asignacion_De_Modulo>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL _blAsignacionModulo = new LogicaDeNegocio.AsignacionDeModuloBL();

        Int64 idModulo;

        public NotaPorModuloAgregar()
        {
            InitializeComponent();

          
            _listaEvaluciones = _blEv.ObtenerTodos();
            cbIdEvalucion.DataSource = _listaEvaluciones;
            cbIdEvalucion.DisplayMember = "Detalle";
            cbIdEvalucion.ValueMember = "Id";

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NotaPorModuloAgregar_Load(object sender, EventArgs e)
        {

        }

        private void cbIdEvalucion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in _listaEvaluciones)
                {
                    if(item.Id== Int64.Parse(cbIdEvalucion.SelectedValue.ToString()))
                    {
                        idModulo = item.IdModulo;
                        _listaAsignacionModulo = _blAsignacionModulo.ObtenerTodosLosAlumnosPorModulo(idModulo);
                        cbIdAsignacion.DataSource = _listaAsignacionModulo;
                        cbIdAsignacion.DisplayMember = "NombrePersona";
                        cbIdAsignacion.ValueMember = "Id";
                    }
                }
            }
            catch (Exception)
            {

               // throw;
            }
           
        }

        private void btbAgregar_Click(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas _notas = new EntidadesDeNegocio.Notas();
            MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL _bl = new LogicaDeNegocio.NotasBL();

            _notas.IdEvaluacion = Int64.Parse(cbIdEvalucion.SelectedValue.ToString());
            _notas.IdAsignacionDeModulo = Int64.Parse(cbIdAsignacion.SelectedValue.ToString());
            _notas.Nota = Int64.Parse(txtNota.Text);

           int resultadoDeMetodo = _bl.Guardar(_notas);
            if (resultadoDeMetodo == 1)
            {
                MessageBox.Show("EL registro fue agregado con exito");
                txtNota.Text = "";
            }
            else
            {
                MessageBox.Show("EL registro no fue agregado");
            }
        }
    }
}
