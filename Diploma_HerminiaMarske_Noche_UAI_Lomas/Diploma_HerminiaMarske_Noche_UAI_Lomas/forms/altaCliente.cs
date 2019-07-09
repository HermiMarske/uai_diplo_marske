using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using ConstantesData;
using System.Linq;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties;
using System.Text.RegularExpressions;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Constantes;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;

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
                comboTipoCliente.Enabled = true;
                txtRazonSocial.Enabled = true;
                txtCuit.Enabled = true;

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
                        string[] dataRow = { t.GetNumero(), t.GetTipo() };
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
                        string[] dataRow = { m.GetMail(), m.GetTipo() };
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
                    messageBox.Show(strings.no_addresses);
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
                comboTipoCliente.Enabled = true;
                txtRazonSocial.Enabled = true;
                txtCuit.Enabled = true;

                groupBox2.Enabled = true;
                groupBox4.Enabled = true;

                groupBox7.Enabled = true;
                groupBox8.Enabled = true;

                groupBox5.Enabled = true;
                groupBox6.Enabled = true;
            }

            txtDni.TextChanged += txtDni_TextChanged;
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            comboSexo.Enabled = false;
            pickerFechaNacimiento.Enabled = false;
            comboTipoCliente.Enabled = false;
            txtRazonSocial.Enabled = false;
            txtCuit.Enabled = false;

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

            string[] dataRow = { tel.GetTipo(), tel.GetNumero() };
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
                    dom.SetTipoDomicilio((string)dataGridDomicilios.Rows.SharedRow(i).Cells[0].Value);
                    dom.SetComentario((string)dataGridDomicilios.Rows.SharedRow(i).Cells[1].Value);
                    dom.SetCalle((string)dataGridDomicilios.Rows.SharedRow(i).Cells[2].Value);
                    dom.SetNumero((string)dataGridDomicilios.Rows.SharedRow(i).Cells[3].Value);
                    dom.SetPiso((int)dataGridDomicilios.Rows.SharedRow(i).Cells[4].Value);
                    dom.SetDpto((string)dataGridDomicilios.Rows.SharedRow(i).Cells[5].Value);
                    dom.SetCodigoPostal((string)dataGridDomicilios.Rows.SharedRow(i).Cells[6].Value);
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

            BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_BAJA, ConstantesBitacora.CLIENTE_CREADO, new Usuario());
            ControladorBitacora.grabarRegistro(bitacora);

            new CustomMessageBox().Show(strings.client_created_person_created, true);
            Close();
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

            object[] dataRow = {dom.GetTipoDomicilio(), dom.GetComentario(), dom.GetCalle(), dom.GetNumero(), dom.GetPiso(), dom.GetDpto(), dom.GetCodigoPostal(), dom.GetLocalidad() };
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

            string[] dataRow = { mail.GetTipo(), mail.GetMail() };
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

        private void txtDni_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            comboSexo.Enabled = false;
            pickerFechaNacimiento.Enabled = false;
            comboTipoCliente.Enabled = false;
            txtRazonSocial.Enabled = false;
            txtCuit.Enabled = false;

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

            if (txtDni.Text.Length < 8)
            {
                e.Cancel = true;
                errProvider.SetError(txtDni, strings.dni_length_incorrect);
            }
            else if (!Regex.Match(txtDni.Text, @"^\d{8}$", RegexOptions.IgnoreCase).Success)
            {
                e.Cancel = true;
                errProvider.SetError(txtDni, strings.dni_format_incorrect);
            }
        }

        private void txtDni_Validated(object sender, EventArgs e)
        {
            errProvider.Clear();
            personaFillData();
        }

        private void txtNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.Match(txtNombre.Text, @"^[A-z ]{1,50}$", RegexOptions.IgnoreCase).Success)
            {
                e.Cancel = true;
                errProvider.SetError(txtNombre, strings.name_text_only);
            }
        }

        private void txtNombre_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void txtApellido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.Match(txtApellido.Text, @"^[A-z ]{1,50}$", RegexOptions.IgnoreCase).Success)
            {
                e.Cancel = true;
                errProvider.SetError(txtApellido, strings.name_text_only);
            }
        }

        private void txtApellido_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void comboSexo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!comboSexo.Items.Contains(comboSexo.Text))
            {
                e.Cancel = true;
                errProvider.SetError(comboSexo, strings.select_value_from_combo);
            }
        }

        private void comboSexo_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void pickerFechaNacimiento_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (pickerFechaNacimiento.Value >= DateTime.Now)
            {
                e.Cancel = true;
                errProvider.SetError(pickerFechaNacimiento, strings.date_too_recent);
            }
        }

        private void pickerFechaNacimiento_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void comboTipoCliente_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!comboTipoCliente.Items.Contains(comboTipoCliente.Text))
            {
                e.Cancel = true;
                errProvider.SetError(comboTipoCliente, strings.select_value_from_combo);
            }
        }

        private void comboTipoCliente_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtRazonSocial.Text.Length > 50 || txtRazonSocial.Text.Length < 1)
            {
                e.Cancel = true;
                errProvider.SetError(txtRazonSocial, string.Format(strings.text_length_too_short, 1, 50));
            }
        }

        private void txtRazonSocial_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void txtCuit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtCuit.Text.Length < 11)
            {
                e.Cancel = true;
                errProvider.SetError(txtCuit, strings.cuit_length_incorrect);
            }
            else if (!Regex.Match(txtCuit.Text, @"^(\d){11}$", RegexOptions.IgnoreCase).Success)
            {
                e.Cancel = true;
                errProvider.SetError(txtCuit, strings.cuit_format_incorrect);
            }
        }

        private void txtCuit_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void textBoxNumero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.Match(textBoxNumero.Text, @"^\+?(\d){1,13}$", RegexOptions.IgnoreCase).Success)
            {
                e.Cancel = true;
                errProvider.SetError(textBoxNumero, strings.phone_format_incorrect);
            }
        }

        private void textBoxNumero_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void comboTipoTelefono_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!comboTipoTelefono.Items.Contains(comboTipoTelefono.Text))
            {
                e.Cancel = true;
                errProvider.SetError(comboTipoTelefono, strings.select_value_from_combo);
            }
        }

        private void comboTipoTelefono_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void textBoxMail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.Match(textBoxMail.Text, @"^\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b$", RegexOptions.IgnoreCase).Success)
            {
                e.Cancel = true;
                errProvider.SetError(textBoxMail, strings.mail_format_incorrect);
            }
        }

        private void textBoxMail_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void comboTipoMails_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!comboTipoMails.Items.Contains(comboTipoMails.Text))
            {
                e.Cancel = true;
                errProvider.SetError(comboTipoMails, strings.select_value_from_combo);
            }
        }

        private void comboTipoMails_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void txtCalle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtCalle.Text.Length > 50 || txtCalle.Text.Length < 1)
            {
                e.Cancel = true;
                errProvider.SetError(txtCalle, string.Format(strings.text_length_too_short, 1, 50));
            }
            else if (!Regex.Match(txtCalle.Text, @"^[\w &\(\)\\]{1,50}$", RegexOptions.IgnoreCase).Success)
            {
                e.Cancel = true;
                errProvider.SetError(txtCalle, strings.street_format_incorrect);
            }
        }

        private void txtCalle_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void txtNumero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtNumero.Text.Length > 10 || txtCalle.Text.Length < 1)
            {
                e.Cancel = true;
                errProvider.SetError(txtNumero, string.Format(strings.text_length_too_short, 1, 10));
            }
            else if (!Regex.Match(txtNumero.Text, @"^\d{1,10}$", RegexOptions.IgnoreCase).Success)
            {
                e.Cancel = true;
                errProvider.SetError(txtNumero, strings.numbers_only);
            }
        }

        private void txtNumero_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void comboPais_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!comboPais.Items.Cast<Pais>().Select(p => p.GetNombre().Equals(comboPais.Text)).First())
            {
                e.Cancel = true;
                errProvider.SetError(comboPais, strings.select_value_from_combo);
            }
        }

        private void comboPais_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void comboProvincias_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!comboProvincias.Items.Cast<Provincia>().Select(p => p.GetNombre().Equals(comboProvincias.Text)).First())
            {
                e.Cancel = true;
                errProvider.SetError(comboProvincias, strings.select_value_from_combo);
            }
        }

        private void comboProvincias_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void comboLocalidades_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!comboLocalidades.Items.Cast<Localidad>().Select(l => l.GetNombre().Equals(comboLocalidades.Text)).First())
            {
                e.Cancel = true;
                errProvider.SetError(comboLocalidades, strings.select_value_from_combo);
            }
        }

        private void comboLocalidades_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void txtCodigoPostal_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtCodigoPostal.Text.Length > 10 || txtCodigoPostal.Text.Length < 1)
            {
                e.Cancel = true;
                errProvider.SetError(txtCodigoPostal, string.Format(strings.text_length_too_short, 1, 10));
            }
            else if (!Regex.Match(txtCodigoPostal.Text, @"^\d{1,10}$", RegexOptions.IgnoreCase).Success)
            {
                e.Cancel = true;
                errProvider.SetError(txtCodigoPostal, strings.numbers_only);
            }
        }

        private void txtCodigoPostal_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void txtDpto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtDpto.Text.Length > 4 || txtDpto.Text.Length < 1)
            {
                e.Cancel = true;
                errProvider.SetError(txtDpto, string.Format(strings.text_length_too_short, 1, 4));
            }
            else if (!Regex.Match(txtDpto.Text, @"^\w{1,4}$", RegexOptions.IgnoreCase).Success)
            {
                e.Cancel = true;
                errProvider.SetError(txtDpto, strings.alphanumeric_only);
            }
        }

        private void txtDpto_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void txtPiso_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtPiso.Value < 0 && txtPiso.Value > 100)
            {
                e.Cancel = true;
                errProvider.SetError(txtDpto, string.Format(strings.out_of_range, 1, 100));
            }
        }

        private void txtPiso_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void comboTipo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!comboTipo.Items.Contains(comboTipo.Text))
            {
                e.Cancel = true;
                errProvider.SetError(comboTipo, strings.select_value_from_combo);
            }
        }

        private void comboTipo_Validated(object sender, EventArgs e) => errProvider.Clear();

        private void txtComentario_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtComentario.Text.Length > 100 || txtDpto.Text.Length < 1)
            {
                e.Cancel = true;
                errProvider.SetError(txtDpto, string.Format(strings.text_length_too_short, 1, 100));
            }
        }

        private void txtComentario_Validated(object sender, EventArgs e) => errProvider.Clear();
    }
}
