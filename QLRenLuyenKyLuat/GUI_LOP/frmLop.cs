using System;
using System.Windows.Forms;
using QLRenLuyenKyLuat.GUI_DD;
using QLRenLuyenKyLuat.GUI_LOP;
using QLRenLuyenKyLuat.GUI_HV;
using System.Data.SqlClient;
using QLRenLuyenKyLuat.Data;
using System.Text;
using System.Data;

namespace QLRenLuyenKyLuat.GUI_LOP
{
    public partial class frmLop : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        DSHocvien DSHocvien;
        HDSD_KL HDSD_KL;
        HDSD_TL HDSD_TL;
        KQKL_Month KQKL_Month;
        KQKL_Term KQKL_Term;
        KQKL_Year KQKL_Year;
        KQTL_Quy KQTL_Quy;
        KQTL_Year KQTL_Year;
        LOP_ThayMK LOP_ThayMK;
        NhapRLKL NhapRLKL;
        TrangChu TrangChu;
        public frmLop()
        {
            InitializeComponent();
            
            //hienthi thong tin user:
            barStaticItem3.Caption = frmLogin.name;
            barStaticItem4.Caption = frmLogin.maLop;
            DateTime dt = DateTime.Now;
            barStaticItem6.Caption = dt.Date.ToString("yyyy/MM/dd");
            if (TrangChu == null)
            {
                TrangChu TrangChu = new TrangChu();
                TrangChu.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(TrangChu);
                TrangChu.BringToFront();
                
            }
            else
            {
                TrangChu.BringToFront();
               
            }
            lblTieude.Caption = "Trang chủ";

        }
        // clik trang chu 
        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            if (TrangChu == null)
            {
                TrangChu TrangChu = new TrangChu();
                TrangChu.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(TrangChu);
                TrangChu.BringToFront();
                
            }
            else
            {
                TrangChu.BringToFront();
               
            }
            lblTieude.Caption = "Trang chủ";
        }
        // click
        private void itemMonth_Click(object sender, EventArgs e)
        {
            //kqkL_Month1.BringToFront();
            if (KQKL_Month == null)
            {
                KQKL_Month KQKL_Month = new KQKL_Month();
                KQKL_Month.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(KQKL_Month);
                KQKL_Month.BringToFront();
            }
            else
            {
                KQKL_Month.BringToFront();
            }
            lblTieude.Caption = "Kết quả rèn luyện kỷ luật theo tháng";
        }

        private void itemHocky_Click(object sender, EventArgs e)
        {
            if (KQKL_Term == null)
            {
                KQKL_Term KQKL_Term = new KQKL_Term();
                KQKL_Term.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(KQKL_Term);
                KQKL_Term.BringToFront();
            }
            else
            {
                KQKL_Term.BringToFront();
            }
            lblTieude.Caption = "Kết quả rèn luyện kỷ luật theo học kỳ";
        }

        private void itemNamhoc_Click(object sender, EventArgs e)
        {
            if (KQKL_Year == null)
            {
                KQKL_Year KQKL_Year = new KQKL_Year();
                KQKL_Year.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(KQKL_Year);
                KQKL_Year.BringToFront();
            }
            else
            {
                KQKL_Year.BringToFront();
            }
            lblTieude.Caption = "Kết quả rèn luyện kỷ luật theo năm học";
        }

        private void itemQuy_Click(object sender, EventArgs e)
        {
            if (KQTL_Quy == null)
            {
                KQTL_Quy KQTL_Quy = new KQTL_Quy();
                KQTL_Quy.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(KQTL_Quy);
                KQTL_Quy.BringToFront();
            }
            else
            {
                KQTL_Quy.BringToFront();
            }
            lblTieude.Caption = "Kết quả rèn luyện thể lực theo quý";
        }

        private void itemNam_Click(object sender, EventArgs e)
        {
            if (KQTL_Year == null)
            {
                KQTL_Year KQTL_Year = new KQTL_Year();
                KQTL_Year.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(KQTL_Year);
                KQTL_Year.BringToFront();
            }
            else
            {
                KQTL_Year.BringToFront();
            }
            lblTieude.Caption = "Kết quả rèn luyện thể lực theo năm";
        }

        private void itemHDSDKL_Click(object sender, EventArgs e)
        {
            if (HDSD_KL == null)
            {
                HDSD_KL HDSD_KL = new HDSD_KL();
                HDSD_KL.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(HDSD_KL);
                HDSD_KL.BringToFront();
            }
            else
            {
                HDSD_KL.BringToFront();
            }
            lblTieude.Caption = "Hướng dẫn sử dụng chức năng quản lý kỷ luật";
        }

        private void itemHDSDTL_Click(object sender, EventArgs e)
        {
            if (HDSD_TL == null)
            {
                HDSD_TL HDSD_TL = new HDSD_TL();
                HDSD_TL.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(HDSD_TL);
                HDSD_TL.BringToFront();
            }
            else
            {
                HDSD_TL.BringToFront();
            }
            lblTieude.Caption = "Hướng dẫn sử dụng chức năng quản lý thể lực";
        }

        private void itemMK_Click(object sender, EventArgs e)
        {
            if (LOP_ThayMK == null)
            {
                LOP_ThayMK LOP_ThayMK = new LOP_ThayMK();
                LOP_ThayMK.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(LOP_ThayMK);
                LOP_ThayMK.BringToFront();
            }
            else
            {
                LOP_ThayMK.BringToFront();
            }
            lblTieude.Caption = "Thay đổi mật khẩu"; 
        }

        private void itemOut_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Close();
            frm.Show();
        }

        private void NhapKL_Click(object sender, EventArgs e)
        {
            if (DSHocvien == null)
            {
                DSHocvien DSHocvien = new DSHocvien();
                DSHocvien.Dock = DockStyle.Fill;
                FormContainer.Controls.Add(DSHocvien);
                DSHocvien.BringToFront();
            }
            else
            {
                DSHocvien.BringToFront();
            }
            lblTieude.Caption = "Nhập kết quả rèn luyện kỷ luật";
        }
    }
}
