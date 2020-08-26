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
            // ESTAS LINEAS PUEDE QUEDAR DIRECTO EN EL ModuloyEstudiantesAgregar()  PERO MEJOR LO ORDENO EN ESTE METODO
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo> _listaAsignaciondeModulo = new List<EntidadesDeNegocio.Asignacion_De_Modulo>();
            MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL _blAM = new LogicaDeNegocio.AsignacionDeModuloBL();

            // ESTAS LINEAS PUEDE QUEDAR DIRECTO EN EL ModuloyEstudiantesAgregar()  PERO MEJOR LO ORDENO EN ESTE METODO
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Persona> _listaPersona = new List<EntidadesDeNegocio.Persona>();
            MidaiEsfe.Aplicacion.LogicaDeNegocio.PersonaBL _blPersona = new LogicaDeNegocio.PersonaBL();

            // ESTAS LINEAS PUEDE QUEDAR DIRECTO EN EL ModuloyEstudiantesAgregar()  PERO MEJOR LO ORDENO EN ESTE METODO
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo> _listaModulo = new List<EntidadesDeNegocio.Modulo>();
            MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL _blModulo = new LogicaDeNegocio.ModuloBL();

            _listaPersona = _blPersona.ObtenerTodos();
            cbIdPersona.DataSource = _listaPersona;
            cbIdPersona.DisplayMember = "Nombres";
            cbIdPersona.ValueMember = "Id";
            //setiamos otro 
            _listaModulo = _blModulo.ObtenerTodos();
            cbIdModulo.DataSource = _listaModulo;
            cbIdModulo.DisplayMember = "Nombre";
            cbIdModulo.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.Asignacion_De_Modulo _entidad = new EntidadesDeNegocio.Asignacion_De_Modulo();
            //solo para modificar o eliminar
            _entidad.IdPersona = Int64.Parse(cbIdPersona.SelectedValue.ToString());
            _entidad.IdModulo = Int64.Parse(cbIdModulo.SelectedValue.ToString());
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
