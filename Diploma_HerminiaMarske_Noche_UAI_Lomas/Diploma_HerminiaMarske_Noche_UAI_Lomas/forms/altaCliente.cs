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

            SqlParameter[] pms = new SqlParameter[6];
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

    
    }
}
