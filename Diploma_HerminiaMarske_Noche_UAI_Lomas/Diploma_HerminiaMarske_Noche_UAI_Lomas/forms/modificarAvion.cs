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
    public partial class modificarAvion : Form
    {
        public modificarAvion()
        {
            InitializeComponent();
        }

        Avion avion = new Avion();
        private void modificarAvion_Load(object sender, EventArgs e)
        {

            avion = (Avion)formInicio.av;

            txtMarca.Text = avion.GetMarca();
            txtModelo.Text = avion.GetModelo();
            txtMatricula.Text = avion.GetMatricula();


            if(avion.GetHabilitado())
            {
                checkboxHabilitar.Checked = true;
            }
            else
            {
                checkboxHabilitar.Checked = false;
            }



                
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {


            avion.SetMarca(txtMarca.Text);
            avion.SetMatricula(txtMatricula.Text);
            avion.SetModelo(txtModelo.Text);
            if(checkboxHabilitar.Checked == true)
            {
                avion.SetHabilitado(true);
            }
            else
            {
                avion.SetHabilitado(false);
            }

            string rta = ControladorABMAvion.modificarAvion(avion);

            MessageBox.Show(rta);
        }
    }
}
