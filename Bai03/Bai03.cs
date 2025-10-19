using System.Text;

namespace Bai03
{
    internal class Bai03
    {
     
        // Giả sử n và m của ma trận được ràng buộc ở khoảng [1, 1000]
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Hãy nhập số dòng: "); string s1 = Console.ReadLine();
            Console.Write("Hãy nhập số cột: "); string s2 = Console.ReadLine();

            if (!checkInput(s1) || !checkInput(s2))
            {
                Console.Write("Ma trận không hợp lệ!");
                return;
            }

            int n = int.Parse(s1);
            int m = int.Parse(s2);

            int[,] matrix = new int[n, m];
            CreateMatrix(n, m, matrix);   

            Console.WriteLine("1. In ma trận " + n + " dòng " + m + " cột:"); WriteMatrix(n, m, matrix);

            Console.Write("2.1 Nhập phần tử muốn tìm kiếm: ");   string s = Console.ReadLine();  findElement(n, m, matrix, s);

            Console.Write("3. Các phần tử là số nguyên tố: ");  findPrimes(n, m, matrix);

            Console.Write("4. Dòng chứa nhiều số nguyên tố nhất: "); findRowHasMostPrime(n, m, matrix);

        }

        static bool checkInput(string s)
        {

            if (s.Length > 4)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {

                if (s[i] < '0' || s[i] > '9') return false;     // Kiểm tra Input nhập vào có chứa kí tự không?
                                                                // Loại bỏ kí tự và thập phân (dấu '.')
            }

            int n = int.Parse(s);

            if (n == 0 || n > 1000) return false;

            return true;

        }

        static bool checkNumber(string s)
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

        static bool isPrime(int x)
        {

            if (x < 2) return false;

            for (int i = 2; i * i <= x; i++)
            {
                if (x % i == 0) return false;
            }

            return true;

        }

        static void CreateMatrix(int n, int m, int[,] matrix)
        {
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {

                    Console.Write("Nhập A[" + i + ", " + j + "]: ");

                    string s = Console.ReadLine();

                    while (!checkNumber(s))
                    {

                        Console.Write("Nhập lại A[" + i + ", " + j + "]: ");
                        s = Console.ReadLine();

                    }

                    matrix[i, j] = int.Parse(s);

                }

            }

        }

        static void WriteMatrix(int n, int m, int[,] matrix)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++) Console.Write("{0,5}", matrix[i, j]);
                //{0,5}: Canh lề phải rộng 5 kí tự
                Console.WriteLine();
            }

        }

        static void findElement(int n, int m, int [,] matrix, string s)
        {

            Console.Write("2.2 ");

            if (!checkNumber(s))
            {
                Console.WriteLine("Không tìm được phần tử!"); return;
            }

            int k = int.Parse(s);   bool haveK = false;

            for (int i = 0; i < n; i++)
            {

                for(int j = 0; j < m; j++)
                {
                    if (k == matrix[i, j]) haveK = true;

                }

            }

            if (haveK == true)
            {

                Console.Write("Đã tìm được phần tử! Các vị trí gồm: ");

                for(int i=0; i < n; i++)
                {
                    for(int j=0; j < m; j++)
                    {
                        if (matrix[i, j] == k) Console.Write("[" + i + ", " + j + "]  ");
                    }
                }

                Console.WriteLine();

            } else
            {
                Console.WriteLine("Không tìm được phần tử!"); return;
            }

        }
        static void findPrimes(int n, int m, int[,] matrix)
        {

            bool havePrime = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (isPrime(matrix[i, j]))
                    {

                        havePrime = true;
                        Console.Write(matrix[i, j] + " ");

                    }
                }
            }

            if (havePrime == false)
            {
                Console.Write("Không có số nguyên tố! ");
            }

            Console.WriteLine();

        }

        static void findRowHasMostPrime(int n, int m, int[, ] matrix)
        {

            int maxCountPrime = 0;

            for (int i=0; i<n; i++)
            {
                int countPrime = 0;

                for(int j=0; j<m; j++)
                {

                    if (isPrime(matrix[i, j])) countPrime++;

                }

                maxCountPrime = Math.Max(maxCountPrime, countPrime);

            }

            if (maxCountPrime == 0)
            {
                Console.Write("Không có số nguyên tố nào!");
            }
            else
            {

                for (int i = 0; i < n; i++)
                {
                    int countPrime = 0;

                    for (int j = 0; j < m; j++)
                    {

                        if (isPrime(matrix[i, j])) countPrime++;

                    }

                    if (countPrime == maxCountPrime) Console.Write(i + " ");

                }

                Console.Write(" - Với " + maxCountPrime + " số nguyên tố mỗi dòng");

            }

        }

    }
}