using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraReports.UI;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_KQKL_Thang : UserControl
    {
        public usr_KQKL_Thang()
        {
            InitializeComponent();
            //check = date.ToString("MM") + date.ToString("yyyy");
            check = cbbThang.Text.Trim() + cbbNam.Text.Trim();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query = "";
        DateTime date = DateTime.Now;
        string check;

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

        private void usr_KQKL_Thang_Load(object sender, EventArgs e)
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
                    usr_KQKL_Thang_Load(sender, e);
                }

                if (cbbMuc.Text == "Tên học viên")
                {
                    connect(query + " tenhocvien LIKE N'%" + txtNoiDung.Text + "%'");
                }
                else if (cbbMuc.Text == "Lớp")
                {
                    connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%'");
                }
                check = cbbThang.Text.Trim() + cbbNam.Text.Trim();
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHocTap.Text = string.Empty;
            txtKyLuat.Text = string.Empty;
            txtLoiSong.Text = string.Empty;
            txtMucPhanLoai.Text = string.Empty;
            txtNhanXet.Text = string.Empty;
            string constr = Data_Provider.connectionSTR;
            string Sql = "select TenHocVien, MaLop, DIEM_PLKL.DiemKL, DIEM_PLKL.DiemHT, DIEM_PLKL.DiemLS, TenPhanLoai, NhanXet " +
                "from HOCVIEN, HocVien_PLRL, DIEM_PLKL, PHANLOAIKYLUAT " +
                "where HocVien.MaHocVien = HocVien_PLRL.MaHocVien " +
                "and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL " +
                "and DIEM_PLKL.MaPLKL = PHANLOAIKYLUAT.MaPLKL " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%DD%' " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%"+ check + "%' " +
                "and HocVien_PLRL.MaHocVien = '"+ dtgv.SelectedRows[0].Cells[0].Value.ToString().Trim() + "'";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    txtHoTen.Text = DR["TenHocVien"].ToString();
                    txtLop.Text = DR["MaLop"].ToString();
                    txtKyLuat.Text = DR["DiemKL"].ToString();
                    txtHocTap.Text = DR["DiemHT"].ToString();
                    txtLoiSong.Text = DR["DiemLS"].ToString();
                    txtMucPhanLoai.Text = DR["TenPhanLoai"].ToString();
                    txtNhanXet.Text = DR["NhanXet"].ToString();
                }
                DR.Close();
                conn.Close();
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbThang.Text == string.Empty)
                {
                    MessageBox.Show("Phải lựa chọn tháng để xuất file", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbThang.Focus();
                }
                else if (cbbNam.Text == string.Empty)
                {
                    MessageBox.Show("Phải lựa chọn năm để xuất file", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbNam.Focus();
                }
                else
                {
                    sqlCon.Open();
                    DataSetThang dataset = new DataSetThang();
                    DataSetThangTableAdapters.DataTable1TableAdapter nhap = new DataSetThangTableAdapters.DataTable1TableAdapter();
                    nhap.Connection.ConnectionString = Data_Provider.connectionSTR;
                    nhap.ClearBeforeFill = true;
                    string date1 = cbbNam.Text.Trim() + "-" + cbbThang.Text.Trim() + "-1";
                    string date2 = cbbNam.Text.Trim() + "-" + (Convert.ToInt32(cbbThang.Text) + 1).ToString().Trim() + "-1";
                    nhap.Fill(dataset.DataTable1, date1, date2);
                    sqlCon.Close();
                    ReportThang report = new ReportThang();
                    report.DataSource = dataset;
                    report.ShowPreviewDialog();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
