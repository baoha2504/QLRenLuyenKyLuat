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

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_ThemHocVien : UserControl
    {
        public usr_ThemHocVien()
        {
            InitializeComponent();

        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);


        private void CapNhat(string query)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        private void MaTuDong()
        {
            string constr = Data_Provider.connectionSTR;
            string Sql = "select [dbo].[auto_maHV]()";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    txtMaHV.Text = DR[0].ToString();
                }
                DR.Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MaTuDong();
            txtTenHV.Text = String.Empty;
            txtGT.Text = String.Empty;
            txtCapBac.Text = String.Empty;
            txtChucVu.Text = String.Empty;
            cbMaLop.Text = String.Empty;
            txtMatKhau.Text = String.Empty;
            txtNhapLaiMK.Text = String.Empty;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhau.Text == txtNhapLaiMK.Text)
                {
                    string query = "INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau]) VALUES (N'" + txtMaHV.Text + "', N'" + txtTenHV.Text + "', N'" + txtGT.Text + "', N'" + txtCapBac.Text + "', N'" + txtChucVu.Text + "', N'" + cbMaLop.Text + "','" + txtMatKhau.Text + "')";
                    CapNhat(query);
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Kiểm tra lại mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usr_ThemHocVien_Load(object sender, EventArgs e)
        {
            MaTuDong();
            string constr = Data_Provider.connectionSTR;
            string Sql = "select malop from lop";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    cbMaLop.Items.Add(DR[0]);
                }
                DR.Close();
            }
        }
    }
}
