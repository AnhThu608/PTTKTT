using System;
using System.Diagnostics;

class Program
{
    // Cách 1: Phương pháp thông thường
    static double TinhThongThuong(double[] a, int n, double x)
    {
        double ketQua = a[0];

        for (int i = 1; i <= n; i++)
        {
            double luyThua = 1;

            for (int j = 1; j <= i; j++)
            {
                luyThua = luyThua * x;
            }

            ketQua = ketQua + a[i] * luyThua;
        }

        return ketQua;
    }

    // Cách 2: Phương pháp Horner
    static double TinhHorner(double[] a, int n, double x)
    {
        double ketQua = a[n];

        for (int i = n - 1; i >= 0; i--)
        {
            ketQua = a[i] + x * ketQua;
        }

        return ketQua;
    }

    // Tạo mảng hệ số
    static double[] TaoHeSo(int n)
    {
        double[] a = new double[n + 1];

        for (int i = 0; i <= n; i++)
        {
            a[i] = 1;
        }

        return a;
    }

    static void Main()
    {
        int[] danhSachN = { 1000, 10000, 100000 };

        double x = 1.00001;

        Console.WriteLine("BAI 1 - TINH GIA TRI DA THUC");
        Console.WriteLine("==============================================");
        Console.WriteLine("x0 = " + x);
        Console.WriteLine();

        Console.WriteLine(
            "{0,-12}{1,-20}{2,-20}{3}",
            "n",
            "Cach 1 (ms)",
            "Cach 2 (ms)",
            "Nhan xet"
        );

        Console.WriteLine(
            "--------------------------------------------------------------"
        );

        foreach (int n in danhSachN)
        {
            double[] a = TaoHeSo(n);

            // Đo thời gian cách 1
            Stopwatch sw1 = Stopwatch.StartNew();

            double ketQua1 = TinhThongThuong(a, n, x);

            sw1.Stop();

            // Đo thời gian cách 2
            Stopwatch sw2 = Stopwatch.StartNew();

            double ketQua2 = TinhHorner(a, n, x);

            sw2.Stop();

            double thoiGian1 = sw1.Elapsed.TotalMilliseconds;
            double thoiGian2 = sw2.Elapsed.TotalMilliseconds;

            Console.WriteLine(
                "{0,-12}{1,-20:F6}{2,-20:F6}{3}",
                n,
                thoiGian1,
                thoiGian2,
                thoiGian1 > thoiGian2
                    ? "Horner nhanh hon"
                    : "Cach 1 nhanh hon"
            );

            Console.WriteLine("Ket qua cach 1: " + ketQua1);
            Console.WriteLine("Ket qua cach 2: " + ketQua2);
            Console.WriteLine();
        }
        
        Console.WriteLine();
        Console.WriteLine("Nhan phim bat ky de ket thuc...");
        Console.ReadKey();
    }
}
