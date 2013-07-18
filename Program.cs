using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScreenCapture
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            FormCapture NewFormCap = new FormCapture();

            //NewFormCap.Size = new System.Drawing.Size(((int)Math.Floor(Math.Floor(((double)Screen.PrimaryScreen.Bounds.Width / 4) * 3))), (int)Math.Floor(((double)Screen.PrimaryScreen.Bounds.Height / 4) * 3));

            Application.Run(new FormCapture());
        }
    }
}
