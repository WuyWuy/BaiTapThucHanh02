using System.Text;

namespace Bai01
{
    internal class Bai01
    {
     
        static public int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        static public string[] dayOfTheWeek = { "Sat", "Sun", "Mon", "Tue", "Wed", "Thu", "Fri" };
        static void Main(string[] args)
        {
            // Ở bài tập này, giả sử đây là lịch Gregorian Calendar
            // nghĩa là bắt đầu từ Thứ Hai 01/01/0001
            // Giả sử năm được ràng buộc ở khoảng [1, 9999]

            Console.OutputEncoding = Encoding.Unicode;
                 
            Console.Write("Nhập tháng: "); string sMonth = Console.ReadLine();

            Console.Write("Nhập năm: "); string sYear = Console.ReadLine();

            Console.WriteLine();

            if (checkDate(sMonth, sYear) == false)
            {

                Console.WriteLine("Tháng năm không hợp lệ!");

            } else
            {

                if (sMonth.Length < 2) sMonth = "0" + sMonth;
                while (sYear.Length < 4) sYear = "0" + sYear;

                Console.WriteLine("Month " + sMonth + "/" + sYear + ": ");
                writeCalendar( int.Parse(sMonth), int.Parse(sYear) );

            }

        }
        static bool isLeapYear(int year)
        {
            return ((year % 400 == 0) ||
                     (year % 4 == 0 && year % 100 != 0));

        }
        static bool isDigit(string s)
        {

            for (int i=0; i<s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9') return true;
            }

            return false;

        }

        static bool checkDate(string sMonth, string sYear)
        {

            if ( isDigit(sMonth) || isDigit(sYear))
            {
                return false;
            } 

            int iMonth = int.Parse(sMonth), iYear = int.Parse(sYear);

            if (iMonth > 0 && iYear > 0 && iMonth < 13 && iYear < 10000)
            {
                return true;
            }

            return false;

        }

        static int firstDayOfTheWeek(int iMonth, int iYear)
        {

            // Sử dụng công thức Zeller
            // h = (q + ⌊ 13*(m+1)/5 ⌋ + K + ⌊ K/4 ⌋ + ⌊ J/4 ⌋ + 5J ) mod 7

            // Trong đó:
            // + h = kết quả (0: Thứ 7, 1: CN, 2: Thứ 2, ... , 6: Thứ 6)
            // + q = Ngày trong tháng
            // + m = tháng (riêng tháng 1 và tháng 2 được tính là tháng 13, tháng 14 năm trước) 
            // + K = năm trong thế kỷ (year % 100)
            // + J = số thế kỷ (year / 100)

            if (iMonth < 3)
            {
                iMonth += 12;   iYear--;
            }

            int yearInCentury = iYear % 100, iCentury = iYear / 100;

            return ( ( 1 + ( 13*(iMonth+1)/5 + yearInCentury + yearInCentury/4 + iCentury/4 + 5*iCentury) ) % 7);

        }

        static void writeCalendar(int iMonth, int iYear)
        {

            if (iMonth == 2 && isLeapYear(iYear)) daysInMonth[1]++;

            int iDay = firstDayOfTheWeek(iMonth, iYear);

            int iCount = 0, i = 0, j = (iDay + 6) % 7;

            int[,] matrix = new int[6, 7];

            while ( iCount < daysInMonth[iMonth-1] )
            {

                matrix[i, j++] = ++iCount;

                if (j > 6)
                {
                    i++;    j = 0;
                }

            }

            Console.Write(dayOfTheWeek[1]);

            for (int u=1; u<7; u++)
            {

                Console.Write("{0, 8}", dayOfTheWeek[ (u+1)%7 ]);

            }

            Console.WriteLine();

            for(int u = 0; u <= i; u++)
            {

                if (matrix[u, 0] > 0) Console.Write("{0, 3}", matrix[u, 0]);
                  else Console.Write("{0, 3}", "");

                for (int v = 1; v < 7; v++)
                {

                    if (matrix[u, v] > 0) Console.Write("{0, 8}", matrix[u, v]);
                      else Console.Write("{0, 8}", " ");

                }
                Console.WriteLine();
            }

        }

    }
}