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
    public partial class ModulosyEstudiantesAgregar : Form
    {
        private object txtFecha;

        public ModulosyEstudiantesAgregar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.Asignacion_De_Modulo _entidad = new EntidadesDeNegocio.Asignacion_De_Modulo();
            //solo para modificar o eliminar
            _entidad.IdPersona = Int64.Parse(txtIdPersona.Text);
            _entidad.IdModulo = Int64.Parse(txtIdModulo.Text);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
