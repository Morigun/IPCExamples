using System.IO.Pipes;

namespace IPCPipeLog
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("logPipe", PipeDirection.Out))
            {
                Console.WriteLine("Waiting for connection...");
                pipeServer.WaitForConnection();
                Console.WriteLine("Client connected.");

                using (StreamWriter writer = new StreamWriter(pipeServer))
                {
                    while (true)
                    {
                        string log = $"Log at {DateTime.Now}";
                        await writer.WriteLineAsync(log);
                        await writer.FlushAsync();
                        Console.WriteLine(log);
                        await Task.Delay(1000); // Симуляция логирования раз в секунду
                    }
                }
            }
        }
    }
}
