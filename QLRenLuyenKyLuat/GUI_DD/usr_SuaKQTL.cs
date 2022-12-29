using QLRenLuyenKyLuat.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_SuaKQTL : UserControl
    {
        public usr_SuaKQTL()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query = "";
        DateTime date = DateTime.Now;
        string MaKQTL;
        string check = "";
        string laycheck;

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

        private void usr_SuaKQTL_Load(object sender, System.EventArgs e)
        {
            string check = date.ToString("MM") + date.ToString("yyyy");
            query = "select DISTINCT HOCVIEN.MaHocVien, HOCVIEN.TenHocVien, HOCVIEN.MaLop, HOCVIEN.GioiTinh " +
                "from HOCVIEN join HOCVIEN_PLTL on ( HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                "and HOCVIEN_PLTL.MaHocVien IN  (" +
                "Select HOCVIEN_PLTL.MaHocVien " +
                "from HOCVIEN_PLTL " +
                "where HOCVIEN_PLTL.MaKQTL LIKE '%" + check + "%')) ";
            connect(query);
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string check = date.ToString("MM") + date.ToString("yyyy");
            MaKQTL = dtgv.SelectedRows[0].Cells[0].Value.ToString().Trim() + "KQTL" + check.Trim();

            string constr = Data_Provider.connectionSTR;
            string Sql = "select KETQUATHELUC.Boi, KETQUATHELUC.ChayDai, KETQUATHELUC.ChayNgan, KETQUATHELUC.NhayXa, KETQUATHELUC.Xa, KETQUATHELUC.ChongDay, PHANLOAITHELUC.TenPLTL " +
                "from KETQUATHELUC, PHANLOAITHELUC " +
                "where MaKQTL = '" + MaKQTL + "' and KETQUATHELUC.MaPLTL = PHANLOAITHELUC.MaPLTL";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    //cbbNguoiGiamSat.Items.Add(DR[0].ToString());
                    txtBoi.Text = DR["Boi"].ToString();
                    txtChayDai.Text = DR["ChayDai"].ToString();
                    txtChayNgan.Text = DR["ChayNgan"].ToString();
                    txtBatXa.Text = DR["NhayXa"].ToString();
                    if (DR["Xa"].ToString() == string.Empty)
                    {
                        txtKeoXa_ChongDay.Text = DR["ChongDay"].ToString();
                        check = "ChongDay";
                    }
                    else
                    {
                        txtKeoXa_ChongDay.Text = DR["Xa"].ToString();
                        check = "Xa";
                    }
                    txtKetQua.Text = DR["TenPLTL"].ToString();

                }
                DR.Close();
                conn.Close();
            }
            laycheck = check;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string check = cbbThang.Text.Trim() + cbbNam.Text.Trim();
            query = "select DISTINCT HOCVIEN.MaHocVien, HOCVIEN.TenHocVien, HOCVIEN.MaLop, HOCVIEN.GioiTinh " +
                "from HOCVIEN join HOCVIEN_PLTL on ( HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                "and HOCVIEN_PLTL.MaHocVien IN  (" +
                "Select HOCVIEN_PLTL.MaHocVien " +
                "from HOCVIEN_PLTL " +
                "where HOCVIEN_PLTL.MaKQTL LIKE '%" + check + "%') " +
                "and ";
            if (cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
            {
                usr_SuaKQTL_Load(sender, e);
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

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (laycheck == "Xa")
            {
                query = "update KETQUATHELUC " +
                    "set Boi = " + txtBoi.Text + ", ChayDai = '" + txtChayDai.Text + "', ChayNgan = '" + txtChayNgan.Text + "', NhayXa = " + txtBatXa.Text + ", Xa = " + txtKeoXa_ChongDay.Text + " " +
                    "where MaPLTL = '" + MaKQTL + "'";
                connect(query);
                MessageBox.Show("Thay đổi kết quả thể lực thành công");
            }
            else if (laycheck == "ChongDay")
            {
                query = "update KETQUATHELUC " +
                    "set Boi = " + txtBoi.Text + ", ChayDai = '" + txtChayDai.Text + "', ChayNgan = '" + txtChayNgan.Text + "', NhayXa = " + txtBatXa.Text + ", ChongDay = " + txtKeoXa_ChongDay.Text + " " +
                    "where MaPLTL = '" + MaKQTL + "'";
                connect(query);
                MessageBox.Show("Thay đổi kết quả thể lực thành công");
            }
            else
            {
                MessageBox.Show("Lỗi");
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

        private void txtBoi_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^[0-9]+$");
            string text = txtBoi.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtBoi.Text))
            {
                e.Cancel = true;
                txtBoi.Focus();
                errorProvider1.SetError(txtBoi, "Vui lòng nhập số lần.");
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
                        errorProvider1.SetError(txtBoi, "Vui lòng nhập số lần lớn hơn 0.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtBoi, null);
                    }
                }
            }
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
    }
}
