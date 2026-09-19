using System;

public class HinhTamGiac : IHinh
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public HinhTamGiac(double a, double b, double c)
    {
        if (!IsTamGiac(a, b, c))
        {
            throw new ArgumentException(
                "Ba canh khong tao thanh tam giac."
            );
        }

        A = a;
        B = b;
        C = c;
    }

    public bool IsTamGiac(double a, double b, double c)
    {
        return a > 0 &&
               b > 0 &&
               c > 0 &&
               a + b > c &&
               a + c > b &&
               b + c > a;
    }

    public double GetDienTich()
    {
        double p = GetChuVi() / 2;

        return Math.Sqrt(
            p * (p - A) * (p - B) * (p - C)
        );
    }

    public double GetChuVi()
    {
        return A + B + C;
    }

    public void Nhap()
    {
        Console.Write("Nhap canh A: ");
        A = double.Parse(Console.ReadLine());

        Console.Write("Nhap canh B: ");
        B = double.Parse(Console.ReadLine());

        Console.Write("Nhap canh C: ");
        C = double.Parse(Console.ReadLine());

        if (!IsTamGiac(A, B, C))
        {
            throw new ArgumentException(
                "Ba canh khong tao thanh tam giac."
            );
        }
    }

    public void HienThi()
    {
        Console.WriteLine("Hinh tam giac");
        Console.WriteLine($"Canh A: {A}");
        Console.WriteLine($"Canh B: {B}");
        Console.WriteLine($"Canh C: {C}");
        Console.WriteLine($"Dien tich: {GetDienTich():F2}");
        Console.WriteLine($"Chu vi: {GetChuVi():F2}");
    }
}   