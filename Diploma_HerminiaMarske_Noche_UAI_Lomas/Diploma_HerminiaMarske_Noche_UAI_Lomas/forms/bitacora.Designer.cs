namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    partial class bitacora
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bitacora));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimeFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dateTimeFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.comboCriticidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridBitacora = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criticidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBitacora)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.comboCriticidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dateTimeFechaHasta
            // 
            this.dateTimeFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dateTimeFechaHasta, "dateTimeFechaHasta");
            this.dateTimeFechaHasta.Name = "dateTimeFechaHasta";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btnFiltrar
            // 
            resources.ApplyResources(this.btnFiltrar, "btnFiltrar");
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dateTimeFechaDesde
            // 
            this.dateTimeFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dateTimeFechaDesde, "dateTimeFechaDesde");
            this.dateTimeFechaDesde.Name = "dateTimeFechaDesde";
            // 
            // comboCriticidad
            // 
            this.comboCriticidad.FormattingEnabled = true;
            this.comboCriticidad.Items.AddRange(new object[] {
            resources.GetString("comboCriticidad.Items"),
            resources.GetString("comboCriticidad.Items1"),
            resources.GetString("comboCriticidad.Items2")});
            resources.ApplyResources(this.comboCriticidad, "comboCriticidad");
            this.comboCriticidad.Name = "comboCriticidad";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtUsuario
            // 
            resources.ApplyResources(this.txtUsuario, "txtUsuario");
            this.txtUsuario.Name = "txtUsuario";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // dataGridBitacora
            // 
            this.dataGridBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBitacora.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.criticidad,
            this.descripcion,
            this.usuario});
            this.dataGridBitacora.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            resources.ApplyResources(this.dataGridBitacora, "dataGridBitacora");
            this.dataGridBitacora.Name = "dataGridBitacora";
            this.dataGridBitacora.ReadOnly = true;
            this.dataGridBitacora.RowTemplate.Height = 28;
            this.dataGridBitacora.ShowCellToolTips = false;
            this.dataGridBitacora.ShowEditingIcon = false;
            // 
            // fecha
            // 
            resources.ApplyResources(this.fecha, "fecha");
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // criticidad
            // 
            resources.ApplyResources(this.criticidad, "criticidad");
            this.criticidad.Name = "criticidad";
            this.criticidad.ReadOnly = true;
            // 
            // descripcion
            // 
            resources.ApplyResources(this.descripcion, "descripcion");
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // usuario
            // 
            resources.ApplyResources(this.usuario, "usuario");
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // btnSalir
            // 
            resources.ApplyResources(this.btnSalir, "btnSalir");
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimeFechaHasta);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dateTimeFechaDesde);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // bitacora
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dataGridBitacora);
            this.Controls.Add(this.groupBox1);
            this.Icon = global::Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties.Resources.Airplane_Landing;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "bitacora";
            this.Load += new System.EventHandler(this.bitacora_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBitacora)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DateTimePicker dateTimeFechaDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboCriticidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridBitacora;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn criticidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DateTimePicker dateTimeFechaHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}