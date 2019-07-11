using Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class BackupDialog : Form
    {
        public BackupDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardarRespaldo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            guardarRespaldo.FileName = string.Format("Respaldo_UAI_GESTION_AGUILA_{0}", DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            guardarRespaldo.Filter = strings.backup_extensions;
            guardarRespaldo.ShowDialog();
            txtRespaldo.Text = guardarRespaldo.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            servicio.ControladorBackup.CreateBackup(txtRespaldo.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buscarRespaldo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            buscarRespaldo.Filter = strings.backup_extensions;
            buscarRespaldo.ShowDialog();
            txtRestauracion.Text = buscarRespaldo.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            servicio.ControladorBackup.RestoreBackup(txtRestauracion.Text);
        }
    }
}
