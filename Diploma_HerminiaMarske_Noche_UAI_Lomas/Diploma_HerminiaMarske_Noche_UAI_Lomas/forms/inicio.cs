using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.forms;
using ConstantesData;
using System.Linq;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using System.Globalization;
using System.Threading;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Constantes;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas
{

    public partial class formInicio : Form
    {
        public static object fkPersonaModif;
        public static object idClienteModif;
        public static object idUsuarioModif;
        public static object idPilotoModif;
        public static object idActividad;

        public static object av;

        public static object idAvionModif;

        Idioma[] idiomas = {
            new Idioma("en", "english"),
            new Idioma("es-AR", "spanish")
        };
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
        CustomMessageBox messageBox = new CustomMessageBox();

        public static Usuario usuarioLogueado;

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
                string[] dataRow = { c.GetId().ToString(), c.GetPersona().GetIdPersona().ToString(), c.GetCuit(), c.GetRazonSocial(), c.GetPersona().GetNombre(), c.GetPersona().GetApellido(), c.GetPersona().GetDni()};
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
                object[] dataRow = { (int)dr[0], usuario, (string)dr[3], (string)dr[4], !(bool)dr[5]};
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
                object[] dataRow = { (int)dr[0], (string)dr[1], (string)dr[3], (string)dr[4] };
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
                object[] dataRow = { (int)dr[0], (DateTime)dr[1], (string)dr[2], (string)dr[3] };
                dataGridActividades.Rows.Add(dataRow);
            }

        }


        public void listarAviones()
        {
            dataGridAviones.Rows.Clear();

            List<Avion> aviones = ControladorABMAvion.getAviones();

            foreach (Avion av in aviones)
            {
                object[] dataRow = { av.GetId(), av.GetMatricula(), av.GetMarca(), av.GetModelo(), av.GetHabilitado()};
                dataGridAviones.Rows.Add(dataRow);
            }
        }


        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            formAltaCliente = new altaCliente();
            formAltaCliente.Show();
        }


        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAltaCliente = new altaCliente();
            formAltaCliente.Show();
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (dataGridClientes.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridClientes.SelectedCells[0].RowIndex;
                idClienteModif = dataGridClientes.Rows[rowIndex].Cells[0].Value;
                fkPersonaModif = dataGridClientes.Rows[rowIndex].Cells[1].Value;
                
                formModifCliente = new modificarCliente();
                formModifCliente.Show();
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dataGridClientes.SelectedCells.Count > 0)
            {
                DialogResult question = messageBox.Show(strings.confirm_delete, MessageBoxButtons.OKCancel);
                if (question == DialogResult.OK)
                {
                    try
                    {
                        int rowIndex = dataGridClientes.SelectedCells[0].RowIndex;
                        object idCliente = dataGridClientes.Rows[rowIndex].Cells[0].Value;
                        SqlParameter[] pms = new SqlParameter[1];

                        pms[0] = new SqlParameter("@idCliente", SqlDbType.Int);
                        pms[0].Value = idCliente.ToString();

                        string respuesta = dataConnection.databaseDelete(pms, SP.BORRAR_CLIENTE);

                        if (respuesta != null)
                        {
                            messageBox.Show(strings.client_deleted);
                        }

                        BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, ConstantesBitacora.CLIENTE_BORRADO, new Usuario());
                        ControladorBitacora.grabarRegistro(bitacora);

                    }
                    catch (Exception ex)
                    {
                        messageBox.ShowError(ex.Message.ToString());
                    }
                }
            }
        }

        /** FIN SOLAPA CLIENTES **/

        private bool hasPermission(string permission) => usuarioLogueado.GetPatentes().Where(p => !p.GetNegado()).ToList().Exists(p => p.GetDescripcion().Equals(ControladorEncriptacion.Encrypt(permission)));


        private void formInicio_Load(object sender, EventArgs e)
        {
            if (usuarioLogueado != null)
            {
                if (hasPermission("ADM_CLIENTES_VER"))
                    listarClientes();
                if (hasPermission("ADM_USUARIOS_VER"))
                    listarUsuarios();
                if (hasPermission("ADM_AVIONES_VER"))
                    listarAviones();
                if (hasPermission("ADM_PILOTOS_VER"))
                    listarPilotos();
                if (hasPermission("ADM_ACTIVIDADES_VER"))
                    listarActividades();
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

        private void initializer()
        {
            InitializeComponent();
            toolStripComboBox1.Items.AddRange(idiomas);
            toolStripComboBox1.AutoCompleteCustomSource.AddRange(idiomas.Select(i => i.GetDescripcion()).ToArray());

            Idioma select = toolStripComboBox1.Items.Cast<Idioma>().Where(i => i.GetCodigo().Equals(Thread.CurrentThread.CurrentUICulture.Name)).FirstOrDefault();
            toolStripComboBox1.SelectedItem = select ?? idiomas.Where(i => i.GetCodigo().Equals("es-AR")).First();
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;

            ((DataGridViewCheckBoxColumn)datagridUsuarios.Columns[4]).TrueValue = true;
            ((DataGridViewCheckBoxColumn)datagridUsuarios.Columns[4]).FalseValue = false;
        }

        public formInicio()
        {
            initializer();
        }

        public formInicio(Usuario usuario)
        {
            usuarioLogueado = usuario;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(usuario.GetIdioma());
            Controls.Clear();
            initializer();

            dataGridClientes.Enabled = hasPermission("ADM_CLIENTES_VER");
            btnNuevoCliente.Enabled = hasPermission("ADM_CLIENTES_ALTA");
            clienteToolStripMenuItem.Enabled = hasPermission("ADM_CLIENTES_ALTA");
            btnEliminarCliente.Enabled = hasPermission("ADM_CLIENTES_BAJA");
            btnModificarCliente.Enabled = hasPermission("ADM_CLIENTES_MODIF");

            datagridUsuarios.Enabled = hasPermission("ADM_USUARIOS_VER");
            btnAltaUsuario.Enabled = hasPermission("ADM_USUARIOS_ALTA");
            usuarioToolStripMenuItem.Enabled = hasPermission("ADM_USUARIOS_ALTA");
            btnEliminarUsuario.Enabled = hasPermission("ADM_USUARIOS_BAJA");
            btnModificarUsuario.Enabled = hasPermission("ADM_USUARIOS_MODIF");
            familiasYPermisosToolStripMenuItem.Enabled = hasPermission("ADM_USUARIOS_PERM");

            dataGridPilotos.Enabled = hasPermission("ADM_PILOTOS_VER");
            btnAltaPiloto.Enabled = hasPermission("ADM_PILOTOS_ALTA");
            pilotoToolStripMenuItem.Enabled = hasPermission("ADM_PILOTOS_ALTA");
            borrarPiloto.Enabled = hasPermission("ADM_PILOTOS_BAJA");
            btnModificarPiloto.Enabled = hasPermission("ADM_PILOTOS_MODIF");

            dataGridAviones.Enabled = hasPermission("ADM_AVIONES_VER");
            btnAddAvion.Enabled = hasPermission("ADM_AVIONES_ALTA");
            avionToolStripMenuItem.Enabled = hasPermission("ADM_AVIONES_ALTA");
            btnEliminarAvion.Enabled = hasPermission("ADM_AVIONES_BAJA");
            btnModificarAvion.Enabled = hasPermission("ADM_AVIONES_MODIF");

            dataGridActividades.Enabled = hasPermission("ADM_ACTIVIDADES_VER");
            btnAddActividad.Enabled = hasPermission("ADM_ACTIVIDADES_ALTA");
            actividadToolStripMenuItem.Enabled = hasPermission("ADM_ACTIVIDADES_ALTA");
            btnEliminarActividad.Enabled = hasPermission("ADM_ACTIVIDADES_BAJA");
            btnVerActividad.Enabled = hasPermission("ADM_ACTIVIDADES_VISUALIZAR");

            respaldosToolStripMenuItem.Enabled = hasPermission("ADM_SEGURIDAD_RESTORE");
            recalcularDigitosVerificadoresToolStripMenuItem.Enabled = hasPermission("ADM_SEGURIDAD_RECALCULAR_DV");
        }

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanelListaClientes.Show();
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

                object idUsuario = datagridUsuarios.Rows[rowIndex].Cells[0].Value;

                DialogResult question = messageBox.Show(strings.confirm_delete, MessageBoxButtons.OKCancel);
                if (question == DialogResult.OK)
                {
                    try
                    {
                        messageBox.Show(ControladorABMUsuario.borrarUsuario((int)idUsuario));
                    }
                    catch (Exception ex)
                    {
                        messageBox.ShowError(ex.Message.ToString());
                    }
                }
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

                modificarUsuario = new modificarUsuario();
                modificarUsuario.Show();
            }

        }

        private void btnModificarAvion_Click(object sender, EventArgs e)
        {
            if (dataGridAviones.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridAviones.SelectedCells[0].RowIndex;
                av = new Avion((int)dataGridAviones.Rows[rowIndex].Cells[0].Value, (string)dataGridAviones.Rows[rowIndex].Cells[1].Value, (string)dataGridAviones.Rows[rowIndex].Cells[2].Value, (string)dataGridAviones.Rows[rowIndex].Cells[3].Value, (bool)dataGridAviones.Rows[rowIndex].Cells[4].Value);

                modificarAvion = new modificarAvion();
                modificarAvion.Show();
            }
        }

        private void btnAddAvion_Click(object sender, EventArgs e)
        {
            altaAvion = new altaAvion();
            altaAvion.Show();
        }

        private void btnEliminarAvion_Click(object sender, EventArgs e)
        {
            if (dataGridAviones.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridAviones.SelectedCells[0].RowIndex;

                object idAvion = datagridUsuarios.Rows[rowIndex].Cells[0].Value;

                DialogResult question = messageBox.Show(strings.confirm_delete, MessageBoxButtons.OKCancel);
                if (question == DialogResult.OK)
                {
                    try
                    {
                        messageBox.Show(ControladorABMAvion.borrarAvion((int)idAvion));
                    }
                    catch (Exception ex)
                    {
                        messageBox.ShowError(ex.Message.ToString());
                    }
                }
            }
        }

        private void formInicio_Activated(object sender, EventArgs e)
        {
            if (usuarioLogueado != null)
            {
                if (hasPermission("ADM_CLIENTES_VER"))
                    listarClientes();
                if (hasPermission("ADM_USUARIOS_VER"))
                    listarUsuarios();
                if (hasPermission("ADM_AVIONES_VER"))
                    listarAviones();
                if (hasPermission("ADM_PILOTOS_VER"))
                    listarPilotos();
                if (hasPermission("ADM_ACTIVIDADES_VER"))
                    listarActividades();
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

        private void btnAltaPiloto_Click(object sender, EventArgs e)
        {
            altaPilotos = new altaPilotos();
            altaPilotos.Show();
        }

        private void btnModificarPiloto_Click(object sender, EventArgs e)
        {
            modificacionPiloto modificacionPiloto = new modificacionPiloto();
            modificacionPiloto.Show();
        }

        private void borrarPiloto_Click(object sender, EventArgs e)
        {
            if (dataGridPilotos.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridPilotos.SelectedCells[0].RowIndex;

                object idPiloto = dataGridPilotos.Rows[rowIndex].Cells[0].Value;

                DialogResult question = messageBox.Show(strings.confirm_delete, MessageBoxButtons.OKCancel);
                if (question == DialogResult.OK)
                {
                    try
                    {
                        messageBox.Show(ControladorABMPiloto.borrarPiloto((int)idPiloto));
                    }
                    catch (Exception ex)
                    {
                        messageBox.ShowError(ex.Message.ToString());
                    }
                }
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
            DialogResult question = messageBox.Show(strings.confirm_delete, MessageBoxButtons.OKCancel);
            if (question == DialogResult.OK)
            {
                try
                {
                    messageBox.Show(ControladorABMActividad.borrarActividad((int)idActividad));
                }
                catch (Exception ex)
                {
                    messageBox.ShowError(ex.Message.ToString());
                }
            }
        }

        private void btnVerActividad_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridActividades.SelectedCells[0].RowIndex;
            idActividad = dataGridActividades.Rows[rowIndex].Cells[0].Value;
            
            visualizarActividad visualizarActividad = new visualizarActividad();
            visualizarActividad.Show();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox comboBox = (ToolStripComboBox)sender;
            string codigoToolCombo = ((Idioma) comboBox.SelectedItem).GetCodigo();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(codigoToolCombo);
            comboBox.Owner.Hide();
            Controls.Clear();
            initializer();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult question = messageBox.Show(strings.confirm_exit, MessageBoxButtons.OKCancel);
            if (question == DialogResult.OK)
            {
                if (Application.MessageLoop)
                {
                    Application.Exit();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult question = messageBox.Show(strings.confirm_logout, MessageBoxButtons.OKCancel);
            if (question == DialogResult.OK)
            {
                Close();
            }
        }

        private void recalcularDigitosVerificadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.ProgressBar progressBar = new forms.ProgressBar();
            progressBar.ShowRecalculate();
        }

        private void respaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupDialog backupDialog = new BackupDialog();
            backupDialog.ShowDialog();
        }

        private void datagridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            if (view.SelectedCells.Count > 0)
            {
                if (view.SelectedCells[0].ColumnIndex == 4 && (bool)view.SelectedCells[0].Value)
                {
                    messageBox.Show(ControladorABMUsuario.desbloquearUsuario((int)view.Rows[view.SelectedCells[0].RowIndex].Cells[0].Value));
                }
                else
                {
                    view.SelectedCells[0].Value = false;
                }
            }
        }
    }
}
