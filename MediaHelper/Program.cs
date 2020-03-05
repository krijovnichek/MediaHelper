using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaHelper
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }

        // public static void fClose()
        //{
        //    for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
        //    {
               
        //            Application.OpenForms[1].Close;
                
        //    }
        //}
    }
}
