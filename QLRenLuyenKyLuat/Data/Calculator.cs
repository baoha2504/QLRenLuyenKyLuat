using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRenLuyenKyLuat.Data
{
    class Calculator
    {
        public static int sumThang;
        public static string xeploaiThang;
        public static string cal_DiemRLThang(int diem1, int diem2,int diem3, int []KL, int []LS, int []HT)
        {
            sumThang = diem1 + diem2 + diem3;
            int muc1 = KL[0] + LS[0] + HT[1];
            int muc2 = KL[1] + LS[1] + HT[1] + 1;
            int muc3 = KL[1] + LS[1] -2 + HT[1];
            int muc4 = KL[2] + LS[2] + HT[2]+1;
            if (sumThang >= muc1)
            {
                if (diem1 >= 9 && diem2 >= 9)
                    xeploaiThang = "T";
                else xeploaiThang = "K";
            }

            else if (sumThang >= muc2 && sumThang < muc1)
            {
                if (diem1 >= 7 && diem2 >= 7)
                    xeploaiThang = "K";
                else
                    xeploaiThang = "TBK";
            }

            else if (sumThang >= muc3 && sumThang < muc2)
            {
                if (diem1 >= 6 && diem2 >= 6)
                    xeploaiThang = "TBK";
                else xeploaiThang = "TB";
            }

            else if (sumThang >= muc4 - 1 && sumThang < muc3)
            {
                if (sumThang >= muc4 && sumThang < muc3)
                {
                    if (diem1 >= 5 && diem2 >= 5 && diem3 >= 5)
                        xeploaiThang = "TB";
                }
                else if (diem1 < 4 && diem2 >= 4 && diem3 >= 4)
                    xeploaiThang = "Y";
                else if (diem2 < 4 && diem1 >= 4 && diem3 >= 4)
                    xeploaiThang = "Y";
                else if (diem3 < 4 && diem2 >= 4 && diem1 >= 4)
                    xeploaiThang = "Y";

            }
            else if ((diem1 < 4 && diem2 < 4) || (diem1 < 4 && diem3 < 4) || (diem3 < 4 && diem2 < 4) || (diem1 < 4 && diem2 < 4 && diem3 < 4))
                xeploaiThang = "Ke";
            else
                xeploaiThang = "Ke";
            return xeploaiThang;
        }
    }
}
