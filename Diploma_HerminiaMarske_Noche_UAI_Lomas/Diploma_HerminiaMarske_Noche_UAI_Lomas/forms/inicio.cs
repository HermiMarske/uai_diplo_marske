﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.forms;
using ConstantesData;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas
{

    public partial class formInicio : Form
    {
        public static Object fkPersonaModif;
        public static Object idClienteModif;

        altaCliente formAltaCliente = new altaCliente();
        altaUsuario formAltaUsuario = new altaUsuario();
        modificarCliente formModifCliente = new modificarCliente();

        DataConnection.DataConnection dataConnection = new DataConnection.DataConnection();


        /** SOLAPA CLIENTES **/
        public void listarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            dataGridClientes.Rows.Clear();
            clientes.Clear();
            
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            dt = dataQuery.getList(SP.LISTAR_CLIENTES, null);

            foreach (DataRow dr in dt.Rows)
            {
                Persona persona = new Persona((int)dr[4], (string)dr[5], (string)dr[6], (string)dr[7], (string)dr[8]);
                Cliente cliente = new Cliente((int)dr[0], (string)dr[1], (string)dr[2], (string)dr[3], persona);
                clientes.Add(cliente);
            }

            foreach(Cliente c in clientes)
            {
                String[] dataRow = { c.GetId().ToString(), c.GetPersona().GetIdPersona().ToString(), c.GetCuit(), c.GetRazonSocial(), c.GetPersona().GetNombre(), c.GetPersona().GetApellido(), c.GetPersona().GetDni()};
                dataGridClientes.Rows.Add(dataRow);
            }
            
        }

        /** SOLAPA USUARIOS **/
        public void listarUsuarios()
        {
            
            datagridUsuarios.Rows.Clear();

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            dt = dataQuery.getList(SP.LISTAR_USUARIOS, null);

            foreach (DataRow dr in dt.Rows)
            {
                Object[] dataRow = { (Int32)dr[0], (string)dr[1],(string)dr[3], (string)dr[4]};
                datagridUsuarios.Rows.Add(dataRow);
            }

        }


        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            formAltaCliente.Show();
        }


        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {


            formAltaCliente.Show();

        }

        private void formInicio_Load(object sender, EventArgs e)
        {
            listarClientes();
            listarUsuarios();

        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (dataGridClientes.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridClientes.SelectedCells[0].RowIndex;
                idClienteModif = dataGridClientes.Rows[rowIndex].Cells[0].Value;
                fkPersonaModif = dataGridClientes.Rows[rowIndex].Cells[1].Value;
                try
                {
                    formModifCliente.Show();
                }
                catch
                {
                    modificarCliente formModifCliente = new modificarCliente();
                    formModifCliente.Show();
                }
                
               
            }
     
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dataGridClientes.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridClientes.SelectedCells[0].RowIndex;
                Object idCliente = dataGridClientes.Rows[rowIndex].Cells[0].Value;
                SqlParameter[] pms = new SqlParameter[1];

                pms[0] = new SqlParameter("@idCliente", SqlDbType.Int);
                pms[0].Value = idCliente.ToString();

                string respuesta = dataConnection.databaseDelete(pms, SP.BORRAR_CLIENTE);

                if (respuesta != null)
                {
                 
                    MessageBox.Show(respuesta);
                    listarClientes();
                }
            }
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


        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            formAltaUsuario = new altaUsuario();
            formAltaUsuario.Show();
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (datagridUsuarios.SelectedCells.Count > 0)
            {
                int rowIndex = datagridUsuarios.SelectedCells[0].RowIndex;
                Object idUsuario = datagridUsuarios.Rows[rowIndex].Cells[0].Value;
                SqlParameter[] pms = new SqlParameter[1];

                pms[0] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pms[0].Value = idUsuario.ToString();

                string respuesta = dataConnection.databaseDelete(pms, SP.BORRAR_USUARIO);

                if (respuesta != null)
                {
                    MessageBox.Show(respuesta);
                    listarClientes();
                }
            }
        }
    }
}
