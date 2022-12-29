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
using System.Security.Cryptography;
using QLRenLuyenKyLuat.Data;
using System.Data.SqlClient;

namespace QLRenLuyenKyLuat.GUI_HV
{
    public partial class ThayDoiMatKhau : DevExpress.XtraEditors.XtraUserControl
    {
        public ThayDoiMatKhau()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);

        public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtPass.Focus();
            }
            else if (txtNewPass.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtNewPass.Focus();
            }
            else if (txtReNewPass.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu mới !", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtReNewPass.Focus();
            }
            else if (txtNewPass.Text != txtReNewPass.Text)
            {
                MessageBox.Show("Mật khẩu mới không trùng nhau", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtNewPass.Focus();
            }
            else if (ComputeSha256Hash(txtPass.Text) != frmLogin.hashPass)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại không chính xác", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtPass.Focus();
            }
            else
            {
                string query = "Update HOCVIEN set MatKhau = '" + ComputeSha256Hash(txtNewPass.Text) + "' where MaHocVien ='" + frmLogin.maNguoiDung + "'";
                sqlCon.Open();
                SqlCommand sqlDa = new SqlCommand(query, sqlCon);
                sqlDa.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
