using QLRenLuyenKyLuat.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_QCTheLuc : UserControl
    {
        public usr_QCTheLuc()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        DateTime date;
        private void HienComboBox()
        {
            string constr = Data_Provider.connectionSTR;
            string Sql = "select DISTINCT QUYCHUAN.ThoiGian from QUYCHUANTHELUC, QUYCHUAN where QUYCHUAN.MaQLQC = QUYCHUANTHELUC.MaQLQC";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    //cbbMuc.Items.Add(DR[0]);
                    date = DateTime.Parse(DR[0].ToString());
                    cbbMuc.Items.Add(date.ToString("dd-MM-yyyy"));
                }
                DR.Close();
                conn.Close();
            }
        }

        private void usr_QCTheLuc_Load(object sender, EventArgs e)
        {
            HienComboBox();
            radioNam.Checked = true;
            string query = "select Gioi, Kha, Dat, HoTen, ThoiGian " +
                "from QUYCHUANTHELUC, QUYCHUAN, QUANLY " +
                "where QUYCHUAN.MaQLQC = QUYCHUANTHELUC.MaQLQC " +
                "and QUYCHUAN.NguoiSuaDoi = QUANLY.MaQL " +
                "and NoiDung LIKE N'%nam%' " +
                "and QUYCHUAN.ThoiGian = '" + date.ToString("yyyy-MM-dd") + "' " +
                "order by (NoiDung)";
            connect(query);
        }


        private void connect(string query)
        {
            string[] s1 = new string[10];
            string[] s2 = new string[10];
            string[] s3 = new string[10];
            string s4 = "";
            string s5 = "";
            int i;
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            i = 0;
            foreach (DataRow row in dtb.Rows)
            {
                s1[i] = row["Gioi"].ToString();
                s2[i] = row["Kha"].ToString();
                s3[i] = row["Dat"].ToString();
                s4 = row["HoTen"].ToString();
                s5 = row["ThoiGian"].ToString();
                i++;
            }

            txtNguoiThayDoi.Text = s4;
            txtThoiGianThayDoi.Text = s5;

            txt1_1.Text = s1[0];
            txt1_2.Text = s2[0];
            txt1_3.Text = s3[0];

            txt2_1.Text = s1[1];
            txt2_2.Text = s2[1];
            txt2_3.Text = s3[1];

            txt3_1.Text = s1[2];
            txt3_2.Text = s2[2];
            txt3_3.Text = s3[2];

            txt4_1.Text = s1[3];
            txt4_2.Text = s2[3];
            txt4_3.Text = s3[3];

            txt5_1.Text = s1[4];
            txt5_2.Text = s2[4];
            txt5_3.Text = s3[4];


            sqlCon.Close();
        }

        private void radioNu_CheckedChanged(object sender, EventArgs e)
        {
            string query = "select Gioi, Kha, Dat, HoTen, ThoiGian " +
                "from QUYCHUANTHELUC, QUYCHUAN, QUANLY " +
                "where QUYCHUAN.MaQLQC = QUYCHUANTHELUC.MaQLQC " +
                "and QUYCHUAN.NguoiSuaDoi = QUANLY.MaQL " +
                "and NoiDung LIKE N'%nữ%' " +
                "and QUYCHUAN.ThoiGian = '" + cbbMuc.Text + "' " +
                "order by (NoiDung)";
            connect(query);
        }

        private void radioNam_CheckedChanged(object sender, EventArgs e)
        {
            string query = "select Gioi, Kha, Dat, HoTen, ThoiGian " +
                "from QUYCHUANTHELUC, QUYCHUAN, QUANLY " +
                "where QUYCHUAN.MaQLQC = QUYCHUANTHELUC.MaQLQC " +
                "and QUYCHUAN.NguoiSuaDoi = QUANLY.MaQL " +
                "and NoiDung LIKE N'%nam%' " +
                "and QUYCHUAN.ThoiGian = '" + cbbMuc.Text + "' " +
                "order by (NoiDung)";
            connect(query);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if(radioNam.Checked == true)
            {
                radioNam_CheckedChanged(sender, e);
            } else
            {
                radioNu_CheckedChanged(sender, e);
            }
        }
    }
}
