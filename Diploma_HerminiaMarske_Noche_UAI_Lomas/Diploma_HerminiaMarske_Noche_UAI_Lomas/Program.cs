using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.tests;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new formInicio());
            //Application.Run(new Form1());
            Application.Run(new logIn());
        }
    }
}
