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
    public partial class Evaluacion : Form
    {
        //INTANCIAR BL Y EN
        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones> _listaEvaluaciones = new List<EntidadesDeNegocio.Evaluaciones>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL _blE = new EvaluacionesBL();

        //INTANCIAR BL Y EN
        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo> _listaModulo = new List<EntidadesDeNegocio.Modulo>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL _blModulo = new ModuloBL();

        public Evaluacion()
        {
            InitializeComponent();
            ObtenerTodosLasEvaluaciones();
            limpiadorYDehabilitadordeCampos();
        }

        private void ObtenerTodosLasEvaluaciones()
        {

            _listaModulo = _blModulo.ObtenerTodos();
            //cuando ya tenemos la lista se la setiamos al combox
            cbIdModulo.DataSource = _listaModulo;
            cbIdModulo.DisplayMember = "Nombre";
            cbIdModulo.ValueMember = "Id";
          




        }

        private void limpiadorYDehabilitadordeCampos()
        {
            // deshabilitamos todo
            txtDetalle.Text = "";
            cbIdModulo.Enabled = false;
            txtFecha.Enabled = false;
            txtDetalle.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

        }
        public MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones modeloParaModificar = new EntidadesDeNegocio.Evaluaciones();


        private void button1_Click(object sender, EventArgs e)
        {
            EvaluacionAgregar Nueva_Evaluacion = new EvaluacionAgregar();
            this.Hide();
            Nueva_Evaluacion.ShowDialog();
            this.Show();
        }

        private void Evaluacion_Load(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones> lista = new List<EntidadesDeNegocio.Evaluaciones>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

        private void Evaluacion_Activated(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones> lista = new List<EntidadesDeNegocio.Evaluaciones>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //llenamos la entidad
                modeloParaModificar.Id = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                modeloParaModificar.IdModulo = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                modeloParaModificar.FechaRegistro = DateTime.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                modeloParaModificar.Detalle = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                //de la entidad le pasamos los datos a las cajas de texto
                cbIdModulo.SelectedValue = modeloParaModificar.IdModulo;
                txtFecha.Text = modeloParaModificar.FechaRegistro.ToString();
                txtDetalle.Text = modeloParaModificar.Detalle.ToString();

                // habilitamos todo
                cbIdModulo.Enabled = true;
                txtFecha.Enabled = true;
                txtDetalle.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

            }
            catch
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL();
            int respuesta = _bl.Eliminar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue eliminado con exito");

                //refrescamos la lista
                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones> lista = new List<EntidadesDeNegocio.Evaluaciones>();
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
            modeloParaModificar.IdModulo = Int64.Parse(cbIdModulo.SelectedValue.ToString());
            modeloParaModificar.FechaRegistro = DateTime.Parse(txtFecha.Text);
            modeloParaModificar.Detalle = txtDetalle.Text;


            MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL();
            int respuesta = _bl.Modificar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue modificado con exito");

                //refrescamos la lista
                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones> lista = new List<EntidadesDeNegocio.Evaluaciones>();
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
    }
}
