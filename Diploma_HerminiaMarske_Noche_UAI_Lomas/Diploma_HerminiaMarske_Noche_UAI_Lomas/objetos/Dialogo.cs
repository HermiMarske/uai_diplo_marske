using System.Windows.Forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    public static class Dialogo
    {
        public static int Result;
        public static DialogResult LimpiarCampos()
        {
            Form prompt = new Form();
            prompt.Width = 250;
            prompt.Height = 150;
            prompt.Text = "Limpiar campos";
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "¿Seguro que deseas limpiar todos los campos?" };
            Button confirmation = new Button() { Text = "Sí", Left = 50, Width = 50, Top = 70, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "No", Left = 150, Width = 50, Top = 70, DialogResult = DialogResult.Cancel };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();
            return prompt.DialogResult;
        }
    }
}
