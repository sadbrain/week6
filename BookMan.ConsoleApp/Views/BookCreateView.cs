
using static System.Console;

namespace BookMan.ConsoleApp.Views
{
    /// <summary>
    /// class tạo ra một cuốn sách mới
    /// </summary>
    internal class BookCreateView
    {
        public BookCreateView() { }
        /// <summary>
        /// hàm tạo cuốn sách mới với những thông tin
        /// title, authors, publisherm year, edition, reading
        /// tags, description, rate, file
        /// </summary>
        public void Render()
        {
            WriteLine("CREATE A NEW BOOK", ConsoleColor.Green);
            //đọc một dòng và trả về chuỗi kí tựu
            string title = InputString("Title");
            string authors = InputString("Authors");
            string publisher = InputString("Publisher");
            int year = InputInt("Year");
            int edition = InputInt("Edition");
            var tags = InputString("Tags");
            var description = InputString("Description");
            var rating = InputInt("Rate");
            bool reading = InputBool("Reading");
            var file = InputString("File");
        }
        /// <summary>
        /// xuất ra thông tin với màu sắc
        /// </summary>
        /// <param name="message"> thông tin cần xuất</param>
        /// <param name="color"></param>
        /// <param name="resetColor"> trả lại màu mặc định hay không</param>
        private void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true )
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (resetColor) ResetColor();
        }

        private void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor) ResetColor();
        }
        /// <summary>
        /// in ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// rồi chuyển sang kiểu bool
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        private bool InputBool(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} [y/n]: ", labelColor);
            ConsoleKeyInfo key = ReadKey();
            Console.WriteLine();
            bool @char = key.KeyChar == 'Y' || key.KeyChar == 'y' ? true : false;
            
            return @char;
        }


        /// <summary>
        /// in ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// rồi chuyển sang số nguyên
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        private int InputInt(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {

            while (true)
            {
                var str = InputString(label, labelColor, valueColor);
                var result = int.TryParse(str, out int i);

                if (result) return i;
            }
        }


        /// <summary>
        /// in ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        private string InputString(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}: ", labelColor, false) ;
            ForegroundColor = valueColor;
            string value = ReadLine();
            ResetColor();
            return value;
        }


    }
}
