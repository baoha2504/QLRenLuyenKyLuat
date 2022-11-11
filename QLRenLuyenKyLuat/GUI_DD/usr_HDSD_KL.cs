using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_HDSD_KL : UserControl
    {
        public usr_HDSD_KL()
        {
            InitializeComponent();
        }

        private void usr_HDSD_KL_Load(object sender, EventArgs e)
        {
            string a = File.ReadAllText("D:\\QLRenLuyenKyLuat\\QLRenLuyenKyLuat\\HDSD_KyLuat.txt");
            txtNoiDung.Text = a;
        }
    }
}
