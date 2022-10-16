using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class frmDaiDoi : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmDaiDoi()
        {
            InitializeComponent();
        }

        usr_ThemHocVien usr_ThemHocVien;
        usr_SuaHocVien usr_SuaHocVien;
        private void btnThemHocVien_Click(object sender, EventArgs e)
        {
            if(usr_ThemHocVien == null)
            {
                usr_ThemHocVien usr_ThemHocVien = new usr_ThemHocVien();
                usr_ThemHocVien.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_ThemHocVien);
                usr_ThemHocVien.BringToFront();
            } else
            {
                usr_ThemHocVien.BringToFront();
            }
            lblTieuDe.Caption = "Thêm học viên";
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {
            if (usr_SuaHocVien == null)
            {
                usr_SuaHocVien usr_SuaHocVien = new usr_SuaHocVien();
                usr_SuaHocVien.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_SuaHocVien);
                usr_SuaHocVien.BringToFront();
            }
            else
            {
                usr_SuaHocVien.BringToFront();
            }
            lblTieuDe.Caption = "Sửa học viên";
        }
    }
}
