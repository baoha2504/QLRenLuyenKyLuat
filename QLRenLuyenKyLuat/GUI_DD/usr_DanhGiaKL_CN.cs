using QLRenLuyenKyLuat.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_DanhGiaKL_CN : UserControl
    {
        public usr_DanhGiaKL_CN()
        {
            InitializeComponent();
            check = date.ToString("MM").Trim() + date.ToString("yyyy").Trim();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query = "";
        DateTime date = DateTime.Now;
        string check;

        private void connect(string query)
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            dtgv.DataSource = dtb;
            dtgv.AutoGenerateColumns = false;
            dtgv.AllowUserToAddRows = false;
            dtgv.AutoResizeColumns();
            sqlCon.Close();
        }

        private void usr_DanhGiaKL_CN_Load(object sender, EventArgs e)
        {
            //check = date.ToString("MM").Trim() + date.ToString("yyyy").Trim();
            query = "select HOCVIEN.MaHocVien AS 'Mã học viên', TenHocVien AS 'Tên học viên' , MaLop AS 'Mã lớp', DIEM_PLKL.DiemKL AS 'Điểm kỷ luật', DIEM_PLKL.DiemHT AS 'Điểm học tập', DIEM_PLKL.DiemLS AS 'Điểm lối sống', TenPhanLoai AS 'Tên phân loại' " +
                "from HOCVIEN, HocVien_PLRL, DIEM_PLKL, PHANLOAIKYLUAT " +
                "where HocVien.MaHocVien = HocVien_PLRL.MaHocVien " +
                "and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL " +
                "and DIEM_PLKL.MaPLKL = PHANLOAIKYLUAT.MaPLKL " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%CN%' " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%" + check + "%' "; //+
                                                                    //"and HocVien_PLRL.MaHocVien = '" + MaHV + "'";
            connect(query);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            query = "select HOCVIEN.MaHocVien AS 'Mã học viên', TenHocVien AS 'Tên học viên' , MaLop AS 'Mã lớp', DIEM_PLKL.DiemKL AS 'Điểm kỷ luật', DIEM_PLKL.DiemHT AS 'Điểm học tập', DIEM_PLKL.DiemLS AS 'Điểm lối sống', TenPhanLoai AS 'Tên phân loại' " +
                "from HOCVIEN, HocVien_PLRL, DIEM_PLKL, PHANLOAIKYLUAT " +
                "where HocVien.MaHocVien = HocVien_PLRL.MaHocVien " +
                "and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL " +
                "and DIEM_PLKL.MaPLKL = PHANLOAIKYLUAT.MaPLKL " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%CN%' " +
                "and ";
            try
            {
                if (cbbMuc.Text == "Tên học viên")
                {
                    query += " tenhocvien LIKE N'%" + txtNoiDung.Text + "%' and ";
                }
                else if (cbbMuc.Text == "Lớp")
                {
                    query += " malop LIKE N'%" + txtNoiDung.Text + "%' and ";
                } 

                if (/*cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty && */(cbbThang.Text == string.Empty || cbbNam.Text == string.Empty))
                {
                    check = date.ToString("MM").Trim() + date.ToString("yyyy").Trim();
                    query += " DIEM_PLKL.MaDiemPLKL LIKE '%" + check + "%' ";
                    connect(query);
                }
                else if (/*cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty && */ (cbbThang.Text != string.Empty && cbbNam.Text != string.Empty))
                {
                    check = cbbThang.Text.Trim() + cbbNam.Text.Trim();
                    query += " DIEM_PLKL.MaDiemPLKL LIKE '%" + check + "%' ";
                    connect(query);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}
