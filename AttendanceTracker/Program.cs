using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceTracker
{
    static class Program
    {
        public static Emgu.CV.VideoCapture _capture = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _capture = new Emgu.CV.VideoCapture(); ;
            Application.Run(new DashBoard());
            
        }
    }
}
