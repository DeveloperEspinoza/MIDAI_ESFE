﻿using System;
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

            // deshabilitamos todo
            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;
            txtIdTipoPersona.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        public MidaiEsfe.Aplicacion.EntidadesDeNegocio.Persona modeloParaModificar = new EntidadesDeNegocio.Persona();

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //llenamos la entidad
                modeloParaModificar.Id = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                modeloParaModificar.IdTipoPersona = Int64.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                modeloParaModificar.Nombres = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                modeloParaModificar.Apellidos = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                //de la entidad le pasamos los datos a las cajas de texto
                txtNombres.Text = modeloParaModificar.Nombres;
                txtApellidos.Text = modeloParaModificar.Apellidos;
                txtIdTipoPersona.Text = modeloParaModificar.IdTipoPersona.ToString();

                // habilitamos todo
                txtNombres.Enabled = true;
                txtApellidos.Enabled = true;
                txtIdTipoPersona.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                
            }
            catch
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MidaiEsfe.Aplicacion.LogicaDeNegocio.PersonaBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.PersonaBL();
            int respuesta = _bl.Eliminar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue eliminado con exito");

                //refrescamos la lista
                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Persona> lista = new List<EntidadesDeNegocio.Persona>();
                lista = _bl.ObtenerTodos();
                dataGridView1.DataSource = lista;

                // deshabilitamos todo
                txtNombres.Enabled = false;
                txtApellidos.Enabled = false;
                txtIdTipoPersona.Enabled = false;
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
            modeloParaModificar.Nombres = txtNombres.Text;
            modeloParaModificar.Apellidos = txtApellidos.Text;
            modeloParaModificar.IdTipoPersona = Int64.Parse(txtIdTipoPersona.Text);


            MidaiEsfe.Aplicacion.LogicaDeNegocio.PersonaBL _bl = new MidaiEsfe.Aplicacion.LogicaDeNegocio.PersonaBL();
            int respuesta = _bl.Modificar(modeloParaModificar);
            if (respuesta > 0)
            {
                MessageBox.Show("El registro fue modificado con exito");

                //refrescamos la lista
                List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Persona> lista = new List<EntidadesDeNegocio.Persona>();
                lista = _bl.ObtenerTodos();
                dataGridView1.DataSource = lista;

                // deshabilitamos todo
                txtNombres.Enabled = false;
                txtApellidos.Enabled = false;
                txtIdTipoPersona.Enabled = false;
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
