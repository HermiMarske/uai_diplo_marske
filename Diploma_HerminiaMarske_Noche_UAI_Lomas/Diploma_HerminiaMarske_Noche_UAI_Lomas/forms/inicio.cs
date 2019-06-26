using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.forms;
using ConstantesData;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using System.Globalization;
using System.Threading;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas
{

    public partial class formInicio : Form
    {
        public static Object fkPersonaModif;
        public static Object idClienteModif;
        public static Object idUsuarioModif;
        public static Object idPilotoModif;
        public static Object idActividad;

        public static Object av;

        public static Object idAvionModif;

        altaCliente formAltaCliente = new altaCliente();
        altaUsuario formAltaUsuario = new altaUsuario();
        bitacora formBitacora = new bitacora();
        altaFamilia formFamilias = new altaFamilia();
        modificarCliente formModifCliente = new modificarCliente();
        modificarUsuario modificarUsuario = new modificarUsuario();
        modificarAvion modificarAvion = new modificarAvion();
        altaAvion altaAvion = new altaAvion();
        altaPilotos altaPilotos = new altaPilotos();
        modificacionPiloto modificacionPiloto = new modificacionPiloto();
        altaActividad altaActividad = new altaActividad();
        visualizarActividad visualizarActividad = new visualizarActividad();

        private Usuario usuarioLogueado;

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
                string usuario = ControladorEncriptacion.Decrypt((string)dr[1]);
                Object[] dataRow = { (Int32)dr[0], usuario, (string)dr[3], (string)dr[4]};
                datagridUsuarios.Rows.Add(dataRow);
            }

        }

        /** SOLAPA PILOTOS **/
        public void listarPilotos()
        {
            dataGridPilotos.Rows.Clear();

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            dt = dataQuery.getList(SP.LISTAR_PILOTOS, null);

            foreach (DataRow dr in dt.Rows)
            {
                Object[] dataRow = { (Int32)dr[0], (string)dr[1], (string)dr[3], (string)dr[4] };
                dataGridPilotos.Rows.Add(dataRow);
            }

        }


        /** SOLAPA PILOTOS **/
        public void listarActividades()
        {
            dataGridActividades.Rows.Clear();

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            dt = dataQuery.getList(SP.LISTAR_ACTIVIDADES, null);

            foreach (DataRow dr in dt.Rows)
            {
                Object[] dataRow = { (Int32)dr[0], (DateTime)dr[1], (string)dr[2], (string)dr[3] };
                dataGridActividades.Rows.Add(dataRow);
            }

        }


        public void listarAviones()
        {

            dataGridAviones.Rows.Clear();

            List<Avion> aviones = ControladorABMAvion.getAviones();

            foreach (Avion av in aviones)
            {
                
                Object[] dataRow = { av.GetId(), av.GetMatricula(), av.GetMarca(), av.GetModelo(), av.GetHabilitado()};
                dataGridAviones.Rows.Add(dataRow);
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

        private bool hasPermission(string permission) => usuarioLogueado.GetPatentes().Exists(p => p.GetDescripcion().Equals(permission) && !p.GetNegado());


        private void formInicio_Load(object sender, EventArgs e)
        {
            if (usuarioLogueado != null)
            {
                if (hasPermission("ADM_CLIENTES_VER"))
                    listarClientes();
                if (hasPermission("ADM_USUARIOS_VER"))
                    listarUsuarios();

            }
            else
            {
                listarClientes();
                listarUsuarios();
                listarAviones();
                listarPilotos();
                listarActividades();
            }
        }

        public formInicio()
        {
            InitializeComponent();
        }

        public formInicio(Usuario usuario)
        {
            usuarioLogueado = usuario;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(usuario.GetIdioma());
            Controls.Clear();
            InitializeComponent();

            btnNuevoCliente.Enabled = hasPermission("ADM_CLIENTES_ALTA");
            btnVerCliente.Enabled = hasPermission("ADM_CLIENTES_VER");
            dataGridClientes.Enabled = hasPermission("ADM_CLIENTES_VER");
            btnEliminarCliente.Enabled = hasPermission("ADM_CLIENTES_BAJA");
            btnModificarCliente.Enabled = hasPermission("ADM_CLIENTES_MODIF");

            datagridUsuarios.Enabled = hasPermission("ADM_USUARIOS_VER");
            btnDetalleUsuario.Enabled = hasPermission("ADM_USUARIOS_VER");
            btnAltaUsuario.Enabled = hasPermission("ADM_USUARIOS_ALTA");
            btnEliminarUsuario.Enabled = hasPermission("ADM_USUARIOS_BAJA");
            btnModificarUsuario.Enabled = hasPermission("ADM_USUARIOS_MODIF");
            familiasYPermisosToolStripMenuItem.Enabled = hasPermission("ADM_USUARIOS_PERM");
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

                string respuesta = ControladorABMUsuario.borrarUsuario((int)idUsuario);

                MessageBox.Show(respuesta);

            }
        }

        private void familiasYPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFamilias = new altaFamilia();
            formFamilias.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formBitacora = new bitacora();
            formBitacora.Show();

        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {

            if (datagridUsuarios.SelectedCells.Count > 0)
            {
                int rowIndex = datagridUsuarios.SelectedCells[0].RowIndex;
                idUsuarioModif = datagridUsuarios.Rows[rowIndex].Cells[0].Value;
             
                try
                {
                    modificarUsuario.Show();
                }
                catch
                {
                    modificarUsuario modificarUsuario = new modificarUsuario();
                    modificarUsuario.Show();
                }


            }

        }

        private void btnModificarAvion_Click(object sender, EventArgs e)
        {
            if (dataGridAviones.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridAviones.SelectedCells[0].RowIndex;
                av = new Avion((int)dataGridAviones.Rows[rowIndex].Cells[0].Value, (string)dataGridAviones.Rows[rowIndex].Cells[1].Value, (string)dataGridAviones.Rows[rowIndex].Cells[2].Value, (string)dataGridAviones.Rows[rowIndex].Cells[3].Value, (bool)dataGridAviones.Rows[rowIndex].Cells[4].Value);

                try
                {
                    modificarAvion.Show();
                }
                catch
                {
                    modificarAvion modificarAvion = new modificarAvion();
                    modificarAvion.Show();
                }


            }
        }

        private void btnAddAvion_Click(object sender, EventArgs e)
        {
            try
            {
                altaAvion.Show();
            } 
            catch
            {
                altaAvion = new altaAvion();
                altaAvion.Show();
            }
        }

        private void btnEliminarAvion_Click(object sender, EventArgs e)
        {
            if (dataGridAviones.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridAviones.SelectedCells[0].RowIndex;

                Object idAvion = datagridUsuarios.Rows[rowIndex].Cells[0].Value;

                string respuesta = ControladorABMAvion.borrarAvion((int)idAvion);

                MessageBox.Show(respuesta);

            }
        }

        private void btnAltaPiloto_Click(object sender, EventArgs e)
        {
            try
            {
                altaPilotos.Show();
            }
            catch
            {
                altaPilotos = new altaPilotos();
                altaPilotos.Show();
            }
        }

        private void btnModificarPiloto_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridPilotos.SelectedCells[0].RowIndex;
            idPilotoModif = dataGridPilotos.Rows[rowIndex].Cells[0].Value;

            try
            {
                modificacionPiloto.Show();
            }
            catch
            {
                modificacionPiloto modificacionPiloto = new modificacionPiloto();
                modificacionPiloto.Show();
            }
        }

        private void borrarPiloto_Click(object sender, EventArgs e)
        {

            if (dataGridPilotos.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridPilotos.SelectedCells[0].RowIndex;

                Object idPiloto = dataGridPilotos.Rows[rowIndex].Cells[0].Value;

                string respuesta = ControladorABMPiloto.borrarPiloto((int)idPiloto);

                MessageBox.Show(respuesta);

            }

        }

        private void btnAddActividad_Click(object sender, EventArgs e)
        {
            try
            {
                altaActividad.Show();
            }
            catch
            {
                altaActividad altaActividad = new altaActividad();
                altaActividad.Show();
            }
        }

        private void btnEliminarActividad_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridActividades.SelectedCells[0].RowIndex;

            idActividad = dataGridActividades.Rows[rowIndex].Cells[0].Value;
            string rta = ControladorABMActividad.borrarActividad((int)idActividad);

            MessageBox.Show(rta);
        }

        private void btnVerActividad_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridActividades.SelectedCells[0].RowIndex;
            idActividad = dataGridActividades.Rows[rowIndex].Cells[0].Value;

            try
            {
                visualizarActividad.Show();
            }
            catch
            {
                visualizarActividad visualizarActividad = new visualizarActividad();
                visualizarActividad.Show();
            }
        }
    }
}
