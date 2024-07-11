using RabbitMQ.Client;
using System.Text;

namespace IPCRabbitMQLog
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "logQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                while (true)
                {
                    string log = $"Log at {DateTime.Now}";
                    var body = Encoding.UTF8.GetBytes(log);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "logQueue",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine($"Sent: {log}");
                    await Task.Delay(1000); // Симуляция логирования раз в секунду
                }
            }
        }
    }
}
