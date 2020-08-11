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
        }

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
    }
}
