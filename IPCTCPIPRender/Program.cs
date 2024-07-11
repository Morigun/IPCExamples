using System.Net.Sockets;
using System.Text;

namespace IPCTCPIPRender
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 12345))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        string log = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"Rendered: {log}");
                    }
                }
            }
        }
    }
}
