using AppAdapter;
using Microsoft.Azure.ServiceBus;
using System.Text;

namespace AppServiceBusAdapter
{
    public class LogServiceTransaction : ILogServiceAdapter
    {
        string _connectionString = "Endpoint=sb://logtran.servicebus.windows.net/;SharedAccessKeyName=SendPolicy;SharedAccessKey=dBamVF/eBbObiCDwlFODXKZTU9LBry6ZDG3rMgqa8i0=";
        public LogServiceTransaction()
        {
        }

        public void Log(string requstLog)
        {
            if (string.IsNullOrEmpty(_connectionString))
                return;

            var queueClient = new QueueClient(_connectionString, "lt_tranq");
            var message = new Message(Encoding.UTF8.GetBytes(requstLog));
            queueClient.SendAsync(message).GetAwaiter().GetResult();
            queueClient.CloseAsync();
        }
    }
}
