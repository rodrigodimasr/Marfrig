using Marfrig.UI.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marfrig.Core; 

namespace Marfrig.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = ConfigurationManager.AppSettings["URL"];
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Consulta(new Animal(path), new Pecuarista(path), new CompraGado(path)));
        }
    }
}
