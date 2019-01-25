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

        private void buttonAddTelefono_Click(object sender, EventArgs e)
        {
       
            addTelefonosToGrid(textBoxNumero.Text, comboTipoTelefono.SelectedItem.ToString());

        }

        private void addTelefonosToGrid(string numero, string tipo)
        {
            String[] dataRow = { numero, tipo };
            dataGridTelefonos.Rows.Add(dataRow);
        }

        private void buttonAddCliente_Click(object sender, EventArgs e)
        {

            DataConnection.DataConnection dataConnection = new DataConnection.DataConnection();

            SqlParameter[] pms = new SqlParameter[7];
            pms[0] = new SqlParameter("@razonSocial", SqlDbType.VarChar);
            pms[0].Value = txtRazonSocial.Text;

            pms[1] = new SqlParameter("@cuil", SqlDbType.VarChar);
            pms[1].Value = txtCuit.Text;

            pms[2] = new SqlParameter("@dni", SqlDbType.VarChar);
            pms[2].Value = txtDni.Text;

            pms[3] = new SqlParameter("@nombre", SqlDbType.VarChar);
            pms[3].Value = txtNombre.Text;

            pms[4] = new SqlParameter("@apellido", SqlDbType.VarChar);
            pms[4].Value = txtApellido.Text;

            pms[5] = new SqlParameter("@sexo", SqlDbType.VarChar);
            pms[5].Value = comboSexo.SelectedItem.ToString();

            pms[6] = new SqlParameter("@fechaNacimiento", SqlDbType.Date);
            pms[6].Value = pickerFechaNacimiento.Value;

            int fk = dataConnection.databaseInsert(pms, "AltaCliente");

            if (fk > 0)
            {
                SqlParameter[] pmsTelefono = new SqlParameter[3];

                for (int i =0 ; i < (dataGridTelefonos.Rows.Count)-1 ; i++)
                {

                    string telefono = (string)dataGridTelefonos.Rows.SharedRow(i).Cells[0].Value;
                    string tipo = (string)dataGridTelefonos.Rows.SharedRow(i).Cells[1].Value;

                    pmsTelefono[0] = new SqlParameter("@tipo", SqlDbType.VarChar);
                    pmsTelefono[0].Value = tipo;

                    pmsTelefono[1] = new SqlParameter("@numero", SqlDbType.VarChar);
                    pmsTelefono[1].Value = telefono;

                    pmsTelefono[2] = new SqlParameter("@fk_persona", SqlDbType.Int);
                    pmsTelefono[2].Value = fk;

                    dataConnection.databaseInsertAditionalData(pmsTelefono, "AltaTelefono");
                    
                }
         
                /*
                 * for (int i; i < addresses.length; i++) {
                 *   SqlParameter[] addresses = new SqlParameter[X]
                 *   pms[0] = new SqlParameter("@field", SqlDbType.FieldType);
                 *   pms[0].Value = txtField.Text;
                 *   ...
                 *   dataConnection.insertAddress(addresses, fk, "AltaClienteDireccion");
                 * }
                 * 
                */

            }

        }

        private void altaCliente_Load(object sender, EventArgs e)
        {

            List<Pais> paises = new List<Pais>();
            //LLenado de combo de paises
            DataConnection.DataConnection dataConnection = new DataConnection.DataConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da = dataConnection.getList("ListarPaises");
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Pais pais = new Pais((int) dr[0], (string) dr[1]);
                paises.Add(pais);
            }
            comboPais.DataSource = paises;

        }

        private void comboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            List<Provincia> provincias = new List<Provincia>();
            DataConnection.DataConnection dataConnection = new DataConnection.DataConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            Pais p = new Pais();
            p = (Pais)this.comboPais.SelectedItem;
            SqlParameter[] fkPais = new SqlParameter[1];
            fkPais[0] = new SqlParameter("@pais", SqlDbType.Int);
            fkPais[0].Value = p.GetId();

            da = dataConnection.getListParams("ListarProvincias", fkPais);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Provincia provincia = new Provincia((int)dr[0], (string)dr[1]);
                provincias.Add(provincia);
            }
            comboProvincias.DataSource = provincias;
        }
    }
}
