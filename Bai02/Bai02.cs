using System.Text;

namespace Bai02
{
    internal class Bai02
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Nhập đường dẫn thư mục: ");  string dirPath = Console.ReadLine();

            Console.WriteLine();

            if (Directory.Exists(dirPath))  // Kiểm tra sự tồn tại thư mục của string dirPath
            {
                Console.WriteLine("Nội dung của thư mục " + dirPath);

                string[] subDir =  Directory.GetDirectories(dirPath);
                // GetDirectories: trả về một mảng chứa tên của tất cả đối tượng trong đường dẫn

                if (subDir.Length != 0)
                {

                    for(int i=0; i<subDir.Length; i++)
                    {
                        Console.WriteLine("<DIR> " + Path.GetFileName(subDir[i]) );
                        // Path.GetFileName: Lấy tên tập tin ở cuối đường dẫn
                    }

                    string[] listFolder = Directory.GetFiles(dirPath);
                    // GetDirectories: trả về một mảng chứa tên của tất cả tệp tin

                    for (int i = 0; i < listFolder.Length; i++)
                    {
                        Console.WriteLine(Path.GetFileName(listFolder[i]));
                        // Path.GetFileName: Lấy tên tập tin ở cuối đường dẫn
                    }

                }
                else Console.Write("Không có tập tin hay thư mục con nào.");

            }
            else Console.Write("Không tìm thấy thư mục");

        }
    }
}