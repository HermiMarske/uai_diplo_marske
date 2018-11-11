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

            SqlParameter[] pms = new SqlParameter[2];
            pms[0] = new SqlParameter("@razonSocial", SqlDbType.VarChar);
            pms[0].Value = txtRazonSocial.Text;

            pms[1] = new SqlParameter("@cuil", SqlDbType.VarChar);
            pms[1].Value = txtCuit.Text;

            dataConnection.databaseInsert(pms, "AltaCliente");

        }
    }
}
