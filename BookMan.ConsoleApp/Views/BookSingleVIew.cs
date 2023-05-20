using System;
using static System.Console;

namespace BookMan.ConsoleApp.Views
{
    using Models;
    /// <summary>
    /// class hiển thị một cuốn cách
    /// </summary>
    class BookSingleView
    {
        //biến chứa thông tin cuốn sách
        protected Book Model;

        public BookSingleView(Book model)
        {
            Model = model;
        }

        /// <summary>
        /// hàm hiện thị thông tin 1 cuốn sách
        /// </summary>
        public void Render()
        {
            //kiểm tra xem Model có dữ liệu không
            if (Model == null) 
            {
                WriteLine("NO BOOK FOUND/. SORRY!", ConsoleColor.Red);
                return;
            }

            WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);

            Console.WriteLine($"Author:         {Model.Author}");
            Console.WriteLine($"Title:          {Model.Title}");
            Console.WriteLine($"Publisher:      {Model.Publisher}");
            Console.WriteLine($"Year:           {Model.Year}");
            Console.WriteLine($"Edition:        {Model.Edition}");
            Console.WriteLine($"Isbn:           {Model.Isbn}");
            Console.WriteLine($"Tags:           {Model.Tags}");
            Console.WriteLine($"Description:    {Model.Description}");
            Console.WriteLine($"Rating:         {Model.Rating}");
            Console.WriteLine($"Reading:        {Model.Reading}");
            Console.WriteLine($"FIle:           {Model.File}");
            Console.WriteLine($"NameFile:       {Model.FileName}");

        }

        /// <summary>
        /// in thông báo ra màn hình với chữ màu
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        protected void WriteLine(string message, ConsoleColor color)
        {
            ForegroundColor = color;
            Console.WriteLine(message);
            ResetColor();


        }
    }
}
