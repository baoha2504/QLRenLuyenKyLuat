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
    public partial class usr_SuaLop : UserControl
    {
        public usr_SuaLop()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);

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

        private void usr_SuaLop_Load(object sender, EventArgs e)
        {
            string query = "Select MaLop, TenLop from Lop";
            connect(query);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "Select MaLop, TenLop from Lop where";
            if (cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
            {
                connect(query + " 1 = 1");
            }

            if (cbbMuc.Text == "Mã lớp")
            {
                connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%'");
            }
            else if (cbbMuc.Text == "Tên lớp")
            {
                connect(query + " tenlop LIKE N'%" + txtNoiDung.Text + "%'");
            }
            
        }
        private string malopmoi;

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLop.Text = dtgv.SelectedRows[0].Cells[0].Value.ToString();
            malopmoi = txtMaLop.Text;
            txtTenLop.Text = dtgv.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Lop " +
                    " Set MaLop = N'" + txtMaLop.Text + "', TenLop = N'" + txtTenLop.Text + "' "
                   + " where MaLop = N'" + malopmoi + "'";
                connect(query);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usr_SuaLop_Load(sender, e);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
