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
    public partial class modificarUsuario : Form
    {
        public modificarUsuario()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void modificarUsuario_Load(object sender, EventArgs e)
        {
            Usuario usr = ControladorABMUsuario.getUsuario((int)formInicio.idUsuarioModif);
        }
    }
}
