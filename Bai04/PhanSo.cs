namespace Bai04
{
    internal class PhanSo
    {

        private int iTuSo;
        private int iMauSo;

        public PhanSo(int iNum = 0, int iDen = 1)
        {
            iTuSo = iNum; iMauSo = iDen;
        }
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

        public PhanSo RutGon()
        {

            if (iMauSo < 0) { iMauSo = -iMauSo; iTuSo = -iTuSo; }

            int tmp_tu = iTuSo, tmp_mau = iMauSo;

            if (tmp_tu < 0) tmp_tu = -tmp_tu; if (tmp_mau < 0) tmp_mau = -tmp_mau;

            while (tmp_mau != 0)
            {
                int tmp = tmp_mau;
                tmp_mau = tmp_tu % tmp_mau;
                tmp_tu = tmp;
            }

            int iUocChung = tmp_tu;

            iTuSo /= iUocChung; iMauSo /= iUocChung;

            return new PhanSo(iTuSo, iMauSo);

        }

        public void Nhap()
        {

            Console.Write("Nhập tử số: ");  string s1 = Console.ReadLine();

            while (!KiemTraNhap(s1))
            {
                Console.Write("Nhập lại tử số: "); s1 = Console.ReadLine();
            }

            Console.Write("Nhập mẫu số: "); string s2 = Console.ReadLine();

            while (!KiemTraNhap(s2) || (s2[0] == '0' || (s2[0] == '-' && s2[1] == '0')))
            {
                Console.Write("Nhập lại mẫu số: "); s2 = Console.ReadLine();
            }

            iTuSo = int.Parse(s1);  iMauSo = int.Parse(s2);

            RutGon();

        }
        public void Xuat()
        {

            if (iMauSo == 1)
            {
                Console.Write(iTuSo);
            } else
            {
                Console.Write(iTuSo + "/" + iMauSo);
            }

        }
        public float LayGiaTri() => (float)iTuSo / iMauSo;
        // Dấu =>: biểu thức Lambda, viết rút gọn cho { return...; }
        public static PhanSo operator +(PhanSo a, PhanSo b) 
            => new PhanSo( (a.iTuSo * b.iMauSo) + (b.iTuSo * a.iMauSo) , 
                            a.iMauSo * b.iMauSo ).RutGon();

        // Để static với operator vì triển khai phép tính trực tiếp luôn không cần gọi đối tượng trước
        // VD: a + b thay vì a.operator+(b), với a và b là PhanSo
        public static PhanSo operator -(PhanSo a, PhanSo b)
            => new PhanSo( (a.iTuSo * b.iMauSo) - (b.iTuSo * a.iMauSo) ,
                            a.iMauSo* b.iMauSo ).RutGon();
        public static PhanSo operator *(PhanSo a, PhanSo b)
            => new PhanSo( a.iTuSo * b.iTuSo, a.iMauSo * b.iMauSo ).RutGon();

        public static PhanSo operator /(PhanSo a, PhanSo b) 
            => new PhanSo( a.iTuSo * b.iMauSo, b.iTuSo * a.iMauSo ).RutGon();

    }
}

