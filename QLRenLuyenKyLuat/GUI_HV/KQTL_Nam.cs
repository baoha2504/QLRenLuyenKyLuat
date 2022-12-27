using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using QLRenLuyenKyLuat.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_HV
{
    public partial class KQTL_Nam : DevExpress.XtraEditors.XtraUserControl
    {
        public KQTL_Nam()
        {
            InitializeComponent();
            cbB_TL_Nam.Text = DateTime.Now.Year.ToString();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        private void connect()
        {
            sqlCon.Open();
            string query = "select HOCVIEN.TenHocVien, HOCVIEN.MaLop, PHANLOAITHELUC.TenPLTL " +
            "from HOCVIEN, HOCVIEN_PLTL, KETQUATHELUC, PHANLOAITHELUC " +
            "where HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
            "and HOCVIEN_PLTL.MaKQTL = KETQUATHELUC.MaKQTL " +
            "and KETQUATHELUC.MaPLTL = PHANLOAITHELUC.MaPLTL " +
            "and YEAR(ThoiGian) = " + cbB_TL_Nam.Text +
            "and HOCVIEN.MaHocVien = N'" + frmLogin.maHV + "' order by ThoiGian asc";
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            sqlCon.Close();
            if (dtb.Rows.Count == 4)
            {
                foreach (DataRow dr in dtb.Rows)
                {
                    quy_1.Text = dr["TenPLTL"].ToString();
                    quy_2.Text = dr["TenPLTL"].ToString();
                    quy_3.Text = dr["TenPLTL"].ToString();
                    quy_4.Text = dr["TenPLTL"].ToString();

                }
                caNam.Text = Calculator.cal_TinhTheLucNam(quy_1.Text, quy_2.Text, quy_3.Text, quy_4.Text);
            }
            else
            {
                MessageBox.Show("Không đủ dữ liệu để hiển thị");
            }
            
        }


        private void KQTL_Nam_Load(object sender, EventArgs e)
        {
            connect();
        }

        private void cbB_TL_Nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            quy_1.Text = "";
            quy_2.Text = "";
            quy_3.Text = "";
            quy_4.Text = "";
            caNam.Text = "";
            
            connect();
        }
    }
}
