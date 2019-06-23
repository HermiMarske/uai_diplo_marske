namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    partial class altaAvion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(altaAvion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkboxHabilitar = new System.Windows.Forms.CheckBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkboxHabilitar);
            this.groupBox1.Controls.Add(this.txtMarca);
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Controls.Add(this.txtMatricula);
            this.groupBox1.Controls.Add(this.lblMarca);
            this.groupBox1.Controls.Add(this.lblModelo);
            this.groupBox1.Controls.Add(this.lblMatricula);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // checkboxHabilitar
            // 
            resources.ApplyResources(this.checkboxHabilitar, "checkboxHabilitar");
            this.checkboxHabilitar.Name = "checkboxHabilitar";
            this.checkboxHabilitar.UseVisualStyleBackColor = true;
            // 
            // txtMarca
            // 
            resources.ApplyResources(this.txtMarca, "txtMarca");
            this.txtMarca.Name = "txtMarca";
            // 
            // txtModelo
            // 
            resources.ApplyResources(this.txtModelo, "txtModelo");
            this.txtModelo.Name = "txtModelo";
            // 
            // txtMatricula
            // 
            resources.ApplyResources(this.txtMatricula, "txtMatricula");
            this.txtMatricula.Name = "txtMatricula";
            // 
            // lblMarca
            // 
            resources.ApplyResources(this.lblMarca, "lblMarca");
            this.lblMarca.Name = "lblMarca";
            // 
            // lblModelo
            // 
            resources.ApplyResources(this.lblModelo, "lblModelo");
            this.lblModelo.Name = "lblModelo";
            // 
            // lblMatricula
            // 
            resources.ApplyResources(this.lblMatricula, "lblMatricula");
            this.lblMatricula.Name = "lblMatricula";
            // 
            // btnSalir
            // 
            resources.ApplyResources(this.btnSalir, "btnSalir");
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCrear
            // 
            resources.ApplyResources(this.btnCrear, "btnCrear");
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // altaAvion
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Icon = global::Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties.Resources.Airplane_Landing;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "altaAvion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.CheckBox checkboxHabilitar;
    }
}