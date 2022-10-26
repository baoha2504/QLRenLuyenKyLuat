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
      
        public frmLop()
        {
            InitializeComponent();
            dsHocvien1.BringToFront();
            //hienthi thong tin user:
            barStaticItem3.Caption = frmLogin.name;
            barStaticItem2.Caption = frmLogin.position;
            barStaticItem4.Caption = frmLogin.lop;
        }
        // click
        private void itemMonth_Click(object sender, EventArgs e)
        {
            //kqkL_Month1.BringToFront();
        }

        private void itemHocky_Click(object sender, EventArgs e)
        {
            //kqkL_Term1.BringToFront();
        }

        private void itemNamhoc_Click(object sender, EventArgs e)
        {
           // kqkL_Year1.BringToFront();
        }

        private void itemQuy_Click(object sender, EventArgs e)
        {
           // kqtL_Quy1.BringToFront();
        }

        private void itemNam_Click(object sender, EventArgs e)
        {
           // kqtl_year1.BringToFront();
        }

        private void itemHDSDKL_Click(object sender, EventArgs e)
        {
           // hdsD_KL1.BringToFront();
        }

        private void itemHDSDTL_Click(object sender, EventArgs e)
        {
           // hdsD_TL1.BringToFront();
        }

        private void itemMK_Click(object sender, EventArgs e)
        {
           // loP_ThayMK1.BringToFront();
        }

        private void itemOut_Click(object sender, EventArgs e)
        {

        }
    }
}
