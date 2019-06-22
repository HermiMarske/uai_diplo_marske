using ConstantesData;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
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
    public partial class modificarUsuario : Form
    {
        Usuario usr = new Usuario();

        public modificarUsuario()
        {
            InitializeComponent();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(altaCliente));
            groupBox1.Text = resources.GetString("groupBox1.Text");
            groupBox2.Text = resources.GetString("groupBox2.Text");
            groupBox4.Text = resources.GetString("groupBox4.Text");
            groupBox6.Text = resources.GetString("groupBox6.Text");
            groupBox5.Text = resources.GetString("groupDomicilioDatos.Text");
            groupBox10.Text = resources.GetString("groupBox8.Text");
            groupBox9.Text = resources.GetString("groupBox7.Text");
            label10.Text = resources.GetString("label10.Text");
            label6.Text = resources.GetString("label6.Text");
            label9.Text = resources.GetString("label9.Text");
            label8.Text = resources.GetString("label8.Text");
            label9.Text = resources.GetString("label9.Text");
            label12.Text = resources.GetString("label12.Text");
            label13.Text = resources.GetString("label13.Text");
            label5.Text = resources.GetString("label5.Text");
            label1.Text = resources.GetString("label1.Text");
            label2.Text = resources.GetString("label2.Text");
            label3.Text = resources.GetString("label3.Text");
            comboSexo.Items.AddRange(new object[] {
                resources.GetString("comboSexo.Items"),
                resources.GetString("comboSexo.Items1")
            });
            comboTipo.Items.AddRange(new object[] {
                resources.GetString("comboTipo.Items"),
                resources.GetString("comboTipo.Items1")
            });
            comboTipoMails.Items.AddRange(new object[] {
                resources.GetString("comboTipoMails.Items"),
                resources.GetString("comboTipoMails.Items1")
            });
            buttonAddTelefono.Text = resources.GetString("buttonAddTelefono.Text");
            btnModificarTel.Text = resources.GetString("btnModificarTel.Text");
            btnBorrarTel.Text = resources.GetString("btnBorrarTel.Text");
            btnModificarDom.Text = resources.GetString("btnModificarDom.Text");
            btnAgregarDireccion.Text = resources.GetString("btnAgregarDireccion.Text");
            btnBorrarDomicilio.Text = resources.GetString("btnBorrarDomicilio.Text");
            btnAgregarMail.Text = resources.GetString("btnAgregarMail.Text");
            btnModificarMail.Text = resources.GetString("btnModificarMail.Text");
            btnBorrarMail.Text = resources.GetString("btnBorrarMail.Text");
            button6.Text = resources.GetString("button6.Text");
            button7.Text = resources.GetString("button7.Text");
            labelTipoEmail.Text = resources.GetString("labelTipoEmail.Text");
            labelEmail.Text = resources.GetString("labelEmail.Text");
            tabPage1.Text = resources.GetString("tabPage1.Text");
            tabPage2.Text = resources.GetString("tabPage2.Text");
            tabPage5.Text = resources.GetString("tabPage4.Text");
            tabPage3.Text = resources.GetString("tabPage3.Text");
            TipoTelefono.HeaderText = resources.GetString("TipoTelefono.HeaderText");
            NumeroTelefono.HeaderText = resources.GetString("NumeroTelefono.HeaderText");
            dataGridViewTextBoxColumn1.HeaderText = resources.GetString("dataGridViewTextBoxColumn1.HeaderText");
            dataGridViewTextBoxColumn2.HeaderText = resources.GetString("dataGridViewTextBoxColumn2.HeaderText");
            Tipo.HeaderText = resources.GetString("Tipo.HeaderText");
            Comentario.HeaderText = resources.GetString("Comentario.HeaderText");
            Calle.HeaderText = resources.GetString("Calle.HeaderText");
            Numero.HeaderText = resources.GetString("Numero.HeaderText");
            Piso.HeaderText = resources.GetString("Piso.HeaderText");
            DPTO.HeaderText = resources.GetString("DPTO.HeaderText");
            CP.HeaderText = resources.GetString("CP.HeaderText");
            Localidad.HeaderText = resources.GetString("Localidad.HeaderText");
            Provincia.HeaderText = resources.GetString("Provincia.HeaderText");
            Pais.HeaderText = resources.GetString("Pais.HeaderText");
            dataGridDomicilios.Text = resources.GetString("dataGridDomicilios.Text");
            labelCalle.Text = resources.GetString("labelCalle.Text");
            labelLocalidad.Text = resources.GetString("labelLocalidad.Text");
            labelDpto.Text = resources.GetString("labelDpto.Text");
            labelCodigo.Text = resources.GetString("labelCodigo.Text");
            labelPiso.Text = resources.GetString("labelPiso.Text");
            labelNumero.Text = resources.GetString("labelNumero.Text");

            resources = new ComponentResourceManager(typeof(altaUsuario));
            labelUsuario.Text = resources.GetString("labelUsuario.Text");
            labelClaveRpt.Text = resources.GetString("labelClaveRpt.Text");
            labelPregunta.Text = resources.GetString("labelPregunta.Text");
            labelRespuesta.Text = resources.GetString("labelRespuesta.Text");
            tabPage6.Text = resources.GetString("tabPage4.Text");
            tabPage4.Text = resources.GetString("tabPage6.Text");
            groupPermisosFamilia.Text = resources.GetString("groupPermisosFamilia.Text");
            groupFamiliasPatentes.Text = resources.GetString("groupFamiliasPatentes.Text");
            groupPermisosPatentes.Text = resources.GetString("groupPermisosPatentes.Text");
            groupPatentesAdquiridas.Text = resources.GetString("groupPatentesAdquiridas.Text");
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void modificarUsuario_Load(object sender, EventArgs e)
        {
            usr = ControladorABMUsuario.getUsuario((int)formInicio.idUsuarioModif);

            //coso de familias

            List<FamiliaFlag> famFlag = ControladorABMUsuario.getFamilias(usr.GetIdUsuario());
            int c = 0;
            foreach(FamiliaFlag f in famFlag)
            {
                DataConnection.DataConnection dataQueryFamiliasPatentes = new DataConnection.DataConnection();
                DataTable dtfp = new DataTable();
                dtfp = dataQueryFamiliasPatentes.getList(SP.LISTAR_PATENTES_FAMILIAS, null);
                List<Patente> patenteList = new List<Patente>();
                foreach (DataRow drfp in dtfp.Rows)
                {
                    if (f.GetId() == (int)drfp[0])
                    {
                        Patente p = new Patente((int)drfp[2], (string)drfp[3], (int)drfp[0]);
                        patenteList.Add(p);
                    }
                }
                f.SetPatentes(patenteList);
                checkedListFamilias.Items.Add(f);
                if(f.GetFlag())
                {
                    checkedListFamilias.SetItemChecked(c, true);
                }
                c++;
            }

            //LLENADO COSO DE PATENTES
            List<Patente> patentes = new List<Patente>();
            DataConnection.DataConnection dataQueryPatentes = new DataConnection.DataConnection();
            DataTable dtpat = new DataTable();
            string sql = "SELECT p.idPatente, p.codigo, up.negado from Patente p left join Usuario_Patente up on p.idPatente = up.patenteFK where up.usuarioFK = @idUsuario;"; 
            dtpat = dataQueryPatentes.getList(SP.LISTAR_TODAS_PATENTES, null);
            foreach (DataRow drpat in dtpat.Rows)
            {
                Patente patente = new Patente((int)drpat[0], (string)drpat[1]);
                patentes.Add(patente);
            }
            checkedListPatentes.DataSource = patentes;

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

            checkedListFamilias_SelectedIndexChanged(sender, e);
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


        //Solapa Tel

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
                dataGridTelefonos.Rows[rowIndex].Cells[1].Value = textBoxNumero.Text;
                dataGridTelefonos.Rows[rowIndex].Cells[0].Value = comboTipoTelefono.Text;
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

        private void dataGridTelefonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                comboTipoTelefono.Text = (string)dataGridTelefonos.Rows[e.RowIndex].Cells[0].Value;
                textBoxNumero.Text = (string)dataGridTelefonos.Rows[e.RowIndex].Cells[1].Value;
            }
        }

        //Fin Solapa Tel

        //Solapa Mails

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

        private void dataGridMails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxMail.Text = (string)dataGridMails.Rows[e.RowIndex].Cells[0].Value;
                comboTipoMails.Text = (string)dataGridMails.Rows[e.RowIndex].Cells[1].Value;
            }
        }

        //Fin solapa Mails

        //Solapa Domicilios

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

        private void borrarDom_Click(object sender, EventArgs e)
        {
            if (dataGridDomicilios.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridDomicilios.SelectedCells[0].RowIndex;
                dataGridDomicilios.Rows.RemoveAt(rowIndex);
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

        //Fin solapa DOMICILIOS

        private void checkedListFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<FamiliaFlag> familiasSeleccionadas = new List<FamiliaFlag>();
            string listarPatentes = "";

            foreach (FamiliaFlag f in checkedListFamilias.CheckedItems)
            {
                familiasSeleccionadas.Add(f);
                listarPatentes += (!string.IsNullOrEmpty(listarPatentes) && f.GetPatentes().Count > 0 ? "," : "") + string.Join(",", f.GetPatentes().Select(n => n.GetId().ToString()).ToArray());
            }

            listBoxFamiliasAdquiridas.DataSource = familiasSeleccionadas;

            List<Patente> patentes = new List<Patente>();
            List<Patente> patentes2 = new List<Patente>();
            DataConnection.DataConnection patentesHeredadas = new DataConnection.DataConnection();
            DataTable ph = new DataTable();
            if (!string.IsNullOrEmpty(listarPatentes))
            {
                string sql = string.Format("SELECT p.idPatente, p.codigo FROM Patente p WHERE p.idPatente IN ({0})", listarPatentes);
                ph = patentesHeredadas.sqlExecute(sql, null);

                foreach (DataRow dr in ph.Rows)
                {
                    Patente p = new Patente((int)dr[0], (string)dr[1]);
                    patentes.Add(p);
                }
            }
            string sql2 = "SELECT p.idPatente, p.codigo FROM Patente p" + (!string.IsNullOrEmpty(listarPatentes) ? string.Format(" WHERE p.idPatente NOT IN ({0})", listarPatentes) : "");
            ph = patentesHeredadas.sqlExecute(sql2, null);

            foreach (DataRow dr in ph.Rows)
            {
                Patente p = new Patente((int)dr[0], (string)dr[1]);
                patentes2.Add(p);
            }

            checkedListPatentesAdquiridas.DataSource = patentes;
            for (int i = 0; i < checkedListPatentesAdquiridas.Items.Count; i++)
            {
                checkedListPatentesAdquiridas.SetItemChecked(i, true);
            }
            checkedListPatentes.DataSource = patentes2;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            List<Domicilio> domicilios = new List<Domicilio>();
            List<Telefono> telefonos = new List<Telefono>();
            List<Mail> mails = new List<Mail>();


            for (int i = 0; i < dataGridTelefonos.Rows.Count; i++)
            {
                Telefono t = new Telefono((string)dataGridTelefonos.Rows.SharedRow(i).Cells[0].Value, (string)dataGridTelefonos.Rows.SharedRow(i).Cells[1].Value);
                telefonos.Add(t);
            }
            for (int i = 0; i < dataGridMails.Rows.Count; i++)
            {
                Mail m = new Mail((string)dataGridMails.Rows.SharedRow(i).Cells[0].Value, (string)dataGridMails.Rows.SharedRow(i).Cells[1].Value);
                mails.Add(m);
            }

            for (int i = 0; i < dataGridDomicilios.Rows.Count; i++)
            {
                Domicilio dom = new Domicilio(0, (string)dataGridDomicilios.Rows.SharedRow(i).Cells[2].Value,
                    (string)dataGridDomicilios.Rows.SharedRow(i).Cells[3].Value, (int)dataGridDomicilios.Rows.SharedRow(i).Cells[4].Value,
                    (string)dataGridDomicilios.Rows.SharedRow(i).Cells[5].Value, (string)dataGridDomicilios.Rows.SharedRow(i).Cells[1].Value,
                    (string)dataGridDomicilios.Rows.SharedRow(i).Cells[6].Value, (string)dataGridDomicilios.Rows.SharedRow(i).Cells[0].Value,
                    (Localidad)dataGridDomicilios.Rows.SharedRow(i).Cells[7].Value);

                domicilios.Add(dom);
            }


            Usuario u = usr;

            Persona p = usr.GetPersona();

            p.SetDni(txtDni.Text);
            p.SetNombre(txtNombre.Text);
            p.SetApellido(txtApellido.Text);
            p.SetSexo(comboSexo.SelectedItem.ToString());
            p.SetFechaNacimiento(pickerFechaNacimiento.Value);

            p.SetDomicilios(domicilios);
            p.SetMails(mails);
            p.SetTelefonos(telefonos);

            u.SetPersona(p);
            u.SetPassword(txtClave.Text);
            u.SetRespuesta(txtRespuesta.Text);
            u.SetFkPregunta(comboPreguntas.SelectedIndex + 1);

            ControladorABMUsuario.modificarUsuario(u);
            

        }
    }
}
