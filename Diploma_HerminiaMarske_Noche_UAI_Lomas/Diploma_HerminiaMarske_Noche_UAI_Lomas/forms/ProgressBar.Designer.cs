namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    partial class ProgressBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressBar));
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblExtra = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progBar
            // 
            resources.ApplyResources(this.progBar, "progBar");
            this.progBar.Name = "progBar";
            this.progBar.Step = 1;
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.Name = "lblMessage";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.Text = global::Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties.strings.ok;
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblExtra
            // 
            resources.ApplyResources(this.lblExtra, "lblExtra");
            this.lblExtra.Name = "lblExtra";
            // 
            // ProgressBar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblExtra);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.progBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties.Resources.Airplane_Landing;
            this.Name = "ProgressBar";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblExtra;
    }
}