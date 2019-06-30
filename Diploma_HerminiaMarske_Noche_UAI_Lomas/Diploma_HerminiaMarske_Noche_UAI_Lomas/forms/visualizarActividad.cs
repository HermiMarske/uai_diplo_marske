using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class visualizarActividad : Form
    {
        public visualizarActividad()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void visualizarActividad_Load(object sender, EventArgs e)
        {
            int idActividad = (int)formInicio.idActividad;

            Actividad actividad = ControladorABMActividad.getActividad(idActividad);

            txtTexto.Text = actividad.GetTexto();
            try
            {
                pickerFechaHoraInicio.Value = actividad.GetFechaHoraInicio();
            } catch
            {

            }
            numericUpDownHs.Value = actividad.GetHoras();
            comboPiloto.Text = actividad.GetPiloto().GetPersona().GetApellido() + ", " + actividad.GetPiloto().GetPersona().GetNombre();
            comboCliente.Text = actividad.GetCliente().GetRazonSocial();
            comboPais.Text = actividad.GetLocalidad().GetPais().GetNombre();
            comboProvincias.Text = actividad.GetLocalidad().GetProvincia().GetNombre();
            comboLocalidades.Text = actividad.GetLocalidad().GetNombre();
            comboAvion.Text = actividad.GetAvion().GetMatricula();

            

        }
    }
}
