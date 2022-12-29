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

namespace QLRenLuyenKyLuat.GUI_LOP
{
    public partial class HDSD_KL : DevExpress.XtraEditors.XtraUserControl
    {
        public HDSD_KL()
        {
            InitializeComponent();
            string a = File.ReadAllText("D:\\QLRenLuyenKyLuat\\QLRenLuyenKyLuat\\HDSD_KyLuat.txt");
            txtbox_HDSDKL.Text = a;
        }
    }
}
