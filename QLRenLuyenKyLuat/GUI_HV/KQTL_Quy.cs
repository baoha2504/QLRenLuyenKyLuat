using QLRenLuyenKyLuat.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QLRenLuyenKyLuat.GUI_HV
{
    public partial class KQTL_Quy : DevExpress.XtraEditors.XtraUserControl
    {
        public KQTL_Quy()
        {
            InitializeComponent();
            cbb_Nam.Text = DateTime.Now.Year.ToString();
            ThangDau(DateTime.Now.Month);
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query;
        int thang;
        int thangConLai1;
        int thangConLai2;

        private void connect()
        {
            thangConLai1 = thang + 1;
            thangConLai2 = thang + 2;

            query = "select HOCVIEN.TenHocVien, HOCVIEN.GioiTinh, NhayXa , Boi, ChayDai, ChayNgan, ChongDay, Xa, TenPLTL " +
                "from KETQUATHELUC, HOCVIEN_PLTL, HOCVIEN, PHANLOAITHELUC " +
                "where KETQUATHELUC.MaKQTL = HOCVIEN_PLTL.MaKQTL " +
                "and PHANLOAITHELUC.MaPLTL = KETQUATHELUC.MaPLTL " +
                "and HOCVIEN.MaHocVien = HOCVIEN_PLTL.MaHocVien " +
                "and YEAR(HOCVIEN_PLTL.ThoiGian) = " + cbb_Nam.Text + 
                " and (Month(HOCVIEN_PLTL.ThoiGian) = " + thang + " " +
                "or Month(HOCVIEN_PLTL.ThoiGian) = " + thangConLai1 + " " +
                "or Month(HOCVIEN_PLTL.ThoiGian) = " + thangConLai2 + ") " +
                "and Hocvien.MaHocVien = N'" + frmLogin.maNguoiDung + "'";

            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            sqlCon.Close();
            string chongday;
            string xa;
            if (dtb.Rows.Count == 1)
            {

                foreach (DataRow dr in dtb.Rows)
                {
                    txt_ChayDai.Text = dr["ChayDai"].ToString();
                    txt_ChayNgan.Text = dr["ChayNgan"].ToString();
                    txt_BatXa.Text = dr["NhayXa"].ToString();
                    txt_Boi.Text = dr["Boi"].ToString();
                    txt_KetQua.Text = dr["TenPLTL"].ToString();
                    chongday = dr["ChongDay"].ToString();
                    xa = dr["Xa"].ToString();
                    if (chongday != string.Empty)
                    {
                        txt_Xa.Text = dr["ChongDay"].ToString();
                    }
                    else
                    {
                        txt_Xa.Text = dr["Xa"].ToString();
                    }

                }
            }else
            {
                MessageBox.Show("Không đủ dữ liệu để hiển thị");
            }
        }

        private void Hien_CbbQuy()
        {
            DateTime date = DateTime.Now; 
            thang = date.Month;
            if (thang == 1 || thang == 2 || thang == 3)
            {
                cbb_Quy.SelectedIndex = 0;
            }
            else if (thang == 4 || thang == 5 || thang == 6)
            {
                cbb_Quy.SelectedIndex = 1;
            }
            else if (thang == 7 || thang == 8 || thang == 9)
            {
                cbb_Quy.SelectedIndex = 2;
            }
            else
            {
                //cbB_TL_Quy.Text = "4";
                cbb_Quy.SelectedIndex = 3;
            }
            //string quy = cbb_Quy.Text;
            int q = int.Parse(cbb_Quy.Text);
            ThangDau(q);

        }

        private void ThangDau(int quy) //Tính tháng đầu
        {
            if (quy == 1)
            {
                thang = 1;
            }
            else if (quy == 2)
            {
                thang = 4;
            }
            else if (quy == 3)
            {
                thang = 7;

            }
            else
            {
                thang = 10;
            }
        }


        private void KQTL_Quy_Load(object sender, EventArgs e)
        {
            Hien_CbbQuy();
            cbb_Nam.SelectedIndex = 1;
            connect();
        }

        private void cbb_Quy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_ChayDai.Clear();
            txt_ChayNgan.Clear();
            txt_BatXa.Clear();
            txt_Boi.Clear();
            txt_Xa.Clear();
            txt_KetQua.Clear();
            if (cbb_Quy.Text == null || cbb_Quy.Text == string.Empty)
            {
                cbb_Quy.Text = "1";
            }
            int quy = int.Parse(cbb_Quy.Text);
            ThangDau(quy);
            connect();
        }

        private void cbb_Nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_ChayDai.Clear();
            txt_ChayNgan.Clear();
            txt_BatXa.Clear();
            txt_Boi.Clear();
            txt_Xa.Clear();
            txt_KetQua.Clear();
            if (cbb_Quy.Text == null || cbb_Quy.Text == string.Empty)
            {
                cbb_Quy.Text = "1";
            }
            int quy = int.Parse(cbb_Quy.Text);
            ThangDau(quy);
            connect();
        }
    }
}
