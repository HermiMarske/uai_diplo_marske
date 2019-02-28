using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;


namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class modificarCliente : Form
    {
        public static Object idCliente;
        public modificarCliente()
        {
            InitializeComponent();
        }

        private void modificarCliente_Load(object sender, EventArgs e)
        {
            int idClienteSelec = Int32.Parse((string)formInicio.idClienteModif);

            SqlParameter[] pms = new SqlParameter[1];

            pms[0] = new SqlParameter("@idCliente", SqlDbType.Int);
            pms[0].Value = idClienteSelec;

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da = dataQuery.getList("ObtenerCliente", pms);
            da.Fill(dt);

            DataRow dr = dt.Rows[0];
           
            Persona persona = new Persona((int)dr[4], (string)dr[5], (string)dr[6], (string)dr[7], (string)dr[8]);
            Cliente cliente = new Cliente((int)dr[0], (string)dr[1], (string)dr[2], (string)dr[3], persona);

            txtRazonSocial.Text = cliente.GetRazonSocial();
            txtCuit.Text = cliente.GetCuit();
            comboTipoCliente.Text = cliente.GetTipoCliente();
            txtDni.Text = persona.GetDni();
            txtNombre.Text = persona.GetNombre();
            txtApellido.Text = persona.GetApellido();
            comboSexo.Text = persona.GetSexo();
            pickerFechaNacimiento.MinDate = persona.GetFechaNacimiento();


            /** Lleno el grid de telefonos **/

            int idPersona = persona.GetIdPersona();
            DataTable dtTel = new DataTable();
            pms[0] = new SqlParameter("@id", SqlDbType.Int);
            pms[0].Value = idPersona;
           

            da = dataQuery.getList("ObtenerTelefonos", pms);
            da.Fill(dtTel);
            List<Telefono> telList = new List<Telefono>();

            foreach(DataRow drTel in dtTel.Rows)
            {
                Telefono tel = new Telefono();
                tel.SetId((int)drTel[0]);
                tel.SetTipo((string)drTel[1]);
                tel.SetNumero((string)drTel[2]);
                telList.Add(tel);
            }

            foreach (Telefono t in telList)
            {
                String[] dataRow = { t.GetNumero(), t.GetTipo() };
                dataGridTelefonos.Rows.Add(dataRow);
            }

            /** Lleno lista de domicilios **/

            DataTable dtDom = new DataTable();
            pms[0] = new SqlParameter("@id", SqlDbType.Int);
            pms[0].Value = idPersona;


            da = dataQuery.getList("ObtenerDomicilios", pms);
            da.Fill(dtDom);
            List<Domicilio> domList = new List<Domicilio>();

            foreach (DataRow drDom in dtDom.Rows)
            {
                Localidad lc = new Localidad((string)drDom[10], (int)drDom[9], 0);
                Provincia pv = new Provincia((string)drDom[12], (int)drDom[11]);
                Pais p = new Pais((int)drDom[13], (string)drDom[14]);
                Domicilio dom = new Domicilio((int)drDom[0], (string)drDom[1], (string)drDom[2], (int)drDom[3], (string)drDom[4], (string)drDom[5], (string)drDom[6], (string)drDom[7], lc, p, pv );

                domList.Add(dom);
           
            }
            foreach (Domicilio d in domList)
            {
                String[] dataRow = { d.GetTipoDomicilio(), d.GetComentario(), d.GetCalle(), d.GetNumero(), d.GetPiso().ToString(), d.GetDpto(), d.GetCodigoPostal(), d.GetLocalidad().GetNombre() };
                dataGridDomicilios.Rows.Add(dataRow);
            }



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
