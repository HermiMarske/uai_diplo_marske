using System.Windows.Forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public DialogResult Show(string label)
        {
            lblMessage.Text = label;
            icon.Image = Properties.Resources.icons8_info_96;
            Text = Properties.strings.message;
            return ShowDialog();
        }

        public DialogResult Show(string label, bool success)
        {
            lblMessage.Text = label;
            icon.Image = Properties.Resources.icons8_info_96;
            Text = success ? Properties.strings.success : Properties.strings.failure;
            return ShowDialog();
        }

        public DialogResult ShowWarning(string label)
        {
            lblMessage.Text = label;
            icon.Image = Properties.Resources.icons8_error_96;
            Text = Properties.strings.failure;
            return ShowDialog();
        }

        public DialogResult ShowError(string label)
        {
            lblMessage.Text = label;
            icon.Image = Properties.Resources.icons8_cancel_96;
            Text = Properties.strings.error;
            return ShowDialog();
        }
    }
}
