using QLRenLuyenKyLuat.Data;  //Để dùng Data_Provider
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; //Để dùng SqlConnection
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_HV
{
    public partial class KQKL_HK : DevExpress.XtraEditors.XtraUserControl
    {
        public KQKL_HK()
        {
            InitializeComponent();
            //cbbHK.Text = "HK1 2022-2023";
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
       
        string query = "";
        string MaHV = frmLogin.maNguoiDung;
        string TenHV = frmLogin.name;
        string t1, t2, t3, t4, t5, t6;
        string[] kq = new string[10];
        int i;


        private void KQKL_HK_Load(object sender, EventArgs e)
        {
            txt_Ten.Text = TenHV;
            txt_Lop.Text = frmLogin.lop;
            txt_NX.Text = string.Empty;
            txt_PL.Text = string.Empty;
        }

        private void FindCheck(string date)
        {
            if (date == "HK1 2021-2022") // nam 3
            {
                t1 = "082021";
                t2 = "092021";
                t3 = "102021";
                t4 = "112021";
                t5 = "122021";
                t6 = "012022";
            }
            else if (date == "HK2 2021-2022")
            {
                t1 = "022022";
                t2 = "032022";
                t3 = "042022";
                t4 = "052022";
                t5 = "062022";
                t6 = "072022";
            }
            else if (date == "HK1 2022-2023") // nam 4
            {
                t1 = "082022";
                t2 = "092022";
                t3 = "102022";
                t4 = "112022";
                t5 = "122022";
                t6 = "012023";
            }
            else if (date == "HK2 2022-2023")
            {
                t1 = "022023";
                t2 = "032023";
                t3 = "042023";
                t4 = "052023";
                t5 = "062023";
                t6 = "072023";
            }
            
            
        }
      

        private void cbbHK_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlCon.Open();
            string date = cbbHK.Text.ToString();

            FindCheck(date);
            query = "select  MaPLKL, NhanXet " +
                    "from HOCVIEN, HocVien_PLRL, DIEM_PLKL " +
                    "where HocVien.MaHocVien = HocVien_PLRL.MaHocVien " +
                    "and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL " +
                    "and DIEM_PLKL.MaDiemPLKL LIKE '%DD%' " +
                    "and (DIEM_PLKL.MaDiemPLKL LIKE '%" + t1 + "%' " +
                    "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t2 + "%' " +
                    "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t3 + "%' " +
                    "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t4 + "%' " +
                    "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t5 + "%' " +
                    "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t6 + "%') " +
                    "and HocVien_PLRL.MaHocVien = '" + MaHV.Trim() + "'"; 
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            sqlCon.Close();
            if (dtb.Rows.Count == 6)
            {
                foreach (DataRow dr in dtb.Rows)
                {
                    txt_NX.Text = dr["NhanXet"].ToString();
                }
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    kq[i] = dtb.Rows[i][0].ToString();
                }
                string text = Calculator.cal_DiemRLHocKy(kq[0].Trim(), kq[1].Trim(), kq[2].Trim(), kq[3].Trim(), kq[4].Trim(), kq[5].Trim());
                txt_PL.Text = text;
                
            }
            else
            {
                MessageBox.Show("Không đủ dữ liệu để xét rèn luyện học kỳ của học viên " + TenHV.Trim(), "Thông báo");
                txt_PL.Text = "Chưa đủ dữ liệu";
                txt_NX.Text = "Chưa đủ dữ liệu"; 
            }
        }
    }

}
