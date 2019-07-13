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
        private static forms.ProgressBar progress;

        public static void CreateBackup(string address)
        {
            progress = new forms.ProgressBar(address);
            progress.ShowBackup();
            progress.Dispose();
        }

        public static void RestoreBackup(string address)
        {
            progress = new forms.ProgressBar(address);
            progress.ShowRestore();
            progress.Dispose();
        }
    }
}
