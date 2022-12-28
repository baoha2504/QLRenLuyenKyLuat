using QLRenLuyenKyLuat.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
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

        private void txtChayDai_TextChanged(object sender, EventArgs e)
        {
            //txtChayDai.Text = string.Empty;
        }

        private void txtChayNgan_TextChanged(object sender, EventArgs e)
        {
            //txtChayNgan.Text = string.Empty;
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

        private void txtKeoXa_ChongDay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^[0-9]+$");
            string text = txtKeoXa_ChongDay.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtKeoXa_ChongDay.Text))
            {
                e.Cancel = true;
                txtKeoXa_ChongDay.Focus();
                errorProvider1.SetError(txtKeoXa_ChongDay, "Vui lòng nhập số lần.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txtKeoXa_ChongDay.Focus();
                    errorProvider1.SetError(txtKeoXa_ChongDay, "Chỉ có số!");
                }
                else
                {
                   if (int.Parse(txtKeoXa_ChongDay.Text) < 0)
                    {
                        e.Cancel = true;
                        txtKeoXa_ChongDay.Focus();
                        errorProvider1.SetError(txtKeoXa_ChongDay, "Vui lòng nhập số lần lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtKeoXa_ChongDay, null);
                    }
                }
            }
        }

        private void txtBoi_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^[0-9]+$");
            string text = txtBoi.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtBoi.Text))
            {
                e.Cancel = true;
                txtBoi.Focus();
                errorProvider1.SetError(txtBoi, "Vui lòng nhập số met.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txtBoi.Focus();
                    errorProvider1.SetError(txtBoi, "Chỉ có số!");
                }
                else
                {
                    if (int.Parse(txtBoi.Text) < 0)
                    {
                        e.Cancel = true;
                        txtBoi.Focus();
                        errorProvider1.SetError(txtBoi, "Vui lòng nhập số met lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtBoi, null);
                    }
                }
            }
        }

        private void txtBatXa_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^-?[0-9][0-9,\.]+$");
            string text = txtBatXa.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtBatXa.Text))
            {
                e.Cancel = true;
                txtBatXa.Focus();
                errorProvider1.SetError(txtBatXa, "Vui lòng nhập số mét.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txtBatXa.Focus();
                    errorProvider1.SetError(txtBatXa, "Vui lòng nhập số thập phân có dấu '.'");
                }
                else
                {
                    if (double.Parse(txtBatXa.Text) < 0)
                    {
                        e.Cancel = true;
                        txtBatXa.Focus();
                        errorProvider1.SetError(txtBatXa, "Vui lòng nhập số lần lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtBatXa, null);
                    }
                }
            }
        }

        private void txtChayNgan_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^-?[0-9][0-9,\.]+$");
            string text = txtChayNgan.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtChayNgan.Text))
            {
                e.Cancel = true;
                txtChayNgan.Focus();
                errorProvider1.SetError(txtChayNgan, "Vui lòng nhập số giây.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txtChayNgan.Focus();
                    errorProvider1.SetError(txtChayNgan, "Vui lòng nhập số thập phân có dấu '.'");
                }
                else
                {
                    if (double.Parse(txtChayNgan.Text) < 0)
                    {
                        e.Cancel = true;
                        txtChayNgan.Focus();
                        errorProvider1.SetError(txtChayNgan, "Vui lòng nhập số giây lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtChayNgan, null);
                    }
                }
            }
        }

        private void txtChayDai_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex CharRegex = new Regex(@"^[0-5][0-9]:[0-5][0-9]$");
            string text = txtChayDai.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtChayDai.Text))
            {
                e.Cancel = true;
                txtChayDai.Focus();
                errorProvider1.SetError(txtChayDai, "Vui lòng nhập phút:giây!");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txtChayDai.Focus();
                    errorProvider1.SetError(txtChayDai, "Vui lòng nhập dạng mm:ss");
                }
                else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtChayDai, null);
                    }
                
            }
        }
    }
}
