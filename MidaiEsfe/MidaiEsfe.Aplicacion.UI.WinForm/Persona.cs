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
    public partial class Persona : Form
    {
        public Persona()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.Persona _entidad = new EntidadesDeNegocio.Persona();
            //solo para modificar o eliminar
            _entidad.IdTipoPersona = byte.Parse(txtIdTipoPersona.Text);
            _entidad.Nombres = txtNombres.Text;
            _entidad.Apellidos = txtApellidos.Text;

            LogicaDeNegocio.PersonaBL _logica = new LogicaDeNegocio.PersonaBL();

            int resultadoDeMetodo = _logica.Guardar(_entidad);

            if (resultadoDeMetodo == 1)
            {
                MessageBox.Show("EL registro fue guardado con exito");
                txtNombres.Text = "";
            }
            else
            {
                MessageBox.Show("EL registro no fue guardado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
