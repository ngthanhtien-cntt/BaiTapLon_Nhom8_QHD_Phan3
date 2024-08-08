using System;

namespace BTL_Nhom8_Phan3
{
    internal class QuiHoachDong_TimDuongDiToiUu
    {
        public void TimDuongDiToiUu(int[,] A)
        {
            int m = A.GetLength(0);
            int n = A.GetLength(1);


            int[,] B = new int[m, n];


            for (int i = 0; i < m; i++)
            {
                B[i, 0] = A[i, 0];
            }

            for (int j = 1; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    int maxPrev = B[i, j - 1];
                    if (i > 0)
                    {
                        maxPrev = Math.Max(maxPrev, B[i - 1, j - 1]);
                    }
                    if (i < m - 1)
                    {
                        maxPrev = Math.Max(maxPrev, B[i + 1, j - 1]);
                    }
                    B[i, j] = A[i, j] + maxPrev;
                }
            }


            int maxPoints = B[0, n - 1];
            int startRow = 0;
            for (int i = 1; i < m; i++)
            {
                if (B[i, n - 1] > maxPoints)
                {
                    maxPoints = B[i, n - 1];
                    startRow = i;
                }
            }

            int[] path = new int[n];
            path[n - 1] = startRow;
            for (int j = n - 2; j >= 0; j--)
            {
                int i = path[j + 1];
                if (i > 0 && B[i, j + 1] == B[i - 1, j] + A[i, j + 1])
                {
                    path[j] = i - 1;
                }
                else if (i < m - 1 && B[i, j + 1] == B[i + 1, j] + A[i, j + 1])
                {
                    path[j] = i + 1;
                }
                else
                {
                    path[j] = i;
                }
            }


            Console.WriteLine("Điem so lon nhat co the dat duoc : " + maxPoints);
            Console.Write("Đuong di : ");
            for (int j = 0; j < n; j++)
            {
                Console.Write($"({path[j] + 1}, {j + 1}) ");
            }
            Console.WriteLine();
        }
        static void Main()
        {
            int[,] A = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

            QuiHoachDong_TimDuongDiToiUu qhd = new QuiHoachDong_TimDuongDiToiUu();
            qhd.TimDuongDiToiUu(A);
        }
    }
}
