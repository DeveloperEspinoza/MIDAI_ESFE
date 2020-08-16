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
    public partial class TipoPersona : Form
    {
        MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona modeloParaModificar = new EntidadesDeNegocio.TipoPersona();

        public TipoPersona()
        {
            InitializeComponent();
            txtNombre.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoPersonaAgregar tipoPersonaAgregar = new TipoPersonaAgregar();
            this.Hide();
            tipoPersonaAgregar.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TipoPersona_Load(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.TipoPersonaBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.TipoPersonaBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona> lista = new List<EntidadesDeNegocio.TipoPersona>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

        private void TipoPersona_Activated(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.TipoPersonaBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.TipoPersonaBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona> lista = new List<EntidadesDeNegocio.TipoPersona>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            modeloParaModificar.Nombre = txtNombre.Text;

            MidaiEsfe.Aplicacion.LogicaDeNegocio.TipoPersonaBL _bl = new TipoPersonaBL();
            int respuesta = _bl.Modificar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue modificado con exito");

                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona> lista = new List<EntidadesDeNegocio.TipoPersona>();
                lista = _bl.ObtenerTodos();
                dataGridView1.DataSource = lista;

                txtNombre.Text = "";
                txtNombre.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                MessageBox.Show("El registro no fue modificado");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                modeloParaModificar.Id = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                modeloParaModificar.Nombre = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNombre.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                txtNombre.Text = modeloParaModificar.Nombre;
            }
            catch
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.TipoPersonaBL _bl = new TipoPersonaBL();
           int respuesta = _bl.Eliminar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue eliminado con exito");

                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona> lista = new List<EntidadesDeNegocio.TipoPersona>();
                lista = _bl.ObtenerTodos();
                dataGridView1.DataSource = lista;

                txtNombre.Text = "";
                txtNombre.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                MessageBox.Show("El registro no fue eliminado");
            }

        }
    }
}
