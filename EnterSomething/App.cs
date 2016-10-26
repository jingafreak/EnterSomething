using System;
using System.Windows.Forms;

namespace EnterSomething
{
    static class App
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GUI app = new GUI();
            Application.Run(app);
        }   // Main()
    }   // class App
}