using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRenLuyenKyLuat.Data
{
    class Calculator
    {
        public string cal_TinhTheLucNam(string KQ_Quy1, string KQ_Quy2, string KQ_Quy3, string KQ_Quy4)
        {
            int ThongKeGioi = 0;
            int ThongKeKha = 0;
            int ThongKeDat = 0;
            int ThongKeKhongDat = 0;
            int sum = 0;

            if(KQ_Quy1 == "Giỏi")
            {
                ThongKeGioi++;
            } else if (KQ_Quy1 == "Khá")
            {
                ThongKeKha++;
            } else if (KQ_Quy1 == "Đạt")
            {
                ThongKeDat++;
            } else
            {
                ThongKeKhongDat++;
            }

            if (KQ_Quy2 == "Giỏi")
            {
                ThongKeGioi++;
            }
            else if (KQ_Quy2 == "Khá")
            {
                ThongKeKha++;
            }
            else if (KQ_Quy2 == "Đạt")
            {
                ThongKeDat++;
            }
            else
            {
                ThongKeKhongDat++;
            }

            if (KQ_Quy3 == "Giỏi")
            {
                ThongKeGioi++;
            }
            else if (KQ_Quy3 == "Khá")
            {
                ThongKeKha++;
            }
            else if (KQ_Quy3 == "Đạt")
            {
                ThongKeDat++;
            }
            else
            {
                ThongKeKhongDat++;
            }

            if (KQ_Quy4 == "Giỏi")
            {
                ThongKeGioi++;
            }
            else if (KQ_Quy4 == "Khá")
            {
                ThongKeKha++;
            }
            else if (KQ_Quy4 == "Đạt")
            {
                ThongKeDat++;
            }
            else
            {
                ThongKeKhongDat++;
            }

            sum = ThongKeGioi * 3 + ThongKeKha * 2 + ThongKeDat; 
            if(sum >= 11)
            {
                return "Giỏi";
            } else if(sum >= 8)
            {
                return "Khá";
            } else if (sum >= 3)
            {
                return "Đạt";
            }
            else
            {
                return "Không đạt";
            }
        }
    }
}
