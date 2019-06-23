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
    public partial class altaAvion : Form
    {
        public altaAvion()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Avion avion = new Avion();

            if(checkboxHabilitar.Checked == true)
            {
                avion.SetHabilitado(true);
            } else
            {
                avion.SetHabilitado(false);
            }

            avion.SetMarca(txtMarca.Text);
            avion.SetMatricula(txtMatricula.Text);
            avion.SetModelo(txtModelo.Text);

            string result = ControladorABMAvion.crearAvion(avion);

            MessageBox.Show(result);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
