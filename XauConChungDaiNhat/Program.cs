using System;

namespace BTL_Nhom8_Phan3
{
    internal class QHD_XauConChungDaiNhat
    {

        public static int TinhDoDaiXauConChungDaiNhat(string S1, string S2)
        {
            int lengthS1 = S1.Length;
            int lengthS2 = S2.Length;
            int[,] dp = new int[lengthS1 + 1, lengthS2 + 1];
            int maxLength = 0;

            for (int i = 1; i <= lengthS1; i++)
            {
                for (int j = 1; j <= lengthS2; j++)
                {
                    if (S1[i - 1] == S2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                        if (dp[i, j] > maxLength)
                        {
                            maxLength = dp[i, j];
                        }
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }
                }
            }

            return maxLength;
        }


        public static void Main(string[] args)
        {

            Console.WriteLine("Nhap xau  S1:");
            string S1 = Console.ReadLine();
            Console.WriteLine("Nhap xau S2:");
            string S2 = Console.ReadLine();

            int maxLength = TinhDoDaiXauConChungDaiNhat(S1, S2);


            Console.WriteLine($"Đo dai xau  con chung dai nhat: {maxLength}");
        }
    }
}
