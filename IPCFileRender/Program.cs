namespace IPCFileRender
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string logDirectory = "..\\..\\..\\..\\logs";

            while (true)
            {
                string[] logFiles = Directory.GetFiles(logDirectory, "log_*.txt");
                foreach (var logFilePath in logFiles)
                {
                    using (StreamReader reader = new StreamReader(logFilePath))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            Console.WriteLine($"Rendered: {line}");
                        }
                    }
                    File.Delete(logFilePath); // Удаление файла после чтения
                }
                await Task.Delay(1000); // Периодическая проверка файлов
            }
        }
    }
}
