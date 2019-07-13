using Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using System.Data.SqlClient;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class ProgressBar : Form
    {
        private const string defaultDatabase = "UAI_GESTION_AGUILA";
        private string address;
        private Timer timer;
        private bool dispatch;

        public ProgressBar()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public ProgressBar(string address)
        {
            this.address = address;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public ProgressBar(bool dispatch)
        {
            this.dispatch = dispatch;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void SetProgress(int percent)
        {
            progBar.Value = percent;
            if (percent == 100)
            {
                btnOK.Enabled = true;
            }
        }

        public void SetLabel(string label)
        {
            lblMessage.Text = label;
        }

        public void SetExtra(string label, KnownColor color)
        {
            lblExtra.ForeColor = Color.FromKnownColor(color);
            lblExtra.Text = label;
            btnOK.Enabled = true;
        }

        internal DialogResult ShowRestore()
        {
            lblMessage.Text = strings.restore_in_process;
            progBar.Style = ProgressBarStyle.Marquee;

            timer = new Timer();
            timer.Elapsed += Timer_Restore;
            timer.AutoReset = false;
            timer.Interval = 100;
            timer.Start();

            return ShowDialog();
        }

        internal DialogResult ShowBackup()
        {
            lblMessage.Text = strings.backup_in_process;
            progBar.Style = ProgressBarStyle.Marquee;

            timer = new Timer();
            timer.Elapsed += Timer_Backup;
            timer.AutoReset = false;
            timer.Interval = 100;
            timer.Start();

            return ShowDialog();
        }

        internal DialogResult ShowRecalculate()
        {
            lblMessage.Text = strings.recalculate_in_progress;
            progBar.Style = ProgressBarStyle.Marquee;
            timer = new Timer();
            timer.Elapsed += Timer_Recalculate;
            timer.AutoReset = false;
            timer.Interval = 100;
            timer.Start();

            return ShowDialog();
        }

        internal DialogResult ShowValidateIntegrity()
        {
            lblMessage.Text = strings.validation_in_progress;
            progBar.Style = ProgressBarStyle.Marquee;
            timer = new Timer();
            timer.Elapsed += Timer_ValidateIntegrity;
            timer.AutoReset = false;
            timer.Interval = 200;
            timer.Start();

            return ShowDialog();
        }



        private void Timer_Recalculate(object sender, ElapsedEventArgs e)
        {
            ControladorDigitosVerificadores.recalcularDV();
            SetLabel(strings.recalculation_success);
            SetProgress(100);

            if (dispatch)
            {
                Close();
            }
        }

        private void Timer_ValidateIntegrity(object sender, ElapsedEventArgs e)
        {
            ControladorDigitosVerificadores.verificarIntegridad();
            System.Threading.Thread.Sleep(2000);
            SetLabel(strings.validation_finished);
            System.Threading.Thread.Sleep(500);

            if (dispatch)
            {
                Close();
            }
        }

        private void Timer_Restore(object sender, ElapsedEventArgs e)
        {
            DataConnection.DataConnection restoreQuery = new DataConnection.DataConnection();
            string restoreSQL = string.Format("USE master; RESTORE DATABASE {0} FROM DISK = '{1}' WITH REPLACE;", defaultDatabase, address);
            try
            {
                restoreQuery.sqlCommand(string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE; ", defaultDatabase), null);
                restoreQuery.sqlCommand(restoreSQL, null);
                restoreQuery.sqlCommand(string.Format("ALTER DATABASE {0} SET MULTI_USER; ", defaultDatabase), null);
                SetLabel(strings.restore_is_ready);
            }
            catch (SqlException ex)
            {
                SetExtra(ex.Message, KnownColor.Red);
            }
            SetProgress(100);

            if (dispatch)
            {
                Close();
            }
        }

        private void Timer_Backup(object sender, ElapsedEventArgs e)
        {
            DataConnection.DataConnection backupQuery = new DataConnection.DataConnection();
            string backupSQL = string.Format("BACKUP DATABASE [{0}] TO DISK = '{1}'" +
                "WITH FORMAT, COMPRESSION, MEDIANAME = 'AGUILA_BACKUP', " +
                "NAME = 'BACKUP COMPLETO DE BASE DE DATOS';", defaultDatabase, address);
            try
            {
                backupQuery.sqlCommand(backupSQL, null);
                SetLabel(strings.backup_is_ready);
            }
            catch (SqlException ex) 
            {
                SetExtra(ex.Message, KnownColor.Red);
            }
            SetProgress(100);

            if (dispatch)
            {
                Close();
            }
        }
    }
}
