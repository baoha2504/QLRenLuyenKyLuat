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
        public static string maHV;
        DataTable dtbl;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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
                maHV = txtLoginMaHV.Text.Trim();
                foreach (DataRow dr in dtbl.Rows)
                {
                    name = dr["HoTen"].ToString();
                    position = dr["ChucVu"].ToString();
                    //lop = dr["MaLop"].ToString();
                }
                sqlCon.Close();
                frmLop frm = new frmLop();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Check your Username and Password!");
            }

        }
    }
}
