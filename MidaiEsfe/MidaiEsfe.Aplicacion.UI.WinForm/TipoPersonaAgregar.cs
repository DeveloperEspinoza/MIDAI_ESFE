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
    public partial class TipoPersonaAgregar : Form
    {
        public TipoPersonaAgregar()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.TipoPersona _entidad = new EntidadesDeNegocio.TipoPersona();
            //solo para modificar o eliminar
            _entidad.Nombre = Nombre.Text;

            LogicaDeNegocio.TipoPersonaBL _logica = new LogicaDeNegocio.TipoPersonaBL();

            int resultadoDeMetodo = _logica.Guardar(_entidad);

            if (resultadoDeMetodo == 1)
            {
                MessageBox.Show("EL registro fue agregado con exito");
                Nombre.Text = "";
            }
            else
            {
                MessageBox.Show("EL registro no fue agregado");
            }


        }
    }
}
