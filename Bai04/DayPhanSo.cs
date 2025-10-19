namespace Bai04
{
    internal class DayPhanSo
    {

        private List<PhanSo> ds;

        public DayPhanSo() { ds = new List<PhanSo>(); }
        public bool KiemTraNhap(string s)
        {

            if (s.Length == 1)
            {
                if (s[0] >= '0' && s[0] <= '9') return true;
                else return false;
            }

            int i = 0;

            if (s[0] == '-') i++;

            for (; i < s.Length; i++) if (s[i] < '0' || s[i] > '9') return false;

            return true;

        }
        public void Nhap()
        {

            Console.Write("Nhập số N: ");   string s = Console.ReadLine();

            while ( !KiemTraNhap(s) || int.Parse(s) <= 0)
            {
                Console.Write("Nhập lại N: ");  s = Console.ReadLine();
            }

            int n = int.Parse(s);

            for (int i=0; i<n; i++)
            {

                Console.WriteLine("- Nhập phân số thứ " + (i + 1) + " : ");
                
                PhanSo x = new PhanSo();     x.Nhap();  ds.Add(x);

            }

        }
        public void Xuat()
        {
         
            for(int i=0; i<ds.Count; i++)
            {
                ds[i].Xuat();   Console.Write(" ");
            }

        }

        public PhanSo PhanSoLonNhat()
        {

            PhanSo maxPhanSo = ds[0];  // Lấy phân số đầu tiên làm mốc

            for (int i = 1; i < ds.Count; i++) // So sánh vs mấy thằng còn lại từ 1->n
            {

                if (maxPhanSo.LayGiaTri() < ds[i].LayGiaTri()) maxPhanSo = ds[i];

            }

            return maxPhanSo;

        }

        public void SapXep()
        {
            ds = ds.OrderBy(p => p.LayGiaTri()).ToList();
            // OrderBy: Sắp xếp phần tử tăng dần, trả về 1 tập hợp mới (IEnumerable)
            // p => p.LayGiaTri(): Đặt p là sắp xếp theo tiêu chí giá trị phân số
            // ToList(): chuyển IEnumerable thành List
        }

    }
}
