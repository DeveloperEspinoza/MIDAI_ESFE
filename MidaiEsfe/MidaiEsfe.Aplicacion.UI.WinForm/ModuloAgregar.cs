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
    public partial class ModuloAgregar : Form
    {
        public ModuloAgregar()
        {

            InitializeComponent();
            //CREE UN METODO PARA OBTNER TODOS LOS TIPOS DE USUARIOS
            ObtenerTodosLosTiposDePersonas();
        }
        private void ObtenerTodosLosTiposDePersonas()
        {
            // ESTAS LINEAS PUEDE QUEDAR DIRECTO EN EL PersonaAgregar()  PERO MEJOR LO ORDENO EN ESTE METODO
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo> _listaTipoPersona = new List<EntidadesDeNegocio.Modulo>();
            MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL _blTp = new LogicaDeNegocio.ModuloBL();
            _listaTipoPersona = _blTp.ObtenerTodos();

            cbIdPersona.DataSource = _listaTipoPersona;
            cbIdPersona.DisplayMember = "Nombre";
            cbIdPersona.ValueMember = "Id";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.Modulo _entidad = new EntidadesDeNegocio.Modulo();
            //solo para modificar o eliminar
            _entidad.IdPersona = byte.Parse(cbIdPersona.SelectedValue.ToString());
            _entidad.Nombre = txtNombre.Text;

            LogicaDeNegocio.ModuloBL _logica = new LogicaDeNegocio.ModuloBL();

            int resultadoDeMetodo = _logica.Guardar(_entidad);

            if (resultadoDeMetodo == 1)
            {
                MessageBox.Show("EL registro fue agregado con exito");
                txtNombre.Text = "";
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ModuloAgregar_Load(object sender, EventArgs e)
        {

        }
    }
}
