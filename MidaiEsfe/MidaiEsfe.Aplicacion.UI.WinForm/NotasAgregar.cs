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
    public partial class Nueva_Nota : Form
    {
        public Nueva_Nota()
        {
            InitializeComponent();
            //CREE UN METODO PARA OBTNER TODOS LOS TIPOS DE USUARIOS
            ObtenerTodosLosTiposDePersonas();
        }
        private void ObtenerTodosLosTiposDePersonas()
        {
            // ESTAS LINEAS PUEDE QUEDAR DIRECTO EN EL PersonaAgregar()  PERO MEJOR LO ORDENO EN ESTE METODO
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas> _listaTipoPersona = new List<EntidadesDeNegocio.Notas>();
            MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL _blTp = new LogicaDeNegocio.NotasBL();
            _listaTipoPersona = _blTp.ObtenerTodos();

            cbIdEvaluaciones.DataSource = _listaTipoPersona;
            cbIdEvaluaciones.DisplayMember = "Nombre";
            cbIdEvaluaciones.ValueMember = "Id";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.Notas _entidad = new EntidadesDeNegocio.Notas();
            //solo para modificar o eliminar
            _entidad.IdEvaluacion = byte.Parse(cbIdEvaluaciones.SelectedValue.ToString());
            _entidad.IdAsignacionDeModulo = Int64.Parse(txtIdModuloyEstudiante.Text);
            _entidad.Nota = Int64.Parse(txtNota.Text);

            LogicaDeNegocio.NotasBL _logica = new LogicaDeNegocio.NotasBL();

            int resultadoDeMetodo = _logica.Guardar(_entidad);

            if (resultadoDeMetodo == 1)
            {
                MessageBox.Show("EL registro fue agregado con exito");
                txtIdModuloyEstudiante.Text = "";
                txtNota.Text = "";
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Nueva_Nota_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
