using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLRenLuyenKyLuat.GUI_LOP;
using QLRenLuyenKyLuat.GUI_DD;
using QLRenLuyenKyLuat.GUI_HV;

namespace QLRenLuyenKyLuat
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
            //Application.Run(new frmDaiDoi());

             Application.Run(new frmLogin());
        }
    }
}
