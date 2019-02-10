using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using DataConnection;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;



namespace Diploma_HerminiaMarske_Noche_UAI_Lomas
{
    public partial class altaCliente : Form
    {
        public altaCliente()
        {
            InitializeComponent();
            dataGridDomicilios.Columns[0].Name = "Numero";
            dataGridDomicilios.Columns[1].Name = "Tipo";
         
        }

        private void tableLayoutPanelAltaCliente_Paint(object sender, PaintEventArgs e)
        {

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        List<Domicilio> domicilios = new List<Domicilio>();
        List<Telefono> telefonos = new List<Telefono>();

        private void buttonAddTelefono_Click(object sender, EventArgs e)
        {
            Telefono tel = new Telefono();
            tel.SetNumero(textBoxNumero.Text);
            tel.SetTipo(comboTipoTelefono.SelectedItem.ToString());

            String[] dataRow = { tel.GetNumero(), tel.GetTipo()};
            dataGridTelefonos.Rows.Add(dataRow);
        }

        private void addTelefonosToGrid(string numero, string tipo)
        {
            String[] dataRow = { numero, tipo };
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

            int fk = dataConnection.databaseInsert(pms, "AltaCliente");

            if (fk > 0)
            {
                SqlParameter[] pmsTelefono = new SqlParameter[3];
                SqlParameter[] pmsDomicilio = new SqlParameter[9];

                for (int i =0 ; i < (dataGridTelefonos.Rows.Count)-1 ; i++)
                {
                    Telefono t = new Telefono();

                    t.SetNumero((string)dataGridTelefonos.Rows.SharedRow(i).Cells[0].Value);
                    t.SetTipo((string)dataGridTelefonos.Rows.SharedRow(i).Cells[1].Value);
                    telefonos.Add(t);

                    //string telefono = (string)dataGridTelefonos.Rows.SharedRow(i).Cells[0].Value;
                    //string tipo = (string)dataGridTelefonos.Rows.SharedRow(i).Cells[1].Value;

                    pmsTelefono[0] = new SqlParameter("@tipo", SqlDbType.VarChar);
                    pmsTelefono[0].Value = t.GetTipo();

                    pmsTelefono[1] = new SqlParameter("@numero", SqlDbType.VarChar);
                    pmsTelefono[1].Value = t.GetNumero();

                    pmsTelefono[2] = new SqlParameter("@fk_persona", SqlDbType.Int);
                    pmsTelefono[2].Value = fk;

                    dataConnection.databaseInsertAditionalData(pmsTelefono, "AltaTelefono");
                    
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

                    dataConnection.databaseInsertAditionalData(pmsDomicilio, "AltaDomicilio");

                }
         
            }

        }

        private void altaCliente_Load(object sender, EventArgs e)
        {
            //Llenado de combo de paises
            List<Pais> paises = new List<Pais>();
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da = dataQuery.getList("ListarPaises", null);
            da.Fill(dt);
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
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlParameter[] pmsProvincias = new SqlParameter[1];
            pmsProvincias[0] = new SqlParameter("@pais", SqlDbType.Int);
            pmsProvincias[0].Value = pais.GetId();
            da = dataQuery.getList("ListarProvincias", pmsProvincias);
            da.Fill(dt);
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

            Object[] dataRow = {dom.GetTipoDomicilio(), dom.GetComentario(), dom.GetCalle(), dom.GetNumero(), dom.GetPiso(), dom.GetDpto(), dom.GetCodigoPostal(), dom.GetLocalidad() };
            dataGridDomicilios.Rows.Add(dataRow);
          
        }
    }
}
