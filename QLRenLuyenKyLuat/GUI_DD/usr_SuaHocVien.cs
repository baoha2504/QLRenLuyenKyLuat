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
    public partial class usr_SuaHocVien : UserControl
    {
        public usr_SuaHocVien()
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

        private void CapNhat(string query)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "Select MaHocVien, TenHocVien, GioiTinh, MaLop, CapBac, Chucvu from HocVien where";
            if(cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
            {
                connect(query + " 1 = 1");
            }

            if (cbbMuc.Text == "Mã học viên")
            {
                connect(query + " mahocvien = N'" + txtNoiDung.Text + "'");
            } else if (cbbMuc.Text == "Tên học viên")
            {
                connect(query + " tenhocvien = N'" + txtNoiDung.Text + "'");
            } else if(cbbMuc.Text == "Lớp")
            {
                connect(query + " malop = N'" + txtNoiDung.Text + "'");
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE HocVien" +
                    " Set TenHocVien = N'" + txtTenHV.Text + "', GioiTinh = N'" + txtTenHV.Text + "',MaLop = N'" + txtMaLop.Text + "',CapBac = N'" + txtCapBac.Text + "',ChucVu = N'" + txtChucVu.Text + "' "
                   + " where MaHocVien = N'" + txtMaHV.Text + "'";
                connect(query);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usr_SuaHocVien_Load(object sender, EventArgs e)
        {
            string query = "Select MaHocVien, TenHocVien, GioiTinh, MaLop, CapBac, ChucVu from HocVien";
            connect(query);
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHV.Text = dtgv.SelectedRows[0].Cells[0].Value.ToString();
            txtTenHV.Text = dtgv.SelectedRows[0].Cells[1].Value.ToString();
            txtGT.Text = dtgv.SelectedRows[0].Cells[2].Value.ToString();
            txtMaLop.Text = dtgv.SelectedRows[0].Cells[3].Value.ToString();
            txtCapBac.Text = dtgv.SelectedRows[0].Cells[4].Value.ToString();
            txtChucVu.Text = dtgv.SelectedRows[0].Cells[5].Value.ToString();
        }
    }
}
