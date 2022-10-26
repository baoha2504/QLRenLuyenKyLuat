using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using QLRenLuyenKyLuat.Data;
using System.Data.SqlClient;


namespace QLRenLuyenKyLuat.GUI_LOP
{
    public partial class DSHocvien : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        public DSHocvien()
        {
            InitializeComponent();
            connect();
        }
        private void DSHocvien_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            txtBoxCurDay.Text = "Ngày " + dt.Date.ToString("dd/MM/yyyy");
        }

        private void connect() // danh sach hoc vien
        {
            sqlCon.Close();
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select MaHocVien as 'Mã học viên', TenHocVien as 'Họ và tên', GioiTinh as 'Giới tính', CapBac as 'Cấp bậc', ChucVu as 'Chức vụ' from HOCVIEN where maLop = N'"+ frmLogin.lop+"'", sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            datagridDSHV.DataSource = dtb;
            datagridDSHV.AutoGenerateColumns = false;
            datagridDSHV.AllowUserToAddRows = false;
            datagridDSHV.AutoResizeColumns();
            sqlCon.Close();
        }
        private void btnDeNghi_Click(object sender, EventArgs e)
        {

        }
        public string MaHV, hoten, NguoiDG;

        private void datagridDSHV_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            sqlCon.Close();
            sqlCon.Open();
            string query = "Select * from Hocvien where malop= N'" + frmLogin.lop + "' and chucvu= N'Lớp trưởng'";
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                NguoiDG = dr["tenhocvien"].ToString();
            }
        
            if (e.ColumnIndex == this.colEdit.Index)
            {
                MaHV = datagridDSHV.Rows[e.RowIndex].Cells[2].Value.ToString();
                hoten = datagridDSHV.Rows[e.RowIndex].Cells[3].Value.ToString();
                NhapRLKL frm = new NhapRLKL(this,MaHV,hoten, NguoiDG);
                datagridDSHV.Controls.Add(frm);
                frm.Show()  ;
            }
        }
    }
}
