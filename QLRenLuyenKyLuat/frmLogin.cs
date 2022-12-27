using System;
using System.Windows.Forms;
using QLRenLuyenKyLuat.GUI_DD;
using QLRenLuyenKyLuat.GUI_LOP;
using QLRenLuyenKyLuat.GUI_HV;
using System.Data.SqlClient;
using QLRenLuyenKyLuat.Data;
using System.Security.Cryptography;
    using System.Text;
    using System.Data;
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
            frmDaiDoi frmDaiDoi = new frmDaiDoi();
            frmDaiDoi.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmLop frmLop = new frmLop();
            frmLop.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmHocVien frmHocVien = new frmHocVien();
            frmHocVien.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            sqlCon.Close();
            sqlCon.Open();
           
            string query = "Select * from HocVien hv, Lop lop where hv.MaLop = lop.MaLop and mahocvien= N'" + txtLoginMaHV.Text.Trim() + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);        
            dtbl = new DataTable(); 
            da.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                maHV = txtLoginMaHV.Text.Trim();
                foreach (DataRow dr in dtbl.Rows)
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
}
