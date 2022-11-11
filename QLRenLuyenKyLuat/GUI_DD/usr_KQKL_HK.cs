using QLRenLuyenKyLuat.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_KQKL_HK : UserControl
    {
        public usr_KQKL_HK()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query = "";
        string MaHV = "";
        string t1, t2, t3, t4, t5, t6;
        string[] kq = new string[10];
        int i;

        //ki 1 ----8 9 10 11 12 1
        //ki 2 ----2 3 4 5 6 7

        private void FindCheck(string date)
        {
            if (date == "HK1 2019-2020") // nam 1
            {
                t1 = "082019";
                t2 = "092019";
                t3 = "102019";
                t4 = "112019";
                t5 = "122019";
                t6 = "012020";
            }
            else if (date == "HK2 2019-2020")
            {
                t1 = "022020";
                t2 = "032020";
                t3 = "042020";
                t4 = "052020";
                t5 = "062020";
                t6 = "072020";
            }
            else if (date == "HK1 2020-2021") // nam 2
            {
                t1 = "082020";
                t2 = "092020";
                t3 = "102020";
                t4 = "112020";
                t5 = "122020";
                t6 = "012021";
            }
            else if (date == "HK2 2020-2021")
            {
                t1 = "022021";
                t2 = "032021";
                t3 = "042021";
                t4 = "052021";
                t5 = "062021";
                t6 = "072021";
            }
            else if (date == "HK1 2021-2022") // nam 3
            {
                t1 = "082021";
                t2 = "092021";
                t3 = "102021";
                t4 = "112021";
                t5 = "122021";
                t6 = "012022";
            }
            else if (date == "HK2 2021-2022")
            {
                t1 = "022022";
                t2 = "032022";
                t3 = "042022";
                t4 = "052022";
                t5 = "062022";
                t6 = "072022";
            }
            else if (date == "HK1 2022-2023") // nam 4
            {
                t1 = "082022";
                t2 = "092022";
                t3 = "102022";
                t4 = "112022";
                t5 = "122022";
                t6 = "012023";
            }
            else if (date == "HK2 2022-2023")
            {
                t1 = "022023";
                t2 = "032023";
                t3 = "042023";
                t4 = "052023";
                t5 = "062023";
                t6 = "072023";
            }
            else if (date == "HK1 2023-2024") // nam 5
            {
                t1 = "082023";
                t2 = "092023";
                t3 = "102023";
                t4 = "112023";
                t5 = "122023";
                t6 = "012024";
            }
            else if (date == "HK2 2023-2024")
            {
                t1 = "022024";
                t2 = "032024";
                t3 = "042024";
                t4 = "052024";
                t5 = "062024";
                t6 = "062024";
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

        private void usr_KQKL_HK_Load(object sender, EventArgs e)
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
                    usr_KQKL_HK_Load(sender, e);
                }

                if (cbbMuc.Text == "Tên học viên")
                {
                    connect(query + " tenhocvien LIKE N'%" + txtNoiDung.Text + "%'");
                }
                else if (cbbMuc.Text == "Lớp")
                {
                    connect(query + " malop LIKE N'%" + txtNoiDung.Text + "%'");
                }
                FindCheck(cbbHK.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = 0;
                MaHV = dtgv.SelectedRows[0].Cells[0].Value.ToString();
                txtHoTen.Text = dtgv.SelectedRows[0].Cells[1].Value.ToString();
                txtLop.Text = dtgv.SelectedRows[0].Cells[2].Value.ToString();
                txtMucPhanLoai.Text = string.Empty;
                txtNhanXet.Text = string.Empty;

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
                    "and HocVien_PLRL.MaHocVien = '" + MaHV.Trim() + "'";
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Sql, conn);
                    SqlDataReader DR = cmd.ExecuteReader();

                    while (DR.Read() || i == 10)
                    {
                        kq[i] = DR["MaPLKL"].ToString();
                        txtNhanXet.Text = DR["NhanXet"].ToString();
                        i++;
                    }
                    DR.Close();
                    conn.Close();
                } 
                if (i <= 5)
                {
                    MessageBox.Show("Không đủ dữ liệu để xét rèn luyện học kỳ của học viên " + txtHoTen.Text.Trim(), "Thông báo");
                    txtMucPhanLoai.Text = "Chưa đủ dữ liệu";
                }
                else
                {
                    txtMucPhanLoai.Text = Calculator.cal_DiemRLHocKy(kq[0], kq[1], kq[2], kq[3], kq[4], kq[5]);
                }
            }

            catch
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin thời gian");
            }
        }
    }
}
