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
namespace QLRenLuyenKyLuat.GUI_LOP
{
    public partial class NhapRLKL : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        public DSHocvien dshv;
      
      
        public NhapRLKL(DSHocvien frm, string mahv, string hoten, string NgDG)
        {
            InitializeComponent();
            this.dshv = frm;
            txtboxMaHV.Text = mahv;
            txtBoxTen.Text = hoten;
            txtBoxNgDG.Text = NgDG;
        }

        private void RenLuyenKL_Load(object sender, EventArgs e)
        {
            sqlCon.Close();
            sqlCon.Open();
            DateTime dt = DateTime.Now;
            txBoxNhapThang.Text = dt.Month.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                /* sqlCon.Close();
                 sqlCon.Open();
                 string query = "INSERT INTO  Diem_PLKL(MaDiemPLKL, DiemKL, DiemHT, DiemLS, NhanXet, NguoiDanhGia, CapDanhGia, MaPLKL) VALUES([dbo].auto_MaHVPLRL(N'" + txtboxMaHV.Text + "') , " + int.Parse(txtboxDiemKL.Text) + ","
                     + int.Parse(txtBoxDiemHT.Text) + "," + int.Parse(txtBoxDiemLS.Text) + ", N'" +
                     txtBox_NhanXet.Text + "', N'" + txtBoxNgDG.Text + "', N'L' , N'" + txtBoxXepLoai.Text + "')";*/


                /*  SqlCommand sqlDa = new SqlCommand(query, sqlCon);
                  sqlDa.ExecuteNonQuery();
                  sqlCon.Close();*/
                //dacheck = 1;
                DSHocvien.check = 1;
                
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelNhapKL_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kết quả chưa được lưu. Bạn chắc chắn muốn thoát?", "HỎI?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DSHocvien.check = 0;
                //DSHocvien ds = new DSHocvien(this, check);
                this.Hide();
            }
            else
            {
                this.Visible = true;
            }
        }
        public static int sum = 0;
        public static string xeploai;
        public static int[] HT = new int[3];
        public static int[] KL = new int[3];
        public static int[] LS = new int[3];
        private void txtBoxSum_MouseClick(object sender, MouseEventArgs e)
        {
            sqlCon.Close();
            sqlCon.Open();
            int diem1 = int.Parse(txtboxDiemKL.Text);
            int diem2 = int.Parse(txtBoxDiemLS.Text);
            int diem3 = int.Parse(txtBoxDiemHT.Text);
           
            while (diem1 > 10 || diem1 < 0)
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
            }
                
            
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
            txtBox_NhanXet.Focus();
        }

       
    }
}
