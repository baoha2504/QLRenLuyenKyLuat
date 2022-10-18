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
    public partial class usr_ThemLop : UserControl
    {
        public usr_ThemLop()
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

        private void MaDaiDoi()
        {
            string constr = Data_Provider.connectionSTR;
            string Sql = "select MaDaiDoi from DaiDoi";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    txtMaDD.Text = DR[0].ToString();
                }
                DR.Close();
            }
        }

        private void usr_ThemLop_Load(object sender, EventArgs e)
        {
            MaDaiDoi();
        }

        private void bthAdd_Click(object sender, EventArgs e)
        {
            try 
            {
                if (txtMK.Text == txtNhapLaiMK.Text)
                {
                    string query = "INSERT [dbo].[LOP] ([MaLop], [TenLop], [MaDaiDoi], [MatKhau]) VALUES (N'" + txtMaLop.Text + "', N'" + txtTenLop.Text + "', N'" + txtMaDD.Text + "', N'" + txtMK.Text + "')";
                    CapNhat(query);
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Kiểm tra lại mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch 
            {
                MessageBox.Show("Kiểm tra lại thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bthRefesh_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = string.Empty; 
            txtTenLop.Text = string.Empty;
            txtMK.Text = string.Empty;
            txtNhapLaiMK.Text = string.Empty;
        }
    }
}
