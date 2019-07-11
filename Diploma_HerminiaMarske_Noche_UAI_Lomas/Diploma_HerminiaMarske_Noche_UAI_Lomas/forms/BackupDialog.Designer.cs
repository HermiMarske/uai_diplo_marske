namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    partial class BackupDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupDialog));
            this.grpRespaldo = new System.Windows.Forms.GroupBox();
            this.btnRespaldar = new System.Windows.Forms.Button();
            this.btnBuscarRespaldo = new System.Windows.Forms.Button();
            this.txtRespaldo = new System.Windows.Forms.TextBox();
            this.grpRestaurar = new System.Windows.Forms.GroupBox();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnAbrirBackup = new System.Windows.Forms.Button();
            this.txtRestauracion = new System.Windows.Forms.TextBox();
            this.guardarRespaldo = new System.Windows.Forms.SaveFileDialog();
            this.buscarRespaldo = new System.Windows.Forms.OpenFileDialog();
            this.grpRespaldo.SuspendLayout();
            this.grpRestaurar.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRespaldo
            // 
            this.grpRespaldo.Controls.Add(this.btnRespaldar);
            this.grpRespaldo.Controls.Add(this.btnBuscarRespaldo);
            this.grpRespaldo.Controls.Add(this.txtRespaldo);
            resources.ApplyResources(this.grpRespaldo, "grpRespaldo");
            this.grpRespaldo.Name = "grpRespaldo";
            this.grpRespaldo.TabStop = false;
            // 
            // btnRespaldar
            // 
            resources.ApplyResources(this.btnRespaldar, "btnRespaldar");
            this.btnRespaldar.Name = "btnRespaldar";
            this.btnRespaldar.UseVisualStyleBackColor = true;
            this.btnRespaldar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBuscarRespaldo
            // 
            resources.ApplyResources(this.btnBuscarRespaldo, "btnBuscarRespaldo");
            this.btnBuscarRespaldo.Name = "btnBuscarRespaldo";
            this.btnBuscarRespaldo.UseVisualStyleBackColor = true;
            this.btnBuscarRespaldo.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRespaldo
            // 
            this.txtRespaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtRespaldo, "txtRespaldo");
            this.txtRespaldo.Name = "txtRespaldo";
            // 
            // grpRestaurar
            // 
            this.grpRestaurar.Controls.Add(this.btnRestaurar);
            this.grpRestaurar.Controls.Add(this.btnAbrirBackup);
            this.grpRestaurar.Controls.Add(this.txtRestauracion);
            resources.ApplyResources(this.grpRestaurar, "grpRestaurar");
            this.grpRestaurar.Name = "grpRestaurar";
            this.grpRestaurar.TabStop = false;
            // 
            // btnRestaurar
            // 
            resources.ApplyResources(this.btnRestaurar, "btnRestaurar");
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAbrirBackup
            // 
            resources.ApplyResources(this.btnAbrirBackup, "btnAbrirBackup");
            this.btnAbrirBackup.Name = "btnAbrirBackup";
            this.btnAbrirBackup.UseVisualStyleBackColor = true;
            this.btnAbrirBackup.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtRestauracion
            // 
            this.txtRestauracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtRestauracion, "txtRestauracion");
            this.txtRestauracion.Name = "txtRestauracion";
            // 
            // guardarRespaldo
            // 
            this.guardarRespaldo.RestoreDirectory = true;
            // 
            // buscarRespaldo
            // 
            this.buscarRespaldo.RestoreDirectory = true;
            // 
            // BackupDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpRestaurar);
            this.Controls.Add(this.grpRespaldo);
            this.Icon = global::Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties.Resources.Airplane_Landing;
            this.Name = "BackupDialog";
            this.grpRespaldo.ResumeLayout(false);
            this.grpRespaldo.PerformLayout();
            this.grpRestaurar.ResumeLayout(false);
            this.grpRestaurar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRespaldo;
        private System.Windows.Forms.Button btnRespaldar;
        private System.Windows.Forms.Button btnBuscarRespaldo;
        private System.Windows.Forms.TextBox txtRespaldo;
        private System.Windows.Forms.GroupBox grpRestaurar;
        private System.Windows.Forms.SaveFileDialog guardarRespaldo;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnAbrirBackup;
        private System.Windows.Forms.TextBox txtRestauracion;
        private System.Windows.Forms.OpenFileDialog buscarRespaldo;
    }
}