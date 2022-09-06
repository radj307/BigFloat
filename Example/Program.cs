using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Example
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            App app = new();
            try
            {
                var mw = new MainWindow();
                app.Run(mw);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
