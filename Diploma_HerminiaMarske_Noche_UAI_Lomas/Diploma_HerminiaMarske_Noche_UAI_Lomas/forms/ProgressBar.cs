using Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class ProgressBar : Form
    {
        private Timer timer;
        private Backup backup;
        private Restore restore;
        private Server server;
        private bool dispatch;

        public ProgressBar()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public ProgressBar(bool dispatch)
        {
            this.dispatch = dispatch;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public ProgressBar(Restore restoreDB, Server tempConn)
        {
            restore = restoreDB;
            server = tempConn;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public ProgressBar(Backup backupDB, Server tempConn)
        {
            backup = backupDB;
            server = tempConn;
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

            restore.PercentComplete += CompletionStatusInPercent;
            restore.Complete += Restore_Completed;
            restore.SqlRestoreAsync(server);
            timer = new Timer();
            timer.Elapsed += Timer_Restore;
            timer.AutoReset = true;
            timer.Interval = 2000;
            timer.Start();

            return ShowDialog();
        }

        internal DialogResult ShowBackup()
        {
            lblMessage.Text = strings.backup_in_process;

            backup.PercentComplete += CompletionStatusInPercent;
            backup.Complete += Backup_Completed;
            backup.SqlBackupAsync(server);
            timer = new Timer();
            timer.Elapsed += Timer_Backup;
            timer.AutoReset = true;
            timer.Interval = 2000;
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
            SetLabel(strings.validation_finished);
            System.Threading.Thread.Sleep(2000);
            if (dispatch)
            {
                Close();
            }
        }

        private void Timer_Restore(object sender, ElapsedEventArgs e)
        {
            if (restore.AsyncStatus.ExecutionStatus == ExecutionStatus.Failed)
            {
                SetExtra(restore.AsyncStatus.LastException.Message, KnownColor.Red);
                server.ConnectionContext.Disconnect();
                timer.Stop();
            }
            else if (restore.AsyncStatus.ExecutionStatus == ExecutionStatus.Succeeded)
            {
                SetProgress(100);
                server.ConnectionContext.Disconnect();
                timer.Stop();
            }
        }

        private void Timer_Backup(object sender, ElapsedEventArgs e)
        {
            if (backup.AsyncStatus.ExecutionStatus == ExecutionStatus.Failed)
            {
                SetExtra(backup.AsyncStatus.LastException.Message, KnownColor.Red);
                server.ConnectionContext.Disconnect();
                timer.Stop();
            }
            else if (backup.AsyncStatus.ExecutionStatus == ExecutionStatus.Succeeded)
            {
                SetProgress(100);
                server.ConnectionContext.Disconnect();
                timer.Stop();
            }
        }

        private void CompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
        {
            SetProgress(args.Percent);
        }
        private void Backup_Completed(object sender, ServerMessageEventArgs args)
        {
            SetLabel(strings.backup_is_ready);
            SetProgress(100);
        }
        private void Restore_Completed(object sender, ServerMessageEventArgs args)
        {
            SetLabel(strings.restore_is_ready);
            SetProgress(100);
        }
    }
}
