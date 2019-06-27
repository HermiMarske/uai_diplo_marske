using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using System;
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
            checkboxHabilitar.Checked = avion.GetHabilitado();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            avion.SetMarca(txtMarca.Text);
            avion.SetMatricula(txtMatricula.Text);
            avion.SetModelo(txtModelo.Text);
            avion.SetHabilitado(checkboxHabilitar.Checked);

            CustomMessageBox messageBox = new CustomMessageBox();
            try
            {
                messageBox.Show(ControladorABMAvion.modificarAvion(avion), true);
            }
            catch (Exception ex)
            {
                messageBox.ShowError(ex.Message.ToString());
            }
        }

        private void txtMatricula_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (((TextBox)sender).Text.Length < 5 || ((TextBox)sender).Text.Length > 10)
            {
                e.Cancel = true;
                errProvider.SetError(txtMatricula, string.Format(strings.text_length_too_short, 5, 10));
            }
        }

        private void textBox_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void genericTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            if (txtBox.Text.Length < 1 || txtBox.Text.Length > 100)
            {
                e.Cancel = true;
                errProvider.SetError(txtModelo, string.Format(strings.text_length_too_short, 1, 100));
            }
        }
    }
}
