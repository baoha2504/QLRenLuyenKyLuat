using QLRenLuyenKyLuat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLRenLuyenKyLuat.Data;

namespace QLRenLuyenKyLuat.GUI_LOP
{

    public partial class KQKL_Month : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query;
        public KQKL_Month()
        {
            InitializeComponent();
            query = "select MaHocVien as 'Mã học viên', TenHocVien as 'Họ và tên', GioiTinh as 'Giới tính', CapBac as 'Cấp bậc', ChucVu as 'Chức vụ' from HOCVIEN where maLop like N'%" + frmLogin.maNguoiDung.Trim() + "%'";
            connect(query);
        }
        private void connect(string query)
        {
            sqlCon.Close();
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            danhsach_KL_month.DataSource = dtb;
            danhsach_KL_month.AutoGenerateColumns = false;
            danhsach_KL_month.AllowUserToAddRows = false;
            danhsach_KL_month.AutoResizeColumns();
            sqlCon.Close();
        }
        string Mahocvien, Thang, Nam;
        private void HienThiText(string mahocvien, string month, string year)
        {
            string constr = Data_Provider.connectionSTR;
            string Sql;
            Sql = "select HOCVIEN.TenHocVien, DiemKL, DiemLS, DiemHT, PHANLOAIKYLUAT.TenPhanLoai, NhanXet, QUANLY.HoTen, ThoiGian " +
                " from HOCVIEN_PLRL, DIEM_PLKL, HOCVIEN, PHANLOAIKYLUAT, QUANLY " +
                " where HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL "+
                " and QUANLY.MaQL = NguoiDanhGia "+
                " and DIEM_PLKL.MaPLKL = PHANLOAIKYLUAT.MaPLKL " +
                " and HOCVIEN.MaHocVien = HOCVIEN_PLRL.MaHocVien "+
                " and DIEM_PLKL.CapDanhGia like N'%D%' and MONTH(HOCVIEN_PLRL.ThoiGian) = " + int.Parse(month)+
                " and Year(HOCVIEN_PLRL.ThoiGian) = " + int.Parse(year)+
                " and HOCVIEN.MaHocVien = N'"+ mahocvien.Trim()+"'";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {

                    txtBoxTen.Text = DR["TenHocVien"].ToString();
                    txtBox_DKL.Text = DR["DiemKL"].ToString();
                    txtBox_DLS.Text = DR["DiemLS"].ToString();
                    txtbox_DHT.Text = DR["DiemHT"].ToString();
                    txtBox_PL.Text = DR["TenPhanLoai"].ToString();
                    txtBox_Nhanxet.Text = DR["NhanXet"].ToString();
                    txtbox_NgKL.Text = DR["HoTen"].ToString();

                }
                DR.Close();
            }
        }

        private void danhsach_KL_month_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(cbBox_Month.Text) && string.IsNullOrEmpty(cbb_Nam.Text))
            {
                MessageBox.Show("Vui lòng chọn năm học và tháng.", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                Mahocvien = danhsach_KL_month.SelectedRows[0].Cells[0].Value.ToString();
                Thang = cbBox_Month.Text;
                Nam = cbb_Nam.Text;
                HienThiText(Mahocvien, Thang, Nam);
            }      
        }
    }
}
