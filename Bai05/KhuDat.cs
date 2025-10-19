
namespace Bai05
{
    internal class KhuDat
    {

        protected string sDiaDiem;
        protected double dGiaBan;
        protected double dDienTich;

        public KhuDat()
        {
        }

        public bool KiemTraNhapSoThuc(string s)
        {

            bool haveNumber = false;

            if (s[0] >= '0' && s[0] <= '9') { haveNumber = true; }
         
            for (int i=0; i<s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9') {

                   if ( (s[i] != '.') || (s[i] == '.' && haveNumber == false) ) return false;

                }
            }

            return true;

        }
        public bool KiemTraNhapSoNguyenDuong(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9') return false;
            }

            return true;
        }

        public virtual void Nhap()
        {
            Console.Write("Nhập địa điểm: ");   sDiaDiem = Console.ReadLine();

            Console.Write("Nhập giá bán (VNĐ): ");    string s = Console.ReadLine();

            while ( !KiemTraNhapSoThuc(s) )
            {
                Console.Write("Nhập lại giá bán (VNĐ): "); s = Console.ReadLine();
            }

            dGiaBan = double.Parse(s);

            Console.Write("Nhập diện tích (M^2): ");     s = Console.ReadLine();

            while ( !KiemTraNhapSoThuc(s) )
            {
                Console.Write("Nhập lại diện tích (M^2): "); s = Console.ReadLine();
            }

            dDienTich = double.Parse(s);

        }
        public virtual void Xuat()
        {

            Console.WriteLine("Địa điểm: " + sDiaDiem);
            Console.WriteLine("Giá bán: "  + dGiaBan + " VNĐ");
            Console.WriteLine("Diện tích: " + dDienTich + " M2");

        }

        public string getDiaDiem() => sDiaDiem;
        public double getGiaBan() => dGiaBan;
        public double getDienTich() => dDienTich;
        public virtual int getLoai() => 1;

    }
    class NhaPho : KhuDat
    {

        private int iNamXayDung;
        private int iSoTang;

        public NhaPho()
        {
        }

        public override void Nhap()
        {

            base.Nhap();    string s;

            Console.Write("Nhập năm xây dựng: ");   s = Console.ReadLine();

            while ( !KiemTraNhapSoNguyenDuong(s) )
            {
                Console.Write("Nhập lại năm xây dựng: "); s = Console.ReadLine();
            }

            iNamXayDung = int.Parse(s);

            Console.Write("Nhập số tầng: ");   s = Console.ReadLine();

            while ( !KiemTraNhapSoNguyenDuong(s) )
            {
                Console.Write("Nhập lại số tầng: "); s = Console.ReadLine();
            }

            iSoTang = int.Parse(s);

        }
        public override void Xuat()
        {
            base.Xuat();

            Console.WriteLine("Năm xây dựng: " + iNamXayDung);

            Console.WriteLine("Số tầng: " + iSoTang);

        }
        public int getNamXayDung() => iNamXayDung;
        public override int getLoai() => 2;

    }
    class ChungCu : KhuDat
    {
        private int iTang;
        public ChungCu()
        {
        }

        public override void Nhap() 
        {
            base.Nhap();    string s;

            Console.Write("Nhập tầng: ");    s = Console.ReadLine();

            while (!KiemTraNhapSoNguyenDuong(s))
            {
                Console.Write("Nhập lại tầng: "); s = Console.ReadLine();
            }

            iTang = int.Parse(s);

        }
        public override void Xuat()
        {

            base.Xuat();

            Console.WriteLine("Tầng: " + iTang);
        
        }

        public int getTang() => iTang;

        public override int getLoai() => 3;

    }

}
