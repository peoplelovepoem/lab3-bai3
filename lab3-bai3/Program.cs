using System;

public class DaThuc
{
    private double[] mHeSo;

    public int Bac
    {
        get { return mHeSo.Length - 1; }
    }

    public DaThuc(int n)
    {
        if (n < 0) n = 0;
        mHeSo = new double[n + 1];
    }

    public double this[int k]
    {
        get
        {
            if (k >= 0 && k <= Bac)
                return mHeSo[k];
            return 0; 
        }
        set
        {
            if (k >= 0 && k <= Bac)
                mHeSo[k] = value;
        }
    }

    public double TinhGiaTri(double b)
    {
        double ketQua = 0;
        for (int k = 0; k <= Bac; k++)
        {
            ketQua += mHeSo[k] * Math.Pow(b, k);
        }
        return ketQua;
    }

    public static DaThuc operator +(DaThuc P1, DaThuc P2)
    {
        int maxBac = Math.Max(P1.Bac, P2.Bac);
        DaThuc ketQua = new DaThuc(maxBac);

        for (int k = 0; k <= maxBac; k++)
        {
            double ak_P1 = (k <= P1.Bac) ? P1[k] : 0;
            double ak_P2 = (k <= P2.Bac) ? P2[k] : 0;

            ketQua[k] = ak_P1 + ak_P2;
        }
        return ketQua;
    }

    public static DaThuc operator -(DaThuc P1, DaThuc P2)
    {
        int maxBac = Math.Max(P1.Bac, P2.Bac);
        DaThuc ketQua = new DaThuc(maxBac);

        for (int k = 0; k <= maxBac; k++)
        {
            double ak_P1 = (k <= P1.Bac) ? P1[k] : 0;
            double ak_P2 = (k <= P2.Bac) ? P2[k] : 0;

            ketQua[k] = ak_P1 - ak_P2;
        }
        return ketQua;
    }

    public override string ToString()
    {
        string hienThi = "";
        for (int k = Bac; k >= 0; k--)
        {
            if (mHeSo[k] != 0)
            {
                if (hienThi != "")
                    hienThi += (mHeSo[k] > 0) ? " + " : " - ";
                else if (mHeSo[k] < 0)
                    hienThi += "-";

                double giaTriTuyetDoi = Math.Abs(mHeSo[k]);

                if (k == 0)
                    hienThi += giaTriTuyetDoi.ToString();
                else if (k == 1)
                    hienThi += giaTriTuyetDoi.ToString() + "x";
                else
                    hienThi += giaTriTuyetDoi.ToString() + "x^" + k;
            }
        }
        return hienThi == "" ? "0" : hienThi;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        DaThuc P1 = new DaThuc(2);
        P1[2] = 3;
        P1[1] = 2;
        P1[0] = 1;

        DaThuc P2 = new DaThuc(3);
        P2[3] = 5;
        P2[2] = -2;
        P2[1] = 0;
        P2[0] = 4;

        Console.WriteLine($"Đa thức P1 (Bậc {P1.Bac}): {P1}");
        Console.WriteLine($"Đa thức P2 (Bậc {P2.Bac}): {P2}");

        DaThuc tong = P1 + P2;
        DaThuc hieu = P1 - P2;

        Console.WriteLine($"\nP1 + P2 = {tong}");
        Console.WriteLine($"P1 - P2 = {hieu}");

        double x = 2;
        Console.WriteLine($"\nGiá trị của P1 khi x = {x} là: {P1.TinhGiaTri(x)}");

        Console.ReadLine();
    }
}