using System.Windows.Forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
            btnCancel.Visible = false;
        }

        public DialogResult Show(string text)
        {
            btnCancel.Visible = false;
            lblMessage.Text = text;
            icon.Image = Properties.Resources.icons8_info_96;
            Text = Properties.strings.message;
            return ShowDialog();
        }

        public DialogResult Show(string text, bool success)
        {
            btnCancel.Visible = false;
            lblMessage.Text = text;
            icon.Image = Properties.Resources.icons8_info_96;
            Text = success ? Properties.strings.success : Properties.strings.failure;
            return ShowDialog();
        }

        public DialogResult ShowWarning(string text)
        {
            btnCancel.Visible = false;
            lblMessage.Text = text;
            icon.Image = Properties.Resources.icons8_error_96;
            Text = Properties.strings.failure;
            return ShowDialog();
        }

        public DialogResult ShowError(string text)
        {
            btnCancel.Visible = false;
            lblMessage.Text = text;
            icon.Image = Properties.Resources.icons8_cancel_96;
            Text = Properties.strings.error;
            return ShowDialog();
        }

        public DialogResult Show(string text, MessageBoxButtons messageBoxButtons)
        {
            if (messageBoxButtons == MessageBoxButtons.OKCancel)
            {
                btnCancel.Visible = true;
            }
            lblMessage.Text = text;
            icon.Image = Properties.Resources.icons8_help_96;
            Text = Properties.strings.question;
            return ShowDialog();
        }
    }
}
