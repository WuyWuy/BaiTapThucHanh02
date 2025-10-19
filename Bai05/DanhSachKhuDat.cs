namespace Bai05
{
    internal class DanhSachKhuDat
    {

        private List<KhuDat> ds;

        public DanhSachKhuDat()
        {
            ds = new List<KhuDat>();
        }
        public bool KiemTraSoNguyenDuong(string s)
        {

            for (int i=0; i<s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9') return false;
            }

            return true;

        }

        public void Nhap()
        {

            Console.Write("Nhập số N: ");   string s = Console.ReadLine();

            while ( !KiemTraSoNguyenDuong(s) )
            {
                Console.Write("Nhập lại số N: "); s = Console.ReadLine();
            }

            int n = int.Parse(s);

            for (int i=0; i<n; i++)
            {

                KhuDat khuDat;  Console.WriteLine();

                Console.Write("Nhập loại khu đất thứ " +  (i+1)  +" (1 - Khu đất, 2 - Nhà phố, 3 - Chung cư): ");

                s = Console.ReadLine();

                while (!KiemTraSoNguyenDuong(s) || int.Parse(s) > 3 || int.Parse(s) < 1)
                {
                    Console.Write("Nhập lại loại (1-3): "); s = Console.ReadLine();
                }

                int iType = int.Parse(s);

                switch (iType)
                {
                    case 1: 
                        khuDat = new KhuDat();
                        break;

                    case 2:
                        khuDat = new NhaPho();
                        break;

                    default:
                        khuDat = new ChungCu();
                        break;

                }

                khuDat.Nhap();  ds.Add(khuDat);

            }

        }
        public void Xuat()
        {

            for(int i=0; i<ds.Count; i++)
            {

                Console.WriteLine("Bất động sản thứ " + (i+1) + ": ");
                ds[i].Xuat();   Console.WriteLine();

            }

        }
        public void XuatTongGia()
        {

            double iA = 0, iB = 0, iC = 0;

            for (int i=0; i < ds.Count; i++)
            {

                switch (ds[i].getLoai())
                {

                    case 1:  iA += ds[i].getGiaBan();    break;

                    case 2:  iB += ds[i].getGiaBan();    break;

                    default: iC += ds[i].getGiaBan();    break; 

                }

            }

            Console.WriteLine("Tổng giá bán Khu đất: " + iA + " VNĐ");

            Console.WriteLine("Tổng giá bán Nhà phố: " + iB + " VNĐ");

            Console.WriteLine("Tổng giá bán Chung cư: "+ iC + " VNĐ");

        }
        public void XuatTheoDieuKien()
        {

            for(int i=0; i<ds.Count; i++)
            {

                if (ds[i].getLoai() == 1)
                {



                    if (ds[i].getDienTich() > 100)
                    {
                        Console.WriteLine(); ds[i].Xuat();
                    }

                }

                if (ds[i].getLoai() == 2)
                {
                    NhaPho np = (NhaPho)ds[i];

                    if (np.getDienTich() > 60 && np.getNamXayDung() >= 2019)
                    {
                        Console.WriteLine(); ds[i].Xuat();
                    }

                }

            }

        }

        public void TimKiem(KhuDat x)
        {

            bool isFound = false;

            for (int i=0; i<ds.Count; i++)
            {

                if ( ds[i].getLoai() == 2 || ds[i].getLoai() == 3 )
                {

                    if ( ds[i].getGiaBan() <= x.getGiaBan() && ds[i].getDienTich() >= x.getDienTich() 
                         && (ds[i].getDiaDiem().ToLower() == x.getDiaDiem().ToLower() ) )
                    {
                        Console.WriteLine();  ds[i].Xuat();     isFound = true; 
                    }

                }

            }

            if (!isFound)
            {
                Console.Write("Không tìm thấy thông tin!");
            }

        }

    }
}
