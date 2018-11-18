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
        }

        private void tableLayoutPanelAltaCliente_Paint(object sender, PaintEventArgs e)
        {

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
       
        
        

        private void button5_Click(object sender, EventArgs e)
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

        

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
