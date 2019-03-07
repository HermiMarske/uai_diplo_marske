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
            //Llenado de combo de paises
            List<Pais> paises = new List<Pais>();
            DataConnection.DataConnection dataQueryPaises = new DataConnection.DataConnection();
            SqlDataAdapter dap = new SqlDataAdapter();
            DataTable dtp = new DataTable();
            dap = dataQueryPaises.getList("ListarPaises", null);
            dap.Fill(dtp);
            foreach (DataRow drp in dtp.Rows)
            {
                Pais pais = new Pais((int)drp[0], (string)drp[1]);
                paises.Add(pais);
            }
            comboPais.DataSource = paises;

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
                object[] dataRow = { d.GetTipoDomicilio(), d.GetComentario(), d.GetCalle(), d.GetNumero(), d.GetPiso().ToString(), d.GetDpto(), d.GetCodigoPostal(), d.GetLocalidad(), d.GetProvincia(), d.GetPais()};
                dataGridDomicilios.Rows.Add(dataRow);
            }



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificarTel_Click(object sender, EventArgs e)
        {

            if (dataGridTelefonos.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridTelefonos.SelectedCells[0].RowIndex;
                dataGridTelefonos.Rows[rowIndex].Cells[0].Value = textBoxNumero.Text;
                dataGridTelefonos.Rows[rowIndex].Cells[1].Value = comboTipoTelefono.Text;
            }

        }

        private void dataGridTelefonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxNumero.Text = (string)dataGridTelefonos.Rows[e.RowIndex].Cells[0].Value;
                comboTipoTelefono.Text = (string)dataGridTelefonos.Rows[e.RowIndex].Cells[1].Value;
            }
        }

        private void dataGridDomicilios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                comboTipo.Text = (string)dataGridDomicilios.Rows[e.RowIndex].Cells[0].Value;
                txtComentario.Text = (string)dataGridDomicilios.Rows[e.RowIndex].Cells[1].Value;
                txtCalle.Text = (string)dataGridDomicilios.Rows[e.RowIndex].Cells[2].Value;
                txtNumero.Text = (string)dataGridDomicilios.Rows[e.RowIndex].Cells[3].Value;
                txtPiso.Text = (string)dataGridDomicilios.Rows[e.RowIndex].Cells[4].Value;
                txtDpto.Text = (string)dataGridDomicilios.Rows[e.RowIndex].Cells[5].Value;
                txtCodigoPostal.Text = (string)dataGridDomicilios.Rows[e.RowIndex].Cells[6].Value;
                comboPais.SelectedIndex = comboPais.FindStringExact(dataGridDomicilios.Rows[e.RowIndex].Cells[9].Value.ToString());
                comboPais_SelectedIndexChanged(null,null);
                comboProvincias.SelectedIndex = comboProvincias.FindStringExact(dataGridDomicilios.Rows[e.RowIndex].Cells[8].Value.ToString());
                comboProvincias_SelectedIndexChanged(null,null);
                comboLocalidades.SelectedIndex = comboLocalidades.FindStringExact(dataGridDomicilios.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
        }


        private void comboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Provincia> provincias = new List<Provincia>();
            Pais pais = (Pais)comboPais.SelectedItem;
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlParameter[] pmsProvincias = new SqlParameter[1];
            pmsProvincias[0] = new SqlParameter("@pais", SqlDbType.Int);
            pmsProvincias[0].Value = pais.GetId();
            da = dataQuery.getList("ListarProvincias", pmsProvincias);
            da.Fill(dt);
            comboProvincias.Text = null;
            foreach (DataRow dr in dt.Rows)
            {
                Provincia provincia = new Provincia((string)dr[0], (int)dr[1]);
                provincias.Add(provincia);
            }
            comboProvincias.DataSource = provincias;
        }

        private void comboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Localidad> localidades = new List<Localidad>();
            Provincia provincia = (Provincia)comboProvincias.SelectedItem;
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlParameter[] pmsLocalidades = new SqlParameter[1];
            if (provincia != null)
            {
                pmsLocalidades[0] = new SqlParameter("@provincia", SqlDbType.Int);
                pmsLocalidades[0].Value = provincia.GetId();
                da = dataQuery.getList("ListarLocalidades", pmsLocalidades);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Localidad localidad = new Localidad((string)dr[0], (int)dr[1], (int)dr[2]);
                    localidades.Add(localidad);
                }
            }
            comboLocalidades.Text = null;
            comboLocalidades.DataSource = localidades;
        }

        private void btnModificarDom_Click(object sender, EventArgs e)
        {
            if (dataGridDomicilios.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridDomicilios.SelectedCells[0].RowIndex;
                dataGridDomicilios.Rows[rowIndex].Cells[0].Value = comboTipo.Text;
                dataGridDomicilios.Rows[rowIndex].Cells[1].Value = txtComentario.Text;
                dataGridDomicilios.Rows[rowIndex].Cells[2].Value = txtCalle.Text;
                dataGridDomicilios.Rows[rowIndex].Cells[3].Value = txtNumero.Text;
                dataGridDomicilios.Rows[rowIndex].Cells[4].Value = txtPiso.Text;
                dataGridDomicilios.Rows[rowIndex].Cells[5].Value = txtDpto.Text;
                dataGridDomicilios.Rows[rowIndex].Cells[6].Value = txtCodigoPostal.Text;
                dataGridDomicilios.Rows[rowIndex].Cells[9].Value = comboPais.SelectedItem;
                dataGridDomicilios.Rows[rowIndex].Cells[8].Value = comboProvincias.SelectedItem;
                dataGridDomicilios.Rows[rowIndex].Cells[7].Value = comboLocalidades.SelectedItem;

            }
        }
    }
}
