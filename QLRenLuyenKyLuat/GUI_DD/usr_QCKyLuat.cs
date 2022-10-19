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
    public partial class usr_QCKyLuat : UserControl
    {
        public usr_QCKyLuat()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        private string thoigiancuoi = "";
        private void HienComboBox()
        {
            string constr = Data_Provider.connectionSTR;
            string Sql = "select DISTINCT QUYCHUAN.ThoiGian from QUYCHUANKYLUAT, QUYCHUAN where QUYCHUAN.MaQLQC = QUYCHUANKYLUAT.MaQLQC";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    cbbMuc.Items.Add(DR[0]);
                    thoigiancuoi = DR[0].ToString();
                }
                DR.Close();
            }
        }

        private void connect(string query)
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            
            string[] s1 = new string[10];
            string[] s2 = new string[10];
            string[] s3 = new string[10];
            string[] s4 = new string[10];
            string s5 = "";
            string s6 = "";
            int i = 0;
            foreach (DataRow row in dtb.Rows)
            {
                s1[i] = row["NoiDung"].ToString();
                s2[i] = row["Muc1"].ToString();
                s3[i] = row["Muc2"].ToString();
                s4[i] = row["Muc3"].ToString();
                s5 = row["ThoiGian"].ToString();
                s6 = row["HoTen"].ToString();
                i++;
            }

            txtNguoiThayDoi.Text = s5;
            txtThoiGianThayDoi.Text = s6;

            txtTC1.Text = s1[0];
            txtMuc1_1.Text = s2[0];
            txtMuc1_2.Text = s3[0];
            txtMuc1_3.Text = s4[0];

            txtTC2.Text = s1[1];
            txtMuc2_1.Text = s2[1];
            txtMuc2_2.Text = s3[1];
            txtMuc2_3.Text = s4[1];

            txtTC3.Text = s1[2];
            txtMuc3_1.Text = s2[2];
            txtMuc3_2.Text = s3[2];
            txtMuc3_3.Text = s4[2];

            sqlCon.Close();
        }

        private void usr_QCKyLuat_Load(object sender, EventArgs e)
        {
            HienComboBox();
            string query = "select NoiDung, Muc1, Muc2, Muc3, ThoiGian, HoTen " +
                "from QUYCHUANKYLUAT, QUYCHUAN, QUANLY " +
                "where QUYCHUAN.MaQLQC = QUYCHUANKYLUAT.MaQLQC and QUYCHUAN.NguoiSuaDoi = QUANLY.MaQL and " +
                "QUYCHUAN.ThoiGian = '" + thoigiancuoi + "'";
            connect(query);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string query = "select NoiDung, Muc1, Muc2, Muc3, ThoiGian, HoTen " +
                "from QUYCHUANKYLUAT, QUYCHUAN, QUANLY " +
                "where QUYCHUAN.MaQLQC = QUYCHUANKYLUAT.MaQLQC and QUYCHUAN.NguoiSuaDoi = QUANLY.MaQL and " +
                "QUYCHUAN.ThoiGian = '" + cbbMuc.Text + "'";
            connect(query);
        }
    }
}
