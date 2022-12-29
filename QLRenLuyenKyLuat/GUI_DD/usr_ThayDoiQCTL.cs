using QLRenLuyenKyLuat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_ThayDoiQCTL : UserControl
    {
        public usr_ThayDoiQCTL()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        private string MaQLQC;
        private string MaQC;
        private string query;

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
                Sql = "select [dbo].[auto_maQCTL]()";
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có bạn thật sự muốn thay đổi", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            string NoiDung = "";
            string DonVi = "";
            string[] s1 = new string[10];
            string[] s2 = new string[10];
            string[] s3 = new string[10];
            string s4 = frmLogin.maNguoiDung;
            string s5 = DateTime.Now.ToString("yyyy-MM-dd");

            s1[0] = txt1_1.Text;
            s2[0] = txt1_2.Text;
            s3[0] = txt1_3.Text;
            s1[1] = txt2_1.Text;
            s2[1] = txt2_2.Text;
            s3[1] = txt2_3.Text;
            s1[2] = txt3_1.Text;
            s2[2] = txt3_2.Text;
            s3[2] = txt3_3.Text;
            s1[3] = txt4_1.Text;
            s2[3] = txt4_2.Text;
            s3[3] = txt4_3.Text;
            s1[4] = txt5_1.Text;
            s2[4] = txt5_2.Text;
            s3[4] = txt5_3.Text;

            query = "INSERT [dbo].[QUYCHUAN] ([MaQLQC], [ThoiGian], [NguoiSuaDoi]) " +
                "VALUES (N'" + MaQLQC + "', '" + s5 + "', N'" + s4 + "')";
            CapNhat(query);

            if (radioNam.Checked == true)
            {
                for(int i = 0; i < 5; i++)
                {
                    if(i == 0)
                    {
                        NoiDung = "Bật xa nam";
                        DonVi = "mét";
                    } else if (i ==1)
                    {
                        NoiDung = "Bơi nam nữ";
                        DonVi = "mét";
                    }
                    else if (i == 2)
                    {
                        NoiDung = "Chạy dài nam";
                        DonVi = "phút";
                    }
                    else if (i == 3)
                    {
                        NoiDung = "Chạy ngắn nam";
                        DonVi = "giây";
                    }
                    else if (i == 4)
                    {
                        NoiDung = "Xà nam";
                        DonVi = "cái";
                    }
                    query = "INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) " +
                        "VALUES (N'" + MaQC + "', N'" + NoiDung +"', N'" + DonVi + "', N'" + s1[i] + "', N'" + s2[i] + "', N'" + s3[i] + "', N'" + MaQLQC + "')";
                    CapNhat(query);
                }
            } else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        NoiDung = "Bật xa nữ";
                        DonVi = "mét";
                    }
                    else if (i == 1)
                    {
                        NoiDung = "Bơi nam nữ";
                        DonVi = "mét";
                    }
                    else if (i == 2)
                    {
                        NoiDung = "Chạy dài nữ";
                        DonVi = "phút";
                    }
                    else if (i == 3)
                    {
                        NoiDung = "Chạy ngắn nữ";
                        DonVi = "giây";
                    }
                    else if (i == 4)
                    {
                        NoiDung = "Chống đẩy nữ";
                        DonVi = "cái";
                    }
                    query = "INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) " +
                        "VALUES (N'" + MaQC + "', N'" + NoiDung + "', N'" + DonVi + "', N'" + s1[i] + "', N'" + s2[i] + "', N'" + s3[i] + "', N'" + MaQLQC + "')";
                    CapNhat(query);
                }
            }
            MessageBox.Show("Thêm thành công quy chuẩn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void usr_ThayDoiQCTL_Load(object sender, EventArgs e)
        {
            radioNam.Checked = true;
            LayMaThemVao();
        }

        private void txt3_1_Click(object sender, EventArgs e)
        {
            //txt3_1.Text = string.Empty;
        }

        private void txt3_2_Click(object sender, EventArgs e)
        {
            //txt3_2.Text = string.Empty;
        }

        private void txt3_3_Click(object sender, EventArgs e)
        {
            //txt3_3.Text = string.Empty;
        }

        private void txt4_1_Click(object sender, EventArgs e)
        {
           // txt4_1.Text = string.Empty;
        }

        private void txt4_2_Click(object sender, EventArgs e)
        {
            //txt4_2.Text = string.Empty;
        }

        private void txt4_3_Click(object sender, EventArgs e)
        {
           // txt4_3.Text = string.Empty;
        }

        private void txt3_1_TextChanged(object sender, EventArgs e)
        {
            //txt3_1.Text = string.Empty;
        }

        private void txt3_2_TextChanged(object sender, EventArgs e)
        {
            //txt3_2.Text = string.Empty;
        }

        private void txt3_3_TextChanged(object sender, EventArgs e)
        {
            //txt3_3.Text = string.Empty;
        }

        private void txt4_1_TextChanged(object sender, EventArgs e)
        {
           // txt4_1.Text = string.Empty;
        }

        private void txt4_2_TextChanged(object sender, EventArgs e)
        {
            //txt4_2.Text = string.Empty;
        }

        private void txt4_3_TextChanged(object sender, EventArgs e)
        {
           // txt4_3.Text = string.Empty;
        }


        // bat xa
        private void txt1_1_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^-?[0-9][0-9,\.]+$");
            string text = txt1_1.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txt1_1.Text))
            {
                e.Cancel = true;
                txt1_1.Focus();
                errorProvider1.SetError(txt1_1, "Vui lòng nhập số mét.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txt1_1.Focus();
                    errorProvider1.SetError(txt1_1, "Vui lòng nhập số thập phân có dấu '.'");
                }
                else
                {
                    if (double.Parse(txt1_1.Text) < 0)
                    {
                        e.Cancel = true;
                        txt1_1.Focus();
                        errorProvider1.SetError(txt1_1, "Vui lòng nhập số lần lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txt1_1, null);
                    }
                }
            }
        }
        //boi
        private void txt2_1_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^[0-9]+$");
            string text = txt2_1.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txt2_1.Text))
            {
                e.Cancel = true;
                txt2_1.Focus();
                errorProvider1.SetError(txt2_1, "Vui lòng nhập số met.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txt2_1.Focus();
                    errorProvider1.SetError(txt2_1, "Chỉ có số!");
                }
                else
                {
                    if (int.Parse(txt2_1.Text) < 0)
                    {
                        e.Cancel = true;
                        txt2_1.Focus();
                        errorProvider1.SetError(txt2_1, "Vui lòng nhập số met lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txt2_1, null);
                    }
                }
            }
        }
        // chay dai -gioi
        private void txt3_1_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^[0-5][0-9]:[0-5][0-9]$");
            string text = txt3_1.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txt3_1.Text))
            {
                e.Cancel = true;
                txt3_1.Focus();
                errorProvider1.SetError(txt3_1, "Vui lòng nhập phút:giây!");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txt3_1.Focus();
                    errorProvider1.SetError(txt3_1, "Vui lòng nhập dạng mm:ss");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txt3_1, null);
                }

            }
        }
        // chay ngan - gioi 
        private void txt4_1_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^-?[0-9][0-9,\.]+$");
            string text = txt4_1.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txt4_1.Text))
            {
                e.Cancel = true;
                txt4_1.Focus();
                errorProvider1.SetError(txt4_1, "Vui lòng nhập số giây.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txt4_1.Focus();
                    errorProvider1.SetError(txt4_1, "Vui lòng nhập số thập phân có dấu '.'");
                }
                else
                {
                    if (double.Parse(txt4_1.Text) < 0)
                    {
                        e.Cancel = true;
                        txt4_1.Focus();
                        errorProvider1.SetError(txt4_1, "Vui lòng nhập số giây lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txt4_1, null);
                    }
                }
            }
        }

        private void txt5_1_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^[0-9]+$");
            string text = txt5_1.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txt5_1.Text))
            {
                e.Cancel = true;
                txt5_1.Focus();
                errorProvider1.SetError(txt5_1, "Vui lòng nhập số lần.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txt5_1.Focus();
                    errorProvider1.SetError(txt5_1, "Chỉ có số!");
                }
                else
                {
                    if (int.Parse(txt5_1.Text) < 0)
                    {
                        e.Cancel = true;
                        txt5_1.Focus();
                        errorProvider1.SetError(txt5_1, "Vui lòng nhập số lần lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txt5_1, null);
                    }
                }
            }
        }
        // bat xa-kha
        private void txt1_2_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^-?[0-9][0-9,\.]+$");
            string text = txt1_2.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txt1_2.Text))
            {
                e.Cancel = true;
                txt1_2.Focus();
                errorProvider1.SetError(txt1_2, "Vui lòng nhập số mét.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txt1_2.Focus();
                    errorProvider1.SetError(txt1_2, "Vui lòng nhập số thập phân có dấu '.'");
                }
                else
                {
                    if (double.Parse(txt1_2.Text) < 0)
                    {
                        e.Cancel = true;
                        txt1_2.Focus();
                        errorProvider1.SetError(txt1_2, "Vui lòng nhập số lần lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txt1_2, null);
                    }
                }
            }
        }
        // chay 3000 -kha
        private void txt3_2_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^[0-5][0-9]:[0-5][0-9]$");
            string text = txt3_2.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txt3_2.Text))
            {
                e.Cancel = true;
                txt3_2.Focus();
                errorProvider1.SetError(txt3_2, "Vui lòng nhập phút:giây!");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txt3_2.Focus();
                    errorProvider1.SetError(txt3_2, "Vui lòng nhập dạng mm:ss");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txt3_2, null);
                }

            }
        }
        // chay ngan-kha
        private void txt4_2_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^-?[0-9][0-9,\.]+$");
            string text = txt4_2.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txt4_2.Text))
            {
                e.Cancel = true;
                txt4_2.Focus();
                errorProvider1.SetError(txt4_2, "Vui lòng nhập số giây.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txt4_2.Focus();
                    errorProvider1.SetError(txt4_2, "Vui lòng nhập số thập phân có dấu '.'");
                }
                else
                {
                    if (double.Parse(txt4_2.Text) < 0)
                    {
                        e.Cancel = true;
                        txt4_2.Focus();
                        errorProvider1.SetError(txt4_2, "Vui lòng nhập số giây lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txt4_2, null);
                    }
                }
            }
        }
        // chay dai - dat yc
        private void txt3_3_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^[0-5][0-9]:[0-5][0-9]$");
            string text = txt3_3.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txt3_3.Text))
            {
                e.Cancel = true;
                txt3_3.Focus();
                errorProvider1.SetError(txt3_3, "Vui lòng nhập phút:giây!");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txt3_3.Focus();
                    errorProvider1.SetError(txt3_3, "Vui lòng nhập dạng mm:ss");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txt3_3, null);
                }

            }
        }
        // chay ngan - dat yc
        private void txt4_3_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^-?[0-9][0-9,\.]+$");
            string text = txt4_3.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txt4_3.Text))
            {
                e.Cancel = true;
                txt4_3.Focus();
                errorProvider1.SetError(txt4_3, "Vui lòng nhập số giây.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txt4_3.Focus();
                    errorProvider1.SetError(txt4_3, "Vui lòng nhập số thập phân có dấu '.'");
                }
                else
                {
                    if (double.Parse(txt4_3.Text) < 0)
                    {
                        e.Cancel = true;
                        txt4_3.Focus();
                        errorProvider1.SetError(txt4_3, "Vui lòng nhập số giây lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txt4_3, null);
                    }
                }
            }
        }
    }
}
