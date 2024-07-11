using System.Net.Sockets;
using System.Net;
using System.Text;

namespace IPCTCPIPLog
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();
            Console.WriteLine("Waiting for connection...");

            using (TcpClient client = await listener.AcceptTcpClientAsync())
            {
                Console.WriteLine("Client connected.");
                using (NetworkStream stream = client.GetStream())
                {
                    while (true)
                    {
                        string log = $"Log at {DateTime.Now}";
                        byte[] data = Encoding.UTF8.GetBytes(log);
                        await stream.WriteAsync(data, 0, data.Length);
                        Console.WriteLine(log);
                        await Task.Delay(1000); // Симуляция логирования раз в секунду
                    }
                }
            }
        }
    }
}
