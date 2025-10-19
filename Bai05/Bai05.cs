
using System.Text;

namespace Bai05
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode;

            //==== Nhập xuất các thông tin (Khu đất, Nhà phố, Chung cư) cần quản lý ===

            Console.WriteLine("1. Nhập danh sách khu đất:");

            DanhSachKhuDat ListBatDongSan = new DanhSachKhuDat();

            ListBatDongSan.Nhap(); Console.WriteLine();

            Console.WriteLine("2. Nhập thông tin cần tìm kiếm:");

            Console.WriteLine();

            KhuDat x = new KhuDat(); x.Nhap();

            Console.WriteLine();

            Console.WriteLine("3. Xuất danh sách cần quản lý:");

            ListBatDongSan.Xuat();

            //=== Tổng giá bán của 3 loại thành phố ===

            Console.WriteLine("4. Tổng giá bán 3 loại thành phố:");

            ListBatDongSan.XuatTongGia();

            Console.WriteLine();

            //=== Danh sách Khu đất có diện tích > 100m2 hoặc Nhà phố có diện tích >60m2 và năm xây dựng >= 2019 (nếu có) ===

            Console.WriteLine("5. Danh sách Khu đất có diện tích > 100m2 hoặc Nhà phố có diện tích >60m2 và năm xây dựng >= 2019: ");

            ListBatDongSan.XuatTheoDieuKien(); Console.WriteLine();

            //=== Xuất thông tin Nhà phố hoặc Chung cư theo tìm kiếm ===

            Console.WriteLine("6. Kết quả tìm kiếm: ");

            ListBatDongSan.TimKiem(x);

        }
    }
}