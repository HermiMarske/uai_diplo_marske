using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
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

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class altaUsuario : Form
    {
        public altaUsuario()
        {
            InitializeComponent();
        }

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

        private void dataGridTelefonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxNumero.Text = (string)dataGridTelefonos.Rows[e.RowIndex].Cells[0].Value;
                comboTipoTelefono.Text = (string)dataGridTelefonos.Rows[e.RowIndex].Cells[1].Value;
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

        private void buttonAddTelefono_Click(object sender, EventArgs e)
        {
            Telefono tel = new Telefono();
            tel.SetNumero(textBoxNumero.Text);
            tel.SetTipo(comboTipoTelefono.SelectedItem.ToString());

            String[] dataRow = { tel.GetTipo(), tel.GetNumero() };
            dataGridTelefonos.Rows.Add(dataRow);
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

        private void btnBorrarTel_Click(object sender, EventArgs e)
        {
            if (dataGridTelefonos.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridTelefonos.SelectedCells[0].RowIndex;
                dataGridTelefonos.Rows.RemoveAt(rowIndex);
            }
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

        private void btnBorrarDomicilio_Click(object sender, EventArgs e)
        {
            if (dataGridDomicilios.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridDomicilios.SelectedCells[0].RowIndex;
                dataGridDomicilios.Rows.RemoveAt(rowIndex);
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

        private void btnModificarMail_Click(object sender, EventArgs e)
        {
            if (dataGridMails.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridMails.SelectedCells[0].RowIndex;
                dataGridMails.Rows[rowIndex].Cells[0].Value = textBoxMail.Text;
                dataGridMails.Rows[rowIndex].Cells[1].Value = comboTipoMails.Text;
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
            pmsLocalidades[0] = new SqlParameter("@provincia", SqlDbType.Int);
            pmsLocalidades[0].Value = provincia.GetId();
            da = dataQuery.getList("ListarLocalidades", pmsLocalidades);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Localidad localidad = new Localidad((string)dr[0], (int)dr[1], (int)dr[2]);
                localidades.Add(localidad);
            }
            comboLocalidades.DataSource = localidades;
        }

        private void personaFillData()
        {
            string dni = txtDni.Text;
            if (String.IsNullOrEmpty(dni))
            {
                return;
            }
            DataConnection.DataConnection dataConnection = new DataConnection.DataConnection();
            SqlDataAdapter dap = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlParameter[] pms = new SqlParameter[1];

            pms[0] = new SqlParameter("@dniPersona", SqlDbType.VarChar);
            pms[0].Value = dni;

            dap = dataConnection.getList("ObtenerPersona", pms);
            dap.Fill(dt);

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
                txtUsuario.Enabled = true;
                txtClave.Enabled = true;
                txtRptClave.Enabled = true;

                // Fill de telefonos

                int idPersona = persona.GetIdPersona();
                DataTable dtTel = new DataTable();
                pms[0] = new SqlParameter("@id", SqlDbType.Int);
                pms[0].Value = idPersona;

                SqlDataAdapter da = new SqlDataAdapter();
                DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

                da = dataQuery.getList("ObtenerTelefonos", pms);
                da.Fill(dtTel);
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
                        String[] dataRow = { t.GetNumero(), t.GetTipo() };
                        dataGridTelefonos.Rows.Add(dataRow);
                    }
                }
                catch
                {
                    MessageBox.Show(dtTel.Rows[0].ItemArray[0].ToString());
                }

                // Fill de correos

                DataTable dtMail = new DataTable();
                pms[0] = new SqlParameter("@id", SqlDbType.Int);
                pms[0].Value = idPersona;

                SqlDataAdapter daMails = new SqlDataAdapter();
                DataConnection.DataConnection dataQueryMails = new DataConnection.DataConnection();

                daMails = dataQuery.getList("ObtenerMails", pms);
                da.Fill(dtTel);
                List<Mail> mails = new List<Mail>();

                try
                {
                    foreach (DataRow drMail in dtMail.Rows)
                    {
                        Mail mail= new Mail();
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
                catch
                {
                    MessageBox.Show(dtTel.Rows[0].ItemArray[0].ToString());
                }

                // Fill de domicilios

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
                    Domicilio dom = new Domicilio((int)drDom[0], (string)drDom[1], (string)drDom[2], (int)drDom[3], (string)drDom[4], (string)drDom[5], (string)drDom[6], (string)drDom[7], lc, p, pv);

                    domList.Add(dom);

                }
                foreach (Domicilio d in domList)
                {
                    object[] dataRow = { d.GetTipoDomicilio(), d.GetComentario(), d.GetCalle(), d.GetNumero(), d.GetPiso().ToString(), d.GetDpto(), d.GetCodigoPostal(), d.GetLocalidad(), d.GetProvincia(), d.GetPais() };
                    dataGridDomicilios.Rows.Add(dataRow);
                }

                // Deshabilitar todos los controles y mostrar los datos 

                groupTelDatos.Enabled = false;
                groupTelLista.Enabled = false;

                groupMailDatos.Enabled = false;
                groupMailLista.Enabled = false;

                groupDomicilioDatos.Enabled = false;
                groupDomicilioLista.Enabled = false;

                groupPermisosFamilia.Enabled = false;
                groupPermisosPatentes.Enabled = false;
            }
            else
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                comboSexo.Enabled = true;
                pickerFechaNacimiento.Enabled = true;
                txtUsuario.Enabled = true;
                txtClave.Enabled = true;
                txtRptClave.Enabled = true;

                groupTelDatos.Enabled = true;
                groupTelLista.Enabled = true;

                groupMailDatos.Enabled = true;
                groupMailLista.Enabled = true;

                groupDomicilioDatos.Enabled = true;
                groupDomicilioLista.Enabled = true;

                groupPermisosFamilia.Enabled = true;
                groupPermisosPatentes.Enabled = true;
            }

            txtDni.TextChanged += TxtDni_TextChanged;
        }

        private void TxtDni_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            comboSexo.Enabled = false;
            pickerFechaNacimiento.Enabled = false;
            txtUsuario.Enabled = false;
            txtUsuario.Clear();
            txtClave.Enabled = false;
            txtClave.Clear();
            txtRptClave.Enabled = false;
            txtRptClave.Clear();

            groupTelDatos.Enabled = false;
            txtNumero.Clear();
            comboTipoTelefono.ResetText();
            groupTelLista.Enabled = false;
            dataGridTelefonos.Rows.Clear();

            groupMailDatos.Enabled = false;
            textBoxMail.Clear();
            comboTipoMails.ResetText();
            groupMailLista.Enabled = false;
            dataGridMails.Rows.Clear();

            groupDomicilioDatos.Enabled = false;
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
            groupDomicilioLista.Enabled = false;
            dataGridDomicilios.Rows.Clear();

            groupPermisosFamilia.Enabled = false;
            groupPermisosPatentes.Enabled = false;
        }

        private void funcionAltaUsuario()
        {

        }

        private void altaUsuario_Load(object sender, EventArgs e)
        {
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
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            comboSexo.Enabled = false;
            pickerFechaNacimiento.Enabled = false;
            txtUsuario.Enabled = false;
            txtUsuario.Clear();
            txtClave.Enabled = false;
            txtClave.Clear();
            txtRptClave.Enabled = false;
            txtRptClave.Clear();

            groupTelDatos.Enabled = false;
            groupTelLista.Enabled = false;

            groupMailDatos.Enabled = false;
            groupMailLista.Enabled = false;

            groupDomicilioDatos.Enabled = false;
            groupDomicilioLista.Enabled = false;

            groupPermisosFamilia.Enabled = false;
            groupPermisosPatentes.Enabled = false;
        }
    }
}
