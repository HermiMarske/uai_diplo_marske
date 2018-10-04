using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas
{
    public partial class formInicio : Form
    {
        public formInicio()
        {
            InitializeComponent();
        }

        private void actividadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void groupAltaCliente_Enter(object sender, EventArgs e)
        {

        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void formInicio_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'uAI_GESTION_AGUILADataSet.Personas' Puede moverla o quitarla según sea necesario.
            this.personasTableAdapter.Fill(this.uAI_GESTION_AGUILADataSet.Personas);
            // TODO: esta línea de código carga datos en la tabla 'uAI_GESTION_AGUILADataSet.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.uAI_GESTION_AGUILADataSet.Clientes);

        }
    }
}
