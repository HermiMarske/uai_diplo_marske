using System.Data.SqlClient;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties;
using System.Timers;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class ControladorBackup
    {
        private const string defaultDatabase = "UAI_GESTION_AGUILA";

        private static Timer timer;
        private static forms.ProgressBar progress;
        private static string address;

        public static string Address { get => address; set => address = value; }

        public static void CreateBackup(string address)
        {
            progress = new forms.ProgressBar();
            Address = address;
            timer = new Timer();
            timer.Elapsed += Timer_Backup;
            timer.AutoReset = false;
            timer.Interval = 100;
            timer.Start();

            progress.ShowBackup();
            progress.Dispose();
        }

        public static void RestoreBackup(string address)
        {
            progress = new forms.ProgressBar();
            Address = address;
            timer = new Timer();
            timer.Elapsed += Timer_Restore;
            timer.AutoReset = false;
            timer.Interval = 100;
            timer.Start();

            progress.ShowRestore();
            progress.Dispose();
        }

        private static void Timer_Restore(object sender, ElapsedEventArgs e)
        {
            DataConnection.DataConnection restoreQuery = new DataConnection.DataConnection();
            try
            {
                restoreQuery.sqlCommand(string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE; ", defaultDatabase), null);
                restoreQuery.sqlCommand(string.Format("USE master; RESTORE DATABASE {0} FROM DISK = '{1}' WITH REPLACE;", defaultDatabase, Address), null);
                restoreQuery.sqlCommand(string.Format("ALTER DATABASE {0} SET MULTI_USER; ", defaultDatabase), null);
                progress.SetLabel(strings.restore_is_ready);
            }
            catch (SqlException ex)
            {
                progress.SetExtra(ex.Message, System.Drawing.KnownColor.Red);
            }
            progress.SetProgress(100);
        }

        private static void Timer_Backup(object sender, ElapsedEventArgs e)
        {
            DataConnection.DataConnection backupQuery = new DataConnection.DataConnection();
            string backupSQL = string.Format("BACKUP DATABASE [{0}] TO DISK = '{1}'" +
                "WITH FORMAT, COMPRESSION, MEDIANAME = 'AGUILA_BACKUP', " +
                "NAME = 'BACKUP COMPLETO DE BASE DE DATOS';", defaultDatabase, Address);
            try
            {
                backupQuery.sqlCommand(backupSQL, null);
                progress.SetLabel(strings.backup_is_ready);
            }
            catch (SqlException ex)
            {
                progress.SetExtra(ex.Message, System.Drawing.KnownColor.Red);
            }
            progress.SetProgress(100);
        }
    }
}
