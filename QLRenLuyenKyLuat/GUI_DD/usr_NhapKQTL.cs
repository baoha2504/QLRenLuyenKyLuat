using QLRenLuyenKyLuat.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_NhapKQTL : UserControl
    {
        public usr_NhapKQTL()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query;
        DateTime date = DateTime.Now;
        string MaHVPLTL;
        string MaKQTL;

        private void CapNhat(string query)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        private void LoadCbb()
        {
            string constr = Data_Provider.connectionSTR;
            string Sql = "select MaGS from GIAMSAT";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    cbbNguoiGiamSat.Items.Add(DR[0].ToString());
                }
                DR.Close();
                conn.Close();
            }
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

        private void LoadDTGV()
        {
            string check = date.ToString("MM") + date.ToString("yyyy");
            query = "select DISTINCT HOCVIEN.MaHocVien, HOCVIEN.TenHocVien, HOCVIEN.MaLop, HOCVIEN.GioiTinh " +
                "from HOCVIEN join HOCVIEN_PLTL on ( HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                "and HOCVIEN_PLTL.MaHocVien NOT IN  (" +
                "Select HOCVIEN_PLTL.MaHocVien " +
                "from HOCVIEN_PLTL " +
                "where HOCVIEN_PLTL.MaHVPLTL LIKE '%" + check + "%')) ";
            connect(query);
        }

        private void usr_NhapKQTL_Load(object sender, EventArgs e)
        {
            LoadCbb();
            LoadDTGV();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string check = date.ToString("MM") + date.ToString("yyyy");
            query = "select DISTINCT HOCVIEN.MaHocVien, HOCVIEN.TenHocVien, HOCVIEN.MaLop, HOCVIEN.GioiTinh " +
                "from HOCVIEN join HOCVIEN_PLTL on ( HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                "and HOCVIEN_PLTL.MaHocVien NOT IN  (" +
                "Select HOCVIEN_PLTL.MaHocVien " +
                "from HOCVIEN_PLTL " +
                "where HOCVIEN_PLTL.MaHVPLTL LIKE '%" + check + "%') " +
                "and ";
            if (cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
            {
                connect(query + " 1 = 1)");
            }

            if (cbbMuc.Text == "Tên học viên")
            {
                connect(query + " tenhocvien LIKE N'%" + txtNoiDung.Text + "%')");
            }
            else if (cbbMuc.Text == "Lớp")
            {
                connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%')");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string kq = "";
            if (cbbKetQua.Text == "Giỏi")
            {
                kq = "PLTL001";
            }
            else if (cbbKetQua.Text == "Khá")
            {
                kq = "PLTL002";

            }
            else if (cbbKetQua.Text == "Đạt")
            {
                kq = "PLTL003";
            }
            else
            {
                kq = "";
            }
            try
            {
                MaHVPLTL = txtMaHV.Text.Trim() + date.ToString("MM") + date.ToString("yyyy");
                MaKQTL = txtMaHV.Text.Trim() + "KQTL" + date.ToString("MM") + date.ToString("yyyy");

                if (txtGioiTinh.Text == "Nữ")
                {

                    query = "INSERT [dbo].[KETQUATHELUC] " +
                        "([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) " +
                        "VALUES (N'" + MaKQTL + "', " + txtBoi.Text + ", CAST(N'00:" + txtChayDai.Text + "' AS Time), CAST(N'00:00:" + txtChayNgan.Text + "' AS Time), " + txtBatXa.Text + ", NULL, " + txtKeoXa_ChongDay.Text + ", N'" + kq + "')";
                    CapNhat(query);
                }
                else if (txtGioiTinh.Text == "Nam")
                {
                    query = "INSERT [dbo].[KETQUATHELUC] " +
                        "([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) " +
                        "VALUES (N'" + MaKQTL + "', " + txtBoi.Text + ", CAST(N'00:" + txtChayDai.Text + "' AS Time), CAST(N'00:00:" + txtChayNgan.Text + "' AS Time), " + txtBatXa.Text + ", " + txtKeoXa_ChongDay.Text + ", NULL, N'" + kq + "')";
                    CapNhat(query);
                }
                else
                {
                    MessageBox.Show("Lỗi");
                }


                query = "INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) " +
                    "VALUES (N'" + MaHVPLTL + "', CAST(N'" + date.ToString("yyyy-MM-dd") + "' AS Date), N'" + txtMaHV.Text + "', N'" + cbbNguoiGiamSat.Text + "', N'" + MaKQTL + "')";
                CapNhat(query);

                LoadDTGV();

            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu");
            }
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHV.Text = dtgv.SelectedRows[0].Cells[0].Value.ToString();
            txtHoTen.Text = dtgv.SelectedRows[0].Cells[1].Value.ToString();
            txtLop.Text = dtgv.SelectedRows[0].Cells[2].Value.ToString().Trim();
            txtGioiTinh.Text = dtgv.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void txtChayDai_Click(object sender, EventArgs e)
        {
            txtChayDai.Text = String.Empty;
        }

        private void txtChayNgan_Click(object sender, EventArgs e)
        {
            txtChayNgan.Text = String.Empty;
        }
    }
}
