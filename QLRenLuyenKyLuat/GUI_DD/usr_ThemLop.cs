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

namespace QLRenLuyenKyLuat.GUI_DD
{
    public partial class usr_ThemLop : UserControl
    {
        public usr_ThemLop()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(Data_Provider.connectionSTR);


        private void CapNhat(string query)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        private void usr_ThemLop_Load(object sender, EventArgs e)
        {

        }

        private void bthAdd_Click(object sender, EventArgs e)
        {

        }

        private void bthRefesh_Click(object sender, EventArgs e)
        {
            txtMaDD.Text = string.Empty;
        }
    }
}
