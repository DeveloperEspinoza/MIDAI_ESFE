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
        }

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
       

    }
}
