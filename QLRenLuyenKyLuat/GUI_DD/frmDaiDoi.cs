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
        usr_ThemLop usr_ThemLop;
        usr_SuaLop usr_SuaLop;
        usr_MatKhauHocVien usr_MatKhauHocVien;
        usr_MatKhauLop usr_MatKhauLop;
        usr_SuaDanhGia usr_SuaDanhGia;
        usr_DanhGiaKL_CN usr_DanhGiaKL_CN;
        usr_DanhGiaKL_L usr_DanhGiaKL_L;
        usr_DanhGiaKL_DD usr_DanhGiaKL_DD;
        usr_KQKL_Thang usr_KQKL_Thang;
        usr_KQKL_HK usr_KQKL_HK;
        usr_KQKL_Nam usr_KQKL_Nam;
        usr_NhapKQTL usr_NhapKQTL;
        usr_SuaKQTL usr_SuaKQTL;
        usr_KQTL_Quy usr_KQTL_Quy;
        usr_KQKL_Nam usr_KQTL_Nam;
        usr_QCKyLuat usr_QCKyLuat;
        usr_QCTheLuc usr_QCTheLuc;
        usr_ThayDoiQCKL usr_ThayDoiQCKL;
        usr_ThayDoiQCTL usr_ThayDoiQCTL;
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

        private void accordionControlElement16_Click(object sender, EventArgs e)
        {
            if (usr_ThemLop == null)
            {
                usr_ThemLop usr_ThemLop = new usr_ThemLop();
                usr_ThemLop.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_ThemLop);
                usr_ThemLop.BringToFront();
            }
            else
            {
                usr_ThemLop.BringToFront();
            }
            lblTieuDe.Caption = "Thêm lớp";
        }

        private void SuaThongTinLop_Click(object sender, EventArgs e)
        {
            if (usr_SuaLop == null)
            {
                usr_SuaLop usr_SuaLop = new usr_SuaLop();
                usr_SuaLop.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_SuaLop);
                usr_SuaLop.BringToFront();
            }
            else
            {
                usr_SuaLop.BringToFront();
            }
            lblTieuDe.Caption = "Sửa thông tin lớp lớp";
        }

        private void LayMatKhauHV_Click(object sender, EventArgs e)
        {
            if (usr_MatKhauHocVien == null)
            {
                usr_MatKhauHocVien usr_MatKhauHocVien = new usr_MatKhauHocVien();
                usr_MatKhauHocVien.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_MatKhauHocVien);
                usr_MatKhauHocVien.BringToFront();
            }
            else
            {
                usr_MatKhauHocVien.BringToFront();
            }
            lblTieuDe.Caption = "Lấy lại mật khẩu cho học viên";
        }

        private void LayMatKhauLop_Click(object sender, EventArgs e)
        {
            if (usr_MatKhauHocVien == null)
            {
                usr_MatKhauLop usr_MatKhauLop = new usr_MatKhauLop();
                usr_MatKhauLop.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_MatKhauLop);
                usr_MatKhauLop.BringToFront();
            }
            else
            {
                usr_MatKhauLop.BringToFront();
            }
            lblTieuDe.Caption = "Lấy lại mật khẩu cho lớp";
        }

        private void DanhGiaHV_Click(object sender, EventArgs e)
        {
            if (usr_DanhGiaKL_DD == null)
            {
                usr_DanhGiaKL_DD usr_DanhGiaKL_DD = new usr_DanhGiaKL_DD();
                usr_DanhGiaKL_DD.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_DanhGiaKL_DD);
                usr_DanhGiaKL_DD.BringToFront();
            }
            else
            {
                usr_DanhGiaKL_DD.BringToFront();
            }
            lblTieuDe.Caption = "Đánh giá kết quả rèn luyện của học viên";
        }

        private void SuaDanhGiaHV_Click(object sender, EventArgs e)
        {
            if (usr_SuaDanhGia == null)
            {
                usr_SuaDanhGia usr_SuaDanhGia = new usr_SuaDanhGia();
                usr_SuaDanhGia.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_SuaDanhGia);
                usr_SuaDanhGia.BringToFront();
            }
            else
            {
                usr_SuaDanhGia.BringToFront();
            }
            lblTieuDe.Caption = "Sửa kết quả đánh giá";
        }

        private void DeNghiHocVien_Click(object sender, EventArgs e)
        {
            if (usr_DanhGiaKL_CN == null)
            {
                usr_DanhGiaKL_CN usr_DanhGiaKL_CN = new usr_DanhGiaKL_CN();
                usr_DanhGiaKL_CN.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_DanhGiaKL_CN);
                usr_DanhGiaKL_CN.BringToFront();
            }
            else
            {
                usr_DanhGiaKL_CN.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả học viên đề nghị";
        }

        private void DeNghiLop_Click(object sender, EventArgs e)
        {
            if (usr_DanhGiaKL_L == null)
            {
                usr_DanhGiaKL_L usr_DanhGiaKL_L = new usr_DanhGiaKL_L();
                usr_DanhGiaKL_L.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_DanhGiaKL_L);
                usr_DanhGiaKL_L.BringToFront();
            }
            else
            {
                usr_DanhGiaKL_L.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả lớp đề nghị";
        }

        private void KQRLThang_Click(object sender, EventArgs e)
        {
            
        }

        private void KQRLHK_Click(object sender, EventArgs e)
        {
            if (usr_KQKL_HK == null)
            {
                usr_KQKL_HK usr_KQKL_HK = new usr_KQKL_HK();
                usr_KQKL_HK.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_KQKL_HK);
                usr_KQKL_HK.BringToFront();
            }
            else
            {
                usr_KQKL_HK.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả rèn luyện học kỳ";
        }

        private void KQRLNam_Click(object sender, EventArgs e)
        {
            if (usr_KQKL_Nam == null)
            {
                usr_KQKL_Nam usr_KQKL_Nam = new usr_KQKL_Nam();
                usr_KQKL_Nam.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_KQKL_Nam);
                usr_KQKL_Nam.BringToFront();
            }
            else
            {
                usr_KQKL_Nam.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả rèn luyện năm học";
        }

        private void NhapKQTL_Click(object sender, EventArgs e)
        {
            if (usr_NhapKQTL == null)
            {
                usr_NhapKQTL usr_NhapKQTL = new usr_NhapKQTL();
                usr_NhapKQTL.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_NhapKQTL);
                usr_NhapKQTL.BringToFront();
            }
            else
            {
                usr_NhapKQTL.BringToFront();
            }
            lblTieuDe.Caption = "Nhập kết quả kiểm tra thể lực";
        }

        private void SuaKQTL_Click(object sender, EventArgs e)
        {
            if (usr_SuaKQTL == null)
            {
                usr_SuaKQTL usr_SuaKQTL = new usr_SuaKQTL();
                usr_SuaKQTL.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_SuaKQTL);
                usr_SuaKQTL.BringToFront();
            }
            else
            {
                usr_SuaKQTL.BringToFront();
            }
            lblTieuDe.Caption = "Sửa kết quả kiểm tra thể lực";
        }

        private void KQTLQuy_Click(object sender, EventArgs e)
        {
            if (usr_KQTL_Quy == null)
            {
                usr_KQTL_Quy usr_KQTL_Quy = new usr_KQTL_Quy();
                usr_KQTL_Quy.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_KQTL_Quy);
                usr_KQTL_Quy.BringToFront();
            }
            else
            {
                usr_KQTL_Quy.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả thể lực quý";
        }

        private void KQTLNam_Click(object sender, EventArgs e)
        {
            if (usr_KQTL_Nam == null)
            {
                usr_KQTL_Nam usr_KQTL_Nam = new usr_KQTL_Nam();
                usr_KQTL_Nam.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_KQTL_Nam);
                usr_KQTL_Nam.BringToFront();
            }
            else
            {
                usr_KQTL_Nam.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả thể lực năm";
        }

        private void KQKLThang_Click(object sender, EventArgs e)
        {
            if (usr_KQKL_Thang == null)
            {
                usr_KQKL_Thang usr_KQKL_Thang = new usr_KQKL_Thang();
                usr_KQKL_Thang.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usr_KQKL_Thang);
                usr_KQKL_Thang.BringToFront();
            }
            else
            {
                usr_KQKL_Thang.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả rèn luyện tháng";
        }

        private void QCKL_Click(object sender, EventArgs e)
        {

        }

        private void QCTL_Click(object sender, EventArgs e)
        {

        }

        private void ThayDoiQCKL_Click(object sender, EventArgs e)
        {

        }

        private void ThayDoiQCTL_Click(object sender, EventArgs e)
        {

        }
    }
}
