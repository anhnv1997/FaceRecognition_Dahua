using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognition
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StaticPool.Language = Properties.Settings.Default.Language;
            if (StaticPool.Language == "" || StaticPool.Language == "vi-VN")
                StaticPool.Language = "vi-VN";

            // Ngon ngu su dung
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(StaticPool.Language);

            Application.Run(new Form1());
        }
    }
}
