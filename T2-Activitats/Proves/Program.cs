namespace Proves
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            Task<int> task = Move(cts.Token, '$');

            Console.ReadKey();

            cts.Cancel();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Espais recorreguts: " + task.Result);

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static async Task<int> Move(CancellationToken tk, char ch)
        {
            string spacer = " ";
            int count = 0;

            try
            {
                while (!tk.IsCancellationRequested)
                {
                    Console.Clear();
                    Console.WriteLine(spacer + ch);

                    await Task.Delay(500, tk);

                    spacer += " ";
                    count++;
                }
            }
            catch (Exception)
            {
                return count;
            }
            return count;
        }
    }
}
