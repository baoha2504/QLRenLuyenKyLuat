using DevExpress.XtraEditors;
using System;
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

namespace QLRenLuyenKyLuat.GUI_LOP
{
    public partial class KQKL_Year : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query;
        string MaHocvien;
        public KQKL_Year()
        {
            InitializeComponent();
            query = "select MaHocVien as 'Mã học viên', TenHocVien as 'Họ và tên', GioiTinh as 'Giới tính', CapBac as 'Cấp bậc', ChucVu as 'Chức vụ' from HOCVIEN where maLop like N'%" + frmLogin.maLop.Trim() + "%'";
            connect(query);
        }
        private void connect(string query)
        {
            sqlCon.Close();
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            danhsach_KL_Year.DataSource = dtb;
            danhsach_KL_Year.AutoGenerateColumns = false;
            danhsach_KL_Year.AllowUserToAddRows = false;
            danhsach_KL_Year.AutoResizeColumns();
            sqlCon.Close();
        }
        public static string[] HK1 = new string[6];
        public static string[] HK2 = new string[6];
        private void HienThi(string mahocvien)
        {

            string constr = Data_Provider.connectionSTR;
            string Sql1, Sql2;
            if (cbBox_RLKL_Year.Text == "2021-2022")
            {
                Sql2 = "select HOCVIEN.TenHocVien,  MaPLKL, ThoiGian from HOCVIEN_PLRL, DIEM_PLKL, HOCVIEN" +
                    " where HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL  and HOCVIEN.MaHocVien = HOCVIEN_PLRL.MaHocVien and DIEM_PLKL.CapDanhGia like N'%D%'" +
                    " and ThoiGian between CAST(N'2022-2-1' AS Date) and CAST(N'2022-7-31' AS Date) " +
                    " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                Sql1 = "select HOCVIEN.TenHocVien,  MaPLKL, ThoiGian from HOCVIEN_PLRL, DIEM_PLKL, HOCVIEN" +
                    " where HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL  and HOCVIEN.MaHocVien = HOCVIEN_PLRL.MaHocVien and DIEM_PLKL.CapDanhGia like N'%D%'" +
                    " and ThoiGian between CAST(N'2021-08-1' AS Date) and CAST(N'2022-1-31' AS Date) " +
                    " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
            }
            else if (cbBox_RLKL_Year.Text == "2022-2023")
            {
                Sql2 = "select HOCVIEN.TenHocVien,  MaPLKL, ThoiGian from HOCVIEN_PLRL, DIEM_PLKL, HOCVIEN" +
                    " where HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL  and HOCVIEN.MaHocVien = HOCVIEN_PLRL.MaHocVien and DIEM_PLKL.CapDanhGia like N'%D%'" +
                    " and ThoiGian between CAST(N'2023-2-1' AS Date) and CAST(N'2023-7-31' AS Date) " +
                    " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                Sql1 = "select HOCVIEN.TenHocVien,  MaPLKL, ThoiGian from HOCVIEN_PLRL, DIEM_PLKL, HOCVIEN" +
                    " where HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL  and HOCVIEN.MaHocVien = HOCVIEN_PLRL.MaHocVien and DIEM_PLKL.CapDanhGia like N'%D%'" +
                    " and ThoiGian between CAST(N'2022-08-1' AS Date) and CAST(N'2023-1-31' AS Date) " +
                    " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
            }
            else if (cbBox_RLKL_Year.Text == "2023-2024")
            {
                Sql2 = "select HOCVIEN.TenHocVien,  MaPLKL, ThoiGian from HOCVIEN_PLRL, DIEM_PLKL, HOCVIEN" +
                    " where HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL  and HOCVIEN.MaHocVien = HOCVIEN_PLRL.MaHocVien and DIEM_PLKL.CapDanhGia like N'%D%'" +
                    " and ThoiGian between CAST(N'2024-2-1' AS Date) and CAST(N'2024-7-31' AS Date) " +
                    " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                Sql1 = "select HOCVIEN.TenHocVien,  MaPLKL, ThoiGian from HOCVIEN_PLRL, DIEM_PLKL, HOCVIEN" +
                    " where HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL  and HOCVIEN.MaHocVien = HOCVIEN_PLRL.MaHocVien and DIEM_PLKL.CapDanhGia like N'%D%'" +
                    " and ThoiGian between CAST(N'2023-08-1' AS Date) and CAST(N'2024-1-31' AS Date) " +
                    " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
            }
            else
            {
                Sql2 = "select HOCVIEN.TenHocVien,  MaPLKL, ThoiGian from HOCVIEN_PLRL, DIEM_PLKL, HOCVIEN" +
                    " where HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL  and HOCVIEN.MaHocVien = HOCVIEN_PLRL.MaHocVien and DIEM_PLKL.CapDanhGia like N'%D%'" +
                    " and ThoiGian between CAST(N'2025-2-1' AS Date) and CAST(N'2025-7-31' AS Date) " +
                    " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                Sql1 = "select HOCVIEN.TenHocVien,  MaPLKL, ThoiGian from HOCVIEN_PLRL, DIEM_PLKL, HOCVIEN" +
                    " where HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL  and HOCVIEN.MaHocVien = HOCVIEN_PLRL.MaHocVien and DIEM_PLKL.CapDanhGia like N'%D%'" +
                    " and ThoiGian between CAST(N'2024-08-1' AS Date) and CAST(N'2025-1-31' AS Date) " +
                    " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
            }
            SqlDataAdapter SqlHK1 = new SqlDataAdapter(Sql1, sqlCon);
            SqlDataAdapter SqlHK2 = new SqlDataAdapter(Sql2, sqlCon);

            DataTable dtHK1 = new DataTable();
            DataTable dtHK2 = new DataTable();
            SqlHK1.Fill(dtHK1);
            SqlHK2.Fill(dtHK2);

            for (int i = 0; i < dtHK1.Rows.Count; i++)
            {
                HK1[i] = dtHK1.Rows[i][1].ToString();
            }
            for (int i = 0; i < dtHK2.Rows.Count; i++)
            {
                HK2[i] = dtHK2.Rows[i][1].ToString();
            }
            string PhanloaiHk2 = Calculator.cal_DiemRLHocKy(HK2[0].Trim(), HK2[1].Trim(), HK2[2].Trim(), HK2[3].Trim(), HK2[4].Trim(), HK2[5].Trim());
            string PhanloaiHk1 = Calculator.cal_DiemRLHocKy(HK1[0].Trim(), HK1[1].Trim(), HK1[2].Trim(), HK1[3].Trim(), HK1[4].Trim(), HK1[5].Trim());
            string PhanloaiNam = Calculator.cal_DiemRLNam(PhanloaiHk1, PhanloaiHk2);
            txtBoxPLNam.Text = PhanloaiNam;
            
        }

        private void danhsach_KL_Year_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MaHocvien = danhsach_KL_Year.SelectedRows[0].Cells[0].Value.ToString();
            txtBoxTen.Text = danhsach_KL_Year.SelectedRows[0].Cells[1].Value.ToString();
            HienThi(MaHocvien);
        }
    }
}
