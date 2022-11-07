using DevExpress.Xpo.DB.Helpers;
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
    public partial class usr_KQKL_HK : UserControl
    {
        public usr_KQKL_HK()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query = "";
        string MaHV = "";

        private void CapNhat(string query)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
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

        private void usr_KQKL_HK_Load(object sender, EventArgs e)
        {
            query = "select MaHocVien, TenHocVien, MaLop, GioiTinh, CapBac from HocVien";
            connect(query);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select MaHocVien, TenHocVien, MaLop, GioiTinh, CapBac, ChucVu " +
                    "from HocVien " +
                    "where MaHocVien != ' ' " +
                    "and ";
                if (cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
                {
                    usr_KQKL_HK_Load(sender, e);
                }

                if (cbbMuc.Text == "Tên học viên")
                {
                    connect(query + " tenhocvien LIKE N'%" + txtNoiDung.Text + "%'");
                }
                else if (cbbMuc.Text == "Lớp")
                {
                    connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%'");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaHV = dtgv.SelectedRows[0].Cells[0].Value.ToString();
            txtHoTen.Text = dtgv.SelectedRows[0].Cells[1].Value.ToString();
            txtLop.Text = dtgv.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
