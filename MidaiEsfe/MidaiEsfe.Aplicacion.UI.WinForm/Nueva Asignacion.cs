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
    public partial class Nueva_Asignacion : Form
    {
        public Nueva_Asignacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.AsignacionDeModulo _entidad = new EntidadesDeNegocio.AsignacionDeModulo();
            //solo para modificar o eliminar
            _entidad.IdPersona = byte.Parse(txtIdPersona.Text);
            _entidad.IdModulo = byte.Parse(txtIdModulo.Text);
            _entidad.FechaRegistro = DateTime.Parse(txtFecha.Text);

            LogicaDeNegocio.AsignacionDeModuloBL _logica = new LogicaDeNegocio.AsignacionDeModuloBL();

            int resultadoDeMetodo = _logica.Guardar(_entidad);

            if (resultadoDeMetodo == 1)
            {
                MessageBox.Show("EL registro fue agregado con exito");
                txtIdPersona.Text = "";
                txtIdModulo.Text = "";
                txtFecha.Text = "";
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
    }
}
