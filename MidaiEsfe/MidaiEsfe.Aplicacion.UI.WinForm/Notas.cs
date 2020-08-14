﻿using System;
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
    public partial class Notas : Form
    {
        public Notas()
        {
            InitializeComponent();
        }

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
    }
}
