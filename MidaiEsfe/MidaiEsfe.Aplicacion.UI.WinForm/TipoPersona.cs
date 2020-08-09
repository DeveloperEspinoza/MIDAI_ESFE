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
        public TipoPersona()
        {
            InitializeComponent();
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
    }
}
