using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLRenLuyenKyLuat.GUI_CB;
using QLRenLuyenKyLuat.GUI_LT;
using QLRenLuyenKyLuat.GUI_HV;
using QLRenLuyenKyLuat.ADMIN;

namespace QLRenLuyenKyLuat
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void GuiCB_Click(object sender, EventArgs e)
        {
            frmCanBo frmCanBo = new frmCanBo();
            frmCanBo.Show();
            this.Hide();
        }

        private void GuiLT_Click(object sender, EventArgs e)
        {
            frmLopTruong frmLopTruong = new frmLopTruong();
            frmLopTruong.Show();
            this.Hide();
        }

        private void GuiHV_Click(object sender, EventArgs e)
        {
            frmHocVien frmHocVien = new frmHocVien();
            frmHocVien.Show();
            this.Hide();
        }

        private void GuiAdmin_Click(object sender, EventArgs e)
        {
            frmAdmin frmAdmin = new frmAdmin();
            frmAdmin.Show();
            this.Hide();
        }
    }
}
