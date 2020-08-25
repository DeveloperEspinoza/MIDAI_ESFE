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
        //INTANCIAR BL Y EN
        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo> _listaModulo = new List<EntidadesDeNegocio.Modulo>();
        MidaiEsfe.Aplicacion.LogicaDeNegocio.ModuloBL _blModulo = new ModuloBL();

        public Modulo()
        {
            InitializeComponent();
            limpiadorYDehabilitadordeCampos();
            ObtenerTodosLasAsignacionesDeModulo();
        
         }
           private void ObtenerTodosLasAsignacionesDeModulo()
        {

            _listaModulo = _blModulo.ObtenerTodos();
            //cuando ya tenemos la lista se la setiamos al combox
            cbIdPersona.DataSource = _listaModulo;
            cbIdPersona.DisplayMember = "Id";
            cbIdPersona.ValueMember = "Id";


        }

        private void limpiadorYDehabilitadordeCampos()
        {
            // deshabilitamos todo
            txtNombre.Text = "";
            txtNombre.Enabled = false;
            cbIdPersona.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

        }
        public MidaiEsfe.Aplicacion.EntidadesDeNegocio.Modulo modeloParaModificar = new EntidadesDeNegocio.Modulo();


        private void btnNuevo_Click(object sender, EventArgs e)
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

        private void btnEliminar_Click_1(object sender, EventArgs e)
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
                limpiadorYDehabilitadordeCampos();
            }
            else
            {
                MessageBox.Show("El registro no fue eliminado");
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            //setiamos a la entidad
            modeloParaModificar.Nombre = txtNombre.Text;
            modeloParaModificar.IdPersona = Int64.Parse(cbIdPersona.SelectedValue.ToString());


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
                modeloParaModificar.IdPersona = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                modeloParaModificar.Nombre = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                //de la entidad le pasamos los datos a las cajas de texto
                txtNombre.Text = modeloParaModificar.Nombre;
                cbIdPersona.SelectedValue = modeloParaModificar.IdPersona;

                // habilitamos todo
                cbIdPersona.Enabled = true;
                txtNombre.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

            }
            catch
            {

            }
        }
    }
}
