using System;

public class HinhChuNhat : IHinh
{
    public double ChieuDai { get; set; }
    public double ChieuRong { get; set; }

    public HinhChuNhat(double chieuDai, double chieuRong)
    {
        if (chieuDai <= 0 || chieuRong <= 0)
        {
            throw new ArgumentException(
                "Chieu dai va chieu rong phai lon hon 0."
            );
        }

        ChieuDai = chieuDai;
        ChieuRong = chieuRong;
    }

    public double GetDienTich()
    {
        return ChieuDai * ChieuRong;
    }

    public double GetChuVi()
    {
        return 2 * (ChieuDai + ChieuRong);
    }

    public void Nhap()
    {
        Console.Write("Nhap chieu dai: ");
        ChieuDai = double.Parse(Console.ReadLine());

        Console.Write("Nhap chieu rong: ");
        ChieuRong = double.Parse(Console.ReadLine());

        if (ChieuDai <= 0 || ChieuRong <= 0)
        {
            throw new ArgumentException(
                "Chieu dai va chieu rong phai lon hon 0."
            );
        }
    }

    public void HienThi()
    {
        Console.WriteLine("Hinh chu nhat");
        Console.WriteLine($"Chieu dai: {ChieuDai}");
        Console.WriteLine($"Chieu rong: {ChieuRong}");
        Console.WriteLine($"Dien tich: {GetDienTich():F2}");
        Console.WriteLine($"Chu vi: {GetChuVi():F2}");
    }
}