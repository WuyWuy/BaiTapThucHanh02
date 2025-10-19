using System.Text;

namespace Bai04
{
    internal class Bai04
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("I. Nhập 2 phân số để tính toán biểu thức:");    
            
            Part1();    
            
            Console.WriteLine("\nII. Nhập dãy phân số: ");    
            
            Part2();


        }
        static void Part1()
        {
            PhanSo A = new PhanSo(); A.Nhap();

            PhanSo B = new PhanSo(); B.Nhap(); 

            Console.Write("1. Phép cộng: "); (A + B).Xuat(); Console.WriteLine();
            Console.Write("2. Phép trừ : "); (A - B).Xuat(); Console.WriteLine();
            Console.Write("3. Phép nhân: "); (A * B).Xuat(); Console.WriteLine();
            Console.Write("4. Phép chia: "); (A / B).Xuat(); Console.WriteLine();

        }

        static void Part2()
        {

            DayPhanSo Arr = new DayPhanSo();

            Arr.Nhap();

            Console.Write("5. Phân số lớn nhất của dãy: "); ( Arr.PhanSoLonNhat() ).Xuat(); Console.WriteLine();

            Console.Write("6. Dãy phân số sau khi tăng dần: "); Arr.SapXep(); Arr.Xuat();

        }

    }
}