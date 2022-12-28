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

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_SuaDanhGia : UserControl
    {
        public usr_SuaDanhGia()
        {
            InitializeComponent();
            check = date.ToString("MM").Trim() + date.ToString("yyyy").Trim();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query = "";
        DateTime date = DateTime.Now;
        string check;
        string MaDiemPLKL;

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

        private void usr_SuaDanhGia_Load(object sender, EventArgs e)
        {
            query = "select MaHocVien, TenHocVien, MaLop, GioiTinh from HocVien";
            connect(query);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select MaHocVien, TenHocVien, MaLop, GioiTinh, CapBac, ChucVu " +
                    "from HocVien " +
                    "where MaHocVien != ' ' " +
                    "and ";
                if (cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
                {
                    usr_SuaDanhGia_Load(sender, e);
                }

                if (cbbMuc.Text == "Tên học viên")
                {
                    connect(query + " tenhocvien LIKE N'%" + txtNoiDung.Text + "%'");
                }
                else if (cbbMuc.Text == "Lớp")
                {
                    connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%'");
                }
                check = cbbThang.Text.Trim() + cbbNam.Text.Trim();
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
                query = "UPDATE [DIEM_PLKL] " +
                    "set DiemKL = " + txtKL.Text.Trim() + ", DiemHT = " + txtHT.Text.Trim() + ", DiemLS = " + txtLS.Text.Trim() + ", NhanXet = N'" + txtNhanXet.Text + "', MaPLKL = N'" + txtMucDanhGia.Text + "' " +
                    "where MaDiemPLKL = N'" + MaDiemPLKL + "'";
                CapNhat(query);
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }

        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHoTen.Text = dtgv.SelectedRows[0].Cells[1].Value.ToString().Trim();
            txtLop.Text = dtgv.SelectedRows[0].Cells[2].Value.ToString().Trim();
            txtKL.Text = string.Empty;
            txtHT.Text = string.Empty;
            txtLS.Text = string.Empty;
            txtMucDanhGia.Text = string.Empty;
            txtNhanXet.Text = string.Empty;
            MaDiemPLKL = dtgv.SelectedRows[0].Cells[0].Value.ToString().Trim() + "DKL" + check + "DD" ;
            string constr = Data_Provider.connectionSTR;
            string Sql = "select TenHocVien, MaLop, DIEM_PLKL.DiemKL, DIEM_PLKL.DiemHT, DIEM_PLKL.DiemLS, PHANLOAIKYLUAT.MaPLKL, TenPhanLoai, NhanXet " +
                "from HOCVIEN, HocVien_PLRL, DIEM_PLKL, PHANLOAIKYLUAT " +
                "where HocVien.MaHocVien = HocVien_PLRL.MaHocVien " +
                "and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL " +
                "and DIEM_PLKL.MaPLKL = PHANLOAIKYLUAT.MaPLKL " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%DD%' " +
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
                    txtKL.Text = DR["DiemKL"].ToString();
                    txtHT.Text = DR["DiemHT"].ToString();
                    txtLS.Text = DR["DiemLS"].ToString();
                    txtMucDanhGia.Text = DR["MaPLKL"].ToString();
                    txtNhanXet.Text = DR["NhanXet"].ToString();
                }
                DR.Close();
                conn.Close();
            }
        }

        private void txtNhanXet_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNhanXet.Text))
            {
                e.Cancel = true;
                txtNhanXet.Focus();
                errorProvider1.SetError(txtNhanXet, "Vui lòng nhập nhận xét.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNhanXet, null);
            }
        }
    }
}
