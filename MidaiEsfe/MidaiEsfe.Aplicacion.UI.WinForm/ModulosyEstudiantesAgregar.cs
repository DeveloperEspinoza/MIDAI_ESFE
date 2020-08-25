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
       

        public ModulosyEstudiantesAgregar()
        {
            InitializeComponent();
            //CREE UN METODO PARA OBTNER TODOS LOS TIPOS DE USUARIOS
            ObtenerTodosLosTiposDePersonas();
        }

        private void ObtenerTodosLosTiposDePersonas()
        {
            // ESTAS LINEAS PUEDE QUEDAR DIRECTO EN EL PersonaAgregar()  PERO MEJOR LO ORDENO EN ESTE METODO
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo> _listaAsignaciondeModulo = new List<EntidadesDeNegocio.Asignacion_De_Modulo>();
            MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL _blAM = new LogicaDeNegocio.AsignacionDeModuloBL();

            _listaAsignaciondeModulo = _blAM.ObtenerTodos();
            cbIdPersona.DataSource = _listaAsignaciondeModulo;
            cbIdPersona.DisplayMember = "Id";
            cbIdPersona.ValueMember = "Id";
            //setiamos otro 
            _listaAsignaciondeModulo = _blAM.ObtenerTodos();
            cbIdModulo.DataSource = _listaAsignaciondeModulo;
            cbIdModulo.DisplayMember = "Id";
            cbIdModulo.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.Asignacion_De_Modulo _entidad = new EntidadesDeNegocio.Asignacion_De_Modulo();
            //solo para modificar o eliminar
            _entidad.IdPersona = Int64.Parse(cbIdPersona.Text);
            _entidad.IdModulo = Int64.Parse(cbIdModulo.Text);
            _entidad.FechaRegistro = DateTime.Parse(txtFecha.Text);

            LogicaDeNegocio.AsignacionDeModuloBL _logica = new LogicaDeNegocio.AsignacionDeModuloBL();

            int resultadoDeMetodo = _logica.Guardar(_entidad);

            if (resultadoDeMetodo == 1)
            {
                MessageBox.Show("EL registro fue agregado con exito");
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

        private void txtIdPersona_TextChanged(object sender, EventArgs e)
        {

        }

        private void ModulosyEstudiantesAgregar_Load(object sender, EventArgs e)
        {

        }
    }
}
