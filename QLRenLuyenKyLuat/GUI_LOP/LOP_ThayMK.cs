using DevExpress.XtraEditors;
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

namespace QLRenLuyenKyLuat.GUI_LOP
{
    public partial class LOP_ThayMK : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        public LOP_ThayMK()
        {
            InitializeComponent();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            string curPass = txtbox_curPass.Text;
            string newPass = txtBox_newPass.Text;
            string rePass = txtBox_rePass.Text;
            if(curPass== string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtbox_curPass.Focus();
            }
            if(newPass == string.Empty)
            {
                 MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
               
                txtBox_newPass.Focus();
            }
            if (rePass == string.Empty)
            {
               MessageBox.Show("Vui lòng nhập lại mật khẩu mới !", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                
                txtBox_rePass.Focus();
            }
            string query;
            string Matkhau;
            query = "select * from Lop where MaLop like N'%" + frmLogin.maLop.Trim() + "%'";
            sqlCon.Close();
            sqlCon.Open();
            SqlDataAdapter sqlHv = new SqlDataAdapter(query, sqlCon);
            DataTable Hocvien = new DataTable();
            sqlHv.Fill(Hocvien);
            foreach (DataRow dr in Hocvien.Rows)
            {
                Matkhau = dr["MatKhau"].ToString();
                if(curPass !="" && newPass!= ""&& rePass != "")
                {
                    if (curPass.Trim() == Matkhau.Trim())
                    {
                        if (rePass == newPass)
                        {
                            query = "UPDATE Lop " +
                               "SET MatKhau = N'" + rePass + "' " +
                               "WHERE  MaLop like N'%" + frmLogin.maLop.Trim() + "%'";
                            SqlCommand sqlDa = new SqlCommand(query, sqlCon);
                            sqlDa.ExecuteNonQuery();
                            sqlCon.Close();
                            DialogResult suc = MessageBox.Show("Bạn đã thay đổi mật khẩu thành công! Vui lòng đăng nhập lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (suc == DialogResult.OK)
                            {
                                this.Hide();
                                frmLogin frm = new frmLogin();
                                frm.Show();
                            }
                            else
                            {
                                this.Visible = true;
                            }
                        }
                        else
                        {
                             MessageBox.Show("Mật khẩu nhập lại chưa khớp với mật khẩu mới! Vui lòng nhập lại!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question); 
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại mật khẩu này! Vui lòng nhập lại", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);  
                    }
                }
               
            }
   
        }
    }
}
