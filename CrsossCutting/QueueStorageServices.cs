
namespace CrsossCutting
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Model;
    using Newtonsoft.Json;
    using System;
    using System.Configuration;

    public class QueueStorageServices
    {
        private CloudStorageAccount storageAccount;
        private const string QueueName = "examplequeue";

        public QueueStorageServices()
        {
            this.storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["Azure"].ConnectionString);            
        }

        private CloudQueueClient QueueClient
        {
            get { return this.storageAccount.CreateCloudQueueClient(); }
        }

        /// <summary>
        /// Add message from queue
        /// </summary>
        /// <param name="model">Object to insert in queue</param>
        public void AddMessage(QueueModel model)
        {
            var queue =  this.GetContainer(QueueName);
            var messageJson = JsonConvert.SerializeObject(model);
            var message = new CloudQueueMessage(messageJson);
            //Message with 60 seconds visibulity
            queue.AddMessage(message, timeToLive: TimeSpan.FromSeconds(60.0));
        }

        /// <summary>
        ///  Read message from queue
        /// </summary>
        /// <returns></returns>
        public QueueModel GetMessage()
        {
            var queue = this.GetContainer(QueueName);
            var queueuMessage = queue.GetMessage();            
            return JsonConvert.DeserializeObject<QueueModel>(queueuMessage.AsString);            
        }

        /// <summary>
        /// Get reference to queue. If no exist create it.
        /// </summary>
        /// <param name="queue">Name of queue</param>
        /// <returns></returns>
        private CloudQueue GetContainer(string queue)
        {
            var queueContainer = this.QueueClient.GetQueueReference(queue);
            queueContainer.CreateIfNotExists();
            return queueContainer;
        }
    }
}
