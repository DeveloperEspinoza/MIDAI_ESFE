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
    public partial class Modulo : Form
    {
        public Modulo()
        {
            InitializeComponent();
            // deshabilitamos todo
            txtNombre.Enabled = false;
            txtIdPersona.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        public MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo modeloParaModificar = new EntidadesDeNegocio.Modulo();


        private void button1_Click(object sender, EventArgs e)
        {
            ModuloAgregar Nuevo_Modulo = new ModuloAgregar();
            this.Hide();
            Nuevo_Modulo.ShowDialog();
            this.Show();
        }

        private void Modulo_Load(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo> lista = new List<EntidadesDeNegocio.Modulo>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

        private void Modulo_Activated(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo> lista = new List<EntidadesDeNegocio.Modulo>();
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
                modeloParaModificar.Nombre = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                //de la entidad le pasamos los datos a las cajas de texto
                txtNombre.Text = modeloParaModificar.Nombre;
                txtIdPersona.Text = modeloParaModificar.IdPersona.ToString();

                // habilitamos todo
                txtNombre.Enabled = true;
                txtIdPersona.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

            }
            catch
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL();
            int respuesta = _bl.Eliminar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue eliminado con exito");

                //refrescamos la lista
                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo> lista = new List<EntidadesDeNegocio.Modulo>();
                lista = _bl.ObtenerTodos();
                dataGridView1.DataSource = lista;

                // deshabilitamos todo
                txtNombre.Text = "";
                txtIdPersona.Text = "";
                txtNombre.Enabled = false;
                txtIdPersona.Enabled = false;
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
            modeloParaModificar.Nombre = txtNombre.Text;
            modeloParaModificar.IdPersona = Int64.Parse(txtIdPersona.Text);


            MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL();
            int respuesta = _bl.Modificar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue modificado con exito");

                //refrescamos la lista
                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo> lista = new List<EntidadesDeNegocio.Modulo>();
                lista = _bl.ObtenerTodos();
                dataGridView1.DataSource = lista;

                // deshabilitamos todo
                txtNombre.Text = "";
                txtIdPersona.Text = "";
                txtNombre.Enabled = false;
                txtIdPersona.Enabled = false;
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
