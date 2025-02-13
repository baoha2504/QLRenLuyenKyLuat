﻿using QLRenLuyenKyLuat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "Select MaHocVien, TenHocVien, GioiTinh, MaLop, CapBac, Chucvu from HocVien where";
            if(cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
            {
                connect(query + " 1 = 1");
            }

            if (cbbMuc.Text == "Mã học viên")
            {
                connect(query + " mahocvien LIKE N'%" + txtNoiDung.Text + "%'");
            } else if (cbbMuc.Text == "Tên học viên")
            {
                connect(query + " tenhocvien LIKE N'%" + txtNoiDung.Text + "%'");
            } else if(cbbMuc.Text == "Lớp")
            {
                connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%'");
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE HocVien" +
                    " Set TenHocVien = N'" + txtTenHV.Text + "', GioiTinh = N'" + txtGT.Text + "',MaLop = N'" + txtMaLop.Text + "',CapBac = N'" + txtCapBac.Text + "',ChucVu = N'" + txtChucVu.Text + "' "
                   + " where MaHocVien = N'" + txtMaHV.Text + "'";
                connect(query);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usr_SuaHocVien_Load(sender, e);
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

        private void txtTenHV_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^([^0-9]*)$");
          
            string text = txtTenHV.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtTenHV.Text))
            {
                e.Cancel = true;
                txtTenHV.Focus();
                errorProvider1.SetError(txtTenHV, "Vui lòng nhập tên học viên.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txtTenHV.Focus();
                    errorProvider1.SetError(txtTenHV, "Vui lòng kiểm tra lại tên học viên!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtTenHV, null);
                }
            }
        }
    }
}
