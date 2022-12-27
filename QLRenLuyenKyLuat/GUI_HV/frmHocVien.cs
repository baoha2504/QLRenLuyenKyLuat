using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DialogResult = System.Windows.Forms.DialogResult;
namespace QLRenLuyenKyLuat.GUI_HV
{
    public partial class frmHocVien : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmHocVien()
        {
            InitializeComponent();
            time.Caption = DateTime.Now.ToString("dd/MM/yyyy");
            //hienthi thong tin user:
            name.Caption = frmLogin.name;
            position.Caption = frmLogin.position;
            
        }

        KQKL_HK KQKL_HK;
        KQKL_Nam KQKL_Nam;
        KQKL_Thang KQKL_Thang;
        KQTL_Nam KQTL_Nam;
        KQTL_Quy KQTL_Quy;
        TrangChu TrangChu;
        TuDanhGia TuDanhGia;

        private void fluentDesignFormControl1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void frmHocVien_Load(object sender, EventArgs e)
        {
            
        }

        private void ace_TuDanhGia_Click(object sender, EventArgs e)
        {
            if (TuDanhGia == null)
            {
                TuDanhGia tuDanhGia = new TuDanhGia();
                tuDanhGia.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(tuDanhGia);
                tuDanhGia.BringToFront();
            }
            else
            {
                TuDanhGia.BringToFront();
            }
            lblTieuDe.Caption = "Học viên tự đánh giá";
        }

        private void ace_KQKL_Thang_Click(object sender, EventArgs e)
        {
            if (KQKL_Thang == null)
            {
                KQKL_Thang kQKL_Thang = new KQKL_Thang();
                kQKL_Thang.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(kQKL_Thang);
                kQKL_Thang.BringToFront();
            }
            else
            {
                KQKL_Thang.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả kỷ luật tháng";
        }

        private void ace_KQKL_Ky_Click(object sender, EventArgs e)
        {
            if (KQKL_HK == null)
            {
                KQKL_HK kQKL_HK = new KQKL_HK();
                kQKL_HK.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(kQKL_HK);
                kQKL_HK.BringToFront();
            }
            else
            {
                KQKL_HK.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả kỷ luật theo kỳ";
        }

        private void ace_KQKL_Nam_Click(object sender, EventArgs e)
        {
            if (KQKL_Nam == null)
            {
                KQKL_Nam kQKL_Nam = new KQKL_Nam();
                kQKL_Nam.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(kQKL_Nam);
                kQKL_Nam.BringToFront();
            }
            else
            {
                KQKL_Nam.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả kỷ luật năm";
        }

        private void ace_KQTL_Quy_Click(object sender, EventArgs e)
        {
            if (KQTL_Quy == null)
            {
                KQTL_Quy kQTL_Quy = new KQTL_Quy();
                kQTL_Quy.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(kQTL_Quy);
                kQTL_Quy.BringToFront();
            }
            else
            {
                KQTL_Quy.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả thể lực quý";
        }

        private void aceTrangChu_Click(object sender, EventArgs e)
        {
            if (TrangChu == null)
            {
                TrangChu trangChu = new TrangChu();
                trangChu.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(trangChu);
                trangChu.BringToFront();
            }
            else
            {
                TrangChu.BringToFront();
            }
            lblTieuDe.Caption = "Trang chủ";
        }

        private void ace_KQTL_Nam_Click(object sender, EventArgs e)
        {
            if (KQTL_Nam == null)
            {
                KQTL_Nam kQTL_Nam = new KQTL_Nam();
                kQTL_Nam.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(kQTL_Nam);
                kQTL_Nam.BringToFront();
            }
            else
            {
                KQTL_Nam.BringToFront();
            }
            lblTieuDe.Caption = "Kết quả thể lực quý";
        }
    }
}
