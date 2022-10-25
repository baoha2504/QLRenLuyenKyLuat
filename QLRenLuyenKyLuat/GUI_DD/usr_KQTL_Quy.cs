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
    public partial class usr_KQTL_Quy : UserControl
    {
        public usr_KQTL_Quy()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query;
        int thang;
        int thangConLai1;
        int thangConLai2;
        int nam;
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

        private void HienComboBox()
        {
            string constr = Data_Provider.connectionSTR;
            string Sql = "select DISTINCT ThoiGian from HOCVIEN_PLTL";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    cbbThoiGian.Items.Add(DR[0]);
                }
                DR.Close();
            }
        }

            private void TinhQuy (DateTime dateTime)
        {
            thang = dateTime.Month;
            nam = dateTime.Year;
            if(thang == 1 || thang == 4 || thang == 7 || thang == 10)
            {
                thangConLai1 = thang + 1;
                thangConLai2 = thang + 2;
            } else if(thang == 2 || thang == 5 || thang == 8 || thang == 11)
            {
                thangConLai1 = thang - 1;
                thangConLai2 = thang + 1;
            } else
            {
                thangConLai1 = thang - 1;
                thangConLai2 = thang - 2;
            }
        }

        private void usr_KQTL_Quy_Load(object sender, EventArgs e)
        {
            TinhQuy(DateTime.Now);
            HienComboBox();
            query = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                "from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                "where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                "and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                "and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                "and YEAR(HOCVIEN_PLTL.ThoiGian) = " + nam + " " +
                "and (Month(HOCVIEN_PLTL.ThoiGian) = " + thang + " " +
                "or Month(HOCVIEN_PLTL.ThoiGian) = " + thangConLai1 + " " +
                "or Month(HOCVIEN_PLTL.ThoiGian) = " + thangConLai2 + ")";
            connect(query);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbbThoiGian.Text != string.Empty)
            {
                TinhQuy(DateTime.Parse(cbbThoiGian.Text));
            } else
            {
                TinhQuy(DateTime.Now);
            }
            query = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                "from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                "where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                "and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                "and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                "and YEAR(HOCVIEN_PLTL.ThoiGian) = " + nam + " " +
                "and (Month(HOCVIEN_PLTL.ThoiGian) = " + thang + " " +
                "or Month(HOCVIEN_PLTL.ThoiGian) = " + thangConLai1 + " " +
                "or Month(HOCVIEN_PLTL.ThoiGian) = " + thangConLai2 + ") and ";
            if (cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
            {
                connect(query + " 1 = 1");
            }
            else if (cbbMuc.Text == "Học viên")
            {
                connect(query + " tenhocvien LIKE N'%" + txtNoiDung.Text + "%'");
            }
            else if (cbbMuc.Text == "Lớp")
            {
                connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%'");
            }
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHoTen.Text = dtgv.SelectedRows[0].Cells[0].Value.ToString();
            txtGioiTinh.Text = dtgv.SelectedRows[0].Cells[1].Value.ToString();
            txtBatXa.Text = dtgv.SelectedRows[0].Cells[2].Value.ToString();
            txtBoi.Text = dtgv.SelectedRows[0].Cells[3].Value.ToString();
            txtChayDai.Text = dtgv.SelectedRows[0].Cells[4].Value.ToString();
            txtChayNgan.Text = dtgv.SelectedRows[0].Cells[5].Value.ToString();
            if (dtgv.SelectedRows[0].Cells[6].Value.ToString() != string.Empty)
            {
                txtKeoXa_ChongDay.Text = dtgv.SelectedRows[0].Cells[6].Value.ToString();
            }
            else if (dtgv.SelectedRows[0].Cells[7].Value.ToString() != string.Empty)
            {
                txtKeoXa_ChongDay.Text = dtgv.SelectedRows[0].Cells[7].Value.ToString();
            }
            
            txtKetQua.Text = dtgv.SelectedRows[0].Cells[8].Value.ToString();

        }
    }
}
