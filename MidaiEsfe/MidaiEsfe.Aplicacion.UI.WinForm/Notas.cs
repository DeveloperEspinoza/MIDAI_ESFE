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
    public partial class Nota : Form
    {
        //INTANCIAR BL Y EN
        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas> _listaNotas = new List<EntidadesDeNegocio.Notas>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL _blNotas = new NotasBL();
    


    public Nota()
        {
            InitializeComponent();
            limpiadorYDehabilitadordeCampos();
            ObtenerTodasLasNotas();

        }


        private void ObtenerTodasLasNotas()
        {
        _listaNotas = _blNotas.ObtenerTodos();
        //cuando ya tenemos la lista se la setiamos al combox
        cbIdEvaluaciones.DataSource = _listaNotas;
        cbIdEvaluaciones.DisplayMember = "Nombre";
        cbIdEvaluaciones.ValueMember = "Id";

            //setiamos otro combox
            cbIdModuloyEstudiante.DataSource = _listaNotas;
            cbIdModuloyEstudiante.DisplayMember = "Nombre";
            cbIdModuloyEstudiante.ValueMember = "Id";

        }

        private void limpiadorYDehabilitadordeCampos()
        {
            // deshabilitamos todo
            txtNota.Text = "";
            cbIdEvaluaciones.Enabled = false;
            cbIdModuloyEstudiante.Enabled = false;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Nueva_Nota Nueva_Nota = new Nueva_Nota();
            this.Hide();
            Nueva_Nota.ShowDialog();
            this.Show();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            //setiamos a la entidad
            modeloParaModificar.IdEvaluacion = Int64.Parse(cbIdEvaluaciones.Text);
            modeloParaModificar.IdAsignacionDeModulo = Int64.Parse(cbIdModuloyEstudiante.Text);
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
                limpiadorYDehabilitadordeCampos();
            }
            else
            {
                MessageBox.Show("El registro no fue modificado");
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //llenamos la entidad
                modeloParaModificar.Id = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                modeloParaModificar.IdEvaluacion = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                modeloParaModificar.IdAsignacionDeModulo = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                modeloParaModificar.Nota = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

                //de la entidad le pasamos los datos a las cajas de texto
                cbIdEvaluaciones.SelectedValue = modeloParaModificar.IdEvaluacion;
                cbIdModuloyEstudiante.SelectedValue = modeloParaModificar.IdAsignacionDeModulo;
                txtNota.Text = modeloParaModificar.Nota.ToString();

                // habilitamos todo
                cbIdEvaluaciones.Enabled = true;
                cbIdModuloyEstudiante.Enabled = true;
                txtNota.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

            }
            catch
            {

            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
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
                limpiadorYDehabilitadordeCampos();
            }
            else
            {
                MessageBox.Show("El registro no fue eliminado");
            }
        }

        private void Nota_Activated(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.NotasBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Notas> lista = new List<EntidadesDeNegocio.Notas>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }
    }
}
