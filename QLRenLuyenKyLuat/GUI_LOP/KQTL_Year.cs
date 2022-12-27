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
using QLRenLuyenKyLuat.Data;

namespace QLRenLuyenKyLuat.GUI_LOP
{
    public partial class KQTL_Year : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query;
        string MaHocVien;
        Calculator a = new Calculator();
        public KQTL_Year()
        {
            query = "select MaHocVien as 'Mã học viên', TenHocVien as 'Họ và tên', GioiTinh as 'Giới tính', CapBac as 'Cấp bậc', ChucVu as 'Chức vụ' from HOCVIEN where maLop like N'%" + frmLogin.maLop.Trim() + "%'";
            InitializeComponent();
            connect(query);
        }
        
        private void connect(string query)
        {
            sqlCon.Close();
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            DSKQThelucYear_LOP.DataSource = dtb;
            DSKQThelucYear_LOP.AutoGenerateColumns = false;
            DSKQThelucYear_LOP.AllowUserToAddRows = false;
            DSKQThelucYear_LOP.AutoResizeColumns();
            sqlCon.Close();
        }

        private void HienText(string mahocvien)
        {
            int i = 1;
            string constr = Data_Provider.connectionSTR;
            string Sql;
            if (cmboxNamhoc.Text == "2022")
            {
                Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, Month(thoigian)  as thoigian,PHANLOAITHELUC.TenPLTL " +
                " from HOCVIEN, HOCVIEN_PLTL, KETQUATHELUC, PHANLOAITHELUC " +
                " where HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                " and HOCVIEN_PLTL.MaKQTL = KETQUATHELUC.MaKQTL " +
                " and KETQUATHELUC.MaPLTL = PHANLOAITHELUC.MaPLTL " +
                " and  thoigian between  CAST(N'2022-01-1' AS Date) and CAST(N'2022-12-31' AS Date) and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
            }
            else if(cmboxNamhoc.Text == "2023")
            {
                Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, Month(thoigian)  as thoigian,PHANLOAITHELUC.TenPLTL " +
                " from HOCVIEN, HOCVIEN_PLTL, KETQUATHELUC, PHANLOAITHELUC " +
                " where HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                " and HOCVIEN_PLTL.MaKQTL = KETQUATHELUC.MaKQTL " +
                " and KETQUATHELUC.MaPLTL = PHANLOAITHELUC.MaPLTL " +
                " and  thoigian between   CAST(N'2023-01-1' AS Date) and CAST(N'2023-12-31' AS Date) and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
            }
            else if(cmboxNamhoc.Text == "2024")
            {
                Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh,Month(thoigian)  as thoigian, PHANLOAITHELUC.TenPLTL " +
               " from HOCVIEN, HOCVIEN_PLTL, KETQUATHELUC, PHANLOAITHELUC " +
               " where HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
               " and HOCVIEN_PLTL.MaKQTL = KETQUATHELUC.MaKQTL " +
               " and KETQUATHELUC.MaPLTL = PHANLOAITHELUC.MaPLTL " +
               " and  thoigian between   CAST(N'2024-01-1' AS Date) and CAST(N'2024-12-31' AS Date) and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
            }
            else
            {
                Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh,Month(thoigian)  as thoigian, PHANLOAITHELUC.TenPLTL " +
                 " from HOCVIEN, HOCVIEN_PLTL, KETQUATHELUC, PHANLOAITHELUC " +
                 " where HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                 " and HOCVIEN_PLTL.MaKQTL = KETQUATHELUC.MaKQTL " +
                 " and KETQUATHELUC.MaPLTL = PHANLOAITHELUC.MaPLTL " +
                 " and  thoigian between   CAST(N'2025-01-1' AS Date) and CAST(N'2025-12-31' AS Date) and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";

            }
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    //cbbThoiGian.Items.Add(DR[0]);
                    txBoxHoten.Text = DR["TenHocVien"].ToString();
                    txboxGender.Text = DR["GioiTinh"].ToString();
                    if (int.Parse(DR["thoigian"].ToString()) == 3)
                    {
                        txtQuy1.Text = DR["TenPLTL"].ToString();
                    }
                    else if (int.Parse(DR["thoigian"].ToString()) == 6)
                    {
                        txtQuy2.Text = DR["TenPLTL"].ToString();
                    }
                    else if( int.Parse(DR["thoigian"].ToString()) == 9)
                    {
                        txtQuy3.Text = DR["TenPLTL"].ToString();
                    }
                    else if (int.Parse(DR["thoigian"].ToString()) == 12)
                    {
                        txtQuy4.Text = DR["TenPLTL"].ToString();
                    }
                    i++;
                }
                DR.Close();
            }
        }

        private void DSKQThelucYear_LOP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MaHocVien = DSKQThelucYear_LOP.SelectedRows[0].Cells[0].Value.ToString();
            HienText(MaHocVien);
            txtCaNam.Text = a.cal_TinhTheLucNam(txtQuy1.Text.Trim(), txtQuy2.Text.Trim(), txtQuy3.Text.Trim(), txtQuy4.Text.Trim());
        }
    }
}
