
namespace QueueStorageSend
{
    using CrsossCutting;
    using CrsossCutting.Model;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var model = new QueueModel() { Message = "Example queue", CreateDateMessage = DateTime.Now };
            QueueStorageServices queueService = new QueueStorageServices();
            queueService.AddMessage(model);
            Console.WriteLine("Message send to queue");
            Console.ReadLine();
        }
    }
}
