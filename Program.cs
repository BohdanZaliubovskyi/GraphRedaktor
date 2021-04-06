using GraphRedaktor.Models;
using GraphRedaktor.Models.MyEventArgs;
using GraphRedaktor.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphRedaktor
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
            MainForm form = new MainForm();
            FileHandler fileHandler = new FileHandler();
            ImageHandler imageHandler = new ImageHandler();
            MainPresenter mainPresenter = new MainPresenter(form, fileHandler, imageHandler);
            Application.Run(form);
        }
    }
}
