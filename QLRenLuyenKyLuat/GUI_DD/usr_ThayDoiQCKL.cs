using QLRenLuyenKyLuat.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_ThayDoiQCKL : UserControl
    {
        public usr_ThayDoiQCKL()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        private string MaQLQC = "";
        private string MaQC = "";

        private void CapNhat(string query)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        private void LayMaThemVao()
        {
            string constr = Data_Provider.connectionSTR;
            string Sql;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                Sql = "select [dbo].[auto_maQC]()";
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    MaQLQC = DR[0].ToString();
                }
                DR.Close();
                conn.Close();

                conn.Open();
                Sql = "select [dbo].[auto_maQCKL]()";
                SqlCommand cmd1 = new SqlCommand(Sql, conn);
                SqlDataReader DR1 = cmd1.ExecuteReader();

                while (DR1.Read())
                {
                    MaQC = DR1[0].ToString();
                }
                DR1.Close();
                conn.Close();
            }
        }

        private void usr_ThayDoiQCKL_Load(object sender, EventArgs e)
        {
            LayMaThemVao();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có bạn thật sự muốn thay đổi", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            string query = "";
            string[] s1 = new string[10];
            string[] s2 = new string[10];
            string[] s3 = new string[10];
            string[] s4 = new string[10];
            string s5 = frmLogin.maNguoiDung;

            s1[0] = txtTC1.Text;
            s2[0] = txtMuc11.Text;
            s3[0] = txtMuc12.Text;
            s4[0] = txtMuc11.Text;

            s1[1] = txtTC2.Text;
            s2[1] = txtMuc21.Text;
            s3[1] = txtMuc22.Text;
            s4[1] = txtMuc21.Text;

            s1[2] = txtTC3.Text;
            s2[2] = txtMuc31.Text;
            s3[2] = txtMuc32.Text;
            s4[2] = txtMuc31.Text;

            //query = "INSERT [dbo].[QUYCHUAN] ([MaQLQC], [ThoiGian], [NguoiSuaDoi]) " +
            //    "VALUES (N'" + MaQLQC + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', N' " + s5 + " ')";
            query = "INSERT [dbo].[QUYCHUAN] ([MaQLQC], [ThoiGian], [NguoiSuaDoi]) " +
                "VALUES (N'" + MaQLQC + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', N'" + s5 + "')";
            CapNhat(query);


            for (int i = 0; i < 3; i++)
            {
                query = "INSERT [dbo].[QUYCHUANKYLUAT] ([MaQC], [NoiDung], [Muc1], [Muc2], [Muc3], [MaQLQC]) " +
                    "VALUES (N'" + MaQC + "', N'" + s1[i] + "', " + s2[i] + ", " + s3[i] + ", " + s4[i] + ", N'" + MaQLQC + "')";
                CapNhat(query);
            }
            MessageBox.Show("Thêm thành công quy chuẩn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
