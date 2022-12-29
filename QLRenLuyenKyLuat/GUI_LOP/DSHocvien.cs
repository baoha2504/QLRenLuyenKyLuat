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
using System.Text.RegularExpressions;
using QLRenLuyenKyLuat.Data;

namespace QLRenLuyenKyLuat.GUI_LOP
{
    public partial class DSHocvien : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        public static int check;
        public DSHocvien()
        {
            InitializeComponent();
            //int a = 0;
            
        }
        public int checkbox;
       
        
        private void DSHocvien_Load(object sender, EventArgs e)
        {
            errorProvider1.ContainerControl = this;
            connect();
        }

        private void connect() // danh sach hoc vien
        {
            sqlCon.Close();
            sqlCon.Open();
            
            SqlDataAdapter sqlDa = new SqlDataAdapter("select MaHocVien as 'Mã học viên', TenHocVien as 'Họ và tên', GioiTinh as 'Giới tính', CapBac as 'Cấp bậc', ChucVu as 'Chức vụ' from HOCVIEN where maLop like N'%" + frmLogin.maNguoiDung.Trim() + "%'", sqlCon);

            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            datagridDSHV.DataSource = dtb;
            datagridDSHV.AutoGenerateColumns = false;
            datagridDSHV.AllowUserToAddRows = false;
            datagridDSHV.AutoResizeColumns();
            sqlCon.Close();

        }
        private void datagridDSHV_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            sqlCon.Close();
            sqlCon.Open();
            string query = "Select * from Hocvien where maLop like N'%" + frmLogin.maNguoiDung.Trim() + "%' and chucvu= N'Lớp trưởng'";
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                txtBoxNgDG.Text = dr["MaHocVien"].ToString();
            }
            
            txtboxMaHV.Text = datagridDSHV.SelectedRows[0].Cells[1].Value.ToString();
            txtBoxTen.Text = datagridDSHV.SelectedRows[0].Cells[2].Value.ToString();

            // datagridDSHV.Rows[e.RowIndex].Cells[1].Value = check;

        }
        public int count;
        DateTime date = DateTime.Now;
        private void btnDeNghi_Click(object sender, EventArgs e)
        {
            int dem = 0;
            for (int row = 0; row < datagridDSHV.Rows.Count; ++row)
            {
                if (Convert.ToInt32(datagridDSHV.Rows[row].Cells[0].Value) == 1)
                {
                    dem++;
                }
            }
            sqlCon.Close();
            sqlCon.Open();
            string query = "select count(MaHocVien) as soluong from HOCVIEN where MaLop = N'" + frmLogin.maNguoiDung + "'";
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                count = int.Parse(dr["soluong"].ToString());
            }
            if (dem == count)
            {
                sqlCon.Close();
                sqlCon.Open();
                for (int row = 0; row < datagridDSHV.Rows.Count; ++row)
                {
                    String q = "INSERT INTO  Hocvien_PLRL(MaHVPLRL, thoigian, MaHocvien, MaDiemPLRL) VALUES([dbo].auto_MaHVPLRL('" + (string)(datagridDSHV.Rows[row].Cells[1].Value.ToString().Trim()) + "'), " +
                        "CAST(N'" + date.Date.ToString("yyyy/MM/dd") + "' AS DATE) , N'" + (string)(datagridDSHV.Rows[row].Cells[1].Value.ToString().Trim()) + "'," +
                        " [dbo].auto_MaDiemPLKL(N'" + (string)(datagridDSHV.Rows[row].Cells[1].Value.ToString().Trim()) + "'))";
                    SqlCommand sqld = new SqlCommand(q, sqlCon);
                    sqld.ExecuteNonQuery();
                    
                }
                sqlCon.Close();
                MessageBox.Show("Đã đề nghị thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult warn = MessageBox.Show("Có học viên chưa được đánh giá. Vui lòng kiểm tra lại!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }
        private void clear()
        {
            txtBoxTen.Text = "";
            txtboxMaHV.Text = "";
            txtboxDiemKL.Text = "";
            txtBoxDiemHT.Text = "";
            txtBoxDiemLS.Text = "";
            txtBoxNgDG.Text = "";
            txtBoxSum.Text = "";
            txtBoxXepLoai.Text = "";
            txtBox_NhanXet.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Close();
                sqlCon.Open();
                string query = "INSERT INTO  Diem_PLKL(MaDiemPLKL, DiemKL, DiemHT, DiemLS, NhanXet, NguoiDanhGia, CapDanhGia, MaPLKL) VALUES([dbo].auto_MaDiemPLKL(N'" + txtboxMaHV.Text.Trim() + "') , " + int.Parse(txtboxDiemKL.Text) + 
                    "," + int.Parse(txtBoxDiemHT.Text.Trim()) + "," + int.Parse(txtBoxDiemLS.Text.Trim()) + ", N'" + txtBox_NhanXet.Text.Trim() + "', N'" + txtBoxNgDG.Text.Trim() + "', N'L' , N'" + txtBoxXepLoai.Text.Trim() + "')";
                SqlCommand sqlDa = new SqlCommand(query, sqlCon);
                sqlDa.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Đã lưu thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datagridDSHV.SelectedRows[0].Cells[0].Value = 1;
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Học viên đã được đánh giá rèn luyện kỷ luật tháng!", "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public  int sum = 0;
        public  string xeploai;
        public  int[] HT = new int[3];
        public  int[] KL = new int[3];
        public  int[] LS = new int[3];
        private void txtBoxSum_MouseClick(object sender, MouseEventArgs e)
        {
            sqlCon.Close();
            sqlCon.Open();
            int diem1 = int.Parse(txtboxDiemKL.Text);
            int diem2 = int.Parse(txtBoxDiemLS.Text);
            int diem3 = int.Parse(txtBoxDiemHT.Text);

            /*while (diem1 > 10 || diem1 < 0)
            {
                DialogResult warn = MessageBox.Show("Điểm nằm trong khoảng từ 0 đến 10. Vui lòng nhập lại điểm!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtboxDiemKL.Focus();
            }

            while (diem2 > 10 || diem2 < 0)
            {
                DialogResult warn = MessageBox.Show("Điểm nằm trong khoảng từ 0 đến 10. Vui lòng nhập lại điểm!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtBoxDiemLS.Focus();
            }

            while (diem3 > 10 || diem3 < 0)
            {
                DialogResult warn = MessageBox.Show("Điểm nằm trong khoảng từ 0 đến 10. Vui lòng nhập lại điểm!", "Cảnh báo?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtBoxDiemHT.Focus();
            }*/


            sum = diem1 + diem2 + diem3;
            txtBoxSum.Text = sum.ToString();

            string queryHT = "select muc1, muc2, muc3 from QUYCHUANKYLUAT join (select MaQLQC, ThoiGian from QUYCHUAN where ThoiGian = (select Max(thoigian) from QUYCHUAN )) as b on QUYCHUANKYLUAT.MaQLQC = b.MaQLQC and NoiDung = N'Học tập'";
            string queryKL = "select muc1, muc2, muc3 from QUYCHUANKYLUAT join (select MaQLQC, ThoiGian from QUYCHUAN where ThoiGian = (select Max(thoigian) from QUYCHUAN )) as b on QUYCHUANKYLUAT.MaQLQC = b.MaQLQC and NoiDung = N'Kỷ luật'";
            string queryLS = "select muc1, muc2, muc3 from QUYCHUANKYLUAT join (select MaQLQC, ThoiGian from QUYCHUAN where ThoiGian = (select Max(thoigian) from QUYCHUAN )) as b on QUYCHUANKYLUAT.MaQLQC = b.MaQLQC and NoiDung = N'Lối sống'";
            SqlDataAdapter sqlDaHT = new SqlDataAdapter(queryHT, sqlCon);
            SqlDataAdapter sqlDaKL = new SqlDataAdapter(queryKL, sqlCon);
            SqlDataAdapter sqlDaLS = new SqlDataAdapter(queryLS, sqlCon);
            DataTable dtHT = new DataTable();
            DataTable dtKL = new DataTable();
            DataTable dtLS = new DataTable();
            sqlDaHT.Fill(dtHT);
            sqlDaKL.Fill(dtKL);
            sqlDaLS.Fill(dtLS);

            foreach (DataRow dr in dtHT.Rows)
            {
                HT[0] = int.Parse(dr["muc1"].ToString());
                HT[1] = int.Parse(dr["muc2"].ToString());
                HT[2] = int.Parse(dr["muc3"].ToString());
            }
            foreach (DataRow dr in dtKL.Rows)
            {
                KL[0] = int.Parse(dr["muc1"].ToString());
                KL[1] = int.Parse(dr["muc2"].ToString());
                KL[2] = int.Parse(dr["muc3"].ToString());
            }
            foreach (DataRow dr in dtLS.Rows)
            {
                LS[0] = int.Parse(dr["muc1"].ToString());
                LS[1] = int.Parse(dr["muc2"].ToString());
                LS[2] = int.Parse(dr["muc3"].ToString());
            }
            xeploai = Calculator.cal_DiemRLThang(diem1, diem2, diem3, KL, LS, HT);


            txtBoxXepLoai.Text = xeploai;
            
        }

        private void txtboxDiemKL_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^[0-9]+$");
            string text = txtboxDiemKL.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtboxDiemKL.Text))
            {
                e.Cancel = true;
                txtboxDiemKL.Focus();
                errorProvider1.SetError(txtboxDiemKL, "Vui lòng nhập điểm.");
            }
            else
            {
                if(result == false)
                {
                    e.Cancel = true;
                    txtboxDiemKL.Focus();
                    errorProvider1.SetError(txtboxDiemKL, "Chỉ có số!");
                }
                else
                {
                    if (int.Parse(txtboxDiemKL.Text) > 10 || int.Parse(txtboxDiemKL.Text) < 0)
                    {
                        e.Cancel = true;
                        txtboxDiemKL.Focus();
                        errorProvider1.SetError(txtboxDiemKL, "Vui lòng nhập điểm từ 0-10.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtboxDiemKL, null);
                    }
                }
                
            }
        }
       
        private void txtBoxDiemLS_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^[0-9]+$");
            string text = txtBoxDiemLS.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtBoxDiemLS.Text))
            {
                e.Cancel = true;
                txtBoxDiemLS.Focus();
                errorProvider1.SetError(txtBoxDiemLS, "Vui lòng nhập điểm.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txtBoxDiemLS.Focus();
                    errorProvider1.SetError(txtboxDiemKL, "Chỉ có số!");
                }
                else
                {
                    if (int.Parse(txtBoxDiemLS.Text) > 10 || int.Parse(txtBoxDiemLS.Text) < 0)
                    {
                        e.Cancel = true;
                        txtBoxDiemLS.Focus();
                        errorProvider1.SetError(txtBoxDiemLS, "Vui lòng nhập điểm từ 0-10.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtBoxDiemLS, null);
                    }
                }
            }
            
        }

        private void txtBoxDiemHT_Validating(object sender, CancelEventArgs e)
        {
            Regex CharRegex = new Regex("^[0-9]+$");
            string text = txtBoxDiemLS.Text;
            bool result = CharRegex.IsMatch(text);
            if (string.IsNullOrEmpty(txtBoxDiemHT.Text))
            {
                e.Cancel = true;
                txtBoxDiemHT.Focus();
                errorProvider1.SetError(txtBoxDiemHT, "Vui lòng nhập điểm.");
            }
            else
            {
                if (result == false)
                {
                    e.Cancel = true;
                    txtBoxDiemLS.Focus();
                    errorProvider1.SetError(txtboxDiemKL, "Chỉ có số!");
                }
                else
                {
                    if (int.Parse(txtBoxDiemHT.Text) > 10 || int.Parse(txtBoxDiemHT.Text) < 0)
                    {
                        e.Cancel = true;
                        txtBoxDiemHT.Focus();
                        errorProvider1.SetError(txtBoxDiemHT, "Vui lòng nhập điểm từ 0-10.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtBoxDiemHT, null);
                    }
                }               
            }
        }

        private void txtBox_NhanXet_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBox_NhanXet.Text))
            {
                e.Cancel = true;   
                errorProvider1.SetError(txtBox_NhanXet, "Vui lòng cho nhận xét.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBox_NhanXet, null);
            }
        }  
    }
}
