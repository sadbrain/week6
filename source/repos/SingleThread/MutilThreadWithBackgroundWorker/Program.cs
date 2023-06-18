using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
class Program
{
    static BackgroundWorker backgroundWorker;
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        // Khởi tạo và cấu hình lớp BackgroundWorker
        backgroundWorker = new BackgroundWorker();
        backgroundWorker.WorkerReportsProgress = true;
        //đăng ký một hàm thực thi khi event DoWork thực thi
        //DoWork thực thi khi RunWorkerAsync() được thực thi

        backgroundWorker.DoWork += BackgroundWorker_DoWork;
        //đăng ký hàm thực thi khi có sự thay đổi giá trị cảu một biến
        backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
        //đăng ký hàm thực thi được kích hoạt một khi hoàn thành thực thi toàn bộ code trên luồng phụ.
        backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        // Bắt đầu thực thi công việc trong background
        //tham số của thằng này truyền cho phương thực thực thi ở luồng khác
        backgroundWorker.RunWorkerAsync("Dữ liệu đầu vào");
        // Tiếp tục thực hiện các tác vụ khác trong luồng chính
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Thực hiện tác vụ trong luồng chính.");
            Thread.Sleep(1000);
        }
        Console.ReadKey();
    }
    static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Lấy dữ liệu công việc từ tham số nhận từ RunWorkerAsync
        string jobData = e.Argument as string;
        Console.WriteLine(jobData);
        // Thực hiện công việc dài hạn trong background
        for (int i = 0; i < 10; i++)
        {
            // Thông báo tiến trình, gửi i*10 cho BackgroundWorker_ProgressChanged
            backgroundWorker.ReportProgress(i * 10);
            // Giả lập thời gian xử lý công việc
            Thread.Sleep(1000);
        }
        // Kết quả của công việc được trả về
        e.Result = "OK";
        // Có thể sử dụng e.Cancel để kiểm soát việc hủy công việc
    }
    static void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // Xử lý thông báo tiến trình, e.ProgressPercentage lấy giá trị được truyền vào ReportProcess và thể hiện phần trăm.

        Console.WriteLine("Tiến trình trong luồng phụ: {0}%", e.ProgressPercentage);
    }
    static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Xử lý khi công việc đã hoàn thành
        if (e.Error != null)
        {
            // Xử lý khi có lỗi xảy ra trong quá trình thực hiện công việc
        }
        else if (e.Cancelled)
        {
            // Xử lý khi công việc bị hủy
        }
        else
        {
            // Xử lý kết quả công việc
            string result = e.Result as string;
            Console.WriteLine("Hoàn thành với kết quả: " + result);
        }
    }
}