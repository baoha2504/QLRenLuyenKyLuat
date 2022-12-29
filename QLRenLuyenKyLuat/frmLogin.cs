using QLRenLuyenKyLuat.Data;
using QLRenLuyenKyLuat.GUI_DD;
using QLRenLuyenKyLuat.GUI_HV;
using QLRenLuyenKyLuat.GUI_LOP;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace QLRenLuyenKyLuat
{
    public partial class frmLogin : Form
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        public static string position;
        public static string name;
        public static string lop;
        public static string maNguoiDung;
        public static string hashPass;
        DataTable dtblDD;
        DataTable dtblL;
        DataTable dtblHV;
        string query;
        public frmLogin()
        {
            InitializeComponent();
        }
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            sqlCon.Close();
            sqlCon.Open();
            query = "select * from QuanLy where MaQL = N'"+ txtLoginMaHV.Text.Trim() + "' and MatKhau = '"+ ComputeSha256Hash(txtLoginPass.Text.Trim()) + "'";
            SqlDataAdapter daDD = new SqlDataAdapter(query, sqlCon);
            dtblDD = new DataTable();
            daDD.Fill(dtblDD);
            //sqlCon.Close();
            if (dtblDD.Rows.Count == 1)
            {
                maNguoiDung = txtLoginMaHV.Text.Trim();
                foreach (DataRow dr in dtblDD.Rows)
                {
                    name = dr["HoTen"].ToString();
                    position = dr["ChucVu"].ToString();
                    //lop = dr["MaLop"].ToString();
                }
                sqlCon.Close();
                frmDaiDoi frm = new frmDaiDoi();
                frm.Show();
                this.Hide();
            }
            else
            {
                query = "select * from LOP where MaLop = N'"+ txtLoginMaHV.Text.Trim() + "' and MatKhau = '"+ ComputeSha256Hash(txtLoginPass.Text.Trim()) + "'";
                SqlDataAdapter daL = new SqlDataAdapter(query, sqlCon);
                dtblL = new DataTable();
                daL.Fill(dtblL);
                if (dtblL.Rows.Count == 1)
                {
                    maNguoiDung = txtLoginMaHV.Text.Trim();
                    foreach (DataRow dr in dtblL.Rows)
                    {
                        //name = dr["MaLop"].ToString();
                        //position = dr["ChucVu"].ToString();
                        lop = dr["MaLop"].ToString();
                    }
                    sqlCon.Close();
                    frmLop frm = new frmLop();
                    frm.Show();
                    this.Hide();
                } else
                {
                    query = "select * from HOCVIEN where MaHocVien = N'"+ txtLoginMaHV.Text.Trim() + "' and MatKhau = '"+ ComputeSha256Hash(txtLoginPass.Text.Trim()) + "'";
                    SqlDataAdapter daHV = new SqlDataAdapter(query, sqlCon);
                    dtblHV = new DataTable();
                    daHV.Fill(dtblHV);
                    if (dtblHV.Rows.Count == 1)
                    {
                        maNguoiDung = txtLoginMaHV.Text.Trim();
                        foreach (DataRow dr in dtblHV.Rows)
                        {
                            name = dr["TenHocvien"].ToString();
                            position = dr["ChucVu"].ToString();
                            lop = dr["MaLop"].ToString();
                        }
                        sqlCon.Close();
                        frmHocVien frm = new frmHocVien();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Check your Username and Password!");
                    }
                }
            }
            hashPass = ComputeSha256Hash(txtLoginPass.Text);
        }

        private void txtLoginMaHV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLoginPass.Focus();
            }
        }

        private void txtLoginPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
