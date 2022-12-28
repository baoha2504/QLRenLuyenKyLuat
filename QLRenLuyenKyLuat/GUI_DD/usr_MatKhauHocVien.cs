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
    public partial class usr_MatKhauHocVien : UserControl
    {
        public usr_MatKhauHocVien()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);

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
        private void CapNhat(string query)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        private void usr_MatKhauHocVien_Load(object sender, EventArgs e)
        {
            string query = "Select MaHocVien, TenHocVien, GioiTinh, MaLop from HocVien";
            connect(query);
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHV.Text = dtgv.SelectedRows[0].Cells[0].Value.ToString();
            txtTenHV.Text = dtgv.SelectedRows[0].Cells[1].Value.ToString();
            txtGT.Text = dtgv.SelectedRows[0].Cells[2].Value.ToString();
            txtMaLop.Text = dtgv.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "Select MaHocVien, TenHocVien, GioiTinh, MaLop from HocVien where";
            if (cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
            {
                connect(query + " 1 = 1");
            }

            if (cbbMuc.Text == "Mã học viên")
            {
                connect(query + " mahocvien LIKE N'%" + txtNoiDung.Text + "%'");
            }
            else if (cbbMuc.Text == "Tên học viên")
            {
                connect(query + " tenhocvien LIKE N'%" + txtNoiDung.Text + "%'");
            }
            else if (cbbMuc.Text == "Mã lớp")
            {
                connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%'");
            }
        }

        private void bthLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMKMoi.Text == txtNhapLaiMKMoi.Text)
                {
                    string query = "UPDATE HocVien" +
                    " Set MatKhau = N'" + txtMKMoi.Text + "' "
                   + " where MaHocVien = N'" + txtMaHV.Text + "'";
                    CapNhat(query);
                    MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMKMoi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMKMoi.Text))
            {
                e.Cancel = true;
                txtMKMoi.Focus();
                errorProvider1.SetError(txtMKMoi, "Vui lòng nhập mật khẩu.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMKMoi, null);
            }
        }

        private void txtNhapLaiMKMoi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNhapLaiMKMoi.Text))
            {
                e.Cancel = true;
                txtNhapLaiMKMoi.Focus();
                errorProvider1.SetError(txtNhapLaiMKMoi, "Vui lòng nhập mật khẩu.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNhapLaiMKMoi, null);
            }
        }
    }
}
