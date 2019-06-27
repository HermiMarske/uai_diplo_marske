using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using System;
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

            avion.SetHabilitado(checkboxHabilitar.Checked);
            avion.SetMarca(txtMarca.Text);
            avion.SetMatricula(txtMatricula.Text);
            avion.SetModelo(txtModelo.Text);

            CustomMessageBox messageBox = new CustomMessageBox();
            try
            {
                messageBox.Show(ControladorABMAvion.crearAvion(avion), true);
            }
            catch (Exception ex)
            {
                messageBox.ShowError(ex.Message.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
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
