using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class bitacora : Form
    {
        public bitacora()
        {
            InitializeComponent();
        }

        private void bitacora_Load(object sender, EventArgs e)
        {
            List<BitacoraRow> bitacoraRows = ControladorBitacora.getBitacoraRows();

            foreach (BitacoraRow br in bitacoraRows)
            {
                string[] dataRow = { br.GetTimeStamp().ToString(), br.GetCriticidad(), br.GetDescripcion(), br.GetUsuario().GetNombreUsuario()};
                dataGridBitacora.Rows.Add(dataRow);
            }

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<BitacoraRow> bitacoraRows = ControladorBitacora.getBitacoraFiltrada(txtUsuario.Text, comboCriticidad.SelectedItem != null ? comboCriticidad.SelectedItem.ToString() : null, dateTimeFechaDesde.Value, dateTimeFechaHasta.Value);

            dataGridBitacora.Rows.Clear();

            foreach (BitacoraRow br in bitacoraRows)
            {
                string[] dataRow = { br.GetTimeStamp().ToString(), br.GetCriticidad(), br.GetDescripcion(), br.GetUsuario().GetNombreUsuario() };
                dataGridBitacora.Rows.Add(dataRow);
            }
        }
    }
}
