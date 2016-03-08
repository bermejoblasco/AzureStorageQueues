
namespace QueueStorageReciver
{
    using CrsossCutting;
    using CrsossCutting.Model;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            QueueStorageServices queueService = new QueueStorageServices();
            var queueModel = queueService.GetMessage();            
            Console.WriteLine($"Message from queue: {queueModel.Message} - Creation message date: {queueModel.CreateDateMessage.ToString()}");
            Console.ReadLine();
        }
    }
}
