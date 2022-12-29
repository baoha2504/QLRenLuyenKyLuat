using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLRenLuyenKyLuat.Data;
using System.Text.RegularExpressions;

namespace QLRenLuyenKyLuat.GUI_HV
{
    public partial class TuDanhGia : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        public TuDanhGia()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            lbl_Thang.Text = dt.Month.ToString();
        }

        public static string maHocVien;
        private void btnTudanhgia_Click(object sender, EventArgs e)
        {
            maHocVien = frmLogin.maNguoiDung;
            sqlCon.Close();
            try
            {
                sqlCon.Open();
                String query = "INSERT INTO  Diem_PLKL(MaDiemPLKL, DiemKL, DiemHT, DiemLS, NhanXet, NguoiDanhGia, CapDanhGia, MaPLKL) VALUES([dbo].auto_MaDiemKL_CN('" + frmLogin.maNguoiDung+ "'),'" +
                int.Parse(txtbox_DKL_CN.Text) + "','"  + int.Parse(txtbox_DHT_CN.Text) + "','" + int.Parse(txtbox_DLS_CN.Text) + "','"+
                txtbox_NX_CN.Text + "', null ,'CN','" + txtbox_PL_CN.Text + "')";
                SqlCommand sqlDa = new SqlCommand(query, sqlCon);
                sqlDa.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Đã lưu kết quả tự đánh giá");


                DateTime dt = DateTime.Now;
                sqlCon.Open();
                String q = "INSERT INTO  Hocvien_PLRL (MaHVPLRL, thoigian, MaHocvien, MaDiemPLRL) VALUES([dbo].auto_MaHVPLRL_CN('" + frmLogin.maNguoiDung+"'), " +
                "CAST(N'" + dt.ToString("yyyy/MM/dd") + "' AS DATE), N'" + frmLogin.maNguoiDung + "'," +
                "[dbo].auto_MaDiemKL_CN('" + frmLogin.maNguoiDung + "') )";
                SqlCommand sqld1 = new SqlCommand(q, sqlCon);
                sqld1.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Đã lưu kết quả vào PLRL");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public static int sum = 0;
        public static string xeploai;
        public static int[] HT = new int[3];
        public static int[] KL = new int[3];
        public static int[] LS = new int[3];

        private void txtbox_sum_CN_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int diem1 = int.Parse(txtbox_DKL_CN.Text);
                int diem2 = int.Parse(txtbox_DLS_CN.Text);
                int diem3 = int.Parse(txtbox_DHT_CN.Text);

                while (diem1 > 10 || diem1 < 0)
                {
                    DialogResult warn = MessageBox.Show("Điểm nằm trong khoảng từ 0 đến 10. Vui lòng nhập lại điểm!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtbox_DKL_CN.Focus();
                }

                while (diem2 > 10 || diem2 < 0)
                {
                    DialogResult warn = MessageBox.Show("Điểm nằm trong khoảng từ 0 đến 10. Vui lòng nhập lại điểm!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtbox_DLS_CN.Focus();
                }

                while (diem3 > 10 || diem3 < 0)
                {
                    DialogResult warn = MessageBox.Show("Điểm nằm trong khoảng từ 0 đến 10. Vui lòng nhập lại điểm!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtbox_DHT_CN.Focus();
                }

                sum = diem1 + diem2 + diem3;

                sqlCon.Close();
                sqlCon.Open();
                string query = "select muc1, muc2, muc3 from QUYCHUANKYLUAT join (select MaQLQC, ThoiGian from QUYCHUAN where ThoiGian = (select Max(thoigian) from QUYCHUAN )) as b on QUYCHUANKYLUAT.MaQLQC = b.MaQLQC and NoiDung = N'Kỷ luật'";
                string query1 = "select muc1, muc2, muc3 from QUYCHUANKYLUAT join (select MaQLQC, ThoiGian from QUYCHUAN where ThoiGian = (select Max(thoigian) from QUYCHUAN )) as b on QUYCHUANKYLUAT.MaQLQC = b.MaQLQC and NoiDung = N'Lối sống'";
                string query2 = "select muc1, muc2, muc3 from QUYCHUANKYLUAT join (select MaQLQC, ThoiGian from QUYCHUAN where ThoiGian = (select Max(thoigian) from QUYCHUAN )) as b on QUYCHUANKYLUAT.MaQLQC = b.MaQLQC and NoiDung = N'Học Tập'";

                SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
                DataTable dtbl = new DataTable();
                da.Fill(dtbl);

                SqlDataAdapter da1 = new SqlDataAdapter(query1, sqlCon);
                DataTable dtbl1 = new DataTable();
                da1.Fill(dtbl1);

                SqlDataAdapter da2 = new SqlDataAdapter(query2, sqlCon);
                DataTable dtbl2 = new DataTable();
                da2.Fill(dtbl2);

                foreach (DataRow dr in dtbl.Rows)
                {
                    KL[0] = int.Parse(dr["muc1"].ToString());
                    KL[1] = int.Parse(dr["muc2"].ToString());
                    KL[2] = int.Parse(dr["muc3"].ToString());
                }

                foreach (DataRow dr in dtbl1.Rows)
                {
                    LS[0] = int.Parse(dr["muc1"].ToString());
                    LS[1] = int.Parse(dr["muc2"].ToString());
                    LS[2] = int.Parse(dr["muc3"].ToString());
                }

                foreach (DataRow dr in dtbl2.Rows)
                {
                    HT[0] = int.Parse(dr["muc1"].ToString());
                    HT[1] = int.Parse(dr["muc2"].ToString());
                    HT[2] = int.Parse(dr["muc3"].ToString());
                }

                xeploai = Calculator.cal_DiemRLThang(diem1, diem2, diem3, KL, LS, HT);

                txtbox_sum_CN.Text = sum.ToString();
                txtbox_PL_CN.Text = Calculator.cal_DiemRLThang(diem1, diem2, diem3, KL, LS, HT);
            }
            catch
            {
                MessageBox.Show("Chưa đủ dữ liệu");
            }
        }

        private void txtbox_DKL_CN_Validating(object sender, CancelEventArgs e)
        {
             Regex CharRegex = new Regex("^[0-9]+$");
            string text = txtbox_DKL_CN.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtbox_DKL_CN.Text))
            {
                e.Cancel = true;
                txtbox_DKL_CN.Focus();
                errorProvider1.SetError(txtbox_DKL_CN, "Vui lòng nhập điểm!");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txtbox_DKL_CN.Focus();
                    errorProvider1.SetError(txtbox_DKL_CN, "Chỉ có số");
                }
                else
                {
                    if (int.Parse(txtbox_DKL_CN.Text) > 10 || int.Parse(txtbox_DKL_CN.Text) < 0)
                    {
                        e.Cancel = true;
                        txtbox_DKL_CN.Focus();
                        errorProvider1.SetError(txtbox_DKL_CN, "Vui lòng nhập điểm từ 0-10!");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtbox_DKL_CN, null);
                    }
                }
            }
        }

        private void txtbox_DLS_CN_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^[0-9]+$");
            string text = txtbox_DLS_CN.Text;
            bool result = CharRegex.IsMatch(text);
            if (result == false)
            {
                e.Cancel = true;
                txtbox_DLS_CN.Focus();
                errorProvider1.SetError(txtbox_DLS_CN, "Chỉ có số");
            }
            else
            {
                if (int.Parse(txtbox_DLS_CN.Text) > 10 || int.Parse(txtbox_DLS_CN.Text) < 0)
                {
                    e.Cancel = true;
                    txtbox_DLS_CN.Focus();
                    errorProvider1.SetError(txtbox_DLS_CN, "Vui lòng nhập điểm từ 0-10!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtbox_DLS_CN, null);
                }
            }
        }

        private void txtbox_DHT_CN_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^[0-9]+$");
            string text = txtbox_DHT_CN.Text;
            bool result = CharRegex.IsMatch(text);
            if (result == false)
            {
                e.Cancel = true;
                txtbox_DLS_CN.Focus();
                errorProvider1.SetError(txtbox_DHT_CN, "Chỉ có số");
            }
            else
            {
                if (int.Parse(txtbox_DHT_CN.Text) > 10 || int.Parse(txtbox_DHT_CN.Text) < 0)
                {
                    e.Cancel = true;
                    txtbox_DLS_CN.Focus();
                    errorProvider1.SetError(txtbox_DHT_CN, "Vui lòng nhập điểm từ 0-10!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtbox_DHT_CN, null);
                }
            }
        }

        private void txtbox_NX_CN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbox_NX_CN.Text))
            {
                e.Cancel = true;
                txtbox_DKL_CN.Focus();
                errorProvider1.SetError(txtbox_NX_CN, "Vui lòng nhập nhận xét!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbox_NX_CN, null);

            }
        }
    }
}
