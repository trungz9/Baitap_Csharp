using System;

public class HinhTron : IHinh
{
	public double BanKinh { get; set; }

	public HinhTron(double banKinh)
	{
		if (banKinh <= 0)
		{
			throw new ArgumentException("Ban kinh phai lon hon 0.");
		}

		BanKinh = banKinh;
	}

	public double GetDienTich()
	{
		return Math.PI * BanKinh * BanKinh;
	}

	public double GetChuVi()
	{
		return 2 * Math.PI * BanKinh;
	}

	public void Nhap()
	{
		Console.Write("Nhap ban kinh: ");
		double r = double.Parse(Console.ReadLine());

		if (r <= 0)
		{
			throw new ArgumentException("Ban kinh phai lon hon 0.");
		}

		BanKinh = r;
	}

	public void HienThi()
	{
		Console.WriteLine("Hinh tron");
		Console.WriteLine($"Ban kinh: {BanKinh}");
		Console.WriteLine($"Dien tich: {GetDienTich():F2}");
		Console.WriteLine($"Chu vi: {GetChuVi():F2}");
	}
}