using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidaiEsfe.Aplicacion.UI.WinForm
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void manualDeLaAplicaiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tiposDePersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoPersona tipoPersona = new TipoPersona();
            this.Hide();
            tipoPersona.ShowDialog();
            this.Show();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nueva_Persona Nueva_Persona = new Nueva_Persona();
            this.Hide();
            Nueva_Persona.ShowDialog();
            this.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulo Modulo = new Modulo();
            this.Hide();
            Modulo.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void registroDeModulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulo_y_Estudiante Modulo_y_Estudiante = new Modulo_y_Estudiante();
            this.Hide();
            Modulo_y_Estudiante.ShowDialog();
            this.Show();
        }
    }
}
