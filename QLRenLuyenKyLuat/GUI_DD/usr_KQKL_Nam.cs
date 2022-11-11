using QLRenLuyenKyLuat.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_KQKL_Nam : UserControl
    {
        public usr_KQKL_Nam()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query = "";
        string MaHV = "";
        string t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12;
        string[] kqhk1 = new string[10];
        string[] kqhk2 = new string[10];
        string KetQuaHK1, KetQuaHK2;
        int i, j;

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = 0;
                j = 0;
                MaHV = dtgv.SelectedRows[0].Cells[0].Value.ToString();
                txtHoTen.Text = dtgv.SelectedRows[0].Cells[1].Value.ToString();
                txtLop.Text = dtgv.SelectedRows[0].Cells[2].Value.ToString();
                txtMucPhanLoai.Text = string.Empty;
                txtNhanXet.Text = string.Empty;
                FindCheckNam(cbbNam.Text, MaHV);
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin thời gian");
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

        private void FindCheckHK(string date)
        {
            if (date == "2019-2020") // nam 1
            {
                t1 = "082019";
                t2 = "092019";
                t3 = "102019";
                t4 = "112019";
                t5 = "122019";
                t6 = "012020";
                t7 = "022020";
                t8 = "032020";
                t9 = "042020";
                t10 = "052020";
                t11 = "062020";
                t12 = "072020";
            }
            else if (date == "2020-2021") // nam 2
            {
                t1 = "082020";
                t2 = "092020";
                t3 = "102020";
                t4 = "112020";
                t5 = "122020";
                t6 = "012021";
                t7 = "022021";
                t8 = "032021";
                t9 = "042021";
                t10 = "052021";
                t11 = "062021";
                t12 = "072021";
            }

            else if (date == "2021-2022") // nam 3
            {
                t1 = "082021";
                t2 = "092021";
                t3 = "102021";
                t4 = "112021";
                t5 = "122021";
                t6 = "012022";
                t7 = "022022";
                t8 = "032022";
                t9 = "042022";
                t10 = "052022";
                t11 = "062022";
                t12 = "072022";
            }
            else if (date == "2022-2023") // nam 4
            {
                t1 = "082022";
                t2 = "092022";
                t3 = "102022";
                t4 = "112022";
                t5 = "122022";
                t6 = "012023";
                t7 = "022023";
                t8 = "032023";
                t9 = "042023";
                t10 = "052023";
                t11 = "062023";
                t12 = "072023";
            }

            else if (date == "2023-2024") // nam 5
            {
                t1 = "082023";
                t2 = "092023";
                t3 = "102023";
                t4 = "112023";
                t5 = "122023";
                t6 = "012024";
                t7 = "022024";
                t8 = "032024";
                t9 = "042024";
                t10 = "052024";
                t11 = "062024";
                t12 = "062024";
            }
        }

        private void FindCheckNam(string date, string mahv)
        {
            FindCheckHK(date);
            string constr = Data_Provider.connectionSTR;
            string Sql = "select  MaPLKL, NhanXet " +
                "from HOCVIEN, HocVien_PLRL, DIEM_PLKL " +
                "where HocVien.MaHocVien = HocVien_PLRL.MaHocVien " +
                "and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%DD%' " +
                "and (DIEM_PLKL.MaDiemPLKL LIKE '%" + t1 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t2 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t3 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t4 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t5 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t6 + "%') " +
                "and HocVien_PLRL.MaHocVien = '" + mahv.Trim() + "'";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read() || i == 10)
                {
                    kqhk1[i] = DR["MaPLKL"].ToString();
                    txtNhanXet.Text = DR["NhanXet"].ToString();
                    i++;
                }
                DR.Close();
                conn.Close();
            }
            if (i <= 5)
            {
                MessageBox.Show("Không đủ dữ liệu của học viên " + txtHoTen.Text.Trim() + " học kỳ 1", "Thông báo");
                txtMucPhanLoai.Text = "Chưa đủ dữ liệu";
            }
            else
            {
                KetQuaHK1 = Calculator.cal_DiemRLHocKy(kqhk1[0], kqhk1[1], kqhk1[2], kqhk1[3], kqhk1[4], kqhk1[5]);
            }


            Sql = "select  MaPLKL, NhanXet " +
                "from HOCVIEN, HocVien_PLRL, DIEM_PLKL " +
                "where HocVien.MaHocVien = HocVien_PLRL.MaHocVien " +
                "and HOCVIEN_PLRL.MaDiemPLRL = DIEM_PLKL.MaDiemPLKL " +
                "and DIEM_PLKL.MaDiemPLKL LIKE '%DD%' " +
                "and (DIEM_PLKL.MaDiemPLKL LIKE '%" + t7 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t8 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t9 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t10 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t11 + "%' " +
                "or DIEM_PLKL.MaDiemPLKL LIKE '%" + t12 + "%') " +
                "and HocVien_PLRL.MaHocVien = '" + mahv.Trim() + "'";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(Sql, conn);
                SqlDataReader DR1 = cmd1.ExecuteReader();

                while (DR1.Read() || j == 10)
                {
                    kqhk2[i] = DR1["MaPLKL"].ToString();
                    txtNhanXet.Text = DR1["NhanXet"].ToString();
                    j++;
                }
                DR1.Close();
                conn.Close();
            }
            if (j <= 5)
            {
                MessageBox.Show("Không đủ dữ liệu của học viên " + txtHoTen.Text.Trim() + " học kỳ 2", "Thông báo");
                txtMucPhanLoai.Text = "Chưa đủ dữ liệu";
            }
            else
            {
                KetQuaHK2 = Calculator.cal_DiemRLHocKy(kqhk2[0], kqhk2[1], kqhk2[2], kqhk2[3], kqhk2[4], kqhk2[5]);
            }

            txtMucPhanLoai.Text = Calculator.cal_DiemRLNam(KetQuaHK1, KetQuaHK2);
        }

        private void usr_KQKL_Nam_Load(object sender, EventArgs e)
        {
            query = "select MaHocVien, TenHocVien, MaLop, GioiTinh, CapBac from HocVien";
            connect(query);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select MaHocVien, TenHocVien, MaLop, GioiTinh, CapBac, ChucVu " +
                    "from HocVien " +
                    "where MaHocVien != ' ' " +
                    "and ";
                if (cbbMuc.Text == string.Empty || txtNoiDung.Text == string.Empty)
                {
                    usr_KQKL_Nam_Load(sender, e);
                }

                if (cbbMuc.Text == "Tên học viên")
                {
                    connect(query + " tenhocvien LIKE N'%" + txtNoiDung.Text + "%'");
                }
                else if (cbbMuc.Text == "Lớp")
                {
                    connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%'");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}