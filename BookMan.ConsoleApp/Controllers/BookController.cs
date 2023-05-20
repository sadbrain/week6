
namespace BookMan.ConsoleApp.Controllers
{
    using Models;
    using Views;

    /// <summary>
    /// Lớp điều khiển, giúp ghép nối dữ liêu với giao diện
    /// </summary>
    class BookController
    {
        /// <summary>
        /// ghép nối dữ liệu 1 cuốn sách với giao diện hiển thị 1 cuôn sách
        /// </summary>
        /// <param name="Id"></param>
        public void Single(int Id)
        {
            Book model1 = new Book
            {
                Id = 1,
                Author = "Adam Freeman",
                Title = "Expert ASP.NET Web API 2 for MVC Developers (The Expert's Voice in .NET)",
                Publisher = "Apress",
                Year = 2014,
                Tags = "c#, asp.net, mvc",
                Description = "Expert insight and understanding of how to create, customize, and deploy complex, flexible, and robust HTTP web services",
                Rating = 5,
                Reading = true
            };
            //khởi tạo view 
            BookSingleView view = new BookSingleView(model1);
            //gọi phương thức render để hiện thị ra mà hình thông tin cuốn sách
            view.Render();
        }

        public void Create()
        {
            BookCreateView view = new BookCreateView();
            view.Render(); // hiện thị ra màn hình hàm tạo sách mới
        }   
    }


}
