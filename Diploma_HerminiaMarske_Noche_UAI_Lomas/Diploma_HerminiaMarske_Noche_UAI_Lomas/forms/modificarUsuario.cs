using ConstantesData;
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

            //Llenado de combo de paises
            List<Pais> paises = new List<Pais>();
            DataConnection.DataConnection dataQueryPaises = new DataConnection.DataConnection();
            DataTable dtp = new DataTable();
            dtp = dataQueryPaises.getList(SP.LISTAR_PAISES, null);
            foreach (DataRow drp in dtp.Rows)
            {
                Pais pais = new Pais((int)drp[0], (string)drp[1]);
                paises.Add(pais);
            }
            comboPais.DataSource = paises;



            txtUsuario.Enabled = false;

            Usuario usr = ControladorABMUsuario.getUsuario((int)formInicio.idUsuarioModif);

            txtNombre.Text = usr.GetPersona().GetNombre();
            txtApellido.Text = usr.GetPersona().GetApellido();
            txtDni.Text = usr.GetPersona().GetDni();
            comboSexo.Text = usr.GetPersona().GetSexo();
            pickerFechaNacimiento.Value = usr.GetPersona().GetFechaNacimiento();
            txtUsuario.Text = usr.GetNombreUsuario();


            foreach (Mail m in usr.GetPersona().GetMails())
            {
                String[] dataRow = { m.GetTipo(), m.GetMail() };
                dataGridMails.Rows.Add(dataRow);
            }

      
            foreach (Domicilio d in usr.GetPersona().GetDomicilios())
            {
                object[] dataRow = { d.GetTipoDomicilio(), d.GetComentario(), d.GetCalle(), d.GetNumero(), d.GetPiso().ToString(), d.GetDpto(), d.GetCodigoPostal(), d.GetLocalidad(), d.GetProvincia(), d.GetPais() };
                dataGridDomicilios.Rows.Add(dataRow);
            }

            foreach (Telefono t in usr.GetPersona().GetTelefonos())
            {
                String[] dataRow = { t.GetTipo(), t.GetNumero() };
                dataGridTelefonos.Rows.Add(dataRow);
            }



        }
    }
}
