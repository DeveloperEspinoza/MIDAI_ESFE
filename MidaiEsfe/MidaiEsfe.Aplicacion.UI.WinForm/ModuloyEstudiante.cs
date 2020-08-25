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
    public partial class Modulo_y_Estudiante : Form
    {
        //INTANCIAR BL Y EN
        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo> _listaAsignacionDeModulo = new List<EntidadesDeNegocio.Asignacion_De_Modulo>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL _blAsignacionDeModulo = new AsignacionDeModuloBL();

        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Persona> _listaPersonas = new List<EntidadesDeNegocio.Persona>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.PersonaBL _blPersonas = new PersonaBL();

        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo> _listaModulos= new List<EntidadesDeNegocio.Modulo>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL _blModulo = new ModuloBL();


        public Modulo_y_Estudiante()
        {
            InitializeComponent();
            ObtenerTodosLasAsignacionesDeModulo();
            limpiadorYDehabilitadordeCampos();
           
        }
        private void ObtenerTodosLasAsignacionesDeModulo()
        {

            _listaPersonas = _blPersonas.ObtenerTodos();
            //cuando ya tenemos la lista se la setiamos al combox
            cbIdPersona.DataSource = _listaPersonas;

            cbIdPersona.DisplayMember = "Nombres";
            cbIdPersona.ValueMember = "Id";
            //setiamos otro combox
            _listaModulos = _blModulo.ObtenerTodos();
            cbIdModulo.DataSource = _listaModulos;
            cbIdModulo.DisplayMember = "Nombre";
            cbIdModulo.ValueMember = "Id";


        }

        private void limpiadorYDehabilitadordeCampos()
        {
            // deshabilitamos todo
            txtFecha.Text = "";
            cbIdPersona.Enabled = false;
            cbIdModulo.Enabled = false;
            txtFecha.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

        }
        public MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo modeloParaModificar = new EntidadesDeNegocio.Asignacion_De_Modulo();


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ModulosyEstudiantesAgregar Modulo_y_Estudinate = new ModulosyEstudiantesAgregar();
            this.Hide();
            Modulo_y_Estudinate.ShowDialog();
            this.Show();
        }

        private void Modulo_y_Estudiante_Load(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo> lista = new List<EntidadesDeNegocio.Asignacion_De_Modulo>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

        private void Modulo_y_Estudiante_Activated(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo> lista = new List<EntidadesDeNegocio.Asignacion_De_Modulo>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //llenamos la entidad
                modeloParaModificar.Id = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                modeloParaModificar.IdPersona = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                modeloParaModificar.IdModulo = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                modeloParaModificar.FechaRegistro = DateTime.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

                //de la entidad le pasamos los datos a las cajas de texto
                cbIdPersona.SelectedValue = modeloParaModificar.IdPersona;
                cbIdModulo.SelectedValue = modeloParaModificar.IdModulo;
                txtFecha.Text = modeloParaModificar.FechaRegistro.ToString();

                // habilitamos todo
                txtFecha.Text = "";
                cbIdPersona.Enabled = true;
                cbIdModulo.Enabled = true;
                txtFecha.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

            }
            catch
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL();
            int respuesta = _bl.Eliminar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue eliminado con exito");

                //refrescamos la lista
                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo> lista = new List<EntidadesDeNegocio.Asignacion_De_Modulo>();
                lista = _bl.ObtenerTodos();
                dataGridView1.DataSource = lista;

                // deshabilitamos todo
                limpiadorYDehabilitadordeCampos();

            }
            else
            {
                MessageBox.Show("El registro no fue eliminado");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //setiamos a la entidad
            modeloParaModificar.IdPersona = Int64.Parse(cbIdPersona.SelectedValue.ToString());
            modeloParaModificar.IdModulo = Int64.Parse(cbIdModulo.SelectedValue.ToString());
            modeloParaModificar.FechaRegistro = DateTime.Parse(txtFecha.Text);


            MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL();
            int respuesta = _bl.Modificar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue modificado con exito");

                //refrescamos la lista
                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo> lista = new List<EntidadesDeNegocio.Asignacion_De_Modulo>();
                lista = _bl.ObtenerTodos();
                dataGridView1.DataSource = lista;

                // deshabilitamos todo
                limpiadorYDehabilitadordeCampos();

            }
            else
            {
                MessageBox.Show("El registro no fue modificado");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
