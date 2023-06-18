using System.Text;
class Program
{
    // để đếm số công việc cần chờ hoàn thành cụ thể ở đây là 10
    //mỗi khi một công việ hoàn thành ta gọi hàm signal để giảm đém
    static CountdownEvent countdownEvent = new CountdownEvent(10);

    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        // gửi công việc tới threadPool, mỗi công việc sẽ được thực thi trong phương thức ProcessTask

        for (int i = 0; i < 10; i++)
        {
            ThreadPool.QueueUserWorkItem(ProcessTask, i);

        }

        //vòng for sẽ hoàn thành trước các công việc nên nó sẽ thực hiện lệnh tiếp theo sau for
        //ta cần dùng hàm dưới để đợi cho tất cả các công việc đã hoàn thành
        countdownEvent.Wait();
        Console.WriteLine("All work finished");
    }
    static void ProcessTask(object state)
    {
        int taskId = (int)state;
        Console.WriteLine("Work {0} is enforcementing by thread {1}.", taskId, Thread.CurrentThread.ManagedThreadId);
        //giả lặp thời gian xử lý công việc
        Thread.Sleep(1000);
        Console.WriteLine("Work {0} has finished", taskId);
        //giảm đếm khi công việc hoàn thành
        countdownEvent.Signal();
    }
}