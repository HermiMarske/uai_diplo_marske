using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using ConstantesData;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;

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
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string clave = txtPassword.Text;

            if (user == "" || clave == "")
            {
                MessageBox.Show("Por favor ingrese sus credenciales.");
                txtUsuario.Focus();
            } else
            {
                try
                {
                    Persona persona = ControladorUsuario.logIn(user, clave);
                    MessageBox.Show(string.Format("¡Bienvenido {0} {1}!", persona.GetNombre(), persona.GetApellido()));
                } catch (Exception ex)
                {
                    switch (ex.Message.ToString())
                    {
                        case "AUTH_USR_NOT_EXISTS":
                            MessageBox.Show("El usuario ingresado no existe.");
                            txtUsuario.Focus();
                            break;
                        case "USR_BLOCKED":
                            MessageBox.Show("El usuario se encuentra bloqueado.\nComuníquese con un administrador");
                            txtUsuario.Focus();
                            break;
                        case "AUTH_USR_FAILED":
                            MessageBox.Show("¡Contraseña incorrecta!");
                            txtPassword.Focus();
                            break;
                        default:
                            MessageBox.Show("Existe un problema con su contraseña y no se puede procesar.\nComuníquese con un administrador");
                            break;
                    }
                }
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
