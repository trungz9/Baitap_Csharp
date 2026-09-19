using System;

class Program
{
    static void Main(string[] args)
    {
        IHinh[] danhSachHinh =
        {
            new HinhTron(5),
            new HinhChuNhat(10, 5),
            new HinhTamGiac(3, 4, 5)
        };

        foreach (IHinh hinh in danhSachHinh)
        {
            hinh.HienThi();
            Console.WriteLine("--------------------");
        }
    }
}