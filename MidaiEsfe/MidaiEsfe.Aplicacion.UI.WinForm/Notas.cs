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
    public partial class Notas : Form
    {
        public Notas()
        {
            InitializeComponent();
            // deshabilitamos todo
            txtIdEvaluaciones.Enabled = false;
            txtIdModuloyEstudiante.Enabled = false;
            txtNota.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        public MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas modeloParaModificar = new EntidadesDeNegocio.Notas();

        private void button1_Click(object sender, EventArgs e)
        {
            Nueva_Nota Nueva_Nota = new Nueva_Nota();
            this.Hide();
            Nueva_Nota.ShowDialog();
            this.Show();
        }

        private void Notas_Load(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas> lista = new List<EntidadesDeNegocio.Notas>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

        private void Notas_Activated(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas> lista = new List<EntidadesDeNegocio.Notas>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //llenamos la entidad
                modeloParaModificar.Id = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                modeloParaModificar.IdEvaluacion = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                modeloParaModificar.IdAsignacionDeModulo = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                modeloParaModificar.Nota =Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

                //de la entidad le pasamos los datos a las cajas de texto
                txtIdEvaluaciones.Text = modeloParaModificar.IdEvaluacion.ToString();
                txtIdModuloyEstudiante.Text = modeloParaModificar.IdAsignacionDeModulo.ToString();
                txtNota.Text = modeloParaModificar.Nota.ToString();

                // habilitamos todo
                txtIdEvaluaciones.Enabled = true;
                txtIdModuloyEstudiante.Enabled = true;
                txtNota.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

            }
            catch
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL();
            int respuesta = _bl.Eliminar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue eliminado con exito");

                //refrescamos la lista
                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas> lista = new List<EntidadesDeNegocio.Notas>();
                lista = _bl.ObtenerTodos();
                dataGridView1.DataSource = lista;

                // deshabilitamos todo
                txtIdEvaluaciones.Text = "";
                txtIdModuloyEstudiante.Text = "";
                txtNota.Text = "";
                txtIdEvaluaciones.Enabled = false;
                txtIdModuloyEstudiante.Enabled = false;
                txtNota.Enabled = false;
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
            modeloParaModificar.IdEvaluacion = Int64.Parse(txtIdEvaluaciones.Text);
            modeloParaModificar.IdAsignacionDeModulo = Int64.Parse(txtIdModuloyEstudiante.Text);
            modeloParaModificar.Nota = Int64.Parse(txtNota.Text);


            MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL();
            int respuesta = _bl.Modificar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue modificado con exito");

                //refrescamos la lista
                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas> lista = new List<EntidadesDeNegocio.Notas>();
                lista = _bl.ObtenerTodos();
                dataGridView1.DataSource = lista;

                // deshabilitamos todo
                txtIdEvaluaciones.Text = "";
                txtIdModuloyEstudiante.Text = "";
                txtNota.Text = "";
                txtIdEvaluaciones.Enabled = false;
                txtIdModuloyEstudiante.Enabled = false;
                txtNota.Enabled = false;
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
