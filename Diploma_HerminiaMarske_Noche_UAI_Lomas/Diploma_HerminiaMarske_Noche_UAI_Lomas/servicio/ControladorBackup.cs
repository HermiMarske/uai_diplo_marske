using System;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class ControladorBackup
    {
        private const string DefaultDatabase = "UAI_GESTION_AGUILA";
        private static forms.ProgressBar progress;
        private static string Sql = ConfigurationManager.ConnectionStrings["BackupConnection.Properties"].ConnectionString;

        private static Server GetSqlServer()
        {
            ServerConnection connection = new ServerConnection(new SqlConnection(Sql));
            Server myServer = new Server(connection);
            try
            {
                //Console.WriteLine(myServer.Language);
                //myServer.ConnectionContext.LoginSecure = true;
                myServer.ConnectionContext.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return myServer;
        }

        public static void CreateBackup(string address)
        {
            Backup bkpDBFull = new Backup();

            bkpDBFull.Action = BackupActionType.Database;
            bkpDBFull.Database = DefaultDatabase;

            bkpDBFull.CompressionOption = BackupCompressionOptions.On;
            string curFile = string.Format(@"{0}.bak", address.EndsWith(".bak") ? address.Substring(0, address.Length - 4) : address);
            if (File.Exists(curFile))
            {
                File.Delete(curFile);
            }
            bkpDBFull.Devices.AddDevice(curFile, DeviceType.File);
            bkpDBFull.BackupSetName = "GESTION AGUILA BACKUP";
            bkpDBFull.BackupSetDescription = "Backup completo de base de datos";

            bkpDBFull.ExpirationDate = DateTime.Today.AddDays(30);
            bkpDBFull.Initialize = false;

            Server tempConn = GetSqlServer();
            if (tempConn != null && tempConn.ConnectionContext.IsOpen) {
                progress = new forms.ProgressBar(bkpDBFull, tempConn);
                progress.ShowBackup();
                progress.Dispose();
            } else
            {
                throw new ConnectionException("NO_CONNECTION_DATABASE");
            }
        }

        public static void RestoreBackup(string address)
        {
            Restore restoreDB = new Restore();
            restoreDB.Database = DefaultDatabase;

            restoreDB.Action = RestoreActionType.Database;
            string curFile = string.Format(@"{0}.bak", address.EndsWith(".bak") ? address.Substring(0, address.Length - 4) : address);
            if (!File.Exists(curFile) && Regex.Match(curFile, @"^[A-z]\:\\", RegexOptions.IgnoreCase).Success)
            {
                throw new FailedOperationException("NO_FILE_SELECTED");
            }
            else if (File.Exists(curFile) && !curFile.EndsWith(".bak"))
            {
                throw new FailedOperationException("NO_VALID_EXTENSION");
            }
            restoreDB.Devices.AddDevice(curFile, DeviceType.File);

            restoreDB.NoRecovery = false;
            restoreDB.ReplaceDatabase = true;

            Server tempConn = GetSqlServer();
            if (tempConn != null && tempConn.ConnectionContext.IsOpen && restoreDB.SqlVerifyLatest(tempConn))
            {
                progress = new forms.ProgressBar(restoreDB, tempConn);
                progress.ShowRestore();
                progress.Dispose();
            }
            else if (!restoreDB.SqlVerifyLatest(tempConn))
            {
                throw new ConnectionException("COULDNT_VERIFY_BACKUP");
            }
            else
            {
                throw new ConnectionException("NO_CONNECTION_DATABASE");
            }
        }

        
    }
}
