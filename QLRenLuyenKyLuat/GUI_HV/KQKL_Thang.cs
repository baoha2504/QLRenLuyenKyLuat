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

namespace QLRenLuyenKyLuat.GUI_HV
{
    public partial class KQKL_Thang : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query = "";
        string query1 = "";
        string query2 = "";
        int thang;
        DateTime date = DateTime.Now;
        string check;
        public KQKL_Thang()
        {
            InitializeComponent();
            txtBoxNX.Multiline = true;
            txtBoxNX1.Multiline = true;
            txtBoxNX.ScrollBars = ScrollBars.Vertical;
            txtBoxNX1.ScrollBars = ScrollBars.Vertical;
        }

        private void KQKL_Thang_Load(object sender, EventArgs e)
        {

            thang = date.Month;
            cbB_KL_Thang.Text = thang.ToString();
            cbB_KL_Nam.Text = "2022";
        }

        private void cbB_KL_Nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbB_KL_Thang.SelectedItem = null;
        }

        private void btn_Xem_Click(object sender, EventArgs e)
        {
            check = cbB_KL_Nam.Text.Trim() + "-" + cbB_KL_Thang.Text.Trim();
            txtBoxDHT.Clear();
            txtBoxDLS.Clear();
            txtBoxDKL.Clear();
            txtBoxNX.Clear();
            txtBoxPL.Clear();
            txtBoxDHT1.Clear();
            txtBoxDLS1.Clear();
            txtBoxDKL1.Clear();
            txtBoxNX1.Clear();
            txtBoxPL1.Clear();
            txtBoxNX_Cuoi.Clear();
            txtBoxPL_Cuoi.Clear();
            query = "select  DiemKL, DiemHT, DiemLS, TenPhanLoai, NhanXet from HOCVIEN, HocVien_PLRL, DIEM_PLKL, PHANLOAIKYLUAT where HocVien.MaHocVien = HocVien_PLRL.MaHocVien and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL and DIEM_PLKL.MaPLKL = PHANLOAIKYLUAT.MaPLKL and DIEM_PLKL.MaDiemPLKL LIKE '%CN%' and HocVien_PLRL.MaHocVien = '"+ frmLogin.maNguoiDung +"'and HOCVIEN_PLRL.ThoiGian LIKE '"+check+ "%'";
            query1 = "select DiemKL, DiemHT, DiemLS, TenPhanLoai, NhanXet from HOCVIEN, HocVien_PLRL, DIEM_PLKL, PHANLOAIKYLUAT where HocVien.MaHocVien = HocVien_PLRL.MaHocVien and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL and DIEM_PLKL.MaPLKL = PHANLOAIKYLUAT.MaPLKL and DIEM_PLKL.MaDiemPLKL LIKE '%L' and HocVien_PLRL.MaHocVien = '" + frmLogin.maNguoiDung + "'and HOCVIEN_PLRL.ThoiGian LIKE '" + check + "%'";
            query2 = "select TenPhanLoai, NhanXet from HOCVIEN, HocVien_PLRL, DIEM_PLKL, PHANLOAIKYLUAT where HocVien.MaHocVien = HocVien_PLRL.MaHocVien and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL and DIEM_PLKL.MaPLKL = PHANLOAIKYLUAT.MaPLKL and DIEM_PLKL.MaDiemPLKL LIKE '%DD%' and HocVien_PLRL.MaHocVien = '" + frmLogin.maNguoiDung + "'and HOCVIEN_PLRL.ThoiGian LIKE '" + check + "%'";
            
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            sqlCon.Close();
            foreach (DataRow dr in dtb.Rows)
            {
                txtBoxDHT.Text = dr["DiemHT"].ToString();
                txtBoxDLS.Text = dr["DiemLS"].ToString();
                txtBoxDKL.Text = dr["DiemKL"].ToString();
                txtBoxNX.Text = dr["NhanXet"].ToString();
                txtBoxPL.Text = dr["TenPhanLoai"].ToString();

            }

            sqlCon.Open();
            SqlDataAdapter sqlDa1 = new SqlDataAdapter(query1,sqlCon);
            DataTable dtb1 = new DataTable();
            sqlDa1.Fill(dtb1);
            sqlCon.Close();
            foreach (DataRow dr in dtb1.Rows)
            {
                txtBoxDHT1.Text = dr["DiemHT"].ToString();
                txtBoxDLS1.Text = dr["DiemLS"].ToString();
                txtBoxDKL1.Text = dr["DiemKL"].ToString();
                txtBoxNX1.Text = dr["NhanXet"].ToString();
                txtBoxPL1.Text = dr["TenPhanLoai"].ToString();

            }

            sqlCon.Open();
            SqlDataAdapter sqlDa2 = new SqlDataAdapter(query2,sqlCon);
            DataTable dtb2 = new DataTable();
            sqlDa2.Fill(dtb2);
            sqlCon.Close();
            foreach (DataRow dr in dtb2.Rows)
            {
                txtBoxNX_Cuoi.Text = dr["NhanXet"].ToString();
                txtBoxPL_Cuoi.Text = dr["TenPhanLoai"].ToString();
            }
        }

        private void txtBoxDLS_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxDKL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxDHT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxNX_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxPL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxDKL1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxDLS1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxDHT1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxNX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxPL1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxNX_Cuoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxPL_Cuoi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
