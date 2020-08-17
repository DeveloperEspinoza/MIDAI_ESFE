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
        public Modulo_y_Estudiante()
        {
            InitializeComponent();
            // deshabilitamos todo
            txtIdPersona.Enabled = false;
            txtIdModulo.Enabled = false;
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
                txtIdPersona.Text = modeloParaModificar.IdPersona.ToString();
                txtIdModulo.Text = modeloParaModificar.IdModulo.ToString();
                txtFecha.Text = modeloParaModificar.FechaRegistro.ToString();

                // habilitamos todo
                txtIdPersona.Enabled = true;
                txtIdModulo.Enabled = true;
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
                txtIdPersona.Text = "";
                txtIdModulo.Text = "";
                txtFecha.Text = "";
                txtIdPersona.Enabled = false;
                txtIdModulo.Enabled = false;
                txtFecha.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                MessageBox.Show("El registro no fue eliminado");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //setiamos a la entidad
            modeloParaModificar.IdPersona = Int64.Parse(txtIdPersona.Text);
            modeloParaModificar.IdModulo = Int64.Parse(txtIdPersona.Text);
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
                txtIdPersona.Text = "";
                txtIdModulo.Text = "";
                txtFecha.Text = "";
                txtIdPersona.Enabled = false;
                txtIdModulo.Enabled = false;
                txtFecha.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                MessageBox.Show("El registro no fue modificado");
            }
        }
    }
}
