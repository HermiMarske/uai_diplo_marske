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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actividadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pilotosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actividadesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.busquedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanelListaClientes = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uAI_GESTION_AGUILADataSet = new Diploma_HerminiaMarske_Noche_UAI_Lomas.UAI_GESTION_AGUILADataSet();
            this.uAIGESTIONAGUILADataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientesTableAdapter = new Diploma_HerminiaMarske_Noche_UAI_Lomas.UAI_GESTION_AGUILADataSetTableAdapters.ClientesTableAdapter();
            this.clientesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.personasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personasTableAdapter = new Diploma_HerminiaMarske_Noche_UAI_Lomas.UAI_GESTION_AGUILADataSetTableAdapters.PersonasTableAdapter();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelListaClientes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAI_GESTION_AGUILADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAIGESTIONAGUILADataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionToolStripMenuItem,
            this.seguridadToolStripMenuItem,
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1304, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actividadesToolStripMenuItem,
            this.pilotosToolStripMenuItem,
            this.actividadesToolStripMenuItem1,
            this.clientesToolStripMenuItem});
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            this.gestionToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.gestionToolStripMenuItem.Text = "Gestion";
            // 
            // actividadesToolStripMenuItem
            // 
            this.actividadesToolStripMenuItem.Name = "actividadesToolStripMenuItem";
            this.actividadesToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.actividadesToolStripMenuItem.Text = "Actividades";
            // 
            // pilotosToolStripMenuItem
            // 
            this.pilotosToolStripMenuItem.Name = "pilotosToolStripMenuItem";
            this.pilotosToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.pilotosToolStripMenuItem.Text = "Pilotos";
            // 
            // actividadesToolStripMenuItem1
            // 
            this.actividadesToolStripMenuItem1.Name = "actividadesToolStripMenuItem1";
            this.actividadesToolStripMenuItem1.Size = new System.Drawing.Size(161, 26);
            this.actividadesToolStripMenuItem1.Text = "Aviones";
            this.actividadesToolStripMenuItem1.Click += new System.EventHandler(this.actividadesToolStripMenuItem1_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.busquedaToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // nuevoClienteToolStripMenuItem
            // 
            this.nuevoClienteToolStripMenuItem.Name = "nuevoClienteToolStripMenuItem";
            this.nuevoClienteToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.nuevoClienteToolStripMenuItem.Text = "Nuevo Cliente";
            this.nuevoClienteToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
            // 
            // busquedaToolStripMenuItem
            // 
            this.busquedaToolStripMenuItem.Name = "busquedaToolStripMenuItem";
            this.busquedaToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.busquedaToolStripMenuItem.Text = "Lista de Clientes";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(188, 6);
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.seguridadToolStripMenuItem.Text = "Seguridad";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 684);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1304, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanelListaClientes
            // 
            this.tableLayoutPanelListaClientes.AutoSize = true;
            this.tableLayoutPanelListaClientes.ColumnCount = 5;
            this.tableLayoutPanelListaClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelListaClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelListaClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelListaClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelListaClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelListaClientes.Controls.Add(this.button5, 0, 1);
            this.tableLayoutPanelListaClientes.Controls.Add(this.button4, 0, 1);
            this.tableLayoutPanelListaClientes.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanelListaClientes.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanelListaClientes.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanelListaClientes.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanelListaClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelListaClientes.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanelListaClientes.Name = "tableLayoutPanelListaClientes";
            this.tableLayoutPanelListaClientes.RowCount = 2;
            this.tableLayoutPanelListaClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelListaClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanelListaClientes.Size = new System.Drawing.Size(1304, 656);
            this.tableLayoutPanelListaClientes.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.tableLayoutPanelListaClientes.SetColumnSpan(this.groupBox1, 5);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1298, 577);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Clientes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1292, 556);
            this.dataGridView1.TabIndex = 0;
            // 
            // uAI_GESTION_AGUILADataSet
            // 
            this.uAI_GESTION_AGUILADataSet.DataSetName = "UAI_GESTION_AGUILADataSet";
            this.uAI_GESTION_AGUILADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uAIGESTIONAGUILADataSetBindingSource
            // 
            this.uAIGESTIONAGUILADataSetBindingSource.DataSource = this.uAI_GESTION_AGUILADataSet;
            this.uAIGESTIONAGUILADataSetBindingSource.Position = 0;
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "Clientes";
            this.clientesBindingSource.DataSource = this.uAIGESTIONAGUILADataSetBindingSource;
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // clientesBindingSource1
            // 
            this.clientesBindingSource1.DataMember = "Clientes";
            this.clientesBindingSource1.DataSource = this.uAIGESTIONAGUILADataSetBindingSource;
            // 
            // personasBindingSource
            // 
            this.personasBindingSource.DataMember = "Personas";
            this.personasBindingSource.DataSource = this.uAIGESTIONAGUILADataSetBindingSource;
            // 
            // personasTableAdapter
            // 
            this.personasTableAdapter.ClearBeforeFill = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(263, 586);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(194, 40);
            this.button5.TabIndex = 9;
            this.button5.Text = "Salir";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(783, 586);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 40);
            this.button4.TabIndex = 8;
            this.button4.Text = "Ver detalles";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1043, 586);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 40);
            this.button3.TabIndex = 7;
            this.button3.Text = "Eliminar Cliente";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(523, 586);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "Modificar Cliente";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 586);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Nuevo Cliente";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // formInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1304, 706);
            this.Controls.Add(this.tableLayoutPanelListaClientes);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formInicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.formInicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanelListaClientes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAI_GESTION_AGUILADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAIGESTIONAGUILADataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actividadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pilotosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actividadesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem busquedaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelListaClientes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource uAIGESTIONAGUILADataSetBindingSource;
        private UAI_GESTION_AGUILADataSet uAI_GESTION_AGUILADataSet;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private UAI_GESTION_AGUILADataSetTableAdapters.ClientesTableAdapter clientesTableAdapter;
        private System.Windows.Forms.BindingSource clientesBindingSource1;
        private System.Windows.Forms.BindingSource personasBindingSource;
        private UAI_GESTION_AGUILADataSetTableAdapters.PersonasTableAdapter personasTableAdapter;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

