using System.Windows.Forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas
{
    partial class formInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formInicio));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pilotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actividadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familiasYPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.passwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.respaldosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabUsuarios = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelListaClientes = new System.Windows.Forms.TableLayoutPanel();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridClientes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.datagridUsuarios = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desbloquear = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.btnAltaUsuario = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnModificarPiloto = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridPilotos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrarPiloto = new System.Windows.Forms.Button();
            this.btnAltaPiloto = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnModificarAvion = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridAviones = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarAvion = new System.Windows.Forms.Button();
            this.btnAddAvion = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridActividades = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddActividad = new System.Windows.Forms.Button();
            this.btnEliminarActividad = new System.Windows.Forms.Button();
            this.btnVerActividad = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabUsuarios.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanelListaClientes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClientes)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridUsuarios)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPilotos)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAviones)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividades)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionToolStripMenuItem,
            this.seguridadToolStripMenuItem,
            this.opcionesToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripItem,
            this.toolStripSeparator1,
            this.cerrarSesionToolStripMenuItem,
            this.toolStripSeparator2,
            this.salirToolStripMenuItem});
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            resources.ApplyResources(this.gestionToolStripMenuItem, "gestionToolStripMenuItem");
            // 
            // nuevoToolStripItem
            // 
            this.nuevoToolStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.usuarioToolStripMenuItem,
            this.pilotoToolStripMenuItem,
            this.avionToolStripMenuItem,
            this.actividadToolStripMenuItem});
            this.nuevoToolStripItem.Name = "nuevoToolStripItem";
            resources.ApplyResources(this.nuevoToolStripItem, "nuevoToolStripItem");
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            resources.ApplyResources(this.clienteToolStripMenuItem, "clienteToolStripMenuItem");
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            resources.ApplyResources(this.usuarioToolStripMenuItem, "usuarioToolStripMenuItem");
            // 
            // pilotoToolStripMenuItem
            // 
            this.pilotoToolStripMenuItem.Name = "pilotoToolStripMenuItem";
            resources.ApplyResources(this.pilotoToolStripMenuItem, "pilotoToolStripMenuItem");
            // 
            // avionToolStripMenuItem
            // 
            this.avionToolStripMenuItem.Name = "avionToolStripMenuItem";
            resources.ApplyResources(this.avionToolStripMenuItem, "avionToolStripMenuItem");
            // 
            // actividadToolStripMenuItem
            // 
            this.actividadToolStripMenuItem.Name = "actividadToolStripMenuItem";
            resources.ApplyResources(this.actividadToolStripMenuItem, "actividadToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            resources.ApplyResources(this.cerrarSesionToolStripMenuItem, "cerrarSesionToolStripMenuItem");
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.familiasYPermisosToolStripMenuItem,
            this.bitacoraToolStripMenuItem,
            this.toolStripMenuItem2,
            this.passwordToolStripMenuItem,
            this.toolStripSeparator3,
            this.respaldosToolStripMenuItem});
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            resources.ApplyResources(this.seguridadToolStripMenuItem, "seguridadToolStripMenuItem");
            // 
            // familiasYPermisosToolStripMenuItem
            // 
            this.familiasYPermisosToolStripMenuItem.Name = "familiasYPermisosToolStripMenuItem";
            resources.ApplyResources(this.familiasYPermisosToolStripMenuItem, "familiasYPermisosToolStripMenuItem");
            this.familiasYPermisosToolStripMenuItem.Click += new System.EventHandler(this.familiasYPermisosToolStripMenuItem_Click);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            resources.ApplyResources(this.bitacoraToolStripMenuItem, "bitacoraToolStripMenuItem");
            this.bitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // passwordToolStripMenuItem
            // 
            this.passwordToolStripMenuItem.Name = "passwordToolStripMenuItem";
            resources.ApplyResources(this.passwordToolStripMenuItem, "passwordToolStripMenuItem");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // respaldosToolStripMenuItem
            // 
            this.respaldosToolStripMenuItem.Name = "respaldosToolStripMenuItem";
            resources.ApplyResources(this.respaldosToolStripMenuItem, "respaldosToolStripMenuItem");
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarIdiomaToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            resources.ApplyResources(this.opcionesToolStripMenuItem, "opcionesToolStripMenuItem");
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            this.cambiarIdiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            resources.ApplyResources(this.cambiarIdiomaToolStripMenuItem, "cambiarIdiomaToolStripMenuItem");
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            resources.ApplyResources(this.toolStripComboBox1, "toolStripComboBox1");
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.tabUsuarios);
            this.panel1.Name = "panel1";
            // 
            // tabUsuarios
            // 
            this.tabUsuarios.Controls.Add(this.tabPage1);
            this.tabUsuarios.Controls.Add(this.tabPage2);
            this.tabUsuarios.Controls.Add(this.tabPage3);
            this.tabUsuarios.Controls.Add(this.tabPage4);
            this.tabUsuarios.Controls.Add(this.tabPage5);
            resources.ApplyResources(this.tabUsuarios, "tabUsuarios");
            this.tabUsuarios.Name = "tabUsuarios";
            this.tabUsuarios.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanelListaClientes);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelListaClientes
            // 
            resources.ApplyResources(this.tableLayoutPanelListaClientes, "tableLayoutPanelListaClientes");
            this.tableLayoutPanelListaClientes.Controls.Add(this.btnModificarCliente, 0, 1);
            this.tableLayoutPanelListaClientes.Controls.Add(this.btnNuevoCliente, 0, 1);
            this.tableLayoutPanelListaClientes.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanelListaClientes.Controls.Add(this.btnEliminarCliente, 2, 1);
            this.tableLayoutPanelListaClientes.Name = "tableLayoutPanelListaClientes";
            // 
            // btnModificarCliente
            // 
            resources.ApplyResources(this.btnModificarCliente, "btnModificarCliente");
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.UseVisualStyleBackColor = true;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // btnNuevoCliente
            // 
            resources.ApplyResources(this.btnNuevoCliente, "btnNuevoCliente");
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // groupBox1
            // 
            this.tableLayoutPanelListaClientes.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.dataGridClientes);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dataGridClientes
            // 
            this.dataGridClientes.AllowUserToAddRows = false;
            this.dataGridClientes.AllowUserToDeleteRows = false;
            this.dataGridClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fkPersona,
            this.cuit,
            this.razonSocial,
            this.nombre,
            this.apellido,
            this.dni});
            resources.ApplyResources(this.dataGridClientes, "dataGridClientes");
            this.dataGridClientes.Name = "dataGridClientes";
            this.dataGridClientes.ReadOnly = true;
            this.dataGridClientes.RowTemplate.Height = 24;
            // 
            // id
            // 
            resources.ApplyResources(this.id, "id");
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // fkPersona
            // 
            resources.ApplyResources(this.fkPersona, "fkPersona");
            this.fkPersona.Name = "fkPersona";
            this.fkPersona.ReadOnly = true;
            // 
            // cuit
            // 
            resources.ApplyResources(this.cuit, "cuit");
            this.cuit.Name = "cuit";
            this.cuit.ReadOnly = true;
            // 
            // razonSocial
            // 
            resources.ApplyResources(this.razonSocial, "razonSocial");
            this.razonSocial.Name = "razonSocial";
            this.razonSocial.ReadOnly = true;
            // 
            // nombre
            // 
            resources.ApplyResources(this.nombre, "nombre");
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido
            // 
            resources.ApplyResources(this.apellido, "apellido");
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // dni
            // 
            resources.ApplyResources(this.dni, "dni");
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            // 
            // btnEliminarCliente
            // 
            resources.ApplyResources(this.btnEliminarCliente, "btnEliminarCliente");
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.UseVisualStyleBackColor = true;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminarUsuario, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnModificarUsuario, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAltaUsuario, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 3);
            this.groupBox2.Controls.Add(this.datagridUsuarios);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // datagridUsuarios
            // 
            this.datagridUsuarios.AllowUserToAddRows = false;
            this.datagridUsuarios.AllowUserToDeleteRows = false;
            this.datagridUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.usuario,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Desbloquear});
            resources.ApplyResources(this.datagridUsuarios, "datagridUsuarios");
            this.datagridUsuarios.Name = "datagridUsuarios";
            this.datagridUsuarios.ReadOnly = true;
            this.datagridUsuarios.RowTemplate.Height = 24;
            // 
            // dataGridViewTextBoxColumn1
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // usuario
            // 
            resources.ApplyResources(this.usuario, "usuario");
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Desbloquear
            // 
            resources.ApplyResources(this.Desbloquear, "Desbloquear");
            this.Desbloquear.Name = "Desbloquear";
            this.Desbloquear.ReadOnly = true;
            // 
            // btnEliminarUsuario
            // 
            resources.ApplyResources(this.btnEliminarUsuario, "btnEliminarUsuario");
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // btnModificarUsuario
            // 
            resources.ApplyResources(this.btnModificarUsuario, "btnModificarUsuario");
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);
            // 
            // btnAltaUsuario
            // 
            resources.ApplyResources(this.btnAltaUsuario, "btnAltaUsuario");
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.UseVisualStyleBackColor = true;
            this.btnAltaUsuario.Click += new System.EventHandler(this.btnAltaUsuario_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel3);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.btnModificarPiloto, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.borrarPiloto, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnAltaPiloto, 0, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // btnModificarPiloto
            // 
            resources.ApplyResources(this.btnModificarPiloto, "btnModificarPiloto");
            this.btnModificarPiloto.Name = "btnModificarPiloto";
            this.btnModificarPiloto.UseVisualStyleBackColor = true;
            this.btnModificarPiloto.Click += new System.EventHandler(this.btnModificarPiloto_Click);
            // 
            // groupBox4
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.groupBox4, 3);
            this.groupBox4.Controls.Add(this.dataGridPilotos);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // dataGridPilotos
            // 
            this.dataGridPilotos.AllowUserToAddRows = false;
            this.dataGridPilotos.AllowUserToDeleteRows = false;
            this.dataGridPilotos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPilotos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPilotos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            resources.ApplyResources(this.dataGridPilotos, "dataGridPilotos");
            this.dataGridPilotos.Name = "dataGridPilotos";
            this.dataGridPilotos.ReadOnly = true;
            this.dataGridPilotos.RowTemplate.Height = 24;
            // 
            // dataGridViewTextBoxColumn8
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // borrarPiloto
            // 
            resources.ApplyResources(this.borrarPiloto, "borrarPiloto");
            this.borrarPiloto.Name = "borrarPiloto";
            this.borrarPiloto.UseVisualStyleBackColor = true;
            this.borrarPiloto.Click += new System.EventHandler(this.borrarPiloto_Click);
            // 
            // btnAltaPiloto
            // 
            resources.ApplyResources(this.btnAltaPiloto, "btnAltaPiloto");
            this.btnAltaPiloto.Name = "btnAltaPiloto";
            this.btnAltaPiloto.UseVisualStyleBackColor = true;
            this.btnAltaPiloto.Click += new System.EventHandler(this.btnAltaPiloto_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.btnModificarAvion, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEliminarAvion, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnAddAvion, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // btnModificarAvion
            // 
            resources.ApplyResources(this.btnModificarAvion, "btnModificarAvion");
            this.btnModificarAvion.Name = "btnModificarAvion";
            this.btnModificarAvion.UseVisualStyleBackColor = true;
            this.btnModificarAvion.Click += new System.EventHandler(this.btnModificarAvion_Click);
            // 
            // groupBox3
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox3, 3);
            this.groupBox3.Controls.Add(this.dataGridAviones);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // dataGridAviones
            // 
            this.dataGridAviones.AllowUserToAddRows = false;
            this.dataGridAviones.AllowUserToDeleteRows = false;
            this.dataGridAviones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAviones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAviones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Habilitado});
            resources.ApplyResources(this.dataGridAviones, "dataGridAviones");
            this.dataGridAviones.Name = "dataGridAviones";
            this.dataGridAviones.ReadOnly = true;
            this.dataGridAviones.RowTemplate.Height = 24;
            // 
            // dataGridViewTextBoxColumn2
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // Habilitado
            // 
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            // 
            // btnEliminarAvion
            // 
            resources.ApplyResources(this.btnEliminarAvion, "btnEliminarAvion");
            this.btnEliminarAvion.Name = "btnEliminarAvion";
            this.btnEliminarAvion.UseVisualStyleBackColor = true;
            this.btnEliminarAvion.Click += new System.EventHandler(this.btnEliminarAvion_Click);
            // 
            // btnAddAvion
            // 
            resources.ApplyResources(this.btnAddAvion, "btnAddAvion");
            this.btnAddAvion.Name = "btnAddAvion";
            this.btnAddAvion.UseVisualStyleBackColor = true;
            this.btnAddAvion.Click += new System.EventHandler(this.btnAddAvion_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tableLayoutPanel4);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.groupBox5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnAddActividad, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnEliminarActividad, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnVerActividad, 1, 1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // groupBox5
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.groupBox5, 3);
            this.groupBox5.Controls.Add(this.dataGridActividades);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // dataGridActividades
            // 
            this.dataGridActividades.AllowUserToAddRows = false;
            this.dataGridActividades.AllowUserToDeleteRows = false;
            this.dataGridActividades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridActividades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15});
            resources.ApplyResources(this.dataGridActividades, "dataGridActividades");
            this.dataGridActividades.Name = "dataGridActividades";
            this.dataGridActividades.ReadOnly = true;
            this.dataGridActividades.RowTemplate.Height = 24;
            // 
            // dataGridViewTextBoxColumn12
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn15, "dataGridViewTextBoxColumn15");
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // btnAddActividad
            // 
            resources.ApplyResources(this.btnAddActividad, "btnAddActividad");
            this.btnAddActividad.Name = "btnAddActividad";
            this.btnAddActividad.UseVisualStyleBackColor = true;
            this.btnAddActividad.Click += new System.EventHandler(this.btnAddActividad_Click);
            // 
            // btnEliminarActividad
            // 
            resources.ApplyResources(this.btnEliminarActividad, "btnEliminarActividad");
            this.btnEliminarActividad.Name = "btnEliminarActividad";
            this.btnEliminarActividad.UseVisualStyleBackColor = true;
            this.btnEliminarActividad.Click += new System.EventHandler(this.btnEliminarActividad_Click);
            // 
            // btnVerActividad
            // 
            resources.ApplyResources(this.btnVerActividad, "btnVerActividad");
            this.btnVerActividad.Name = "btnVerActividad";
            this.btnVerActividad.UseVisualStyleBackColor = true;
            this.btnVerActividad.Click += new System.EventHandler(this.btnVerActividad_Click);
            // 
            // formInicio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties.Resources.Airplane_Landing;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formInicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.formInicio_Activated);
            this.Load += new System.EventHandler(this.formInicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabUsuarios.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanelListaClientes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClientes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridUsuarios)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPilotos)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAviones)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabUsuarios;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelListaClientes;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.Button btnModificarCliente;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridClientes;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Button btnAltaUsuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView datagridUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.ToolStripMenuItem familiasYPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button borrarPiloto;
        private System.Windows.Forms.Button btnModificarPiloto;
        private System.Windows.Forms.Button btnAltaPiloto;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridPilotos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnEliminarAvion;
        private System.Windows.Forms.Button btnModificarAvion;
        private System.Windows.Forms.Button btnAddAvion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridAviones;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnVerActividad;
        private System.Windows.Forms.Button btnEliminarActividad;
        private System.Windows.Forms.Button btnAddActividad;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridActividades;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Habilitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private DataGridViewCheckBoxColumn Desbloquear;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem pilotoToolStripMenuItem;
        private ToolStripMenuItem avionToolStripMenuItem;
        private ToolStripMenuItem actividadToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem passwordToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem respaldosToolStripMenuItem;
    }
}

