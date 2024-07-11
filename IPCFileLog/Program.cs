namespace IPCFileLog
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string logDirectory = "..\\..\\..\\..\\logs";
            Directory.CreateDirectory(logDirectory);

            while (true)
            {
                string logFilePath = Path.Combine(logDirectory, $"log_{DateTime.Now.Ticks}.txt");
                using (StreamWriter writer = new StreamWriter(logFilePath, append: true))
                {
                    string log = $"Log at {DateTime.Now}";
                    await writer.WriteLineAsync(log);
                    await writer.FlushAsync();
                    Console.WriteLine(log);
                }
                await Task.Delay(1000); // Симуляция логирования раз в секунду
            }
        }
    }
}
