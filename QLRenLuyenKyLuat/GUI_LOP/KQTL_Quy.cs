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

namespace QLRenLuyenKyLuat.GUI_LOP
{
    public partial class KQTL_Quy : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query;
        string MaHocVien;
        Calculator a = new Calculator();
        public KQTL_Quy()
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
            DSKQThelucQUY_LOP.DataSource = dtb;
            DSKQThelucQUY_LOP.AutoGenerateColumns = false;
            DSKQThelucQUY_LOP.AllowUserToAddRows = false;
            DSKQThelucQUY_LOP.AutoResizeColumns();
            sqlCon.Close();
        }

        
        private void HienText(string mahocvien)
        {
            
            string constr = Data_Provider.connectionSTR;
            string Sql;

            if (cbboxNam.Text == "2022")
            {
                if (cbbQuy.Text == "Quý 1")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between  CAST(N'2022-01-1' AS Date) and CAST(N'2022-03-31' AS Date) and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else if (cbbQuy.Text == "Quý 2")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between CAST(N'2022-04-1' AS Date) and CAST(N'2022-06-30' AS Date)" +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else if (cbbQuy.Text == "Quý 3")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between  CAST(N'2022-07-1' AS Date) and CAST(N'2022-09-30' AS Date)" +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                         " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between CAST(N'2022-10-1' AS Date) and CAST(N'2022-12-31' AS Date)" +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }

            }
            else if (cbboxNam.Text == "2023")
            {
                if (cbbQuy.Text == "Quý 1")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between CAST(N'2023-01-1' AS Date) and CAST(N'2023-03-31' AS Date)" +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else if (cbbQuy.Text == "Quý 2")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between CAST(N'2023-04-1' AS Date) and CAST(N'2023-06-30' AS Date)" +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else if (cbbQuy.Text == "Quý 3")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between CAST(N'2023-07-1' AS Date) and CAST(N'2023-09-30' AS Date)" +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between  CAST(N'2023-10-1' AS Date) and CAST(N'2023-12-31' AS Date)" +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
            }
            else if (cbboxNam.Text == "2024")
            {
                if (cbbQuy.Text == "Quý 1")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between CAST(N'2024-01-1' AS Date) and CAST(N'2024-03-31' AS Date)" +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else if (cbbQuy.Text == "Quý 2")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between CAST(N'2024-04-1' AS Date) and CAST(N'2024-06-30' AS Date)" +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else if (cbbQuy.Text == "Quý 3")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        " from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        " where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        " and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        " and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         " and ThoiGian between CAST(N'2024-07-1' AS Date) and CAST(N'2024-09-30' AS Date)3" +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        "from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        "where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        "and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        "and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         "and ThoiGian between CAST(N'2024-10-1' AS Date) and CAST(N'2024-12-31' AS Date) " +
                                          " and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
            }
            else
            {
                if (cbbQuy.Text == "Quý 1")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        "from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        "where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        "and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        "and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         "and ThoiGian between CAST(N'2025-01-1' AS Date) and CAST(N'2025-03-31' AS Date) " +
                                          "and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else if (cbbQuy.Text == "Quý 2")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        "from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        "where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        "and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        "and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         "and ThoiGian between CAST(N'2025-04-1' AS Date) and CAST(N'2025-06-30' AS Date) " +
                                          "and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else if (cbbQuy.Text == "Quý 3")
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        "from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        "where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        "and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        "and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                         "and ThoiGian between CAST(N'2025-07-1' AS Date) and CAST(N'2025-09-30' AS Date) " +
                                          "and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }
                else
                {
                    Sql = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                                        "from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                                        "where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                                        "and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                                        "and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                                        "and ThoiGian between CAST(N'2025-10-1' AS Date) and CAST(N'2025-12-31' AS Date) " +
                                          "and HOCVIEN.MaHocVien = N'" + mahocvien.Trim() + "'";
                }

            }
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    
                    txBoxHoten.Text = DR["TenHocVien"].ToString();
                    txboxGender.Text = DR["GioiTinh"].ToString();
                    txBoxBoi.Text = DR["Boi"].ToString();
                    txChaydai.Text = DR["ChayDai"].ToString();
                    txBoxChayngan.Text = DR["ChayNgan"].ToString();
                    if(txboxGender.Text == "Nam")
                    {
                        txBoxKeoXa.Text = DR["xa"].ToString();
                    }
                    else
                    {
                        txBoxKeoXa.Text = DR["ChongDay"].ToString();
                    }
                    txboxBat.Text = DR["NhayXa"].ToString();
                    KetQuaQuy.Text = DR["TenPLTL"].ToString();
                    
                }
                DR.Close();
            }
        }

        private void DSKQThelucQUY_LOP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MaHocVien = DSKQThelucQUY_LOP.SelectedRows[0].Cells[0].Value.ToString();
            HienText(MaHocVien);
            
        }
    }
}
