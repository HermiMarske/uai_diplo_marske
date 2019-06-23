using System;
using System.Windows.Forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class logIn : Form
    {
        public logIn()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox();
            string user = txtUsuario.Text;
            string clave = txtPassword.Text;

            if (user == "" || clave == "")
            {
                messageBox.Show(strings.missing_user_data);
                txtUsuario.Focus();
            } else
            {
                try
                {
                    Usuario usuario = ControladorUsuario.logIn(user, clave);
                    messageBox.Show(string.Format(strings.welcome, usuario.GetPersona().GetNombre()), true);
                    txtUsuario.Clear();
                    txtPassword.Clear();
                    Hide();
                    new formInicio(usuario).ShowDialog();
                    Show();
                    txtUsuario.Focus();
                } catch (Exception ex)
                {
                    switch (ex.Message.ToString())
                    {
                        case "AUTH_USR_NOT_EXISTS":
                            messageBox.ShowWarning(strings.user_not_exists);
                            txtUsuario.Focus();
                            break;
                        case "USR_BLOCKED":
                            messageBox.ShowWarning(strings.user_blocked);
                            txtUsuario.Focus();
                            break;
                        case "AUTH_USR_FAILED":
                            messageBox.ShowWarning(strings.user_auth_failed);
                            txtPassword.Focus();
                            break;
                        default:
                            messageBox.ShowError(strings.user_auth_error);
                            break;
                    }
                }
            }


        }
    }
}
