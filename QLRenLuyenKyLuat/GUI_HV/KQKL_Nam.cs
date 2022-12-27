using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLRenLuyenKyLuat.Data;

namespace QLRenLuyenKyLuat.GUI_HV
{
    public partial class KQKL_Nam : DevExpress.XtraEditors.XtraUserControl
    {
        
        //maHV = txtLoginMaHV.Text.Trim();
        public KQKL_Nam()
        {
            InitializeComponent();
            cbB_KL_Nam.Text = "2021-2022";
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string MaHV = frmLogin.maNguoiDung;
        string TenHV = frmLogin.name;
        //SqlDataReader dr;

        string t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12;
        string[] kqhk1 = new string[10];
        string[] kqhk2 = new string[10];
        string KetQuaHK1, KetQuaHK2;
        int i, j;


        private void FindCheckHK(string date)
        {
            if (date == "2019-2020") // nam 1
            {
                t1 = "082019";
                t2 = "092019";
                t3 = "102019";
                t4 = "112019";
                t5 = "122019";
                t6 = "012020";
                t7 = "022020";
                t8 = "032020";
                t9 = "042020";
                t10 = "052020";
                t11 = "062020";
                t12 = "072020";
            }
            else if (date == "2020-2021") // nam 2
            {
                t1 = "082020";
                t2 = "092020";
                t3 = "102020";
                t4 = "112020";
                t5 = "122020";
                t6 = "012021";
                t7 = "022021";
                t8 = "032021";
                t9 = "042021";
                t10 = "052021";
                t11 = "062021";
                t12 = "072021";
            }

            else if (date == "2021-2022") // nam 3
            {
                t1 = "082021";
                t2 = "092021";
                t3 = "102021";
                t4 = "112021";
                t5 = "122021";
                t6 = "012022";
                t7 = "022022";
                t8 = "032022";
                t9 = "042022";
                t10 = "052022";
                t11 = "062022";
                t12 = "072022";
            }
            else if (date == "2022-2023") // nam 4
            {
                t1 = "082022";
                t2 = "092022";
                t3 = "102022";
                t4 = "112022";
                t5 = "122022";
                t6 = "012023";
                t7 = "022023";
                t8 = "032023";
                t9 = "042023";
                t10 = "052023";
                t11 = "062023";
                t12 = "072023";
            }

            else if (date == "2023-2024") // nam 5
            {
                t1 = "082023";
                t2 = "092023";
                t3 = "102023";
                t4 = "112023";
                t5 = "122023";
                t6 = "012024";
                t7 = "022024";
                t8 = "032024";
                t9 = "042024";
                t10 = "052024";
                t11 = "062024";
                t12 = "062024";
            }
        }


        private void connect()
        {
            string query = "select  MaPLKL, NhanXet " +
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
            string query1 = "select  MaPLKL, NhanXet " +
                "from HOCVIEN, HocVien_PLRL, DIEM_PLKL " +
                "where HocVien.MaHocVien = HocVien_PLRL.MaHocVien " +
                "and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%DD%' " +
                "and (DIEM_PLKL.MaDiemPLKL LIKE '%" + t7 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t8 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t9 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t10 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t11 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t12 + "%') " +
                "and HocVien_PLRL.MaHocVien = '" + MaHV.Trim() + "'";

            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            sqlCon.Close();
            if (dtb.Rows.Count == 6)
            {
                foreach (DataRow dr in dtb.Rows)
                {
                    kqhk1[i] = dr["MaPLKL"].ToString();
                    txt_NX.Text = dr["NhanXet"].ToString();
                }
                KetQuaHK1 = Calculator.cal_DiemRLHocKy(kqhk1[0], kqhk1[1], kqhk1[2], kqhk1[3], kqhk1[4], kqhk1[5]);
            }

            sqlCon.Open();
            SqlDataAdapter sqlDa1 = new SqlDataAdapter(query1, sqlCon);
            DataTable dtb1 = new DataTable();
            sqlDa1.Fill(dtb1);
            sqlCon.Close();
            if (dtb.Rows.Count == 6)
            {
                foreach (DataRow dr in dtb.Rows)
                {
                    kqhk1[i] = dr["MaPLKL"].ToString();
                    txt_NX.Text = dr["NhanXet"].ToString();
                }
                KetQuaHK2 = Calculator.cal_DiemRLHocKy(kqhk1[0], kqhk1[1], kqhk1[2], kqhk1[3], kqhk1[4], kqhk1[5]);
            }

            if (dtb.Rows.Count == 6 && dtb1.Rows.Count == 6)
            {
                txt_PL.Text = Calculator.cal_DiemRLNam(KetQuaHK1, KetQuaHK2);
            }
            else
            {
                MessageBox.Show("Không đủ dữ liệu để xét rèn năm "+cbB_KL_Nam.Text.ToString()+" của học viên " + TenHV.Trim(), "Thông báo");
                txt_PL.Text = "Chưa đủ dữ liệu";
                txt_NX.Text = "Chưa đủ dữ liệu";
            }

        }
        private void KQKL_Nam_Load(object sender, EventArgs e)
        {
            cbB_KL_Nam.Text = "2021-2022";
            string date = cbB_KL_Nam.Text.ToString();
            FindCheckHK(date);
            connect();
        }

        private void cbB_KL_Nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_NX.Clear();
            txt_PL.Clear();
            string date = cbB_KL_Nam.Text.ToString();
            FindCheckHK(date);
            connect();
           
        }
    }
}

