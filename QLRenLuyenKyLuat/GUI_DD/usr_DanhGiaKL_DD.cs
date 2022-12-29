using QLRenLuyenKyLuat.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_DanhGiaKL_DD : UserControl
    {
        public usr_DanhGiaKL_DD()
        {
            InitializeComponent();
            check = date.ToString("MM").Trim() + date.ToString("yyyy").Trim();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query = "";
        DateTime date = DateTime.Now;
        string check;
        string MaHVPLRL = "";
        string MaDiemPLKL = "";
        string MaHV;

        private void CapNhat(string query)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }

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

        private void usr_DanhGiaKL_DD_Load(object sender, EventArgs e)
        {
            query = "select MaHocVien, TenHocVien, MaLop, GioiTinh from HocVien";
            connect(query);
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHoTen.Text = dtgv.SelectedRows[0].Cells[1].Value.ToString().Trim();
            txtLop.Text = dtgv.SelectedRows[0].Cells[2].Value.ToString().Trim();
            txtHT_L.Text = string.Empty;
            txtLS_L.Text = string.Empty;
            txtKL_L.Text = string.Empty;
            txtNhanXet_L.Text = string.Empty;
            string constr = Data_Provider.connectionSTR;
            string Sql = "select TenHocVien, MaLop, DIEM_PLKL.DiemKL, DIEM_PLKL.DiemHT, DIEM_PLKL.DiemLS, TenPhanLoai, NhanXet " +
                "from HOCVIEN, HocVien_PLRL, DIEM_PLKL, PHANLOAIKYLUAT " +
                "where HocVien.MaHocVien = HocVien_PLRL.MaHocVien " +
                "and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL " +
                "and DIEM_PLKL.MaPLKL = PHANLOAIKYLUAT.MaPLKL " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%L%' " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%" + check + "%' " +
                "and HocVien_PLRL.MaHocVien = '" + dtgv.SelectedRows[0].Cells[0].Value.ToString().Trim() + "'";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    //txtHoTen.Text = DR["TenHocVien"].ToString();
                    //txtLop.Text = DR["MaLop"].ToString();
                    txtKL_L.Text = DR["DiemKL"].ToString();
                    txtHT_L.Text = DR["DiemHT"].ToString();
                    txtLS_L.Text = DR["DiemLS"].ToString();
                    txtMucPhanLoai_L.Text = DR["TenPhanLoai"].ToString();
                    txtNhanXet_L.Text = DR["NhanXet"].ToString();
                }
                DR.Close();
                conn.Close();
            }

            MaHVPLRL = dtgv.SelectedRows[0].Cells[0].Value.ToString().Trim() + check.Trim() + "DD";
            MaDiemPLKL = dtgv.SelectedRows[0].Cells[0].Value.ToString().Trim() + "DKL" + check.Trim() + "DD";
            MaHV = dtgv.SelectedRows[0].Cells[0].Value.ToString().Trim();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select MaHocVien, TenHocVien, MaLop, GioiTinh, CapBac " +
                    "from HocVien " +
                    "where MaHocVien != ' ' " +
                    "and ";
                if (cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
                {
                    usr_DanhGiaKL_DD_Load(sender, e);
                }

                if (cbbMuc.Text == "Tên học viên")
                {
                    connect(query + " tenhocvien LIKE N'%" + txtNoiDung.Text + "%'");
                }
                else if (cbbMuc.Text == "Lớp")
                {
                    connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%'");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                query = "INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemLS], [DiemHT], [NhanXet], [CapDanhGia], [NguoiDanhGia], [MaPLKL]) " +
                    "VALUES (N'" + MaDiemPLKL + "', " + txtKL_DD + ", " + txtLS_L.Text + ", " + txtHT_L.Text + ", N'" + txtNhanXet_L.Text + "', N'D', N'" + frmLogin.maNguoiDung + "', N'" + txtMucPhanLoai_DD.Text + "')";
                CapNhat(query);
            }
            catch
            {
                MessageBox.Show("Lỗi ở bảng DIEM_PLKL");
            }
            try
            {
                query = "INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) " +
                    "VALUES (N'" + MaHVPLRL + "', CAST(N'" + date.ToString("yyyy-MM-dd") + "' AS Date), N'" + MaHV + "',N'" + MaDiemPLKL + "')";
                CapNhat(query);
                MessageBox.Show("Thêm thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi ở bảng HOCVIEN_PLRL");
            }
        }

        private void txtNhanXet_DD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNhanXet_DD.Text))
            {
                e.Cancel = true;
                txtNhanXet_DD.Focus();
                errorProvider1.SetError(txtNhanXet_DD, "Vui lòng cho nhận xét!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNhanXet_DD, null);
            }
        }
    }
}
