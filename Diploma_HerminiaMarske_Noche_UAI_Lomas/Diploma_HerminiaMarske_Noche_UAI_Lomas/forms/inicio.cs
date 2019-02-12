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

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas
{
    public partial class formInicio : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        altaCliente formAltaCliente = new altaCliente();

       
        /** SOLAPA CLIENTES **/
        private void listarClientes()
        {

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da = dataQuery.getList("ListarClientes", null);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Persona persona = new Persona((int)dr[4], (string)dr[5], (string)dr[6], (string)dr[7], (string)dr[8]);
                Cliente cliente = new Cliente((int)dr[0], (string)dr[1], (string)dr[2], (string)dr[3], persona);
                clientes.Add(cliente);
            }


            dataGridClientes.DataSource = clientes;

        }
        

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            formAltaCliente.Show();
        }
        /** FIN SOLAPA CLIENTES **/

        public formInicio()
        {
            InitializeComponent();
        }

        private void actividadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void groupAltaCliente_Enter(object sender, EventArgs e)
        {

        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {


            formAltaCliente.Show();

        }

        private void formInicio_Load(object sender, EventArgs e)
        {
            listarClientes();

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanelListaClientes.Show();
        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
