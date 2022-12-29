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
    public partial class usr_KQTL_Nam : UserControl
    {
        public usr_KQTL_Nam()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query;
        string MaHocVien;
        Calculator a = new Calculator();

        private void usr_KQTL_Nam_Load(object sender, EventArgs e)
        {
            HienComboBox();
            query = "select MaHocVien, TenHocVien, MaLop from HOCVIEN";
            connect(query);
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

        private void HienComboBox()
        {
            string constr = Data_Provider.connectionSTR;
            string Sql = "select DISTINCT Year(ThoiGian) from HOCVIEN_PLTL";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    cbbThoiGian.Items.Add(DR[0]);
                }
                DR.Close();
            }
        }

        private void HienText(string mahocvien)
        {
            int i = 1;
            string constr = Data_Provider.connectionSTR;
            string Sql = "select HOCVIEN.TenHocVien, HOCVIEN.MaLop, PHANLOAITHELUC.TenPLTL " +
                "from HOCVIEN, HOCVIEN_PLTL, KETQUATHELUC, PHANLOAITHELUC " +
                "where HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                "and HOCVIEN_PLTL.MaKQTL = KETQUATHELUC.MaKQTL " +
                "and KETQUATHELUC.MaPLTL = PHANLOAITHELUC.MaPLTL " +
                "and YEAR(ThoiGian) = 2022" +
                "and HOCVIEN.MaHocVien = N'" + mahocvien + "'";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    //cbbThoiGian.Items.Add(DR[0]);
                    txtHoTen.Text = DR["TenHocVien"].ToString();
                    txtLop.Text = DR["MaLop"].ToString();
                    if (i == 1)
                    {
                        txtQuy1.Text = DR["TenPLTL"].ToString();
                    }
                    else if (i == 2)
                    {
                        txtQuy2.Text = DR["TenPLTL"].ToString();
                    }
                    else if (i == 3)
                    {
                        txtQuy3.Text = DR["TenPLTL"].ToString();
                    }
                    else if (i == 4)
                    {
                        txtQuy4.Text = DR["TenPLTL"].ToString();
                    }
                    i++;
                }
                DR.Close();
            }
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MaHocVien = dtgv.SelectedRows[0].Cells[0].Value.ToString();
            HienText(MaHocVien);
            txtCaNam.Text = Calculator.cal_TinhTheLucNam(txtQuy1.Text, txtQuy2.Text, txtQuy3.Text, txtQuy4.Text);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            query = "select HOCVIEN.TenHocVien, HOCVIEN.MaLop, PHANLOAITHELUC.TenPLTL " +
                "from HOCVIEN, HOCVIEN_PLTL, KETQUATHELUC, PHANLOAITHELUC " +
                "where HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                "and HOCVIEN_PLTL.MaKQTL = KETQUATHELUC.MaKQTL " +
                "and KETQUATHELUC.MaPLTL = PHANLOAITHELUC.MaPLTL " +
                "and YEAR(ThoiGian) = " + cbbThoiGian.Text + "" +
                "and ";
            if (cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
            {
                connect(query + " 1 = 1");
            }
            else if (cbbMuc.Text == "Học viên")
            {
                connect(query + " HOCVIEN.TenHocVien LIKE N'%" + txtNoiDung.Text + "%'");
            }
            else if (cbbMuc.Text == "Lớp")
            {
                connect(query + " HOCVIEN.MaLop LIKE N'%" + txtNoiDung.Text + "%'");
            }
        }
    }
}
