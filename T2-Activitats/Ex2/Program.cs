using System.Diagnostics;

namespace Ex2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string fileName = "processes.txt";
            const string filePath = @"..\..\..\" + fileName;

            if (File.Exists(filePath))
            {
                var processes = Process.GetProcesses();
                List<string> lines = new List<string>();

                foreach (Process proc in processes)
                {
                    string line = $"PID: {proc.Id,-10} Nom: {proc.ProcessName}";
                    Console.WriteLine(line);
                    lines.Add(line);
                }

                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Processos escrits en l'arxiu");
            }
        }
    }
}
