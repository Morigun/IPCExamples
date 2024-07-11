using System.IO.Pipes;

namespace IPCPipeRender
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "logPipe", PipeDirection.In))
            {
                pipeClient.Connect();
                using (StreamReader reader = new StreamReader(pipeClient))
                {
                    while (true)
                    {
                        string log = await reader.ReadLineAsync() ?? string.Empty;
                        Console.WriteLine($"Rendered: {log}");
                    }
                }
            }
        }
    }
}
