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
    public partial class Persona : Form
    {
        public Persona()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonaAgregar Persona = new PersonaAgregar();
            this.Hide();
            Persona.ShowDialog();
            this.Show();
        }

     

        private void Persona_Load(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.PersonaBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.PersonaBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Persona> lista = new List<EntidadesDeNegocio.Persona>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }

        private void Persona_Activated(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.PersonaBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.PersonaBL();
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Persona> lista = new List<EntidadesDeNegocio.Persona>();
            lista = _bl.ObtenerTodos();
            dataGridView1.DataSource = lista;
        }
    }
}
