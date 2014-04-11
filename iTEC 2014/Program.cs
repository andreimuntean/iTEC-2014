using System;
using System.Windows.Forms;

namespace iTEC2014
{
    static class Program
    {
        public static MainForm Screen { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Screen = new MainForm())
            {
                Application.Run(Screen);
            }
        }
    }
}
