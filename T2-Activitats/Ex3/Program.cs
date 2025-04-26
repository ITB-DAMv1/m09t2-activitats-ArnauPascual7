using System.Diagnostics;

namespace Ex3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListBrowserThreads("chrome");
        }

        public static void ListBrowserThreads(string browser)
        {
            var processes = Process.GetProcessesByName(browser);

            foreach (Process proc in processes)
            {
                Console.WriteLine($"\nPID: {proc.Id,-13} Procés: {proc.ProcessName}");

                foreach (ProcessThread th in proc.Threads)
                {
                    Console.WriteLine($"Fil ID: {th.Id,-10} Hora d'inici: {th.StartTime,-20} Proritat: {th.PriorityLevel}");
                }
            }
        }
    }
}
