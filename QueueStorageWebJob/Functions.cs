namespace QueueStorageWebJob
{
    using CrsossCutting.Model;
    using Microsoft.Azure.WebJobs;
    using System.IO;

    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        private const string QueueName = "examplequeue";
        /// <summary>
        /// QueueTrigger: When add message to queue execute this method.
        /// </summary>
        /// <param name="queueModel">Object in message</param>
        /// <param name="log"></param>
        public static void ProcessQueueMessage([QueueTrigger(QueueName)] QueueModel queueModel, TextWriter log)
        {
            log.WriteLine($"Message from queue: {queueModel.Message} - Creation message date: {queueModel.CreateDateMessage.ToString()}");
        }

        /// <summary>
        /// When message fails in queue goes to poision queue
        /// </summary>
        /// <param name="queueModel"></param>
        /// <param name="log"></param>
        public static void ProcessQueuePoisonNotificationMessage([QueueTrigger(QueueName)] QueueModel queueModel, TextWriter log)
        {
            log.WriteLine($"Poison: Message from queue: {queueModel.Message} - Creation message date: {queueModel.CreateDateMessage.ToString()}");
        }
    }
}
