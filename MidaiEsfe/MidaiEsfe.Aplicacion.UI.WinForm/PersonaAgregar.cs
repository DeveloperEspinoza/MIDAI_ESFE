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
    public partial class PersonaAgregar : Form
    {
        public PersonaAgregar()
        {
            InitializeComponent();
            //CREE UN METODO PARA OBTNER TODOS LOS TIPOS DE USUARIOS
            ObtenerTodosLosTiposDePersonas();
        }

        private void ObtenerTodosLosTiposDePersonas()
        {
            // ESTAS LINEAS PUEDE QUEDAR DIRECTO EN EL PersonaAgregar()  PERO MEJOR LO ORDENO EN ESTE METODO
            List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona> _listaTipoPersona = new List<EntidadesDeNegocio.TipoPersona>();
            MidaiEsfe.Aplicacion.LogicaDeNegocio.TipoPersonaBL _blTp = new LogicaDeNegocio.TipoPersonaBL();
            _listaTipoPersona = _blTp.ObtenerTodos();

            cbIdTipoPersona.DataSource = _listaTipoPersona;
            cbIdTipoPersona.DisplayMember = "Nombre";
            cbIdTipoPersona.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.Persona _entidad = new EntidadesDeNegocio.Persona();
            //solo para modificar o eliminar
            _entidad.IdTipoPersona = byte.Parse(cbIdTipoPersona.SelectedValue.ToString());
            _entidad.Nombres = txtNombres.Text;
            _entidad.Apellidos = txtApellidos.Text;

            LogicaDeNegocio.PersonaBL _logica = new LogicaDeNegocio.PersonaBL();

            int resultadoDeMetodo = _logica.Guardar(_entidad);

            if (resultadoDeMetodo == 1)
            {
                MessageBox.Show("EL registro fue guardado con exito");
                txtNombres.Text = "";
                txtApellidos.Text = "";
            }
            else
            {
                MessageBox.Show("EL registro no fue guardado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PersonaAgregar_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbIdTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
