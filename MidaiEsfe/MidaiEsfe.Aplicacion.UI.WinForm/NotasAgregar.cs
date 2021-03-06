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
    public partial class Nueva_Nota : Form
    {
        // LLAMAR LA FAMILIA DE EVALUACIONES
        MidaiEsfe.Aplicacion.LogicaDeNegocio.EvaluacionesBL _blEvaluaciones = new LogicaDeNegocio.EvaluacionesBL();
        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones> listaEvaluaciones = new List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Evaluaciones>();

        MidaiEsfe.Aplicacion.LogicaDeNegocio.AsignacionDeModuloBL _blAsignacionModulo = new LogicaDeNegocio.AsignacionDeModuloBL();
        List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo> listaDeAsignacionesDeModulo = new List<MidaiEsfe.Aplicacion.EntidadesDeNegocio.Asignacion_De_Modulo>();


        public Nueva_Nota()
        {
            InitializeComponent();

            listaEvaluaciones = _blEvaluaciones.ObtenerTodos();
            cbIdEvaluaciones.DataSource = listaEvaluaciones;
            cbIdEvaluaciones.DisplayMember = "Detalle";
            cbIdEvaluaciones.ValueMember = "Id";

            listaDeAsignacionesDeModulo = _blAsignacionModulo.ObtenerTodos();
            cbIdModuloYEstudiante.DataSource = listaDeAsignacionesDeModulo;
            cbIdModuloYEstudiante.DisplayMember = "NombrePersona";
            cbIdModuloYEstudiante.ValueMember = "Id";

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            //MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona _en = new MidaiEsfe.Aplicacion.EntidadesDeNegocio.TipoPersona();
            EntidadesDeNegocio.Notas _entidad = new EntidadesDeNegocio.Notas();
            //solo para modificar o eliminar
            _entidad.IdEvaluacion = Int64.Parse(cbIdEvaluaciones.SelectedValue.ToString());
            _entidad.IdAsignacionDeModulo = Int64.Parse(cbIdModuloYEstudiante.SelectedValue.ToString());
            _entidad.Nota = Int64.Parse(txtNota.Text);

            LogicaDeNegocio.NotasBL _logica = new LogicaDeNegocio.NotasBL();

            int resultadoDeMetodo = _logica.Guardar(_entidad);

            if (resultadoDeMetodo == 1)
            {
                MessageBox.Show("EL registro fue agregado con exito");
                txtNota.Text = "";
            }
            else
            {
                MessageBox.Show("EL registro no fue agregado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Nueva_Nota_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
