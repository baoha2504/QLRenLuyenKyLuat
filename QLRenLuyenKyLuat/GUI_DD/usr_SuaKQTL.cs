using QLRenLuyenKyLuat.Data;
using System;
using System.Data;
using System.Data.SqlClient;
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
    }
}
