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
    public partial class EvaluacionAgregar : Form
    {
        public EvaluacionAgregar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.Evaluaciones _entidad = new EntidadesDeNegocio.Evaluaciones();
            //solo para modificar o eliminar
            _entidad.IdModulo = Int64.Parse(txtIdModulo.Text);
            _entidad.FechaRegistro = DateTime.Parse(dateTimePicker1.Text);
            _entidad.Detalle = txtDetalle.Text;
            LogicaDeNegocio.EvaluacionesBL _logica = new LogicaDeNegocio.EvaluacionesBL();

            int resultadoDeMetodo = _logica.Guardar(_entidad);

            if (resultadoDeMetodo == 1)
            {
                MessageBox.Show("EL registro fue agregado con exito");
                txtIdModulo.Text = "";
                dateTimePicker1.Text = "";
                txtDetalle.Text = "";
            }
            else
            {
                MessageBox.Show("EL registro no fue agregado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
