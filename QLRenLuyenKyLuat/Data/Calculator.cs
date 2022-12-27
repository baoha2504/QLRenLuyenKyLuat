namespace QLRenLuyenKyLuat.Data
{
    class Calculator
    {
        public static string cal_TinhTheLucNam(string KQ_Quy1, string KQ_Quy2, string KQ_Quy3, string KQ_Quy4)
        {
            int ThongKeGioi = 0;
            int ThongKeKha = 0;
            int ThongKeDat = 0;
            int ThongKeKhongDat = 0;
            int sum = 0;
            
            if (KQ_Quy1 == "Giỏi")
            {
                ThongKeGioi++;
            }
            else if (KQ_Quy1 == "Khá")
            {
                ThongKeKha++;
            }
            else if (KQ_Quy1 == "Đạt")
            {
                ThongKeDat++;
            }
            else
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
            if (sum >= 11)
            {
                return "Giỏi";
            }
            else if (sum >= 8)
            {
                return "Khá";
            }
            else if (sum >= 3)
            {
                return "Đạt";
            }
            else
            {
                return "Không đạt";
            }
        }
        public static int sumThang;
        public static string xeploaiThang;
        public static string cal_DiemRLThang(int diem1, int diem2, int diem3, int[] KL, int[] LS, int[] HT)
        {
            sumThang = diem1 + diem2 + diem3;
            int muc1 = KL[0] + LS[0] + HT[1];
            int muc2 = KL[1] + LS[1] + HT[1] + 1;
            int muc3 = KL[1] + LS[1] - 2 + HT[1];
            int muc4 = KL[2] + LS[2] + HT[2] + 1;
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

        public static string cal_DiemRLHocKy(string kq1, string kq2, string kq3, string kq4, string kq5, string kq6)
        {
            int tongdiem = 0;
            int demT = 0;
            int demK = 0;
            int demTB = 0;
            int demTBK = 0;
            int demY = 0;

            if (kq1 == "T") { tongdiem += 5; demT++; }
            else if (kq1 == "K") { tongdiem += 4; demK++; }
            else if (kq1 == "TB") { tongdiem += 3; demTB++; }
            else if (kq1 == "TBK") { tongdiem += 2; demTBK++; }
            else if (kq1 == "Y") { tongdiem += 1; demY++; }


            if (kq2 == "T") { tongdiem += 5; demT++; }
            else if (kq2 == "K") { tongdiem += 4; demK++; }
            else if (kq2 == "TB") { tongdiem += 3; demTB++; }
            else if (kq2 == "TBK") { tongdiem += 2; demTBK++; }
            else if (kq2 == "Y") { tongdiem += 1; demY++; }

            if (kq3 == "T") { tongdiem += 5; demT++; }
            else if (kq3 == "K") { tongdiem += 4; demK++; }
            else if (kq3 == "TB") { tongdiem += 3; demTB++; }
            else if (kq3 == "TBK") { tongdiem += 2; demTBK++; }
            else if (kq3 == "Y") { tongdiem += 1; demY++; }

            if (kq4 == "T") { tongdiem += 5; demT++; }
            else if (kq4 == "K") { tongdiem += 4; demK++; }
            else if (kq4 == "TB") { tongdiem += 3; demTB++; }
            else if (kq4 == "TBK") { tongdiem += 2; demTBK++; }
            else if (kq4 == "Y") { tongdiem += 1; demY++; }

            if (kq5 == "T") { tongdiem += 5; demT++; }
            else if (kq5 == "K") { tongdiem += 4; demK++; }
            else if (kq5 == "TB") { tongdiem += 3; demTB++; }
            else if (kq5 == "TBK") { tongdiem += 2; demTBK++; }
            else if (kq5 == "Y") { tongdiem += 1; demY++; }

            if (kq6 == "T") { tongdiem += 5; demT++; }
            else if (kq6 == "K") { tongdiem += 4; demK++; }
            else if (kq6 == "TB") { tongdiem += 3; demTB++; }
            else if (kq6 == "TBK") { tongdiem += 2; demTBK++; }
            else if (kq6 == "Y") { tongdiem += 1; demY++; }

            if (tongdiem >= 27 && demT >= 5 && demK <= 1 && demTB == 0 && demTBK == 0 && demY == 0)
            {
                return "T";
            }
            else if (tongdiem >= 21 && demT >= 0 && demK >= 5 && demTB <= 1 && demTBK == 0 && demY == 0)
            {
                return "K";
            }
            else if (tongdiem >= 15 && demT >= 0 && demK >= 0 && demTB >= 5 && demTBK <= 1 && demY == 0)
            {
                return "TB";
            }
            else if (tongdiem >= 9 && demT >= 0 && demK >= 0 && demTB >= 0 && demTBK >= 5 && demY <= 1)
            {
                return "TBK";
            }
            else if (tongdiem >= 9 && demT >= 0 && demK >= 0 && demTB >= 0 && demTBK >= 0 && demY >= 5)
            {
                return "Y";
            }
            else
            {
                return "Kém";
            }
        }

        public static string cal_DiemRLNam(string kq1, string kq2)
        {
            if (kq1 == "T")
            {
                if (kq2 == "T") { return "T"; }
                else if (kq2 == "K") { return "K"; }
                else if (kq2 == "TB") { return "K"; }
                else if (kq2 == "TBK") { return "TB"; }
                else if (kq2 == "Y") { return "Y"; }
                else { return "Kém"; }
            }

            else if (kq1 == "K")
            {
                if (kq2 == "T") { return "K"; }
                else if (kq2 == "K") { return "K"; }
                else if (kq2 == "TB") { return "K"; }
                else if (kq2 == "TBK") { return "TBK"; }
                else if (kq2 == "Y") { return "Y"; }
                else { return "Kém"; }
            }

            else if (kq1 == "TB")
            {
                if (kq2 == "T") { return "K"; }
                else if (kq2 == "K") { return "TB"; }
                else if (kq2 == "TB") { return "TB"; }
                else if (kq2 == "TBK") { return "TB"; }
                else if (kq2 == "Y") { return "TBK"; }
                else { return "Kém"; }
            }

            else if (kq1 == "TBK")
            {
                if (kq2 == "T") { return "TB"; }
                else if (kq2 == "K") { return "TB"; }
                else if (kq2 == "TB") { return "TBK"; }
                else if (kq2 == "TBK") { return "TBK"; }
                else if (kq2 == "Y") { return "Y"; }
                else { return "Kém"; }
            }

            else if (kq1 == "Y")
            {
                if (kq2 == "T") { return "TBK"; }
                else if (kq2 == "K") { return "TBK"; }
                else if (kq2 == "TB") { return "Y"; }
                else if (kq2 == "TBK") { return "Y"; }
                else if (kq2 == "Y") { return "Y"; }
                else { return "Kém"; }
            }

            else
            {
                return "Kém";
            }

        }
        
    }
}
