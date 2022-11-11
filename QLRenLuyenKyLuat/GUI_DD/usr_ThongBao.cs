using QLRenLuyenKyLuat.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_ThongBao : UserControl
    {
        public usr_ThongBao()
        {
            InitializeComponent();
            datetimepicker.Text = DateTime.Now.ToString("dd/MM/yyyy");
            check = date.ToString("MM").Trim() + date.ToString("yyyy").Trim();
            beforeCheck = date.AddMonths(-1).ToString("MM").Trim() + date.AddMonths(-1).ToString("yyyy").Trim();
            afterCheck = date.AddMonths(1).ToString("MM").Trim() + date.AddMonths(1).ToString("yyyy").Trim();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);
        string query = "";
        DateTime date = DateTime.Now;
        string check;
        string beforeCheck;
        string afterCheck;
        string txt;

        private void LoadText(string sql)
        {
            string constr = Data_Provider.connectionSTR;
            string Sql = sql;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    txt = DR["SoLuong"].ToString();
                    break;
                }
                DR.Close();
                conn.Close();
            }
        }

        private void usr_ThongBao_Load(object sender, EventArgs e)
        {
            query = "select COUNT(MaQL) as 'SoLuong' from QUANLY where HoatDong = 1";
            LoadText(query);
            txtTongCB.Text = txt;
            query = "select COUNT(MaHocVien) as 'SoLuong' from HOCVIEN where HoatDong = 1";
            LoadText(query);
            txtTongHV.Text = txt;
            txtTongQS.Text = (Int32.Parse(txtTongCB.Text) + Int32.Parse(txtTongHV.Text)).ToString();
            query = "select COUNT(MaHVPLRL) as 'SoLuong' from HOCVIEN_PLRL where MaHVPLRL LIKE '%" + check + "DD%'";
            LoadText(query);
            txtSoKQKL.Text = txt;
            query = "select COUNT(MaHVPLTL) as 'SoLuong' " +
                "from HOCVIEN_PLTL " +
                "where MaHVPLTL LIKE '%"+check+"%' " +
                "or MaHVPLTL LIKE '%"+beforeCheck+"%' " +
                "or MaHVPLTL LIKE '%"+afterCheck+"%'";
            LoadText(query);
            txtSoKQTL.Text = txt;
        }
    }
}
