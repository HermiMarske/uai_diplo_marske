﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using ConstantesData;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas
{
    public partial class altaCliente : Form
    {
        private CustomMessageBox messageBox = new CustomMessageBox();

        public altaCliente()
        {
            InitializeComponent();
        }

        List<Domicilio> domicilios = new List<Domicilio>();
        List<Telefono> telefonos = new List<Telefono>();
        List<Mail> mails = new List<Mail>();

        private void txtDni_Leave(object sender, EventArgs e)
        {
            personaFillData();
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personaFillData();
            }
        }

        private void personaFillData()
        {
            string dni = txtDni.Text;
            if (string.IsNullOrEmpty(dni))
            {
                return;
            }
            DataConnection.DataConnection dataConnection = new DataConnection.DataConnection();
            DataTable dt = new DataTable();

            SqlParameter[] pms = new SqlParameter[1];

            pms[0] = new SqlParameter("@dniPersona", SqlDbType.VarChar);
            pms[0].Value = dni;

            dt = dataConnection.getList(SP.OBTENER_PERSONA, pms);

            Persona persona = null;
            foreach (DataRow dr in dt.Rows)
            {
                persona = new Persona((int)dr[0], (string)dr[1], (string)dr[2], (string)dr[3], (string)dr[4], (DateTime)dr[5]);
            }

            if (persona != null)
            {
                txtNombre.Enabled = false;
                txtNombre.Text = persona.GetNombre();
                txtApellido.Enabled = false;
                txtApellido.Text = persona.GetApellido();
                comboSexo.Enabled = false;
                comboSexo.Text = persona.GetSexo();
                pickerFechaNacimiento.Enabled = false;
                pickerFechaNacimiento.Value = persona.GetFechaNacimiento();

                // Fill de telefonos

                int idPersona = persona.GetIdPersona();
                DataTable dtTel = new DataTable();
                pms[0] = new SqlParameter("@id", SqlDbType.Int);
                pms[0].Value = idPersona;

                DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

                dtTel = dataQuery.getList(SP.OBTENER_TELEFONOS, pms);
                List<Telefono> telList = new List<Telefono>();
                if (!dtTel.Rows[0].ItemArray[0].GetType().Equals(typeof(string)))
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
                        String[] dataRow = { t.GetNumero(), t.GetTipo() };
                        dataGridTelefonos.Rows.Add(dataRow);
                    }
                }

                // Fill de correos

                DataTable dtMail = new DataTable();
                pms[0] = new SqlParameter("@id", SqlDbType.Int);
                pms[0].Value = idPersona;

                DataConnection.DataConnection dataQueryMails = new DataConnection.DataConnection();

                dtMail = dataQuery.getList(SP.OBTENER_MAILS, pms);
                List<Mail> mails = new List<Mail>();
                if (!dtMail.Rows[0].ItemArray[0].GetType().Equals(typeof(string)))
                {
                    foreach (DataRow drMail in dtMail.Rows)
                    {
                        Mail mail = new Mail();
                        mail.SetId((int)drMail[0]);
                        mail.SetTipo((string)drMail[1]);
                        mail.SetMail((string)drMail[2]);
                        mails.Add(mail);
                    }

                    foreach (Mail m in mails)
                    {
                        String[] dataRow = { m.GetMail(), m.GetTipo() };
                        dataGridMails.Rows.Add(dataRow);
                    }
                }

                // Fill de domicilios

                DataTable dtDom = new DataTable();
                pms[0] = new SqlParameter("@id", SqlDbType.Int);
                pms[0].Value = idPersona;


                dtDom = dataQuery.getList(SP.OBTENER_DOMICILIOS, pms);
                List<Domicilio> domList = new List<Domicilio>();
                try
                {

                    foreach (DataRow drDom in dtDom.Rows)
                    {
                        Localidad lc = new Localidad((string)drDom[10], (int)drDom[9], 0);
                        Provincia pv = new Provincia((string)drDom[12], (int)drDom[11]);
                        Pais p = new Pais((int)drDom[13], (string)drDom[14]);
                        Domicilio dom = new Domicilio((int)drDom[0], (string)drDom[1], (string)drDom[2], (int)drDom[3], (string)drDom[4], (string)drDom[5], (string)drDom[6], (string)drDom[7], lc, p, pv);

                        domList.Add(dom);

                    }
                    foreach (Domicilio d in domList)
                    {
                        object[] dataRow = { d.GetTipoDomicilio(), d.GetComentario(), d.GetCalle(), d.GetNumero(), d.GetPiso(), d.GetDpto(), d.GetCodigoPostal(), d.GetLocalidad(), d.GetProvincia(), d.GetPais() };
                        dataGridDomicilios.Rows.Add(dataRow);
                    }
                }
                catch
                {
                    messageBox.Show(Properties.strings.no_addresses);
                }

                // Deshabilitar todos los controles y mostrar los datos 

                groupBox2.Enabled = false;
                groupBox4.Enabled = false;

                groupBox7.Enabled = false;
                groupBox8.Enabled = false;

                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
            }
            else
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                comboSexo.Enabled = true;
                pickerFechaNacimiento.Enabled = true;

                groupBox2.Enabled = false;
                groupBox4.Enabled = false;

                groupBox7.Enabled = false;
                groupBox8.Enabled = false;

                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
            }

            txtDni.TextChanged += txtDni_TextChanged;
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            comboSexo.Enabled = false;
            pickerFechaNacimiento.Enabled = false;

            groupBox2.Enabled = false;
            txtNumero.Clear();
            comboTipoTelefono.ResetText();
            groupBox4.Enabled = false;
            dataGridTelefonos.Rows.Clear();

            groupBox7.Enabled = false;
            textBoxMail.Clear();
            comboTipoMails.ResetText();
            groupBox8.Enabled = false;
            dataGridMails.Rows.Clear();

            groupBox5.Enabled = false;
            txtCalle.Clear();
            txtNumero.Clear();
            txtCodigoPostal.Clear();
            txtDpto.Clear();
            txtComentario.Clear();
            txtPiso.ResetText();
            comboPais.ResetText();
            comboProvincias.ResetText();
            comboLocalidades.ResetText();
            comboTipo.ResetText();
            groupBox6.Enabled = false;
            dataGridDomicilios.Rows.Clear();
        }

        private void buttonAddTelefono_Click(object sender, EventArgs e)
        {
            Telefono tel = new Telefono();
            tel.SetNumero(textBoxNumero.Text);
            tel.SetTipo(comboTipoTelefono.SelectedItem.ToString());

            String[] dataRow = { tel.GetTipo(), tel.GetNumero() };
            dataGridTelefonos.Rows.Add(dataRow);
        }

        private void buttonAddCliente_Click(object sender, EventArgs e)
        {
            DataConnection.DataConnection dataConnection = new DataConnection.DataConnection();

            SqlParameter[] pms = new SqlParameter[8];
            pms[0] = new SqlParameter("@razonSocial", SqlDbType.VarChar);
            pms[0].Value = txtRazonSocial.Text;

            pms[1] = new SqlParameter("@cuil", SqlDbType.VarChar);
            pms[1].Value = txtCuit.Text;

            pms[2] = new SqlParameter("@tipoCliente", SqlDbType.VarChar);
            pms[2].Value = comboTipoCliente.SelectedItem.ToString();

            pms[3] = new SqlParameter("@dni", SqlDbType.VarChar);
            pms[3].Value = txtDni.Text;

            pms[4] = new SqlParameter("@nombre", SqlDbType.VarChar);
            pms[4].Value = txtNombre.Text;

            pms[5] = new SqlParameter("@apellido", SqlDbType.VarChar);
            pms[5].Value = txtApellido.Text;

            pms[6] = new SqlParameter("@sexo", SqlDbType.VarChar);
            pms[6].Value = comboSexo.SelectedItem.ToString();

            pms[7] = new SqlParameter("@fechaNacimiento", SqlDbType.Date);
            pms[7].Value = pickerFechaNacimiento.Value;

            int fk = dataConnection.databaseInsert(pms, SP.ALTA_CLIENTE);

            if (fk > 0)
            {
                SqlParameter[] pmsTelefono = new SqlParameter[3];
                SqlParameter[] pmsMail = new SqlParameter[3];
                SqlParameter[] pmsDomicilio = new SqlParameter[9];

                for (int i =0 ; i < dataGridTelefonos.Rows.Count; i++)
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
                    pmsTelefono[2].Value = fk;

                    dataConnection.databaseInsertAditionalData(pmsTelefono, SP.ALTA_TELEFONO);           
                }

                for (int i =0 ; i < dataGridMails.Rows.Count; i++)
                {
                    Mail m = new Mail();

                    m.SetTipo((string)dataGridMails.Rows.SharedRow(i).Cells[0].Value);
                    m.SetMail((string)dataGridMails.Rows.SharedRow(i).Cells[1].Value);
                    mails.Add(m);

                    pmsMail[0] = new SqlParameter("@tipo", SqlDbType.VarChar);
                    pmsMail[0].Value = m.GetTipo();

                    pmsMail[1] = new SqlParameter("@mail", SqlDbType.VarChar);
                    pmsMail[1].Value = m.GetMail();

                    pmsMail[2] = new SqlParameter("@fk_persona", SqlDbType.Int);
                    pmsMail[2].Value = fk;

                    dataConnection.databaseInsertAditionalData(pmsMail, SP.ALTA_MAIL);           
                }

                for (int i = 0; i < dataGridDomicilios.Rows.Count; i++)
                {
                    Domicilio dom = new Domicilio();
                    dom.SetTipoDomicilio((String)dataGridDomicilios.Rows.SharedRow(i).Cells[0].Value);
                    dom.SetComentario((String)dataGridDomicilios.Rows.SharedRow(i).Cells[1].Value);
                    dom.SetCalle((String)dataGridDomicilios.Rows.SharedRow(i).Cells[2].Value);
                    dom.SetNumero((String)dataGridDomicilios.Rows.SharedRow(i).Cells[3].Value);
                    dom.SetPiso((Int32)dataGridDomicilios.Rows.SharedRow(i).Cells[4].Value);
                    dom.SetDpto((String)dataGridDomicilios.Rows.SharedRow(i).Cells[5].Value);
                    dom.SetCodigoPostal((String)dataGridDomicilios.Rows.SharedRow(i).Cells[6].Value);
                    dom.SetLocalidad((Localidad)dataGridDomicilios.Rows.SharedRow(i).Cells[7].Value);

                    domicilios.Add(dom);
                }

                foreach(Domicilio d in domicilios)
                {
                    pmsDomicilio[0] = new SqlParameter("@calle", SqlDbType.VarChar);
                    pmsDomicilio[0].Value = d.GetCalle();

                    pmsDomicilio[1] = new SqlParameter("@numero", SqlDbType.VarChar);
                    pmsDomicilio[1].Value = d.GetNumero();

                    pmsDomicilio[2] = new SqlParameter("@piso", SqlDbType.Int);
                    pmsDomicilio[2].Value = (object) d.GetPiso() ?? DBNull.Value;

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
                    pmsDomicilio[8].Value = fk;

                    dataConnection.databaseInsertAditionalData(pmsDomicilio, SP.ALTA_DOMICILIO);
                }
            }

            new CustomMessageBox().Show(Properties.strings.client_created_person_created);
        }

        private void altaCliente_Load(object sender, EventArgs e)
        {
            //Llenado de combo de paises
            List<Pais> paises = new List<Pais>();
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            dt = dataQuery.getList(SP.LISTAR_PAISES, null);
            foreach (DataRow dr in dt.Rows)
            {
                Pais pais = new Pais((int) dr[0], (string) dr[1]);
                paises.Add(pais);
            }
            comboPais.DataSource = paises;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = Dialogo.LimpiarCampos();
            Console.Out.WriteLine(result);
        }

        private void comboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Provincia> provincias = new List<Provincia>();
            Pais pais = (Pais) comboPais.SelectedItem;
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            SqlParameter[] pmsProvincias = new SqlParameter[1];
            pmsProvincias[0] = new SqlParameter("@pais", SqlDbType.Int);
            pmsProvincias[0].Value = pais.GetId();
            dt = dataQuery.getList(SP.LISTAR_PROVINCIAS, pmsProvincias);
            foreach (DataRow dr in dt.Rows)
            {
                Provincia provincia = new Provincia((string) dr[0], (int) dr[1]);
                provincias.Add(provincia);
            }
            comboProvincias.DataSource = provincias;
        }

        private void comboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Localidad> localidades= new List<Localidad>();
            Provincia provincia  = (Provincia)comboProvincias.SelectedItem;
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            SqlParameter[] pmsLocalidades = new SqlParameter[1];
            pmsLocalidades[0] = new SqlParameter("@provincia", SqlDbType.Int);
            pmsLocalidades[0].Value = provincia.GetId();
            dt = dataQuery.getList(SP.LISTAR_LOCALIDADES, pmsLocalidades);
            foreach (DataRow dr in dt.Rows)
            {
                Localidad localidad = new Localidad((string)dr[0], (int)dr[1], (int)dr[2]);
                localidades.Add(localidad);
            } 
            comboLocalidades.DataSource = localidades;
        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            Domicilio dom = new Domicilio();
            dom.SetNumero(txtNumero.Text);
            dom.SetCalle(txtCalle.Text);
            dom.SetCodigoPostal(txtCodigoPostal.Text);
            dom.SetDpto(txtDpto.Text);
            try
            {
                dom.SetPiso(Convert.ToInt32(txtPiso.Text));
            } catch (Exception)
            {
               
            } 
            dom.SetTipoDomicilio(comboTipo.SelectedItem.ToString());
            dom.SetComentario(txtComentario.Text);
            dom.SetLocalidad((Localidad)comboLocalidades.SelectedItem);
            dom.SetProvincia((Provincia)comboProvincias.SelectedItem);
            dom.SetPais((Pais)comboPais.SelectedItem);

            Object[] dataRow = {dom.GetTipoDomicilio(), dom.GetComentario(), dom.GetCalle(), dom.GetNumero(), dom.GetPiso(), dom.GetDpto(), dom.GetCodigoPostal(), dom.GetLocalidad() };
            dataGridDomicilios.Rows.Add(dataRow);
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

        private void btnModificarTel_Click(object sender, EventArgs e)
        {
            if (dataGridTelefonos.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridTelefonos.SelectedCells[0].RowIndex;
                dataGridTelefonos.Rows[rowIndex].Cells[0].Value = textBoxNumero.Text;
                dataGridTelefonos.Rows[rowIndex].Cells[1].Value = comboTipoTelefono.Text;
            }
        }

        private void btnAgregarMail_Click(object sender, EventArgs e)
        {
            Mail mail = new Mail();
            mail.SetMail(textBoxMail.Text);
            mail.SetTipo(comboTipoMails.SelectedItem.ToString());

            String[] dataRow = { mail.GetTipo(), mail.GetMail() };
            dataGridMails.Rows.Add(dataRow);
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
