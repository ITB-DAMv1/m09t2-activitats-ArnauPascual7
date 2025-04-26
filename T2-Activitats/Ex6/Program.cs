namespace Ex6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread c1 = new Thread(() => Race(1, GetMinSleep(), GetMaxSleep()));
            Thread c2 = new Thread(() => Race(2, GetMinSleep(), GetMaxSleep()));
            Thread c3 = new Thread(() => Race(3, GetMinSleep(), GetMaxSleep()));
            Thread c4 = new Thread(() => Race(4, GetMinSleep(), GetMaxSleep()));
            Thread c5 = new Thread(() => Race(5, GetMinSleep(), GetMaxSleep()));

            c1.Start();
            c2.Start();
            c3.Start();
            c4.Start();
            c5.Start();

            c1.Join();
            c2.Join();
            c3.Join();
            c4.Join();
            c5.Join();

            Console.WriteLine("Fi de la cursa");
        }

        public static void Race(int camelNum, int minSleep, int maxSleep)
        {
            Random random = new Random();

            string spaces = new string('\t', (camelNum - 1) * 2);

            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine($"{spaces}Camell {camelNum}: {i}");
                Thread.Sleep(random.Next(minSleep, maxSleep));
            }

            Console.WriteLine($"\nEl camell {camelNum} ha finalitzat la cursa!\n");
        }

        public static int GetMinSleep()
        {
            return new Random().Next(100, 200);
        }
        public static int GetMaxSleep()
        {
            return new Random().Next(300, 600);
        }
    }
}
