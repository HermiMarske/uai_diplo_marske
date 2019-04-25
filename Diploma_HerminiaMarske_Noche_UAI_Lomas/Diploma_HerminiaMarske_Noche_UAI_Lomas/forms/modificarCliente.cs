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
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using ConstantesData;


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
            DataTable dtp = new DataTable();
            dtp = dataQueryPaises.getList(SP.LISTAR_PAISES, null);
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
            DataTable dt = new DataTable();
            dt = dataQuery.getList(SP.OBTENER_CLIENTE, pms);

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


            dtTel = dataQuery.getList(SP.OBTENER_TELEFONOS, pms);
            List<Telefono> telList = new List<Telefono>();

            try
            {
                foreach (DataRow drTel in dtTel.Rows)
                {
                    Telefono tel = new Telefono();
                    tel.SetId((int)drTel[0]);
                    tel.SetTipo((string)drTel[1]);
                    tel.SetNumero((string)drTel[2]);
                    telList.Add(tel);
                }

                foreach (Telefono t in telList)
                {
                    String[] dataRow = { t.GetTipo(), t.GetNumero() };
                    dataGridTelefonos.Rows.Add(dataRow);
                }
            }
            catch
            {
                MessageBox.Show(dtTel.Rows[0].ItemArray[0].ToString());
            }
            
            /** Lleno el grid de correos **/
            DataTable dtMail = new DataTable();
            pms[0] = new SqlParameter("@id", SqlDbType.Int);
            pms[0].Value = idPersona;


            dtMail = dataQuery.getList(SP.OBTENER_TELEFONOS, pms);
            List<Mail> mailList = new List<Mail>();

            try
            {
                foreach (DataRow drMail in dtMail.Rows)
                {
                    Mail mail = new Mail();
                    mail.SetId((int)drMail[0]);
                    mail.SetTipo((string)drMail[1]);
                    mail.SetMail((string)drMail[2]);
                    mailList.Add(mail);
                }

                foreach (Mail m in mailList)
                {
                    String[] dataRow = { m.GetTipo(), m.GetMail() };
                    dataGridMails.Rows.Add(dataRow);
                }
            }
            catch
            {
                MessageBox.Show(dtMail.Rows[0].ItemArray[0].ToString());
            }
    
            /** Lleno lista de domicilios **/
            DataTable dtDom = new DataTable();
            pms[0] = new SqlParameter("@id", SqlDbType.Int);
            pms[0].Value = idPersona;


            dtDom = dataQuery.getList(SP.OBTENER_DOMICILIOS, pms);
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
                comboPais_SelectedIndexChanged(sender, null);
                comboProvincias.SelectedIndex = comboProvincias.FindStringExact(dataGridDomicilios.Rows[e.RowIndex].Cells[8].Value.ToString());
                comboProvincias_SelectedIndexChanged(sender, null);
                comboLocalidades.SelectedIndex = comboLocalidades.FindStringExact(dataGridDomicilios.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
        }


        private void comboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Provincia> provincias = new List<Provincia>();
            Pais pais = (Pais)comboPais.SelectedItem;
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            SqlParameter[] pmsProvincias = new SqlParameter[1];
            pmsProvincias[0] = new SqlParameter("@pais", SqlDbType.Int);
            pmsProvincias[0].Value = pais.GetId();
            dt = dataQuery.getList(SP.LISTAR_PROVINCIAS, pmsProvincias);
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
            DataTable dt = new DataTable();
            SqlParameter[] pmsLocalidades = new SqlParameter[1];
            if (provincia != null)
            {
                pmsLocalidades[0] = new SqlParameter("@provincia", SqlDbType.Int);
                pmsLocalidades[0].Value = provincia.GetId();
                dt = dataQuery.getList(SP.LISTAR_LOCALIDADES, pmsLocalidades);
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
                dataGridDomicilios.Rows[rowIndex].Cells[7].Value = comboLocalidades.SelectedItem;
                dataGridDomicilios.Rows[rowIndex].Cells[8].Value = comboProvincias.SelectedItem;
                dataGridDomicilios.Rows[rowIndex].Cells[9].Value = comboPais.SelectedItem;

            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            DataConnection.DataConnection dataConnection = new DataConnection.DataConnection();

            SqlParameter[] pms = new SqlParameter[9];

            pms[0] = new SqlParameter("@idCliente", SqlDbType.Int);
            pms[0].Value = Int32.Parse((string)formInicio.idClienteModif);

            pms[1] = new SqlParameter("@razonSocial", SqlDbType.VarChar);
            pms[1].Value = txtRazonSocial.Text;

            pms[2] = new SqlParameter("@cuil", SqlDbType.VarChar);
            pms[2].Value = txtCuit.Text;

            pms[3] = new SqlParameter("@tipoCliente", SqlDbType.VarChar);
            pms[3].Value = comboTipoCliente.SelectedItem.ToString();

            pms[4] = new SqlParameter("@dni", SqlDbType.VarChar);
            pms[4].Value = txtDni.Text;

            pms[5] = new SqlParameter("@nombre", SqlDbType.VarChar);
            pms[5].Value = txtNombre.Text;

            pms[6] = new SqlParameter("@apellido", SqlDbType.VarChar);
            pms[6].Value = txtApellido.Text;

            pms[7] = new SqlParameter("@sexo", SqlDbType.VarChar);
            pms[7].Value = comboSexo.SelectedItem.ToString();

            pms[8] = new SqlParameter("@fechaNacimiento", SqlDbType.Date);
            pms[8].Value = pickerFechaNacimiento.Value;

            dataConnection.databaseModifyData(pms, SP.MODIFICAR_CLIENTE);

            SqlParameter[] pmsTel = new SqlParameter[1];
           

            pmsTel[0] = new SqlParameter("@idPersona", SqlDbType.Int);
            pmsTel[0].Value = Int32.Parse((string)formInicio.fkPersonaModif);

            dataConnection.databaseModifyData(pmsTel, SP.BORRAR_TELEFONOS);

            SqlParameter[] pmsTelefono = new SqlParameter[3];
            List<Telefono> telefonos = new List<Telefono>();
            List<Domicilio> domicilios = new List<Domicilio>();

            for (int i = 0; i < dataGridTelefonos.Rows.Count; i++)
            {
                Telefono t = new Telefono();

                t.SetTipo((string)dataGridTelefonos.Rows.SharedRow(i).Cells[0].Value);
                t.SetNumero((string)dataGridTelefonos.Rows.SharedRow(i).Cells[1].Value);
                telefonos.Add(t);

                pmsTelefono[0] = new SqlParameter("@tipo", SqlDbType.VarChar);
                pmsTelefono[0].Value = t.GetTipo();

                pmsTelefono[1] = new SqlParameter("@numero", SqlDbType.VarChar);
                pmsTelefono[1].Value = t.GetNumero();

                pmsTelefono[2] = new SqlParameter("@fk_persona", SqlDbType.Int);
                pmsTelefono[2].Value = Int32.Parse((string)formInicio.fkPersonaModif);

                dataConnection.databaseInsertAditionalData(pmsTelefono, SP.ALTA_TELEFONO);

            }


            SqlParameter[] pmsMails = new SqlParameter[1];


            pmsMails[0] = new SqlParameter("@idPersona", SqlDbType.Int);
            pmsMails[0].Value = Int32.Parse((string)formInicio.fkPersonaModif);

            dataConnection.databaseModifyData(pmsTel, SP.BORRAR_MAILS);

            SqlParameter[] pmsEmails = new SqlParameter[3];
            List<Mail> mails = new List<Mail>();
        

            for (int i = 0; i < dataGridMails.Rows.Count; i++)
            {
                Mail m = new Mail();

                m.SetTipo((string)dataGridMails.Rows.SharedRow(i).Cells[0].Value);
                m.SetMail((string)dataGridMails.Rows.SharedRow(i).Cells[1].Value);
                mails.Add(m);

                pmsEmails[0] = new SqlParameter("@tipo", SqlDbType.VarChar);
                pmsEmails[0].Value = m.GetTipo();

                pmsEmails[1] = new SqlParameter("@mail", SqlDbType.VarChar);
                pmsEmails[1].Value = m.GetMail();

                pmsEmails[2] = new SqlParameter("@fk_persona", SqlDbType.Int);
                pmsEmails[2].Value = Int32.Parse((string)formInicio.fkPersonaModif);

                dataConnection.databaseInsertAditionalData(pmsEmails, SP.ALTA_MAIL);

            }

            for (int i = 0; i < dataGridDomicilios.Rows.Count; i++)
            {
                string pisoString = (string)dataGridDomicilios.Rows.SharedRow(i).Cells[4].Value;
                int piso = Convert.ToInt32(pisoString);

                Domicilio dom = new Domicilio();
                dom.SetTipoDomicilio((String)dataGridDomicilios.Rows.SharedRow(i).Cells[0].Value);
                dom.SetComentario((String)dataGridDomicilios.Rows.SharedRow(i).Cells[1].Value);
                dom.SetCalle((String)dataGridDomicilios.Rows.SharedRow(i).Cells[2].Value);
                dom.SetNumero((String)dataGridDomicilios.Rows.SharedRow(i).Cells[3].Value);
                dom.SetPiso(piso);
                dom.SetDpto((String)dataGridDomicilios.Rows.SharedRow(i).Cells[5].Value);
                dom.SetCodigoPostal((String)dataGridDomicilios.Rows.SharedRow(i).Cells[6].Value);
                dom.SetLocalidad((Localidad)dataGridDomicilios.Rows.SharedRow(i).Cells[7].Value);

                domicilios.Add(dom);
            }

            SqlParameter[] pmsDom = new SqlParameter[1];

            pmsDom[0] = new SqlParameter("@idPersona", SqlDbType.Int);
            pmsDom[0].Value = Int32.Parse((string)formInicio.fkPersonaModif);
            dataConnection.databaseModifyData(pmsDom, SP.BORRAR_DOMICILIOS);

            SqlParameter[] pmsDomicilio = new SqlParameter[9];

            foreach (Domicilio d in domicilios)
            {
                pmsDomicilio[0] = new SqlParameter("@calle", SqlDbType.VarChar);
                pmsDomicilio[0].Value = d.GetCalle();

                pmsDomicilio[1] = new SqlParameter("@numero", SqlDbType.VarChar);
                pmsDomicilio[1].Value = d.GetNumero();

                pmsDomicilio[2] = new SqlParameter("@piso", SqlDbType.Int);
                pmsDomicilio[2].Value = (object)d.GetPiso() ?? DBNull.Value;

                pmsDomicilio[3] = new SqlParameter("@dpto", SqlDbType.VarChar);
                pmsDomicilio[3].Value = d.GetDpto();

                pmsDomicilio[4] = new SqlParameter("@comentarios", SqlDbType.VarChar);
                pmsDomicilio[4].Value = d.GetComentario();

                pmsDomicilio[5] = new SqlParameter("@codPostal", SqlDbType.VarChar);
                pmsDomicilio[5].Value = d.GetCodigoPostal();

                pmsDomicilio[6] = new SqlParameter("@tipoDomicilio", SqlDbType.VarChar);
                pmsDomicilio[6].Value = d.GetTipoDomicilio();

                pmsDomicilio[7] = new SqlParameter("@fk_localidad", SqlDbType.Int);
                pmsDomicilio[7].Value = d.GetLocalidad().GetId();

                pmsDomicilio[8] = new SqlParameter("@fk_persona", SqlDbType.Int);
                pmsDomicilio[8].Value = Int32.Parse((string)formInicio.fkPersonaModif);

                dataConnection.databaseModifyData(pmsDomicilio, SP.ALTA_DOMICILIO);
            }
        }

        private void buttonAddTelefono_Click(object sender, EventArgs e)
        {
            Telefono tel = new Telefono();
            tel.SetNumero(textBoxNumero.Text);
            tel.SetTipo(comboTipoTelefono.SelectedItem.ToString());

            String[] dataRow = { tel.GetTipo(), tel.GetNumero() };
            dataGridTelefonos.Rows.Add(dataRow);
        }

        private void btnAgregarDom_Click(object sender, EventArgs e)
        {
            Domicilio dom = new Domicilio();
            dom.SetNumero(txtNumero.Text);
            dom.SetCalle(txtCalle.Text);
            dom.SetCodigoPostal(txtCodigoPostal.Text);
            dom.SetDpto(txtDpto.Text);
            try
            {
                dom.SetPiso(Convert.ToInt32(txtPiso.Text));
            }
            catch (Exception)
            {

            }
            dom.SetTipoDomicilio(comboTipo.SelectedItem.ToString());
            dom.SetComentario(txtComentario.Text);
            dom.SetLocalidad((Localidad)comboLocalidades.SelectedItem);
            dom.SetProvincia((Provincia)comboProvincias.SelectedItem);
            dom.SetPais((Pais)comboPais.SelectedItem);

            Object[] dataRow = { dom.GetTipoDomicilio(), dom.GetComentario(), dom.GetCalle(), dom.GetNumero(), dom.GetPiso(), dom.GetDpto(), dom.GetCodigoPostal(), dom.GetLocalidad() };
            dataGridDomicilios.Rows.Add(dataRow);
        }

        private void btnAgregarMail_Click(object sender, EventArgs e)
        {
            Mail mail = new Mail();
            mail.SetMail(textBoxMail.Text);
            mail.SetTipo(comboTipoMails.SelectedItem.ToString());

            String[] dataRow = { mail.GetTipo(), mail.GetMail() };
            dataGridMails.Rows.Add(dataRow);
        }

        private void btnModificarMail_Click(object sender, EventArgs e)
        {
            if (dataGridMails.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridMails.SelectedCells[0].RowIndex;
                dataGridMails.Rows[rowIndex].Cells[0].Value = textBoxMail.Text;
                dataGridMails.Rows[rowIndex].Cells[1].Value = comboTipoMails.Text;
            }
        }

        private void dataGridMails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxMail.Text = (string)dataGridMails.Rows[e.RowIndex].Cells[0].Value;
                comboTipoMails.Text = (string)dataGridMails.Rows[e.RowIndex].Cells[1].Value;
            }
        }

        private void btnBorrarMail_Click(object sender, EventArgs e)
        {
            if (dataGridMails.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridMails.SelectedCells[0].RowIndex;
                dataGridMails.Rows.RemoveAt(rowIndex);
            }
        }

        private void btnBorrarTel_Click(object sender, EventArgs e)
        {
            if (dataGridTelefonos.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridTelefonos.SelectedCells[0].RowIndex;
                dataGridTelefonos.Rows.RemoveAt(rowIndex);
            }
        }

        private void btnBorrarDomicilio_Click(object sender, EventArgs e)
        {
            if (dataGridDomicilios.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridDomicilios.SelectedCells[0].RowIndex;
                dataGridDomicilios.Rows.RemoveAt(rowIndex);
            }
        }
    }
}
