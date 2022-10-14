using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLRenLuyenKyLuat.GUI_DD;
using QLRenLuyenKyLuat.GUI_LOP;
using QLRenLuyenKyLuat.GUI_HV;

namespace QLRenLuyenKyLuat
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmDaiDoi frmDaiDoi = new frmDaiDoi();
            frmDaiDoi.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmLop frmLop = new frmLop();
            frmLop.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmHocVien frmHocVien = new frmHocVien();
            frmHocVien.Show();
            this.Hide();
        }
    }
}
