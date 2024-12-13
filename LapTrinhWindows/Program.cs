using LapTrinhWindows.Buoi4;
using LapTrinhWindows.TruyenData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapTrinhWindows
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Buoi4.ListView()); //Bài 4
            //Application.Run(new Buoi5.MDI.frm_SoanThao); //Bài 5
            Application.Run(new Buoi6.QuanLySinhVien.Form1()); //Bài 5
        }
    }
}
